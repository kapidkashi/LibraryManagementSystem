using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Pragados_Finals
{
    public partial class frmDashboard : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBBook;
        private DataSet DSBook = new DataSet();
        private DataTable DTBook = new DataTable();

        private SQLiteDataAdapter DBSection;
        private DataSet DSSection = new DataSet();
        private DataTable DTSection = new DataTable();

        private SQLiteDataAdapter DBPenalty;
        private DataSet DSPenalty = new DataSet();
        private DataTable DTPenalty = new DataTable();
        private SQLiteDataAdapter DBPenaltyB;
        private DataSet DSPenaltyB = new DataSet();
        private DataTable DTPenaltyB = new DataTable();

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True");

        }
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();

            string CommandText = "Select * from Books";
            DBBook = new SQLiteDataAdapter(CommandText, sql_con);
            DSBook.Reset();
            DBBook.Fill(DSBook);
            DTBook = DSBook.Tables[0];
            dgvBooks.DataSource = DTBook;
            sql_con.Close();
        }

        public string getUser { get; set; }
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblLibrarian.Text = getUser;
            LoadData();
        }

        //private static int res = 0;
        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (res == 0)
            //{
            //    res++;
            //    frmCreateAccount fca = new frmCreateAccount();
            //    fca.Show();

            //}
            //else
            //{
            //    MessageBox.Show("It is already opened!");

            //    frmCreateAccount fca = new frmCreateAccount();
            //    fca.Focus();
            //}

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCreateAccount")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }
               
            }

            if (IsOpen == false)
            {
                frmCreateAccount fca = new frmCreateAccount();
                fca.Show();
            }
        }

        private void allAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmAccount")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmAccount fa = new frmAccount();
                fa.Show();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmBooks")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmBooks fb = new frmBooks();
                fb.getUser = lblLibrarian.Text;
                fb.Show();
            }
         
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmCreateStudent")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmCreateStudent fs = new frmCreateStudent();
                fs.Show();
            }
        }

        private void studentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmStudent")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmStudent fs = new frmStudent();
                fs.Show();
            }
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmBorrow")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmBorrow fbr = new frmBorrow();
                fbr.getLibBorrow = lblLibrarian.Text;
                fbr.Show();
            }
          
        }

        private void allTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmTransaction")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmTransaction ft = new frmTransaction();
                ft.getUser = lblLibrarian.Text;
                ft.Show();
            }

        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmReturn")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmReturn1 fr = new frmReturn1();
                fr.getLibReturn = lblLibrarian.Text;
                fr.Show();
            }

        }
    }
}
