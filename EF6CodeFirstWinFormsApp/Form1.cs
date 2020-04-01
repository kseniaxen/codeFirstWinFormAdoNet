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
    }
}
