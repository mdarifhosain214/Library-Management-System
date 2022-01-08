using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class Return_book : Form
    {
        public Return_book()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textEnroll.Text!="")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnsearchstudent_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText= "select * from IR_book where std_enroll= '"+textEnroll.Text+"' and book_return_date Is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            
            if (ds.Tables[0].Rows.Count!=0)
           {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Enrollment No Or No Book Issue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEnroll.Clear();
            }
        }

        private void Return_book_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textEnroll.Clear();
        }
        string bname;
        string bdate;
        Int64 rowid;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            textBookname.Text = bname;
            textBookissuedate.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IR_book set book_return_date= '" + dateTimePicker1.Text + "' where std_enroll ='" + textEnroll.Text + "' and id ='" + rowid + "'";
            cmd.ExecuteNonQuery();
            con.Close(); 

            MessageBox.Show("Return Book Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Return_book_Load(this, null);
            // textEnroll.Clear();
            // textBookname.Clear();
            // textBookissuedate.Clear();
            panel2.Visible = false;


        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            textEnroll.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
