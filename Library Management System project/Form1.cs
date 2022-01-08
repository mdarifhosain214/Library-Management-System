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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textuserid_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void textuserid_MouseClick(object sender, MouseEventArgs e)
        {
            if (textuserid.Text == "User ID :")
            {
                textuserid.Clear();
            }
        }

        private void textpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (textpassword.Text == "Password :")
                textpassword.Clear();
            textpassword.PasswordChar = '*';

        }

        private void btnlogin(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-FI65JP3\\SQLEXPRESS;database =Library_Management_System;integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText="select* from login_table where userid='"+textuserid.Text+"' and pass='"+textpassword.Text+"'";
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            Da.Fill(DS);
            if(DS.Tables[0].Rows.Count !=0)
            {
               this.Hide();
               Dasboard db = new Dasboard();
               db.Show();
            }
            else
            {
                MessageBox.Show("Wrong User ID Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textuserid.Clear();
                textpassword.Clear();
            }
        }
    }
}
