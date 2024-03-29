﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
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

        /// <summary>
        /// Este metodo es para buscar fianzas
        /// </summary>
        /// <param name="Poliza"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EBuscaInformacionPolizasFianzas> BuscaInformacionPolizasFianzas(string Poliza = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_INFORMACION_POLIZAS_FIANZAS(Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.Correcciones.EBuscaInformacionPolizasFianzas
                           {
                               Poliza=n.Poliza,
                               Estatus=n.Estatus,
                               SumaAsegurada=n.SumaAsegurada,
                               Prima=n.Prima,
                               Intermediario=n.Intermediario,
                               NombreVendedor=n.NombreVendedor,
                               Cliente=n.Cliente,
                               NombreCliente=n.NombreCliente,
                               Deudor=n.Deudor,
                               Ramo=n.Ramo,
                               NombreRamo=n.NombreRamo,
                               SubRamo=n.SubRamo,
                               NombreSubramo=n.NombreSubramo,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Modifica el Monto Afianzado
        /// </summary>
        /// <param name="Monto"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Correcciones.EModificarMontoAfianzado ModificarMontoAfianzado(UtilidadesAmigos.Logica.Entidades.Correcciones.EModificarMontoAfianzado Monto, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Correcciones.EModificarMontoAfianzado Modificar = null;

            var MontoAfianzado = ObjData.SP_MODIFICAR_MONTO_AFIANZADO(
                Monto.Poliza,
                Monto.MontoAfianzado,
                Accion);
            if (MontoAfianzado != null) {

                Modificar = (from n in MontoAfianzado
                             select new UtilidadesAmigos.Logica.Entidades.Correcciones.EModificarMontoAfianzado
                             {
                                 Poliza=n.Poliza,
                                 MontoAfianzado=n.MontoAfianzado
                             }).FirstOrDefault();
            }
            return Modificar;
        }
        #endregion

        #region EQUIPOS ELECTRINCOS
        /// <summary>
        /// Muestra el listado de items de las polizas de equipos electrincios
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EBuscaInformacionPolizaEquiposElectronicos> BuscaInformacionEquiposElectronicos(string Poliza = null, int? Item = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_INFORMACION_POLIZA_EQUIPOS_ELECTRONICOS(Poliza, Item)
                           select new UtilidadesAmigos.Logica.Entidades.Correcciones.EBuscaInformacionPolizaEquiposElectronicos
                           {
                               Poliza=n.Poliza,
                               Cotizacion=n.Cotizacion,
                               Item=n.Item,
                               Cliente=n.Cliente,
                               NombreCliente=n.NombreCliente,
                               Intermediario=n.Intermediario,
                               NombreIntermediario=n.NombreIntermediario,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               CantidadEquipos=n.CantidadEquipos,
                               CantidadEquiposTotal=n.CantidadEquiposTotal
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Muestra el Inventario de los equipos electrinicos
        /// </summary>
        /// <param name="Cotizacion"></param>
        /// <param name="Secuencia"></param>
        /// <param name="IdEquipo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos> MostrarInventarioEquiposElectrinicos(decimal? Cotizacion = null, int? Secuencia = null, int? IdEquipo = null) {

            ObjData.CommandTimeout = 999999999;

            var Inventario = (from n in ObjData.SP_MOSTRAR_INVENTARIO_POLIZAS_EQUIPOS_ELECTRINICOS(Cotizacion, Secuencia, IdEquipo)
                              select new UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos
                              {
                                  Compania=n.Compania,
                                  Cotizacion=n.Cotizacion,
                                  Secuencia=n.Secuencia,
                                  IdEquipo=n.IdEquipo,
                                  Descripcion=n.Descripcion,
                                  Marca=n.Marca,
                                  Modelo=n.Modelo,
                                  Serie=n.Serie,
                                  ValorAsegurado=n.ValorAsegurado,
                                  ValorReposicion=n.ValorReposicion,
                                  PorcDeducible=n.PorcDeducible,
                                  BaseDeducible=n.BaseDeducible,
                                  MinimoDeducible=n.MinimoDeducible,
                                  PorcPrima=n.PorcPrima,
                                  FechaAdiciona0=n.FechaAdiciona0,
                                  FechaAdiciona=n.FechaAdiciona,
                                  TotalItems=n.TotalItems
                              }).ToList();
            return Inventario;
        }

        /// <summary>
        /// Procesa la Información del Inventario
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos ProcesarEquiposElectrionicos(UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos Procesar = null;

            var Equipos = ObjData.SP_PROCESAR_INFORMACION_POLIZAS_EQUIPOS_ELECTRINICOS(
                Item.Compania,
                Item.Cotizacion,
                Item.Secuencia,
                Item.IdEquipo,
                Item.Descripcion,
                Item.Marca,
                Item.Modelo,
                Item.Serie,
                Item.ValorAsegurado,
                Item.ValorReposicion,
                Item.PorcDeducible,
                Item.BaseDeducible,
                Item.MinimoDeducible,
                Item.PorcPrima,
                Accion);
            if (Equipos != null)
            {
                Procesar = (from n in Equipos
                            select new UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos
                            {
                                Compania = n.Compania,
                                Cotizacion = n.Cotizacion,
                                Secuencia = n.Secuencia,
                                IdEquipo = n.IdEquipo,
                                Descripcion = n.Descripcion,
                                Marca = n.Marca,
                                Modelo = n.Modelo,
                                Serie = n.Serie,
                                ValorAsegurado = n.ValorAsegurado,
                                ValorReposicion = n.ValorReposicion,
                                PorcDeducible = n.PorcDeducible,
                                BaseDeducible = n.BaseDeducible,
                                MinimoDeducible = n.MinimoDeducible,
                                PorcPrima = n.PorcPrima,
                                FechaAdiciona0 = n.FechaAdiciona,
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
