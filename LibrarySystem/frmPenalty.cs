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
    public partial class frmPenalty : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBPenalty;
        private DataSet DSPenalty = new DataSet();
        private DataTable DTPenalty = new DataTable();
        public frmPenalty()
        {
            InitializeComponent();
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

            string CommandTextSection = "Select * from Penalty";
            DBPenalty = new SQLiteDataAdapter(CommandTextSection, sql_con);
            DSPenalty.Reset();
            DBPenalty.Fill(DSPenalty);
            DTPenalty = DSPenalty.Tables[0];

            dgvPenalty.DataSource = DTPenalty;


            sql_con.Close();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string textQuery = "insert into Penalty(BorrowDays,PenaltyExceedDays) values('" + txtBorrowDays.Text + "','" + txtPenalty.Text + "')";
            ExecuteQuery(textQuery);
            LoadData();
        }

        private void frmPenalty_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string textQuery = "Update Penalty set BorrowDays = '" + txtBorrowDays.Text + "',PenaltyExceedDays ='" + txtPenalty.Text + "'where BorrowDays = '"+txtBorrowDays.Text+"'";
            ExecuteQuery(textQuery);
            LoadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string textQuery = "delete from Penalty where BorrowDays ='" + txtBorrowDays.Text + "'";
            ExecuteQuery(textQuery);
            LoadData();
        }

        private void dgvPenalty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvPenalty.SelectedRows[0];
            txtBorrowDays.Text = dr.Cells[1].Value.ToString();
            txtPenalty.Text = dr.Cells[2].Value.ToString();
         
        }
    }
}
