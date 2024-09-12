using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ALBUM
{
    public partial class Form1 : Form
    {
        BindingSource albumbindingSource = new BindingSource();
        BindingSource highlightsbindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dao albumsdao = new dao();

            //connect the list and the grid view
            albumbindingSource.DataSource = albumsdao.getAllAlbums();
            dataGridView1.DataSource = albumbindingSource;
            // for showing pictures
            pictureBox1.Load("https://th.bing.com/th/id/R.10b2f6d95195994fca386842dae53bb2?rik=L1ia54tpAs8maQ&riu=http%3a%2f%2fi.stack.imgur.com%2fwD3lC.png&ehk=qINJQV1LNqNQCfaLiR593%2bFVfdRvPv4KFeREKYHX7m0%3d&risl=&pid=ImgRaw&r=0&sres=1&sresct=1");
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dao albumsdao = new dao();

            //connect the list and the grid view
            albumbindingSource.DataSource = albumsdao.searchTitles(textBox1.Text);
            dataGridView1.DataSource = albumbindingSource;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int rowClicked = dataGridView.CurrentRow.Index;
            //MessageBox.Show("you clicked" + rowClicked);
            String image = dataGridView.Rows[rowClicked].Cells[4].Value.ToString();
            //MessageBox.Show("URL" + image);
            pictureBox1.Load(image);

            dao albumsdao = new dao();
            highlightsbindingSource.DataSource = albumsdao.getHighlights((int)dataGridView.Rows[rowClicked].Cells[0].Value);
            dataGridView2.DataSource = highlightsbindingSource;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //add a new item to the database
            Album album = new Album
            {
                memory_name = txt_memory.Text,
                person = txt_person.Text,
                Year = Int32.Parse(txt_year.Text),
                image = txt_image.Text,
                description = txt_description.Text,
            };
            dao albumsdao = new dao();
            int result = albumsdao.addOneAlbum(album);
            MessageBox.Show(result + " new row(s) inserted");
        }
    }
}
        
    

