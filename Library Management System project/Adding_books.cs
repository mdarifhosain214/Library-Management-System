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
    public partial class Adding_books : Form
    {
        public Adding_books()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {

            if (textbookname.Text != "" && textauthorname.Text != "" && textbookpublication.Text != "" && dateTimePicker1.Text != "" && textprice.Text != "" && textbookquantity.Text != "")
            { string bookname = textbookname.Text;
                string bookathourname = textauthorname.Text;
                string bookpublication = textbookpublication.Text;
                string publicationdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(textprice.Text);
                Int64 quan = Int64.Parse(textbookquantity.Text);


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                con.Open();
                cmd.CommandText = "insert into addbook (book_name,book_autor_name, book_publication,book_publication_date,book_price,book_quantity) values ('" + bookname + "','" + bookathourname + "','" + bookpublication + "','" + publicationdate + "','" + price + "','" + quan + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textbookname.Clear();
                textauthorname.Clear();
                textbookpublication.Clear();
                textprice.Clear();
                textbookquantity.Clear();

            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbookname.Clear();
                textauthorname.Clear();
                textbookpublication.Clear();
                textprice.Clear();
                textbookquantity.Clear();
            }
           

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void Adding_books_Load(object sender, EventArgs e)
        {

        }
    }
}
