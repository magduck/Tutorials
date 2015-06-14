namespace UI
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
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.FilterButton = new System.Windows.Forms.Button();
            this.CompanyNameText = new System.Windows.Forms.TextBox();
            this.CityNameBox = new System.Windows.Forms.ComboBox();
            this.CountryNameBox = new System.Windows.Forms.ComboBox();
            this.CountryLable = new System.Windows.Forms.Label();
            this.CompaniesGrid = new System.Windows.Forms.DataGridView();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagingPanel = new System.Windows.Forms.Panel();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.LastBtn = new System.Windows.Forms.Button();
            this.FirstBtn = new System.Windows.Forms.Button();
            this.PageLabel = new System.Windows.Forms.Label();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompaniesGrid)).BeginInit();
            this.PagingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.CompanyLabel);
            this.SearchPanel.Controls.Add(this.CityLabel);
            this.SearchPanel.Controls.Add(this.FilterButton);
            this.SearchPanel.Controls.Add(this.CompanyNameText);
            this.SearchPanel.Controls.Add(this.CityNameBox);
            this.SearchPanel.Controls.Add(this.CountryNameBox);
            this.SearchPanel.Controls.Add(this.CountryLable);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1100, 53);
            this.SearchPanel.TabIndex = 0;
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Location = new System.Drawing.Point(682, 15);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(120, 20);
            this.CompanyLabel.TabIndex = 6;
            this.CompanyLabel.Text = "Company name";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(359, 15);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(35, 20);
            this.CityLabel.TabIndex = 5;
            this.CityLabel.Text = "City";
            // 
            // FilterButton
            // 
            this.FilterButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FilterButton.Location = new System.Drawing.Point(954, 8);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(134, 39);
            this.FilterButton.TabIndex = 4;
            this.FilterButton.Text = "Filter Apply";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // CompanyNameText
            // 
            this.CompanyNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyNameText.Location = new System.Drawing.Point(808, 12);
            this.CompanyNameText.Name = "CompanyNameText";
            this.CompanyNameText.Size = new System.Drawing.Size(140, 26);
            this.CompanyNameText.TabIndex = 3;
            this.CompanyNameText.TextChanged += new System.EventHandler(this.CompanyNameText_TextChanged);
            // 
            // CityNameBox
            // 
            this.CityNameBox.FormattingEnabled = true;
            this.CityNameBox.Location = new System.Drawing.Point(400, 10);
            this.CityNameBox.Name = "CityNameBox";
            this.CityNameBox.Size = new System.Drawing.Size(276, 28);
            this.CityNameBox.TabIndex = 2;
            this.CityNameBox.SelectedValueChanged += new System.EventHandler(this.CityNameBox_SelectedValueChanged);
            // 
            // CountryNameBox
            // 
            this.CountryNameBox.FormattingEnabled = true;
            this.CountryNameBox.Location = new System.Drawing.Point(77, 10);
            this.CountryNameBox.Name = "CountryNameBox";
            this.CountryNameBox.Size = new System.Drawing.Size(276, 28);
            this.CountryNameBox.TabIndex = 1;
            this.CountryNameBox.SelectedValueChanged += new System.EventHandler(this.CountryNameBox_SelectedValueChanged);
            // 
            // CountryLable
            // 
            this.CountryLable.AutoSize = true;
            this.CountryLable.Location = new System.Drawing.Point(7, 13);
            this.CountryLable.Name = "CountryLable";
            this.CountryLable.Size = new System.Drawing.Size(64, 20);
            this.CountryLable.TabIndex = 0;
            this.CountryLable.Text = "Country";
            // 
            // CompaniesGrid
            // 
            this.CompaniesGrid.AllowUserToAddRows = false;
            this.CompaniesGrid.AllowUserToDeleteRows = false;
            this.CompaniesGrid.AllowUserToOrderColumns = true;
            this.CompaniesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompaniesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountryName,
            this.CityName,
            this.CompanyName});
            this.CompaniesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompaniesGrid.Location = new System.Drawing.Point(0, 53);
            this.CompaniesGrid.Name = "CompaniesGrid";
            this.CompaniesGrid.ReadOnly = true;
            this.CompaniesGrid.RowTemplate.Height = 28;
            this.CompaniesGrid.Size = new System.Drawing.Size(1100, 845);
            this.CompaniesGrid.TabIndex = 2;
            // 
            // CountryName
            // 
            this.CountryName.HeaderText = "CountryName";
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            // 
            // CityName
            // 
            this.CityName.HeaderText = "CityName";
            this.CityName.Name = "CityName";
            this.CityName.ReadOnly = true;
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyName.HeaderText = "CompanyName";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // PagingPanel
            // 
            this.PagingPanel.Controls.Add(this.PageLabel);
            this.PagingPanel.Controls.Add(this.FirstBtn);
            this.PagingPanel.Controls.Add(this.LastBtn);
            this.PagingPanel.Controls.Add(this.NextBtn);
            this.PagingPanel.Controls.Add(this.PrevBtn);
            this.PagingPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagingPanel.Location = new System.Drawing.Point(0, 834);
            this.PagingPanel.Name = "PagingPanel";
            this.PagingPanel.Size = new System.Drawing.Size(1100, 64);
            this.PagingPanel.TabIndex = 3;
            // 
            // PrevBtn
            // 
            this.PrevBtn.Location = new System.Drawing.Point(346, 19);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(75, 33);
            this.PrevBtn.TabIndex = 0;
            this.PrevBtn.Text = "< Prev";
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(605, 19);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 33);
            this.NextBtn.TabIndex = 1;
            this.NextBtn.Text = "Next >";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // LastBtn
            // 
            this.LastBtn.Location = new System.Drawing.Point(686, 19);
            this.LastBtn.Name = "LastBtn";
            this.LastBtn.Size = new System.Drawing.Size(75, 33);
            this.LastBtn.TabIndex = 2;
            this.LastBtn.Text = "Last";
            this.LastBtn.UseVisualStyleBackColor = true;
            this.LastBtn.Click += new System.EventHandler(this.LastBtn_Click);
            // 
            // FirstBtn
            // 
            this.FirstBtn.Location = new System.Drawing.Point(265, 19);
            this.FirstBtn.Name = "FirstBtn";
            this.FirstBtn.Size = new System.Drawing.Size(75, 33);
            this.FirstBtn.TabIndex = 3;
            this.FirstBtn.Text = "First";
            this.FirstBtn.UseVisualStyleBackColor = true;
            this.FirstBtn.Click += new System.EventHandler(this.FirstBtn_Click);
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Location = new System.Drawing.Point(485, 25);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(49, 20);
            this.PageLabel.TabIndex = 4;
            this.PageLabel.Text = "1 of 1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 898);
            this.Controls.Add(this.PagingPanel);
            this.Controls.Add(this.CompaniesGrid);
            this.Controls.Add(this.SearchPanel);
            this.MinimumSize = new System.Drawing.Size(1122, 954);
            this.Name = "MainForm";
            this.Text = "Client UI";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompaniesGrid)).EndInit();
            this.PagingPanel.ResumeLayout(false);
            this.PagingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.DataGridView CompaniesGrid;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.TextBox CompanyNameText;
        private System.Windows.Forms.ComboBox CityNameBox;
        private System.Windows.Forms.ComboBox CountryNameBox;
        private System.Windows.Forms.Label CountryLable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.Panel PagingPanel;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Button FirstBtn;
        private System.Windows.Forms.Button LastBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label PageLabel;
    }
}

