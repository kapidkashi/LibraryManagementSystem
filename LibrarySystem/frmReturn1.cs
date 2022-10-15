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
    public partial class frmReturn1 : Form
    {
        SQLiteConnection con = new SQLiteConnection(@"Data Source = LibraryDB.db; Version = 3; New = False; Compress = True");
        SQLiteCommand cm = new SQLiteCommand();

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        private SQLiteDataAdapter DBBook;
        private DataSet DSBook = new DataSet();
        private DataTable DTBook = new DataTable();

        private SQLiteDataAdapter DBBorrow;
        private DataSet DSBorrow = new DataSet();
        private DataTable DTBorrow = new DataTable();

        private SQLiteDataAdapter DBReturn;
        private DataSet DSReturn = new DataSet();
        private DataTable DTReturn = new DataTable();

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

            //string CommandText = "Select * from Books";
            //DBBook = new SQLiteDataAdapter(CommandText, sql_con);
            //DSBook.Reset();
            //DBBook.Fill(DSBook);
            //DTBook = DSBook.Tables[0];
            //dgvBook.DataSource = DTBook;

            string CommandTextBorrow = "Select * from BorrowBooks";
            DBBorrow = new SQLiteDataAdapter(CommandTextBorrow, sql_con);
            DSBorrow.Reset();
            DBBorrow.Fill(DSBorrow);
            DTBorrow = DSBorrow.Tables[0];

            dgvBorrow.DataSource = DTBorrow;


            string CommandTextReturn = "Select * from ReturnBooks";
            DBReturn = new SQLiteDataAdapter(CommandTextReturn, sql_con);
            DSReturn.Reset();
            DBReturn.Fill(DSReturn);
            DTReturn = DSReturn.Tables[0];

            dgvReturn.DataSource = DTReturn;




            sql_con.Close();

        }

        private void ReturnID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBBorrowID = new SQLiteDataAdapter("select ReturnBookID from ReturnBooks order by ReturnBookID desc", sql_con);
                DataSet DSBorrowID = new DataSet();
                DBBorrowID.Fill(DSBorrowID);
                if (DSBorrowID.Tables[0].Rows.Count > 0)
                {
                    txtAuto.Text = DSBorrowID.Tables[0].Rows[0]["ReturnBookID"].ToString();
                }
                else
                {
                    txtAuto.Text = "RTRN0000";
                }
                if (!string.IsNullOrEmpty(txtAuto.Text))
                {
                    txtAuto.SelectionStart = 4;
                    txtAuto.SelectionLength = 5;
                    lblAuto.Text = txtAuto.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAuto.Text))
                {
                    int ID = int.Parse(lblAuto.Text.ToString()) + 1;
                    txtReturnID.Text = ID.ToString("RTRN0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }

        public frmReturn1()
        {
            InitializeComponent(); 
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string textQuery2 = "Delete from BorrowBooks where BorrowBookID ='" + txtBorrowID.Text + "'";
            ExecuteQuery(textQuery2);

            sql_cmd = new SQLiteCommand("UPDATE Books SET BookQty=(BookQty+@BookQty) WHERE BookID LIKE '" + txtBookID.Text + "'", sql_con);
            sql_cmd.Parameters.AddWithValue("@BookQty", Convert.ToInt16(nudQty.Value));
            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            string txtQuery = "insert into ReturnBooks (ReturnBookID,BorrowBookID,StudentID,StudentName,Contact,BookID,BookTitle,BookAuthor," +
                "BookSection,BookQty,DateBorrow,LibrarianBorrow,BorrowDays,PenaltyBorrow,DateReturn,LibrarianReturn,ReturnDays,Penalty) values" +
               "('" + txtReturnID.Text + "','" + txtBorrowID.Text + "','" + txtStudentID.Text + "','" + txtStudentName.Text + "','" + txtContact.Text + "'," +
               "'" + txtBookID.Text + "','" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + txtBookSection.Text + "','" + nudQty.Value + "'," +
               "'" + dtpBorrow.Text + "','" + lblLibBorrow.Text + "','" + txtAvailableDays.Text + "','" + txtExceedingDay.Text + "','" + dtpReturn.Text + "','" + lblLibReturn.Text + "','" + txtReturnDays.Text + "','" + txtPenalty.Text + "')";
            ExecuteQuery(txtQuery);

            string txtQuery1 = "insert into TransactionReturn (ReturnBookID,StudentID,StudentName,ContactNumber,BookID,BookTitle,BookAuthor," +
               "BookSection,BookQty,DateBorrow,LibrarianBorrow,DateReturn,LibrarianReturn,ReturnDays,Penalty) values" +
              "('" + txtReturnID.Text +  "','" + txtStudentID.Text + "','" + txtStudentName.Text + "','" + txtContact.Text + "'," +
              "'" + txtBookID.Text + "','" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + txtBookSection.Text + "','" + nudQty.Value + "'," +
              "'" + dtpBorrow.Text + "','" + lblLibBorrow.Text + "','" + dtpReturn.Text + "','" + lblLibReturn.Text + "','" + txtReturnDays.Text + "','" + txtPenalty.Text + "')";
            ExecuteQuery(txtQuery1);

       
            
          
            LoadData();
            ReturnID();
            Clear();
        }

        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvBorrow.Rows[e.RowIndex];
            txtBorrowID.Text = dr.Cells[0].Value.ToString();
            txtStudentID.Text = dr.Cells[1].Value.ToString();
            txtStudentName.Text = dr.Cells[2].Value.ToString();
            txtContact.Text = dr.Cells[3].Value.ToString();
            txtBookID.Text = dr.Cells[4].Value.ToString();
            txtBookName.Text = dr.Cells[5].Value.ToString();
            txtBookAuthor.Text = dr.Cells[6].Value.ToString();
            txtBookSection.Text = dr.Cells[7].Value.ToString();
            nudQty.Value = Convert.ToInt32(dr.Cells[8].Value.ToString());
            dtpBorrow.Text = dr.Cells[9].Value.ToString();
            lblLibBorrow.Text = dr.Cells[10].Value.ToString();
            txtAvailableDays.Text = dr.Cells[11].Value.ToString();
            txtExceedingDay.Text = dr.Cells[12].Value.ToString();

            int daysPenalty = 0;
            int.TryParse(txtExceedingDay.Text, out daysPenalty);
            int AvailableDays = 0;
            int.TryParse(txtAvailableDays.Text, out AvailableDays);
            int days = Convert.ToInt32(txtReturnDays.Text);

            int exceedingDays, penalty;

            if (AvailableDays <= days)
            {
                exceedingDays = days - AvailableDays;

                for (int i = 0; i < exceedingDays; i++)
                {
                    penalty = exceedingDays * daysPenalty;
                    txtPenalty.Text = (penalty).ToString();
                }

            }
        }

        private void dgvReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvReturn.Rows[e.RowIndex];
            txtReturnID.Text = dr.Cells[0].Value.ToString();
            txtBorrowID.Text = dr.Cells[1].Value.ToString();
            txtStudentID.Text = dr.Cells[2].Value.ToString();
            txtStudentName.Text = dr.Cells[3].Value.ToString();
            txtContact.Text = dr.Cells[4].Value.ToString();
            txtBookID.Text = dr.Cells[5].Value.ToString();
            txtBookName.Text = dr.Cells[6].Value.ToString();
            txtBookAuthor.Text = dr.Cells[7].Value.ToString();
            txtBookSection.Text = dr.Cells[8].Value.ToString();
            nudQty.Value = Convert.ToInt32(dr.Cells[9].Value.ToString());
            dtpBorrow.Value = Convert.ToDateTime(dr.Cells[10].Value.ToString());
            lblLibBorrow.Text = dr.Cells[11].Value.ToString();
            txtAvailableDays.Text = dr.Cells[12].Value.ToString();
            txtExceedingDay.Text = dr.Cells[13].Value.ToString();
            dtpReturn.Value = Convert.ToDateTime(dr.Cells[14].Value.ToString());
            lblLibReturn.Text = dr.Cells[15].Value.ToString();
            txtReturnDays.Text = dr.Cells[16].Value.ToString();
            txtPenalty.Text = dr.Cells[17].Value.ToString();

        }

        private void dtpBorrow_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dtpBorrow.Value.ToString();
            DateTime dt1 = Convert.ToDateTime(date1);

            string date2 = dtpReturn.Value.ToString();
            DateTime dt2 = Convert.ToDateTime(date2);

            int days;
            days = (dt2 - dt1).Days;
            txtReturnDays.Text = String.Format("{0:0}", days);

         
        }

        private void txtSearchBorrow_TextChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from BorrowBooks where BookTitle Like  '%" + txtSearchBorrow.Text + "%' or BookAuthor Like'%" + txtSearchBorrow.Text + "%' or BookSection Like '" + txtSearchBorrow.Text + "%'", con);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvBorrow.DataSource = ds.Tables[0];

        }

        public string getLibReturn { get; set; }
        private void frmReturn1_Load(object sender, EventArgs e)
        {
            lblLibReturn.Text = getLibReturn;
            LoadData();
            ReturnID();
        }

        private void dtpReturn_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dtpBorrow.Value.ToString();
            DateTime dt1 = Convert.ToDateTime(date1);

            string date2 = dtpReturn.Value.ToString();
            DateTime dt2 = Convert.ToDateTime(date2);

            int days;
            days = (dt2 - dt1).Days;
            txtReturnDays.Text = String.Format("{0:0}", days);

            int daysPenalty = Convert.ToInt32(txtExceedingDay.Text);
            int AvailableDays = Convert.ToInt32(txtAvailableDays.Text);
            int exceedingDays, penalty;

            if (AvailableDays <= days)
            {
                exceedingDays = days - AvailableDays;

                for (int i = 0; i < exceedingDays; i++)
                {
                    penalty = exceedingDays * daysPenalty;
                    txtPenalty.Text = penalty.ToString();
                }
            }

        }

        private void txtReturnDays_TextChanged(object sender, EventArgs e)
        {
            //string date1 = dtpBorrow.Value.ToString();
            //DateTime dt1 = Convert.ToDateTime(date1);

            //string date2 = dtpReturn.Value.ToString();
            //DateTime dt2 = Convert.ToDateTime(date2);

            //int days;
            //days = (dt2 - dt1).Days;
            //txtReturnDays.Text = String.Format("{0:0}", days);

            //int daysPenalty = 0;
            //int.TryParse(txtExceedingDay.Text, out daysPenalty);
            //int AvailableDays = 0;
            //int.TryParse(txtAvailableDays.Text, out AvailableDays);
            //int days = Convert.ToInt32(txtReturnDays.Text);

            //int exceedingDays, penalty;

            //if (AvailableDays <= days)
            //{
            //    exceedingDays = days - AvailableDays;

            //    for (int i = 0; i < exceedingDays; i++)
            //    {
            //        penalty = exceedingDays * daysPenalty;
            //        txtPenalty.Text = (penalty).ToString();
            //    }

            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string textQuery = "Delete from ReturnBooks where BorrowBookID ='" + txtBorrowID.Text + "'";
            ExecuteQuery(textQuery);
            string textQueryBorrow = "Delete from TransactionReturn where BorrowBookID ='" + txtBorrowID.Text + "'";
            ExecuteQuery(textQueryBorrow);
            string txtQuery3 = "insert into BorrowBooks (BorrowBookID,StudentID,StudentName,ContactNumber,BookID,BookTitle,BookAuthor,BookSection,BookQty,DateBorrow,LibrarianBorrow,BorrowDays,Penalty) values" +
                  "('" + txtBorrowID.Text + "','" + txtStudentID.Text + "','" + txtStudentName.Text + "','" + txtContact.Text + "'," +
                  "'" + txtBookID.Text + "','" + txtBookName.Text + "','" + txtBookAuthor.Text + "','" + txtBookSection.Text + "','" + nudQty.Value + "','" + dtpBorrow.Text + "','" + lblLibBorrow.Text + "','" + txtAvailableDays.Text + "','" + txtExceedingDay.Text + "')";
           ExecuteQuery(txtQuery3);

            sql_cmd = new SQLiteCommand("UPDATE Books SET BookQty=(BookQty+@BookQty) WHERE BookID LIKE '" + txtBookID.Text + "'", sql_con);
            sql_cmd.Parameters.AddWithValue("@BookQty", Convert.ToInt16(nudQty.Value));
            sql_con.Open();
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            LoadData();
            Clear();
        }

        private void Clear()
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
            txtContact.Clear();
            txtBookID.Clear();
            txtBookName.Clear();
            txtBookAuthor.Clear();
            txtBookSection.Clear();
            nudQty.Value =  0;
            txtExceedingDay.Clear();
            txtPenalty.Clear();
            txtReturnDays.Clear();
            txtPenalty.Clear();
            ReturnID();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtAvailableDays_TextChanged(object sender, EventArgs e)
        {
            int daysPenalty = 0;
            int.TryParse(txtExceedingDay.Text, out daysPenalty);
            int AvailableDays = 0;
            int.TryParse(txtAvailableDays.Text, out AvailableDays);
            int days = Convert.ToInt32(txtReturnDays.Text);

            int exceedingDays, penalty;

            if (AvailableDays <= days)
            {
                exceedingDays = days - AvailableDays;

                for (int i = 0; i < exceedingDays; i++)
                {
                    penalty = exceedingDays * daysPenalty;
                    txtPenalty.Text = (penalty).ToString();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchReturn_TextChanged(object sender, EventArgs e)
        {
            cm = new SQLiteCommand("select * from ReturnBooks where StudentID Like  '%" + txtSearchReturn.Text + "%' or StudentName Like  '" + txtSearchReturn.Text + "%' or BookTitle Like  '" + txtSearchReturn.Text + "%' or BookAuthor Like'%" + txtSearchReturn.Text + "%' or BookSection Like '" + txtSearchReturn.Text + "%' or LibrarianBorrow Like '" + txtSearchReturn.Text + "%' or LibrarianReturn Like '" + txtSearchReturn.Text + "%' or DateBorrow Like '" + txtSearchReturn.Text + "%' or DateReturn Like '" + txtSearchReturn.Text + "%'", con); ;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvReturn.DataSource = ds.Tables[0];
        }
    }
}
