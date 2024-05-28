using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    internal class ReadKisi : IReadFile
    {
        List<string> FilmAdi;
        List<string> KisiAdi;
        List<string> TelefonNo;
        List<string> gnulukUcert;
        List<string> Tarih;
        List<string> KiraMi;
        public ReadKisi(string isim)
        {
            //İşte dosya yolu
            path = @"DateBase\";
            string cs = isim + ".csv";
            var fs = new FileStream(path + cs, FileMode.OpenOrCreate);
            fs.Close();
            sr = new StreamReader(path + cs);

  
            TelefonNo = new List<string>();
            Tarih = new List<string>();
            FilmAdi = new List<string>();
            gnulukUcert=new List<string>();
            KisiAdi = new List<string>();


            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                kume = line.Split(',');
                FilmAdi.Add(kume[0]);
                KisiAdi.Add(kume[1]);
                Tarih.Add(kume[3]);
                gnulukUcert.Add(kume[4]);
                TelefonNo.Add(kume[2]);
            }
            sr.Close();

        }

        public string path { get; set ; }
        public StreamReader sr { get ; set; }
        public string[] kume { get ; set ; }

        public List<string> Filim_adi { get => FilmAdi; set => FilmAdi = value; }
        public List<string> Kisi_adi { get => KisiAdi; set => KisiAdi = value; }
        public List<string> Telefon_no { get => TelefonNo; set => TelefonNo = value; }
        public List<string> tarih { get => Tarih; set => Tarih = value; }
        public List<string> GnulukUcert { get => gnulukUcert; set => gnulukUcert = value; }

        public int ara(String str)
        {

            return FilmAdi.IndexOf(str);

        }


    }
}
