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
    public partial class frmCreateAccount : Form
    {

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
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
        public frmCreateAccount()
        {
            InitializeComponent();
        }
        private void LibID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBLibID = new SQLiteDataAdapter("select UserID from User order by UserID desc", sql_con);
                DataSet DSLibID = new DataSet();
                DBLibID.Fill(DSLibID);
                if (DSLibID.Tables[0].Rows.Count > 0)
                {
                    txtAutoLib.Text = DSLibID.Tables[0].Rows[0]["UserID"].ToString();
                }
                else
                {
                    txtAutoLib.Text = "LIB0000"; 
                }
                if (!string.IsNullOrEmpty(txtAutoLib.Text))
                {
                    txtAutoLib.SelectionStart = 3;
                    txtAutoLib.SelectionLength = 4;
                    lblAutoLib.Text = txtAutoLib.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoLib.Text))
                {
                    int ID = int.Parse(lblAutoLib.Text.ToString()) + 1;
                    txtLibID.Text = ID.ToString("LIB0000");
                }
            }
            catch(Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        private void txtCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtConfirmPassword.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Complete Data", "Confirm");
            }
            if(txtPassword.Text!=txtConfirmPassword.Text)
            {
                MessageBox.Show("Password AND Confirm Password is not the same", "Confirm");
            }
            else
            {
                string txtQuery = "Insert into User(userID,Name,Password) values ('" + txtLibID.Text + "','" + txtName.Text + "','" + txtConfirmPassword.Text + "')";
                ExecuteQuery(txtQuery);

                MessageBox.Show("New Librarian Account has been Added.");
                LibID();
                txtName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
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

        private void cbConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirm.Checked)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            LibID();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Cancel?", "Confirmation Message!", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
              
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
