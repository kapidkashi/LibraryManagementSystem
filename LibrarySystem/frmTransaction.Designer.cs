
namespace Pragados_Finals
{
    partial class frmTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransaction));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvBorrow = new System.Windows.Forms.DataGridView();
            this.dgvReturn = new System.Windows.Forms.DataGridView();
            this.lblLibrarian = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchBorrow = new System.Windows.Forms.TextBox();
            this.cmbMonthReturn = new System.Windows.Forms.ComboBox();
            this.txtSearchReturn = new System.Windows.Forms.TextBox();
            this.cmbYearReturn = new System.Windows.Forms.ComboBox();
            this.cmbYearBorrow = new System.Windows.Forms.ComboBox();
            this.cmbMonthBorrow = new System.Windows.Forms.ComboBox();
            this.cmbDaysBorrow = new System.Windows.Forms.ComboBox();
            this.cmbDaysReturn = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-20, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(46)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 113;
            this.label1.Text = "Transaction";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(827, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 24);
            this.button1.TabIndex = 108;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvBorrow
            // 
            this.dgvBorrow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrow.Location = new System.Drawing.Point(13, 167);
            this.dgvBorrow.Name = "dgvBorrow";
            this.dgvBorrow.Size = new System.Drawing.Size(834, 181);
            this.dgvBorrow.TabIndex = 1;
            // 
            // dgvReturn
            // 
            this.dgvReturn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturn.Location = new System.Drawing.Point(12, 457);
            this.dgvReturn.Name = "dgvReturn";
            this.dgvReturn.Size = new System.Drawing.Size(834, 188);
            this.dgvReturn.TabIndex = 2;
            // 
            // lblLibrarian
            // 
            this.lblLibrarian.AutoSize = true;
            this.lblLibrarian.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibrarian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(46)))));
            this.lblLibrarian.Location = new System.Drawing.Point(765, 60);
            this.lblLibrarian.Name = "lblLibrarian";
            this.lblLibrarian.Size = new System.Drawing.Size(96, 25);
            this.lblLibrarian.TabIndex = 100;
            this.lblLibrarian.Text = "Librarian";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(46)))));
            this.label12.Location = new System.Drawing.Point(659, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 25);
            this.label12.TabIndex = 99;
            this.label12.Text = "Librarian:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(46)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 24);
            this.label2.TabIndex = 102;
            this.label2.Text = "Transaction Borrow";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(46)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 24);
            this.label3.TabIndex = 103;
            this.label3.Text = "Transaction Return";
            // 
            // txtSearchBorrow
            // 
            this.txtSearchBorrow.Location = new System.Drawing.Point(418, 141);
            this.txtSearchBorrow.Name = "txtSearchBorrow";
            this.txtSearchBorrow.Size = new System.Drawing.Size(221, 20);
            this.txtSearchBorrow.TabIndex = 106;
            this.txtSearchBorrow.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbMonthReturn
            // 
            this.cmbMonthReturn.FormattingEnabled = true;
            this.cmbMonthReturn.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonthReturn.Location = new System.Drawing.Point(183, 430);
            this.cmbMonthReturn.Name = "cmbMonthReturn";
            this.cmbMonthReturn.Size = new System.Drawing.Size(70, 21);
            this.cmbMonthReturn.TabIndex = 107;
            this.cmbMonthReturn.Text = "-MONTH-";
            this.cmbMonthReturn.SelectedIndexChanged += new System.EventHandler(this.cmbMonthReturn_SelectedIndexChanged);
            // 
            // txtSearchReturn
            // 
            this.txtSearchReturn.Location = new System.Drawing.Point(418, 431);
            this.txtSearchReturn.Name = "txtSearchReturn";
            this.txtSearchReturn.Size = new System.Drawing.Size(221, 20);
            this.txtSearchReturn.TabIndex = 108;
            this.txtSearchReturn.TextChanged += new System.EventHandler(this.txtSearchReturn_TextChanged);
            // 
            // cmbYearReturn
            // 
            this.cmbYearReturn.FormattingEnabled = true;
            this.cmbYearReturn.Items.AddRange(new object[] {
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cmbYearReturn.Location = new System.Drawing.Point(335, 431);
            this.cmbYearReturn.Name = "cmbYearReturn";
            this.cmbYearReturn.Size = new System.Drawing.Size(70, 21);
            this.cmbYearReturn.TabIndex = 110;
            this.cmbYearReturn.Text = "YEAR";
            this.cmbYearReturn.SelectedIndexChanged += new System.EventHandler(this.cmbYearReturn_SelectedIndexChanged);
            // 
            // cmbYearBorrow
            // 
            this.cmbYearBorrow.FormattingEnabled = true;
            this.cmbYearBorrow.Items.AddRange(new object[] {
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cmbYearBorrow.Location = new System.Drawing.Point(342, 140);
            this.cmbYearBorrow.Name = "cmbYearBorrow";
            this.cmbYearBorrow.Size = new System.Drawing.Size(70, 21);
            this.cmbYearBorrow.TabIndex = 112;
            this.cmbYearBorrow.Text = "-YEAR-";
            this.cmbYearBorrow.SelectedIndexChanged += new System.EventHandler(this.cmbYearBorrow_SelectedIndexChanged);
            this.cmbYearBorrow.SelectedValueChanged += new System.EventHandler(this.cmbYearBorrow_SelectedValueChanged);
            // 
            // cmbMonthBorrow
            // 
            this.cmbMonthBorrow.FormattingEnabled = true;
            this.cmbMonthBorrow.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonthBorrow.Location = new System.Drawing.Point(190, 140);
            this.cmbMonthBorrow.Name = "cmbMonthBorrow";
            this.cmbMonthBorrow.Size = new System.Drawing.Size(70, 21);
            this.cmbMonthBorrow.TabIndex = 111;
            this.cmbMonthBorrow.Text = "-MONTH-";
            this.cmbMonthBorrow.SelectedIndexChanged += new System.EventHandler(this.cmbMonthBorrow_SelectedIndexChanged);
            // 
            // cmbDaysBorrow
            // 
            this.cmbDaysBorrow.FormattingEnabled = true;
            this.cmbDaysBorrow.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbDaysBorrow.Location = new System.Drawing.Point(266, 141);
            this.cmbDaysBorrow.Name = "cmbDaysBorrow";
            this.cmbDaysBorrow.Size = new System.Drawing.Size(70, 21);
            this.cmbDaysBorrow.TabIndex = 113;
            this.cmbDaysBorrow.Text = "-DAYS-";
            this.cmbDaysBorrow.SelectedIndexChanged += new System.EventHandler(this.cmbDaysBorrow_SelectedIndexChanged);
            // 
            // cmbDaysReturn
            // 
            this.cmbDaysReturn.FormattingEnabled = true;
            this.cmbDaysReturn.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbDaysReturn.Location = new System.Drawing.Point(259, 430);
            this.cmbDaysReturn.Name = "cmbDaysReturn";
            this.cmbDaysReturn.Size = new System.Drawing.Size(70, 21);
            this.cmbDaysReturn.TabIndex = 114;
            this.cmbDaysReturn.Text = "-DAYS-";
            this.cmbDaysReturn.SelectedIndexChanged += new System.EventHandler(this.cmbDaysReturn_SelectedIndexChanged);
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(858, 657);
            this.Controls.Add(this.cmbDaysReturn);
            this.Controls.Add(this.cmbDaysBorrow);
            this.Controls.Add(this.cmbYearBorrow);
            this.Controls.Add(this.cmbMonthBorrow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbYearReturn);
            this.Controls.Add(this.txtSearchReturn);
            this.Controls.Add(this.cmbMonthReturn);
            this.Controls.Add(this.txtSearchBorrow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLibrarian);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvReturn);
            this.Controls.Add(this.dgvBorrow);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransaction";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBorrow;
        private System.Windows.Forms.DataGridView dgvReturn;
        private System.Windows.Forms.Label lblLibrarian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchBorrow;
        private System.Windows.Forms.ComboBox cmbMonthReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSearchReturn;
        private System.Windows.Forms.ComboBox cmbYearReturn;
        private System.Windows.Forms.ComboBox cmbYearBorrow;
        private System.Windows.Forms.ComboBox cmbMonthBorrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDaysBorrow;
        private System.Windows.Forms.ComboBox cmbDaysReturn;
    }
}