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
    public partial class frmBooks : Form
    {
        SQLiteConnection con = new SQLiteConnection(@"Data Source = Finals.db; Version = 3; New = False; Compress = True");
        SQLiteCommand cm = new SQLiteCommand();

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

            string CommandTextSection = "Select * from BookSection";
            DBSection = new SQLiteDataAdapter(CommandTextSection, sql_con);
            DSSection.Reset();
            DBSection.Fill(DSSection);
            DTSection = DSSection.Tables[0];
            frmBookSection fbs = new frmBookSection();
            fbs.dgvBookSection.DataSource = DTSection;

            cmbSection.DataSource = DTSection;
            cmbSection.DisplayMember = "BookSection";
            cmbSection.ValueMember = "SectionID";

            string CommandTextPenalty = "Select * from Penalty";
            DBPenalty = new SQLiteDataAdapter(CommandTextPenalty, sql_con);
            DSPenalty.Reset();
            DBPenalty.Fill(DSPenalty);
            DTPenalty = DSPenalty.Tables[0];
            frmPenalty fp = new frmPenalty();
            fp.dgvPenalty.DataSource = DTPenalty;

            cmbPenalty.DataSource = DTPenalty;
            cmbPenalty.DisplayMember = "BorrowDays";
            cmbPenalty.ValueMember = "PenaltyID";



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

            sql_cmd.CommandText = "select *from Penalty where BorrowDays=@BorrowDays";
            sql_cmd.Parameters.AddWithValue("@BorrowDays", cmbPenalty.SelectedValue);
            DTBind = new DataTable();
            DBBind = new SQLiteDataAdapter();
            cmd.DataAdapter = DBBind;

            DBBind.SelectCommand = sql_cmd;
            DBBind.Fill(DTBind);
            DTPenalty.AcceptChanges();
            txtPenalty.DataBindings.Clear();
            txtPenalty.DataBindings.Add("Text", DTPenalty, "PenaltyExceedDays", false, DataSourceUpdateMode.OnPropertyChanged);

            sql_con.Close();

        }

        public frmBooks()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnAddBookSection_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmBookSection")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmBookSection fbs = new frmBookSection();
                fbs.Show();
            }
            
        }

        private void btnAddPenalty_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "frmPenalty")
                {
                    IsOpen = true;
                    f.BringToFront();
                    break;
                }

            }

            if (IsOpen == false)
            {
                frmPenalty fp = new frmPenalty();
                fp.Show();
            }
         
        }
        private void BookID()
        {
            SetConnection();
            try
            {
                SQLiteDataAdapter DBBookID = new SQLiteDataAdapter("select BookID from Books order by BookID desc", sql_con);
                DataSet DSBookID = new DataSet();
                DBBookID.Fill(DSBookID);
                if (DSBookID.Tables[0].Rows.Count > 0)
                {
                    txtAutoID.Text = DSBookID.Tables[0].Rows[0]["BookID"].ToString();
                }
                else
                {
                    txtAutoID.Text = "BOOK0000";
                }
                if (!string.IsNullOrEmpty(txtAutoID.Text))
                {
                    txtAutoID.SelectionStart = 4;
                    txtAutoID.SelectionLength = 5;
                    lblAutoID.Text = txtAutoID.SelectedText;
                }
                if (!string.IsNullOrEmpty(lblAutoID.Text))
                {
                    int ID = int.Parse(lblAutoID.Text.ToString()) + 1;
                    txtBookID.Text = ID.ToString("BOOK0000");
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show(ab.Message);
            }
        }
        public string getUser { get; set; }
        private void frmBooks_Load(object sender, EventArgs e)
        {
            LoadData();
            lblLibrarian.Text = getUser;
            Bind();
            BookID();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string textQuery = "insert into Books (BookID,BookTitle,BookAuthor,BookSection,BookQty,BorrowDays,Penalty) values" +
                "('"+txtBookID.Text+"','"+txtTitle.Text+"','"+txtAuthor.Text+"','"+cmbSection.Text+"','"+txtQty.Text+"','"+cmbPenalty.Text+"','"+txtPenalty.Text+"')";

            ExecuteQuery(textQuery);
            LoadData();
            BookID();
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string txtQuery = "Update Books set BookID='" + txtBookID.Text + "', BookTitle='" + txtTitle.Text + "',BookAuthor = '" + txtAuthor.Text + "',BookSection= '" + cmbSection.Text + "'," +
         "BookQty= '" + txtQty.Text + "',BorrowDays= '" + cmbPenalty.Text + "', Penalty= '" + txtPenalty.Text + "' where BookID = '" + txtBookID.Text + "'";

            ExecuteQuery(txtQuery);
            LoadData();
            Clear();
            BookID();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string textQuery = "Delete from Books where BookID ='" + txtBookID.Text + "'";
            ExecuteQuery(textQuery);
            LoadData();
            BookID();
            Clear();
        }
        private void Clear()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtTitle.Clear();
          
            txtQty.Clear();
            
            

        }

        private void btnRefreshSection_Click(object sender, EventArgs e)
        {
            LoadData();
            Bind();
        }

        private void btnRefreshBorrow_Click(object sender, EventArgs e)
        {
            LoadData();
            Bind();
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvBooks.SelectedRows[e.RowIndex];
            txtBookID.Text = dr.Cells[0].Value.ToString();
            txtTitle.Text = dr.Cells[1].Value.ToString();
            txtAuthor.Text = dr.Cells[2].Value.ToString();
            cmbSection.Text = dr.Cells[3].Value.ToString();
            txtQty.Text = dr.Cells[4].Value.ToString();
            cmbPenalty.Text = dr.Cells[5].Value.ToString();
            txtPenalty.Text = dr.Cells[6].Value.ToString();
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            BookID();   
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sql_cmd = new SQLiteCommand("select * from Books where BookTitle Like  '" + txtSearch.Text + "%' or BookAuthor Like'%" + txtSearch.Text + "%' or BookSection Like '" + txtSearch.Text + "%'", sql_con);
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBooks.DataSource = ds.Tables[0];


                //sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
                //sql_cmd.Connection = sql_con;
                //sql_cmd.CommandText = "select * from Books where BookTitle Like  '" + txtSearch.Text + "%' or BookAuthor Like'%" + txtSearch.Text + "%' or BookSection Like '" + txtSearch.Text + "%'";
                //SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //dgvBooks.DataSource = ds.Tables[0];
            }
            else
            {
                sql_con.ConnectionString = "Data Source = LibraryDB.db ; Version = 3; New = False; Compress = True";
                sql_cmd.Connection = sql_con;

                sql_cmd.CommandText = "select * from Books ";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvBooks.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
