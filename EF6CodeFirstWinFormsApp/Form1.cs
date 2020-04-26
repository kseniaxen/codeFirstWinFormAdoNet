using EF6CodeFirstWinFormsApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF6CodeFirstWinFormsApp
{
    public partial class Form1 : Form
    {
        private BindingList<Author> authorsBL
            = new BindingList<Author>();
        private BindingList<Publisher> publisherBL
           = new BindingList<Publisher>();
        private BindingList<Book> bookBL
           = new BindingList<Book>();
        public string title, idAuth, pages, price, idPubl;
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = authorsBL;

            using (LibraryContext db = new LibraryContext())
            {
                db.Authors.ToList().ForEach(
                    a => authorsBL.Add(a)
                );
            }

            dataGridView2.DataSource = publisherBL;
            dataGridView3.DataSource = bookBL;
            using (LibraryContext db = new LibraryContext())
            {
                db.Publishers.ToList().ForEach(
                    a => publisherBL.Add(a)
                );
                db.Books.ToList().ForEach(
                    a => bookBL.Add(a)
                );
            }

            /* Author author = new Author
            {
                FirstName = "Isaac",
                LastName = "Azimov" 
            };
            using (LibraryContext db = new LibraryContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                var ac = db.Authors.ToList();
                foreach (var a in ac)
                {
                    Console.WriteLine(a.FirstName + " " + a.LastName);
                }
            } */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Author author =
                    db.Authors.Add(
                        new Author() { FirstName = textBox1.Text, LastName = textBox2.Text }
                    );
                db.SaveChanges();
                authorsBL.Add(author);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Publisher publisher =
                    db.Publishers.Add(
                        new Publisher() { PublisherName = textBox4.Text, Address = textBox3.Text }
                    );
                db.SaveChanges();
                publisherBL.Add(publisher);
            }
        }

        private void dataGridView3_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            title = (dataGridView3.Rows[e.RowIndex].Cells["Title"].Value).ToString();
            idAuth = (dataGridView3.Rows[e.RowIndex].Cells["AuthorId"].Value).ToString();
            pages = (dataGridView3.Rows[e.RowIndex].Cells["Pages"].Value).ToString();
            price = (dataGridView3.Rows[e.RowIndex].Cells["Price"].Value).ToString();
            idPubl = (dataGridView3.Rows[e.RowIndex].Cells["PublisherId"].Value).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Book book =
                    db.Books.Add(
                        new Book() { AuthorId = Int32.Parse(idAuth), Pages = Int32.Parse(pages), PublisherId = Int32.Parse(idPubl), Price = Int32.Parse(price), Title = title }
                    );
                db.SaveChanges();
                bookBL.Add(book);
            }
        }
    }
}
