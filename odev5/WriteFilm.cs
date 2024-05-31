using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    public class WriteFilm : Write
    {
        //Bu sınıfın işlevi depolama yapmaktır
        //ya silin yada ekleyin

        //İşte dosya yolu
        public string cs { get; set; }
        public string isim { get; set; }
        public string path { get; set; }

        public StreamWriter sw { get; set; }
        public bool varmi { get; set; }

        ReadFilm reader;

        public WriteFilm(string isim) :base(isim)
        {
            this.varmi = false;
            //Bu Oluşturucunun işlevi, verileri getirme yolunu tanımlamaktır.
            this.path = @"DateBase\";
            this.isim = isim;
            this.cs = isim + ".csv";
            this.reader = new ReadFilm(isim);
        }
        public void ekle(String adi, String turu, String sinir, String yapim, String dil)
        {
            //Bu Ekleme İşlevi,  dosyaya editörler ve yazarlar için ad ve soyadı ekler
            reader.Filim_adi.Add(adi);
            reader.Film_turu.Add(turu);
            reader.Yas_sinir.Add(sinir);
            reader.Film_yapim.Add(yapim);
            reader.Film_dili.Add(dil);
            reader.durum.Add("İade edilen ürün");


            kaydetmek();
        }
        public void sil(string a)
        {
            //Bu Silme İşlevi,  dosyaya editörler ve yazarlar için ad ve soyadı siler
            int index = reader.Filim_adi.IndexOf(a);
            if (index == -1)
            {
                varmi = false;
            }
            else
            {
                reader.Filim_adi.RemoveAt(index);
                reader.Film_turu.RemoveAt(index);
                reader.Yas_sinir.RemoveAt(index);
                reader.Film_yapim.RemoveAt(index);
                reader.Film_dili.RemoveAt(index);
                reader.durum.RemoveAt(index);

                kaydetmek();
                varmi = true;
            }
        }

        public void guncell(int index, String adi, String turu, String sinir, String yapim, String dil)
        {
            reader.Filim_adi[index] = adi;
            reader.Film_turu[index] = turu;
            reader.Yas_sinir[index] = sinir;
            reader.Film_yapim[index] = yapim;
            reader.Film_dili[index] = dil;
            kaydetmek();
        }

        public void guncell(int index, int sec)
        {
            if (sec == 1)
            {
                reader.durum[index] = "Kiralanan ürün";
            }

            else if (sec == 2)
            {
                reader.durum[index] = "İade edilen ürün";
            }
            kaydetmek();
        }

        public void kaydetmek()
        {
            //Bu Kaydetme İşlevi,dosyaya editörler ve yazarlar için ad ve soyadı kaydetir
            sw = new StreamWriter(path + "\\" + cs);
            for (int i = 0; i < reader.Filim_adi.Count; i++)
            {
                sw.WriteLine("{0},{1},{2},{3},{4},{5}", reader.Filim_adi[i], reader.Film_turu[i], reader.Yas_sinir[i]
                    , reader.Film_yapim[i], reader.Film_dili[i], reader.durum[i]);
            }
            sw.Close();
        }
    }
}
