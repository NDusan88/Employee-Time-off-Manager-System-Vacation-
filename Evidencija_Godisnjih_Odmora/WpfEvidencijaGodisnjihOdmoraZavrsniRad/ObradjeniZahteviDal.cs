using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class ObradjeniZahteviDal
    {
        public List<ObradjeniZahtevi> ListaObradjenihZahteva()
        {
            List<ObradjeniZahtevi> listaObZahteva = new List<ObradjeniZahtevi>();
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_ListaObradjenihZahteva", SqlConn);
            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ObradjeniZahtevi ob = new ObradjeniZahtevi();
                    ob.ZaposleniId = read.GetInt32(0);
                    ob.Ime = read.GetString(1);
                    ob.Prezime = read.GetString(2);
                    ob.Pozicija = read.GetString(3);
                    ob.StatusResenja = read.GetString(4);
                    ob.DatumResenja = read.GetDateTime(5);
                    ob.Objasnjenje = read.GetString(6);

                    listaObZahteva.Add(ob);
                }
                return listaObZahteva;
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
