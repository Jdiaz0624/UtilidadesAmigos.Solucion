using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaReportes
{
    public class ProduccionPorUsuarioResumido
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionReportesDataContext ObjData = new Data.Conexiones.LINQ.BDConexionReportesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region GUARDAR DATOS REPORTE PRODUCCION POR USUARIOS
        //GUARDA R LOS DATOS DE PRODUCCION POR USUARIO RESUMIDO
        public UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido GuardarDatosProduccionPorUsuarioResumido(UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido Guardar = null;

            var Produccion = ObjData.SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDO(
              Item.IdUsuario,
              Item.Sucursal,
              Item.Oficina,
              Item.Departaemnto,
              Item.Usuario,
              Item.Concepto,
              Item.Cantidad,
              Item.Total,
              Item.TipoMovimiento,
              Item.TotalRegistros,
              Item.TotalPrima,
              Item.FechaDesde,
              Item.FechaHasta,
              Accion);
            if (Produccion != null) {
                Guardar = (from n in Produccion
                           select new UtilidadesAmigos.Logica.Entidades.Reportes.EProduccionPorusuarioResumido
                           {
                               IdUsuario=n.IdUsuario,
                               Sucursal=n.Sucursal,
                               Oficina=n.Oficina,
                               Departaemnto=n.Departaemnto,
                               Usuario=n.Usuario,
                               Concepto=n.Concepto,
                               Cantidad=n.Cantidad,
                               Total=n.Total,
                               TipoMovimiento=n.TipoMovimiento,
                               TotalRegistros=n.TotalRegistros,
                               TotalPrima=n.TotalPrima,
                               FechaDesde=n.FechaDesde,
                               FechaHasta=n.FechaHasta
                           }).FirstOrDefault();
            }
            return Guardar;

     
        }
        #endregion
    }
}
