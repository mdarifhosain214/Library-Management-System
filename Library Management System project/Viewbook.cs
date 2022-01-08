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
    public partial class Viewbook : Form
    {
        public Viewbook()
        {
            InitializeComponent();
        }

        private void Viewbook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "select * from addbook";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Viewbook_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addbook where book_name like '" + textBookName.Text + "%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addbook";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        int book_ID;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                panel2.Visible = true;
                book_ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                panel2.Visible = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from addbook where book_ID= " + book_ID + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                textBname.Text = ds.Tables[0].Rows[0][1].ToString();
                textBauthor.Text = ds.Tables[0].Rows[0][2].ToString();
                textBpublication.Text = ds.Tables[0].Rows[0][3].ToString();
                dateTimePicker1.Text = ds.Tables[0].Rows[0][4].ToString();
                textBprice.Text = ds.Tables[0].Rows[0][5].ToString();
                textBquantity.Text = ds.Tables[0].Rows[0][6].ToString();
                
            }
        }

        private void btlcancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBookName.Text = "";
           // panel2.Visible = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (textBname.Text != "" && textBauthor.Text != "" && textBpublication.Text != "" && dateTimePicker1.Text != "" && textBprice.Text != "" && textBquantity.Text != "")
            {
                if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string bname = textBname.Text;
                    string bauthor = textBauthor.Text;
                    string bpublication = textBpublication.Text;
                    string bpurchase = dateTimePicker1.Text;
                    Int64 bprice = Int64.Parse(textBprice.Text);
                    Int64 bquantity = Int64.Parse(textBquantity.Text);

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;


                    cmd.CommandText = "Update addbook set book_name='" + bname + "',book_autor_name='" + bauthor + "',book_publication='" + bpublication + "',book_publication_date='" + bpurchase + "',book_price='" + bprice + "',book_quantity='" + bquantity + "' where book_ID ='" + rowid + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DA.Fill(ds);

      
                }

            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted.Confirm?", "Confirmermation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "delete addbook where book_ID='" + rowid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DA.Fill(ds);
            }
        }
    }
}
