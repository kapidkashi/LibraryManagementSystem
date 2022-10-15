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
    public partial class frmTransaction : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

       

        private SQLiteDataAdapter DBBorrow;
        private DataSet DSBorrow = new DataSet();
        private DataTable DTBorrow = new DataTable();
        private SQLiteDataAdapter DBReturn;
        private DataSet DSReturn = new DataSet();
        private DataTable DTReturn = new DataTable();
        public frmTransaction()
        {
            InitializeComponent();
        }
        public string getUser { get; set; }
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            LoadData();
            lblLibrarian.Text = getUser;
          
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

          
            string CommandTextBorrow = "Select * from TransactionBorrow";
            DBBorrow = new SQLiteDataAdapter(CommandTextBorrow, sql_con);
            DSBorrow.Reset();
            DBBorrow.Fill(DSBorrow);
            DTBorrow = DSBorrow.Tables[0];

            dgvBorrow.DataSource = DTBorrow;


            string CommandTextReturn = "Select * from TransactionBorrow";
            DBReturn = new SQLiteDataAdapter(CommandTextReturn, sql_con);
            DSReturn.Reset();
            DBReturn.Fill(DSReturn);
            DTReturn = DSReturn.Tables[0];

            dgvReturn.DataSource = DTBorrow;

            sql_con.Close();

        }
        SQLiteConnection con = new SQLiteConnection(@"Data Source = LibraryDB.db; Version = 3; New = False; Compress = True");
        SQLiteCommand cm = new SQLiteCommand();

     

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionBorrow where StudentID Like  '%" + txtSearchBorrow.Text + "%' or StudentName Like  '" + txtSearchBorrow.Text + "%' or BookTitle Like  '" + txtSearchBorrow.Text + "%' or BookAuthor Like'%" + txtSearchBorrow.Text + "%' or BookSection Like '" + txtSearchBorrow.Text + "%' or LibrarianBorrow Like '" + txtSearchBorrow.Text + "%' or DateBorrow Like '" + txtSearchBorrow.Text + "%'", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbMonthBorrow_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionBorrow where DateBorrow Like  '%" + cmbMonthBorrow.Text + "%' ", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];
        }

        private void cmbYearBorrow_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionBorrow where DateBorrow Like  '%" + cmbYearBorrow.Text + "%' ", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];
        }

        private void cmbYearBorrow_SelectedValueChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionBorrow where DateBorrow Like  '%" + cmbYearBorrow.SelectedItem + "%' ", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbYearReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionReturn where DateBorrow Like  '%" + cmbYearReturn.Text + "%' or DateReturn Like  '%" + cmbYearReturn.Text + "%'", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvReturn.DataSource = ds.Tables[0];
        }

        private void cmbMonthReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionReturn where DateBorrow Like  '%" + cmbMonthReturn.Text + "%' or DateReturn Like  '%" + cmbMonthReturn.Text + "%' ", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvReturn.DataSource = ds.Tables[0];
        }

        private void txtSearchReturn_TextChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from Transaction Return where StudentID Like  '%" + txtSearchReturn.Text + "%' or StudentName Like  '" + txtSearchReturn.Text + "%' or BookTitle Like  '" + txtSearchReturn.Text + "%' or BookAuthor Like'%" + txtSearchReturn.Text + "%' or BookSection Like '" + txtSearchReturn.Text + "%' or LibrarianBorrow Like '" + txtSearchReturn.Text + "%' or LibrarianReturn Like '" + txtSearchReturn.Text + "%' or DateBorrow Like '" + txtSearchReturn.Text + "%' or DateReturn Like '" + txtSearchReturn.Text + "%'", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvReturn.DataSource = ds.Tables[0];
        }

        private void cmbDaysBorrow_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionBorrow where DateBorrow Like  '%" + cmbDaysBorrow.Text + "%' ", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];
        }

        private void cmbDaysReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from TransactionReturn where DateBorrow Like  '%" + cmbDaysReturn.Text + "%' ", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvReturn.DataSource = ds.Tables[0];
        }
    }
}
