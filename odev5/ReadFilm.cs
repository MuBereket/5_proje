using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    public class ReadFilm:IReadFile
    {
        public string path { get; set; }
        public StreamReader sr { get; set; }
        public string[] kume { get; set; }
        //Veri türüne göre listeler oluşturun
        List<string> FilmAdi;
        List<string> FilmTuru;
        List<string> FilmYapım;
        List<string> FilmDili;
        List<string> YasSinir;
        List<string> Durum;



        //Bu Yapıcı, Kitaplar dosyasındaki verileri alır
        public ReadFilm( string isim)
        {
            //İşte dosya yolu
            path = @"DateBase\";
            string cs = isim + ".csv";
            var fs = new FileStream(path  + cs, FileMode.OpenOrCreate);
            fs.Close();
            sr = new StreamReader(path + cs);

            FilmYapım = new List<string>();
            FilmDili = new List<string>();
            YasSinir = new List<string>();
            FilmAdi = new List<string>();
            FilmTuru = new List<string>();
            durum = new List<string>();



            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                kume = line.Split(',');
                FilmAdi.Add(kume[0]);
                FilmTuru.Add(kume[1]);
                YasSinir.Add(kume[2]);
                FilmYapım.Add(kume[3]);
                FilmDili.Add(kume[4]);
                durum.Add(kume[5]);
                


            }
            sr.Close();

        }

  
    
        public List<string> Filim_adi { get => FilmAdi; set => FilmAdi = value; }
        public List<string> Film_turu { get => FilmTuru; set => FilmTuru = value; }
        public List<string> Film_yapim { get => FilmYapım; set => FilmYapım = value; }
        public List<string> Film_dili { get => FilmDili; set => FilmDili = value; }
        public List<string> Yas_sinir { get => YasSinir; set => YasSinir = value; }
        public List<string> durum { get => Durum; set => Durum = value; }

        public int ara(String str)
        {

            return FilmAdi.IndexOf(str);

        }

    }

}
