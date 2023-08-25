using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.Metadata;
using Vintasoft.Imaging.Print;
using Vintasoft.Imaging.Spelling;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UIActions;
using Vintasoft.Imaging.Undo;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.Formatters;
#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Annotation.Pdf.Print;
#else
using Vintasoft.Imaging.Annotation.Print;
#endif
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools;

using DemosCommonCode;
using DemosCommonCode.Annotation;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Office;
#if !REMOVE_PDF_PLUGIN
using DemosCommonCode.Pdf;
#endif
using DemosCommonCode.Spelling;
using DemosCommonCode.Twain;
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI.Comments;


namespace DocumentViewerDemo
{
    /// <summary>
    /// Main form of "Document Viewer" demo application.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Constants

        /// <summary>
        /// The value, in screen pixels, that defines how annotation position will be changed when user pressed arrow key.
        /// </summary>
        const int ANNOTATION_KEYBOARD_MOVE_DELTA = 2;

        /// <summary>
        /// The value, in screen pixels, that defines how annotation size will be changed when user pressed "+/-" key.
        /// </summary>
        const int ANNOTATION_KEYBOARD_RESIZE_DELTA = 4;

        #endregion



        #region Fields

        /// <summary>
        /// Template of application title.
        /// </summary>
        string _titlePrefix = "VintaSoft Document Viewer Demo v" + ImagingGlobalSettings.ProductVersion + " - {0}";

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleModeSelectedMenuItem;

        /// <summary>
        /// Dictionary: the tool strip menu item => the annotation type.
        /// </summary>
        Dictionary<ToolStripMenuItem, AnnotationType> _toolStripMenuItemToAnnotationType =
            new Dictionary<ToolStripMenuItem, AnnotationType>();


        /// <summary>
        /// Name of opened image file.
        /// </summary>
        string _sourceFilename = null;

        /// <summary>
        /// Determines that file is opened in read-only mode.
        /// </summary>
        bool _isFileReadOnlyMode = false;

        /// <summary>
        /// A value indicating whether the source image file is changing.
        /// </summary> 
        bool _isSourceChanging = false;

        /// <summary>
        /// Manages asynchronous operations of an annotation viewer images.
        /// </summary>
        ImageViewerImagesManager _imagesManager;

        /// <summary>
        /// Filename, where image collection must be saved.
        /// </summary>
        string _saveFilename;

        /// <summary>
        /// Start time of image loading.
        /// </summary>
        DateTime _imageLoadingStartTime;
        /// <summary>
        /// Time of image loading.
        /// </summary>
        TimeSpan _imageLoadingTime = TimeSpan.Zero;


        /// <summary>
        /// The visual tool that allows to search and select text on document page.
        /// </summary>
        TextSelectionTool _textSelectionTool;

        /// <summary>
        /// The visual tool that allows to navigate document.
        /// </summary>
        DocumentNavigationTool _navigationTool;


        /// <summary>
        /// List of initialized annotations.
        /// </summary>
        List<AnnotationData> _initializedAnnotations = new List<AnnotationData>();

        /// <summary>
        /// Focused annotation.
        /// </summary>
        AnnotationData _focusedAnnotationData = null;

        /// <summary>
        /// Determines that annotation transforming is started.
        /// </summary>
        bool _isAnnotationTransforming = false;

        /// <summary>
        /// Manager of interaction areas.
        /// </summary>
        AnnotationInteractionAreaAppearanceManager _interactionAreaAppearanceManager;

        /// <summary>
        /// Handler of changes of annotation's IRuler.UnitOfMeasure property.
        /// </summary>
        RulerAnnotationPropertyChangedEventHandler _rulerAnnotationPropertyChangedEventHandler;


        /// <summary>
        /// Print manager.
        /// </summary>
        ImageViewerPrintManager _thumbnailViewerPrintManager;


        /// <summary>
        /// The undo manager.
        /// </summary>
        CompositeUndoManager _undoManager;

        /// <summary>
        /// The undo monitor of annotation viewer.
        /// </summary>
        CustomAnnotationViewerUndoMonitor _annotationViewerUndoMonitor;

        /// <summary>
        /// A form with annotation history.
        /// </summary>
        UndoManagerHistoryForm _historyForm;


        /// <summary>
        /// Simple TWAIN manager.
        /// </summary>
        SimpleTwainManager _simpleTwainManager;


        /// <summary>
        /// Determines that form of application is closing.
        /// </summary>
        bool _isFormClosing = false;

        /// <summary>
        /// The comment visual tool.
        /// </summary>
        CommentVisualTool _commentVisualTool;

        /// <summary>
        /// Manages the layout settings of DOCX document image collections.
        /// </summary>
        ImageCollectionDocxLayoutSettingsManager _imageCollectionDocxLayoutSettingsManager;

        /// <summary>
        /// Manages the layout settings of XLSX document image collections.
        /// </summary>
        ImageCollectionXlsxLayoutSettingsManager _imageCollectionXlsxLayoutSettingsManager;

        #endregion



        #region Constructors

        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            PdfAnnotationsAssemblyLoader.Load();
            DocxAssemblyLoader.Load();
            DicomAssemblyLoader.Load();
            RawAssemblyLoader.Load();

            ImagingTypeEditorRegistrator.Register();
            AnnotationTypeEditorRegistrator.Register();

#if !REMOVE_OFFICE_PLUGIN
            AnnotationOfficeUIAssembly.Init();

            DemosCommonCode.Office.OfficeDocumentVisualEditorForm documentVisualEditorForm = new DemosCommonCode.Office.OfficeDocumentVisualEditorForm();
            documentVisualEditorForm.Owner = this;
            documentVisualEditorForm.AddVisualTool(annotationViewer1.AnnotationVisualTool);
#endif

            // set CustomFontProgramsController for all opened documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            InitAddAnnotationMenuItems();

            InitImageDisplayMode();

            InitUndoManager();

            InitImagesManager();

            // init document navigation tool
            InitNavigationTool();

            // init text selection tool
            InitTextSelectionTool();

            AnnotationCommentController annotationCommentController = new AnnotationCommentController(annotationViewer1.AnnotationDataController);
            ImageViewerCommentController imageViewerCommentsController = new ImageViewerCommentController(annotationCommentController);

            _commentVisualTool = new CommentVisualTool(imageViewerCommentsController, new CommentControlFactory());
            annotationCommentsControl1.ImageViewer = annotationViewer1;
            annotationCommentsControl1.CommentTool = _commentVisualTool;
            annotationCommentsControl1.AnnotationTool = annotationViewer1.AnnotationVisualTool;

            // set default visual tool
            annotationViewer1.VisualTool = new CompositeVisualTool(
                _commentVisualTool,
#if !REMOVE_OFFICE_PLUGIN
               new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
                annotationViewer1.AnnotationVisualTool,
                _navigationTool,
                _textSelectionTool,
                annotationViewer1.AnnotationSelectionTool);
            visualToolsToolStrip1.MandatoryVisualTool = annotationViewer1.VisualTool;
            visualToolsToolStrip1.ImageViewer = annotationViewer1;

            // bind viewer to tool strips
            visualToolsToolStrip1.ImageViewer = annotationViewer1;
            annotationsToolStrip1.AnnotationViewer = annotationViewer1;
            annotationsToolStrip1.CommentBuilder = new AnnotationCommentBuilder(_commentVisualTool, annotationViewer1.AnnotationVisualTool);

            NoneAction noneAction = visualToolsToolStrip1.FindAction<NoneAction>();
            noneAction.Activated += NoneAction_Activated;
            noneAction.Deactivated += NoneAction_Deactivated;

            _interactionAreaAppearanceManager = new AnnotationInteractionAreaAppearanceManager();
            _interactionAreaAppearanceManager.VisualTool = annotationViewer1.AnnotationVisualTool;

            CloseCurrentFile();

            DemosTools.SetTestFilesFolder(openFileDialog);

            // set default rendering settings
#if REMOVE_PDF_PLUGIN && REMOVE_OFFICE_PLUGIN
            annotationViewer1.ImageRenderingSettings = RenderingSettings.Empty;
#elif REMOVE_OFFICE_PLUGIN
            annotationViewer1.ImageRenderingSettings = new PdfRenderingSettings();
#elif REMOVE_PDF_PLUGIN
            annotationViewer1.ImageRenderingSettings = new CompositeRenderingSettings(
                new DocxRenderingSettings(),
                new XlsxRenderingSettings());
#else
            annotationViewer1.ImageRenderingSettings = new CompositeRenderingSettings(
                new PdfRenderingSettings(),
                new DocxRenderingSettings(),
                new XlsxRenderingSettings());
#endif

            annotationViewer1.AnnotationVisualTool.SpellChecker = SpellCheckTools.CreateSpellCheckManager();
            annotationViewer1.AnnotationDataController.AnnotationDataDeserializationException += new EventHandler<AnnotationDataDeserializationExceptionEventArgs>(AnnotationDataController_AnnotationDataDeserializationException);
            annotationViewer1.MouseMove += new MouseEventHandler(annotationViewer1_MouseMove);

            annotationViewer1.KeyPress += new KeyPressEventHandler(annotationViewer1_KeyPress);
            annotationViewer1.FocusedAnnotationViewChanged += new EventHandler<AnnotationViewChangedEventArgs>(annotationViewer1_SelectedAnnotationChanged);
            annotationViewer1.SelectedAnnotations.Changed += new EventHandler(SelectedAnnotations_Changed);
            annotationViewer1.AnnotationInteractionModeChanged += new EventHandler<AnnotationInteractionModeChangedEventArgs>(annotationViewer1_AnnotationInteractionModeChanged);
            annotationViewer1.AnnotationVisualTool.ActiveInteractionControllerChanged += new PropertyChangedEventHandler<IInteractionController>(AnnotationVisualTool_ActiveInteractionControllerChanged);
            annotationViewer1.AutoScrollPositionExChanging += new PropertyChangingEventHandler<PointF>(annotationViewer1_AutoScrollPositionExChanging);
            annotationViewer1.AnnotationBuildingStarted += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingStarted);
            annotationViewer1.AnnotationBuildingFinished += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingFinished);
            annotationViewer1.AnnotationBuildingCanceled += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingCanceled);
            annotationViewer1.Images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(SavingProgress);
            annotationViewer1.Images.ImageCollectionSavingFinished += new EventHandler(images_ImageCollectionSavingFinished);
            annotationViewer1.Images.ImageSavingException += new EventHandler<ExceptionEventArgs>(Images_ImageSavingException);

            InitPrintManager();

            // remember current image scale mode
            _imageScaleModeSelectedMenuItem = bestFitToolStripMenuItem;

            // initialize color management in viewer
            ColorManagementHelper.EnableColorManagement(annotationViewer1);

            // update the UI
            UpdateUI();

            // create handler of changes of annotation's IRuler.UnitOfMeasure property
            _rulerAnnotationPropertyChangedEventHandler = new RulerAnnotationPropertyChangedEventHandler(annotationViewer1);

            DemosTools.CatchVisualToolExceptions(annotationViewer1);

            InitCustomAnnotations();

#if !REMOVE_PDF_PLUGIN
            // enable PDF Password Dialog
            PdfAuthenticateTools.EnableAuthenticateRequest = true;
#endif

            moveAnnotationsBetweenImagesToolStripMenuItem.Checked = annotationViewer1.CanMoveAnnotationsBetweenImages;

            // init visual tools
            InitVisualToolsToolStrip();

            DocumentPasswordForm.EnableAuthentication(annotationViewer1);

#if !REMOVE_OFFICE_PLUGIN
            // specify that image collection of annotation viewer  must handle layout settings requests
            _imageCollectionDocxLayoutSettingsManager = new ImageCollectionDocxLayoutSettingsManager(annotationViewer1.Images);
            _imageCollectionXlsxLayoutSettingsManager = new ImageCollectionXlsxLayoutSettingsManager(annotationViewer1.Images);
#else
            documentLayoutSettingsToolStripMenuItem.Visible = false;
