namespace proyectoSM
{
    partial class AddAttribute
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DominioLabel = new System.Windows.Forms.Label();
            this.DominioComboBox = new System.Windows.Forms.ComboBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.NominalListBox = new System.Windows.Forms.ListBox();
            this.AddTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddLabel = new System.Windows.Forms.Label();
            this.DominioCategoricoLabel = new System.Windows.Forms.Label();
            this.SelectTypeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Location = new System.Drawing.Point(12, 20);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(455, 47);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "No se encontraron nombres de atributos, por favor ingresalos todos.";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(15, 123);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(62, 17);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "Nombre:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(102, 123);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(351, 22);
            this.NameTextBox.TabIndex = 2;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "nominal",
            "numeric"});
            this.TypeComboBox.Location = new System.Drawing.Point(102, 83);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(227, 24);
            this.TypeComboBox.TabIndex = 1;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo:";
            // 
            // DominioLabel
            // 
            this.DominioLabel.Location = new System.Drawing.Point(15, 156);
            this.DominioLabel.Name = "DominioLabel";
            this.DominioLabel.Size = new System.Drawing.Size(72, 44);
            this.DominioLabel.TabIndex = 10;
            this.DominioLabel.Text = "Dominio numérico:";
            // 
            // DominioComboBox
            // 
            this.DominioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DominioComboBox.Enabled = false;
            this.DominioComboBox.FormattingEnabled = true;
            this.DominioComboBox.Items.AddRange(new object[] {
            "[0-9]+"});
            this.DominioComboBox.Location = new System.Drawing.Point(102, 166);
            this.DominioComboBox.Name = "DominioComboBox";
            this.DominioComboBox.Size = new System.Drawing.Size(231, 24);
            this.DominioComboBox.TabIndex = 3;
            // 
            // AcceptButton
            // 
            //this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptButton.Enabled = false;
            this.AcceptButton.Location = new System.Drawing.Point(102, 442);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(127, 29);
            this.AcceptButton.TabIndex = 7;
            this.AcceptButton.Text = "Aceptar";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // NominalListBox
            // 
            this.NominalListBox.Enabled = false;
            this.NominalListBox.FormattingEnabled = true;
            this.NominalListBox.ItemHeight = 16;
            this.NominalListBox.Location = new System.Drawing.Point(102, 207);
            this.NominalListBox.Name = "NominalListBox";
            this.NominalListBox.Size = new System.Drawing.Size(351, 164);
            this.NominalListBox.TabIndex = 4;
            // 
            // AddTextBox
            // 
            this.AddTextBox.Enabled = false;
            this.AddTextBox.Location = new System.Drawing.Point(102, 401);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(236, 22);
            this.AddTextBox.TabIndex = 5;
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(344, 401);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(109, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Añadir";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddLabel
            // 
            this.AddLabel.Location = new System.Drawing.Point(15, 380);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(72, 59);
            this.AddLabel.TabIndex = 12;
            this.AddLabel.Text = "Añadir Opción Nominal:";
            this.AddLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // DominioCategoricoLabel
            // 
            this.DominioCategoricoLabel.Location = new System.Drawing.Point(12, 207);
            this.DominioCategoricoLabel.Name = "DominioCategoricoLabel";
            this.DominioCategoricoLabel.Size = new System.Drawing.Size(84, 48);
            this.DominioCategoricoLabel.TabIndex = 11;
            this.DominioCategoricoLabel.Text = "Dominio Categórico:";
            this.DominioCategoricoLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // SelectTypeButton
            // 
            this.SelectTypeButton.Location = new System.Drawing.Point(344, 83);
            this.SelectTypeButton.Name = "SelectTypeButton";
            this.SelectTypeButton.Size = new System.Drawing.Size(109, 24);
            this.SelectTypeButton.TabIndex = 13;
            this.SelectTypeButton.Text = "Seleccionar";
            this.SelectTypeButton.UseVisualStyleBackColor = true;
            this.SelectTypeButton.Click += new System.EventHandler(this.SelectTypeButton_Click);
            // 
            // AddAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 483);
            this.Controls.Add(this.SelectTypeButton);
            this.Controls.Add(this.DominioCategoricoLabel);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddTextBox);
            this.Controls.Add(this.NominalListBox);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.DominioComboBox);
            this.Controls.Add(this.DominioLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TitleLabel);
            this.MaximumSize = new System.Drawing.Size(500, 530);
            this.MinimumSize = new System.Drawing.Size(500, 530);
            this.Name = "AddAttribute";
            this.Text = "AddAttribute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DominioLabel;
        private System.Windows.Forms.ComboBox DominioComboBox;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ListBox NominalListBox;
        private System.Windows.Forms.TextBox AddTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Label DominioCategoricoLabel;
        private System.Windows.Forms.Button SelectTypeButton;
    }
}