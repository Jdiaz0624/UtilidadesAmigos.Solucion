using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaMatrisRiesgo
{
    public class LogicaMatrisRiesgo
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.MatrizRiesgoBDDataContext ObjData = new Data.Conexiones.LINQ.MatrizRiesgoBDDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);


        #region MATRIZ DE RIESGO
        public UtilidadesAmigos.Logica.Entidades.MatrizRiesgo.EMatrisRiesgo ProcesarMatrisRiesgo(UtilidadesAmigos.Logica.Entidades.MatrizRiesgo.EMatrisRiesgo Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.MatrizRiesgo.EMatrisRiesgo Procesar = null;

            var Matris = ObjData.SP_PROCESAR_INFORMACION_MATRIZ_RIEZGO(
                Item.IdRegistro,
                Item.IdOficina,
                Item.IdUsuario,
                Item.Nombres,
                Item.IdTipoIdentificacion,
                Item.NumeroIdentificacion,
                Item.IdProducto,
                Item.IdProductoNivel,
                Item.IdSubProducto,
                Item.IdSUbProductoNivel,
                Item.IdCanalDistribucion,
                Item.IdCanalDistribucionNivel,
                Item.IdPaisResidencia,
                Item.IdPaisResidenciaNivel,
                Item.IdPaisProcedencia,
                Item.IdPaisProcedenciaNivel,
                Item.IdProvincia,
                Item.IdProvinciaNivel,
                Item.IdMontoRiesgo,
                Item.IdMontoRIesgoNivel,
                Item.IdActividadEconomica,
                Item.IdActivicadEconomicaNivel,
                Item.IdPromedioIngresoAnual,
                Item.IdPromedioIngresoAnualNivel,
                Item.IdPEP,
                Item.IDPEPNivel,
                Item.IdPrimaAnual,
                Item.IdPrimaAnualNivel,
                Item.IdTipoMonitoreo,
                Item.IdTipoDebidaDiligencia,
                Item.Observaciones,
                Accion);
            if (Matris != null) {

                Procesar = (from n in Matris
                            select new UtilidadesAmigos.Logica.Entidades.MatrizRiesgo.EMatrisRiesgo
                            {
                                IdRegistro = n.IdRegistro,
                                IdOficina =n.IdOficina,
                                IdUsuario=n.IdUsuario,
                                Fecha=n.Fecha,
                                Nombres=n.Nombres,
                                IdTipoIdentificacion=n.IdTipoIdentificacion,
                                NumeroIdentificacion = n.NumeroIdentificacion,
                                IdProducto = n.IdProducto,
                                IdProductoNivel = n.IdProductoNivel,
                                IdSubProducto = n.IdSubProducto,
                                IdSUbProductoNivel = n.IdSUbProductoNivel,
                                IdCanalDistribucion = n.IdCanalDistribucion,
                                IdCanalDistribucionNivel = n.IdCanalDistribucionNivel,
                                IdPaisResidencia = n.IdPaisResidencia,
                                IdPaisResidenciaNivel = n.IdPaisResidenciaNivel,
                                IdPaisProcedencia = n.IdPaisProcedencia,
                                IdPaisProcedenciaNivel = n.IdPaisProcedenciaNivel,
                                IdProvincia = n.IdProvincia,
                                IdProvinciaNivel = n.IdProvinciaNivel,
                                IdMontoRiesgo = n.IdMontoRiesgo,
                                IdMontoRIesgoNivel = n.IdMontoRIesgoNivel,
                                IdActividadEconomica = n.IdActividadEconomica,
                                IdActivicadEconomicaNivel = n.IdActivicadEconomicaNivel,
                                IdPromedioIngresoAnual = n.IdPromedioIngresoAnual,
                                IdPromedioIngresoAnualNivel = n.IdPromedioIngresoAnualNivel,
                                IdPEP = n.IdPEP,
                                IDPEPNivel = n.IDPEPNivel,
                                IdPrimaAnual = n.IdPrimaAnual,
                                IdPrimaAnualNivel = n.IdPrimaAnualNivel,
                                IdTipoMonitoreo = n.IdTipoMonitoreo,
                                IdTipoDebidaDiligencia = n.IdTipoDebidaDiligencia,
                                Observaciones = n.Observaciones,
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
