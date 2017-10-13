using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SEA_Toyota
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Recepcion recepcion = new Recepcion();
            recepcion.GetAllRecepcion();

            HttpWebRequest request = CreateWebRequest();
            NetworkCredential credencial = new NetworkCredential("sea_portillo", "inicial1");
            request.Credentials = credencial;
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:toyota.cl:dealer:envio_facturacion_vms_0004\"> " +
           "<soapenv:Header/> " +
           "<soapenv:Body> " +
            "<urn:DEALER_Envio_Facturacion_MT > " +
             "<CODIGO_DEALER>200000</CODIGO_DEALER> " +
             "<Row>" +
            "<CODIGO_SUCURSAL>100082</CODIGO_SUCURSAL>" +
            "<TIPO_FACTURA>F</TIPO_FACTURA>" +
            "<FECHA_FACTURA>20170213</FECHA_FACTURA>" +
            "<NUMERO_FACTURA>1234567</NUMERO_FACTURA>" +
            "<REFERENCIA>1234567</REFERENCIA>" +
            "<NOMBRE_USUARIO>MARTACLARISAMUÑOZMORALES</NOMBRE_USUARIO>" +
            "<MODELO_VEHICULO>COROLLASD1.8GLMT4X2</MODELO_VEHICULO>" +
            "<NUM_STOCK>0000481360</NUM_STOCK>" +
            "<VERSION_VEHICULO>172MG1</VERSION_VEHICULO>" +
            "<COLOR_VEHICULO>BLANCO</COLOR_VEHICULO>" +
            "<STOCK_ASIG>481360</STOCK_ASIG>" +
            "<NOMBRE_CLIENTE>MARTACLARISAMUÑOZMORALES</NOMBRE_CLIENTE>" +
            "<RUT_CLIENTE>7383308-6</RUT_CLIENTE>" +
            "<TEL_CLIENTE>998701968</TEL_CLIENTE>" +
            "<NOM_USUA_FINAL>MARTA</NOM_USUA_FINAL>" +
            "<NOM2_USUA_FINAL>CLARISA</NOM2_USUA_FINAL>" +
            "<APEP_USUA_FINAL>MUÑOZ</APEP_USUA_FINAL>" +
            "<APEM_USUA_FINAL>MORALES</APEM_USUA_FINAL>" +
            "<RUT_ASUA_FINAL>7383308-6</RUT_ASUA_FINAL>" +
            "<MAIL_USUA_FINAL>marta_cobranza@hotmail.com</MAIL_USUA_FINAL>" +
            "<NOM_VENDEDOR>DANIELACORDERO</NOM_VENDEDOR>" +
            "<RUT_VENDEDOR>42979-1</RUT_VENDEDOR>" +
            "<ACCESORIOS>NOTIENE</ACCESORIOS>" +
            "<MONTO_FACTURA>10690000</MONTO_FACTURA>" +
            "<MONEDA>CLP</MONEDA>" +
            "<MAR_VEHI_RETOMA>?</MAR_VEHI_RETOMA>" +
            "<MOD_VEHI_RETOMA>?</MOD_VEHI_RETOMA>" +
            "<ANO_VEHI_RETOMA>?</ANO_VEHI_RETOMA>" +
            "<INST_CREDITO>MAF</INST_CREDITO>" +
            "<TIPO_CREDITO>C4</TIPO_CREDITO>" +
            "<INST_SEGURO>.</INST_SEGURO>" +
                " </Row> " +
             "  </urn:DEALER_Envio_Facturacion_MT> " +
             "</soapenv:Body> " +
            "</soapenv:Envelope>");
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    XmlTextReader reader = new XmlTextReader(new StringReader(soapResult));
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    string ret;



                    while (reader.Read())
                    {
                        if (!reader.Value.Equals(""))
                        {
                            ret = reader.NodeType.ToString();
                            ret = reader.Value;
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format(@"{0}", "http://sea.toyotachile.cl:8100/XISOAPAdapter/MessageServlet?senderParty=&senderService=BS_DEALER_PRD&receiverParty=&receiverService=&interface=os_DEALER_Envio_Facturacion_VMS_0004_SI&interfaceNamespace=urn:toyota.cl:dealer:envio_facturacion_vms_0004"));
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}