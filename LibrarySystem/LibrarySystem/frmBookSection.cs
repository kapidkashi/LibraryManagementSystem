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
    public partial class frmBookSection : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBSection;
        private DataSet DSSection = new DataSet();
        private DataTable DTSection = new DataTable();

        public frmBookSection()
        {
            InitializeComponent();
            LoadData();
        }
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
            string CommandTextSection = "Select BookSection from BookSection";
            DBSection = new SQLiteDataAdapter(CommandTextSection, sql_con);
            DSSection.Reset();
            DBSection.Fill(DSSection);
            DTSection = DSSection.Tables[0];
          
            dgvBookSection.DataSource = DTSection;


            sql_con.Close();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string txtQuery = "Insert into BookSection (BookSection) values ('"+ txtSection.Text +"')";
            ExecuteQuery(txtQuery);
            LoadData();
            txtSection.Clear();
        }

        private void frmBookSection_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string txtQuery = "Update BookSection set BookSection = '" + txtSection.Text + "' where BookSection = '" + txtSection.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();
            txtSection.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string txtQuery = "delete from BookSection where BookSection ='" + txtSection.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();
            txtSection.Clear();
        }

        private void dgvBookSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvBookSection.SelectedRows[0];
            txtSection.Text = dr.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
