using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to set settings for text search.
    /// </summary>
    public partial class FindTextForm : Form
    {

        #region Fields

        /// <summary>
        /// The location of the form.
        /// </summary>
        Point _formLocation = Point.Empty;

        /// <summary>
        /// The visual tool that allows to search and select text on document page.
        /// </summary>
        TextSelectionTool _viewerTool;

        /// <summary>
        /// A value indicating whether the find text dialog is shown.
        /// </summary>
        bool _isFindDialogShown = false;

        /// <summary>
        /// The text, which must be searched.
        /// </summary>
        string _searchingText;

        /// <summary>
        /// The text search mode of the text selection tool.
        /// </summary>
        TextSearchMode _textSearchMode;

        /// <summary>
        /// Determines whether text searching must be started from the beginning of document.
        /// </summary>
        bool _searchFromStart = true;

        /// <summary>
        /// A value indicating whether text searching must be stoped.
        /// </summary>
        bool _stopSearch = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FindTextForm"/> class.
        /// </summary>
        /// <param name="viewerTool">The text selection tool.</param>
        public FindTextForm(TextSelectionTool viewerTool)
        {
            InitializeComponent();

            // init text selection tool
            _viewerTool = viewerTool;
            _viewerTool.TextSearchingProgress += new EventHandler<TextSearchingProgressEventArgs>(viewerTool_FindTextAtPage);
            _viewerTool.TextSearched += new EventHandler<TextSearchedEventArgs>(viewerTool_TextSearched);
            lookInComboBox.SelectedIndex = 1;

            matchCaseCheckBox.Checked = false;
            searchUpCheckBox.Checked = _searchUp;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a text to find.
        /// </summary>
        public string FindWhat
        {
            get
            {
                return findWhatComboBox.Text;
            }
            set
            {
                if (value.Contains(Environment.NewLine))
                    value = value.Substring(0, value.IndexOf(Environment.NewLine));
                findWhatComboBox.Text = value;
            }
        }

        bool _searchUp;
        /// <summary>
        /// Gets a value indicating whether the text must be searched from the current point
        /// to the top of the page/document.
        /// </summary>
        public bool SearchUp
        {
            get
            {
                return _searchUp;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the case sensitive search must be made.
        /// </summary>
        public bool MatchCase
        {
            get
            {
                return matchCaseCheckBox.Checked;
            }
        }

        /// <summary>
        /// Gets the selected text search mode.
        /// </summary>
        public TextSearchMode SearchMode
        {
            get
            {
                return (TextSearchMode)lookInComboBox.SelectedIndex;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Shown event of FindTextDialog object.
        /// </summary>
        private void FindTextDialog_Shown(object sender, EventArgs e)
        {
            _isFindDialogShown = true;
            _searchFromStart = true;

            // if form location is not empty
            if (!_formLocation.IsEmpty)
            {
                // set form location
                Location = _formLocation;
            }
        }

        /// <summary>
        /// Handles the FormClosing event of FindTextDialog object.
        /// </summary>
        private void FindTextDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFindDialogShown = false;

            // get form location
            _formLocation = Location;
        }

        /// <summary>
        /// Handles the TextChanged event of findWhatComboBox object.
        /// </summary>
        private void findWhatComboBox_TextChanged(object sender, EventArgs e)
        {
            // if text can be search
            if (findWhatComboBox.Text != "")
                findNextButton.Enabled = true;
            else
                findNextButton.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of findNextButton object.
        /// </summary>
        private void findNextButton_Click(object sender, EventArgs e)
        {
            // if image in image viewer is empty
            if (_viewerTool.ImageViewer.Image == null)
                return;

            // get searching text
            string text = findWhatComboBox.Text;

            // if regular expression must be used
            if (regexCheckBox.Checked)
            {
                // check regular expression
                try
                {
                    CreateRegex(text, MatchCase);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    return;
                }
            }

            // get value which indicates that the text must be searched 
            // from current point to the top of the page
            _searchUp = searchUpCheckBox.Checked;

            if (findWhatComboBox.Items.Contains(text))
                findWhatComboBox.Items.Remove(text);
            findWhatComboBox.Items.Insert(0, text);

            // get text search mode
            TextSearchMode findMode = SearchMode;
            // if text search mode is all pages
            if (findMode == TextSearchMode.AllPages)
                SetSearchInProgress(true);
            _stopSearch = false;

            _searchingText = text;
            _textSearchMode = findMode;

            // begin search async
            ThreadPool.QueueUserWorkItem(new WaitCallback(FindNextAsync));
        }

        /// <summary>
        /// Handles the Click event of stopButton object.
        /// </summary>
        private void stopButton_Click(object sender, EventArgs e)
        {
            // stop search
            _stopSearch = true;
        }

        /// <summary>
        /// Handles the KeyDown event of FindTextDialog object.
        /// </summary>
        private void FindTextDialog_KeyDown(object sender, KeyEventArgs e)
        {
            // if dialog must be canceled
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of searchUpCheckBox object.
        /// </summary>
        private void searchUpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if search should be up
            if (searchUpCheckBox.Checked)
                _searchUp = true;
            else
                _searchUp = false;
        }

        #endregion


        /// <summary>
        /// Selects searched text.
        /// </summary>
        /// <param name="tool">The text selection tool.</param>
        /// <param name="args">The text searched event args.</param>
        public static void SelectSearchedText(TextSelectionTool tool, TextSearchedEventArgs args)
        {
            // set image where text is found
            tool.ImageViewer.SetFocusedIndexSync(args.ImageIndex);

            // select the region of searched text
            tool.SelectedRegion = args.FoundTextRegion;

            // scroll to the searched text
            tool.ScrollToSelectedRegion();
        }

        /// <summary>
        /// Creates the regular expression.
        /// </summary>
        /// <param name="text">The pattern of regular expression.</param>
        /// <param name="matchCase">Indicates whether the case sensitive search must be made.</param>
        private Regex CreateRegex(string text, bool matchCase)
        {
            // get regular expression
            RegexOptions options = RegexOptions.None;
            if (!matchCase)
                options |= RegexOptions.IgnoreCase;
            // create text search engine
            return new Regex(text, options);
        }

        /// <summary>
        /// Starts the asynchronous search of the next occurrence of the text.
        /// </summary>
        /// <param name="state">The state.</param>
        private void FindNextAsync(object state)
        {
            TextSearchEngine finder;
            // if regular expression must be used
            if (regexCheckBox.Checked)
            {
                // create text search engine using regular expression
                finder = TextSearchEngine.Create(CreateRegex(_searchingText, MatchCase));
            }
            else
            {
                // create text search engine
                finder = TextSearchEngine.Create(_searchingText, !MatchCase);
            }

            // search text
            _viewerTool.FindText(finder, _textSearchMode, _searchUp, _searchFromStart);

            _searchFromStart = false;

            if (_textSearchMode == TextSearchMode.AllPages)
                SetSearchInProgress(false);
        }

        /// <summary>
        /// Text searching is in progress.
        /// </summary>
        private void viewerTool_FindTextAtPage(object sender, TextSearchingProgressEventArgs e)
        {
            // if text searching must be stoped
            if (_stopSearch)
                e.Cancel = true;
        }

        /// <summary>
        /// Text searching is finished.
        /// </summary>
        private void viewerTool_TextSearched(object sender, TextSearchedEventArgs e)
        {
            // if form is shown
            if (_isFindDialogShown)
            {
                // if text is not found
                if (e.FoundTextRegion == null)
                {
                    // if text searching is not canceled
                    if (!e.Canceled)
                    {
                        MessageBox.Show(string.Format("The following specified text was not found: {0}", e.SearchEngine),
                            "Find text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // if text is found
                else
                {
                    // select searched text
                    SelectSearchedText((TextSelectionTool)sender, e);
                }
            }
        }

        /// <summary>
        /// Updates user interface of the form.
        /// </summary>
        /// <param name="isSearchInProgress">Determines whether search is in progress.</param>
        private void SetSearchInProgress(bool isSearchInProgress)
        {
            if (!InvokeRequired)
            {
                findWhatComboBox.Enabled = !isSearchInProgress;
                lookInComboBox.Enabled = !isSearchInProgress;
                findOptionsGroupBox.Enabled = !isSearchInProgress;
                findNextButton.Visible = !isSearchInProgress;
                stopButton.Visible = isSearchInProgress;
            }
            else
            {
                Invoke(new SetSearchInProgressDelegate(SetSearchInProgress), isSearchInProgress);
            }
        }

        #endregion



        #region Delegates

        /// <summary>
        /// Represents the method that updates user interface of the form.
        /// </summary>
        /// <param name="isSearchInProgress">Determines whether search in progress.</param>
        delegate void SetSearchInProgressDelegate(bool isSearchInProgress);

        #endregion

    }
}
