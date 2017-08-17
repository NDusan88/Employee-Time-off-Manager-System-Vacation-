using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class VrstaOdsustvaDal
    {
        public List<VrstaZahteva> PrikaziVrstu()
        {
            List<VrstaZahteva> listaVrsti = new List<VrstaZahteva>();
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VrstaOdsustva", SqlConn);          

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    VrstaZahteva vr = new VrstaZahteva();
                    vr.VrstaOdsustvaId = read.GetInt32(0);
                    vr.Naziv = read.GetString(1);
                    listaVrsti.Add(vr);
                }
                return listaVrsti;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConn.Close();
            }
        }
    }
}
