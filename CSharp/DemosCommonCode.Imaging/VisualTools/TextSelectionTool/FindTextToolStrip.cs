using System;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Tool strip that allows to search text in a document document.
    /// </summary>
    public partial class FindTextToolStrip : ToolStrip
    {

        #region Fields

        /// <summary>
        /// The find text dialog.
        /// </summary>
        FindTextForm _findTextDialog;


        /// <summary>
        /// Text search mode.
        /// </summary>
        TextSearchMode _searchMode = TextSearchMode.AllPages;

        /// <summary>
        /// A value indicating whether that text search must be restarted.
        /// </summary>
        bool _searchFromStart;

        /// <summary>
        /// A value indicating whether the text must be searched from current position in document to the beginning of document/page.
        /// </summary>
        bool _searchUp = false;

        /// <summary>
        /// A value indicating whether the case sensitive search must be made.
        /// </summary>
        bool _matchCase = false;


        /// <summary>
        /// The thread for asynchronous text search.
        /// </summary>
        Thread _asynchronousTextSearchThread = null;

        /// <summary>
        /// A value indicating whether the text searching must be stopped.
        /// </summary>
        bool _stopTextSearch;


        /// <summary>
        /// Previously searched text.
        /// </summary>
        string _previouslySearchedText = null;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FindTextToolStrip"/> class.
        /// </summary>
        public FindTextToolStrip()
            : base()
        {
            InitializeComponent();

            UpdateUIAsync();
        }

        #endregion



        #region Properties

        #region PUBLIC

        TextSelectionTool _textSelectionTool = null;
        /// <summary>
        /// Gets or sets the text selection tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        public TextSelectionTool TextSelectionTool
        {
            get
            {
                return _textSelectionTool;
            }
            set
            {
                if (_textSelectionTool != null)
                {
                    UnsubscribeFromVisualToolEvents(_textSelectionTool);
                    _findTextDialog = null;
                    _isActivated = false;
                    _isTextSearching = false;
                    _isTextSearchDialogShown = false;
                }

                _textSelectionTool = value;

                if (_textSelectionTool != null)
                {
                    SubscribeToVisualToolEvents(_textSelectionTool);
                    _findTextDialog = new FindTextForm(_textSelectionTool);
                    _isActivated = _textSelectionTool.ImageViewer != null;
                }

                UpdateUIAsync();
            }
        }

        bool _isTextSearching = false;
        /// <summary>
        /// Gets a value indicating whether text is searching.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        public bool IsTextSearching
        {
            get
            {
                return _isTextSearching;
            }
        }

        #endregion


        #region PRIVATE

        bool _isActivated = false;
        /// <summary>
        /// Gets or sets a value indicating whether visual tool is activated.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        private bool IsActivated
        {
            get
            {
                return _isActivated;
            }
            set
            {
                _isActivated = value;
                UpdateUIAsync();
            }
        }

        bool _isTextSearchDialogShown = false;
        /// <summary>
        /// Gets or sets a value indicating whether the text search dialog is shown.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        private bool IsTextSearchDialogShown
        {
            get
            {
                return _isTextSearchDialogShown;
            }
            set
            {
                _isTextSearchDialogShown = value;
                UpdateUIAsync();
            }
        }

        #endregion

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the KeyDown event of FastFindToolStripComboBox object.
        /// </summary>
        private void fastFindToolStripComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            // if text search must be started
            if (e.KeyCode == Keys.Enter)
                FastFind();
        }

        /// <summary>
        /// Handles the Click event of FastFindNextToolStripButton object.
        /// </summary>
        private void fastFindNextToolStripButton_Click(object sender, EventArgs e)
        {
            // find the text
            FastFind();
        }

        /// <summary>
        /// Handles the Click event of StopFastFindToolStripButton object.
        /// </summary>
        private void stopFastFindToolStripButton_Click(object sender, EventArgs e)
        {
            // stop text search
            _stopTextSearch = true;
        }

        #endregion


        #region UI state

        /// <summary>
        /// Update UI safely.
        /// </summary>
        private void UpdateUIAsync()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isEnabled = Enabled && IsActivated && TextSelectionTool != null && TextSelectionTool.FocusedImageHasTextRegion;
            bool isFindText = IsTextSearching;
            bool isFindDialogShow = IsTextSearchDialogShown;

            findTextToolStripButton.Enabled = isEnabled && !isFindText && !isFindDialogShow;
            fastFindToolStripComboBox.Enabled = isEnabled && !isFindText && !isFindDialogShow;
            fastFindNextToolStripButton.Enabled = isEnabled && !isFindDialogShow;
            fastFindNextToolStripButton.Visible = !isFindText;
            stopFastFindToolStripButton.Enabled = isEnabled && !isFindDialogShow;
            stopFastFindToolStripButton.Visible = isFindText;
        }

        /// <summary>
        /// The Enabled property is changed.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            UpdateUIAsync();
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Subscribes to the image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
        }

        /// <summary>
        /// Unsubscribes from the image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= imageViewer_FocusedIndexChanged;
        }

        /// <summary>
        /// Focused image is changed in image viewer.
        /// </summary>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            UpdateUI();
        }

        #endregion


        #region Text selection tool

        /// <summary>
        /// Subscribes to the visual tool events.
        /// </summary>
        /// <param name="textSelectionTool">The text selection tool.</param>
        private void SubscribeToVisualToolEvents(TextSelectionTool textSelectionTool)
        {
            textSelectionTool.Activated += new EventHandler(textSelectionTool_Activated);
            textSelectionTool.Deactivated += new EventHandler(textSelectionTool_Deactivated);
            textSelectionTool.TextSearchingProgress +=
                new EventHandler<TextSearchingProgressEventArgs>(textSelectionTool_TextSearchingProgress);
            textSelectionTool.TextSearched += new EventHandler<TextSearchedEventArgs>(textSelectionTool_TextSearched);

            if (textSelectionTool.ImageViewer != null)
                SubscribeToImageViewerEvents(textSelectionTool.ImageViewer);
        }

        /// <summary>
        /// Unsubscribes from the visual tool events.
        /// </summary>
        /// <param name="textSelectionTool">The text selection tool.</param>
        private void UnsubscribeFromVisualToolEvents(TextSelectionTool textSelectionTool)
        {
            textSelectionTool.Activated -= textSelectionTool_Activated;
            textSelectionTool.Deactivated -= textSelectionTool_Deactivated;
            textSelectionTool.TextSearchingProgress -= textSelectionTool_TextSearchingProgress;
            textSelectionTool.TextSearched -= textSelectionTool_TextSearched;

            if (textSelectionTool.ImageViewer != null)
                UnsubscribeFromImageViewerEvents(textSelectionTool.ImageViewer);
        }

        /// <summary>
        /// Text selection tool is activated.
        /// </summary>
        private void textSelectionTool_Activated(object sender, EventArgs e)
        {
            IsActivated = true;
            SubscribeToImageViewerEvents(((TextSelectionTool)sender).ImageViewer);
        }

        /// <summary>
        /// Text selection tool is deactivated.
        /// </summary>
        private void textSelectionTool_Deactivated(object sender, EventArgs e)
        {
            if (_asynchronousTextSearchThread != null)
            {
                _stopTextSearch = true;
                _isTextSearching = false;
                _isTextSearchDialogShown = false;
                _asynchronousTextSearchThread = null;
            }

            IsActivated = false;
            UnsubscribeFromImageViewerEvents(((TextSelectionTool)sender).ImageViewer);
        }

        /// <summary>
        /// Progress of text searching is changed.
        /// </summary>
        private void textSelectionTool_TextSearchingProgress(object sender, TextSearchingProgressEventArgs e)
        {
            if (TextSelectionTool.ImageViewer == null || IsTextSearching && !e.Cancel && _stopTextSearch)
                // stop search
                e.Cancel = true;
        }

        /// <summary>
        /// Text is searched.
        /// </summary>
        private void textSelectionTool_TextSearched(object sender, TextSearchedEventArgs e)
        {
            if (IsTextSearching)
            {
                if (e.FoundTextRegion == null)
                {
                    // text was not found
                    if (!e.Canceled)
                        MessageBox.Show(string.Format("The following specified text was not found: {0}", e.SearchEngine), "Find text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    FindTextForm.SelectSearchedText((TextSelectionTool)sender, e);
                }

                OnTextSearchingStarted(false);
                fastFindToolStripComboBox.Focus();
            }
        }

        #endregion


        /// <summary>
        /// Handles the Click event of FindTextToolStripButton object.
        /// </summary>
        private void findTextToolStripButton_Click(object sender, EventArgs e)
        {
            // if text is selected
            if (_textSelectionTool.HasSelectedText)
                // update searched text
                _findTextDialog.FindWhat = _textSelectionTool.SelectedText;

            IsTextSearchDialogShown = true;
            // show dialog
            _findTextDialog.ShowDialog();


            // update search properties

            _matchCase = _findTextDialog.MatchCase;
            _searchMode = _findTextDialog.SearchMode;
            _searchUp = _findTextDialog.SearchUp;

            IsTextSearchDialogShown = false;
        }

        /// <summary>
        /// Runs the text search asynchronously.
        /// </summary>
        private void FastFind()
        {
            OnTextSearchingStarted(true);

            // get a search text
            string text = fastFindToolStripComboBox.Text;
            if (text == "")
            {
                OnTextSearchingStarted(false);
                return;
            }

            // add text to fastFindToolStripComboBox
            if (fastFindToolStripComboBox.Items.Contains(text))
                fastFindToolStripComboBox.Items.Remove(text);
            fastFindToolStripComboBox.Items.Insert(0, text);

            _searchFromStart = text != _previouslySearchedText;
            _previouslySearchedText = text;
            _stopTextSearch = false;

            _asynchronousTextSearchThread = new Thread(new ThreadStart(AsynchronousTextSearchThread));
            _asynchronousTextSearchThread.IsBackground = true;
            _asynchronousTextSearchThread.Start();
        }

        /// <summary>
        /// Text searching is started.
        /// </summary>
        private void OnTextSearchingStarted(bool value)
        {
            _isTextSearching = value;
            UpdateUIAsync();
        }

        /// <summary>
        /// Searches text in the background thread.
        /// </summary>
        private void AsynchronousTextSearchThread()
        {
            TextSearchEngine finder = TextSearchEngine.Create(_previouslySearchedText, !_matchCase);

            // search text
            _textSelectionTool.FindText(finder, _searchMode, _searchUp, _searchFromStart);

            _asynchronousTextSearchThread = null;
            _stopTextSearch = false;
        }

        #endregion



        #region Delegates

        /// <summary>
        /// Delegate for updating the user interface.
        /// </summary>
        private delegate void UpdateUIDelegate();

        #endregion

    }
}
