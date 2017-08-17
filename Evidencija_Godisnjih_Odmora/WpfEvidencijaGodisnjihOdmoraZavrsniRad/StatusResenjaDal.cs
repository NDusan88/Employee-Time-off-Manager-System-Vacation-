using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class StatusResenjaDal
    {
        public List<StatusResenja> PrikaziStatus()
        {
            List<StatusResenja> listaStatus = new List<StatusResenja>();
            SqlConnection SqlConn = Konekcija.VratiKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StatusResenja",SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    StatusResenja st = new StatusResenja();
                    st.StatusResenjaId = read.GetInt32(0);
                    st.Status = read.GetString(1);
                    listaStatus.Add(st);
                }
                return listaStatus;
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
