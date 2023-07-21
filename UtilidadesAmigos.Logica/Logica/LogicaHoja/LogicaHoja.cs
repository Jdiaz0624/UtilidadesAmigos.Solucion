using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaHoja
{
    public class LogicaHoja
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionHojasDataContext ObjData = new Data.Conexiones.LINQ.BDConexionHojasDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);


        #region CERTIFICADO MARITIMO
        /// <summary>
        /// Este metodo se utiliza para validar las informaciones de una poliza de certificado maritimo.
        /// </summary>
        /// <param name="Poliza"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Hoja.ECertificadoMaritimo> BuscaPolizacertificadoMaritimo(string Poliza = null) {

            ObjData.CommandTimeout = 999999999;

            var Informacion = (from n in ObjData.SP_HOJA_CERTIFICADO_SEGUROS_MARITIMO_AEREO(Poliza)
                               select new UtilidadesAmigos.Logica.Entidades.Hoja.ECertificadoMaritimo
                               {
                                   FechaAdiciona=n.FechaAdiciona,
                                   FechaEmision=n.FechaEmision,
                                   Asegurado=n.Asegurado,
                                   Poliza=n.Poliza,
                                   DescripciónMercancía=n.DescripciónMercancía,
                                   MedioTransporte=n.MedioTransporte,
                                   FechaInicioVigencia=n.FechaInicioVigencia,
                                   FechaFinVigencia=n.FechaFinVigencia,
                                   InicioVigencia=n.InicioVigencia,
                                   FinVigencia=n.FinVigencia,
                                   FechaSalida=n.FechaSalida,
                                   FechaAproximadaLlegada=n.FechaAproximadaLlegada,
                                   ValorMercancíaFOB=n.ValorMercancía_FOB,
                                   ValorAseguradoCF=n.ValorAsegurado_CF,
                                   PrimaSeguro=n.PrimaSeguro,
                                   PuertoDesembarque=n.PuertoDesembarque,
                                   PaísProcedencia=n.PaísProcedencia,
                                   PuertoEmbarque=n.PuertoEmbarque
                               }).ToList();
            return Informacion;
        }
        #endregion
    }
}
