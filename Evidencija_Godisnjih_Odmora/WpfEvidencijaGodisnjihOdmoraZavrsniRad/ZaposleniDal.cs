using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class ZaposleniDal
    {
        public List<Zaposleni> vratiZaposlene()
        {
            List<Zaposleni> listaZaposlenih = new List<Zaposleni>();
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Zaposleni", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    Zaposleni z = new Zaposleni();
                    z.ZaposleniId = read.GetInt32(0);
                    z.Ime = read.GetString(1);
                    z.Prezime = read.GetString(2);
                    z.Pozicija = read.GetString(3);
                    z.Slika = (byte[])read[4];

                    listaZaposlenih.Add(z);
                }
                return listaZaposlenih;
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

        public int DodajZaposlenog(Zaposleni z)
        {
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("DodajZaposlenog", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Ime", z.Ime));
                cmd.Parameters.Add(new SqlParameter("@Prezime", z.Prezime));
                cmd.Parameters.Add(new SqlParameter("@Pozicija", z.Pozicija));
                cmd.Parameters.Add(new SqlParameter("@Slika", z.Slika));
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public int ObrisiZaposlenog(Zaposleni z)
        {
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("ObrisiZaposlenog", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add(new SqlParameter("@ZaposleniId", z.ZaposleniId));
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (Exception)
            {
                                
                return -1;
            }
            finally
            {
                SqlConn.Close();
            }
        }
    }     
}
