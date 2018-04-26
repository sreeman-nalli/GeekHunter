namespace GeekHunter
{
    partial class Home
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
            this.homeGridVieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.headerLabelHomePage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loadingGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.filterCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.registerLinkLabel = new System.Windows.Forms.LinkLabel();
            this.filterBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.homeGridVieBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabelHomePage
            // 
            this.headerLabelHomePage.AutoSize = true;
            this.headerLabelHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabelHomePage.Location = new System.Drawing.Point(432, 30);
            this.headerLabelHomePage.Name = "headerLabelHomePage";
            this.headerLabelHomePage.Size = new System.Drawing.Size(152, 31);
            this.headerLabelHomePage.TabIndex = 1;
            this.headerLabelHomePage.Text = "Candidates";
            this.headerLabelHomePage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.loadingGridView);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.filterCheckedListBox);
            this.groupBox1.Controls.Add(this.registerLinkLabel);
            this.groupBox1.Location = new System.Drawing.Point(44, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 373);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Click a record to edit";
            // 
            // loadingGridView
            // 
            this.loadingGridView.AllowUserToAddRows = false;
            this.loadingGridView.AllowUserToDeleteRows = false;
            this.loadingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loadingGridView.Location = new System.Drawing.Point(16, 48);
            this.loadingGridView.Name = "loadingGridView";
            this.loadingGridView.ReadOnly = true;
            this.loadingGridView.Size = new System.Drawing.Size(754, 254);
            this.loadingGridView.TabIndex = 0;
            this.loadingGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loadingGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(814, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by Skills";
            // 
            // filterCheckedListBox
            // 
            this.filterCheckedListBox.CheckOnClick = true;
            this.filterCheckedListBox.FormattingEnabled = true;
            this.filterCheckedListBox.Location = new System.Drawing.Point(793, 62);
            this.filterCheckedListBox.Name = "filterCheckedListBox";
            this.filterCheckedListBox.Size = new System.Drawing.Size(106, 199);
            this.filterCheckedListBox.TabIndex = 3;
            // 
            // registerLinkLabel
            // 
            this.registerLinkLabel.AutoSize = true;
            this.registerLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLinkLabel.Location = new System.Drawing.Point(24, 16);
            this.registerLinkLabel.Name = "registerLinkLabel";
            this.registerLinkLabel.Size = new System.Drawing.Size(61, 17);
            this.registerLinkLabel.TabIndex = 2;
            this.registerLinkLabel.TabStop = true;
            this.registerLinkLabel.Text = "Register";
            this.registerLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLinkLabel_LinkClicked);
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(809, 267);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(75, 23);
            this.filterBtn.TabIndex = 6;
            this.filterBtn.Text = "Filter";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // Home
            // 
            this.ClientSize = new System.Drawing.Size(1000, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.headerLabelHomePage);
            this.Name = "Home";
            this.Text = "Geek Hunter";
            ((System.ComponentModel.ISupportInitialize)(this.homeGridVieBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource homeGridVieBindingSource;
        private System.Windows.Forms.Label headerLabelHomePage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView loadingGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox filterCheckedListBox;
        private System.Windows.Forms.LinkLabel registerLinkLabel;
        private System.Windows.Forms.Button filterBtn;
    }
}

