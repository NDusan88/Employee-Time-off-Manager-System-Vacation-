using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class ObradiZahtev
    {
        public int ResenjeId { get; set; }
        public DateTime DatumResenja { get; set; }
        public string Objasnjenje { get; set; }
        public int ZahtevId { get; set; }
        public int StatusResenjaId { get; set; }

    }
}
