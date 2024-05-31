using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace odev5
{
    public partial class Home : Form
    {
        ReadKisi reader1 = new ReadKisi("Kisiler");
        ReadFilm reader2 = new ReadFilm("Filmler");
        WriteFilm writer2 = new WriteFilm("Filmler");
        //getirme sınıfı
        WriteKisi writer = new WriteKisi("Kisiler");
        int index = 0;
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[index].Cells[4].Value.ToString() == "İade edilen ürün") {
                MessageBox.Show("Ödeledi");
            }
            else { 
            writer2.guncell(reader2.ara(textBox1.Text), 2);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("Ödeme yapıldı");
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < reader1.Filim_adi.Count; i++)
            {
                DateTime d = Convert.ToDateTime(reader1.tarih[i]);
                TimeSpan difference = DateTime.Now - d;

                int Gunsayisi = difference.Days + 1;
                

                int toplamaUcert = Gunsayisi * Convert.ToInt32(reader1.GnulukUcert[i]);


                dataGridView1.Rows.Add(reader1.Filim_adi[i], reader1.Kisi_adi[i],
                    Gunsayisi, toplamaUcert, reader2.durum[reader2.ara(reader1.Filim_adi[i])]);

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                index = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