#endif

        }

        #endregion



        #region Properties

        bool _isFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether file is opening.
        /// </summary>
        internal bool IsFileOpening
        {
            get
            {
                return _isFileOpening;
            }
            set
            {
                _isFileOpening = value;

                if (_isFileOpening)
                {
                    Cursor = Cursors.AppStarting;
                }
                else
                {
                    Cursor = Cursors.Default;
                    annotationViewer1.Focus();
                }

                UpdateUI();
            }
        }

        bool _isFileSaving = false;
        /// <summary>
        /// Gets or sets a value indicating whether file is saving.
        /// </summary>
        internal bool IsFileSaving
        {
            get
            {
                return _isFileSaving;
            }
            set
            {
                _isFileSaving = value;

                if (InvokeRequired)
                    InvokeUpdateUI();
                else
                    UpdateUI();
            }
        }

        bool _isTextSearching = false;
        /// <summary>
        /// Gets or sets a value indicating whether text search is in progress.
        /// </summary>
        internal bool IsTextSearching
        {
            get
            {
                return _isTextSearching;
            }
            set
            {
                _isTextSearching = value;

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region Init

        /// <summary>
        /// Initializes the "Annotation" -> "Menu" menu items.
        /// </summary>
        private void InitAddAnnotationMenuItems()
        {
            _toolStripMenuItemToAnnotationType.Clear();

            _toolStripMenuItemToAnnotationType.Add(rectangleToolStripMenuItem, AnnotationType.Rectangle);
            _toolStripMenuItemToAnnotationType.Add(ellipseToolStripMenuItem, AnnotationType.Ellipse);
            _toolStripMenuItemToAnnotationType.Add(highlightToolStripMenuItem, AnnotationType.Highlight);
            _toolStripMenuItemToAnnotationType.Add(textHighlightToolStripMenuItem, AnnotationType.TextHighlight);
            _toolStripMenuItemToAnnotationType.Add(embeddedImageToolStripMenuItem, AnnotationType.EmbeddedImage);
            _toolStripMenuItemToAnnotationType.Add(referencedImageToolStripMenuItem, AnnotationType.ReferencedImage);
            _toolStripMenuItemToAnnotationType.Add(textToolStripMenuItem, AnnotationType.Text);
            _toolStripMenuItemToAnnotationType.Add(stickyNoteToolStripMenuItem, AnnotationType.StickyNote);
            _toolStripMenuItemToAnnotationType.Add(freeTextToolStripMenuItem, AnnotationType.FreeText);
            _toolStripMenuItemToAnnotationType.Add(rubberStampToolStripMenuItem, AnnotationType.RubberStamp);
            _toolStripMenuItemToAnnotationType.Add(linkToolStripMenuItem, AnnotationType.Link);
            _toolStripMenuItemToAnnotationType.Add(lineToolStripMenuItem, AnnotationType.Line);
            _toolStripMenuItemToAnnotationType.Add(linesToolStripMenuItem, AnnotationType.Lines);
            _toolStripMenuItemToAnnotationType.Add(linesWithInterpolationToolStripMenuItem, AnnotationType.LinesWithInterpolation);
            _toolStripMenuItemToAnnotationType.Add(freehandLinesToolStripMenuItem, AnnotationType.FreehandLines);
            _toolStripMenuItemToAnnotationType.Add(polygonToolStripMenuItem, AnnotationType.Polygon);
            _toolStripMenuItemToAnnotationType.Add(polygonWithInterpolationToolStripMenuItem, AnnotationType.PolygonWithInterpolation);
            _toolStripMenuItemToAnnotationType.Add(freehandPolygonToolStripMenuItem, AnnotationType.FreehandPolygon);
            _toolStripMenuItemToAnnotationType.Add(rulerToolStripMenuItem, AnnotationType.Ruler);
            _toolStripMenuItemToAnnotationType.Add(rulersToolStripMenuItem, AnnotationType.Rulers);
            _toolStripMenuItemToAnnotationType.Add(angleToolStripMenuItem, AnnotationType.Angle);
            _toolStripMenuItemToAnnotationType.Add(triangleCustomAnnotationToolStripMenuItem, AnnotationType.Triangle);
            _toolStripMenuItemToAnnotationType.Add(markCustomAnnotationToolStripMenuItem, AnnotationType.Mark);
        }

        /// <summary>
        /// Initializes the text selection tool.
        /// </summary>
        private void InitTextSelectionTool()
        {
            _textSelectionTool = new TextSelectionTool(new SolidBrush(Color.FromArgb(56, Color.Blue)));
            _textSelectionTool.SelectionChanged += new EventHandler(_textSelectionTool_SelectionChanged);
            _textSelectionTool.TextSearching += new EventHandler(_textSelectionTool_TextSearching);
            _textSelectionTool.TextSearchingProgress += new EventHandler<TextSearchingProgressEventArgs>(_textSelectionTool_TextSearchingProgress);
            _textSelectionTool.TextSearched += new EventHandler<TextSearchedEventArgs>(_textSelectionTool_TextSearched);
            _textSelectionTool.TextExtractionProgress += new EventHandler<ProgressEventArgs>(TextSelectionTool_TextExtractionProgress);
            _textSelectionTool.IsMouseSelectionEnabled = true;
            _textSelectionTool.IsKeyboardSelectionEnabled = true;
            textSelectionControl1.TextSelectionTool = _textSelectionTool;
            findTextToolStrip1.TextSelectionTool = _textSelectionTool;
        }

        /// <summary>
        /// Initializes the document navigation tool.
        /// </summary>
        private void InitNavigationTool()
        {
            _navigationTool = new DocumentNavigationTool();
            _navigationTool.ActionExecutor = new PageContentActionCompositeExecutor(
                new UriActionExecutor(),
                new LaunchActionExecutor(),
                _navigationTool.ActionExecutor);
            _navigationTool.FocusedActionChanged +=
                new PropertyChangedEventHandler<PageContentActionMetadata>(NavigationTool_FocusedActionChanged);
        }

        /// <summary>
        /// Initializes custom annotations.
        /// </summary>
        private void InitCustomAnnotations()
        {
            // register view for mark annotation data
            AnnotationViewFactory.RegisterViewForAnnotationData(
               typeof(MarkAnnotationData),
               typeof(MarkAnnotationView));
            // register view for triangle annotation data
            AnnotationViewFactory.RegisterViewForAnnotationData(
                typeof(TriangleAnnotationData),
                typeof(TriangleAnnotationView));

            // define custom serialization binder for correct deserialization of TriangleAnnotation v6.1 and earlier
            AnnotationSerializationBinder.Current = new CustomAnnotationSerializationBinder();
        }

        /// <summary>
        /// Initializes the undo manager.
        /// </summary>
        private void InitUndoManager()
        {
            _undoManager = new CompositeUndoManager();
            _undoManager.UndoLevel = 100;
            _undoManager.IsEnabled = false;
            _undoManager.Changed += new EventHandler<UndoManagerChangedEventArgs>(annotationUndoManager_Changed);
            _undoManager.Navigated += new EventHandler<UndoManagerNavigatedEventArgs>(annotationUndoManager_Navigated);

            _annotationViewerUndoMonitor = new CustomAnnotationViewerUndoMonitor(_undoManager, annotationViewer1);
        }

        /// <summary>
        /// Initializes the images manager.
        /// </summary>
        private void InitImagesManager()
        {
            // create images manager
            _imagesManager = new ImageViewerImagesManager(annotationViewer1);
            _imagesManager.IsAsync = true;
            _imagesManager.AddStarting += new EventHandler(ImagesManager_AddStarting);
            _imagesManager.AddFinished += new EventHandler(ImagesManager_AddFinished);
            _imagesManager.ImageSourceAddStarting += new EventHandler<ImageSourceEventArgs>(ImagesManager_ImageSourceAddStarting);
            _imagesManager.ImageSourceAddFinished += new EventHandler<ImageSourceEventArgs>(ImagesManager_ImageSourceAddFinished);
            _imagesManager.ImageSourceAddException += new EventHandler<ImageSourceExceptionEventArgs>(ImagesManager_ImageSourceAddException);
        }

        /// <summary>
        /// Initializes the print manager.
        /// </summary>
        private void InitPrintManager()
        {
            // create annotated image print document
            ImagePrintDocument annotatedImagePrintDocument;
#if REMOVE_PDF_PLUGIN
            annotatedImagePrintDocument = new AnnotatedImagePrintDocument(thumbnailViewer1.AnnotationDataController);
#else
            annotatedImagePrintDocument = new AnnotatedPdfPrintDocument(thumbnailViewer1.AnnotationDataController);
#endif
            annotatedImagePrintDocument.Center = false;
            annotatedImagePrintDocument.DistanceBetweenImages = 0;
            annotatedImagePrintDocument.PrintScaleMode = PrintScaleMode.BestFit;

            printDialog1.Document = annotatedImagePrintDocument;
            pageSetupDialog1.Document = annotatedImagePrintDocument;

            // create the print manager
            _thumbnailViewerPrintManager = new ImageViewerPrintManager(
                thumbnailViewer1, annotatedImagePrintDocument, printDialog1);

            _thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation = false;
            _thumbnailViewerPrintManager.PrintDocument.Center = true;
            pageAutoOrientationToolStripMenuItem.Checked = _thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation;
            centerPrintingPageToolStripMenuItem.Checked = _thumbnailViewerPrintManager.PrintDocument.Center;
        }

        /// <summary>
        /// Initializes image display mode.
        /// </summary>
        private void InitImageDisplayMode()
        {
            // init "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Tag = ImageViewerDisplayMode.SinglePage;
            twoColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoColumns;
            singleContinuousRowToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousRow;
            singleContinuousColumnToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousColumn;
            twoContinuousRowsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousRows;
            twoContinuousColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousColumns;
        }

        /// <summary>
        /// Initializes elements of visual tools toolstrip.
        /// </summary>
        private void InitVisualToolsToolStrip()
        {
            // create action, which allows to measure objects on image in image viewer
            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);

            // create different zoom actions
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);

            // create action, which allows to crop an image in image viewer
            VisualToolAction cropSelectionToolAction = new VisualToolAction(
               new CropSelectionTool(),
               "Crop Selection",
               "Crop Selection",
               DemosResourcesManager.GetResourceAsBitmap("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.ImageProcessingVisualTools.Resources.CropSelectionTool.png"));
            visualToolsToolStrip1.AddAction(cropSelectionToolAction);

            // create action, which allows to pan an image in image viewer
            VisualToolAction panToolAction = new VisualToolAction(
                new PanTool(),
                "Pan Tool",
                "Pan",
                DemosResourcesManager.GetResourceAsBitmap("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.ImageProcessingVisualTools.Resources.PanTool.png"));
            visualToolsToolStrip1.AddAction(panToolAction);

            // create action, which allows to scroll pages in image viewer
            VisualToolAction scrollPagesVisualToolAction = new VisualToolAction(
                new ScrollPages(),
                "Scroll Pages",
                "Scroll Pages",
                DemosResourcesManager.GetResourceAsBitmap("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.CustomVisualTools.Resources.ScrollPagesTool.png"));
            visualToolsToolStrip1.AddAction(scrollPagesVisualToolAction);
        }

        #endregion


        #region MainForm

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (annotationViewer1.Focused && annotationViewer1.VisualTool != null)
            {
                if (!annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                {
                    if (keyData == Keys.Tab)
                    {
                        if (annotationViewer1.VisualTool.PerformNextItemSelection(true))
                            return true;
                    }
                    else if (keyData == (Keys.Shift | Keys.Tab))
                    {
                        if (annotationViewer1.VisualTool.PerformNextItemSelection(false))
                            return true;
                    }
                }
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Add))
            {
                RotateViewClockwise();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Subtract))
            {
                RotateViewCounterClockwise();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Handles the Shown event of MainForm object.
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // process command line of the application
            string[] appArgs = Environment.GetCommandLineArgs();
            if (appArgs.Length > 0)
            {
                Application.DoEvents();
                if (appArgs.Length == 2)
                {
                    try
                    {
                        // add image file to the annotation viewer
                        OpenFile(appArgs[1]);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
                else
                {
                    // get filenames from application arguments
                    string[] filenames = new string[appArgs.Length - 1];
                    Array.Copy(appArgs, 1, filenames, 0, filenames.Length);

                    try
                    {
                        // add image file(s) to image collection of the annotation viewer
                        AddFiles(filenames);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                }
            }

            thumbnailViewer1.Focus();
        }

        /// <summary>
        /// Main form is closing.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;
        }

        /// <summary>
        /// Main form is closed.
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseCurrentFile();
            _annotationViewerUndoMonitor.Dispose();
            _undoManager.Dispose();

            _interactionAreaAppearanceManager.Dispose();

            AnnotationVisualTool annotationVisualTool = annotationViewer1.AnnotationVisualTool;
            if (annotationVisualTool.SpellChecker != null)
            {
                SpellCheckManager manager = annotationVisualTool.SpellChecker;
                annotationVisualTool.SpellChecker = null;
                SpellCheckTools.DisposeSpellCheckManagerAndEngines(manager);
            }

            _imagesManager.Dispose();
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // get the current status of application
            bool isFileOpening = IsFileOpening;
            bool isFileLoaded = _sourceFilename != null;
            bool isTextSearching = IsTextSearching;
            bool isFileReadOnlyMode = _isFileReadOnlyMode;
            bool isFileEmpty = true;
            if (annotationViewer1.Images != null)
                isFileEmpty = annotationViewer1.Images.Count <= 0;
            bool isFileSaving = IsFileSaving;
            bool isImageSelected = annotationViewer1.Image != null;
            bool isAnnotationEmpty = true;
            if (isImageSelected)
                isAnnotationEmpty = annotationViewer1.AnnotationDataController[annotationViewer1.FocusedIndex].Count <= 0;
            bool isAnnotationSelected = annotationViewer1.FocusedAnnotationView != null || annotationViewer1.SelectedAnnotations.Count > 0;
            bool isAnnotationBuilding = annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            bool isInteractionModeAuthor = annotationViewer1.AnnotationInteractionMode == AnnotationInteractionMode.Author;
            bool isCanUndo = _undoManager.UndoCount > 0 && !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            bool isCanRedo = _undoManager.RedoCount > 0 && !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;

            // "File" menu
            fileToolStripMenuItem.Enabled = !isFileSaving;
            openToolStripMenuItem.Enabled = !isFileOpening && !isTextSearching;
            addToolStripMenuItem.Enabled = !isTextSearching;
            documentLayoutSettingsToolStripMenuItem.Enabled = !isFileOpening && !isTextSearching;
            saveToolStripMenuItem.Enabled = !isFileOpening && isFileLoaded && !isFileEmpty && !isFileReadOnlyMode && !isTextSearching;
            saveAsToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && !isTextSearching;
            closeAllToolStripMenuItem.Enabled = !isFileEmpty || isFileOpening;
            printToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && !IsFileSaving;

            // "Edit" menu
            editToolStripMenuItem.Enabled = !isFileEmpty && !isFileSaving;
            if (!editToolStripMenuItem.Enabled)
                CloseHistoryForm();
            enableUndoRedoToolStripMenuItem.Checked = _undoManager.IsEnabled;
            undoToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving && isCanUndo;
            redoToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving && isCanRedo;
            historyDialogToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving;

            // "View" menu
            findTextToolStripMenuItem.Enabled = !isTextSearching &&
                                                _textSelectionTool.FocusedImageHasTextRegion &&
                                                textSelectionToolStripMenuItem.Checked;
            moveAnnotationsBetweenImagesToolStripMenuItem.Enabled =
                annotationViewer1.DisplayMode != ImageViewerDisplayMode.SinglePage;
            documentMetadataToolStripMenuItem.Enabled = !isFileEmpty;

            // update "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Checked = false;
            twoColumnsToolStripMenuItem.Checked = false;
            singleContinuousRowToolStripMenuItem.Checked = false;
            singleContinuousColumnToolStripMenuItem.Checked = false;
            twoContinuousRowsToolStripMenuItem.Checked = false;
            twoContinuousColumnsToolStripMenuItem.Checked = false;
            switch (annotationViewer1.DisplayMode)
            {
                case ImageViewerDisplayMode.SinglePage:
                    singlePageToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoColumns:
                    twoColumnsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousRow:
                    singleContinuousRowToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousColumn:
                    singleContinuousColumnToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousRows:
                    twoContinuousRowsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousColumns:
                    twoContinuousColumnsToolStripMenuItem.Checked = true;
                    break;
            }
            spellCheckSettingsToolStripMenuItem.Enabled = annotationViewer1.AnnotationVisualTool.SpellChecker != null;


            // "Annotations" menu
            //
            annotationsInfoToolStripMenuItem.Enabled = !isFileEmpty;
            //
            interactionModeToolStripMenuItem.Enabled = !isFileEmpty;
            //
            loadFromFileToolStripMenuItem.Enabled = !isFileEmpty;
            saveToFileToolStripMenuItem.Enabled = !isAnnotationEmpty && !isFileSaving;
            //
            addAnnotationToolStripMenuItem.Enabled = !isFileEmpty && isInteractionModeAuthor;
            buildAnnotationsContinuouslyToolStripMenuItem.Enabled = !isFileEmpty;
            //
            bringToBackToolStripMenuItem.Enabled = !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding && isAnnotationSelected;
            bringToFrontToolStripMenuItem.Enabled = !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding && isAnnotationSelected;
            //
            multiSelectToolStripMenuItem.Enabled = !isFileEmpty;
            //
            groupUngroupSelectedToolStripMenuItem.Enabled = !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            groupAllToolStripMenuItem.Enabled = !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            //
            rotateImageWithAnnotationsToolStripMenuItem.Enabled = !isFileEmpty;
            burnAnnotationsOnImageToolStripMenuItem.Enabled = !isAnnotationEmpty;
            cloneImageWithAnnotationsToolStripMenuItem.Enabled = !isFileEmpty;
            saveImageWithAnnotationsToolStripMenuItem.Enabled = !isAnnotationEmpty && !isFileSaving;
            copyImageToClipboardToolStripMenuItem.Enabled = isImageSelected;
            deleteImageToolStripMenuItem.Enabled = isImageSelected && !isFileSaving;

            // annotation tool strip 
            annotationsToolStrip1.Enabled = !isFileEmpty;

            // thumbnailViewer1 & annotationViewer1 & propertyGrid1 & annotationComboBox
            zoomPanel.Enabled = !isFileEmpty;
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                annotationComboBox.Enabled = false;
            else
                annotationComboBox.Enabled = true;

            // thumbnail viewer
            thumbnailViewer1.Enabled = !isTextSearching;

            // thumbnailViewer context menu
            thumbnailViewer1.DisableThumbnailContextMenu = isFileSaving;

            // viewer tool strip
            viewerToolStrip.Enabled = !isFileSaving;
            viewerToolStrip.OpenButtonEnabled = openToolStripMenuItem.Enabled;
            viewerToolStrip.SaveButtonEnabled = saveAsToolStripMenuItem.Enabled;
            viewerToolStrip.ScanButtonEnabled = !isFileOpening && !isTextSearching;
            viewerToolStrip.PrintButtonEnabled = printToolStripMenuItem.Enabled;

            // set window title
            if (!isFileOpening)
            {
                string str;
                if (_sourceFilename != null)
                    str = Path.GetFileName(_sourceFilename);
                else
                    str = "(Untitled)";

                if (_isFileReadOnlyMode)
                    str += " [Read Only]";

                Text = string.Format(_titlePrefix, str);
            }
        }

        /// <summary>
        /// Update UI safely.
        /// </summary>
        private void InvokeUpdateUI()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Clears image collection of annotation viewer and
        /// adds image(s) to an image collection of annotation viewer.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set file filters in Open file dialog
            CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog);
            // add text file filter to the Open file dialog
            AddTxtFileFilterToOpenFileDialog(openFileDialog);

            // select image file
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // add image file to annotation viewer as a source
                    OpenFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Adds image(s) to an image collection of annotation viewer.
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog);
            // add text file filter to the Open file dialog
            AddTxtFileFilterToOpenFileDialog(openFileDialog);

            openFileDialog.Multiselect = true;

            // select image file(s)
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // add image file(s) to image collection of the annotation viewer
                    AddFiles(openFileDialog.FileNames);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            openFileDialog.Multiselect = false;
        }

        /// <summary>
        /// Handles the Click event of DocxLayoutSettingsToolStripMenuItem object.
        /// </summary>
        private void docxLayoutSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageCollectionDocxLayoutSettingsManager.EditLayoutSettingsUseDialog();
        }

        /// <summary>
        /// Handles the Click event of XlsxLayoutSettingsToolStripMenuItem object.
        /// </summary>
        private void xlsxLayoutSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _imageCollectionXlsxLayoutSettingsManager.EditLayoutSettingsUseDialog();
        }

        /// <summary>
        /// Saves image collection with annotations to the first source of image collection,
        /// i.e. saves modified image collection with annotations back to the source file.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToSourceFile();
        }

        /// <summary>
        /// Saves image collection with annotations of annotation viewer to new source and
        /// switches to the new source.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImageCollectionToNewFile(true);
        }

        /// <summary>
        /// Closes the current file.
        /// </summary>
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Shows a page settings dialog.
        /// </summary>
        private void pageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of PageAutoOrientationToolStripMenuItem object.
        /// </summary>
        private void pageAutoOrientationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool value = !_thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation;
            _thumbnailViewerPrintManager.PrintDocument.UseImageAutoOrienation = value;
            pageAutoOrientationToolStripMenuItem.Checked = value;
        }
        /// <summary>
        /// Handles the Click event of CenterPrintingPageToolStripMenuItem object.
        /// </summary>
        private void centerPrintingPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool value = !_thumbnailViewerPrintManager.PrintDocument.Center;
            _thumbnailViewerPrintManager.PrintDocument.Center = value;
            centerPrintingPageToolStripMenuItem.Checked = value;
        }

        /// <summary>
        /// Prints images with annotations.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thumbnailViewerPrintManager.Print();
        }

        /// <summary>
        /// Acquires image(s) from scanner.
        /// </summary>
        private void scanViewerToolStripButton_Click(object sender, EventArgs e)
        {
            bool viewerToolStripCanScan = viewerToolStrip.CanScan;
            viewerToolStrip.ScanButtonEnabled = false;

            try
            {
                if (_simpleTwainManager == null)
                    _simpleTwainManager = new SimpleTwainManager(this, annotationViewer1.Images);

                _simpleTwainManager.SelectDeviceAndAcquireImage();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                viewerToolStrip.ScanButtonEnabled = viewerToolStripCanScan;
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'Edit' menu

        /// <summary>
        /// "Edit" menu is opening.
        /// </summary>
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateEditMenuItems();
        }

        /// <summary>
        /// Updates the UI action items in "Edit" menu.
        /// </summary>
        private void UpdateEditMenuItems()
        {
            // if the thumbnail viewer has the input focus
            if (thumbnailViewer1.Focused)
            {
                UpdateEditMenuItem(cutToolStripMenuItem, null, "Cut");
                UpdateEditMenuItem(copyToolStripMenuItem, null, "Copy");
                UpdateEditMenuItem(pasteToolStripMenuItem, null, "Paste");
                deleteToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Text = "Delete Page(s)";
                deleteAllToolStripMenuItem.Enabled = false;
                deleteAllToolStripMenuItem.Text = "Delete All";
                bool isFileEmpty = true;
                if (annotationViewer1.Images != null)
                    isFileEmpty = annotationViewer1.Images.Count <= 0;
                selectAllToolStripMenuItem.Enabled = !isFileEmpty && !IsFileOpening;
                selectAllToolStripMenuItem.Text = "Select All Pages";
                UpdateEditMenuItem(deselectAllToolStripMenuItem, null, "Deselect All");
            }
            // if the thumbnail viewer does NOT have the input focus
            else
            {
                UpdateEditMenuItem(cutToolStripMenuItem, GetUIAction<CutItemUIAction>(annotationViewer1.VisualTool), "Cut");
                UpdateEditMenuItem(copyToolStripMenuItem, GetUIAction<CopyItemUIAction>(annotationViewer1.VisualTool), "Copy");
                UpdateEditMenuItem(pasteToolStripMenuItem, GetUIAction<PasteItemUIAction>(annotationViewer1.VisualTool), "Paste");
                UpdateEditMenuItem(deleteToolStripMenuItem, GetUIAction<DeleteItemUIAction>(annotationViewer1.VisualTool), "Delete");
                UpdateEditMenuItem(deleteAllToolStripMenuItem, GetUIAction<DeleteAllItemsUIAction>(annotationViewer1.VisualTool), "Delete All");
                UpdateEditMenuItem(selectAllToolStripMenuItem, GetUIAction<SelectAllItemsUIAction>(annotationViewer1.VisualTool), "Select All");
                UpdateEditMenuItem(deselectAllToolStripMenuItem, GetUIAction<DeselectAllItemsUIAction>(annotationViewer1.VisualTool), "Deselect All");
            }
        }

        /// <summary>
        /// Updates the UI action item in "Edit" menu.
        /// </summary>
        /// <param name="menuItem">The "Edit" menu item.</param>
        /// <param name="uiAction">The UI action, which is associated with the "Edit" menu item.</param>
        /// <param name="defaultText">The default text for the "Edit" menu item.</param>
        private void UpdateEditMenuItem(ToolStripMenuItem editMenuItem, UIAction uiAction, string defaultText)
        {
            // if UI action is specified AND UI action is enabled
            if (uiAction != null && uiAction.IsEnabled)
            {
                // enable the menu item
                editMenuItem.Enabled = true;
                // set text to the menu item
                editMenuItem.Text = uiAction.Name;
            }
            else
            {
                // disable the menu item
                editMenuItem.Enabled = false;
                // set the default text to the menu item
                editMenuItem.Text = defaultText;
            }
        }

        /// <summary>
        /// Copies selected item into clipboard.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelectedItem();
        }

        /// <summary>
        /// Copies selected item into clipboard.
        /// </summary>
        private void CopySelectedItem()
        {
            // get UI action
            CopyItemUIAction copyUIAction = GetUIAction<CopyItemUIAction>(annotationViewer1.VisualTool);
            // if UI action is not empty AND UI action is enabled
            if (copyUIAction != null && copyUIAction.IsEnabled)
            {
                // execute action
                copyUIAction.Execute();
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Cuts selected item into clipboard.
        /// </summary>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutSelectedItem();
        }

        /// <summary>
        /// Cuts selected item into clipboard.
        /// </summary>
        private void CutSelectedItem()
        {
            // get UI action
            CutItemUIAction cutUIAction = GetUIAction<CutItemUIAction>(annotationViewer1.VisualTool);
            // if UI action is not empty AND UI action is enabled
            if (cutUIAction != null && cutUIAction.IsEnabled)
            {
                // begin the composite undo action
                _undoManager.BeginCompositeAction("AnnotationViewCollection: Cut");

                try
                {
                    cutUIAction.Execute();
                }
                finally
                {
                    // end the composite undo action
                    _undoManager.EndCompositeAction();
                }
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Pastes previously copied item from clipboard.
        /// </summary>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteItem();
        }

        /// <summary>
        /// Pastes previously copied item from clipboard.
        /// </summary>
        private void PasteItem()
        {
            // get UI action
            PasteItemWithOffsetUIAction pasteWithOffsetUIAction = GetUIAction<PasteItemWithOffsetUIAction>(annotationViewer1.VisualTool);
            // if UI action is not empty AND UI action is enabled
            if (pasteWithOffsetUIAction != null)
            {
                if (pasteWithOffsetUIAction.IsEnabled)
                {
                    pasteWithOffsetUIAction.OffsetX = 20;
                    pasteWithOffsetUIAction.OffsetY = 20;

                    _undoManager.BeginCompositeAction("AnnotationViewCollection: Paste");

                    try
                    {
                        pasteWithOffsetUIAction.Execute();
                    }
                    finally
                    {
                        _undoManager.EndCompositeAction();
                    }
                }
            }
            else
            {
                PasteItemUIAction pasteUIAction = GetUIAction<PasteItemUIAction>(annotationViewer1.VisualTool);
                if (pasteUIAction != null)
                    pasteUIAction.Execute();
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Removes selected annotation from annotation collection
        /// or page form page collection.
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if thumbnail viewer is focused
            if (thumbnailViewer1.Focused)
            {
                thumbnailViewer1.DoDelete();
            }
            else
            {
                // delete the selected annotation from image
                DeleteAnnotation(false);
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Removes all annotations from annotation collection.
        /// </summary>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete all annotations from image
            DeleteAnnotation(true);

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Selects all annotations of annotation collection
        /// or pages of page collection.
        /// </summary>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAllItems();
        }

        /// <summary>
        /// Selects all annotations of annotation collection
        /// or pages of page collection.
        /// </summary>
        private void SelectAllItems()
        {
            annotationViewer1.CancelAnnotationBuilding();

            // if thumbnail viewer is focused
            if (thumbnailViewer1.Focused)
            {
                thumbnailViewer1.DoSelectAll();
            }
            else
            {
                // get UI action
                SelectAllItemsUIAction selectAllUIAction = GetUIAction<SelectAllItemsUIAction>(annotationViewer1.VisualTool);
                // if UI action is not empty AND UI action is enabled
                if (selectAllUIAction != null && selectAllUIAction.IsEnabled)
                {
                    // execute UI action
                    selectAllUIAction.Execute();
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// Deselects all annotations of annotation collection.
        /// </summary>
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            // if thumbnail viewer is not focused
            if (!thumbnailViewer1.Focused)
            {
                // get UI action
                DeselectAllItemsUIAction deselectAllUIAction = GetUIAction<DeselectAllItemsUIAction>(annotationViewer1.VisualTool);
                // if UI action is not empty AND UI action is enabled
                if (deselectAllUIAction != null && deselectAllUIAction.IsEnabled)
                {
                    // execute UI action
                    deselectAllUIAction.Execute();
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// Opens text searching dialog.
        /// </summary>
        private void findTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FindTextForm findTextDialog = new FindTextForm(_textSelectionTool))
            {
                TabPage selectedTab = toolsTabControl.SelectedTab;
                toolsTabControl.SelectedTab = textExtractionTabPage;

                if (_textSelectionTool.HasSelectedText)
                    findTextDialog.FindWhat = _textSelectionTool.SelectedText;

                findTextDialog.ShowDialog();

                toolsTabControl.SelectedTab = selectedTab;
            }
        }

        /// <summary>
        /// Returns the UI action of the visual tool.
        /// </summary>
        /// <param name="visualTool">Visual tool.</param>
        /// <returns>The UI action of the visual tool.</returns>
        private T GetUIAction<T>(VisualTool visualTool)
            where T : UIAction
        {
            ISupportUIActions actionSource = visualTool as ISupportUIActions;
            if (actionSource != null)
                return UIAction.GetFirstUIAction<T>(actionSource);
            return default(T);
        }

        /// <summary>
        /// Enables/disables the undo manager.
        /// </summary>
        private void enableUndoRedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isUndoManagerEnabled = _undoManager.IsEnabled ^ true;


            if (!isUndoManagerEnabled)
            {
                CloseHistoryForm();

                _undoManager.Clear();
            }

            _undoManager.IsEnabled = isUndoManagerEnabled;

            UpdateUndoRedoMenu(_undoManager);

            // update UI
            UpdateUI();
        }

        /// <summary>
        /// Undoes changes in annotation collection or annotation.
        /// </summary>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                return;

            _undoManager.Undo(1);
            UpdateUI();
        }

        /// <summary>
        /// Redoes changes in annotation collection or annotation.
        /// </summary>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                return;

            _undoManager.Redo(1);
            UpdateUI();
        }

        /// <summary>
        /// "Annotation history" menu is clicked.
        /// </summary>
        private void historyDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyDialogToolStripMenuItem.Checked ^= true;

            if (historyDialogToolStripMenuItem.Checked)
                // show the image processing history form
                ShowHistoryForm();
            else
                // close the image processing history form
                CloseHistoryForm();
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Changes settings of thumbanil viewer.
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThumbnailViewerSettingsForm viewerSettingsDialog = new ThumbnailViewerSettingsForm(thumbnailViewer1);
            viewerSettingsDialog.ShowDialog();
        }

        /// <summary>
        /// Changes image display mode of annotation viewer.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            annotationViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            UpdateUI();
        }

        /// <summary>
        /// Enables/disables annotation tool.
        /// </summary>
        private void annotationToolToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (annotationViewer1 != null)
            {
                bool isAnnotationToolEnabled = annotationToolToolStripMenuItem.Checked;
                annotationViewer1.AnnotationVisualTool.Enabled = isAnnotationToolEnabled;
                annotationsToolStrip1.Enabled = isAnnotationToolEnabled;
                annotationPropertyGrid.Enabled = isAnnotationToolEnabled;
                annotationComboBox.Enabled = isAnnotationToolEnabled;
            }
        }

        /// <summary>
        /// Enables/disables text extraction tool.
        /// </summary>
        private void textSelectionToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool != null)
            {
                _textSelectionTool.Enabled = textSelectionToolStripMenuItem.Checked;
                if (!_textSelectionTool.Enabled)
                {
                    _textSelectionTool.FocusedTextSymbol = null;
                    _textSelectionTool.SelectedRegion = null;
                    textSelectionControl1.TextSelectionTool = null;
                }
                else
                {
                    textSelectionControl1.TextSelectionTool = _textSelectionTool;
                }
                findTextToolStripMenuItem.Enabled = textSelectionToolStripMenuItem.Checked;
                findTextToolStrip1.Enabled = textSelectionToolStripMenuItem.Checked;
            }
        }

        /// <summary>
        /// Enables/disables the document navigation tool.
        /// </summary>
        private void navigationToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_navigationTool != null)
                _navigationTool.Enabled = navigationToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Shows document metadata form.
        /// </summary>
        private void documentMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentMetadata metadata = annotationViewer1.Image.SourceInfo.Decoder.GetDocumentMetadata();

            if (metadata != null)
            {
                using (PropertyGridForm propertyForm = new PropertyGridForm(metadata, "Document Metadata"))
                {
                    propertyForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("File does not contain metadata.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Sets an image size mode.
        /// </summary>
        private void imageSizeMode_Click(object sender, EventArgs e)
        {
            // disable previously checked menu
            _imageScaleModeSelectedMenuItem.Checked = false;

            //
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            switch (item.Text)
            {
                case "Normal":
                    annotationViewer1.SizeMode = ImageSizeMode.Normal;
                    break;
                case "Best fit":
                    annotationViewer1.SizeMode = ImageSizeMode.BestFit;
                    break;
                case "Fit to width":
                    annotationViewer1.SizeMode = ImageSizeMode.FitToWidth;
                    break;
                case "Fit to height":
                    annotationViewer1.SizeMode = ImageSizeMode.FitToHeight;
                    break;
                case "Pixel to Pixel":
                    annotationViewer1.SizeMode = ImageSizeMode.PixelToPixel;
                    break;
                case "Scale":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    break;
                case "25%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 25;
                    break;
                case "50%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 50;
                    break;
                case "100%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 100;
                    break;
                case "200%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 200;
                    break;
                case "400%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 400;
                    break;
            }

            _imageScaleModeSelectedMenuItem = item;
            _imageScaleModeSelectedMenuItem.Checked = true;
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewClockwise();
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void rotateCounterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewCounterClockwise();
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void RotateViewClockwise()
        {
            if (annotationViewer1.ImageRotationAngle != 270)
            {
                annotationViewer1.ImageRotationAngle += 90;
                thumbnailViewer1.ImageRotationAngle += 90;
            }
            else
            {
                annotationViewer1.ImageRotationAngle = 0;
                thumbnailViewer1.ImageRotationAngle = 0;
            }
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void RotateViewCounterClockwise()
        {
            if (annotationViewer1.ImageRotationAngle != 0)
            {
                annotationViewer1.ImageRotationAngle -= 90;
                thumbnailViewer1.ImageRotationAngle -= 90;
            }
            else
            {
                annotationViewer1.ImageRotationAngle = 270;
                thumbnailViewer1.ImageRotationAngle = 270;
            }
        }

        /// <summary>
        /// Changes settings of annotation viewer.
        /// </summary>
        private void viewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageViewerSettingsForm dialog = new ImageViewerSettingsForm(annotationViewer1))
            {
                dialog.ShowDialog();
            }
            UpdateUI();
        }

        /// <summary>
        /// Changes the rendering settings of annotation viewer.
        /// </summary>
        private void viewerRenderingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CompositeRenderingSettingsForm viewerRenderingSettingsForm = new CompositeRenderingSettingsForm(annotationViewer1.ImageRenderingSettings))
            {
                viewerRenderingSettingsForm.ShowDialog();
            }
            UpdateUI();
        }

        /// <summary>
        /// Show settings of interaction area.
        /// </summary>
        private void interactionPointsAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InteractionAreaAppearanceManagerForm dialog = new InteractionAreaAppearanceManagerForm())
            {
                dialog.InteractionAreaSettings = _interactionAreaAppearanceManager;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Enables/disables the ability to move annotations between images.
        /// </summary>
        private void moveAnnotationsBetweenImagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            annotationViewer1.CanMoveAnnotationsBetweenImages = moveAnnotationsBetweenImagesToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Enables/disables usage of bounding box during creation/transformation of annotation.
        /// </summary>
        private void boundAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.IsAnnotationBoundingRectEnabled = boundAnnotationsToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Edits the spell check settings.
        /// </summary>
        private void spellCheckSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpellCheckManagerSettingsForm dialog = new SpellCheckManagerSettingsForm(
                annotationViewer1.AnnotationVisualTool.SpellChecker))
            {
                dialog.Owner = this;

                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Edits the spell check view settings.
        /// </summary>
        private void spellCheckViewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpellCheckManagerViewSettingsForm dialog = new SpellCheckManagerViewSettingsForm())
            {
                dialog.InteractionAreaSettings = _interactionAreaAppearanceManager;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Edits the color management settings.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorManagementSettingsForm.EditColorManagement(annotationViewer1);
        }

        #endregion


        #region 'Annotation' menu

        /// <summary>
        /// "Annotations" menu is opening.
        /// </summary>
        private void annotationsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // annotation viewer has the focused annotation AND focused annotation is line-based annotation
            if (annotationViewer1.FocusedAnnotationView != null && annotationViewer1.FocusedAnnotationView is LineAnnotationViewBase)
            {
                SetIsEnabled(transformationModeToolStripMenuItem, true);
                UpdateTransformationMenu();
            }
            else
            {
                SetIsEnabled(transformationModeToolStripMenuItem, false);
            }
        }

        /// <summary>
        /// Shows information about annotation collections of all images.
        /// </summary>
        private void annotationsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AnnotationsInfoForm dialog = new AnnotationsInfoForm(annotationViewer1.AnnotationDataController))
            {
                dialog.ShowDialog();
            }
        }


        #region Annotation interaction mode

        /// <summary>
        /// Changes the annotation interaction mode to None.
        /// </summary>
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.None;
        }

        /// <summary>
        /// Changes the annotation interaction mode to View.
        /// </summary>
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.View;
        }

        /// <summary>
        /// Changes the annotation interaction mode to Author.
        /// </summary>
        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.Author;
        }

        #endregion


        #region Transformation Mode

        /// <summary>
        /// Sets "Enabled" property in a tool strip menu item and in its sub items.
        /// </summary>
        /// <param name="item">Tool strip menu item.</param>
        /// <param name="isEnabled">Determines if tool strip menu item is enabled.</param>
        private void SetIsEnabled(ToolStripMenuItem item, bool isEnabled)
        {
            item.Enabled = isEnabled;
            foreach (ToolStripMenuItem subitem in item.DropDownItems)
            {
                subitem.Enabled = isEnabled;
            }
        }

        /// <summary>
        /// Updates "Annotations -> Transformation Mode" menu. 
        /// </summary>
        private void UpdateTransformationMenu()
        {
            // checks which tramsformation mode selected for focused annotation
            GripMode mode = ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode;
            rectangularToolStripMenuItem.Checked = mode == GripMode.Rectangular;
            pointsToolStripMenuItem.Checked = mode == GripMode.Points;
            rectangularAndPointsToolStripMenuItem.Checked = mode == GripMode.RectangularAndPoints;
        }

        /// <summary>
        /// Sets "rectangular" transformation mode for focused annotation.
        /// </summary>
        private void rectangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.Rectangular;
            UpdateTransformationMenu();
        }

        /// <summary>
        /// Sets "points" transformation mode for focused annotation. 
        /// </summary>
        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.Points;
            UpdateTransformationMenu();
        }

        /// <summary>
        /// Sets "rectangular and points" transformation mode for focused annotation.
        /// </summary>
        private void rectangularAndPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.RectangularAndPoints;
            UpdateTransformationMenu();
        }

        #endregion


        #region Load and Save annotations

        /// <summary>
        /// Loads annotation collection from file.
        /// </summary>
        private void loadAnnotationsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileOpening = true;

            AnnotationDemosTools.LoadAnnotationsFromFile(annotationViewer1, openFileDialog, _undoManager);

            IsFileOpening = false;
        }

        /// <summary>
        /// Saves annotation collection to a file.
        /// </summary>
        private void saveAnnotationsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileSaving = true;

            AnnotationDemosTools.SaveAnnotationsToFile(annotationViewer1, saveFileDialog);

            IsFileSaving = false;
        }

        #endregion


        /// <summary>
        /// Starts the annotation building.
        /// </summary>
        private void addAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationType annotationType = _toolStripMenuItemToAnnotationType[(ToolStripMenuItem)sender];

            // start new annotation building process and specify that this is the first process
            annotationsToolStrip1.AddAndBuildAnnotation(annotationType);
        }

        /// <summary>
        /// Enables/disables the continuous building of annotations.
        /// </summary>
        private void buildAnnotationsContinuouslyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            annotationsToolStrip1.NeedBuildAnnotationsContinuously = buildAnnotationsContinuouslyToolStripMenuItem.Checked;
        }


        #region UI actions

        /// <summary>
        /// Brings the selected annotation to the first position in annotation collection.
        /// </summary>
        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            annotationViewer1.BringFocusedAnnotationToBack();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Brings the selected annotation to the last position in annotation collection.
        /// </summary>
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            annotationViewer1.BringFocusedAnnotationToFront();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Enables/disables multi selection of annotations in viewer.
        /// </summary>
        private void multiSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationMultiSelect = multiSelectToolStripMenuItem.Checked;
            UpdateUI();
        }

        /// <summary>
        /// Groups/ungroups selected annotations of annotation collection.
        /// </summary>
        private void groupSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.GroupUngroupSelectedAnnotations(annotationViewer1, _undoManager);
        }

        /// <summary>
        /// Groups all annotations of annotation collection.
        /// </summary>
        private void groupAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.GroupAllAnnotations(annotationViewer1, _undoManager);
        }


        #region Rotate, Burn, Clone

        /// <summary>
        /// Rotates image with annotations.
        /// </summary>
        private void rotateImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AnnotationDemosTools.RotateImageWithAnnotations(annotationViewer1, _undoManager, null);
            }
            catch (Exception exc)
            {
                DemosTools.ShowErrorMessage(exc);
            }
        }

        /// <summary>
        /// Burns an annotation collection on image.
        /// </summary>
        private void burnAnnotationsOnImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                AnnotationDemosTools.BurnAnnotationsOnImage(annotationViewer1, _undoManager, null);

                // update the UI
                UpdateUI();

            }
            catch (ImageProcessingException ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Burn annotations on image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                Cursor = Cursors.Default;
                DemosTools.ShowErrorMessage(exc);
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Clones image with annotations.
        /// </summary>
        private void cloneImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                annotationViewer1.CancelAnnotationBuilding();

                annotationViewer1.AnnotationDataController.CloneImageWithAnnotations(annotationViewer1.FocusedIndex, annotationViewer1.Images.Count);
                annotationViewer1.FocusedIndex = annotationViewer1.Images.Count - 1;
            }
            catch (Exception exc)
            {
                DemosTools.ShowErrorMessage(exc);
            }
        }

        #endregion

        #endregion

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Shows the About dialog.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dialog = new AboutBoxForm())
            {
                dialog.ShowDialog();
            }
        }

        #endregion


        #region Context menu

        /// <summary>
        /// Saves focused image with annotations to a file.
        /// </summary>
        private void saveImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImageToNewFile();
        }

        /// <summary>
        /// Copies focused image with annotations to clipboard.
        /// </summary>
        private void copyImageToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.CopyImageToClipboard(annotationViewer1);
        }

        /// <summary>
        /// Deletes focused image.
        /// </summary>
        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteImages();

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Annotation viewer

        /// <summary>
        /// The mouse is moved in annotation viewer.
        /// </summary>
        private void annotationViewer1_MouseMove(object sender, MouseEventArgs e)
        {
            // if viewer must be scrolled when annotation is moved
            if (scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Checked)
            {
                // if left mouse button is pressed
                if (e.Button == MouseButtons.Left)
                {
                    // get the interaction controller of annotation viewer
                    IInteractionController interactionController =
                        annotationViewer1.AnnotationVisualTool.ActiveInteractionController;
                    // if user interacts with annotation
                    if (interactionController != null && interactionController.IsInteracting)
                    {
                        const int delta = 20;

                        // get the "visible area" of annotation viewer
                        Rectangle rect = annotationViewer1.ClientRectangle;
                        // remove "border" from the "visible area"
                        rect.Inflate(-delta, -delta);

                        // if mouse is located in "border"
                        if (!rect.Contains(e.Location))
                        {
                            // calculate how to scroll the annotation viewer
                            int deltaX = 0;
                            if (e.X < delta)
                                deltaX = -(delta - e.X);
                            if (e.X > delta + rect.Width)
                                deltaX = -(delta + rect.Width - e.X);
                            int deltaY = 0;
                            if (e.Y < delta)
                                deltaY = -(delta - e.Y);
                            if (e.Y > delta + rect.Height)
                                deltaY = -(delta + rect.Height - e.Y);

                            // get the auto scroll position of annotation viewer
                            Point autoScrollPosition = new Point(Math.Abs(annotationViewer1.AutoScrollPosition.X), Math.Abs(annotationViewer1.AutoScrollPosition.Y));

                            // calculate new auto scroll position
                            if (annotationViewer1.AutoScrollMinSize.Width > 0 && deltaX != 0)
                                autoScrollPosition.X += deltaX;
                            if (annotationViewer1.AutoScrollMinSize.Height > 0 && deltaY != 0)
                                autoScrollPosition.Y += deltaY;

                            // if auto scroll position is changed
                            if (autoScrollPosition != annotationViewer1.AutoScrollPosition)
                                // set new auto scroll position
                                annotationViewer1.AutoScrollPosition = autoScrollPosition;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The scroll position of the annotation viewer is changing.
        /// </summary>
        private void annotationViewer1_AutoScrollPositionExChanging(object sender, PropertyChangingEventArgs<PointF> e)
        {
            // if viewer must be scrolled when annotation is moved
            if (scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Checked)
            {
                if (annotationViewer1.AnnotationVisualTool != null)
                {
                    // get the interaction controller of annotation viewer
                    IInteractionController interactionController =
                        annotationViewer1.AnnotationVisualTool.ActiveInteractionController;
                    // if user interacts with annotation
                    if (interactionController != null && interactionController.IsInteracting)
                    {
                        // get bounding box of displayed images
                        RectangleF displayedImagesBBox = annotationViewer1.GetDisplayedImagesBoundingBox();

                        // get the scroll position
                        PointF scrollPosition = e.NewValue;

                        // cut the coordinates for getting coordinates inside the focused image
                        scrollPosition.X = Math.Max(displayedImagesBBox.X, Math.Min(scrollPosition.X, displayedImagesBBox.Right));
                        scrollPosition.Y = Math.Max(displayedImagesBBox.Y, Math.Min(scrollPosition.Y, displayedImagesBBox.Bottom));

                        // update the scroll position
                        e.NewValue = scrollPosition;
                    }
                }
            }
        }

        /// <summary>
        /// Annotation deserialization error occurs.
        /// </summary>
        private void AnnotationDataController_AnnotationDataDeserializationException(object sender, Vintasoft.Imaging.Annotation.AnnotationDataDeserializationExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage("AnnotationData deserialization exception", e.Exception);
        }

        /// <summary>
        /// Image loading in viewer is started.
        /// </summary>
        private void annotationViewer1_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            progressBarImageLoading.Visible = true;
            toolStripStatusLabelLoadingImage.Visible = true;
            _imageLoadingStartTime = DateTime.Now;
        }

        /// <summary>
        /// Image loading in viewer is in progress.
        /// </summary>
        private void annotationViewer1_ImageLoadingProgress(object sender, ProgressEventArgs e)
        {
            if (_isFormClosing)
            {
                e.Cancel = true;
                return;
            }
            progressBarImageLoading.Value = e.Progress;
        }

        /// <summary>
        /// Image loading in viewer is finished.
        /// </summary>
        private void annotationViewer1_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            _imageLoadingTime = DateTime.Now.Subtract(_imageLoadingStartTime);

            progressBarImageLoading.Visible = false;
            toolStripStatusLabelLoadingImage.Visible = false;

            VintasoftImage image = annotationViewer1.Image;

            // show error message if not critical error occurs during image loading
            string imageLoadingErrorString = "";
            if (image.LoadingError)
                imageLoadingErrorString = string.Format("[{0}] ", image.LoadingErrorString);
            // show information about the image
            imageInfoStatusLabel.Text = string.Format("{0} Width={1}; Height={2}; PixelFormat={3}; Resolution={4}", imageLoadingErrorString, image.Width, image.Height, image.PixelFormat, image.Resolution);

            // if image loading time more than 0
            if (_imageLoadingTime != TimeSpan.Zero)
                // show information about image loading time
                imageInfoStatusLabel.Text = string.Format("[Loading time: {0}ms] {1}", _imageLoadingTime.TotalMilliseconds, imageInfoStatusLabel.Text);

            // if image has annotations
            if (image.Metadata.AnnotationsFormat != AnnotationsFormat.None)
                // show information about format of annotations
                imageInfoStatusLabel.Text = string.Format("[AnnotationsFormat: {0}] {1}", image.Metadata.AnnotationsFormat, imageInfoStatusLabel.Text);


            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Key is down in annotation viewer.
        /// </summary>
        private void annotationViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.X:
                        if (cutToolStripMenuItem.Enabled)
                        {
                            CutSelectedItem();

                            e.Handled = true;
                        }
                        break;

                    case Keys.C:
                        if (copyToolStripMenuItem.Enabled)
                        {
                            CopySelectedItem();

                            e.Handled = true;
                        }
                        break;

                    case Keys.V:
                        if (pasteToolStripMenuItem.Enabled)
                        {
                            PasteItem();

                            e.Handled = true;
                        }
                        break;

                    case Keys.A:
                        if (selectAllToolStripMenuItem.Enabled)
                        {
                            SelectAllItems();

                            e.Handled = true;
                        }
                        break;
                }
            }
            else if (deleteToolStripMenuItem.Enabled &&
                e.KeyCode == Keys.Delete && e.Modifiers == Keys.None &&
                CanInteractWithFocusedAnnotationUseKeyboard())
            {
                // delete the selected annotation from image
                DeleteAnnotation(false);

                // update the UI
                UpdateUI();
            }

            if (!e.Handled && annotationViewer1.Focused && CanInteractWithFocusedAnnotationUseKeyboard())
            {
                // get transform from AnnotationViewer space to the DIP space
                AffineMatrix matrix = annotationViewer1.GetTransformFromControlToDip();
                PointF deltaVector = PointFAffineTransform.TransformVector(matrix, new PointF(ANNOTATION_KEYBOARD_MOVE_DELTA, ANNOTATION_KEYBOARD_MOVE_DELTA));
                PointF resizeVector = PointFAffineTransform.TransformVector(matrix, new PointF(ANNOTATION_KEYBOARD_RESIZE_DELTA, ANNOTATION_KEYBOARD_RESIZE_DELTA));

                // current annotation location 
                PointF location = annotationViewer1.FocusedAnnotationView.Location;
                SizeF size = annotationViewer1.FocusedAnnotationView.Size;

                switch (e.KeyData)
                {
                    case Keys.Up:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X, location.Y - deltaVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Down:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X, location.Y + deltaVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Right:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X + deltaVector.X, location.Y);
                        e.Handled = true;
                        break;
                    case Keys.Left:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X - deltaVector.X, location.Y);
                        e.Handled = true;
                        break;
                    case Keys.Add:
                        annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width + resizeVector.X, size.Height + resizeVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Subtract:
                        if (size.Width > resizeVector.X)
                            annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width - resizeVector.X, size.Height);

                        size = annotationViewer1.FocusedAnnotationView.Size;

                        if (size.Height > resizeVector.Y)
                            annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width, size.Height - resizeVector.Y);
                        e.Handled = true;
                        break;
                }
                if (e.Handled)
                    annotationPropertyGrid.Refresh();
            }
        }

        /// <summary>
        /// Determines whether can move focused annotation use keyboard.
        /// </summary>
        private bool CanInteractWithFocusedAnnotationUseKeyboard()
        {
            if (annotationViewer1.FocusedAnnotationView == null)
                return false;

#if !REMOVE_OFFICE_PLUGIN
            Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditor documentEditor =
                UserInteractionVisualTool.GetActiveInteractionController<Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditor>(annotationViewer1.VisualTool);
            if (documentEditor != null && documentEditor.IsEditingEnabled)
            {
                return false;
            }
#endif
            return true;
        }

        /// <summary>
        /// Key is pressed in annotation viewer.
        /// </summary>
        private void annotationViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if Enter key (13) pressed
            if (e.KeyChar == '\xD')
            {
                if (annotationViewer1.IsAnnotationBuilding)
                    annotationViewer1.FinishAnnotationBuilding();
            }
            // if ESC key (27) pressed
            else if (e.KeyChar == '\x1B')
            {
                if (annotationViewer1.IsAnnotationBuilding)
                    annotationViewer1.CancelAnnotationBuilding();
            }
        }

        /// <summary>
        /// Annotation interaction mode of viewer is changed.
        /// </summary>
        private void annotationViewer1_AnnotationInteractionModeChanged(object sender, AnnotationInteractionModeChangedEventArgs e)
        {
            noneToolStripMenuItem.Checked = false;
            viewToolStripMenuItem1.Checked = false;
            authorToolStripMenuItem.Checked = false;

            AnnotationInteractionMode annotationInteractionMode = e.NewValue;
            switch (annotationInteractionMode)
            {
                case AnnotationInteractionMode.None:
                    noneToolStripMenuItem.Checked = true;
                    break;

                case AnnotationInteractionMode.View:
                    viewToolStripMenuItem1.Checked = true;
                    break;

                case AnnotationInteractionMode.Author:
                    authorToolStripMenuItem.Checked = true;
                    break;
            }

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Loading of thumbnails is in progress.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(object sender, ThumbnailsLoadingProgressEventArgs e)
        {
            actionLabel.Text = "Creating thumbnails:";
            progressBar1.Value = e.Progress;
            progressBar1.Visible = true;
            actionLabel.Visible = true;
            if (progressBar1.Value == 100)
            {
                progressBar1.Visible = false;
                actionLabel.Visible = false;
            }
        }

        /// <summary>
        /// Sets the ToolTip of hovered thumbnail.
        /// </summary>
        private void thumbnailViewer1_HoveredThumbnailChanged(object sender, ThumbnailEventArgs e)
        {
            if (e.Thumbnail != null)
            {
                try
                {
                    // get information about hovered image in thumbnail viewer
                    ImageSourceInfo imageSourceInfo = e.Thumbnail.Source.SourceInfo;
                    string filename = null;

                    // if image loaded from file
                    if (imageSourceInfo.SourceType == ImageSourceType.File)
                    {
                        // get image file name
                        filename = Path.GetFileName(imageSourceInfo.Filename);
                    }
                    // if image loaded from stream
                    else if (imageSourceInfo.SourceType == ImageSourceType.Stream)
                    {
                        // if stream is file stream
                        if (imageSourceInfo.Stream is FileStream)
                            // get image file name
                            filename = Path.GetFileName(((FileStream)imageSourceInfo.Stream).Name);
                    }
                    // if image is new image
                    else
                    {
                        filename = "Bitmap";
                    }

                    // if image is multipage image
                    if (imageSourceInfo.PageCount > 1)
                        e.Thumbnail.ToolTip = string.Format("{0}, page {1}", filename, imageSourceInfo.PageIndex + 1);
                    else
                        e.Thumbnail.ToolTip = filename;
                }
                catch
                {
                    e.Thumbnail.ToolTip = "";
                }
            }
        }

        #endregion


        #region Annotations's combobox AND annotation's property grid

        /// <summary>
        /// Fills combobox with information about annotations of image.
        /// </summary>
        private void FillAnnotationComboBox()
        {
            annotationComboBox.Items.Clear();

            if (annotationViewer1.FocusedIndex >= 0)
            {
                AnnotationDataCollection annotations = annotationViewer1.AnnotationDataController[annotationViewer1.FocusedIndex];
                for (int i = 0; i < annotations.Count; i++)
                {
                    annotationComboBox.Items.Add(string.Format("[{0}] {1}", i, annotations[i].GetType().Name));
                    if (annotationViewer1.FocusedAnnotationData == annotations[i])
                        annotationComboBox.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Shows information about annotation in property grid.
        /// </summary>
        private void ShowAnnotationProperties(AnnotationView annotation)
        {
            if (annotationPropertyGrid.SelectedObject != annotation)
                annotationPropertyGrid.SelectedObject = annotation;
            else if (!_isAnnotationTransforming)
                annotationPropertyGrid.Refresh();
        }

        /// <summary>
        /// Handler of the DropDown event of the ComboBox of annotations.
        /// </summary>
        private void annotationComboBox_DropDown(object sender, EventArgs e)
        {
            FillAnnotationComboBox();
        }

        /// <summary>
        /// Selected annotation is changed using annotation's combobox.
        /// </summary>
        private void annotationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (annotationViewer1.FocusedIndex != -1 && annotationComboBox.SelectedIndex != -1)
            {
                annotationViewer1.FocusedAnnotationData = annotationViewer1.AnnotationDataCollection[annotationComboBox.SelectedIndex];
            }
        }

        /// <summary>
        /// Annotation is selected or deselected.
        /// </summary>
        private void annotationViewer1_SelectedAnnotationChanged(object sender, AnnotationViewChangedEventArgs e)
        {
            FillAnnotationComboBox();
            ShowAnnotationProperties(annotationViewer1.FocusedAnnotationView);

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Collection of selected annotations is changed.
        /// </summary>
        private void SelectedAnnotations_Changed(object sender, EventArgs e)
        {
            // update the UI
            UpdateUI();
        }

        #endregion


        #region File manipulation

        /// <summary>
        /// Adds the TXT file filter to the Open file dialog.
        /// </summary>
        /// <param name="dialog">The open file dialog.</param>
        private void AddTxtFileFilterToOpenFileDialog(OpenFileDialog dialog)
        {
            try
            {
                int test = dialog.Filter.IndexOf(new String("|All Image Files|".ToCharArray()));
                dialog.Filter = dialog.Filter.Insert(test, "|TXT Files|*.txt");
                dialog.Filter += "*.txt;";
                dialog.FilterIndex++;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Opens stream of the file and adds opened stream to the image collection of annotation viewer - this allows
        /// to save modified multipage image files back to the source.
        /// </summary>
        /// <param name="filename">Opening file name.</param>
        private void OpenFile(string filename)
        {
            // close the previosly opened file
            CloseCurrentFile();

            // specify that source file is changing
            _isSourceChanging = true;

            // save the source filename
            _sourceFilename = Path.GetFullPath(filename);

            // if source file is TXT-file
            if (Path.GetExtension(filename).ToUpperInvariant() == ".TXT")
            {
                // open TXT-file in image viewer
                OpenTxtFileInImageViewer(filename);
            }
            else
            {
                // check the source file for read-write access
                CheckSourceFileForReadWriteAccess();

                // add the source file to the viewer
                _imagesManager.Add(filename, _isFileReadOnlyMode);
            }
        }

        /// <summary>
        /// Adds files to the image collection of annotation viewer.
        /// </summary>
        /// <param name="filenames">The names of files, which should be opened.</param>
        private void AddFiles(string[] filenames)
        {
            foreach (string filename in filenames)
            {
                // if source file is TXT-file
                if (Path.GetExtension(filename).ToUpperInvariant() == ".TXT")
                {
                    // open TXT-file in image viewer
                    OpenTxtFileInImageViewer(filename);
                }
                else
                {
                    // add the source file to the viewer
                    _imagesManager.Add(filename);
                }
            }
        }

        /// <summary>
        /// Opens TXT-file in image viewer.
        /// </summary>
        /// <param name="filename">A name of TXT-file.</param>
        private void OpenTxtFileInImageViewer(string filename)
        {
            try
            {
                // create stream that contains DOCX document with text from TXT-file
                Stream stream = OfficeDemosTools.ConvertTxtFileToDocxDocument(filename);

                if (stream != null)
                {
                    // add created DOCX document to the viewer
                    _imagesManager.Add(stream, true, filename);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Cannot open {0} : {1}", Path.GetFileName(filename), ex.Message);
                DemosTools.ShowErrorMessage(message);
            }
        }

        /// <summary>
        /// Closes current file.
        /// </summary>
        private void CloseCurrentFile()
        {
            _imagesManager.Cancel();

            _isFileReadOnlyMode = false;
            _sourceFilename = null;

            annotationViewer1.Images.ClearAndDisposeItems();
        }

        /// <summary>
        /// Checks the source file for read-write access.
        /// </summary>
        private void CheckSourceFileForReadWriteAccess()
        {
            _isFileReadOnlyMode = false;
            Stream stream = null;
            try
            {
                stream = new FileStream(_sourceFilename, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
            if (stream == null)
            {
                _isFileReadOnlyMode = true;
            }
            else
            {
                stream.Close();
                stream.Dispose();
            }
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.AddStarting event.
        /// </summary>
        private void ImagesManager_AddStarting(object sender, EventArgs e)
        {
            IsFileOpening = true;
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.ImageSourceAddStarting event.
        /// </summary>
        private void ImagesManager_ImageSourceAddStarting(object sender, ImageSourceEventArgs e)
        {
            // update window title
            string fileState = string.Format("Opening {0}...", Path.GetFileName(e.SourceFilename));
            Text = string.Format(_titlePrefix, fileState);
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.ImageSourceAddFinished event.
        /// </summary>
        private void ImagesManager_ImageSourceAddFinished(object sender, ImageSourceEventArgs e)
        {
            // if source is changed
            if (_isSourceChanging)
                _isSourceChanging = false;
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.AddFinished event.
        /// </summary>
        private void ImagesManager_AddFinished(object sender, EventArgs e)
        {
            IsFileOpening = false;
            _isSourceChanging = false;
        }

        /// <summary>
        /// Handler of the ImageViewerImagesManager.ImageSourceAddException event.
        /// </summary>
        private void ImagesManager_ImageSourceAddException(object sender, ImageSourceExceptionEventArgs e)
        {
            // show error message
            string message = string.Format("Cannot open {0} : {1}", Path.GetFileName(e.SourceFilename), e.Exception.Message);
            DemosTools.ShowErrorMessage(message);

            // if new source failed to set, close file
            if (_isSourceChanging)
                CloseCurrentFile();
        }

        #endregion


        #region Image manipulation

        /// <summary>
        /// Deletes selected images or focused image.
        /// </summary>
        private void DeleteImages()
        {
            // get an array of selected images
            int[] selectedIndices = thumbnailViewer1.SelectedIndices.ToArray();
            VintasoftImage[] selectedImages;
            // if selection is present
            if (selectedIndices.Length > 0)
            {
                selectedImages = new VintasoftImage[selectedIndices.Length];
                for (int i = 0; i < selectedIndices.Length; i++)
                    selectedImages[i] = thumbnailViewer1.Images[selectedIndices[i]];
            }
            // if selection is not present
            else
            {
                // if there is no focused image
                if (thumbnailViewer1.FocusedIndex == -1)
                    return;

                // if there is focused image
                selectedIndices = new int[1];
                selectedIndices[0] = annotationViewer1.FocusedIndex;
                selectedImages = new VintasoftImage[1];
                selectedImages[0] = annotationViewer1.Image;
            }

            // remove selected images from the image collection
            thumbnailViewer1.Images.RemoveRange(selectedIndices);

            // dispose selected images
            for (int i = 0; i < selectedImages.Length; i++)
                selectedImages[i].Dispose();
        }

        #endregion


        #region Annotation

        /// <summary>
        /// Focused annotation is changed in annotation viewer.
        /// </summary>
        private void annotationViewer1_FocusedAnnotationViewChanged(
            object sender,
            AnnotationViewChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                AnnotationData oldValue = e.OldValue.Data;
                while (oldValue is CompositeAnnotationData)
                {
                    CompositeAnnotationData compositeData = (CompositeAnnotationData)oldValue;

                    if (compositeData is StickyNoteAnnotationData)
                    {
                        compositeData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(compositeData_PropertyChanged);
                    }

                    foreach (AnnotationData data in compositeData)
                    {
                        oldValue = data;
                        break;
                    }
                }
                oldValue.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
            }
            if (e.NewValue != null)
            {
                AnnotationData newValue = e.NewValue.Data;
                while (newValue is CompositeAnnotationData)
                {
                    CompositeAnnotationData compositeData = (CompositeAnnotationData)newValue;

                    if (compositeData is StickyNoteAnnotationData)
                    {
                        compositeData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(compositeData_PropertyChanged);
                    }

                    foreach (AnnotationData data in compositeData)
                    {
                        newValue = data;
                        break;
                    }
                }
                newValue.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                // save information about last focused annotation
                _focusedAnnotationData = newValue;
            }
        }

        /// <summary>
        /// The focused annotation property is changed.
        /// </summary>
        private void FocusedAnnotationData_PropertyChanged(
            object sender,
            ObjectPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Location" && annotationViewer1.SelectedAnnotations.Count > 1)
            {
                AnnotationView focusedView = annotationViewer1.AnnotationVisualTool.FocusedAnnotationView;
                if (focusedView != null && focusedView.InteractionController != null)
                {
                    InteractionArea focusedArea = focusedView.InteractionController.FocusedInteractionArea;
                    if (focusedArea != null && focusedArea.InteractionName == "Move")
                    {
                        System.Drawing.PointF oldValue = (System.Drawing.PointF)e.OldValue;
                        System.Drawing.PointF newValue = (System.Drawing.PointF)e.NewValue;
                        System.Drawing.PointF locationDelta = new System.Drawing.PointF(newValue.X - oldValue.X, newValue.Y - oldValue.Y);
                        AnnotationData[] annotations = new AnnotationData[annotationViewer1.SelectedAnnotations.Count];
                        for (int i = 0; i < annotationViewer1.SelectedAnnotations.Count; i++)
                            annotations[i] = annotationViewer1.SelectedAnnotations[i].Data;
                        AnnotationDemosTools.ChangeAnnotationsLocation(locationDelta, annotations, (AnnotationData)sender);
                    }
                }
            }
        }

        /// <summary>
        /// Composite data property is changed.
        /// </summary>
        private void compositeData_PropertyChanged(object sender, ObjectPropertyChangedEventArgs e)
        {
            StickyNoteAnnotationData stickyNote = sender as StickyNoteAnnotationData;
            if (stickyNote != null)
            {
                if (e.PropertyName == "CollapsedType" || e.PropertyName == "IsCollapsed")
                {
                    if (_focusedAnnotationData != null)
                    {
                        _focusedAnnotationData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                    }

                    foreach (AnnotationData data in stickyNote)
                    {
                        _focusedAnnotationData = data;
                        _focusedAnnotationData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Begins initialization of the specified annotation.
        /// </summary>
        private void BeginInit(AnnotationData annotation)
        {
            if (!_initializedAnnotations.Contains(annotation))
            {
                _initializedAnnotations.Add(annotation);
                annotation.BeginInit();
            }
        }

        /// <summary>
        /// Ends initialization of the specified annotation.
        /// </summary>
        private void EndInit(AnnotationData annotation)
        {
            if (_initializedAnnotations.Contains(annotation))
            {
                _initializedAnnotations.Remove(annotation);
                annotation.EndInit();
            }
        }

        /// <summary>
        /// Annotation transforming is started.
        /// </summary>
        private void annotationViewer1_AnnotationTransformingStarted(
            object sender,
            AnnotationViewEventArgs e)
        {
            _isAnnotationTransforming = true;

            // if annotation transformation is NOT shown in the thumbnail viewer
            if (!showAnnotationTransformationOnThumbnailToolStripMenuItem.Checked)
            {
                // begin the initialization of annotation
                BeginInit(e.AnnotationView.Data);
                // for each view of annotation
                foreach (AnnotationView view in annotationViewer1.SelectedAnnotations)
                    // begin the initialization of annotation view
                    BeginInit(view.Data);
            }
        }

        /// <summary>
        /// Annotation transforming is finished.
        /// </summary>
        private void annotationViewer1_AnnotationTransformingFinished(
            object sender,
            AnnotationViewEventArgs e)
        {
            _isAnnotationTransforming = false;

            // end the initialization of annotation
            EndInit(e.AnnotationView.Data);
            // for each view of annotation
            foreach (AnnotationView view in annotationViewer1.SelectedAnnotations)
                // end the initialization of annotation view
                EndInit(view.Data);

            // refresh the property grid
            annotationPropertyGrid.Refresh();
        }

        /// <summary>
        /// Deletes the selected annotation or all annotations from image.
        /// </summary>
        /// <param name="deleteAll">Determines that all annotations must be deleted from image.</param>
        private void DeleteAnnotation(bool deleteAll)
        {
            annotationViewer1.CancelAnnotationBuilding();

            // get UI action
            UIAction deleteUIAction = null;
            if (deleteAll)
                deleteUIAction = GetUIAction<DeleteAllItemsUIAction>(annotationViewer1.VisualTool);
            else
                deleteUIAction = GetUIAction<DeleteItemUIAction>(annotationViewer1.VisualTool);

            // if UI action is not empty  AND UI action is enabled
            if (deleteUIAction != null && deleteUIAction.IsEnabled)
            {
                string actionName = "AnnotationViewCollection: Delete";
                if (deleteAll)
                    actionName = actionName + " All";
                _undoManager.BeginCompositeAction(actionName);

                try
                {
                    deleteUIAction.Execute();
                }
                finally
                {
                    _undoManager.EndCompositeAction();
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// The interaction controller of annotation tool is changed.
        /// </summary>
        private void AnnotationVisualTool_ActiveInteractionControllerChanged(
            object sender,
            PropertyChangedEventArgs<IInteractionController> e)
        {
            TextObjectTextBoxTransformer oldTextObjectTextBoxTransformer = CompositeInteractionController.FindInteractionController<TextObjectTextBoxTransformer>(e.OldValue);
            if (oldTextObjectTextBoxTransformer != null)
            {
                oldTextObjectTextBoxTransformer.TextBoxShown -= TextObjectTextBoxTransformer_TextBoxShown;
                oldTextObjectTextBoxTransformer.TextBoxClosed -= TextObjectTextBoxTransformer_TextBoxClosed;
            }

            TextObjectTextBoxTransformer newTextObjectTextBoxTransformer = CompositeInteractionController.FindInteractionController<TextObjectTextBoxTransformer>(e.NewValue);
            if (newTextObjectTextBoxTransformer != null)
            {
                newTextObjectTextBoxTransformer.TextBoxShown +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxShown);
                newTextObjectTextBoxTransformer.TextBoxClosed +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxClosed);
            }
        }


        /// <summary>
        /// Text box of focused annotation is shown.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxShown(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Text box of focused annotation is closed.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxClosed(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Annotation building is started.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingStarted(object sender, AnnotationViewEventArgs e)
        {
            annotationComboBox.Enabled = false;

            DisableUndoRedoMenu();
            if (_historyForm != null)
                _historyForm.CanNavigateOnHistory = false;
        }

        /// <summary>
        /// Annotation building is canceled.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingCanceled(object sender, AnnotationViewEventArgs e)
        {
            annotationComboBox.Enabled = true;

            EnableUndoRedoMenu();
            if (_historyForm != null)
                _historyForm.CanNavigateOnHistory = true;
        }

        /// <summary>
        /// Annotation building is finished.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingFinished(object sender, AnnotationViewEventArgs e)
        {
            bool isBuildingFinished = true;

            if (annotationsToolStrip1.NeedBuildAnnotationsContinuously)
            {
                if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                    isBuildingFinished = false;
            }

            if (isBuildingFinished)
            {
                annotationComboBox.Enabled = true;

                EnableUndoRedoMenu();
                if (_historyForm != null)
                    _historyForm.CanNavigateOnHistory = true;
            }
        }

        /// <summary>
        /// Disables the comment visual tool.
        /// </summary>
        private void NoneAction_Deactivated(object sender, EventArgs e)
        {
            _commentVisualTool.Enabled = false;
        }

        /// <summary>
        /// Enables the comment visual tool.
        /// </summary>
        private void NoneAction_Activated(object sender, EventArgs e)
        {
            _commentVisualTool.Enabled = true;
        }

        #endregion


        #region Annotation undo manager

        /// <summary>
        /// Updates the "Undo/Redo" menu.
        /// </summary>
        private void UpdateUndoRedoMenu(UndoManager undoManager)
        {
            bool canUndo = false;
            bool canRedo = false;

            if (undoManager != null && undoManager.IsEnabled)
            {
                if (!annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                {
                    canUndo = undoManager.UndoCount > 0;
                    canRedo = undoManager.RedoCount > 0;
                }
            }

            string undoMenuItemText = "Undo";
            if (canUndo)
                undoMenuItemText = string.Format("Undo {0}", undoManager.UndoDescription).Trim();

            undoToolStripMenuItem.Enabled = canUndo;
            undoToolStripMenuItem.Text = undoMenuItemText;


            string redoMenuItemText = "Redo";
            if (canRedo)
                redoMenuItemText = string.Format("Redo {0}", undoManager.RedoDescription).Trim();

            redoToolStripMenuItem.Enabled = canRedo;
            redoToolStripMenuItem.Text = redoMenuItemText;
        }

        /// <summary>
        /// Enables the undo redo menu.
        /// </summary>
        private void EnableUndoRedoMenu()
        {
            UpdateUndoRedoMenu(_undoManager);
            enableUndoRedoToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Disables the undo redo menu.
        /// </summary>
        private void DisableUndoRedoMenu()
        {
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            enableUndoRedoToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Annotation undo manager is changed.
        /// </summary>
        private void annotationUndoManager_Changed(object sender, UndoManagerChangedEventArgs e)
        {
            UpdateUndoRedoMenu((UndoManager)sender);
        }

        /// <summary>
        /// Annotation undo manager is navigated.
        /// </summary>
        private void annotationUndoManager_Navigated(object sender, UndoManagerNavigatedEventArgs e)
        {
            UpdateUndoRedoMenu((UndoManager)sender);
            UpdateUI();
        }

        /// <summary>
        /// Shows the history form.
        /// </summary>
        private void ShowHistoryForm()
        {
            if (annotationViewer1.Image == null)
                return;

            _historyForm = new UndoManagerHistoryForm(this, _undoManager);
            _historyForm.CanNavigateOnHistory = !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            _historyForm.FormClosed += new FormClosedEventHandler(historyForm_FormClosed);
            _historyForm.Show();
        }

        /// <summary>
        /// Closes the history form.
        /// </summary>
        private void CloseHistoryForm()
        {
            if (_historyForm != null)
                _historyForm.Close();
        }

        /// <summary>
        /// History form is closed.
        /// </summary>
        private void historyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            historyDialogToolStripMenuItem.Checked = false;
            _historyForm = null;
        }

        #endregion


        #region Save image(s)

        /// <summary>
        /// Saves modified image collection with annotations back to the source file.
        /// If source file does not support annotations, image collection with annotations will be saved to a new file, which supports annotations,
        /// and switches to the new file.
        /// </summary>
        private void SaveToSourceFile()
        {
            // cancel annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // if focused image is NOT correct
            if (!AnnotationDemosTools.CheckImage(annotationViewer1))
                return;

            // specify that image file saving is started
            IsFileSaving = true;

            try
            {
                // if source file supports annotations
                if (IsAnnotationsSupported(_sourceFilename))
                {
                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    EncoderBase encoder = null;

                    // get the decoder name of the first image in image collection
                    string decoderName = annotationViewer1.Images[0].SourceInfo.DecoderName;

                    // if image encoder is found
                    if (encoderFactory.GetEncoderByName(decoderName, out encoder))
                    {
                        encoder.SaveAndSwitchSource = true;

                        // asynchronously save image collection to a file
                        annotationViewer1.Images.SaveAsync(_sourceFilename, encoder);
                    }
                    // if image encoder is NOT found
                    else
                    {
                        DemosTools.ShowErrorMessage("Images are not saved.");
                        // specify that image file saving is finished
                        IsFileSaving = false;
                    }
                }
                // if source file does NOT support annotations
                else
                    // open the save file dialog and save image collection to a new file
                    SaveImageCollectionToNewFile(true);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Determines that file supports annotations.
        /// </summary>
        /// <param name="fileName">File name with extension.</param>
        /// <returns><b>True</b> if file supports annotations; otherwise, <b>false</b>.</returns>
        private bool IsAnnotationsSupported(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName).ToUpperInvariant();

            switch (fileExtension)
            {
                case ".PDF":
                case ".TIF":
                case ".TIFF":
                case ".PNG":
                case ".JPG":
                case ".JPEG":
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Opens the save file dialog and saves image collection to a new file.
        /// </summary>
        private void SaveImageCollectionToNewFile(bool switchSource)
        {
            OnSaving();

            // if focused image is NOT correct
            if (!AnnotationDemosTools.CheckImage(annotationViewer1))
                return;

            // specify that image file saving is started
            IsFileSaving = true;

            bool multipage = annotationViewer1.Images.Count > 1;

            // set file filters in file saving dialog
            CodecsFileFilters.SetSaveFileDialogFilter(saveFileDialog, multipage, true);
            // show the file saving dialog
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string saveFilename = Path.GetFullPath(saveFileDialog.FileName);

                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    EncoderBase encoder = null;

                    // if image encoder is found
                    if (encoderFactory.GetEncoder(saveFilename, out encoder))
                    {
                        RenderingSettingsForm.SetRenderingSettingsIfNeed(annotationViewer1.Images, encoder, annotationViewer1.ImageRenderingSettings);

                        _saveFilename = saveFilename;
                        encoder.SaveAndSwitchSource = switchSource;

                        // save image collection to a file
                        annotationViewer1.Images.SaveAsync(saveFilename, encoder);
                    }
                    // if image encoder is NOT found
                    else
                    {
                        DemosTools.ShowErrorMessage("Images are not saved.");
                        IsFileSaving = false;
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    // specify that image file saving is finished
                    IsFileSaving = false;
                }
                if (!switchSource)
                    // specify that image file saving is finished
                    IsFileSaving = false;
            }
            else
            {
                // specify that image file saving is finished
                IsFileSaving = false;
            }
        }

        /// <summary>
        /// Opens the save file dialog and saves image with annotations to a new file.
        /// </summary>
        private void SaveImageToNewFile()
        {
            OnSaving();

            // if focused image is NOT correct
            if (!AnnotationDemosTools.CheckImage(annotationViewer1))
                return;

            // specify that image file saving is started
            IsFileSaving = true;

            // set file filters in file saving dialog
            CodecsFileFilters.SetSaveFileDialogFilter(saveFileDialog, false, true);
            // show the file saving dialog
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string saveFilename = Path.GetFullPath(saveFileDialog.FileName);
                    PluginsEncoderFactory encoderFactory = new PluginsEncoderFactory();
                    EncoderBase encoder = null;

                    // if image encoder is found
                    if (encoderFactory.GetEncoder(saveFilename, out encoder))
                    {
                        RenderingSettingsForm.SetRenderingSettingsIfNeed(annotationViewer1.Image, encoder, annotationViewer1.ImageRenderingSettings);

                        // save image to a file
                        annotationViewer1.Image.Save(saveFilename, encoder, SavingProgress);
                    }
                    // if image encoder is NOT found
                    else
                    {
                        DemosTools.ShowErrorMessage("Images are not saved.");
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            // specify that image file saving is finished
            IsFileSaving = false;
        }

        /// <summary>
        /// Called when file is saving.
        /// </summary>
        private void OnSaving()
        {
            // cancel annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // finish active interaction
            annotationViewer1.AnnotationVisualTool.FinishActiveInteraction();
        }


        /// <summary>
        /// Image collection saving is in-progress.
        /// </summary>
        private void SavingProgress(object sender, ProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new SavingProgressDelegate(SavingProgress), sender, e);
            }
            else
            {
                actionLabel.Text = "Saving:";
                progressBar1.Value = e.Progress;
                progressBar1.Visible = e.Progress != 100;
                actionLabel.Visible = true;
            }
        }

        /// <summary>
        /// Image collection is saved.
        /// </summary>
        private void images_ImageCollectionSavingFinished(object sender, EventArgs e)
        {
            if (_saveFilename != null)
            {
                _sourceFilename = _saveFilename;
                _saveFilename = null;
                _isFileReadOnlyMode = false;
            }
            IsFileSaving = false;
        }

        /// <summary>
        /// Image saving error occurs.
        /// </summary>
        private void Images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage(e.Exception);
        }

        #endregion


        #region Text Selection Tool

        /// <summary>
        /// Text selection is changed.
        /// </summary>
        private void _textSelectionTool_SelectionChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Text searching is started.
        /// </summary>
        private void _textSelectionTool_TextSearching(object sender, EventArgs e)
        {
            IsTextSearching = true;
        }

        /// <summary>
        /// Text search is in progress.
        /// </summary>
        private void _textSelectionTool_TextSearchingProgress(
            object sender,
            TextSearchingProgressEventArgs e)
        {
            actionLabel.Text = string.Format("Search on page {0}...", e.ImageIndex + 1);
            actionLabel.Visible = true;
        }

        /// <summary>
        /// Text searching is finished.
        /// </summary>
        private void _textSelectionTool_TextSearched(object sender, TextSearchedEventArgs e)
        {
            actionLabel.Text = "";
            actionLabel.Visible = false;
            IsTextSearching = false;
        }

        /// <summary>
        /// Text extraction is in progress.
        /// </summary>
        private void TextSelectionTool_TextExtractionProgress(object sender, ProgressEventArgs e)
        {
            // show status
            if (e.Progress == 100)
            {
                actionLabel.Text = "";
                actionLabel.Visible = false;
            }
            else
            {
                actionLabel.Visible = true;
                actionLabel.Text = string.Format("Extracting text {0}%...", e.Progress);
                Application.DoEvents();
            }
        }

        #endregion


        #region Navigation Tool

        /// <summary>
        /// Shows focused action in the status strip.
        /// </summary>
        private void NavigationTool_FocusedActionChanged(object sender, EventArgs e)
        {
            PageContentActionMetadata action = _navigationTool.FocusedAction;
            if (action != null)
            {
                if (action is UriActionMetadata)
                {
                    actionLabel.Text = string.Format("Open URL: '{0}'", ((UriActionMetadata)action).Uri);
                    actionLabel.Visible = true;
                }
                else if (action is LaunchActionMetadata)
                {
                    actionLabel.Text = string.Format("Launch Application: '{0}'", ((LaunchActionMetadata)action).CommandLine);
                    actionLabel.Visible = true;
                }
                else if (action is NamedActionMetadata)
                {
                    actionLabel.Text = string.Format("Named Action: '{0}'", ((NamedActionMetadata)action).ActionName);
                    actionLabel.Visible = true;
                }
                else if (action is GotoActionMetadata)
                {
                    GotoActionMetadata gotoAction = (GotoActionMetadata)action;

                    DecoderBase decoder = annotationViewer1
                                          .Images[annotationViewer1.FocusedIndex]
                                          .SourceInfo
                                          .Decoder;

                    if (gotoAction.DestPageIndex >= 0)
                    {
                        int globalImageIndex = annotationViewer1.Images.GetImageIndex(decoder, gotoAction.DestPageIndex);
                        if (globalImageIndex >= 0)
                        {
                            actionLabel.Text = string.Format("Goto page {0}", globalImageIndex + 1);
                            actionLabel.Visible = true;
                        }
                    }
                }
            }
            else
            {
                actionLabel.Visible = false;
                actionLabel.Text = "";
            }
        }

        #endregion

        #endregion



        #region Delegates

        private delegate void UpdateUIDelegate();

        private delegate void CloseCurrentFileDelegate();

        private delegate void SetAddingFilenameDelegate(string filename);

        private delegate void SetIsFileOpeningDelegate(bool isFileOpening);

        private delegate void SavingProgressDelegate(object sender, ProgressEventArgs e);

        #endregion

      
    }
}
