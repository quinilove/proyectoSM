namespace proyectoSM
{
    partial class LecturaCSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LecturaCSV));
            this.CSVDataGridView = new System.Windows.Forms.DataGridView();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.openCSVFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CommentsListBox = new System.Windows.Forms.ListBox();
            this.ComentsLabel = new System.Windows.Forms.Label();
            this.RelationNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CSVDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CSVDataGridView
            // 
            resources.ApplyResources(this.CSVDataGridView, "CSVDataGridView");
            this.CSVDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CSVDataGridView.Name = "CSVDataGridView";
            this.CSVDataGridView.RowTemplate.Height = 24;
            this.CSVDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CSVDataGridView_CellContentClick);
            // 
            // FilePathTextBox
            // 
            resources.ApplyResources(this.FilePathTextBox, "FilePathTextBox");
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.ReadOnly = true;
            // 
            // OpenFileButton
            // 
            resources.ApplyResources(this.OpenFileButton, "OpenFileButton");
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // openCSVFileDialog
            // 
            this.openCSVFileDialog.FileName = "openCSVFileDialog";
            // 
            // CommentsListBox
            // 
            resources.ApplyResources(this.CommentsListBox, "CommentsListBox");
            this.CommentsListBox.FormattingEnabled = true;
            this.CommentsListBox.Name = "CommentsListBox";
            // 
            // ComentsLabel
            // 
            resources.ApplyResources(this.ComentsLabel, "ComentsLabel");
            this.ComentsLabel.Name = "ComentsLabel";
            // 
            // RelationNameTextBox
            // 
            resources.ApplyResources(this.RelationNameTextBox, "RelationNameTextBox");
            this.RelationNameTextBox.Name = "RelationNameTextBox";
            this.RelationNameTextBox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // GuardarButton
            // 
            resources.ApplyResources(this.GuardarButton, "GuardarButton");
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LecturaCSV
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RelationNameTextBox);
            this.Controls.Add(this.ComentsLabel);
            this.Controls.Add(this.CommentsListBox);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.CSVDataGridView);
            this.Name = "LecturaCSV";
            this.Load += new System.EventHandler(this.LecturaCSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CSVDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CSVDataGridView;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.OpenFileDialog openCSVFileDialog;
        private System.Windows.Forms.ListBox CommentsListBox;
        private System.Windows.Forms.Label ComentsLabel;
        private System.Windows.Forms.TextBox RelationNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}