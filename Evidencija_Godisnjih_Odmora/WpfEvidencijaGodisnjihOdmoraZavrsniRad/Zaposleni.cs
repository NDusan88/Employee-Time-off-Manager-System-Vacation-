using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class Zaposleni
    {
        public int ZaposleniId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public byte[] Slika { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Ime,Prezime);
        }
    }
}
