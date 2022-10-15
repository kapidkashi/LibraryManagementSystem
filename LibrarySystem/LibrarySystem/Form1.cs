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
    public partial class frmLogin : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
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
            string CommandText = "Select * from User";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];

            //fca.dgvEmpReg.DataSource = DT;

            cmbUserID.DataSource = DT;
            cmbUserID.DisplayMember = "UserID";
            cmbUserID.ValueMember = "UserID";

            sql_con.Close();

        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
         
            LoadData();
            Bind();
        }

        private SQLiteDataAdapter DBBind;
        
        private DataTable DTBind;
        private SQLiteCommandBuilder cmd = new SQLiteCommandBuilder();
        private void Bind()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            sql_cmd.CommandText = "select *from User where UserID=@UserID";
            sql_cmd.Parameters.AddWithValue("@UserID", cmbUserID.SelectedValue);
            DTBind = new DataTable();
            DBBind = new SQLiteDataAdapter();
            cmd.DataAdapter = DBBind;

            DBBind.SelectCommand =sql_cmd;
            DBBind.Fill(DTBind);
            DT.AcceptChanges();
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", DT, "Name", false, DataSourceUpdateMode.OnPropertyChanged);

            sql_con.Close();
            
        }
     
        private void btnLogin_Click(object sender, EventArgs e)
        {
            sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
            sql_cmd.Connection = sql_con;

            sql_cmd.CommandText = "select * from user where UserID = '" + cmbUserID.Text + "'and Password = '" + txtPassword.Text + "'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

     
            if(ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                frmDashboard fd = new frmDashboard();
                fd.getUser = txtName.Text;
                frmBorrow fbr = new frmBorrow();
                fbr.getLibBorrow = txtName.Text;

                fd.Show();
            }
            else
            {
                MessageBox.Show("User ID and Password do not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
