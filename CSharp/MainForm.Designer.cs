using System;
using Vintasoft.Imaging.UI;

namespace DocumentViewerDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailCaption thumbnailCaption1 = new Vintasoft.Imaging.UI.ThumbnailCaption();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentLayoutSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docxLayoutSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xlsxLayoutSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pageSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.findTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.enableUndoRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainVisualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.imageDisplayModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleContinuousRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleContinuousColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoContinuousRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoContinuousColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageScaleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.scale25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateCounterclockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewerRenderingSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interactionPointsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveAnnotationsBetweenImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.spellCheckSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellCheckViewSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.colorManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.documentMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationsInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.interactionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangularAndPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.addAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textHighlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embeddedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referencedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stickyNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubberStampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesWithInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freehandLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonWithInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freehandPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.angleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.triangleCustomAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markCustomAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAnnotationsContinuouslyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.multiSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.groupUngroupSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateImageWithAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burnAnnotationsOnImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneImageWithAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageWithAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyImageToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationViewer1 = new Vintasoft.Imaging.Annotation.UI.AnnotationViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolsTabControl = new System.Windows.Forms.TabControl();
            this.pagesTabPage = new System.Windows.Forms.TabPage();
            this.thumbnailViewer1 = new Vintasoft.Imaging.Annotation.UI.AnnotatedThumbnailViewer();
            this.thumbnailMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.textExtractionTabPage = new System.Windows.Forms.TabPage();
            this.textSelectionControl1 = new DemosCommonCode.Imaging.TextSelectionControl();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.annotationPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.annotationComboBox = new System.Windows.Forms.ComboBox();
            this.commentsTabPage = new System.Windows.Forms.TabPage();
            this.annotationCommentsControl1 = new DemosCommonCode.Annotation.AnnotationCommentsControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.viewerToolStrip = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.visualToolsToolStrip1 = new DemosCommonCode.Imaging.VisualToolsToolStrip();
            this.findTextToolStrip1 = new DemosCommonCode.Imaging.FindTextToolStrip();
            this.annotationsToolStrip1 = new DemosCommonCode.Annotation.AnnotationsToolStrip();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.actionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelLoadingImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarImageLoading = new System.Windows.Forms.ToolStripProgressBar();
            this.imageInfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.zoomPanel = new System.Windows.Forms.Panel();
            this.toolStripPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.centerPrintingPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageAutoOrientationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolsTabControl.SuspendLayout();
            this.pagesTabPage.SuspendLayout();
            this.thumbnailMenu.SuspendLayout();
            this.textExtractionTabPage.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.panel5.SuspendLayout();
            this.commentsTabPage.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.zoomPanel.SuspendLayout();
            this.toolStripPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.annotationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(376, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addToolStripMenuItem,
            this.documentLayoutSettingsToolStripMenuItem,
            this.toolStripSeparator19,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.pageSettingsToolStripMenuItem,
            this.pageAutoOrientationToolStripMenuItem,
            this.centerPrintingPageToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.addToolStripMenuItem.Text = "Add...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // documentLayoutSettingsToolStripMenuItem
            // 
            this.documentLayoutSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docxLayoutSettingsToolStripMenuItem,
            this.xlsxLayoutSettingsToolStripMenuItem});
            this.documentLayoutSettingsToolStripMenuItem.Name = "documentLayoutSettingsToolStripMenuItem";
            this.documentLayoutSettingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.documentLayoutSettingsToolStripMenuItem.Text = "Layout Settings...";
            // 
            // docxLayoutSettingsToolStripMenuItem
            // 
            this.docxLayoutSettingsToolStripMenuItem.Name = "docxLayoutSettingsToolStripMenuItem";
            this.docxLayoutSettingsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.docxLayoutSettingsToolStripMenuItem.Text = "DOCX...";
            this.docxLayoutSettingsToolStripMenuItem.Click += new System.EventHandler(this.docxLayoutSettingsToolStripMenuItem_Click);
            // 
            // xlsxLayoutSettingsToolStripMenuItem
            // 
            this.xlsxLayoutSettingsToolStripMenuItem.Name = "xlsxLayoutSettingsToolStripMenuItem";
            this.xlsxLayoutSettingsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.xlsxLayoutSettingsToolStripMenuItem.Text = "XLSX...";
            this.xlsxLayoutSettingsToolStripMenuItem.Click += new System.EventHandler(this.xlsxLayoutSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(189, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // pageSettingsToolStripMenuItem
            // 
            this.pageSettingsToolStripMenuItem.Name = "pageSettingsToolStripMenuItem";
            this.pageSettingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.pageSettingsToolStripMenuItem.Text = "Page Settings...";
            this.pageSettingsToolStripMenuItem.Click += new System.EventHandler(this.pageSettingsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.printToolStripMenuItem.Text = "Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem,
            this.toolStripSeparator3,
            this.findTextToolStripMenuItem,
            this.toolStripSeparator4,
            this.enableUndoRedoToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.historyDialogToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "Del";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // findTextToolStripMenuItem
            // 
            this.findTextToolStripMenuItem.Name = "findTextToolStripMenuItem";
            this.findTextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findTextToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.findTextToolStripMenuItem.Text = "Find Text...";
            this.findTextToolStripMenuItem.Click += new System.EventHandler(this.findTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // enableUndoRedoToolStripMenuItem
            // 
            this.enableUndoRedoToolStripMenuItem.Name = "enableUndoRedoToolStripMenuItem";
            this.enableUndoRedoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.enableUndoRedoToolStripMenuItem.Text = "Enable Undo/Redo";
            this.enableUndoRedoToolStripMenuItem.Click += new System.EventHandler(this.enableUndoRedoToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // historyDialogToolStripMenuItem
            // 
            this.historyDialogToolStripMenuItem.Name = "historyDialogToolStripMenuItem";
            this.historyDialogToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.historyDialogToolStripMenuItem.Text = "History Dialog...";
            this.historyDialogToolStripMenuItem.Click += new System.EventHandler(this.historyDialogToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualToolsToolStripMenuItem,
            this.mainVisualToolStripMenuItem,
            this.thumbnailViewerSettingsToolStripMenuItem,
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem,
            this.toolStripSeparator5,
            this.imageDisplayModeToolStripMenuItem,
            this.imageScaleModeToolStripMenuItem,
            this.rotateViewToolStripMenuItem,
            this.viewerSettingsToolStripMenuItem,
            this.viewerRenderingSettingsToolStripMenuItem,
            this.interactionPointsSettingsToolStripMenuItem,
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem,
            this.boundAnnotationsToolStripMenuItem,
            this.moveAnnotationsBetweenImagesToolStripMenuItem,
            this.toolStripSeparator6,
            this.spellCheckSettingsToolStripMenuItem,
            this.spellCheckViewSettingsToolStripMenuItem,
            this.toolStripSeparator7,
            this.colorManagementToolStripMenuItem,
            this.toolStripSeparator11,
            this.documentMetadataToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // visualToolsToolStripMenuItem
            // 
            this.visualToolsToolStripMenuItem.Name = "visualToolsToolStripMenuItem";
            this.visualToolsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.visualToolsToolStripMenuItem.Text = "Visual Tools";
            // 
            // mainVisualToolStripMenuItem
            // 
            this.mainVisualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annotationToolToolStripMenuItem,
            this.navigationToolStripMenuItem,
            this.textSelectionToolStripMenuItem});
            this.mainVisualToolStripMenuItem.Name = "mainVisualToolStripMenuItem";
            this.mainVisualToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.mainVisualToolStripMenuItem.Text = "Main Visual Tool";
            // 
            // annotationToolToolStripMenuItem
            // 
            this.annotationToolToolStripMenuItem.Checked = true;
            this.annotationToolToolStripMenuItem.CheckOnClick = true;
            this.annotationToolToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.annotationToolToolStripMenuItem.Name = "annotationToolToolStripMenuItem";
            this.annotationToolToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.annotationToolToolStripMenuItem.Text = "Annotation Tool";
            this.annotationToolToolStripMenuItem.CheckedChanged += new System.EventHandler(this.annotationToolToolStripMenuItem_CheckedChanged);
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.Checked = true;
            this.navigationToolStripMenuItem.CheckOnClick = true;
            this.navigationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.navigationToolStripMenuItem.Text = "Navigation Tool";
            this.navigationToolStripMenuItem.CheckedChanged += new System.EventHandler(this.navigationToolStripMenuItem_CheckedChanged);
            // 
            // textSelectionToolStripMenuItem
            // 
            this.textSelectionToolStripMenuItem.Checked = true;
            this.textSelectionToolStripMenuItem.CheckOnClick = true;
            this.textSelectionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.textSelectionToolStripMenuItem.Name = "textSelectionToolStripMenuItem";
            this.textSelectionToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.textSelectionToolStripMenuItem.Text = "Text Selection Tool";
            this.textSelectionToolStripMenuItem.CheckedChanged += new System.EventHandler(this.textSelectionToolStripMenuItem_CheckedChanged);
            // 
            // thumbnailViewerSettingsToolStripMenuItem
            // 
            this.thumbnailViewerSettingsToolStripMenuItem.Name = "thumbnailViewerSettingsToolStripMenuItem";
            this.thumbnailViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.thumbnailViewerSettingsToolStripMenuItem.Text = "Thumbnail Viewer Settings...";
            this.thumbnailViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.thumbnailViewerSettingsToolStripMenuItem_Click);
            // 
            // showAnnotationTransformationOnThumbnailToolStripMenuItem
            // 
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.CheckOnClick = true;
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.Name = "showAnnotationTransformationOnThumbnailToolStripMenuItem";
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.Text = "Show Annotation Transformation on Thumbnail";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(364, 6);
            // 
            // imageDisplayModeToolStripMenuItem
            // 
            this.imageDisplayModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePageToolStripMenuItem,
            this.twoColumnsToolStripMenuItem,
            this.singleContinuousRowToolStripMenuItem,
            this.singleContinuousColumnToolStripMenuItem,
            this.twoContinuousRowsToolStripMenuItem,
            this.twoContinuousColumnsToolStripMenuItem});
            this.imageDisplayModeToolStripMenuItem.Name = "imageDisplayModeToolStripMenuItem";
            this.imageDisplayModeToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.imageDisplayModeToolStripMenuItem.Text = "Image Display Mode";
            // 
            // singlePageToolStripMenuItem
            // 
            this.singlePageToolStripMenuItem.Name = "singlePageToolStripMenuItem";
            this.singlePageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.singlePageToolStripMenuItem.Text = "Single Page";
            this.singlePageToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // twoColumnsToolStripMenuItem
            // 
            this.twoColumnsToolStripMenuItem.Name = "twoColumnsToolStripMenuItem";
            this.twoColumnsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.twoColumnsToolStripMenuItem.Text = "Two Columns";
            this.twoColumnsToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // singleContinuousRowToolStripMenuItem
            // 
            this.singleContinuousRowToolStripMenuItem.Name = "singleContinuousRowToolStripMenuItem";
            this.singleContinuousRowToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.singleContinuousRowToolStripMenuItem.Text = "Single Continuous Row";
            this.singleContinuousRowToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // singleContinuousColumnToolStripMenuItem
            // 
            this.singleContinuousColumnToolStripMenuItem.Name = "singleContinuousColumnToolStripMenuItem";
            this.singleContinuousColumnToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.singleContinuousColumnToolStripMenuItem.Text = "Single Continuous Column";
            this.singleContinuousColumnToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // twoContinuousRowsToolStripMenuItem
            // 
            this.twoContinuousRowsToolStripMenuItem.Name = "twoContinuousRowsToolStripMenuItem";
            this.twoContinuousRowsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.twoContinuousRowsToolStripMenuItem.Text = "Two Continuous Rows";
            this.twoContinuousRowsToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // twoContinuousColumnsToolStripMenuItem
            // 
            this.twoContinuousColumnsToolStripMenuItem.Name = "twoContinuousColumnsToolStripMenuItem";
            this.twoContinuousColumnsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.twoContinuousColumnsToolStripMenuItem.Text = "Two Continuous Columns";
            this.twoContinuousColumnsToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // imageScaleModeToolStripMenuItem
            // 
            this.imageScaleModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalImageToolStripMenuItem,
            this.bestFitToolStripMenuItem,
            this.fitToWidthToolStripMenuItem,
            this.fitToHeightToolStripMenuItem,
            this.pixelToPixelToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.toolStripSeparator18,
            this.scale25ToolStripMenuItem,
            this.scale50ToolStripMenuItem,
            this.scale100ToolStripMenuItem,
            this.scale200ToolStripMenuItem,
            this.scale400ToolStripMenuItem});
            this.imageScaleModeToolStripMenuItem.Name = "imageScaleModeToolStripMenuItem";
            this.imageScaleModeToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.imageScaleModeToolStripMenuItem.Text = "Image Scale Mode";
            // 
            // normalImageToolStripMenuItem
            // 
            this.normalImageToolStripMenuItem.Name = "normalImageToolStripMenuItem";
            this.normalImageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.normalImageToolStripMenuItem.Text = "Normal";
            this.normalImageToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // bestFitToolStripMenuItem
            // 
            this.bestFitToolStripMenuItem.Checked = true;
            this.bestFitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bestFitToolStripMenuItem.Name = "bestFitToolStripMenuItem";
            this.bestFitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.bestFitToolStripMenuItem.Text = "Best fit";
            this.bestFitToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // fitToWidthToolStripMenuItem
            // 
            this.fitToWidthToolStripMenuItem.Name = "fitToWidthToolStripMenuItem";
            this.fitToWidthToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fitToWidthToolStripMenuItem.Text = "Fit to width";
            this.fitToWidthToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // fitToHeightToolStripMenuItem
            // 
            this.fitToHeightToolStripMenuItem.Name = "fitToHeightToolStripMenuItem";
            this.fitToHeightToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fitToHeightToolStripMenuItem.Text = "Fit to height";
            this.fitToHeightToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // pixelToPixelToolStripMenuItem
            // 
            this.pixelToPixelToolStripMenuItem.Name = "pixelToPixelToolStripMenuItem";
            this.pixelToPixelToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.pixelToPixelToolStripMenuItem.Text = "Pixel to Pixel";
            this.pixelToPixelToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(138, 6);
            // 
            // scale25ToolStripMenuItem
            // 
            this.scale25ToolStripMenuItem.Name = "scale25ToolStripMenuItem";
            this.scale25ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale25ToolStripMenuItem.Text = "25%";
            this.scale25ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale50ToolStripMenuItem
            // 
            this.scale50ToolStripMenuItem.Name = "scale50ToolStripMenuItem";
            this.scale50ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale50ToolStripMenuItem.Text = "50%";
            this.scale50ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale100ToolStripMenuItem
            // 
            this.scale100ToolStripMenuItem.Name = "scale100ToolStripMenuItem";
            this.scale100ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale100ToolStripMenuItem.Text = "100%";
            this.scale100ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale200ToolStripMenuItem
            // 
            this.scale200ToolStripMenuItem.Name = "scale200ToolStripMenuItem";
            this.scale200ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale200ToolStripMenuItem.Text = "200%";
            this.scale200ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale400ToolStripMenuItem
            // 
            this.scale400ToolStripMenuItem.Name = "scale400ToolStripMenuItem";
            this.scale400ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale400ToolStripMenuItem.Text = "400%";
            this.scale400ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // rotateViewToolStripMenuItem
            // 
            this.rotateViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateClockwiseToolStripMenuItem,
            this.rotateCounterclockwiseToolStripMenuItem});
            this.rotateViewToolStripMenuItem.Name = "rotateViewToolStripMenuItem";
            this.rotateViewToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.rotateViewToolStripMenuItem.Text = "Rotate View";
            // 
            // rotateClockwiseToolStripMenuItem
            // 
            this.rotateClockwiseToolStripMenuItem.Name = "rotateClockwiseToolStripMenuItem";
            this.rotateClockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Plus";
            this.rotateClockwiseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Oemplus)));
            this.rotateClockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.rotateClockwiseToolStripMenuItem.Text = "Clockwise";
            this.rotateClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateClockwiseToolStripMenuItem_Click);
            // 
            // rotateCounterclockwiseToolStripMenuItem
            // 
            this.rotateCounterclockwiseToolStripMenuItem.Name = "rotateCounterclockwiseToolStripMenuItem";
            this.rotateCounterclockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Minus";
            this.rotateCounterclockwiseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.OemMinus)));
            this.rotateCounterclockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.rotateCounterclockwiseToolStripMenuItem.Text = "Counterclockwise";
            this.rotateCounterclockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateCounterclockwiseToolStripMenuItem_Click);
            // 
            // viewerSettingsToolStripMenuItem
            // 
            this.viewerSettingsToolStripMenuItem.Name = "viewerSettingsToolStripMenuItem";
            this.viewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.viewerSettingsToolStripMenuItem.Text = "Viewer Settings...";
            this.viewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.viewerSettingsToolStripMenuItem_Click);
            // 
            // viewerRenderingSettingsToolStripMenuItem
            // 
            this.viewerRenderingSettingsToolStripMenuItem.Name = "viewerRenderingSettingsToolStripMenuItem";
            this.viewerRenderingSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.viewerRenderingSettingsToolStripMenuItem.Text = "Viewer Rendering Settings...";
            this.viewerRenderingSettingsToolStripMenuItem.Click += new System.EventHandler(this.viewerRenderingSettingsToolStripMenuItem_Click);
            // 
            // interactionPointsSettingsToolStripMenuItem
            // 
            this.interactionPointsSettingsToolStripMenuItem.Name = "interactionPointsSettingsToolStripMenuItem";
            this.interactionPointsSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.interactionPointsSettingsToolStripMenuItem.Text = "Interaction Points Settings...";
            this.interactionPointsSettingsToolStripMenuItem.Click += new System.EventHandler(this.interactionPointsAppearanceToolStripMenuItem_Click);
            // 
            // scrollViewerWhenAnnotationIsMovedToolStripMenuItem
            // 
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Checked = true;
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.CheckOnClick = true;
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Name = "scrollViewerWhenAnnotationIsMovedToolStripMenuItem";
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Text = "Scroll Viewer When Annotation is Moved";
            // 
            // boundAnnotationsToolStripMenuItem
            // 
            this.boundAnnotationsToolStripMenuItem.CheckOnClick = true;
            this.boundAnnotationsToolStripMenuItem.Name = "boundAnnotationsToolStripMenuItem";
            this.boundAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.boundAnnotationsToolStripMenuItem.Text = "Move Annotations Within Image Bounds";
            this.boundAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.boundAnnotationsToolStripMenuItem_Click);
            // 
            // moveAnnotationsBetweenImagesToolStripMenuItem
            // 
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Checked = true;
            this.moveAnnotationsBetweenImagesToolStripMenuItem.CheckOnClick = true;
            this.moveAnnotationsBetweenImagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Name = "moveAnnotationsBetweenImagesToolStripMenuItem";
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Text = "Move Annotations Between Images (Multipage Display)";
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Click += new System.EventHandler(this.moveAnnotationsBetweenImagesToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(364, 6);
            // 
            // spellCheckSettingsToolStripMenuItem
            // 
            this.spellCheckSettingsToolStripMenuItem.Name = "spellCheckSettingsToolStripMenuItem";
            this.spellCheckSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.spellCheckSettingsToolStripMenuItem.Text = "Spell Check Settings...";
            this.spellCheckSettingsToolStripMenuItem.Click += new System.EventHandler(this.spellCheckSettingsToolStripMenuItem_Click);
            // 
            // spellCheckViewSettingsToolStripMenuItem
            // 
            this.spellCheckViewSettingsToolStripMenuItem.Name = "spellCheckViewSettingsToolStripMenuItem";
            this.spellCheckViewSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.spellCheckViewSettingsToolStripMenuItem.Text = "Spell Check View Settings...";
            this.spellCheckViewSettingsToolStripMenuItem.Click += new System.EventHandler(this.spellCheckViewSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(364, 6);
            // 
            // colorManagementToolStripMenuItem
            // 
            this.colorManagementToolStripMenuItem.Name = "colorManagementToolStripMenuItem";
            this.colorManagementToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.colorManagementToolStripMenuItem.Text = "Color Management...";
            this.colorManagementToolStripMenuItem.Click += new System.EventHandler(this.colorManagementToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(364, 6);
            // 
            // documentMetadataToolStripMenuItem
            // 
            this.documentMetadataToolStripMenuItem.Name = "documentMetadataToolStripMenuItem";
            this.documentMetadataToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.documentMetadataToolStripMenuItem.Text = "Document Metadata...";
            this.documentMetadataToolStripMenuItem.Click += new System.EventHandler(this.documentMetadataToolStripMenuItem_Click);
            // 
            // annotationsToolStripMenuItem
            // 
            this.annotationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annotationsInfoToolStripMenuItem,
            this.toolStripSeparator8,
            this.interactionModeToolStripMenuItem,
            this.transformationModeToolStripMenuItem,
            this.toolStripSeparator9,
            this.loadFromFileToolStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.toolStripSeparator10,
            this.addAnnotationToolStripMenuItem,
            this.buildAnnotationsContinuouslyToolStripMenuItem,
            this.toolStripSeparator13,
            this.bringToBackToolStripMenuItem,
            this.bringToFrontToolStripMenuItem,
            this.toolStripSeparator12,
            this.multiSelectToolStripMenuItem,
            this.toolStripSeparator14,
            this.groupUngroupSelectedToolStripMenuItem,
            this.groupAllToolStripMenuItem,
            this.toolStripSeparator15,
            this.rotateImageWithAnnotationsToolStripMenuItem,
            this.burnAnnotationsOnImageToolStripMenuItem,
            this.cloneImageWithAnnotationsToolStripMenuItem,
            this.saveImageWithAnnotationsToolStripMenuItem,
            this.copyImageToClipboardToolStripMenuItem,
            this.deleteImageToolStripMenuItem});
            this.annotationsToolStripMenuItem.Name = "annotationsToolStripMenuItem";
            this.annotationsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.annotationsToolStripMenuItem.Text = "Annotations";
            this.annotationsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.annotationsToolStripMenuItem_DropDownOpening);
            // 
            // annotationsInfoToolStripMenuItem
            // 
            this.annotationsInfoToolStripMenuItem.Name = "annotationsInfoToolStripMenuItem";
            this.annotationsInfoToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.annotationsInfoToolStripMenuItem.Text = "Info...";
            this.annotationsInfoToolStripMenuItem.Click += new System.EventHandler(this.annotationsInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(244, 6);
            // 
            // interactionModeToolStripMenuItem
            // 
            this.interactionModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.authorToolStripMenuItem});
            this.interactionModeToolStripMenuItem.Name = "interactionModeToolStripMenuItem";
            this.interactionModeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.interactionModeToolStripMenuItem.Text = "Interaction Mode";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.viewToolStripMenuItem1.Text = "View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Checked = true;
            this.authorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.authorToolStripMenuItem.Text = "Author";
            this.authorToolStripMenuItem.Click += new System.EventHandler(this.authorToolStripMenuItem_Click);
            // 
            // transformationModeToolStripMenuItem
            // 
            this.transformationModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangularToolStripMenuItem,
            this.pointsToolStripMenuItem,
            this.rectangularAndPointsToolStripMenuItem});
            this.transformationModeToolStripMenuItem.Name = "transformationModeToolStripMenuItem";
            this.transformationModeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.transformationModeToolStripMenuItem.Text = "Transformation Mode";
            // 
            // rectangularToolStripMenuItem
            // 
            this.rectangularToolStripMenuItem.Name = "rectangularToolStripMenuItem";
            this.rectangularToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.rectangularToolStripMenuItem.Text = "Rectangular";
            this.rectangularToolStripMenuItem.Click += new System.EventHandler(this.rectangularToolStripMenuItem_Click);
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.pointsToolStripMenuItem.Text = "Points";
            this.pointsToolStripMenuItem.Click += new System.EventHandler(this.pointsToolStripMenuItem_Click);
            // 
            // rectangularAndPointsToolStripMenuItem
            // 
            this.rectangularAndPointsToolStripMenuItem.Name = "rectangularAndPointsToolStripMenuItem";
            this.rectangularAndPointsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.rectangularAndPointsToolStripMenuItem.Text = "Rectangular and Points";
            this.rectangularAndPointsToolStripMenuItem.Click += new System.EventHandler(this.rectangularAndPointsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(244, 6);
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.loadFromFileToolStripMenuItem.Text = "Load From File...";
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadAnnotationsFromFileToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.saveToFileToolStripMenuItem.Text = "Save To File...";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveAnnotationsToFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(244, 6);
            // 
            // addAnnotationToolStripMenuItem
            // 
            this.addAnnotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.highlightToolStripMenuItem,
            this.textHighlightToolStripMenuItem,
            this.embeddedImageToolStripMenuItem,
            this.referencedImageToolStripMenuItem,
            this.textToolStripMenuItem,
            this.stickyNoteToolStripMenuItem,
            this.freeTextToolStripMenuItem,
            this.rubberStampToolStripMenuItem,
            this.linkToolStripMenuItem,
            this.toolStripSeparator16,
            this.lineToolStripMenuItem,
            this.linesToolStripMenuItem,
            this.linesWithInterpolationToolStripMenuItem,
            this.freehandLinesToolStripMenuItem,
            this.polygonToolStripMenuItem,
            this.polygonWithInterpolationToolStripMenuItem,
            this.freehandPolygonToolStripMenuItem,
            this.rulerToolStripMenuItem,
            this.rulersToolStripMenuItem,
            this.angleToolStripMenuItem,
            this.toolStripSeparator17,
            this.triangleCustomAnnotationToolStripMenuItem,
            this.markCustomAnnotationToolStripMenuItem});
            this.addAnnotationToolStripMenuItem.Name = "addAnnotationToolStripMenuItem";
            this.addAnnotationToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.addAnnotationToolStripMenuItem.Text = "Add";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // highlightToolStripMenuItem
            // 
            this.highlightToolStripMenuItem.Name = "highlightToolStripMenuItem";
            this.highlightToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.highlightToolStripMenuItem.Text = "Highlight";
            this.highlightToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // textHighlightToolStripMenuItem
            // 
            this.textHighlightToolStripMenuItem.Name = "textHighlightToolStripMenuItem";
            this.textHighlightToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.textHighlightToolStripMenuItem.Text = "Text highlight";
            this.textHighlightToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // embeddedImageToolStripMenuItem
            // 
            this.embeddedImageToolStripMenuItem.Name = "embeddedImageToolStripMenuItem";
            this.embeddedImageToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.embeddedImageToolStripMenuItem.Text = "Embedded image";
            this.embeddedImageToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // referencedImageToolStripMenuItem
            // 
            this.referencedImageToolStripMenuItem.Name = "referencedImageToolStripMenuItem";
            this.referencedImageToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.referencedImageToolStripMenuItem.Text = "Referenced image";
            this.referencedImageToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // stickyNoteToolStripMenuItem
            // 
            this.stickyNoteToolStripMenuItem.Name = "stickyNoteToolStripMenuItem";
            this.stickyNoteToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.stickyNoteToolStripMenuItem.Text = "Sticky note";
            this.stickyNoteToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // freeTextToolStripMenuItem
            // 
            this.freeTextToolStripMenuItem.Name = "freeTextToolStripMenuItem";
            this.freeTextToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.freeTextToolStripMenuItem.Text = "Free text";
            this.freeTextToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // rubberStampToolStripMenuItem
            // 
            this.rubberStampToolStripMenuItem.Name = "rubberStampToolStripMenuItem";
            this.rubberStampToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rubberStampToolStripMenuItem.Text = "Rubber stamp";
            this.rubberStampToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linkToolStripMenuItem.Text = "Link";
            this.linkToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(228, 6);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linesToolStripMenuItem.Text = "Lines";
            this.linesToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // linesWithInterpolationToolStripMenuItem
            // 
            this.linesWithInterpolationToolStripMenuItem.Name = "linesWithInterpolationToolStripMenuItem";
            this.linesWithInterpolationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linesWithInterpolationToolStripMenuItem.Text = "Lines with interpolation";
            this.linesWithInterpolationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // freehandLinesToolStripMenuItem
            // 
            this.freehandLinesToolStripMenuItem.Name = "freehandLinesToolStripMenuItem";
            this.freehandLinesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.freehandLinesToolStripMenuItem.Text = "Freehand lines";
            this.freehandLinesToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // polygonWithInterpolationToolStripMenuItem
            // 
            this.polygonWithInterpolationToolStripMenuItem.Name = "polygonWithInterpolationToolStripMenuItem";
            this.polygonWithInterpolationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.polygonWithInterpolationToolStripMenuItem.Text = "Polygon with interpolation";
            this.polygonWithInterpolationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // freehandPolygonToolStripMenuItem
            // 
            this.freehandPolygonToolStripMenuItem.Name = "freehandPolygonToolStripMenuItem";
            this.freehandPolygonToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.freehandPolygonToolStripMenuItem.Text = "Freehand polygon";
            this.freehandPolygonToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // rulerToolStripMenuItem
            // 
            this.rulerToolStripMenuItem.Name = "rulerToolStripMenuItem";
            this.rulerToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rulerToolStripMenuItem.Text = "Ruler";
            this.rulerToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // rulersToolStripMenuItem
            // 
            this.rulersToolStripMenuItem.Name = "rulersToolStripMenuItem";
            this.rulersToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rulersToolStripMenuItem.Text = "Rulers";
            this.rulersToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // angleToolStripMenuItem
            // 
            this.angleToolStripMenuItem.Name = "angleToolStripMenuItem";
            this.angleToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.angleToolStripMenuItem.Text = "Angle";
            this.angleToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(228, 6);
            // 
            // triangleCustomAnnotationToolStripMenuItem
            // 
            this.triangleCustomAnnotationToolStripMenuItem.Name = "triangleCustomAnnotationToolStripMenuItem";
            this.triangleCustomAnnotationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.triangleCustomAnnotationToolStripMenuItem.Text = "Triangle - Custom Annotation";
            this.triangleCustomAnnotationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // markCustomAnnotationToolStripMenuItem
            // 
            this.markCustomAnnotationToolStripMenuItem.Name = "markCustomAnnotationToolStripMenuItem";
            this.markCustomAnnotationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.markCustomAnnotationToolStripMenuItem.Text = "Mark - Custom Annotation";
            this.markCustomAnnotationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // buildAnnotationsContinuouslyToolStripMenuItem
            // 
            this.buildAnnotationsContinuouslyToolStripMenuItem.CheckOnClick = true;
            this.buildAnnotationsContinuouslyToolStripMenuItem.Name = "buildAnnotationsContinuouslyToolStripMenuItem";
            this.buildAnnotationsContinuouslyToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.buildAnnotationsContinuouslyToolStripMenuItem.Text = "Build Annotations Continuously";
            this.buildAnnotationsContinuouslyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.buildAnnotationsContinuouslyToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(244, 6);
            // 
            // bringToBackToolStripMenuItem
            // 
            this.bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
            this.bringToBackToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.bringToBackToolStripMenuItem.Text = "Bring to back";
            this.bringToBackToolStripMenuItem.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.bringToFrontToolStripMenuItem.Text = "Bring to front";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(244, 6);
            // 
            // multiSelectToolStripMenuItem
            // 
            this.multiSelectToolStripMenuItem.Checked = true;
            this.multiSelectToolStripMenuItem.CheckOnClick = true;
            this.multiSelectToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.multiSelectToolStripMenuItem.Name = "multiSelectToolStripMenuItem";
            this.multiSelectToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.multiSelectToolStripMenuItem.Text = "Multi Select";
            this.multiSelectToolStripMenuItem.Click += new System.EventHandler(this.multiSelectToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(244, 6);
            // 
            // groupUngroupSelectedToolStripMenuItem
            // 
            this.groupUngroupSelectedToolStripMenuItem.Name = "groupUngroupSelectedToolStripMenuItem";
            this.groupUngroupSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.groupUngroupSelectedToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.groupUngroupSelectedToolStripMenuItem.Text = "Group/Ungroup Selected";
            this.groupUngroupSelectedToolStripMenuItem.Click += new System.EventHandler(this.groupSelectedToolStripMenuItem_Click);
            // 
            // groupAllToolStripMenuItem
            // 
            this.groupAllToolStripMenuItem.Name = "groupAllToolStripMenuItem";
            this.groupAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.groupAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.groupAllToolStripMenuItem.Text = "Group All";
            this.groupAllToolStripMenuItem.Click += new System.EventHandler(this.groupAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(244, 6);
            // 
            // rotateImageWithAnnotationsToolStripMenuItem
            // 
            this.rotateImageWithAnnotationsToolStripMenuItem.Name = "rotateImageWithAnnotationsToolStripMenuItem";
            this.rotateImageWithAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.rotateImageWithAnnotationsToolStripMenuItem.Text = "Rotate Image with Annotations...";
            this.rotateImageWithAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.rotateImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // burnAnnotationsOnImageToolStripMenuItem
            // 
            this.burnAnnotationsOnImageToolStripMenuItem.Name = "burnAnnotationsOnImageToolStripMenuItem";
            this.burnAnnotationsOnImageToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.burnAnnotationsOnImageToolStripMenuItem.Text = "Burn Annotations on Image";
            this.burnAnnotationsOnImageToolStripMenuItem.Click += new System.EventHandler(this.burnAnnotationsOnImageToolStripMenuItem_Click);
            // 
            // cloneImageWithAnnotationsToolStripMenuItem
            // 
            this.cloneImageWithAnnotationsToolStripMenuItem.Name = "cloneImageWithAnnotationsToolStripMenuItem";
            this.cloneImageWithAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.cloneImageWithAnnotationsToolStripMenuItem.Text = "Clone Image with Annotations";
            this.cloneImageWithAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.cloneImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // saveImageWithAnnotationsToolStripMenuItem
            // 
            this.saveImageWithAnnotationsToolStripMenuItem.Name = "saveImageWithAnnotationsToolStripMenuItem";
            this.saveImageWithAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.saveImageWithAnnotationsToolStripMenuItem.Text = "Save image with annotations...";
            this.saveImageWithAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.saveImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // copyImageToClipboardToolStripMenuItem
            // 
            this.copyImageToClipboardToolStripMenuItem.Name = "copyImageToClipboardToolStripMenuItem";
            this.copyImageToClipboardToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.copyImageToClipboardToolStripMenuItem.Text = "Copy image to clipboard";
            this.copyImageToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyImageToClipboardToolStripMenuItem_Click);
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            this.deleteImageToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.deleteImageToolStripMenuItem.Text = "Delete image";
            this.deleteImageToolStripMenuItem.Click += new System.EventHandler(this.deleteImageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // annotationViewer1
            // 
            this.annotationViewer1.AllowMoveSelectedAnnotations = true;
            this.annotationViewer1.AnnotationAuthorContextMenuStrip = null;
            this.annotationViewer1.AnnotationBoundingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.annotationViewer1.AnnotationViewContextMenuStrip = null;
            this.annotationViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.annotationViewer1.Clipboard = winFormsSystemClipboard1;
            this.annotationViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.annotationViewer1.DisplayMode = Vintasoft.Imaging.UI.ImageViewerDisplayMode.SingleContinuousColumn;
            this.annotationViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationViewer1.ImageRenderingSettings = renderingSettings1;
            this.annotationViewer1.ImageRotationAngle = 0;
            this.annotationViewer1.IsKeyboardNavigationEnabled = true;
            this.annotationViewer1.Location = new System.Drawing.Point(0, 0);
            this.annotationViewer1.MultipageDisplayMode = Vintasoft.Imaging.UI.ImageViewerMultipageDisplayMode.AllImages;
            this.annotationViewer1.Name = "annotationViewer1";
            this.annotationViewer1.RendererCacheSize = 256F;
            this.annotationViewer1.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.Size = new System.Drawing.Size(753, 631);
            this.annotationViewer1.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.annotationViewer1.TabIndex = 5;
            this.annotationViewer1.Text = "annotationViewer1";
            this.annotationViewer1.AnnotationTransformingStarted += new System.EventHandler<Vintasoft.Imaging.Annotation.UI.VisualTools.AnnotationViewEventArgs>(this.annotationViewer1_AnnotationTransformingStarted);
            this.annotationViewer1.AnnotationTransformingFinished += new System.EventHandler<Vintasoft.Imaging.Annotation.UI.VisualTools.AnnotationViewEventArgs>(this.annotationViewer1_AnnotationTransformingFinished);
            this.annotationViewer1.ImageLoading += new System.EventHandler<Vintasoft.Imaging.ImageLoadingEventArgs>(this.annotationViewer1_ImageLoading);
            this.annotationViewer1.ImageLoadingProgress += new System.EventHandler<Vintasoft.Imaging.ProgressEventArgs>(this.annotationViewer1_ImageLoadingProgress);
            this.annotationViewer1.ImageLoaded += new System.EventHandler<Vintasoft.Imaging.ImageLoadedEventArgs>(this.annotationViewer1_ImageLoaded);
            this.annotationViewer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.annotationViewer1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolsTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.annotationViewer1);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1027, 631);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 5;
            // 
            // toolsTabControl
            // 
            this.toolsTabControl.Controls.Add(this.pagesTabPage);
            this.toolsTabControl.Controls.Add(this.textExtractionTabPage);
            this.toolsTabControl.Controls.Add(this.annotationsTabPage);
            this.toolsTabControl.Controls.Add(this.commentsTabPage);
            this.toolsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsTabControl.Location = new System.Drawing.Point(0, 0);
            this.toolsTabControl.Name = "toolsTabControl";
            this.toolsTabControl.SelectedIndex = 0;
            this.toolsTabControl.Size = new System.Drawing.Size(270, 631);
            this.toolsTabControl.TabIndex = 5;
            // 
            // pagesTabPage
            // 
            this.pagesTabPage.Controls.Add(this.thumbnailViewer1);
            this.pagesTabPage.Location = new System.Drawing.Point(4, 22);
            this.pagesTabPage.Name = "pagesTabPage";
            this.pagesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pagesTabPage.Size = new System.Drawing.Size(262, 605);
            this.pagesTabPage.TabIndex = 0;
            this.pagesTabPage.Text = "Pages";
            this.pagesTabPage.UseVisualStyleBackColor = true;
            // 
            // thumbnailViewer1
            // 
            this.thumbnailViewer1.AllowDrop = true;
            this.thumbnailViewer1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.thumbnailViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.thumbnailViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnailViewer1.Clipboard = winFormsSystemClipboard1;
            this.thumbnailViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance1.BorderWidth = 1;
            this.thumbnailViewer1.FocusedThumbnailAppearance = thumbnailAppearance1;
            this.thumbnailViewer1.GenerateOnlyVisibleThumbnails = true;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.thumbnailViewer1.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.thumbnailViewer1.ImageRotationAngle = 0;
            this.thumbnailViewer1.Location = new System.Drawing.Point(3, 3);
            this.thumbnailViewer1.MasterViewer = this.annotationViewer1;
            this.thumbnailViewer1.Name = "thumbnailViewer1";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.thumbnailViewer1.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.thumbnailViewer1.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.thumbnailViewer1.Size = new System.Drawing.Size(256, 599);
            this.thumbnailViewer1.TabIndex = 0;
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.thumbnailViewer1.ThumbnailAppearance = thumbnailAppearance5;
            thumbnailCaption1.Padding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            thumbnailCaption1.TextColor = System.Drawing.Color.Black;
            this.thumbnailViewer1.ThumbnailCaption = thumbnailCaption1;
            this.thumbnailViewer1.ThumbnailContextMenuStrip = this.thumbnailMenu;
            this.thumbnailViewer1.ThumbnailControlPadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.thumbnailViewer1.ThumbnailImagePadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.thumbnailViewer1.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.thumbnailViewer1.ThumbnailRenderingThreadCount = 4;
            this.thumbnailViewer1.ThumbnailSize = new System.Drawing.Size(128, 128);
            this.thumbnailViewer1.ThumbnailsLoadingProgress += new System.EventHandler<Vintasoft.Imaging.UI.ThumbnailsLoadingProgressEventArgs>(this.thumbnailViewer1_ThumbnailsLoadingProgress);
            this.thumbnailViewer1.HoveredThumbnailChanged += new System.EventHandler<Vintasoft.Imaging.UI.ThumbnailEventArgs>(this.thumbnailViewer1_HoveredThumbnailChanged);
            // 
            // thumbnailMenu
            // 
            this.thumbnailMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.thumbnailMenu.Name = "annoViewerMenu";
            this.thumbnailMenu.Size = new System.Drawing.Size(236, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem1.Text = "Save image with annotations...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.saveImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem2.Text = "Burn annotations on Image";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.burnAnnotationsOnImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem3.Text = "Copy image to clipboard";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.copyImageToClipboardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem4.Text = "Delete image(s)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.deleteImageToolStripMenuItem_Click);
            // 
            // textExtractionTabPage
            // 
            this.textExtractionTabPage.Controls.Add(this.textSelectionControl1);
            this.textExtractionTabPage.Location = new System.Drawing.Point(4, 22);
            this.textExtractionTabPage.Name = "textExtractionTabPage";
            this.textExtractionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.textExtractionTabPage.Size = new System.Drawing.Size(262, 605);
            this.textExtractionTabPage.TabIndex = 1;
            this.textExtractionTabPage.Text = "Text Extraction";
            this.textExtractionTabPage.UseVisualStyleBackColor = true;
            // 
            // textSelectionControl1
            // 
            this.textSelectionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSelectionControl1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.textSelectionControl1.Location = new System.Drawing.Point(3, 3);
            this.textSelectionControl1.MinimumSize = new System.Drawing.Size(183, 390);
            this.textSelectionControl1.Name = "textSelectionControl1";
            this.textSelectionControl1.Size = new System.Drawing.Size(256, 599);
            this.textSelectionControl1.TabIndex = 0;
            this.textSelectionControl1.TextSelectionTool = null;
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.panel5);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(262, 605);
            this.annotationsTabPage.TabIndex = 2;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.annotationPropertyGrid);
            this.panel5.Controls.Add(this.annotationComboBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 599);
            this.panel5.TabIndex = 3;
            // 
            // annotationPropertyGrid
            // 
            this.annotationPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annotationPropertyGrid.Location = new System.Drawing.Point(0, 24);
            this.annotationPropertyGrid.Name = "annotationPropertyGrid";
            this.annotationPropertyGrid.Size = new System.Drawing.Size(256, 572);
            this.annotationPropertyGrid.TabIndex = 1;
            // 
            // annotationComboBox
            // 
            this.annotationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annotationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.annotationComboBox.FormattingEnabled = true;
            this.annotationComboBox.Location = new System.Drawing.Point(0, 1);
            this.annotationComboBox.Name = "annotationComboBox";
            this.annotationComboBox.Size = new System.Drawing.Size(256, 21);
            this.annotationComboBox.TabIndex = 0;
            this.annotationComboBox.DropDown += new System.EventHandler(this.annotationComboBox_DropDown);
            this.annotationComboBox.SelectedIndexChanged += new System.EventHandler(this.annotationComboBox_SelectedIndexChanged);
            // 
            // commentsTabPage
            // 
            this.commentsTabPage.Controls.Add(this.annotationCommentsControl1);
            this.commentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.commentsTabPage.Name = "commentsTabPage";
            this.commentsTabPage.Size = new System.Drawing.Size(262, 605);
            this.commentsTabPage.TabIndex = 3;
            this.commentsTabPage.Text = "Comments";
            this.commentsTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationCommentsControl1
            // 
            this.annotationCommentsControl1.AnnotationTool = null;
            this.annotationCommentsControl1.CommentTool = null;
            this.annotationCommentsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationCommentsControl1.ImageViewer = null;
            this.annotationCommentsControl1.Location = new System.Drawing.Point(0, 0);
            this.annotationCommentsControl1.MinimumSize = new System.Drawing.Size(190, 180);
            this.annotationCommentsControl1.Name = "annotationCommentsControl1";
            this.annotationCommentsControl1.Size = new System.Drawing.Size(262, 605);
            this.annotationCommentsControl1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.viewerToolStrip);
            this.flowLayoutPanel1.Controls.Add(this.visualToolsToolStrip1);
            this.flowLayoutPanel1.Controls.Add(this.findTextToolStrip1);
            this.flowLayoutPanel1.Controls.Add(this.annotationsToolStrip1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1027, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // viewerToolStrip
            // 
            this.viewerToolStrip.AssociatedZoomTrackBar = null;
            this.viewerToolStrip.CanScan = true;
            this.viewerToolStrip.CaptureFromCameraButtonEnabled = true;
            this.viewerToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewerToolStrip.ImageViewer = this.annotationViewer1;
            this.viewerToolStrip.Location = new System.Drawing.Point(0, 0);
            this.viewerToolStrip.Name = "viewerToolStrip";
            this.viewerToolStrip.PageCount = 0;
            this.viewerToolStrip.PrintButtonEnabled = true;
            this.viewerToolStrip.ScanButtonEnabled = true;
            this.viewerToolStrip.Size = new System.Drawing.Size(391, 25);
            this.viewerToolStrip.TabIndex = 2;
            this.viewerToolStrip.Text = "imageViewerToolStrip1";
            this.viewerToolStrip.UseImageViewerImages = true;
            this.viewerToolStrip.OpenFile += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.viewerToolStrip.SaveFile += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            this.viewerToolStrip.Scan += new System.EventHandler(this.scanViewerToolStripButton_Click);
            this.viewerToolStrip.Print += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // visualToolsToolStrip1
            // 
            this.visualToolsToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.visualToolsToolStrip1.Enabled = false;
            this.visualToolsToolStrip1.ImageViewer = this.annotationViewer1;
            this.visualToolsToolStrip1.Location = new System.Drawing.Point(391, 0);
            this.visualToolsToolStrip1.MandatoryVisualTool = null;
            this.visualToolsToolStrip1.Name = "visualToolsToolStrip1";
            this.visualToolsToolStrip1.Size = new System.Drawing.Size(35, 25);
            this.visualToolsToolStrip1.TabIndex = 2;
            this.visualToolsToolStrip1.Text = "visualToolsToolStrip1";
            this.visualToolsToolStrip1.VisualToolsMenuItem = this.visualToolsToolStripMenuItem;
            // 
            // findTextToolStrip1
            // 
            this.findTextToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.findTextToolStrip1.Location = new System.Drawing.Point(426, 0);
            this.findTextToolStrip1.Name = "findTextToolStrip1";
            this.findTextToolStrip1.Size = new System.Drawing.Size(210, 25);
            this.findTextToolStrip1.TabIndex = 3;
            this.findTextToolStrip1.Text = "findTextToolStrip1";
            this.findTextToolStrip1.TextSelectionTool = null;
            // 
            // annotationsToolStrip1
            // 
            this.annotationsToolStrip1.AnnotationViewer = null;
            this.annotationsToolStrip1.CommentBuilder = null;
            this.annotationsToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.annotationsToolStrip1.Location = new System.Drawing.Point(0, 25);
            this.annotationsToolStrip1.Name = "annotationsToolStrip1";
            this.annotationsToolStrip1.NeedBuildAnnotationsContinuously = false;
            this.annotationsToolStrip1.Size = new System.Drawing.Size(869, 25);
            this.annotationsToolStrip1.TabIndex = 2;
            this.annotationsToolStrip1.Text = "annotationsToolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionLabel,
            this.progressBar1,
            this.toolStripStatusLabelLoadingImage,
            this.progressBarImageLoading,
            this.imageInfoStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1027, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // actionLabel
            // 
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(118, 17);
            this.actionLabel.Text = "toolStripStatusLabel1";
            this.actionLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            this.progressBar1.Visible = false;
            // 
            // toolStripStatusLabelLoadingImage
            // 
            this.toolStripStatusLabelLoadingImage.Name = "toolStripStatusLabelLoadingImage";
            this.toolStripStatusLabelLoadingImage.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabelLoadingImage.Text = "Loading image:";
            this.toolStripStatusLabelLoadingImage.Visible = false;
            // 
            // progressBarImageLoading
            // 
            this.progressBarImageLoading.Name = "progressBarImageLoading";
            this.progressBarImageLoading.Size = new System.Drawing.Size(100, 16);
            this.progressBarImageLoading.Visible = false;
            // 
            // imageInfoStatusLabel
            // 
            this.imageInfoStatusLabel.Name = "imageInfoStatusLabel";
            this.imageInfoStatusLabel.Size = new System.Drawing.Size(1012, 17);
            this.imageInfoStatusLabel.Spring = true;
            this.imageInfoStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 729);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.zoomPanel);
            this.panel3.Controls.Add(this.toolStripPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1027, 705);
            this.panel3.TabIndex = 1;
            // 
            // zoomPanel
            // 
            this.zoomPanel.Controls.Add(this.splitContainer1);
            this.zoomPanel.Controls.Add(this.statusStrip1);
            this.zoomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomPanel.Location = new System.Drawing.Point(0, 52);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Size = new System.Drawing.Size(1027, 653);
            this.zoomPanel.TabIndex = 1;
            // 
            // toolStripPanel
            // 
            this.toolStripPanel.Controls.Add(this.flowLayoutPanel1);
            this.toolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel.Name = "toolStripPanel";
            this.toolStripPanel.Size = new System.Drawing.Size(1027, 52);
            this.toolStripPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainMenu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 24);
            this.panel2.TabIndex = 0;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // centerPrintingPageToolStripMenuItem
            // 
            this.centerPrintingPageToolStripMenuItem.Name = "centerPrintingPageToolStripMenuItem";
            this.centerPrintingPageToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.centerPrintingPageToolStripMenuItem.Text = "Center Page";
            this.centerPrintingPageToolStripMenuItem.Click += new System.EventHandler(this.centerPrintingPageToolStripMenuItem_Click);
            // 
            // pageAutoOrientationToolStripMenuItem
            // 
            this.pageAutoOrientationToolStripMenuItem.Name = "pageAutoOrientationToolStripMenuItem";
            this.pageAutoOrientationToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.pageAutoOrientationToolStripMenuItem.Text = "Page Auto Orientation";
            this.pageAutoOrientationToolStripMenuItem.Click += new System.EventHandler(this.pageAutoOrientationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 729);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft Document Viewer Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolsTabControl.ResumeLayout(false);
            this.pagesTabPage.ResumeLayout(false);
            this.thumbnailMenu.ResumeLayout(false);
            this.textExtractionTabPage.ResumeLayout(false);
            this.annotationsTabPage.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.commentsTabPage.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.zoomPanel.ResumeLayout(false);
            this.zoomPanel.PerformLayout();
            this.toolStripPanel.ResumeLayout(false);
            this.toolStripPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

#endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pageSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem enableUndoRedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thumbnailViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAnnotationTransformationOnThumbnailToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem imageDisplayModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageScaleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interactionPointsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrollViewerWhenAnnotationIsMovedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveAnnotationsBetweenImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem spellCheckSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spellCheckViewSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem colorManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationsInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem interactionModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformationModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem addAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAnnotationsContinuouslyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem multiSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem groupUngroupSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem rotateImageWithAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneImageWithAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangularAndPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textHighlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embeddedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referencedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stickyNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubberStampToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesWithInterpolationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freehandLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonWithInterpolationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freehandPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem angleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem triangleCustomAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markCustomAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleContinuousRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleContinuousColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoContinuousRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoContinuousColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem scale25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale400ToolStripMenuItem;
        private Vintasoft.Imaging.Annotation.UI.AnnotationViewer annotationViewer1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private DemosCommonCode.Imaging.ImageViewerToolStrip viewerToolStrip;
        private DemosCommonCode.Imaging.VisualToolsToolStrip visualToolsToolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl toolsTabControl;
        private System.Windows.Forms.TabPage pagesTabPage;
        private System.Windows.Forms.TabPage textExtractionTabPage;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel actionLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripProgressBar progressBarImageLoading;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLoadingImage;
        private System.Windows.Forms.ToolStripStatusLabel imageInfoStatusLabel;
        private DemosCommonCode.Annotation.AnnotationsToolStrip annotationsToolStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel toolStripPanel;
        private System.Windows.Forms.Panel zoomPanel;
        private Vintasoft.Imaging.Annotation.UI.AnnotatedThumbnailViewer thumbnailViewer1;
        private System.Windows.Forms.ContextMenuStrip thumbnailMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PropertyGrid annotationPropertyGrid;
        private System.Windows.Forms.ComboBox annotationComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DemosCommonCode.Imaging.TextSelectionControl textSelectionControl1;
        private System.Windows.Forms.ToolStripMenuItem bringToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burnAnnotationsOnImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveImageWithAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
        private DemosCommonCode.Imaging.FindTextToolStrip findTextToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem findTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mainVisualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewerRenderingSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentMetadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.TabPage commentsTabPage;
        private DemosCommonCode.Annotation.AnnotationCommentsControl annotationCommentsControl1;
        private System.Windows.Forms.ToolStripMenuItem rotateViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateCounterclockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentLayoutSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem docxLayoutSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xlsxLayoutSettingsToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem pageAutoOrientationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerPrintingPageToolStripMenuItem;
    }
}