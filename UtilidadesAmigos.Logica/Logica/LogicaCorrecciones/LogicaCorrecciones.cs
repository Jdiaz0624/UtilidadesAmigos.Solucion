using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UtilidadesAmigos.Logica.Logica.LogicaCorrecciones
{
    public class LogicaCorrecciones
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionCorreccionesDataContext ObjData = new Data.Conexiones.LINQ.BDConexionCorreccionesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region ELIMINAR ENDOSOS DE SESION
        /// <summary>
        /// Muestra el listado de los endosos
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso> BuscaEndosos(string Poliza = null, int? Item=null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_ENDOSO_SESION(Poliza, Item)
                           select new UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso
                           {
                               Compania=n.Compania,
                               Cotizacion=n.Cotizacion,
                               Poliza=n.Poliza,
                               CodigoRamo=n.CodigoRamo,
                               Ramo=n.Ramo,
                               CodigoSubramo=n.CodigoSubramo,
                               Subramo=n.Subramo,
                               FechaInicioVigencia0=n.FechaInicioVigencia0,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               FechaFinVigencia0=n.FechaFinVigencia0,
                               FechaFinVigencia=n.FechaFinVigencia,
                               Item=n.Item,
                               IdBeneficiario=n.IdBeneficiario,
                               NombreBeneficiario=n.NombreBeneficiario,
                               ValorEndosoCesion=n.ValorEndosoCesion,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               FechaAdiciona0=n.FechaAdiciona0,
                               Fecha=n.Fecha,
                               Hora=n.Hora
                           }).ToList();
            return Listado;
        
        }

        /// <summary>
        /// Procesa la Informacion de Eliminar Endoso
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso ProcesarEliminarEndosos(UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso Procesar = null;

            var EliminarEndoso = ObjData.SP_PROCESAR_INFORMACION_ENDOSOS_POLIZAS(
                Item.Compania,
                Item.Cotizacion,
                Item.Item,
                Item.IdBeneficiario,
                Item.NombreBeneficiario,
                Item.ValorEndosoCesion,
                Item.UsuarioAdiciona,
                Item.FechaAdiciona0,
                Accion);
            if (EliminarEndoso != null) {

                Procesar = (from n in EliminarEndoso
                            select new UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso
                            {
                                Compania=n.Compania,
                                Cotizacion=n.Cotizacion,
                                Item=n.Secuencia,
                                IdBeneficiario=n.IdBeneficiario,
                                NombreBeneficiario=n.NombreBeneficiario,
                                ValorEndosoCesion=n.ValorEndosoCesion,
                                UsuarioAdiciona=n.UsuarioAdiciona,
                                FechaAdiciona0=n.FechaAdiciona
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region HISTORICO DE ELIMINACION DE ENDOSOS
        /// <summary>
        /// Muestra el listado de los endosos eliminados
        /// </summary>
        /// <param name="IdRegistro"></param>
        /// <param name="Poliza"></param>
        /// <param name="Secuencia"></param>
        /// <param name="FechaBorradoDesde"></param>
        /// <param name="FechaBorradoHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados> BuscaHistoricoEndosos(decimal? IdRegistro = null, string Poliza = null, int? Secuencia = null, DateTime? FechaBorradoDesde = null, DateTime? FechaBorradoHasta = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCAR_INFORMACION_ENDOSOS_ELIMINADOS(IdRegistro, Poliza, Secuencia, FechaBorradoDesde, FechaBorradoHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados
                           {
                               IdRegistro=n.IdRegistro,
                               Compania=n.Compania,
                               Poliza=n.Poliza,
                               Cotizacion=n.Cotizacion,
                               Secuencia=n.Secuencia,
                               IdBeneficiario=n.IdBeneficiario,
                               NombreBeneficiario=n.NombreBeneficiario,
                               ValorEndosoCesion=n.ValorEndosoCesion,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               FechaAdiciona=n.FechaAdiciona,
                               UsuarioElimina=n.UsuarioElimina,
                               EliminadoPor=n.EliminadoPor,
                               FechaProcesoElimina0=n.FechaProcesoElimina0,
                               FechaProcesoElimina=n.FechaProcesoElimina,
                               HoraProcesoElimina=n.HoraProcesoElimina,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Procesa la Informacion de los endosos eliminados
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados ProcesarEndosoEliminados(UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados Procesar = null;

            var EliminarEndoso = ObjData.SP_PROCESAR_INFORMACION_HISTORICO_ENDOSOS(
                Item.IdRegistro,
                Item.Compania,
                Item.Cotizacion,
                Item.Secuencia,
                Item.IdBeneficiario,
                Item.NombreBeneficiario,
                Item.ValorEndosoCesion,
                Item.UsuarioAdiciona,
                Item.FechaAdiciona,
                Item.UsuarioElimina,
                Item.FechaProcesoElimina0,
                Item.Estatus0,
                Accion);
            if (EliminarEndoso != null) {

                Procesar = (from n in EliminarEndoso
                            select new UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados
                            {
                                IdRegistro=n.IdRegistro,
                                Compania=n.Compania,
                                Cotizacion=n.Cotizacion,
                                Secuencia=n.Secuencia,
                                IdBeneficiario=n.IdBeneficiario,
                                NombreBeneficiario=n.NombreBeneficiario,
                                ValorEndosoCesion=n.ValorEndosoCesion,
                                UsuarioAdiciona=n.UsuarioAdiciona,
                                FechaAdiciona=n.FechaAdiciona,
                                UsuarioElimina=n.UsuarioElimina,
                                FechaProcesoElimina0=n.FechaProcesoElimina,
                                Estatus0=n.Estatus
                            }).FirstOrDefault();


            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE BITACORA DE MONTO AFIANZADO
        /// <summary>
        /// Este metodo muestra el listado de la bitacora de los cambios realizados al monto afianzado de las polizas
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado> BuscaBitacoraMontoAfianzado(string Poliza = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_BITACORA_MONTO_AFIANZADO(Poliza, FechaDesde, FechaHasta)
                           select new UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado
                           {
                               IdRegistro=n.IdRegistro,
                               Poliza=n.Poliza,
                               Anterior=n.Anterior,
                               Cambio=n.Cambio,
                               Usuario=n.Usuario,
                               CreadoPor=n.CreadoPor,
                               Fecha0=n.Fecha0,
                               Fecha=n.Fecha=n.Fecha,
                               Hora=n.Hora,
                               Concepto=n.Concepto
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo Procesa la informacion de las modificaciones realizadas en la bitacora de monto afianzado
        /// </summary>
        /// <param name="MontoAfianzado"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado ProcesarBitacoraMontoAfianzado(UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado MontoAfianzado, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado Procesar = null;

            var Dato = ObjData.SP_PROCESAR_INFORMACION_BITACORA_MONTO_AFIANZADO(
                MontoAfianzado.IdRegistro,
                MontoAfianzado.Poliza,
                MontoAfianzado.Anterior,
                MontoAfianzado.Cambio,
                MontoAfianzado.Usuario,
                MontoAfianzado.Concepto,
                Accion);
            if (Dato != null) {

                Procesar = (from n in Dato
                            select new UtilidadesAmigos.Logica.Entidades.Correcciones.EBitacoraMontoAfianzado
                            {
                                IdRegistro=n.IdRegistro,
                                Poliza=n.Poliza,
                                Anterior=n.Anterior,
                                Cambio=n.Cambio,
                                Usuario=n.Usuario,
                                Fecha0=n.Fecha,
                                Concepto=n.Concepto
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
