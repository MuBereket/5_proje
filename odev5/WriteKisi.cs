using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    internal class WriteKisi : Write
    {
        public string cs { get; set; }
        public string isim { get; set; }
        public string path { get; set; }
        public StreamWriter sw { get; set; }
        public bool varmi { get; set; }
        ReadKisi reader;
       public WriteKisi(String isim): base(isim)
        {
            this.varmi = false;
            //Bu Oluşturucunun işlevi, verileri getirme yolunu tanımlamaktır.
            this.path = @"DateBase\";
            this.isim = isim;
            this.cs = isim + ".csv";
            this.reader = new ReadKisi(isim);
        }
        public void ekle(String adi, String kisi, String Telefon, String ucert)
        {
            //Bu Ekleme İşlevi,  dosyaya editörler ve yazarlar için ad ve soyadı ekler
            reader.Filim_adi.Add(adi);
            reader.Kisi_adi.Add(kisi);
            reader.Telefon_no.Add(Telefon);
            reader.GnulukUcert.Add(ucert);
            reader.tarih.Add(DateTime.Now.ToString());


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
                reader.Kisi_adi.RemoveAt(index);
                reader.Telefon_no.RemoveAt(index);
                reader.GnulukUcert.RemoveAt(index);
                reader.tarih.RemoveAt(index);

                kaydetmek();
                varmi = true;
            }
        }

        public void guncell(int index, String adi, String kisi, String telefon, String ucert)
        {
            reader.Filim_adi[index] = adi;
            reader.Kisi_adi[index] = kisi;
            reader.Telefon_no[index] = telefon;
            reader.GnulukUcert[index] = ucert;
            reader.tarih[index] = DateTime.Now.ToString();
            kaydetmek();
        }

        private void kaydetmek()
        {
            //Bu Kaydetme İşlevi,dosyaya editörler ve yazarlar için ad ve soyadı kaydetir
            sw = new StreamWriter(path + "\\" + cs);
            for (int i = 0; i < reader.Filim_adi.Count; i++)
            {
                sw.WriteLine("{0},{1},{2},{3},{4}", reader.Filim_adi[i], reader.Kisi_adi[i], reader.Telefon_no[i]
                   , reader.tarih[i] , reader.GnulukUcert[i]);
            }
            sw.Close();
        }
    }

}

