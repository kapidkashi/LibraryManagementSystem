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
    public partial class frmBorrow : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBBook;
        private DataSet DSBook = new DataSet();
        private DataTable DTBook = new DataTable();

        private SQLiteDataAdapter DBBorrow;
        private DataSet DSBorrow = new DataSet();
        private DataTable DTBorrow = new DataTable();

        private SQLiteDataAdapter DBStudent;
        private DataSet DSStudent = new DataSet();
        private DataTable DTStudent = new DataTable();
        //private SQLiteDataAdapter DBPenaltyB;
        //private DataSet DSPenaltyB = new DataSet();
        //private DataTable DTPenaltyB = new DataTable();

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
            dgvBook.DataSource = DTBook;

            string CommandTextSection = "Select * from BorrowBooks";
            DBBorrow = new SQLiteDataAdapter(CommandTextSection, sql_con);
            DSBorrow.Reset();
            DBBorrow.Fill(DSBorrow);
            DTBorrow = DSBorrow.Tables[0];

            dgvBorrow.DataSource = DTBorrow;


            string CommandTextPenalty = "Select * from Student";
            DBStudent = new SQLiteDataAdapter(CommandTextPenalty, sql_con);
            DSStudent.Reset();
            DBStudent.Fill(DSStudent);
            DTStudent = DSStudent.Tables[0];
            frmStudent fp = new frmStudent();
            fp.dgvStudent.DataSource = DTStudent;

            cmbStudentID.DataSource = DTStudent;
            cmbStudentID.DisplayMember = "StudentID";
            cmbStudentID.ValueMember = "StudentID";



            sql_con.Close();

        }


        private SQLiteDataAdapter DBBind;

        private DataTable DTBind;
        private SQLiteCommandBuilder cmd = new SQLiteCommandBuilder();
        private void Bind()
        {

            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();

            sql_cmd.CommandText = "select * from Student where StudentID=@StudentID";
            sql_cmd.Parameters.AddWithValue("@StudentID", cmbStudentID.SelectedValue);
            DTBind = new DataTable();
            DBBind = new SQLiteDataAdapter();
            cmd.DataAdapter = DBBind;

            DBBind.SelectCommand = sql_cmd;
            DBBind.Fill(DTBind);
            DTStudent.AcceptChanges();
            txtStudentName.DataBindings.Clear();
            txtContact.DataBindings.Clear();
            txtStudentName.DataBindings.Add("Text", DTStudent, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            txtContact.DataBindings.Add("Text", DTStudent, "Contact", false, DataSourceUpdateMode.OnPropertyChanged);

            sql_con.Close();

        }
        public frmBorrow()
        {
            InitializeComponent();
        }
        public string getLibBorrow { get; set; }
        private void frmBorrow_Load(object sender, EventArgs e)
        {
            LoadData();
            lblLibrarian.Text = getLibBorrow;
            Bind();
            BorrowID();

        }

        int Qty = 0;
        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvBook.Rows[e.RowIndex];
            txtBookID.Text = dr.Cells[0].Value.ToString();
            txtBookName.Text = dr.Cells[1].Value.ToString();
            txtBookAuthor.Text = dr.Cells[2].Value.ToString();
            txtBookSection.Text = dr.Cells[3].Value.ToString();
            Qty = Convert.ToInt32(dr.Cells[4].Value.ToString());
            txtBorrowDays.Text = dr.Cells[5].Value.ToString();
            txtPenalty.Text = dr.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
                sql_cmd.Connection = sql_con;
                sql_cmd.CommandText = "select * from Books where BookTitle Like  '" + txtSearch.Text + "%' or BookAuthor Like'%" + txtSearch.Text + "%' or BookSection Like '" + txtSearch.Text + "%'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBook.DataSource = ds.Tables[0];
            }
            else
            {
                sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
                sql_cmd.Connection = sql_con;

                sql_cmd.CommandText = "select * from Books ";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBook.DataSource = ds.Tables[0];
            }
        }
        private void BorrowID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBBorrowID = new SQLiteDataAdapter("select BorrowBookID from BorrowBooks order by BorrowBookID desc", sql_con);
                DataSet DSBorrowID = new DataSet();
                DBBorrowID.Fill(DSBorrowID);
                if (DSBorrowID.Tables[0].Rows.Count > 0)
                {
                    txtAuto.Text = DSBorrowID.Tables[0].Rows[0]["BorrowBookID"].ToString();
                }
                else
                {
                    txtAuto.Text = "BRRWD0000";
                }
                if (!string.IsNullOrEmpty(txtAuto.Text))
                {
                    txtAuto.SelectionStart = 5;
                    txtAuto.SelectionLength = 6;
                    lblAuto.Text = txtAuto.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAuto.Text))
                {
                    int ID = int.Parse(lblAuto.Text.ToString()) + 1;
                    txtBorrowID.Text = ID.ToString("BRRWD0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        private void Clear()
        {
            txtBookName.Clear();
            txtBookAuthor.Clear();
            txtBookID.Clear();
            txtBookSection.Clear();
            //txtContact.Clear();
            txtPenalty.Clear();
            txtBorrowDays.Clear();
            nudQty.Value = 0;
            dtpBorrow.ResetText();
            //cmbStudentID.Text = "";
            //txtStudentName.Clear();
        }
        //SQLiteConnection con = new SQLiteConnection(@"Data Source = LibraryDB.db; Version = 3; New = False; Compress = True");
        //SQLiteCommand cm = new SQLiteCommand();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string txtQuery = "insert into BorrowBooks (BorrowBookID,StudentID,StudentName,ContactNumber,BookID,BookTitle,BookAuthor,BookSection,BookQty,DateBorrow,LibrarianBorrow,BorrowDays,Penalty) values" +
               "('" + txtBorrowID.Text + "','" + cmbStudentID.Text + "','" + txtStudentName.Text + "','" + txtContact.Text + "'," +
               "'" + txtBookID.Text + "','" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + txtBookSection.Text + "','" + nudQty.Value + "','" + dtpBorrow.Text + "','" + lblLibrarian.Text + "','" + txtBorrowDays.Text + "','" + txtPenalty.Text + "')";
            ExecuteQuery(txtQuery);

            string txtQueryBorrow= "insert into TransactionBorrow (BorrowBookID,StudentID,StudentName,ContactNumber,BookID,BookTitle,BookAuthor,BookSection,BookQty,DateBorrow,LibrarianBorrow,BorrowDays,Penalty) values" +
               "('" + txtBorrowID.Text + "','" + cmbStudentID.Text + "','" + txtStudentName.Text + "','" + txtContact.Text + "'," +
               "'" + txtBookID.Text + "','" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + txtBookSection.Text + "','" + nudQty.Value + "','" + dtpBorrow.Text + "','" + lblLibrarian.Text + "','" + txtBorrowDays.Text + "','" + txtPenalty.Text + "')";
            ExecuteQuery(txtQueryBorrow);



            sql_cmd = new SQLiteCommand("UPDATE Books SET BookQty=(BookQty-@BookQty) WHERE BookID LIKE '" + txtBookID.Text + "'", sql_con);
            sql_cmd.Parameters.AddWithValue("@BookQty", Convert.ToInt16(nudQty.Value));
            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            LoadData();


            Clear();

            BorrowID();
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    string txtQuery = "Update Books set BookQty= '" + nudQty.Value + "' where BookQty = '" + nudQty.Value + "'";



        //    LoadData();
        //    Clear();


        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentID.SelectedIndex == 0)
            {
                Bind();

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string textQuery = "Delete from BorrowBooks where BorrowBookID ='" + txtBorrowID.Text + "'";
            ExecuteQuery(textQuery);
            string textQueryBorrow = "Delete from TransactionBorrow where BorrowBookID ='" + txtBorrowID.Text + "'";
            ExecuteQuery(textQueryBorrow);

            sql_cmd = new SQLiteCommand("UPDATE Books SET BookQty=(BookQty+@BookQty) WHERE BookID LIKE '" + txtBookID.Text + "'", sql_con);
            sql_cmd.Parameters.AddWithValue("@BookQty", Convert.ToInt16(nudQty.Value));
            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            LoadData();
            BorrowID();
            Clear();
        }

        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvBorrow.Rows[e.RowIndex];
            txtBorrowID.Text = dr.Cells[0].Value.ToString();
            cmbStudentID.Text = dr.Cells[1].Value.ToString();
            txtStudentName.Text = dr.Cells[2].Value.ToString();
            txtContact.Text = dr.Cells[3].Value.ToString();
            txtBookID.Text = dr.Cells[4].Value.ToString();
            txtBookName.Text = dr.Cells[5].Value.ToString();
            txtBookAuthor.Text = dr.Cells[6].Value.ToString();
            txtBookSection.Text = dr.Cells[7].Value.ToString();
            nudQty.Value= Convert.ToInt32(dr.Cells[8].Value.ToString());
            dtpBorrow.Value = Convert.ToDateTime(dr.Cells[9].Value.ToString());
            lblLibrarian.Text = dr.Cells[10].Value.ToString();
            txtBorrowDays.Text = dr.Cells[11].Value.ToString();
            txtPenalty.Text = dr.Cells[12].Value.ToString();
            
        }

        private void nudQty_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nudQty.Value) > Qty)
            {
                MessageBox.Show("No Book left!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;

            }
        }

        private void txtSearchBorrow_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBorrow.Text != "")
            {
                sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
                sql_cmd.Connection = sql_con;
                sql_cmd.CommandText = "select * from BorrowBooks where StudentID Like '" + txtSearchBorrow.Text + "%' or StudentName Like '" + txtSearchBorrow.Text + "%' or BookTitle Like  '%" + txtSearchBorrow.Text + "%' or BookAuthor Like'%" + txtSearchBorrow.Text + "%' or BookSection Like '" + txtSearchBorrow.Text + "%' or LibrarianBorrow Like '" + txtSearchBorrow.Text + "%'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBorrow.DataSource = ds.Tables[0];
            }
            else
            {
                sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
                sql_cmd.Connection = sql_con;

                sql_cmd.CommandText = "select * from BorrowBooks ";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBorrow.DataSource = ds.Tables[0];






            }
        }
    }
}
