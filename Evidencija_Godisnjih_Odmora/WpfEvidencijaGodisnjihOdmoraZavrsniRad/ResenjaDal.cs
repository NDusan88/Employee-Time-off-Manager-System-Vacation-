using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class ResenjaDal
    {
        public List<Resenja> VratiListu()
        {
            List<Resenja> listaResenja = new List<Resenja>();
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_ListaZahteva", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Resenja r = new Resenja();



                    r.ZaposleniId = read.GetInt32(0);
                    r.Ime = read.GetString(1);
                    r.Prezime = read.GetString(2);
                    r.Pozicija = read.GetString(3);
                    r.VremeOd = read.GetDateTime(4);
                    r.VremeDo = read.GetDateTime(5);
                    r.BrojDana = read.GetInt32(6);
                    r.Naziv = read.GetString(7);
                    r.ZahtevId = read.GetInt32(8);


                    listaResenja.Add(r);
                }
                return listaResenja;
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
