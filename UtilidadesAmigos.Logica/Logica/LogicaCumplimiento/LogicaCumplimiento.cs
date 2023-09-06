using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaCumplimiento
{
    public class LogicaCumplimiento
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionCumplimientoDataContext ObjData = new Data.Conexiones.LINQ.BDConexionCumplimientoDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);


        #region MANTENIMIENTO DE MATRIZ DE RIEZGO
        /// <summary>
        /// Muestra el listado de los registros de nivel de riesgo
        /// </summary>
        /// <param name="IdRegistro"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="IdUsuarui"></param>
        /// <param name="Nombre"></param>
        /// <param name="IdTipoIdentificacion"></param>
        /// <param name="NumeroIdentificacion"></param>
        /// <param name="IdArea"></param>
        /// <param name="IdPosicion"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo> BuscaMatrisRiezgo(decimal? IdRegistro = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? IdUsuarui = null, string Nombre = null, int? IdTipoIdentificacion = null, string NumeroIdentificacion = null, int? IdArea = null, int? IdPosicion = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_MATRIZ_RIESGO(IdRegistro, FechaDesde, FechaHasta, IdUsuarui, Nombre, IdTipoIdentificacion, NumeroIdentificacion, IdArea, IdPosicion)
                           select new UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo
                           {
                               IdRegistro=n.IdRegistro,
                               FechaCreado0=n.FechaCreado0,
                               FechaCreado=n.FechaCreado,
                               HoraCreado=n.HoraCreado,
                               IdUsuario=n.IdUsuario,
                               CreadoPor=n.CreadoPor,
                               Nombre=n.Nombre,
                               IdTipoIdentificacion=n.IdTipoIdentificacion,
                               TipoIdentificacion=n.TipoIdentificacion,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               IdTipoTercero=n.IdTipoTercero,
                               TipoTercero=n.TipoTercero,
                               IdNivel_Riesgo_TipoTercero=n.IdNivel_Riesgo_TipoTercero,
                               NivelRiesgo_TipoTercero=n.NivelRiesgo_TipoTercero,
                               IdArea=n.IdArea,
                               Area=n.Area,
                               IdNivel_Riesgo_Area=n.IdNivel_Riesgo_Area,
                               NivelRiesgo_Area=n.NivelRiesgo_Area,
                               IdPosicion=n.IdPosicion,
                               Pocision=n.Pocision,
                               IdNivel_Riesgo_Posicion=n.IdNivel_Riesgo_Posicion,
                               NivelRiesgo_Pocision=n.NivelRiesgo_Pocision,
                               IdNivelAcademico=n.IdNivelAcademico,
                               NivelAcademico=n.NivelAcademico,
                               IdNivel_Riesgo_NivelAcademico=n.IdNivel_Riesgo_NivelAcademico,
                               NivelRiesgo_NivelAcademico=n.NivelRiesgo_NivelAcademico,
                               IdPaisProcedencia=n.IdPaisProcedencia,
                               PaisProcedencia=n.PaisProcedencia,
                               IdNivel_Riesgo_PaisProcedencia=n.IdNivel_Riesgo_PaisProcedencia,
                               NivelRiesgo_PaisProcedencia=n.NivelRiesgo_PaisProcedencia,
                               IdPaisResidencia=n.IdPaisResidencia,
                               PaisResidencia=n.PaisResidencia,
                               IdNivel_Riesgo_PaisResidencia=n.IdNivel_Riesgo_PaisResidencia,
                               NivelRiesgoPaisResidencia=n.NivelRiesgoPaisResidencia,
                               IdProvincia=n.IdProvincia,
                               Provincia=n.Provincia,
                               IdNivel_Riesgo_Provincia=n.IdNivel_Riesgo_Provincia,
                               NivelRiesgo_Provincia=n.NivelRiesgo_Provincia,
                               IdSalarioDevengado=n.IdSalarioDevengado,
                               SalarioDevengado=n.SalarioDevengado,
                               IdNivel_Riesgo_SalarioDevengado=n.IdNivel_Riesgo_SalarioDevengado,
                               NivelRiesgoSalarioDevengado=n.NivelRiesgoSalarioDevengado,
                               ActividadSegundaria=n.ActividadSegundaria,
                               NivelRiesgo_ActividadSegundaria=n.NivelRiesgo_ActividadSegundaria,
                               IdNivel_Riesgo_ActividadSegundaria=n.IdNivel_Riesgo_ActividadSegundaria,
                               IngresosAdicionales=n.IngresosAdicionales,
                               IdNivel_Riesgo_IngresosAdicionales=n.IdNivel_Riesgo_IngresosAdicionales,
                               NivelRiesgo_IngresosAdicionales=n.NivelRiesgo_IngresosAdicionales,
                               IdPEP=n.IdPEP,
                               PEP=n.PEP,
                               IdNivel_Riesgo_PEP=n.IdNivel_Riesgo_PEP,
                               NivelRiesgoPEP=n.NivelRiesgoPEP,
                               PrimaAnual=n.PrimaAnual,
                               IdNivel_Riesgo_PrimaAnual=n.IdNivel_Riesgo_PrimaAnual,
                               NivelRisgoPrimaAnual=n.NivelRisgoPrimaAnual,
                               IdTipoMonitoreo=n.IdTipoMonitoreo,
                               TipoMonitoreo=n.TipoMonitoreo,
                               IdTipoDebidaDiligencia=n.IdTipoDebidaDiligencia,
                               IdNivel_Riesgo_Consolidado=n.IdNivel_Riesgo_Consolidado,
                               NivelRiesgoConsolidado=n.NivelRiesgoConsolidado,
                               Observaciones =n.Observaciones

                           }).ToList();
            return Listado;
        }
        /// <summary>
        /// Procesar la Informacion de la Actividad economica
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo ProcesarMatrizriezgo(UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo Procesar = null;

            var MatrizRiezgo = ObjData.SP_PROCESAR_INFORMACION_MATRIZ_RIESGO(
                Item.IdRegistro,
                Item.IdUsuario,
                Item.Nombre,
                Item.IdTipoIdentificacion,
                Item.NumeroIdentificacion,
                Item.IdTipoTercero,
                Item.IdNivel_Riesgo_TipoTercero,
                Item.IdArea,
                Item.IdNivel_Riesgo_Area,
                Item.IdPosicion,
                Item.IdNivel_Riesgo_Posicion,
                Item.IdNivelAcademico,
                Item.IdNivel_Riesgo_NivelAcademico,
                Item.IdPaisProcedencia,
                Item.IdNivel_Riesgo_PaisProcedencia,
                Item.IdPaisResidencia,
                Item.IdNivel_Riesgo_PaisResidencia,
                Item.IdProvincia,
                Item.IdNivel_Riesgo_Provincia,
                Item.IdSalarioDevengado,
                Item.IdNivel_Riesgo_SalarioDevengado,
                Item.ActividadSegundaria,
                Item.IdNivel_Riesgo_ActividadSegundaria,
                Item.IngresosAdicionales,
                Item.IdNivel_Riesgo_IngresosAdicionales,
                Item.IdPEP,
                Item.IdNivel_Riesgo_PEP,
                Item.PrimaAnual,
                Item.IdNivel_Riesgo_PrimaAnual,
                Item.IdTipoMonitoreo,
                Item.IdTipoDebidaDiligencia,
                Item.IdNivel_Riesgo_Consolidado,
                Item.Observaciones,
                Accion);
            if (MatrizRiezgo != null) {

                Procesar = (from n in MatrizRiezgo
                            select new UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo
                            {
                                IdRegistro = n.IdRegistro,
                                FechaCreado0 = n.FechaCreado,
                                IdUsuario = n.IdUsuario,
                                Nombre = n.Nombre,
                                IdTipoIdentificacion = n.IdTipoIdentificacion,
                                NumeroIdentificacion = n.NumeroIdentificacion,
                                IdTipoTercero = n.IdTipoTercero,
                                IdNivel_Riesgo_TipoTercero = n.IdNivel_Riesgo_TipoTercero,
                                IdArea = n.IdArea,
                                IdNivel_Riesgo_Area = n.IdNivel_Riesgo_Area,
                                IdPosicion = n.IdPosicion,
                                IdNivel_Riesgo_Posicion = n.IdNivel_Riesgo_Posicion,
                                IdNivelAcademico = n.IdNivelAcademico,
                                IdNivel_Riesgo_NivelAcademico = n.IdNivel_Riesgo_NivelAcademico,
                                IdPaisProcedencia = n.IdPaisProcedencia,
                                IdNivel_Riesgo_PaisProcedencia = n.IdNivel_Riesgo_PaisProcedencia,
                                IdPaisResidencia = n.IdPaisResidencia,
                                IdNivel_Riesgo_PaisResidencia = n.IdNivel_Riesgo_PaisResidencia,
                                IdProvincia = n.IdProvincia,
                                IdNivel_Riesgo_Provincia = n.IdNivel_Riesgo_Provincia,
                                IdSalarioDevengado = n.IdSalarioDevengado,
                                IdNivel_Riesgo_SalarioDevengado = n.IdNivel_Riesgo_SalarioDevengado,
                                ActividadSegundaria = n.ActividadSegundaria,
                                IdNivel_Riesgo_ActividadSegundaria = n.IdNivel_Riesgo_ActividadSegundaria,
                                IngresosAdicionales = n.IngresosAdicionales,
                                IdNivel_Riesgo_IngresosAdicionales = n.IdNivel_Riesgo_IngresosAdicionales,
                                IdPEP = n.IdPEP,
                                IdNivel_Riesgo_PEP = n.IdNivel_Riesgo_PEP,
                                PrimaAnual = n.PrimaAnual,
                                IdNivel_Riesgo_PrimaAnual = n.IdNivel_Riesgo_PrimaAnual,
                                IdTipoMonitoreo = n.IdTipoMonitoreo,
                                IdTipoDebidaDiligencia = n.IdTipoDebidaDiligencia,
                                IdNivel_Riesgo_Consolidado = n.IdNivel_Riesgo_Consolidado,
                                Observaciones = n.Observaciones
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
