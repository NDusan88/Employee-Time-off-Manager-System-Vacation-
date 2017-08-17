using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class Zahtev
    {
        public int ZahtevId { get; set; }
        public DateTime VremeOd { get; set; }
        public DateTime VremeDo { get; set; }
        public int BrojDana { get; set; }
        public int ZaposleniId { get; set; }
        public int VrstaOdsustvaId { get; set; }
    }
}
