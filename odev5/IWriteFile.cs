using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    internal interface IWriteFile
    {
        string cs { get; set; }
        string isim { get; set; }
        string path { get; set; }

        StreamWriter sw { get; set; }
        bool varmi { get; set; }
        public void sil(string a) { }
        public void guncell() { }
        public void kaydetmek() { }



    }
}
