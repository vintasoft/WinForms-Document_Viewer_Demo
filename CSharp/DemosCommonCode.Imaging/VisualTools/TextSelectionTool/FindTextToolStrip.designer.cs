namespace DemosCommonCode.Imaging
{
    partial class FindTextToolStrip
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
            if (_textSelectionTool != null)
                SubscribeToVisualToolEvents(_textSelectionTool);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindTextToolStrip));
            this.findTextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fastFindToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.fastFindNextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopFastFindToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // findTextToolStripButton
            // 
            this.findTextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findTextToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("findTextToolStripButton.Image")));
            this.findTextToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findTextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findTextToolStripButton.Name = "findTextToolStripButton";
            this.findTextToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.findTextToolStripButton.Text = "Find text...";
            this.findTextToolStripButton.Click += new System.EventHandler(this.findTextToolStripButton_Click);
            // 
            // fastFindToolStripComboBox
            // 
            this.fastFindToolStripComboBox.Name = "fastFindToolStripComboBox";
            this.fastFindToolStripComboBox.Size = new System.Drawing.Size(150, 23);
            this.fastFindToolStripComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fastFindToolStripComboBox_KeyDown);
            // 
            // fastFindNextToolStripButton
            // 
            this.fastFindNextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fastFindNextToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fastFindNextToolStripButton.Image")));
            this.fastFindNextToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fastFindNextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fastFindNextToolStripButton.Name = "fastFindNextToolStripButton";
            this.fastFindNextToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fastFindNextToolStripButton.Text = "Find next";
            this.fastFindNextToolStripButton.Click += new System.EventHandler(this.fastFindNextToolStripButton_Click);
            // 
            // stopFastFindToolStripButton
            // 
            this.stopFastFindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopFastFindToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stopFastFindToolStripButton.Image")));
            this.stopFastFindToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopFastFindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopFastFindToolStripButton.Name = "stopFastFindToolStripButton";
            this.stopFastFindToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.stopFastFindToolStripButton.Text = "Stop";
            this.stopFastFindToolStripButton.Visible = false;
            this.stopFastFindToolStripButton.Click += new System.EventHandler(this.stopFastFindToolStripButton_Click);
            // 
            // FindTextToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findTextToolStripButton,
            this.fastFindToolStripComboBox,
            this.fastFindNextToolStripButton,
            this.stopFastFindToolStripButton});
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton findTextToolStripButton;
        private System.Windows.Forms.ToolStripComboBox fastFindToolStripComboBox;
        private System.Windows.Forms.ToolStripButton fastFindNextToolStripButton;
        private System.Windows.Forms.ToolStripButton stopFastFindToolStripButton;
    }
}
