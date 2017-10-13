
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace SEA_Toyota
{
    public class LogClass
    {
        public static void SaveLog(string detLog, string funcion, string claseError, string tipoLog)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bddToyota"].ToString());
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertLog";
                cmd.Parameters.AddWithValue("@detLog", SqlDbType.Text).Value = detLog;
                cmd.Parameters.AddWithValue("@funcion", SqlDbType.NVarChar).Value = funcion;
                cmd.Parameters.AddWithValue("@tipoLog", SqlDbType.NVarChar).Value = tipoLog;
                cmd.Parameters.AddWithValue("@claseError", SqlDbType.NVarChar).Value = claseError;
                cmd.Parameters.AddWithValue("@aplicacion", SqlDbType.NVarChar).Value = ConfigurationManager.AppSettings["aplicacion"].ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                con = null;
            }

        }
    }
}