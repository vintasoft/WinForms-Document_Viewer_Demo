using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to select text on document page and extract text from document page.
    /// </summary>
    public partial class TextSelectionControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSelectionControl"/> class.
        /// </summary>
        public TextSelectionControl()
        {
            InitializeComponent();

            selectionModeFullLinesRadioButton.Tag = TextSelectionMode.UseFullLines;
            selectionModeRectangleRadioButton.Tag = TextSelectionMode.Rectangle;

            formattingModeParagraphsRadioButton.Tag = new TextRegionParagraphFormatter();
            formattingModeLinesRadioButton.Tag = new TextRegionLinesFormatter();
            formattingModeMonospaceRadioButton.Tag = new TextRegionMonospaceFormatter();
        }

        #endregion



        #region Properties

        TextSelectionTool _textSelectionTool = null;
        /// <summary>
        /// Gets or sets the text selection tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public TextSelectionTool TextSelectionTool
        {
            get
            {
                return _textSelectionTool;
            }
            set
            {
                if (_textSelectionTool != value)
                {
                    // if tool is NOT changed
                    if (_textSelectionTool == value)
                        return;

                    // if old tool exists
                    if (_textSelectionTool != null)
                        // unsubscribe from the tool events
                        UnsubscribeFromVisualToolEvents(_textSelectionTool);

                    // save reference to the new tool
                    _textSelectionTool = value;

                    // if new tool exists
                    if (_textSelectionTool != null)
                    {
                        // set default text formatter
                        _textSelectionTool.TextFormatter = (TextRegionFormatter)formattingModeParagraphsRadioButton.Tag;

                        // update the selection mode radio buttons
                        UpdateSelectionModeRadioButtons(_textSelectionTool.SelectionMode);

                        // update the formatting mode radio buttons
                        UpdateFormattingModeRadioButtons(_textSelectionTool.TextFormatter);

                        // subscribe to the tool events
                        SubscribeToVisualToolEvents(_textSelectionTool);
                    }

                    UpdateUI();
                }
            }
        }

        Color _higlhightColor = Color.FromArgb(255, 255, 0);
        /// <summary>
        /// Gets or sets the color that is used for highlighting the text.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HighlightColor
        {
            get
            {
                return _higlhightColor;
            }
            set
            {
                _higlhightColor = value;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of selectionModeRadioButton object.
        /// </summary>
        private void selectionModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool == null)
                return;

            // get selected selection mode

            RadioButton radioButton = (RadioButton)sender;
            TextSelectionMode selectionMode = (TextSelectionMode)radioButton.Tag;

            // if selection mode is changed
            if (_textSelectionTool.SelectionMode != selectionMode)
                // update selection mode
                _textSelectionTool.SelectionMode = selectionMode;
        }

        /// <summary>
        /// Handles the CheckedChanged event of formattingModeRadioButton object.
        /// </summary>
        private void formattingModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool == null)
                return;

            // get selected formatting mode

            RadioButton radioButton = (RadioButton)sender;
            TextRegionFormatter formatter = (TextRegionFormatter)radioButton.Tag;

            // if formatting mode must be change
            if (_textSelectionTool.TextFormatter != formatter)
                // update formatting mode
                _textSelectionTool.TextFormatter = formatter;
        }

        /// <summary>
        /// Handles the Opening event of TextSelectionContextMenuStrip object.
        /// </summary>
        private void TextSelectionContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // if text selection has selected text
            if (_textSelectionTool.HasSelectedText)
                copyToolStripMenuItem.Enabled = true;
            else
                copyToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of copyToolStripMenuItem object.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // copy selected text to the clipboard
            Copy();
        }

        /// <summary>
        /// Handles the Click event of selectAllToolStripMenuItem object.
        /// </summary>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // select all text
            SelectAll();
        }

        /// <summary>
        /// Handles the Click event of saveAsTextButton object.
        /// </summary>
        private void saveAsTextButton_Click(object sender, EventArgs e)
        {
            // if text must be saved to file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // get file name
                string fileName = saveFileDialog.FileName;
                // get selected text
                string text = _textSelectionTool.SelectedText;
                // save text to file
                System.IO.File.WriteAllText(fileName, text);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of mouseSelectionCheckBox object.
        /// </summary>
        private void mouseSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool != null)
            {
                // if mouse selection is enabled
                if (mouseSelectionCheckBox.Checked)
                    _textSelectionTool.IsMouseSelectionEnabled = true;
                else
                    _textSelectionTool.IsMouseSelectionEnabled = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of keyboardSelectionCheckBox object.
        /// </summary>
        private void keyboardSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool != null)
            {
                // if keyboard selection is enabled
                if (keyboardSelectionCheckBox.Checked)
                    _textSelectionTool.IsKeyboardSelectionEnabled = true;
                else
                    _textSelectionTool.IsKeyboardSelectionEnabled = false;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of caretWidthNumericUpDown object.
        /// </summary>
        private void caretWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool != null)
                // update caret width
                _textSelectionTool.TextCaretWidth = (int)caretWidthNumericUpDown.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of caretBlinkingIntervalNumericUpDown object.
        /// </summary>
        private void caretBlinkingIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool != null)
                // update caret blink interval
                _textSelectionTool.TextCaretBlinkingInterval = (int)caretBlinkingIntervalNumericUpDown.Value;
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            mainPanel.Enabled =
                _textSelectionTool != null &&
                _textSelectionTool.ImageViewer != null &&
                _textSelectionTool.ImageViewer.Image != null &&
                _textSelectionTool.FocusedImageHasTextRegion;

            if (mainPanel.Enabled)
            {
                saveAsTextButton.Enabled = _textSelectionTool.HasSelectedText;
            }

            if (_textSelectionTool != null)
            {
                mouseSelectionCheckBox.Checked = _textSelectionTool.IsMouseSelectionEnabled;
                keyboardSelectionCheckBox.Checked = _textSelectionTool.IsKeyboardSelectionEnabled;
                caretWidthNumericUpDown.Value = _textSelectionTool.TextCaretWidth;
                caretBlinkingIntervalNumericUpDown.Value = _textSelectionTool.TextCaretBlinkingInterval;
            }
        }

        /// <summary>
        /// TextSelectionTool is activated.
        /// </summary>
        private void selectionTool_Activated(object sender, EventArgs e)
        {
            VisualTool tool = (VisualTool)sender;
            SubscribeToImageViewerEvents(tool.ImageViewer);
            UpdateUI();
        }

        /// <summary>
        /// TextSelectionTool is deactivated.
        /// </summary>
        private void selectionTool_Deactivated(object sender, EventArgs e)
        {
            VisualTool tool = (VisualTool)sender;
            UnsubscribeFromImageViewerEvents(tool.ImageViewer);
            mainPanel.Enabled = false;
        }

        /// <summary>
        /// Text selection in TextSelectionTool is changed.
        /// </summary>
        private void selectionTool_SelectionChanged(object sender, EventArgs e)
        {
            if (_textSelectionTool.SelectedRegion != null)
                textExtractionTextBox.Text = _textSelectionTool.SelectedRegion.TextContent;
            else
                textExtractionTextBox.Text = "";

            UpdateUI();
        }

        /// <summary>
        /// Mouse is down.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolMouseEventArgs"/> instance containing the event data.</param>
        private void selectionTool_MouseUp(object sender, VisualToolMouseEventArgs e)
        {
            if (Enabled && mainPanel.Enabled)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ImageViewer imageViewer = _textSelectionTool.ImageViewer;
                    if (imageViewer != null)
                    {
                        // show context menu
                        TextSelectionContextMenuStrip.Show(imageViewer, new Point(e.X, e.Y));
                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Selection mode is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{TextSelectionMode}"/> instance containing the event data.</param>
        private void selectionTool_SelectionModeChanged(
            object sender,
            PropertyChangedEventArgs<TextSelectionMode> e)
        {
            // update the selection mode radio buttons
            UpdateSelectionModeRadioButtons(e.NewValue);
        }

        /// <summary>
        /// Text formatter is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{TextRegionFormatter}"/> instance containing the event data.</param>
        private void selectionTool_TextFormatterChanged(
            object sender,
            PropertyChangedEventArgs<TextRegionFormatter> e)
        {
            // update the formatting mode radio buttons
            UpdateFormattingModeRadioButtons(e.NewValue);
        }

        /// <summary>
        /// Focused image in image viewer is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            UpdateUI();

            if (_textSelectionTool.SelectedRegion != null)
                textExtractionTextBox.Text = _textSelectionTool.SelectedRegion.TextContent;
            else
                textExtractionTextBox.Text = "";
        }


        /// <summary>
        /// Copies all selected text to the clipboard.
        /// </summary>
        private void Copy()
        {
            string text = string.Empty;

            // if selected region exists
            if (_textSelectionTool.HasSelectedText)
                text = _textSelectionTool.SelectedText;

            // copy text to clipboard
            Clipboard.SetText(text, TextDataFormat.UnicodeText);
        }

        /// <summary>
        /// Selects all text on current page.
        /// </summary>
        private void SelectAll()
        {
            _textSelectionTool.SelectAll();
        }

        /// <summary>
        /// Subscribes to the events of TextSelectionTool.
        /// </summary>
        /// <param name="selectionTool">The selection tool.</param>
        private void SubscribeToVisualToolEvents(TextSelectionTool selectionTool)
        {
            selectionTool.SelectionChanged += new EventHandler(selectionTool_SelectionChanged);
            selectionTool.Activated += new EventHandler(selectionTool_Activated);
            selectionTool.Deactivated += new EventHandler(selectionTool_Deactivated);
            selectionTool.MouseUp += new VisualToolMouseEventHandler(selectionTool_MouseUp);
            selectionTool.SelectionModeChanged += new PropertyChangedEventHandler<TextSelectionMode>(selectionTool_SelectionModeChanged);
            selectionTool.TextFormatterChanged += new PropertyChangedEventHandler<TextRegionFormatter>(selectionTool_TextFormatterChanged);
            selectionTool.FocusedTextSymbolChanged += new PropertyChangedEventHandler<TextRegionSymbol>(SelectionTool_FocusedTextSymbolChanged);

            if (selectionTool.ImageViewer != null)
                SubscribeToImageViewerEvents(selectionTool.ImageViewer);
        }

        /// <summary>
        /// Unsubscribes from the events of TextSelectionTool.
        /// </summary>
        /// <param name="selectionTool">The selection tool.</param>
        private void UnsubscribeFromVisualToolEvents(TextSelectionTool selectionTool)
        {
            selectionTool.SelectionChanged -= selectionTool_SelectionChanged;
            selectionTool.Activated -= selectionTool_Activated;
            selectionTool.Deactivated -= selectionTool_Deactivated;
            selectionTool.MouseUp -= selectionTool_MouseUp;
            selectionTool.SelectionModeChanged -= selectionTool_SelectionModeChanged;
            selectionTool.TextFormatterChanged -= selectionTool_TextFormatterChanged;
            selectionTool.FocusedTextSymbolChanged -= SelectionTool_FocusedTextSymbolChanged;

            if (selectionTool.ImageViewer != null)
                UnsubscribeFromImageViewerEvents(selectionTool.ImageViewer);
        }

        /// <summary>
        /// Subscribes to the events of ImageViewer.
        /// </summary>
        /// <param name="viewer">The viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer viewer)
        {
            viewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);
        }

        /// <summary>
        /// Unsubscribes from the events of ImageViewer.
        /// </summary>
        /// <param name="viewer">The viewer.</param>
        private void UnsubscribeFromImageViewerEvents(ImageViewer viewer)
        {
            viewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
        }

        /// <summary>
        /// Updates the selection mode radio buttons.
        /// </summary>
        /// <param name="selectionMode">The selection mode.</param>
        private void UpdateSelectionModeRadioButtons(TextSelectionMode selectionMode)
        {
            if (selectionMode == TextSelectionMode.Rectangle)
                selectionModeRectangleRadioButton.Checked = true;
            else if (selectionMode == TextSelectionMode.UseFullLines)
                selectionModeFullLinesRadioButton.Checked = true;
        }


        /// <summary>
        /// Updates the formatting mode radio buttons.
        /// </summary>
        /// <param name="formatter">The formatter.</param>
        private void UpdateFormattingModeRadioButtons(TextRegionFormatter formatter)
        {
            if (formatter == formattingModeParagraphsRadioButton.Tag)
                formattingModeParagraphsRadioButton.Checked = true;
            else if (formatter == formattingModeLinesRadioButton.Tag)
                formattingModeLinesRadioButton.Checked = true;
            else if (formatter == formattingModeMonospaceRadioButton.Tag)
                formattingModeMonospaceRadioButton.Checked = true;
        }

        /// <summary>
        /// Focused text symbol is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{TextRegionSymbol}"/> instance containing the event data.</param>
        private void SelectionTool_FocusedTextSymbolChanged(object sender, PropertyChangedEventArgs<TextRegionSymbol> e)
        {
            if (Enabled)
                ShowSymbolInfo(e.NewValue);
        }

        /// <summary>
        /// Shows the symbol information.
        /// </summary>
        /// <param name="symbol">Text region symbol.</param>
        private void ShowSymbolInfo(TextRegionSymbol symbol)
        {
            // if text region symbol exists
            if (symbol != null && TextSelectionTool.ImageViewer != null)
            {
                // update info about symbol
                TextRegion textRegion = _textSelectionTool.FocusedTextRegion;
                VintasoftImage image = TextSelectionTool.ImageViewer.Image;
                AffineMatrix textSpaceToImageTransform = textRegion.GetTransformFromTextToImageSpace(image.Resolution);
                PointF locationInImageSpace = PointFAffineTransform.TransformPoint(textSpaceToImageTransform, symbol.Location);
                imageLocationLabel.Text = locationInImageSpace.ToString();
                pageLocationLabel.Text = symbol.Location.ToString();
                symbolLabel.Text = symbol.TextSymbol.Symbols;
                string symbolCode = "";
                foreach (string unicodeCharacter in new UnicodeCharacterCollection(symbol.TextSymbol.Symbols))
                {
                    int unicodeCharacterValue;

                    if (UnicodeCharacterCollection.IsUtf32Symbol(unicodeCharacter, 0))
                        unicodeCharacterValue = char.ConvertToUtf32(unicodeCharacter, 0);
                    else
                        unicodeCharacterValue = (int)unicodeCharacter[0];

                    symbolCode += string.Format("0x{0:X4} ", unicodeCharacterValue);
                }
                symbolCodeLabel.Text = symbolCode;
                contentCodeLabel.Text = symbol.TextSymbol.ContentSymbolCode.ToString();
                RegionF region = symbol.SelectionRegion;
                symbolRectLabel.Text = string.Format("({0}; {1}) - ({2}; {3})",
                    region.LeftTop.X,
                    region.LeftTop.Y,
                    region.RightBottom.X,
                    region.RightBottom.Y);

                fontLabel.Text = FontDemosTools.GetFontInfo(symbol.TextSymbol.Font);

                fontSizeLabel.Text = string.Format("{0} pt", textRegion.GetFontSizeInPoints(symbol));

                symbolColorPanelControl.Color = symbol.Color;

                renderingModeLabel.Text = symbol.RenderingMode.ToString();
            }
            // if text region symbol does NOT exist
            else
            {
                // clear info about symbol
                imageLocationLabel.Text = "";
                pageLocationLabel.Text = "";
                contentCodeLabel.Text = "";
                renderingModeLabel.Text = "";
                symbolLabel.Text = "";
                symbolCodeLabel.Text = "";
                symbolRectLabel.Text = "";
                fontLabel.Text = "";
                fontSizeLabel.Text = "";
                symbolColorPanelControl.Color = Color.Transparent;
            }
        }

        #endregion

    }
}
