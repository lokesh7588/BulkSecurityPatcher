namespace BulkAssignUserToBU
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAboutUs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDownload = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileLocationTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RemoveExistingcheckBox1 = new System.Windows.Forms.CheckBox();
            this.ImportAndAddButton = new System.Windows.Forms.Button();
            this.TeamBusinessUnitSelectionOptionset = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Result = new System.Windows.Forms.GroupBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AssignmentcomboBox = new System.Windows.Forms.ComboBox();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Result.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbHelp,
            this.toolStripSeparator1,
            this.tsbAboutUs,
            this.toolStripSeparator2,
            this.tsbDownload});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1475, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::BulkAssignUserToBU.Properties.Resources.CloseButton;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(64, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbHelp
            // 
            this.tsbHelp.Image = global::BulkAssignUserToBU.Properties.Resources.arrow_down;
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(141, 28);
            this.tsbHelp.Text = "Download Template";
            this.tsbHelp.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            this.toolStripSeparator1.Visible = false;
            // 
            // tsbAboutUs
            // 
            this.tsbAboutUs.Image = global::BulkAssignUserToBU.Properties.Resources.aboutus;
            this.tsbAboutUs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAboutUs.Name = "tsbAboutUs";
            this.tsbAboutUs.Size = new System.Drawing.Size(84, 28);
            this.tsbAboutUs.Text = "About Us";
            this.tsbAboutUs.Click += new System.EventHandler(this.tsbAboutUs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            this.toolStripSeparator2.Visible = false;
            // 
            // tsbDownload
            // 
            this.tsbDownload.Image = global::BulkAssignUserToBU.Properties.Resources.arrow_down;
            this.tsbDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownload.Name = "tsbDownload";
            this.tsbDownload.Size = new System.Drawing.Size(132, 28);
            this.tsbDownload.Text = "Download Manual";
            this.tsbDownload.Visible = false;
            this.tsbDownload.Click += new System.EventHandler(this.tsbDownload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BrowseButton);
            this.groupBox1.Controls.Add(this.FileLocationTextBox);
            this.groupBox1.Location = new System.Drawing.Point(258, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(547, 153);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import or Drag File";
            // 
            // BrowseButton
            // 
            this.BrowseButton.AllowDrop = true;
            this.BrowseButton.Location = new System.Drawing.Point(430, 73);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(100, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.BrowseButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_Drag);
            // 
            // FileLocationTextBox
            // 
            this.FileLocationTextBox.Location = new System.Drawing.Point(6, 73);
            this.FileLocationTextBox.Name = "FileLocationTextBox";
            this.FileLocationTextBox.Size = new System.Drawing.Size(418, 23);
            this.FileLocationTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RemoveExistingcheckBox1);
            this.groupBox2.Controls.Add(this.ImportAndAddButton);
            this.groupBox2.Controls.Add(this.TeamBusinessUnitSelectionOptionset);
            this.groupBox2.Location = new System.Drawing.Point(811, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 153);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // RemoveExistingcheckBox1
            // 
            this.RemoveExistingcheckBox1.AutoSize = true;
            this.RemoveExistingcheckBox1.Location = new System.Drawing.Point(304, 59);
            this.RemoveExistingcheckBox1.Name = "RemoveExistingcheckBox1";
            this.RemoveExistingcheckBox1.Size = new System.Drawing.Size(113, 21);
            this.RemoveExistingcheckBox1.TabIndex = 3;
            this.RemoveExistingcheckBox1.Text = "Remove Existing";
            this.RemoveExistingcheckBox1.UseVisualStyleBackColor = true;
            this.RemoveExistingcheckBox1.CheckedChanged += new System.EventHandler(this.RemoveExistingcheckBox1_CheckedChanged);
            // 
            // ImportAndAddButton
            // 
            this.ImportAndAddButton.Location = new System.Drawing.Point(195, 105);
            this.ImportAndAddButton.Name = "ImportAndAddButton";
            this.ImportAndAddButton.Size = new System.Drawing.Size(120, 23);
            this.ImportAndAddButton.TabIndex = 2;
            this.ImportAndAddButton.Text = "Import And Add";
            this.ImportAndAddButton.UseVisualStyleBackColor = true;
            this.ImportAndAddButton.Click += new System.EventHandler(this.ImportAndAddButton_Click);
            // 
            // TeamBusinessUnitSelectionOptionset
            // 
            this.TeamBusinessUnitSelectionOptionset.FormattingEnabled = true;
            this.TeamBusinessUnitSelectionOptionset.Location = new System.Drawing.Point(20, 59);
            this.TeamBusinessUnitSelectionOptionset.Name = "TeamBusinessUnitSelectionOptionset";
            this.TeamBusinessUnitSelectionOptionset.Size = new System.Drawing.Size(214, 25);
            this.TeamBusinessUnitSelectionOptionset.TabIndex = 0;
            this.TeamBusinessUnitSelectionOptionset.Text = "Select BU";
            this.TeamBusinessUnitSelectionOptionset.SelectedIndexChanged += new System.EventHandler(this.BusinessUnitSelectionOptionset_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 219);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1306, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // Result
            // 
            this.Result.Controls.Add(this.ResultTextBox);
            this.Result.Location = new System.Drawing.Point(6, 273);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(1306, 275);
            this.Result.TabIndex = 8;
            this.Result.TabStop = false;
            this.Result.Text = "Result";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(6, 22);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(1294, 238);
            this.ResultTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.Result);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(4, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1329, 562);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AssignmentcomboBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 153);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Assignment ";
            // 
            // AssignmentcomboBox
            // 
            this.AssignmentcomboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Assign to Team",
            "Assign to Business Unit"});
            this.AssignmentcomboBox.FormattingEnabled = true;
            this.AssignmentcomboBox.Items.AddRange(new object[] {
            "Assign To Team",
            "Assign To BU"});
            this.AssignmentcomboBox.Location = new System.Drawing.Point(6, 73);
            this.AssignmentcomboBox.Name = "AssignmentcomboBox";
            this.AssignmentcomboBox.Size = new System.Drawing.Size(218, 25);
            this.AssignmentcomboBox.TabIndex = 0;
            this.AssignmentcomboBox.Text = "Select Assignment ";
            this.AssignmentcomboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MyPluginControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStripMenu);
            this.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1475, 656);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Result.ResumeLayout(false);
            this.Result.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox FileLocationTextBox;
        private System.Windows.Forms.Button ImportAndAddButton;
        private System.Windows.Forms.ComboBox TeamBusinessUnitSelectionOptionset;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox Result;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDownload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbAboutUs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox AssignmentcomboBox;
        private System.Windows.Forms.CheckBox RemoveExistingcheckBox1;
    }
}
