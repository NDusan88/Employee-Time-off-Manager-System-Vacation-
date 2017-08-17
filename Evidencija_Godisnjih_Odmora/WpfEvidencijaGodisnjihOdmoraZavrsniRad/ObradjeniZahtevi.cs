using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class ObradjeniZahtevi
    {
        public int ZaposleniId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public DateTime DatumResenja { get; set; }
        public string StatusResenja { get; set; }
        public string Objasnjenje { get; set; }
        public override string ToString()

        {
            return string.Format("{0} {1}-{2}", Ime, Prezime, Pozicija);
        }
    }
}
