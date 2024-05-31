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

namespace odev5
{
    public enum MovieCategory
    {
        Aksiyon,
        Komedi,
        Drama,
        Korku,
        BilimKurgu,
        Gerilim,
        Romantik,
        Animasyon,

    }

    public enum AgeRating
    {
        TümYaşlar,
        Çocuklar,
        EbeveynGözetimi,
        Genç,
        Yetişkin

    }
    public partial class user : Form
    {
        public ReadFilm reader = new ReadFilm("Filmler");
        //getirme sınıfı
        private WriteFilm writer = new WriteFilm("Filmler");
        int index = 0;
        public user()
        {

            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(MovieCategory));
            comboBox2.DataSource = Enum.GetValues(typeof(AgeRating));
        }







        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void user_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < reader.Filim_adi.Count; i++)
            {
                dataGridView1.Rows.Add(reader.Filim_adi[i], reader.Film_turu[i],
                    reader.Yas_sinir[i], reader.Film_yapim[i], reader.Film_dili[i]);

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                writer.ekle(textBox3.Text, comboBox1.Text, comboBox2.Text, textBox4.Text, textBox5.Text);
                dataGridView1.Rows.Add(textBox3.Text, comboBox1.Text, comboBox2.Text, textBox4.Text, textBox5.Text);
                dataGridView1.Refresh();
                clearboxes();
                MessageBox.Show("Ekledi");
            }

        }

        void clearboxes() {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                writer.guncell(reader.ara(textBox3.Text), textBox3.Text, comboBox1.Text, comboBox2.Text, textBox4.Text, textBox5.Text);
                DataGridViewRow row = dataGridView1.Rows[index];

             
                row.Cells[0].Value = textBox3.Text;
                row.Cells[1].Value = comboBox1.Text;
                row.Cells[2].Value = comboBox2.Text;
                row.Cells[3].Value = textBox4.Text;
                row.Cells[4].Value = textBox5.Text;
                dataGridView1.Refresh();

                clearboxes();
                MessageBox.Show("güncelldi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                writer.sil(textBox3.Text);
                dataGridView1.Rows.RemoveAt(index);
                dataGridView1.Refresh();
                clearboxes();
                MessageBox.Show("Sildi");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null) { 
            index = e.RowIndex;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
