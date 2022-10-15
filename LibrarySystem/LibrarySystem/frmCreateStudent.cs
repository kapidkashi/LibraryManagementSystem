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
    public partial class frmCreateStudent : Form
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
        public frmCreateStudent()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text==""|| txtStudentName.Text=="" ||txtCourse.Text==""||txtYear.Text==""||txtAddress.Text==""||txtContact.Text==""||txtEmail.Text=="")
            {
                MessageBox.Show("Please Complete Input", "Confirm");
            }

            else
            { string txtQuery = "Insert into Student(StudentID,Name,Course,Year,Address,Contact,Email) values ('" + txtStudentID.Text + "','" + txtStudentName.Text + "'," +
                "'" + txtCourse.Text + "','" + txtYear.Text + "','" + txtAddress.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "')";
                ExecuteQuery(txtQuery);

                MessageBox.Show("New Student has been Added.");
                txtStudentID.Clear();
                txtStudentName.Text = "";
                txtCourse.Text = "";
                txtYear.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
