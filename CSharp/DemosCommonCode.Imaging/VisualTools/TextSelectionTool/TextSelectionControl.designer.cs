namespace DemosCommonCode.Imaging
{
    partial class TextSelectionControl
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
            TextSelectionTool = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectionModeFullLinesRadioButton = new System.Windows.Forms.RadioButton();
            this.selectionModeRectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textExtractionTextBox = new System.Windows.Forms.TextBox();
            this.saveAsTextButton = new System.Windows.Forms.Button();
            this.cursorGroupBox = new System.Windows.Forms.GroupBox();
            this.contentCodeLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.renderingModeLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.symbolColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.symbolRectLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.fontLabel = new System.Windows.Forms.Label();
            this.symbolCodeLabel = new System.Windows.Forms.Label();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.pageLocationLabel = new System.Windows.Forms.Label();
            this.imageLocationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.caretBlinkingIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.caretWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.keyboardSelectionCheckBox = new System.Windows.Forms.CheckBox();
            this.mouseSelectionCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.formattingModeMonospaceRadioButton = new System.Windows.Forms.RadioButton();
            this.formattingModeLinesRadioButton = new System.Windows.Forms.RadioButton();
            this.formattingModeParagraphsRadioButton = new System.Windows.Forms.RadioButton();
            this.TextSelectionContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cursorGroupBox.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caretBlinkingIntervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caretWidthNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.TextSelectionContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.selectionModeFullLinesRadioButton);
            this.groupBox1.Controls.Add(this.selectionModeRectangleRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(4, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Mode";
            // 
            // selectionModeFullLinesRadioButton
            // 
            this.selectionModeFullLinesRadioButton.AutoSize = true;
            this.selectionModeFullLinesRadioButton.Location = new System.Drawing.Point(87, 18);
            this.selectionModeFullLinesRadioButton.Name = "selectionModeFullLinesRadioButton";
            this.selectionModeFullLinesRadioButton.Size = new System.Drawing.Size(74, 19);
            this.selectionModeFullLinesRadioButton.TabIndex = 1;
            this.selectionModeFullLinesRadioButton.Text = "Full Lines";
            this.selectionModeFullLinesRadioButton.UseVisualStyleBackColor = true;
            this.selectionModeFullLinesRadioButton.CheckedChanged += new System.EventHandler(this.selectionModeRadioButton_CheckedChanged);
            // 
            // selectionModeRectangleRadioButton
            // 
            this.selectionModeRectangleRadioButton.AutoSize = true;
            this.selectionModeRectangleRadioButton.Checked = true;
            this.selectionModeRectangleRadioButton.Location = new System.Drawing.Point(6, 19);
            this.selectionModeRectangleRadioButton.Name = "selectionModeRectangleRadioButton";
            this.selectionModeRectangleRadioButton.Size = new System.Drawing.Size(77, 19);
            this.selectionModeRectangleRadioButton.TabIndex = 0;
            this.selectionModeRectangleRadioButton.TabStop = true;
            this.selectionModeRectangleRadioButton.Text = "Rectangle";
            this.selectionModeRectangleRadioButton.UseVisualStyleBackColor = true;
            this.selectionModeRectangleRadioButton.CheckedChanged += new System.EventHandler(this.selectionModeRadioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textExtractionTextBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 104);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Text on Focused Page";
            // 
            // textExtractionTextBox
            // 
            this.textExtractionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExtractionTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textExtractionTextBox.Location = new System.Drawing.Point(6, 19);
            this.textExtractionTextBox.Multiline = true;
            this.textExtractionTextBox.Name = "textExtractionTextBox";
            this.textExtractionTextBox.ReadOnly = true;
            this.textExtractionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textExtractionTextBox.Size = new System.Drawing.Size(238, 79);
            this.textExtractionTextBox.TabIndex = 0;
            this.textExtractionTextBox.WordWrap = false;
            // 
            // saveAsTextButton
            // 
            this.saveAsTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsTextButton.Enabled = false;
            this.saveAsTextButton.Location = new System.Drawing.Point(4, 416);
            this.saveAsTextButton.Name = "saveAsTextButton";
            this.saveAsTextButton.Size = new System.Drawing.Size(249, 23);
            this.saveAsTextButton.TabIndex = 1;
            this.saveAsTextButton.Text = "Save All Selected Text As...";
            this.saveAsTextButton.UseVisualStyleBackColor = true;
            this.saveAsTextButton.Click += new System.EventHandler(this.saveAsTextButton_Click);
            // 
            // cursorGroupBox
            // 
            this.cursorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorGroupBox.Controls.Add(this.contentCodeLabel);
            this.cursorGroupBox.Controls.Add(this.label11);
            this.cursorGroupBox.Controls.Add(this.renderingModeLabel);
            this.cursorGroupBox.Controls.Add(this.label10);
            this.cursorGroupBox.Controls.Add(this.symbolColorPanelControl);
            this.cursorGroupBox.Controls.Add(this.symbolRectLabel);
            this.cursorGroupBox.Controls.Add(this.label9);
            this.cursorGroupBox.Controls.Add(this.label7);
            this.cursorGroupBox.Controls.Add(this.fontSizeLabel);
            this.cursorGroupBox.Controls.Add(this.fontLabel);
            this.cursorGroupBox.Controls.Add(this.symbolCodeLabel);
            this.cursorGroupBox.Controls.Add(this.symbolLabel);
            this.cursorGroupBox.Controls.Add(this.pageLocationLabel);
            this.cursorGroupBox.Controls.Add(this.imageLocationLabel);
            this.cursorGroupBox.Controls.Add(this.label6);
            this.cursorGroupBox.Controls.Add(this.label5);
            this.cursorGroupBox.Controls.Add(this.label4);
            this.cursorGroupBox.Controls.Add(this.label3);
            this.cursorGroupBox.Controls.Add(this.label2);
            this.cursorGroupBox.Controls.Add(this.label1);
            this.cursorGroupBox.Location = new System.Drawing.Point(3, 183);
            this.cursorGroupBox.Name = "cursorGroupBox";
            this.cursorGroupBox.Size = new System.Drawing.Size(250, 229);
            this.cursorGroupBox.TabIndex = 2;
            this.cursorGroupBox.TabStop = false;
            this.cursorGroupBox.Text = "Focused Text Symbol";
            // 
            // contentCodeLabel
            // 
            this.contentCodeLabel.AutoSize = true;
            this.contentCodeLabel.Location = new System.Drawing.Point(94, 97);
            this.contentCodeLabel.Name = "contentCodeLabel";
            this.contentCodeLabel.Size = new System.Drawing.Size(12, 15);
            this.contentCodeLabel.TabIndex = 19;
            this.contentCodeLabel.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Content Code:";
            // 
            // renderingModeLabel
            // 
            this.renderingModeLabel.AutoSize = true;
            this.renderingModeLabel.Location = new System.Drawing.Point(106, 175);
            this.renderingModeLabel.Name = "renderingModeLabel";
            this.renderingModeLabel.Size = new System.Drawing.Size(12, 15);
            this.renderingModeLabel.TabIndex = 17;
            this.renderingModeLabel.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Rendering Mode:";
            // 
            // symbolColorPanelControl
            // 
            this.symbolColorPanelControl.CanSetColor = false;
            this.symbolColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.symbolColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.symbolColorPanelControl.Location = new System.Drawing.Point(97, 194);
            this.symbolColorPanelControl.Name = "symbolColorPanelControl";
            this.symbolColorPanelControl.Size = new System.Drawing.Size(74, 22);
            this.symbolColorPanelControl.TabIndex = 3;
            // 
            // symbolRectLabel
            // 
            this.symbolRectLabel.AutoSize = true;
            this.symbolRectLabel.Location = new System.Drawing.Point(94, 120);
            this.symbolRectLabel.Name = "symbolRectLabel";
            this.symbolRectLabel.Size = new System.Drawing.Size(12, 15);
            this.symbolRectLabel.TabIndex = 15;
            this.symbolRectLabel.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Symbol Rect:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Color:";
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(94, 158);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(12, 15);
            this.fontSizeLabel.TabIndex = 11;
            this.fontSizeLabel.Text = "-";
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(94, 140);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(12, 15);
            this.fontLabel.TabIndex = 10;
            this.fontLabel.Text = "-";
            // 
            // symbolCodeLabel
            // 
            this.symbolCodeLabel.AutoSize = true;
            this.symbolCodeLabel.Location = new System.Drawing.Point(94, 75);
            this.symbolCodeLabel.Name = "symbolCodeLabel";
            this.symbolCodeLabel.Size = new System.Drawing.Size(12, 15);
            this.symbolCodeLabel.TabIndex = 9;
            this.symbolCodeLabel.Text = "-";
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Location = new System.Drawing.Point(94, 55);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(12, 15);
            this.symbolLabel.TabIndex = 8;
            this.symbolLabel.Text = "-";
            // 
            // pageLocationLabel
            // 
            this.pageLocationLabel.AutoSize = true;
            this.pageLocationLabel.Location = new System.Drawing.Point(125, 35);
            this.pageLocationLabel.Name = "pageLocationLabel";
            this.pageLocationLabel.Size = new System.Drawing.Size(12, 15);
            this.pageLocationLabel.TabIndex = 7;
            this.pageLocationLabel.Text = "-";
            // 
            // imageLocationLabel
            // 
            this.imageLocationLabel.AutoSize = true;
            this.imageLocationLabel.Location = new System.Drawing.Point(137, 16);
            this.imageLocationLabel.Name = "imageLocationLabel";
            this.imageLocationLabel.Size = new System.Drawing.Size(12, 15);
            this.imageLocationLabel.TabIndex = 6;
            this.imageLocationLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Font:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Font Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Symbol Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Symbol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location (Text space):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location (Image space):";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.groupBox4);
            this.mainPanel.Controls.Add(this.keyboardSelectionCheckBox);
            this.mainPanel.Controls.Add(this.mouseSelectionCheckBox);
            this.mainPanel.Controls.Add(this.saveAsTextButton);
            this.mainPanel.Controls.Add(this.groupBox2);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.groupBox3);
            this.mainPanel.Controls.Add(this.cursorGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Enabled = false;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(256, 550);
            this.mainPanel.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.caretBlinkingIntervalNumericUpDown);
            this.groupBox4.Controls.Add(this.caretWidthNumericUpDown);
            this.groupBox4.Location = new System.Drawing.Point(4, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(249, 69);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text Caret";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Caret Width (px):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Blinking Interval (ms):";
            // 
            // caretBlinkingIntervalNumericUpDown
            // 
            this.caretBlinkingIntervalNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.caretBlinkingIntervalNumericUpDown.Location = new System.Drawing.Point(136, 40);
            this.caretBlinkingIntervalNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.caretBlinkingIntervalNumericUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.caretBlinkingIntervalNumericUpDown.Name = "caretBlinkingIntervalNumericUpDown";
            this.caretBlinkingIntervalNumericUpDown.Size = new System.Drawing.Size(60, 23);
            this.caretBlinkingIntervalNumericUpDown.TabIndex = 23;
            this.caretBlinkingIntervalNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.caretBlinkingIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.caretBlinkingIntervalNumericUpDown_ValueChanged);
            // 
            // caretWidthNumericUpDown
            // 
            this.caretWidthNumericUpDown.Location = new System.Drawing.Point(136, 17);
            this.caretWidthNumericUpDown.Name = "caretWidthNumericUpDown";
            this.caretWidthNumericUpDown.Size = new System.Drawing.Size(60, 23);
            this.caretWidthNumericUpDown.TabIndex = 21;
            this.caretWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.caretWidthNumericUpDown.ValueChanged += new System.EventHandler(this.caretWidthNumericUpDown_ValueChanged);
            // 
            // keyboardSelectionCheckBox
            // 
            this.keyboardSelectionCheckBox.AutoSize = true;
            this.keyboardSelectionCheckBox.Location = new System.Drawing.Point(126, 9);
            this.keyboardSelectionCheckBox.Name = "keyboardSelectionCheckBox";
            this.keyboardSelectionCheckBox.Size = new System.Drawing.Size(127, 19);
            this.keyboardSelectionCheckBox.TabIndex = 4;
            this.keyboardSelectionCheckBox.Text = "Keyboard Selection";
            this.keyboardSelectionCheckBox.UseVisualStyleBackColor = true;
            this.keyboardSelectionCheckBox.CheckedChanged += new System.EventHandler(this.keyboardSelectionCheckBox_CheckedChanged);
            // 
            // mouseSelectionCheckBox
            // 
            this.mouseSelectionCheckBox.AutoSize = true;
            this.mouseSelectionCheckBox.Location = new System.Drawing.Point(8, 9);
            this.mouseSelectionCheckBox.Name = "mouseSelectionCheckBox";
            this.mouseSelectionCheckBox.Size = new System.Drawing.Size(113, 19);
            this.mouseSelectionCheckBox.TabIndex = 3;
            this.mouseSelectionCheckBox.Text = "Mouse Selection";
            this.mouseSelectionCheckBox.UseVisualStyleBackColor = true;
            this.mouseSelectionCheckBox.CheckedChanged += new System.EventHandler(this.mouseSelectionCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.formattingModeMonospaceRadioButton);
            this.groupBox2.Controls.Add(this.formattingModeLinesRadioButton);
            this.groupBox2.Controls.Add(this.formattingModeParagraphsRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(4, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 41);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Formatting Mode";
            // 
            // formattingModeMonospaceRadioButton
            // 
            this.formattingModeMonospaceRadioButton.AutoSize = true;
            this.formattingModeMonospaceRadioButton.Location = new System.Drawing.Point(142, 18);
            this.formattingModeMonospaceRadioButton.Name = "formattingModeMonospaceRadioButton";
            this.formattingModeMonospaceRadioButton.Size = new System.Drawing.Size(87, 19);
            this.formattingModeMonospaceRadioButton.TabIndex = 2;
            this.formattingModeMonospaceRadioButton.Text = "Monospace";
            this.formattingModeMonospaceRadioButton.UseVisualStyleBackColor = true;
            this.formattingModeMonospaceRadioButton.CheckedChanged += new System.EventHandler(this.formattingModeRadioButton_CheckedChanged);
            // 
            // formattingModeLinesRadioButton
            // 
            this.formattingModeLinesRadioButton.AutoSize = true;
            this.formattingModeLinesRadioButton.Location = new System.Drawing.Point(87, 19);
            this.formattingModeLinesRadioButton.Name = "formattingModeLinesRadioButton";
            this.formattingModeLinesRadioButton.Size = new System.Drawing.Size(52, 19);
            this.formattingModeLinesRadioButton.TabIndex = 1;
            this.formattingModeLinesRadioButton.Text = "Lines";
            this.formattingModeLinesRadioButton.UseVisualStyleBackColor = true;
            this.formattingModeLinesRadioButton.CheckedChanged += new System.EventHandler(this.formattingModeRadioButton_CheckedChanged);
            // 
            // formattingModeParagraphsRadioButton
            // 
            this.formattingModeParagraphsRadioButton.AutoSize = true;
            this.formattingModeParagraphsRadioButton.Checked = true;
            this.formattingModeParagraphsRadioButton.Location = new System.Drawing.Point(6, 19);
            this.formattingModeParagraphsRadioButton.Name = "formattingModeParagraphsRadioButton";
            this.formattingModeParagraphsRadioButton.Size = new System.Drawing.Size(84, 19);
            this.formattingModeParagraphsRadioButton.TabIndex = 0;
            this.formattingModeParagraphsRadioButton.TabStop = true;
            this.formattingModeParagraphsRadioButton.Text = "Paragraphs";
            this.formattingModeParagraphsRadioButton.UseVisualStyleBackColor = true;
            this.formattingModeParagraphsRadioButton.CheckedChanged += new System.EventHandler(this.formattingModeRadioButton_CheckedChanged);
            // 
            // TextSelectionContextMenuStrip
            // 
            this.TextSelectionContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.TextSelectionContextMenuStrip.Name = "PdfTextSelectionContextMenuStrip";
            this.TextSelectionContextMenuStrip.Size = new System.Drawing.Size(123, 48);
            this.TextSelectionContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TextSelectionContextMenuStrip_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text files|*.txt";
            // 
            // TextSelectionControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(183, 390);
            this.Name = "TextSelectionControl";
            this.Size = new System.Drawing.Size(256, 550);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cursorGroupBox.ResumeLayout(false);
            this.cursorGroupBox.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caretBlinkingIntervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caretWidthNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TextSelectionContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton selectionModeFullLinesRadioButton;
        private System.Windows.Forms.RadioButton selectionModeRectangleRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textExtractionTextBox;
        private System.Windows.Forms.GroupBox cursorGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.Label symbolCodeLabel;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Label pageLocationLabel;
        private System.Windows.Forms.Label imageLocationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ContextMenuStrip TextSelectionContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Label symbolRectLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button saveAsTextButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DemosCommonCode.CustomControls.ColorPanelControl symbolColorPanelControl;
        private System.Windows.Forms.Label renderingModeLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label contentCodeLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton formattingModeLinesRadioButton;
        private System.Windows.Forms.RadioButton formattingModeParagraphsRadioButton;
        private System.Windows.Forms.RadioButton formattingModeMonospaceRadioButton;
        private System.Windows.Forms.CheckBox keyboardSelectionCheckBox;
        private System.Windows.Forms.CheckBox mouseSelectionCheckBox;
        private System.Windows.Forms.NumericUpDown caretWidthNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown caretBlinkingIntervalNumericUpDown;
    }
}