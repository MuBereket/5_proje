using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev5
{
    internal interface IReadFile
    {
        string path { get; set; }
        StreamReader sr { get; set; }
        string[] kume { get; set; }
        public int ara(String str)
        {
            return 0;
        }

    }
}
