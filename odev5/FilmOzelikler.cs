using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    internal class FilmOzelikler
    {
        private String adi;
        private String tur;
        private String yas_sinir;
        private String yapim;
        private String dil;

        public FilmOzelikler(string adi, string tur, string yas_sinir, string yapim, string dil)
        {
            this.Adi = adi;
            this.Tur = tur;
            this.Yas_sinir = yas_sinir;
            this.Yapim = yapim;
            this.Dil = dil;
        }

        public string Adi { get => adi; set => adi = value; }
        public string Tur { get => tur; set => tur = value; }
        public string Yas_sinir { get => yas_sinir; set => yas_sinir = value; }
        public string Dil { get => dil; set => dil = value; }
        public string Yapim { get => yapim; set => yapim = value; }
    }
}
