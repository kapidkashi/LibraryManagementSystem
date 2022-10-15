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
    public partial class frmStudent : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DBAccount;
        private DataSet DSAccount = new DataSet();
        private DataTable DTAccount = new DataTable();
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
            sql_cmd = sql_con.CreateCommand();

            frmCreateAccount fca = new frmCreateAccount();
            string CommandText = "Select * from Student";
            DBAccount = new SQLiteDataAdapter(CommandText, sql_con);
            DSAccount.Reset();
            DBAccount.Fill(DSAccount);
            DTAccount = DSAccount.Tables[0];

            dgvStudent.DataSource = DTAccount;

            sql_con.Close();

        }
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvStudent.SelectedRows[0];
            txtStudentID.Text = dr.Cells[0].Value.ToString();
            txtName.Text = dr.Cells[1].Value.ToString();
            txtCourse.Text = dr.Cells[2].Value.ToString();
            txtYear.Text = dr.Cells[3].Value.ToString();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
