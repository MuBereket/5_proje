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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace odev5
{
    public partial class Film : Form
    {
        ReadKisi reader1 = new ReadKisi("Kisiler");
        ReadFilm reader2 = new ReadFilm("Filmler");

        //getirme sınıfı
        WriteKisi writer = new WriteKisi("Kisiler");
        WriteFilm writer2 = new WriteFilm("Filmler");

        int index = 0;
        public Film()
        {


            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                int i = reader2.ara(comboBox1.Text);
                if (reader2.durum[i] != "Kiralanan ürün")
                {
                    writer.ekle(comboBox1.Text, textBox2.Text, textBox1.Text, textBox3.Text);
                    writer2.guncell(i,1);
                    dataGridView1.Rows.Add(comboBox1.Text, textBox2.Text, textBox1.Text, DateTime.Now, textBox3.Text);
                    dataGridView1.Refresh();
                    textBox3.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Ekledi");
                }
                else
                    MessageBox.Show("Bu ürün şu anda mevcut değil");
            }
            reader2 = new ReadFilm("Filmler");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Film_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = reader2.Filim_adi;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < reader1.Filim_adi.Count; i++)
            {
                dataGridView1.Rows.Add(reader1.Filim_adi[i], reader1.Kisi_adi[i],
                    reader1.Telefon_no[i], reader1.tarih[i], reader1.GnulukUcert[i]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                writer.guncell(reader1.ara(comboBox1.Text), comboBox1.Text, textBox2.Text, textBox1.Text, textBox3.Text);
                DataGridViewRow row = dataGridView1.Rows[index];

               
                row.Cells[0].Value = comboBox1.Text;
                row.Cells[1].Value = textBox2.Text;
                row.Cells[2].Value = textBox1.Text;
                row.Cells[4].Value = textBox3.Text;
                dataGridView1.Refresh();

                textBox3.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("güncelldi");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                int i = reader2.ara(comboBox1.Text);
                writer2.guncell(i, 2);
                writer.sil(comboBox1.Text);
                dataGridView1.Rows.RemoveAt(index);
                dataGridView1.Refresh();
                textBox3.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Sildi");
                reader2= new ReadFilm("Filmler"); 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                index = e.RowIndex;
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
