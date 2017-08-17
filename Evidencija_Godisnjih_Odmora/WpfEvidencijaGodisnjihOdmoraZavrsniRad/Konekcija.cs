using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class Konekcija
    {
        public static SqlConnection VratiKonekciju()
        {
            SqlConnection SqlConn = new SqlConnection(@"Data Source=DESKTOP-J62H038\SQLEXPRESS;Initial Catalog=GodisnjiOdmor;Integrated Security=True");

            return SqlConn;
        }
    }
}
