using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SEA_Toyota
{
    public class Recepcion
    {
        public int ID { get; set; }
        public string NUMERO_PROCESO { get; set; }
        public string HORA_PROCESO { get; set; }
        public string SERVER { get; set; }
        public string TDOC_DATE { get; set; }
        public string CODIGO_DEALER { get; set; }
        public string CODIGO_SUCURSA { get; set; }
        public string COD_SUCURSAL_TOYOTA { get; set; }
        public string MAIL_CLIENTE { get; set; }
        public string MARCA_COMPETENCI { get; set; }
        public string MEDIO_SHOWROOM { get; set; }
        public string MODELO_COMPETENCIA { get; set; }
        public string MODELO_VEHICULO { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string NUM_RECEPCION { get; set; }
        public string RUT_CLIENTE { get; set; }
        public string TEL_CLIENTE { get; set; }
        public string RESULTADO { get; set; }
        public string OBS_RESULTADO { get; set; }

        public Recepcion() { }
        public Recepcion(int id, string numero_proceso, string hora_proceso, string server, string tdoc_date, string codigo_dealer, string codigo_sucursal,
                         string cod_sucursal_toyota, string mail_cliente, string marca_competencia, string medio_showroom, string modelo_competencia, string modelo_vehiculo,
                         string nombre_cliente, string nombre_usuario, string num_recepcion, string rut_cliente, string tel_cliente, string resultado, string obs_resultado)
        {
            ID = id;
            NUMERO_PROCESO = numero_proceso;
            HORA_PROCESO = hora_proceso;
            SERVER = server;
            TDOC_DATE = tdoc_date;
            CODIGO_DEALER = codigo_dealer;
            CODIGO_SUCURSA = codigo_sucursal;
            COD_SUCURSAL_TOYOTA = cod_sucursal_toyota;
            MAIL_CLIENTE = mail_cliente;
            MARCA_COMPETENCI = marca_competencia;
            MEDIO_SHOWROOM = medio_showroom;
            MODELO_COMPETENCIA = modelo_competencia;
            MODELO_VEHICULO = modelo_vehiculo;
            NOMBRE_CLIENTE = nombre_cliente;
            NOMBRE_USUARIO = nombre_usuario;
            NUM_RECEPCION = num_recepcion;
            RUT_CLIENTE = rut_cliente;
            TEL_CLIENTE = tel_cliente;
            RESULTADO = resultado;
            OBS_RESULTADO = obs_resultado;
        }

        //Obtiene todos las recepciones de la base de datos TOYOTA dependiento de las reglas aplicadas al procedimiento almacenado
        public List<Recepcion> GetAllRecepcion()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bddToyota"].ToString());
            try
            {
                List<Recepcion> lstRecepcion = new List<Recepcion>();
                DataTable dt = new DataTable("RECEPCION");
                
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllRecepcion";
                da.SelectCommand = cmd;


                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    lstRecepcion.Add(new Recepcion(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                                                             dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                                                             dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString(),
                                                             dr[15].ToString(), dr[16].ToString(), dr[17].ToString(), dr[18].ToString(), dr[19].ToString()));
                }

            return lstRecepcion;
            }
            catch (Exception ex) { LogClass.SaveLog(ex.ToString(), "GetAllRecepcion", "Recepcion", "Error"); return null; }
            finally
            {
                if(con.State != ConnectionState.Closed)
                {
                    con.Close();
                    GC.Collect();
                }
                con = null;
            }
        }
    }
}