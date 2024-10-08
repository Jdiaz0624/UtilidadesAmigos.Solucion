﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UtilidadesAmigos.Logica.Entidades.Mantenimientos;

namespace UtilidadesAmigos.Logica.Logica.LogicaMantenimientos
{
    public class LogicaMantenimientos
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionMantenimientosDataContext Objdata = new Data.Conexiones.LINQ.BDConexionMantenimientosDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMIENTO DE OFICINAS
        //LISTADO DE OFICINAS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EOficinas> BuscaOficinas(decimal? IdOficina = null, decimal? IdSucursal = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_OFICINAS(IdOficina, IdSucursal, Descripcion)
                          select new Entidades.Mantenimientos.EOficinas
                          {
                              IdOficina = n.IdOficina,
                              IdSucursal = n.IdSucursal,
                              Sucursal = n.Sucursal,
                              Oficina = n.Oficina,
                              Estatus0 = n.Estatus0,
                              Estatus = n.Estatus,
                              UsuarioAdiciona = n.UsuarioAdiciona,
                              Creadopor = n.Creadopor,
                              FechaAdiciona = n.FechaAdiciona,
                              UsuarioModifica = n.UsuarioModifica,
                              ModificadoPor = n.ModificadoPor,
                              FechaModifica = n.FechaModifica
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE OFICINAS
        public Entidades.Mantenimientos.EOficinas MantenimientoOficinas(Entidades.Mantenimientos.EOficinas Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.Mantenimientos.EOficinas Mantenimiento = null;

            var MAN = Objdata.SP_MANTENIMIENTO_OFICINAS(
                Item.IdOficina,
                Item.IdSucursal,
                Item.Oficina,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (MAN != null)
            {
                Mantenimiento = (from n in MAN
                                 select new Entidades.Mantenimientos.EOficinas
                                 {
                                     IdOficina = n.IdOficina,
                                     IdSucursal = n.IdSucursal,
                                     Oficina = n.Descripcion,
                                     Estatus0 = n.Estatus,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE DEPARTAMENTOS
        //LISTADO DE DEPARTAMENTOS
        public List<Entidades.Mantenimientos.EDepartamentos> BuscaDepartamentos(decimal? IdSucursal = null, decimal? IdOficina = null, decimal? IdDepartamento = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_MAN_BUSCA_DEPARTAMENTOS(IdSucursal, IdOficina, IdDepartamento, Descripcion)
                          select new Entidades.Mantenimientos.EDepartamentos
                          {
                              IdSucursal = n.IdSucursal,
                              Sucursal = n.Sucursal,
                              IdOficina = n.IdOficina,
                              Oficina = n.Oficina,
                              IdDepartamento = n.IdDepartamento,
                              Departamento = n.Departamento,
                              Estatus0 = n.Estatus0,
                              Estatus = n.Estatus,
                              UsuarioAdiciona = n.UsuarioAdiciona,
                              CreadoPor = n.CreadoPor,
                              FechaAdiciona = n.FechaAdiciona,
                              FechaCreado = n.FechaCreado,
                              UsuarioModifica = n.UsuarioModifica,
                              ModificadoPor = n.ModificadoPor,
                              FechaModifica = n.FechaModifica,
                              FechaModificado = n.FechaModificado,
                              CantidadRegistros = n.CantidadRegistros
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE DEPARTAMENTOS
        public Entidades.Mantenimientos.EDepartamentos MantenimientoDepartamentos(Entidades.Mantenimientos.EDepartamentos Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.Mantenimientos.EDepartamentos Mantenimiento = null;

            var Departamentos = Objdata.SP_MAN_MANTENIMIENTO_DEPARTAMENTOS(
                Item.IdSucursal,
                Item.IdOficina,
                Item.IdDepartamento,
                Item.Departamento,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (Departamentos != null)
            {
                Mantenimiento = (from n in Departamentos
                                 select new Entidades.Mantenimientos.EDepartamentos
                                 {
                                     IdSucursal = n.IdSucursal,
                                     IdOficina = n.IdOficina,
                                     IdDepartamento = n.IdDepartamento,
                                     Departamento = n.Descripcion,
                                     Estatus0 = n.Estatus,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE EMPLEADOS
        //LISTADO DE EMPLEADOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EEmpleado> BuscaEmpleados(decimal? IdSucursal = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEmpleado = null, string Nombre = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_MAN_BUSCA_EMPLEADOS(IdSucursal, IdOficina, IdDepartamento, IdEmpleado, Nombre)
                          select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EEmpleado
                          {
                              IdSucursal = n.IdSucursal,
                              Sucursal = n.Sucursal,
                              IdOfiicna = n.IdOfiicna,
                              Oficina = n.Oficina,
                              IdDepartamento = n.IdDepartamento,
                              Departamento = n.Departamento,
                              IdEmpleado = n.IdEmpleado,
                              Nombre = n.Nombre,
                              Estatus0 = n.Estatus0,
                              Estatus = n.Estatus,
                              UsuarioAdiciona = n.UsuarioAdiciona,
                              CreadoPor = n.CreadoPor,
                              FechaAdiciona = n.FechaAdiciona,
                              FechaCreado = n.FechaCreado,
                              UsuarioModifica = n.UsuarioModifica,
                              ModificadoPor = n.ModificadoPor,
                              FechaModifica = n.FechaModifica,
                              FechaModificado = n.FechaModificado,
                              CantidadRegistros = n.CantidadRegistros
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE EMPLEADOS
        public Entidades.Mantenimientos.EEmpleado MantenimientoEmpleado(Entidades.Mantenimientos.EEmpleado Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.Mantenimientos.EEmpleado Mantenimiento = null;

            var Empleado = Objdata.SP_MAN_MANTENIMIENTO_EMPLEADO(
                Item.IdSucursal,
                Item.IdOfiicna,
                Item.IdDepartamento,
                Item.IdEmpleado,
                Item.Nombre,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (Empleado != null)
            {
                Mantenimiento = (from n in Empleado
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EEmpleado
                                 {
                                     IdSucursal = n.IdSucursal,
                                     IdOfiicna = n.IdOfiicna,
                                     IdDepartamento = n.IdDepartamento,
                                     IdEmpleado = n.IdEmpleado,
                                     Nombre = n.Nombre,
                                     Estatus0 = n.Estatus,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE TARJETA DE ACCESO
        //LISTADO DE TARJETAS DE ACCESO

        //MANTENIMIENTO DE TARJETAS DE ACCESO

        #endregion

        #region MANTENIMIENTO DE COMISIONES POR DEFECTO
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto> BuscaComisionesPorDefecto(decimal? IdRegistro = null, string Ramo = null, string SubRamo = null) {
            Objdata.CommandTimeout = 999999999;

            var ListadoComisiones = (from n in Objdata.SP_BUSCA_PORCIENTO_COMISION_POR_DEFECTO(IdRegistro, Ramo, SubRamo)
                                     select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto
                                     {
                                         IdRegistro = n.IdRegistro,
                                         CodRamo = n.CodRamo,
                                         Ramo = n.Ramo,
                                         CodSubramo = n.CodSubramo,
                                         Subramo = n.Subramo,
                                         PorcientoComision = n.PorcientoComision
                                     }).ToList();
            return ListadoComisiones;
        }
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto MantenimientoPorcientoComisionPorDefecto(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto Mantenimiento = null;

            var PorcientoComsionesPorDefecto = Objdata.SP_MANTENIMIENTO_COMISIONES_POR_DEFECTO(
                Item.IdRegistro,
                Item.CodRamo,
                Item.CodSubramo,
                Item.PorcientoComision,
                Accion);
            if (PorcientoComsionesPorDefecto != null) {
                Mantenimiento = (from n in PorcientoComsionesPorDefecto
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EComisionesPorDefecto
                                 {
                                     IdRegistro = n.IdRegistro,
                                     CodRamo = n.Ramo,
                                     CodSubramo = n.SubRamo,
                                     PorcientoComision = n.PorcientoComision
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE INTERMEIDAIROS
        //MOSTRAR EL LISTADO DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscaListadoIntermediarios> BuscaListadoIntermediario(string CodigoIntermediario = null, string NombreIntermediario = null, string CodigoSupervisor = null, string NombreSupervisor = null, int? Oficin = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_LISTADO_INTERMEDIARIOS(CodigoIntermediario, NombreIntermediario, CodigoSupervisor, NombreSupervisor, Oficin)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscaListadoIntermediarios
                           {
                               Compania = n.Compania,
                               Codigo = n.Codigo,
                               Cuenta = n.Cuenta,
                               Auxiliar = n.Auxiliar,
                               TipoRnc = n.TipoRnc,
                               DescripcionTipoRNC = n.DescripcionTipoRNC,
                               Rnc = n.Rnc,
                               NombreVendedor = n.NombreVendedor,
                               PorcientoComision = n.PorcientoComision,
                               CodigoSupervisor = n.CodigoSupervisor,
                               Estatus0 = n.Estatus0,
                               Estatus = n.Estatus,
                               Fecha_Entrada = n.Fecha_Entrada,
                               FechaEntrada = n.FechaEntrada,
                               UsuarioAdiciona = n.UsuarioAdiciona,
                               FechaAdiciona = n.FechaAdiciona,
                               UsuarioModifica = n.UsuarioModifica,
                               FechaModifica = n.FechaModifica,
                               PorcientoGastos = n.PorcientoGastos,
                               nota = n.nota,
                               tipo_Intermediario = n.tipo_Intermediario,
                               Agencia = n.Agencia,
                               Fec_Nac = n.Fec_Nac,
                               FechaNacimiento = n.FechaNacimiento,
                               Publicidad = n.Publicidad,
                               PagoComPor = n.PagoComPor,
                               Banco = n.Banco,
                               NombreBanco = n.NombreBanco,
                               CtaBanco = n.CtaBanco,
                               CodigoRnc = n.CodigoRnc,
                               Retencion = n.Retencion,
                               PorcDescuento = n.PorcDescuento,
                               SupervisorCrea = n.SupervisorCrea,
                               VendedorCrea = n.VendedorCrea,
                               Supervisor = n.Supervisor,
                               Poliza = n.Poliza,
                               Direccion = n.Direccion,
                               Ubicacion = n.Ubicacion,
                               DescripcionUbicacion = n.DescripcionUbicacion,
                               Telefono = n.Telefono,
                               TelefonoOficina = n.TelefonoOficina,
                               Celular = n.Celular,
                               Beeper = n.Beeper,
                               Fax = n.Fax,
                               Email = n.Email,
                               LicenciaSeguro = n.LicenciaSeguro,
                               CodigoAnterior = n.CodigoAnterior,
                               Apellido = n.Apellido,
                               Nombre = n.Nombre,
                               Oficina = n.Oficina,
                               NombreOficina = n.NombreOficina,
                               TipoCuentaBco = n.TipoCuentaBco,
                               EjecutivoServicio = n.EjecutivoServicio,
                               AsumeCxc = n.AsumeCxc,
                               CodigoCliente = n.CodigoCliente,
                               Record_Id = n.Record_Id,
                               PorcientoCapitalizacion = n.PorcientoCapitalizacion,
                               Gestor = n.Gestor,
                               EjecutivoCobros = n.EjecutivoCobros,
                               DiasCancelacionAutomatica = n.DiasCancelacionAutomatica,
                               CodigoSupervisor1 = n.CodigoSupervisor1,
                               NombreSupervisor = n.NombreSupervisor,
                               CantidadRegistros = n.CantidadRegistros
                           }).ToList();
            return Listado;
        }

        //BUSCAR LAS COMISIONES DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscarComisionesIntermediarios> BuscaComisionesIntermediario(int? CodigoIntermediario = null, int? Ramo = null, int? SubRamo = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_COMISIONES_INTERMEDIARIO(CodigoIntermediario, Ramo, SubRamo)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscarComisionesIntermediarios
                           {
                               Codigo = n.Codigo,
                               Intermediario = n.Intermediario,
                               IdRamo = n.IdRamo,
                               Ramo = n.Ramo,
                               IdSubRamo = n.IdSubRamo,
                               Subramo = n.Subramo,
                               PorcientoComision = n.PorcientoComision
                           }).ToList();
            return Listado;
        }

        //MANTENIMIENTO DE COMISIONES DE INTERMEDIARIO
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.MantenimientoComisionesIntermediarios MantenimientoComisionesIntermediario(UtilidadesAmigos.Logica.Entidades.Mantenimientos.MantenimientoComisionesIntermediarios Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.MantenimientoComisionesIntermediarios Mantenimiento = null;

            var ComisionesIntermediarios = Objdata.SP_MANTENIMIENTO_PORCIENTO_COMISION_INTERMEDIARIO_SELECCIONADO(
                Item.Compania,
                Item.Codigo,
                Item.Ramo,
                Item.SubRamo,
                Item.PorcientoComision,
                Item.PorcientoGastos,
                Item.PorcientoNivel1,
                Item.PorcientoNivel2,
                Item.Record_Id,
                Item.Usuario,
                Accion);
            if (ComisionesIntermediarios != null) {
                Mantenimiento = (from n in ComisionesIntermediarios
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.MantenimientoComisionesIntermediarios
                                 {
                                     Compania = n.Compania,
                                     Codigo = n.Codigo,
                                     Ramo = n.Ramo,
                                     SubRamo = n.SubRamo,
                                     PorcientoComision = n.PorcientoComision,
                                     PorcientoGastos = n.PorcientoGastos,
                                     PorcientoNivel1 = n.PorcientoNivel1,
                                     PorcientoNivel2 = n.PorcientoNivel2,
                                     Record_Id = n.Record_Id,
                                     Usuario = n.Usuario
                                 }).FirstOrDefault();
            }
            return Mantenimiento;

        }

        //MANTENIMIENTO DE INTERMEDIARIOS Y SUPERVISORES
        /// <summary>
        /// Este metodo es para Realizar el mantenimiento de los intermediarios y los supervisores ya sea crear uno nuevo o modificar uno ya existente.
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoIntermediariosSupervisores MantenimientoIntermediarioSupervisor(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoIntermediariosSupervisores Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoIntermediariosSupervisores Mantenimiento = null;

            var IntermediarioSupervisor = Objdata.SP_MANTENIMIENTO_INTERMEDIARIOS_SUPERVISORES(
                Item.Compania,
                Item.Codigo,
                Item.Cuenta,
                Item.Auxiliar,
                Item.TipoRnc,
                Item.Rnc,
                Item.PorcientoComision,
                Item.CodigoSupervisor,
                Item.Estatus,
                Item.Fecha_Entrada,
                Item.UsuarioAdiciona,
                Item.PorcientoGastos,
                Item.nota,
                Item.tipo_Intermediario,
                Item.Agencia,
                Item.Fec_Nac,
                Item.Publicidad,
                Item.PagoComPor,
                Item.Banco,
                Item.CtaBanco,
                Item.CodigoRnc,
                Item.Retencion,
                Item.PorcDescuento,
                Item.SupervisorCrea,
                Item.VendedorCrea,
                Item.Poliza,
                Item.Direccion,
                Item.Ubicacion,
                Item.Telefono,
                Item.TelefonoOficina,
                Item.Celular,
                Item.Beeper,
                Item.Fax,
                Item.Email,
                Item.LicenciaSeguro,
                Item.CodigoAnterior,
                Item.Apellido,
                Item.Nombre,
                Item.Oficina,
                Item.TipoCuentaBco,
                Item.EjecutivoCobros,
                Item.AsumeCxc,
                Item.CodigoCliente,
                Item.Record_Id,
                Item.PorcientoCapitalizacion,
                Item.Gestor,
                Item.EjecutivoCobros,
                Item.DiasCancelacionAutomatica,
                Accion);
            if (IntermediarioSupervisor != null) {
                Mantenimiento = (from n in IntermediarioSupervisor
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoIntermediariosSupervisores
                                 {
                                     Compania = n.Compania,
                                     Codigo = n.Codigo,
                                     Cuenta = n.Cuenta,
                                     Auxiliar = n.Auxiliar,
                                     TipoRnc = n.TipoRnc,
                                     Rnc = n.Rnc,
                                     NombreVendedor = n.NombreVendedor,
                                     PorcientoComision = n.PorcientoComision,
                                     CodigoSupervisor = n.CodigoSupervisor,
                                     Estatus = n.Estatus,
                                     Fecha_Entrada = n.Fecha_Entrada,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica,
                                     PorcientoGastos = n.PorcientoGastos,
                                     nota = n.nota,
                                     tipo_Intermediario = n.tipo_Intermediario,
                                     Agencia = n.Agencia,
                                     Fec_Nac = n.Fec_Nac,
                                     Publicidad = n.Publicidad,
                                     PagoComPor = n.PagoComPor,
                                     Banco = n.Banco,
                                     CtaBanco = n.CtaBanco,
                                     CodigoRnc = n.CodigoRnc,
                                     Retencion = n.Retencion,
                                     PorcDescuento = n.PorcDescuento,
                                     SupervisorCrea = n.SupervisorCrea,
                                     VendedorCrea = n.VendedorCrea,
                                     Poliza = n.Poliza,
                                     Direccion = n.Direccion,
                                     Ubicacion = n.Ubicacion,
                                     Telefono = n.Telefono,
                                     TelefonoOficina = n.TelefonoOficina,
                                     Celular = n.Celular,
                                     Beeper = n.Beeper,
                                     Fax = n.Fax,
                                     Email = n.Email,
                                     LicenciaSeguro = n.LicenciaSeguro,
                                     CodigoAnterior = n.CodigoAnterior,
                                     Apellido = n.Apellido,
                                     Nombre = n.Nombre,
                                     Oficina = n.Oficina,
                                     TipoCuentaBco = n.TipoCuentaBco,
                                     EjecutivoServicio = n.EjecutivoServicio,
                                     AsumeCxc = n.AsumeCxc,
                                     CodigoCliente = n.CodigoCliente,
                                     Record_Id = n.Record_Id,
                                     PorcientoCapitalizacion = n.PorcientoCapitalizacion,
                                     Gestor = n.Gestor,
                                     EjecutivoCobros = n.EjecutivoCobros,
                                     DiasCancelacionAutomatica = n.DiasCancelacionAutomatica,
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }

        //SACAR EL CODIGO MAXIMO DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.ESacarCodigoMaximoIntermediaio> SacarCodigoMaximo() {
            Objdata.CommandTimeout = 999999999;

            var Sacar = (from n in Objdata.SP_SACAR_CODIGO_MAXIMO_INTERMEDIARIO()
                         select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ESacarCodigoMaximoIntermediaio
                         {
                             Codigo = n.Codigo
                         }).ToList();
            return Sacar;
        }

        //MANTENIMIENTO DE INTERMEDIARIO CADENA DETALLE
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECadenaIntermediarioDetalle MantenimientoIntermediarioCadenaDetalle(UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECadenaIntermediarioDetalle Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECadenaIntermediarioDetalle Mantenimiento = null;

            var IntermediarioCadenaDetalle = Objdata.SP_GUARDAR_CADENA_DETALLE_INTERMEDIARIO(
                Item.Compania,
                Item.IdIntermediario,
                Item.IdIntermediarioSupervisa,
                Item.UsuarioAdiciona,
                Accion);
            if (IntermediarioCadenaDetalle != null) {
                Mantenimiento = (from n in IntermediarioCadenaDetalle
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECadenaIntermediarioDetalle
                                 {
                                     Compania = n.Compania,
                                     IdIntermediario = n.IdIntermediario,
                                     IdIntermediarioSupervisa = n.IdIntermediarioSupervisa,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE PROVEEDORES DE SOLICITUD DE CHEQUES
        //BUSCA PROVEEDORES
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscarProveedoresSolicitudCheques> BuscaProveedores(int? Codigo = null, string RNC = null, string NombreVendedor = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_PROVEEDOR_SOLICITUD_CHEQUE(Codigo, RNC, NombreVendedor)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscarProveedoresSolicitudCheques
                           {
                               Compania = n.Compania,
                               Codigo = n.Codigo,
                               TipoCliente = n.TipoCliente,
                               TipoRnc = n.TipoRnc,
                               RNC = n.RNC,
                               NombreCliente = n.NombreCliente,
                               Ubicacion = n.Ubicacion,
                               LimiteCredito = n.LimiteCredito,
                               Descuento = n.Descuento,
                               CondicionPago = n.CondicionPago,
                               Estatus = n.Estatus,
                               FechaUltPago = n.FechaUltPago,
                               MontoUltPago = n.MontoUltPago,
                               Balance = n.Balance,
                               UsuarioAdiciona = n.UsuarioAdiciona,
                               FechaAdiciona = n.FechaAdiciona,
                               FechaCreado = n.FechaCreado,
                               UsuarioModifica = n.UsuarioModifica,
                               FechaModifica = n.FechaModifica,
                               FechaModificado = n.FechaModificado,
                               CodigoRnc = n.CodigoRnc,
                               PorcComision = n.PorcComision,
                               CodMoneda = n.CodMoneda,
                               TelefonoCasa = n.TelefonoCasa,
                               TelefonoOficina = n.TelefonoOficina,
                               Celular = n.Celular,
                               Fax = n.Fax,
                               Beeper = n.Beeper,
                               Email = n.Email,
                               TipoPago = n.TipoPago,
                               Banco = n.Banco,
                               CuentaBanco = n.CuentaBanco,
                               Contacto = n.Contacto,
                               TipoCuentaBanco = n.TipoCuentaBanco,
                               ClaseProveedor = n.ClaseProveedor
                           }).ToList();
            return Listado;

        }

        //MANTENIMIENTO DE PROVEEDORES DE SOLICITUD
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoProveedoresSolicitud MantenimientoProveedoresSolicitud(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoProveedoresSolicitud Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoProveedoresSolicitud Mantenimiento = null;

            var ProveedoresSOlicitud = Objdata.SP_MANTENIMIENTO_PROCEEDORES_SOLICITUD(
                Item.Compania,
                Item.Codigo,
                Item.TipoCliente,
                Item.TipoRnc,
                Item.RNC,
                Item.NombreCliente,
                Item.Direccion,
                Item.Ubicacion,
                Item.LimiteCredito,
                Item.Descuento,
                Item.CondicionPago,
                Item.Estatus,
                Item.FechaUltPago,
                Item.MontoUltPago,
                Item.Balance,
                Item.UsuarioAdiciona,
                Item.FechaAdiciona,
                Item.UsuarioModifica,
                Item.FechaModifica,
                Item.CodigoRnc,
                Item.PorcComision,
                Item.CodMoneda,
                Item.TelefonoCasa,
                Item.TelefonoOficina,
                Item.Celular,
                Item.Fax,
                Item.Beeper,
                Item.Email,
                Item.TipoPago,
                Item.Banco,
                Item.CuentaBanco,
                Item.Contacto,
                Item.TipoCuentaBanco,
                Item.ClaseProveedor,
                Accion);
            if (ProveedoresSOlicitud != null) {
                Mantenimiento = (from n in ProveedoresSOlicitud
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoProveedoresSolicitud
                                 {
                                     Compania = n.Compania,
                                     Codigo = n.Codigo,
                                     TipoCliente = n.TipoCliente,
                                     TipoRnc = n.TipoRnc,
                                     RNC = n.RNC,
                                     NombreCliente = n.NombreCliente,
                                     Direccion = n.Direccion,
                                     Ubicacion = n.Ubicacion,
                                     LimiteCredito = n.LimiteCredito,
                                     Descuento = n.Descuento,
                                     CondicionPago = n.CondicionPago,
                                     Estatus = n.Estatus,
                                     FechaUltPago = n.FechaUltPago,
                                     MontoUltPago = n.MontoUltPago,
                                     Balance = n.Balance,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica,
                                     CodigoRnc = n.CodigoRnc,
                                     PorcComision = n.PorcComision,
                                     CodMoneda = n.CodMoneda,
                                     TelefonoCasa = n.TelefonoCasa,
                                     TelefonoOficina = n.TelefonoOficina,
                                     Celular = n.Celular,
                                     Fax = n.Fax,
                                     Beeper = n.Beeper,
                                     Email = n.Email,
                                     TipoPago = n.TipoPago,
                                     Banco = n.Banco,
                                     CuentaBanco = n.CuentaBanco,
                                     Contacto = n.Contacto,
                                     TipoCuentaBanco = n.TipoCuentaBanco,
                                     ClaseProveedor = n.ClaseProveedor
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO MONTOS SOLICITUD CHEQUES
        //BUSCAR MONTOS GUARDADOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques> BuscaMontos(decimal? Idusuario = null, int? CodigoIntermediario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_MONTOS_SOLICITUD_CHEQUES(Idusuario, CodigoIntermediario)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques 
                           {
                               IdUsuario = n.IdUsuario,
                               CodigoIntermediario = n.CodigoIntermediario,
                               Bruto = n.Bruto,
                               Neto = n.Neto,
                               Comision = n.Comision,
                               Retencion = n.Retencion,
                               Avance = n.Avance,
                               ALiquidar = n.ALiquidar,
                               Acumulado=n.Acumulado,
                               Total=n.Total
                           }).ToList();
            return Listado;
        }

        //PROCESAR INFORMACION PARA LOS MONTOS
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques ProcesarMontosSolicitudCheque(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques Mantenimeinto = null;

            var MontosSolicitudCheques = Objdata.SP_PROCESAR_MONTOS_SOLICITUD_CHEQUE(
                Item.IdUsuario,
                Item.CodigoIntermediario,
                Item.Bruto,
                Item.Neto,
                Item.Comision,
                Item.Retencion,
                Item.Avance,
                Item.ALiquidar,
                Accion);
            if (MontosSolicitudCheques != null) {
                Mantenimeinto = (from n in MontosSolicitudCheques
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMontosSolicitudCheques
                                 {
                                     IdUsuario = n.IdUsuario,
                                     CodigoIntermediario = n.CodigoIntermediario,
                                     Bruto = n.Bruto,
                                     Neto = n.Neto,
                                     Comision = n.Comision,
                                     Retencion = n.Retencion,
                                     Avance = n.Avance,
                                     ALiquidar = n.ALiquidar
                                 }).FirstOrDefault();
            }
            return Mantenimeinto;
        }


        //PROCESAR INFORMACION SOLICITUD DE CHEQUES
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques ProcesarSolicitudCheques(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques Item, DateTime? FechaDesde, DateTime? FechaHasta, decimal? TotalCobradoVendedor, decimal? ComisionBrutaVendedor, decimal? RetencionVendedor, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques Procesar = null;

            var SolicitudCheque = Objdata.SP_PROCESAR_SOLICITUD_CHEQUE(
                Item.Solicitud,
                Item.RNCTipo,
                Item.RNC,
                Item.CodigoBeneficiario,
                Item.Endosable,
                Item.CtaBanco,
                Item.CuentaBanco,
                Item.Valor,
                Item.UsuarioDigita,
                FechaDesde,
                FechaHasta,
                TotalCobradoVendedor,
                ComisionBrutaVendedor,
                RetencionVendedor,
                Accion);
            if (SolicitudCheque != null) {
                Procesar = (from n in SolicitudCheque
                            select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques
                            {
                                Compania = n.Compania,
                                Anulado = n.Anulado,
                                Sistema = n.Sistema,
                                Solicitud = n.Solicitud,
                                TipoSolicitud = n.TipoSolicitud,
                                DescTipoSolicitud = n.DescTipoSolicitud,
                                FechaSolicitud = n.FechaSolicitud,
                                Sucursal = n.Sucursal,
                                DescSucursal = n.DescSucursal,
                                Departamento = n.Departamento,
                                DescDepto = n.DescDepto,
                                Seccion = n.Seccion,
                                DescSeccion = n.DescSeccion,
                                RNCTipo = n.RNCTipo,
                                RNC = n.RNC,
                                CodigoBeneficiario = n.CodigoBeneficiario,
                                Beneficiario1 = n.Beneficiario1,
                                Beneficiario2 = n.Beneficiario2,
                                Endosable = n.Endosable,
                                CtaBanco = n.CtaBanco,
                                CuentaBanco = n.CuentaBanco,
                                Valor = n.Valor,
                                Concepto1 = n.Concepto1,
                                Concepto2 = n.Concepto2,
                                NumeroCheque = n.NumeroCheque,
                                FechaCheque = n.FechaCheque,
                                AnoMesConciliado = n.AnoMesConciliado,
                                FechaConciliado = n.FechaConciliado,
                                UsuarioDigita = n.UsuarioDigita,
                                UsuarioModifica = n.UsuarioModifica,
                                FechaDigita = n.FechaDigita,
                                FechaModifica = n.FechaModifica,
                                Aprobado = n.Aprobado,
                                FechaAprobado = n.FechaAprobado,
                                UsuarioCheque = n.UsuarioCheque,
                                PrimeraFirma = n.PrimeraFirma,
                                SegundaFirma = n.SegundaFirma,
                                UsuarioCancel = n.UsuarioCancel,
                                Estatus = n.Estatus,
                                Impresion = n.Impresion,
                                TipoDoc = n.TipoDoc
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        //SACAR ULTIMO NUMERO SOLICITUD GENERADO
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.ESacarUltimoNumeroSolicitudGenerado> SacarUltimoNumeroSolicitudGenrado(int? CodigoBeneficiario = null) {
            Objdata.CommandTimeout = 999999999;

            var NumeroSolicitud = (from n in Objdata.SP_SACAR_ULTIMO_NUMERO_SOLICITUD_GENERADO(CodigoBeneficiario)
                                   select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ESacarUltimoNumeroSolicitudGenerado
                                   {
                                       NumeroSolicitud = n.NumeroSolicitud
                                   }).ToList();
            return NumeroSolicitud;
        }

        //PROCESAR LOS DATOS DE LAS COLICITUD DE CHEQUES CUENTAS
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarDatosSolicitudChequesCuentas ProcesarDatosSolicitudCuentas(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarDatosSolicitudChequesCuentas Item, DateTime? FechaDesde, DateTime? FechaHAsta, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarDatosSolicitudChequesCuentas Procesar = null;


            var SolicitudCuentas = Objdata.SP_PROCESAR_DATOS_SOLICITUD_CHEQUES_CUENTAS(
                Item.Solicitud,
                Item.Secuencia,
                Item.Cuenta,
                Item.Auxiliar,
                Item.Origen,
                Item.Valor,
                FechaDesde,
                FechaHAsta,
                Accion);
            if (SolicitudCuentas != null) {
                Procesar = (from n in SolicitudCuentas
                            select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarDatosSolicitudChequesCuentas
                            {
                                Compania = n.Compania,
                                Anulado = n.Anulado,
                                Sistema = n.Sistema,
                                Solicitud = n.Solicitud,
                                Secuencia = n.Secuencia,
                                Cuenta = n.Cuenta,
                                Auxiliar = n.Auxiliar,
                                DescCuenta = n.DescCuenta,
                                Origen = n.Origen,
                                Valor = n.Valor,
                                TipoCompromiso = n.TipoCompromiso,
                                Departamento = n.Departamento
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region REPORTE DE ANTIGUEDAD DE SALDO

        /// <summary>
        /// Este metodo es para mostrar el origen de los datos para los reportes de antigeuda de saldo
        /// </summary>
        /// <param name="FechaCorte"></param>
        /// <param name="NumeroFactura"></param>
        /// <param name="Poliza"></param>
        /// <param name="Ramo"></param>
        /// <param name="Tipo"></param>
        /// <param name="CodigoCliente"></param>
        /// <param name="CodigoVendedor"></param>
        /// <param name="CodigoSupervisor"></param>
        /// <param name="Oficina"></param>
        /// <param name="UsuarioGenera"></param>
        /// <param name="Moneda"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EOrigenDatosAntiguedadSaldo> BuscaOrigenDataAntiguedadSaldo(DateTime? FechaCorte = null, decimal? NumeroFactura = null, string Poliza = null, int? Ramo = null, int? Tipo = null, decimal? CodigoCliente = null, int? CodigoVendedor = null, int? CodigoSupervisor = null, int? Oficina = null, decimal? UsuarioGenera = null, int? Moneda = null) {

            Objdata.CommandTimeout = 999999999;

            var Origen = (from n in Objdata.SP_ORIGEN_DATOS_ANTIGUEDAD_SALDO(FechaCorte, NumeroFactura, Poliza, Ramo, Tipo, CodigoCliente, CodigoVendedor, CodigoSupervisor, Oficina, UsuarioGenera, Moneda)
                          select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EOrigenDatosAntiguedadSaldo
                          {
                              Poliza=n.Poliza,
                              Cotizacion=n.Cotizacion,
                              CodigoCliente=n.CodigoCliente,
                              CodigoIntermediario=n.CodigoIntermediario,
                              CodigoSupervisor=n.CodigoSupervisor,
                              CodigoOficina=n.CodigoOficina,
                              CodigoMoneda=n.CodigoMoneda,
                              CodigoRamo=n.CodigoRamo,
                              Valor=n.Valor,
                              NumeroFactura=n.NumeroFactura,
                              Balance=n.Balance,
                              Tipo=n.Tipo,
                              Fecha=n.Fecha,
                              FechaCorte=n.FechaCorte,
                              UsuarioGenera=n.UsuarioGenera
                        
                          }).ToList();
            return Origen;
        }


        /// <summary>
        /// Procesar los datos de la antiguedad de saldo
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionDatosAntiguedadSaldo ProcesarDatosAntiguedadSaldo(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionDatosAntiguedadSaldo Item, string Accion) {

            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionDatosAntiguedadSaldo Procesar = null;

            var AntiguedadSaldo = Objdata.SP_PROCESAR_INFORMACION_DATOS_ANTIGUEDAD_SALDO(
                Item.IdUsuario,
                Item.Poliza,
                Item.Cotizacion,
                Item.CodigoCliente,
                Item.CodigoIntermediario,
                Item.CodigoSupervisor,
                Item.CodigoOficina,
                Item.CodigoMoneda,
                Item.CodigoRamo,
                Item.Valor,
                Item.NumeroFactura,
                Item.Balance,
                Item.Tipo,
                Item.Fecha,
                Item.FechaCorte,
                Accion);
            if (AntiguedadSaldo != null) {
                Procesar = (from n in AntiguedadSaldo
                            select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionDatosAntiguedadSaldo
                            {
                                IdUsuario=n.IdUsuario,
                                Poliza=n.Poliza,
                                Cotizacion=n.Cotizacion,
                                CodigoCliente=n.CodigoCliente,
                                CodigoIntermediario=n.CodigoIntermediario,
                                CodigoSupervisor=n.CodigoSupervisor,
                                CodigoOficina=n.CodigoOficina,
                                CodigoMoneda=n.CodigoMoneda,
                                CodigoRamo=n.CodigoRamo,
                                Valor=n.Valor,
                                NumeroFactura=n.NumeroFactura,
                                Balance=n.Balance,
                                Tipo=n.Tipo,
                                Fecha=n.Fecha,
                                FechaCorte=n.FechaCorte
                            }).FirstOrDefault();
                

            }
            return Procesar;
        }


        ////PROCESAR INFORMACION PARA EL REPORTE DE ANTIGUEDAD DE SALDO
        //public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionAntiguedadSaldo ProcesarInformacionAntiguedadSaldo(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionAntiguedadSaldo Item, string accion) {
        //    Objdata.CommandTimeout = 999999999;

        //    UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionAntiguedadSaldo Procesar = null;

        //    var AntiguedadSaldo = Objdata.SP_PROCESAR_INFORMACION_REPORTE_ANTIGUEDAD_SALDO(
        //        Item.IdUsuario,
        //        Item.FechaCorte,
        //        Item.DocumentoFormateado,
        //        Item.DocumentoFiltro,
        //        Item.Tipo,
        //        Item.DescripcionTipo,
        //        Item.Asegurado,
        //        Item.CodCliente,
        //        Item.FechaFactura,
        //        Item.Intermediario,
        //        Item.CodIntermediario,
        //        Item.Poliza,
        //        Item.CodMoneda,
        //        Item.DescripcionMoneda,
        //        Item.Estatus,
        //        Item.CodRamo,
        //        Item.InicioVigencia,
        //        Item.Inicio,
        //        Item.FinVigencia,
        //        Item.Fin,
        //        Item.CodOficina,
        //        Item.Oficina,
        //        Item.dias,
        //        Item.Facturado,
        //        Item.Cobrado,
        //        Item.Balance,
        //        Item.Impuesto,
        //        Item.PorcientoComision,
        //        Item.ValorComision,
        //        Item.ComisionPendiente,
        //        Item.__0_10,
        //        Item.__0_30,
        //        Item.__31_60,
        //        Item.__61_90,
        //        Item.__91_120,
        //        Item.__121_150,
        //        Item.__151_mas,
        //        Item.Total,
        //        Item.Diferencia,
        //        Item.OrigenTipo,
        //        accion);
        //    if (AntiguedadSaldo != null) {
        //        Procesar = (from n in AntiguedadSaldo
        //                    select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionAntiguedadSaldo
        //                    {
        //                        IdUsuario = n.IdUsuario,
        //                        FechaCorte = n.FechaCorte,
        //                        DocumentoFormateado = n.DocumentoFormateado,
        //                        DocumentoFiltro = n.DocumentoFiltro,
        //                        Tipo = n.Tipo,
        //                        DescripcionTipo = n.DescripcionTipo,
        //                        Asegurado = n.Asegurado,
        //                        CodCliente = n.CodCliente,
        //                        FechaFactura = n.FechaFactura,
        //                        Intermediario = n.Intermediario,
        //                        CodIntermediario = n.CodIntermediario,
        //                        Poliza = n.Poliza,
        //                        CodMoneda = n.CodMoneda,
        //                        DescripcionMoneda = n.DescripcionMoneda,
        //                        Estatus = n.Estatus,
        //                        CodRamo = n.CodRamo,
        //                        InicioVigencia = n.InicioVigencia,
        //                        Inicio = n.Inicio,
        //                        FinVigencia = n.FinVigencia,
        //                        Fin = n.Fin,
        //                        CodOficina = n.CodOficina,
        //                        Oficina = n.Oficina,
        //                        dias = n.dias,
        //                        Facturado = n.Facturado,
        //                        Cobrado = n.Cobrado,
        //                        Balance = n.Balance,
        //                        Impuesto = n.Impuesto,
        //                        PorcientoComision = n.PorcientoComision,
        //                        ValorComision = n.ValorComision,
        //                        ComisionPendiente = n.ComisionPendiente,
        //                        __0_10 = n._0_10,
        //                        __0_30 = n._0_30,
        //                        __31_60 = n._31_60,
        //                        __61_90 = n._61_90,
        //                        __91_120 = n._91_120,
        //                        __121_150 = n._121_150,
        //                        __151_mas = n._151_mas,
        //                        Total = n.Total,
        //                        Diferencia = n.Diferencia,
        //                        OrigenTipo = n.OrigenTipo
        //                    }).FirstOrDefault();
        //    }
        //    return Procesar;
        //}
        ///// <summary>
        ///// Este MEtodo es apra generar los datos del reporte de antiguedad de saldo resumido y super resumido.
        ///// </summary>
        ///// <param name="IdUsuario"></param>
        ///// <param name="TasaDollar"></param>
        ///// <param name="SuperResumido"></param>
        ///// <returns></returns>
        //public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EReporteAntiguedadSaldoResumido> ReporteAntiguedadSaldoResumido(decimal? IdUsuario = null, decimal? TasaDollar = null, int? SuperResumido = null) {
        //    Objdata.CommandTimeout = 999999999;

        //    var Resumido = (from n in Objdata.SP_REPORTE_ANTIDAD_SALDO_RESUMIDO(IdUsuario, TasaDollar, SuperResumido)
        //                    select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EReporteAntiguedadSaldoResumido
        //                    {
        //                        CodMoneda=n.CodMoneda,
        //                        FechaCorte=n.FechaCorte,
        //                        DescripcionMoneda=n.DescripcionMoneda,
        //                        Ramo=n.Ramo,
        //                        CodRamo=n.CodRamo,
        //                        CantidadFactura=n.CantidadFactura,
        //                        CantidadCreditos=n.CantidadCreditos,
        //                        CantidadPrimaDeposito=n.CantidadPrimaDeposito,
        //                        CantidadRegistros=n.CantidadRegistros,
        //                        Balance=n.Balance,
        //                        __0_30=n._0_30,
        //                        __31_60=n._31_60,
        //                        __61_90=n._61_90,
        //                        __91_120=n._91_120,
        //                        __121_150=n._121_150,
        //                        __151_Mas=n._151_Mas,
        //                        Total=n.Total,
        //                        GeneradoPor=n.GeneradoPor,
        //                        TotalPesos=n.TotalPesos,
        //                        Tasa=n.Tasa

        //                    }).ToList();
        //    return Resumido;
        //}

        ///// <summary>
        ///// Este Metodo es para mostrar los datos de la antiguedad de saldo en detalle
        ///// </summary>
        ///// <param name="IdUsuario"></param>
        ///// <param name="TasaDollar"></param>
        ///// <returns></returns>
        //public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EReporteAntiguedadSaldoDetalle> ReporteAntiguedadSaldoDetalle(decimal? IdUsuario = null, decimal? TasaDollar = null) {
        //    Objdata.CommandTimeout = 999999999;

        //    var AntigueadSaldoDetalle = (from n in Objdata.SP_REPORTE_ANTIDAD_SALDO_DETALLE(IdUsuario, TasaDollar)
        //                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EReporteAntiguedadSaldoDetalle
        //                                 {
        //                                     IdUsuario=n.IdUsuario,
        //                                     Persona=n.Persona,
        //                                     FechaCorte=n.FechaCorte,
        //                                     DocumentoFormateado=n.DocumentoFormateado,
        //                                     DocumentoFiltro=n.DocumentoFiltro,
        //                                     Tipo=n.Tipo,
        //                                     DescripcionTipo=n.DescripcionTipo,
        //                                     Asegurado=n.Asegurado,
        //                                     CodCliente=n.CodCliente,
        //                                     FechaFactura=n.FechaFactura,
        //                                     Intermediario=n.Intermediario,
        //                                     CodIntermediario=n.CodIntermediario,
        //                                     Poliza=n.Poliza,
        //                                     CodMoneda=n.CodMoneda,
        //                                     DescripcionMoneda=n.DescripcionMoneda,
        //                                     Estatus=n.Estatus,
        //                                     CodRamo=n.CodRamo,
        //                                     Ramo=n.Ramo,
        //                                     InicioVigencia=n.InicioVigencia,
        //                                     Inicio=n.Inicio,
        //                                     FinVigencia=n.FinVigencia,
        //                                     Fin=n.Fin,
        //                                     CodOficina=n.CodOficina,
        //                                     Oficina=n.Oficina,
        //                                     dias=n.dias,
        //                                     Facturado=n.Facturado,
        //                                     Cobrado=n.Cobrado,
        //                                     Balance=n.Balance,
        //                                     Impuesto=n.Impuesto,
        //                                     PorcientoComision=n.PorcientoComision,
        //                                     ValorComision=n.ValorComision,
        //                                     ComisionPendiente=n.ComisionPendiente,
        //                                     __0_10=n._0_10,
        //                                     __0_30=n._0_30,
        //                                     __31_60=n._31_60,
        //                                     __61_90=n._61_90,
        //                                     __91_120=n._91_120,
        //                                     __121_150=n._121_150,
        //                                     __151_mas=n._151_mas,
        //                                     Total=n.Total,
        //                                     Diferencia=n.Diferencia,
        //                                     OrigenTipo=n.OrigenTipo,
        //                                     TotalPesos=n.TotalPesos,
        //                                     CantidadFactura=n.CantidadFactura,
        //                                     CantidadCreditos=n.CantidadCreditos,
        //                                     CantidadPrimaDeposito=n.CantidadPrimaDeposito,
        //                                     CantidadRegistros=n.CantidadRegistros,
        //                                     Tasa=n.Tasa
        //                                 }).ToList();
        //    return AntigueadSaldoDetalle;
        //}

        //public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EReporteAntiguedadSaldoNeteadoDetalle> ReporteAntiguedadSaldoNeteadoDetalle(decimal? IdUsuario = null, decimal? TasaDollar = null) {
        //    Objdata.CommandTimeout = 999999999;

        //    var Listado = (from n in Objdata.SP_BUSCA_REPORTE_ANTIGUEDAD_SALDO_NETEADO_DETALLE(IdUsuario, TasaDollar)
        //                   select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EReporteAntiguedadSaldoNeteadoDetalle
        //                   {
        //                       IdUsuario=n.IdUsuario,
        //                       GeneradoPor=n.GeneradoPor,
        //                       FechaCorte=n.FechaCorte,
        //                       FechaCorteFormateado=n.FechaCorteFormateado,
        //                       Asegurado=n.Asegurado,
        //                       Asegurado1=n.Asegurado1,
        //                       CodCliente=n.CodCliente,
        //                       Intermediario=n.Intermediario,
        //                       CodIntermediario=n.CodIntermediario,
        //                       Poliza=n.Poliza,
        //                       CodMoneda=n.CodMoneda,
        //                       DescripcionMoneda=n.DescripcionMoneda,
        //                       Estatus=n.Estatus,
        //                       CodRamo=n.CodRamo,
        //                       Ramo=n.Ramo,
        //                       InicioVigencia=n.InicioVigencia,
        //                       Inicio=n.Inicio,
        //                       FinVigencia=n.FinVigencia,
        //                       Fin=n.Fin,
        //                       Facturado=n.Facturado,
        //                       Cobrado=n.Cobrado,
        //                       Balance=n.Balance,
        //                       Impuesto=n.Impuesto,
        //                       ValorComision=n.ValorComision,
        //                       ComisionPendiente=n.ComisionPendiente,
        //                       __0_30=n._0_30,
        //                       __31_60=n._31_60,
        //                       __61_90=n._61_90,
        //                       __91_120=n._91_120,
        //                       __121_150=n._121_150,
        //                       __151_mas=n._151_mas,
        //                       Total=n.Total,
        //                       TotalPesos=n.TotalPesos,
        //                       TasaDollar=n.TasaDollar,
        //                       Diferencia=n.Diferencia

        //                   }).ToList();
        //    return Listado;
        //}
        #endregion

        #region SACAR LA TASA DE A MONEDA
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.ESacarTasaMoneda> SacartasaMoneda(int? CodigoMoneda = null){
            Objdata.CommandTimeout = 999999999;

            var Tasa = (from n in Objdata.SP_SACAR_TASA_MONEDA(CodigoMoneda)
                        select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ESacarTasaMoneda
                        {
                            Prima=n.Prima
                        }).ToList();
            return Tasa;
        }
        #endregion

        #region MANTENIMEINTO DE REGISTROS DE COLICITUD DE CHEQUE
        //LISTADO DE REGISTROS DE SOLICITUD DE CHEQUE
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote> BuscaRegistrosSolicitudChequeLote(decimal? IdUsuario = null,bool? Estatus = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_REGISTROS_SOLICITUD_CHEQUE_LOTE(IdUsuario, Estatus)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote
                           {
                               IdRegistro=n.IdRegistro,
                               IdUsuairo=n.IdUsuairo,
                               CreadoPor=n.CreadoPor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               NumeroSolicitud=n.NumeroSolicitud,
                               FechaProceso0=n.FechaProceso0,
                               FechaProceso=n.FechaProceso,
                               FechaDesde=n.FechaDesde,
                               ValidadoDesde=n.ValidadoDesde,
                               FechaHasta=n.FechaHasta,
                               ValidadoHasta=n.ValidadoHasta,
                               MontoSolicitud=n.MontoSolicitud,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus,
                               CantidadProcesados=n.CantidadProcesados,
                               CantidadDescartados=n.CantidadDescartados,
                               CantidadRegistros=n.CantidadRegistros

                           }).ToList();
            return Listado;
        }

        //MANTENIMIENTO DE REGISTROS DE SOLICITUD DE CHEQUE
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote MantenimientoRegistrosSolicitudLone(UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote Mantenimeinto = null;

            var RegistroSolicitudChequeLote = Objdata.SP_PROCESAR_INFORMACION_REGISTROS_SOLICITUD_CHEQUE_LOTE(
                Item.IdRegistro,
                Item.IdUsuairo,
                Item.CodigoIntermediario,
                Item.NumeroSolicitud,
                Item.FechaDesde,
                Item.FechaHasta,
                Item.MontoSolicitud,
                Item.Estatus0,
                Accion);
            if (RegistroSolicitudChequeLote != null) {
                Mantenimeinto = (from n in RegistroSolicitudChequeLote
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ERegistrosSolicitudChequeLote
                                 {
                                     IdRegistro=n.IdRegistro,
                                     IdUsuairo=n.IdUsuairo,
                                    CodigoIntermediario=n.CodigoIntermediario,
                                    NumeroSolicitud=n.NumeroSolicitud,
                                    FechaProceso0=n.FechaProceso,
                                    FechaDesde=n.FechaDesde,
                                    FechaHasta=n.FechaDesde,
                                    MontoSolicitud=n.MontoSolicitud,
                                    Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimeinto;
        }
        #endregion


        #region MANTENIMIENTO DE HISTORIAL DE ANTIGUEDAD DE SALDO
        /// <summary>
        /// Este metodo es para procesar la información del historial de los datos de antiguedad de saldo.
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionHistorialDatosAntiguedadSaldo ProcesarHistorialAntiguedadSaldo(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionHistorialDatosAntiguedadSaldo Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionHistorialDatosAntiguedadSaldo Procesar = null;

            var HistorialDatosAntiguedadSaldo = Objdata.SP_PROCESAR_INFORMACION_HISTORIAL_DATOS_ANTIGUEDAD_SALDO(
                Item.NoRegistro,
                Item.Secuencia,
                Item.FechaGuardado,
                Item.FechaCorte,
                Item.DocumentoFormateado,
                Item.DocumentoFiltro,
                Item.Tipo,
                Item.DocumentoTipo,
                Item.Asegurado,
                Item.CodCliente,
                Item.FechaFactura,
                Item.Intermediario,
                Item.CodIntermediario,
                Item.Poliza,
                Item.CodMoneda,
                Item.DescripcionMoneda,
                Item.Estatus,
                Item.CodRamo,
                Item.InicioVigencia,
                Item.Inicio,
                Item.FinVigencia,
                Item.Fin,
                Item.CodOficina,
                Item.Oficina,
                Item.Dias,
                Item.Facturado,
                Item.Cobrado,
                Item.Balance,
                Item.Impuesto,
                Item.PorcientoComision,
                Item.ValorComision,
                Item.ComisionPendiente,
                Item.__0_10,
                Item.__0_30,
                Item.__31_60,
                Item.__61_90,
                Item.__91_120,
                Item.__121_150,
                Item.__151_Mas,
                Item.Total,
                Item.Diferencia,
                Item.OrigenTipo,
                Item.IdUsuario,
                Accion);

            if (HistorialDatosAntiguedadSaldo != null) {
                Procesar = (from n in HistorialDatosAntiguedadSaldo
                            select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionHistorialDatosAntiguedadSaldo
                            {
                                NoRegistro=n.NoRegistro,
                                Secuencia=n.Secuencia,
                                FechaGuardado=n.FechaGuardado,
                                FechaCorte=n.FechaCorte,
                                DocumentoFormateado=n.DocumentoFormateado,
                                DocumentoFiltro=n.DocumentoFiltro,
                                Tipo=n.Tipo,
                                DocumentoTipo=n.DocumentoTipo,
                                Asegurado=n.Asegurado,
                                CodCliente=n.CodCliente,
                                FechaFactura=n.FechaFactura,
                                Intermediario=n.Intermediario,
                                CodIntermediario=n.CodIntermediario,
                                Poliza=n.Poliza,
                                CodMoneda=n.CodMoneda,
                                DescripcionMoneda=n.DescripcionMoneda,
                                Estatus=n.Estatus,
                                CodRamo=n.CodRamo,
                                InicioVigencia=n.InicioVigencia,
                                Inicio=n.Inicio,
                                FinVigencia=n.FinVigencia,
                                Fin=n.Fin,
                                CodOficina=n.CodOficina,
                                Oficina=n.Oficina,
                                Dias=n.Dias,
                                Facturado=n.Facturado,
                                Cobrado=n.Cobrado,
                                Balance=n.Balance,
                                Impuesto=n.Impuesto,
                                PorcientoComision=n.PorcientoComision,
                                ValorComision=n.ValorComision,
                                ComisionPendiente=n.ComisionPendiente,
                                __0_10=n._0_10,
                                __0_30=n._0_30,
                                __31_60=n._31_60,
                                __61_90=n._61_90,
                                __91_120=n._91_120,
                                __121_150=n._121_150,
                                __151_Mas=n._151_Mas,
                                Total=n.Total,
                                Diferencia=n.Diferencia,
                                OrigenTipo=n.OrigenTipo,
                                IdUsuario=n.IdUsuario

                            }).FirstOrDefault();
            }
            return Procesar;
        }
        /// <summary>
        /// Este metodo es para buscar los registros del historial antiguedad de saldo de manera resumida.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="TasaDollar"></param>
        /// <param name="FechaCorte"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="SuperResumido"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EHistorialReporteAntiguedadSaldoResumido> BuscaHistorialAntiguedadSaldoResumida(decimal? IdUsuario = null, decimal? TasaDollar = null, DateTime? FechaCorte = null, DateTime? FechaGuardado = null, int? SuperResumido = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_REPORTE_HISTORIAL_ANTIDAD_SALDO_RESUMIDO(IdUsuario, TasaDollar, FechaCorte, FechaGuardado, SuperResumido)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EHistorialReporteAntiguedadSaldoResumido
                           {
                               CodMoneda=n.CodMoneda,
                               FechaCorte=n.FechaCorte,
                               FechaGuardado=n.FechaGuardado,
                               FechaCorteFormateado=n.FechaCorteFormateado,
                               FechaGuardadoFormateado=n.FechaGuardadoFormateado,
                               DescripcionMoneda=n.DescripcionMoneda,
                               Ramo=n.Ramo,
                               CodRamo=n.CodRamo,
                               CantidadFactura=n.CantidadFactura,
                               CantidadCreditos=n.CantidadCreditos,
                               CantidadPrimaDeposito=n.CantidadPrimaDeposito,
                               CantidadRegistros=n.CantidadRegistros,
                               Balance=n.Balance,
                               __0_30=n._0_30,
                               __31_60=n._31_60,
                               __61_90=n._61_90,
                               __91_120=n._91_120,
                               __121_150=n._121_150,
                               __151_Mas=n._151_Mas,
                               Total=n.Total,
                               GeneradoPor=n.GeneradoPor,
                               TotalPesos=n.TotalPesos,
                               Tasa=n.Tasa
                           }).ToList();
            return Listado;
        }
       
        /// <summary>
        /// Este metodo es para buscar los registros del historial de antiguedad de saldo de manera detallada.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Tasa"></param>
        /// <param name="FechaCorte"></param>
        /// <param name="FechaGuardado"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EHistorialAntiguedadSaldoDetalle> BuscaHistorialAntiguedadSaldoDetalle(decimal? IdUsuario = null, decimal? Tasa = null, DateTime? FechaCorte = null, DateTime? FechaGuardado = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_REPORTE_HISTORIAL_ANTIDAD_SALDO_DETALLE(IdUsuario, Tasa, FechaCorte, FechaGuardado)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EHistorialAntiguedadSaldoDetalle
                           {
                               IdUsuario=n.IdUsuario,
                               Persona=n.Persona,
                               FechaCorte=n.FechaCorte,
                               DocumentoFormateado=n.DocumentoFormateado,
                               DocumentoFiltro=n.DocumentoFiltro,
                               Tipo=n.Tipo,
                               DocumentoTipo=n.DocumentoTipo,
                               Asegurado=n.Asegurado,
                               CodCliente=n.CodCliente,
                               FechaFactura=n.FechaFactura,
                               Intermediario=n.Intermediario,
                               CodIntermediario=n.CodIntermediario,
                               Poliza=n.Poliza,
                               CodMoneda=n.CodMoneda,
                               DescripcionMoneda=n.DescripcionMoneda,
                               Estatus=n.Estatus,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               InicioVigencia=n.InicioVigencia,
                               Inicio=n.Inicio,
                               FinVigencia=n.FinVigencia,
                               Fin=n.Fin,
                               CodOficina=n.CodOficina,
                               Oficina=n.Oficina,
                               dias=n.dias,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance,
                               Impuesto=n.Impuesto,
                               PorcientoComision=n.PorcientoComision,
                               ValorComision=n.ValorComision,
                               ComisionPendiente=n.ComisionPendiente,
                               __0_10=n._0_10,
                               __0_30=n._0_30,
                               __31_60=n._31_60,
                               __61_90=n._61_90,
                               __91_120=n._91_120,
                               __121_150=n._121_150,
                               __151_mas=n._151_mas,
                               Total=n.Total,
                               Diferencia=n.Diferencia,
                               OrigenTipo=n.OrigenTipo,
                               TotalPesos=n.TotalPesos,
                               CantidadFactura=n.CantidadFactura,
                               CantidadCreditos=n.CantidadCreditos,
                               CantidadPrimaDeposito=n.CantidadPrimaDeposito,
                               CantidadRegistros=n.CantidadRegistros,
                               Tasa=n.Tasa
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para buscar los registros del historial de antiguedad de saldo de manera neteada.
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Tasa"></param>
        /// <param name="FechaCorte"></param>
        /// <param name="FechaGuardado"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EHistorialAntiguedadSaldoNeteado> BuscaHistorialAntiguedadSaldoNeteado(decimal? IdUsuario = null, decimal? Tasa = null, DateTime? FechaCorte = null, DateTime? FechaGuardado = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_REPORTE_HISTORIAL_ANTIGUEDAD_SALDO_NETEADO_DETALLE(IdUsuario, Tasa, FechaCorte, FechaGuardado)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EHistorialAntiguedadSaldoNeteado
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               FechaCorte=n.FechaCorte,
                               FechaCorteFormateado=n.FechaCorteFormateado,
                               Asegurado=n.Asegurado,
                               Asegurado1=n.Asegurado1,
                               CodCliente=n.CodCliente,
                               Intermediario=n.Intermediario,
                               CodIntermediario=n.CodIntermediario,
                               Poliza=n.Poliza,
                               CodMoneda=n.CodMoneda,
                               DescripcionMoneda=n.DescripcionMoneda,
                               Estatus=n.Estatus,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               InicioVigencia=n.InicioVigencia,
                               Inicio=n.Inicio,
                               FinVigencia=n.FinVigencia,
                               Fin=n.Fin,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance,
                               Impuesto=n.Impuesto,
                               ValorComision=n.ValorComision,
                               ComisionPendiente=n.ComisionPendiente,
                               __0_30=n._0_30,
                               __31_60=n._31_60,
                               __61_90=n._61_90,
                               __91_120=n._91_120,
                               __121_150=n._121_150,
                               __151_mas=n._151_mas,
                               Total=n.Total,
                               TotalPesos=n.TotalPesos,
                               TasaDollar=n.TasaDollar,
                               Diferencia=n.Diferencia
                             
                           }).ToList();
            return Listado;
        }
        #endregion

        #region CONSULTA INFORMACION SOLICITUD DE CHQEUES POR PANTALLA
        /// <summary>
        /// Este metodo es para consultar los registros de las solicitudes de cheques por pantalla o exportar
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="CodigoIntermediario"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla> ConsultarSolicitudesPorPanalla(decimal? IdUsuario = null, decimal? CodigoIntermediario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_CONSULTA_PANTALLA_SOLICITUD_CHEQUE(IdUsuario, CodigoIntermediario)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla
                           {
                               IdUsuario=n.IdUsuario,
                               CodigoIntermediario=n.CodigoIntermediario,
                               NombreIntermediario=n.NombreIntermediario,
                               CodigoBanco=n.CodigoBanco,
                               Banco=n.Banco,
                               Monto=n.Monto,
                               Acumulado=n.Acumulado,
                               Total=n.Total
                           }).ToList();
            return Listado;
        }

        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla ProcesarInformacionSolicitudChequePanalla(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla Procesar = null;

            var ConsultaInformacionSOliciutdCheque = Objdata.SP_PROCESAR_INFORMACION_CONSULTA_PANTALLA_SOLICITUD_CHEQUE(
                Item.IdUsuario,
                Item.CodigoIntermediario,
                Item.CodigoBanco,
                Item.Monto,
                Item.Acumulado,
                Accion);
            if (ConsultaInformacionSOliciutdCheque != null) {
                Procesar = (from n in ConsultaInformacionSOliciutdCheque
                            select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EConsultaInformacionSolicitudChequePantalla
                            {
                                IdUsuario=n.IdUsuario,
                                CodigoIntermediario=n.CodigoIntermediario,
                                CodigoBanco=n.CodigoBanco,
                                Monto=n.Monto,
                                Acumulado=n.Acumulado
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE MONEDAS
        /// <summary>
        /// Listado de Monedas
        /// </summary>
        /// <param name="CodigoMoneda"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscaMonedas> BuscaMonedas(int? CodigoMoneda = null) {

            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_MONEDAS(CodigoMoneda)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscaMonedas
                           {
                               Codigo=n.Codigo,
                               Descripcion=n.Descripcion,
                               Sigla=n.Sigla,
                               Tasa=n.Tasa,
                               PrimaCobrar=n.PrimaCobrar
                           }).ToList();
            return Listado;
        }

        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoTasaMoneda ModificarTasaMoneda(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoTasaMoneda Item, string Accion) {

            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoTasaMoneda Mantenimiento = null;

            var Moneda = Objdata.SP_MODIFICAR_TASA_MONEDA(
                Item.Codigo,
                Item.Prima,
                Accion);
            if (Moneda != null) {

                Mantenimiento = (from n in Moneda
                                 select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EMantenimientoTasaMoneda
                                 {
                                     Codigo = n.Codigo,
                                     Descripcion = n.Descripcion,
                                     Siglas = n.Siglas,
                                     Prima = n.Prima,
                                     Cuenta = n.Cuenta,
                                     AuxiliarCuenta = n.AuxiliarCuenta,
                                     CuentaIngreso = n.CuentaIngreso,
                                     AuxiliarIngreso = n.AuxiliarIngreso,
                                     CuentaEgreso = n.CuentaEgreso,
                                     AuxiliarEgreso = n.AuxiliarEgreso,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica,
                                     TipoCompromiso = n.TipoCompromiso,
                                     TipoCompromisoEgreso = n.TipoCompromisoEgreso,
                                     TipoCompromisoIngreso = n.TipoCompromisoIngreso,
                                     Origen = n.Origen,
                                     MonedaBase = n.MonedaBase,
                                     CuentaCobrar = n.CuentaCobrar,
                                     AuxiliarCobrar = n.AuxiliarCobrar,
                                     PrimaCobrar = n.PrimaCobrar
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion


        #region CARGA MASIVA INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECargaMasivaIntermediarios> CargaMAsivaIntermediario() {

            Objdata.CommandTimeout = 999999999;

            var Informacion = (from n in Objdata.SP_CARGA_MASIVA_INTEERMEDIARIOS()
                               select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECargaMasivaIntermediarios
                               {
                                   Compania=n.Compania,
                                   Codigo=n.Codigo,
                                   CodigoFormateado=n.CodigoFormateado,
                                   Cuenta=n.Cuenta,
                                   Auxiliar=n.Auxiliar,
                                   TipoRnc=n.TipoRnc,
                                   Rnc=n.Rnc,
                                   NombreVendedor = n.NombreVendedor,
                                   PorcientoComision = n.PorcientoComision,
                                   CodigoSupervisor = n.CodigoSupervisor,
                                   Estatus = n.Estatus,
                                   Fecha_Entrada = n.Fecha_Entrada,
                                   UsuarioAdiciona = n.UsuarioAdiciona,
                                   FechaAdiciona = n.FechaAdiciona,
                                   UsuarioModifica = n.UsuarioModifica,
                                   FechaModifica = n.FechaModifica,
                                   PorcientoGastos = n.PorcientoGastos,
                                   nota = n.nota,
                                   tipo_Intermediario = n.tipo_Intermediario,
                                   Agencia = n.Agencia,
                                   Fec_Nac = n.Fec_Nac,
                                   Publicidad = n.Publicidad,
                                   PagoComPor = n.PagoComPor,
                                   Banco = n.Banco,
                                   CtaBanco = n.CtaBanco,
                                   CodigoRnc = n.CodigoRnc,
                                   Retencion = n.Retencion,
                                   PorcDescuento = n.PorcDescuento,
                                   SupervisorCrea = n.SupervisorCrea,
                                   VendedorCrea = n.VendedorCrea,
                                   Poliza = n.Poliza,
                                   Direccion = n.Direccion,
                                   Ubicacion = n.Ubicacion,
                                   Telefono = n.Telefono,
                                   TelefonoOficina = n.TelefonoOficina,
                                   Celular = n.Celular,
                                   Beeper = n.Beeper,
                                   Fax = n.Fax,
                                   Email = n.Email,
                                   LicenciaSeguro = n.LicenciaSeguro,
                                   CodigoAnterior = n.CodigoAnterior,
                                   Apellido = n.Apellido,
                                   Nombre = n.Nombre,
                                   Oficina = n.Oficina,
                                   TipoCuentaBco = n.TipoCuentaBco,
                                   EjecutivoServicio = n.EjecutivoServicio,
                                   AsumeCxc = n.AsumeCxc,
                                   CodigoCliente = n.CodigoCliente,
                                   Record_Id = n.Record_Id,
                                   Gestor = n.Gestor,
                                   EjecutivoCobros = n.EjecutivoCobros,
                                   VenceLicencia = n.VenceLicencia
                               }).ToList();
            return Informacion;
        }


        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EGuardarClientesMasivos GaurdarClienteMasivo(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EGuardarClientesMasivos Item, string Accion) {

            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EGuardarClientesMasivos Procesar = null;

            var Clientes = Objdata.SP_GUARDAR_CLIENTE_MASIVO(
                Item.Compania,
                Item.Codigo,
                Item.TipoCliente,
                Item.TipoRnc,
                Item.RNC,
                Item.NombreCliente,
                Item.Direccion,
                Item.Ubicacion,
                Item.LimiteCredito,
                Item.Descuento,
                Item.Vendedor,
                Item.Cobrador,
                Item.Facturacion,
                Item.CondicionPago,
                Item.UsuarioAdiciona,
                Item.Estatus,
                Item.Fecha_ingreso,
                Item.FechaUltPago,
                Item.MontoUltPago,
                Item.Balance,
                Item.FechaAdiciona,
                Item.UsuarioModifica,
                Item.FechaModifica,
                Item.TelefonoResidencia,
                Item.TelefonoOficina,
                Item.fax,
                Item.Beeper,
                Item.Email,
                Item.Celular,
                Item.CodigoRnc,
                Item.Consorcio,
                Item.Ncf,
                Item.Nombre,
                Item.Apellidos,
                Item.FechaNacimiento,
                Item.FechaLicencia,
                Item.Itbis,
                Item.Contacto,
                Item.Sexo,
                Item.Comentario,
                Item.Record_Id,
                Item.Nacionalidad,
                Item.TipoRnc1,
                Item.Rnc1,
                Item.TipoRnc2,
                Item.Rnc2,
                Item.ClaseCliente,
                Item.LugarTrabajo,
                Item.CargoTrabajo,
                Item.IngresoSalarial,
                Item.EstadoCivil,
                Item.Ocupacion,
                Accion);
            if (Clientes != null) {

                Procesar = (from n in Clientes
                            select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EGuardarClientesMasivos
                            {
                                Compania=n.Compania,
                                Codigo = n.Codigo,
                                TipoCliente = n.TipoCliente,
                                TipoRnc = n.TipoRnc,
                                RNC = n.RNC,
                                NombreCliente = n.NombreCliente,
                                Direccion = n.Direccion,
                                Ubicacion = n.Ubicacion,
                                LimiteCredito = n.LimiteCredito,
                                Descuento = n.Descuento,
                                Vendedor = n.Vendedor,
                                Cobrador = n.Cobrador,
                                Facturacion = n.Facturacion,
                                CondicionPago = n.CondicionPago,
                                UsuarioAdiciona = n.UsuarioAdiciona,
                                Estatus = n.Estatus,
                                Fecha_ingreso = n.Fecha_ingreso,
                                FechaUltPago = n.FechaUltPago,
                                MontoUltPago = n.MontoUltPago,
                                Balance = n.Balance,
                                FechaAdiciona = n.FechaAdiciona,
                                UsuarioModifica = n.UsuarioModifica,
                                FechaModifica = n.FechaModifica,
                                TelefonoResidencia = n.TelefonoResidencia,
                                TelefonoOficina = n.TelefonoOficina,
                                fax = n.fax,
                                Beeper = n.Beeper,
                                Email = n.Email,
                                Celular = n.Celular,
                                CodigoRnc = n.CodigoRnc,
                                Consorcio = n.Consorcio,
                                Ncf = n.Ncf,
                                Nombre = n.Nombre,
                                Apellidos = n.Apellidos,
                                FechaNacimiento = n.FechaNacimiento,
                                FechaLicencia = n.FechaLicencia,
                                Itbis = n.Itbis,
                                Contacto = n.Contacto,
                                Sexo = n.Sexo,
                                Comentario = n.Comentario,
                                Record_Id = n.Record_Id,
                                Nacionalidad = n.Nacionalidad,
                                TipoRnc1 = n.TipoRnc1,
                                Rnc1 = n.Rnc1,
                                TipoRnc2 = n.TipoRnc2,
                                Rnc2 = n.Rnc2,
                                ClaseCliente = n.ClaseCliente,
                                LugarTrabajo = n.LugarTrabajo,
                                CargoTrabajo = n.CargoTrabajo,
                                IngresoSalarial = n.IngresoSalarial,
                                EstadoCivil = n.EstadoCivil,
                                Ocupacion = n.Ocupacion
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

    }
}
