using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class Resenja
    {
        public int ZaposleniId { get; set; }
        public int ZahtevId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public DateTime VremeOd { get; set; }
        public DateTime VremeDo { get; set; }
        public int BrojDana { get; set; }
        public string Naziv { get; set; }
        public override string ToString()

        {

            return string.Format("{0} {1}", Ime, Prezime);

        }
    }
}
