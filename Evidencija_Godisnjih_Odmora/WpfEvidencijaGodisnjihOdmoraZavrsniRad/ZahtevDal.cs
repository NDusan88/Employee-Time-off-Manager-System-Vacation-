using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class ZahtevDal
    {
        public int PosaljiZahtev(Zahtev z)
        {
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("PosaljiZahtev", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add(new SqlParameter("@VremeOd", z.VremeOd));
                cmd.Parameters.Add(new SqlParameter("@VremeDo", z.VremeDo));
                cmd.Parameters.Add(new SqlParameter("@BrojDana", z.BrojDana));
                cmd.Parameters.Add(new SqlParameter("@VrstaOdsustvaId", z.VrstaOdsustvaId));
                cmd.Parameters.Add(new SqlParameter("@ZaposleniId", z.ZaposleniId));
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                return 0;
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

        public int ObradiZahtev(ObradiZahtev O)
        {
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("ObradiZahtev", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@DatumResenja", O.DatumResenja));
                cmd.Parameters.Add(new SqlParameter("@Objasnjenje", O.Objasnjenje));
                cmd.Parameters.Add(new SqlParameter("@ZahtevId", O.ZahtevId));
                cmd.Parameters.Add(new SqlParameter("@StatusResenjaId", O.StatusResenjaId));
                SqlConn.Open();
                cmd.ExecuteNonQuery();
                return 0;
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
