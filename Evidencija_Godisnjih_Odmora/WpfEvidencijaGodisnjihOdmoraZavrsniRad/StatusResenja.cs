using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class StatusResenja
    {
        public int StatusResenjaId { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", Status);
        }
    }
}
