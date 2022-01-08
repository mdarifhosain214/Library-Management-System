using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class Dasboard : Form
    {
        public Dasboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adding_books addbook = new Adding_books();
            addbook.Show();
        }

       

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStudent ads = new addStudent();
            ads.Show();
        }

        private void viewStudentsInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewstudent vs = new Viewstudent();
                vs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Viewbook Vb = new Viewbook();
            Vb.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issuebook Is = new Issuebook();
            Is.Show();
            
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_book RB = new Return_book();
            RB.Show();
        }

        private void completeBooksDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Complete_book_details CBD = new Complete_book_details();
            CBD.Show();
        }

        private void Dasboard_Load(object sender, EventArgs e)
        {

        }
    }
}
