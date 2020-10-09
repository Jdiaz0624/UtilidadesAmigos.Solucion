using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                              IdOficina=n.IdOficina,
                              IdSucursal=n.IdSucursal,
                              Sucursal=n.Sucursal,
                              Oficina=n.Oficina,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              Creadopor=n.Creadopor,
                              FechaAdiciona=n.FechaAdiciona,
                              UsuarioModifica=n.UsuarioModifica,
                              ModificadoPor=n.ModificadoPor,
                              FechaModifica=n.FechaModifica
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
                                     IdOficina=n.IdOficina,
                                     IdSucursal=n.IdSucursal,
                                     Oficina=n.Descripcion,
                                     Estatus0=n.Estatus,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona,
                                     UsuarioModifica=n.UsuarioModifica,
                                     FechaModifica=n.FechaModifica
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

            var Buscar = (from n in Objdata.SP_MAN_BUSCA_DEPARTAMENTOS(IdSucursal,IdOficina, IdDepartamento, Descripcion)
                          select new Entidades.Mantenimientos.EDepartamentos
                          {
                              IdSucursal=n.IdSucursal,
                              Sucursal=n.Sucursal,
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              CreadoPor=n.CreadoPor,
                              FechaAdiciona=n.FechaAdiciona,
                              FechaCreado=n.FechaCreado,
                              UsuarioModifica=n.UsuarioModifica,
                              ModificadoPor=n.ModificadoPor,
                              FechaModifica=n.FechaModifica,
                              FechaModificado=n.FechaModificado,
                              CantidadRegistros=n.CantidadRegistros
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
                                     IdSucursal=n.IdSucursal,
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
                              IdSucursal=n.IdSucursal,
                              Sucursal=n.Sucursal,
                              IdOfiicna=n.IdOfiicna,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              IdEmpleado=n.IdEmpleado,
                              Nombre=n.Nombre,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              CreadoPor=n.CreadoPor,
                              FechaAdiciona=n.FechaAdiciona,
                              FechaCreado=n.FechaCreado,
                              UsuarioModifica=n.UsuarioModifica,
                              ModificadoPor=n.ModificadoPor,
                              FechaModifica=n.FechaModifica,
                              FechaModificado=n.FechaModificado,
                              CantidadRegistros=n.CantidadRegistros
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
                                     IdSucursal=n.IdSucursal,
                                     IdOfiicna=n.IdOfiicna,
                                     IdDepartamento=n.IdDepartamento,
                                     IdEmpleado=n.IdEmpleado,
                                     Nombre=n.Nombre,
                                     Estatus0=n.Estatus,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona,
                                     UsuarioModifica=n.UsuarioModifica,
                                     FechaModifica=n.FechaModifica
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
                                         IdRegistro=n.IdRegistro,
                                         CodRamo=n.CodRamo,
                                         Ramo=n.Ramo,
                                         CodSubramo=n.CodSubramo,
                                         Subramo=n.Subramo,
                                         PorcientoComision=n.PorcientoComision
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
                                     IdRegistro=n.IdRegistro,
                                     CodRamo=n.Ramo,
                                     CodSubramo=n.SubRamo,
                                     PorcientoComision=n.PorcientoComision
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
                               Compania=n.Compania,
                               Codigo=n.Codigo,
                               Cuenta=n.Cuenta,
                               Auxiliar=n.Auxiliar,
                               TipoRnc=n.TipoRnc,
                               DescripcionTipoRNC=n.DescripcionTipoRNC,
                               Rnc=n.Rnc,
                               NombreVendedor=n.NombreVendedor,
                               PorcientoComision=n.PorcientoComision,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus,
                               Fecha_Entrada=n.Fecha_Entrada,
                               FechaEntrada=n.FechaEntrada,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               FechaAdiciona=n.FechaAdiciona,
                               UsuarioModifica=n.UsuarioModifica,
                               FechaModifica=n.FechaModifica,
                               PorcientoGastos=n.PorcientoGastos,
                               nota=n.nota,
                               tipo_Intermediario=n.tipo_Intermediario,
                               Agencia=n.Agencia,
                               Fec_Nac=n.Fec_Nac,
                               FechaNacimiento=n.FechaNacimiento,
                               Publicidad=n.Publicidad,
                               PagoComPor=n.PagoComPor,
                               Banco=n.Banco,
                               NombreBanco=n.NombreBanco,
                               CtaBanco=n.CtaBanco,
                               CodigoRnc=n.CodigoRnc,
                               Retencion=n.Retencion,
                               PorcDescuento=n.PorcDescuento,
                               SupervisorCrea=n.SupervisorCrea,
                               VendedorCrea=n.VendedorCrea,
                               Supervisor=n.Supervisor,
                               Poliza=n.Poliza,
                               Direccion=n.Direccion,
                               Ubicacion=n.Ubicacion,
                               DescripcionUbicacion=n.DescripcionUbicacion,
                               Telefono=n.Telefono,
                               TelefonoOficina=n.TelefonoOficina,
                               Celular=n.Celular,
                               Beeper=n.Beeper,
                               Fax=n.Fax,
                               Email=n.Email,
                               LicenciaSeguro=n.LicenciaSeguro,
                               CodigoAnterior=n.CodigoAnterior,
                               Apellido=n.Apellido,
                               Nombre=n.Nombre,
                               Oficina=n.Oficina,
                               NombreOficina=n.NombreOficina,
                               TipoCuentaBco=n.TipoCuentaBco,
                               EjecutivoServicio=n.EjecutivoServicio,
                               AsumeCxc=n.AsumeCxc,
                               CodigoCliente=n.CodigoCliente,
                               Record_Id=n.Record_Id,
                               PorcientoCapitalizacion=n.PorcientoCapitalizacion,
                               Gestor=n.Gestor,
                               EjecutivoCobros=n.EjecutivoCobros,
                               DiasCancelacionAutomatica=n.DiasCancelacionAutomatica,
                               CodigoSupervisor1=n.CodigoSupervisor1,
                               NombreSupervisor=n.NombreSupervisor,
                               CantidadRegistros=n.CantidadRegistros
                           }).ToList();
            return Listado;
        }

        //BUSCAR LAS COMISIONES DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscarComisionesIntermediarios> BuscaComisionesIntermediario(int? CodigoIntermediario = null, int? Ramo = null, int? SubRamo = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_COMISIONES_INTERMEDIARIO(CodigoIntermediario, Ramo, SubRamo)
                           select new UtilidadesAmigos.Logica.Entidades.Mantenimientos.EBuscarComisionesIntermediarios
                           {
                               Codigo=n.Codigo,
                               Intermediario=n.Intermediario,
                               IdRamo=n.IdRamo,
                               Ramo=n.Ramo,
                               IdSubRamo=n.IdSubRamo,
                               Subramo=n.Subramo,
                               PorcientoComision=n.PorcientoComision
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
                                     Compania=n.Compania,
                                     Codigo=n.Codigo,
                                     Ramo=n.Ramo,
                                     SubRamo=n.SubRamo,
                                     PorcientoComision=n.PorcientoComision,
                                     PorcientoGastos=n.PorcientoGastos,
                                     PorcientoNivel1=n.PorcientoNivel1,
                                     PorcientoNivel2=n.PorcientoNivel2,
                                     Record_Id=n.Record_Id,
                                     Usuario=n.Usuario
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
                             Codigo=n.Codigo
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
                                     Compania=n.Compania,
                                     IdIntermediario=n.IdIntermediario,
                                     IdIntermediarioSupervisa=n.IdIntermediarioSupervisa,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona
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
                               Compania=n.Compania,
                               Codigo=n.Codigo,
                               TipoCliente=n.TipoCliente,
                               TipoRnc=n.TipoRnc,
                               RNC=n.RNC,
                               NombreCliente=n.NombreCliente,
                               Ubicacion=n.Ubicacion,
                               LimiteCredito=n.LimiteCredito,
                               Descuento=n.Descuento,
                               CondicionPago=n.CondicionPago,
                               Estatus=n.Estatus,
                               FechaUltPago=n.FechaUltPago,
                               MontoUltPago=n.MontoUltPago,
                               Balance=n.Balance,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               FechaAdiciona=n.FechaAdiciona,
                               FechaCreado=n.FechaCreado,
                               UsuarioModifica=n.UsuarioModifica,
                               FechaModifica=n.FechaModifica,
                               FechaModificado=n.FechaModificado,
                               CodigoRnc=n.CodigoRnc,
                               PorcComision=n.PorcComision,
                               CodMoneda=n.CodMoneda,
                               TelefonoCasa=n.TelefonoCasa,
                               TelefonoOficina=n.TelefonoOficina,
                               Celular=n.Celular,
                               Fax=n.Fax,
                               Beeper=n.Beeper,
                               Email=n.Email,
                               TipoPago=n.TipoPago,
                               Banco=n.Banco,
                               CuentaBanco=n.CuentaBanco,
                               Contacto=n.Contacto,
                               TipoCuentaBanco=n.TipoCuentaBanco,
                               ClaseProveedor=n.ClaseProveedor
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
                                     Compania=n.Compania,
                                     Codigo=n.Codigo,
                                     TipoCliente=n.TipoCliente,
                                     TipoRnc=n.TipoRnc,
                                     RNC=n.RNC,
                                     NombreCliente=n.NombreCliente,
                                     Direccion=n.Direccion,
                                     Ubicacion=n.Ubicacion,
                                     LimiteCredito=n.LimiteCredito,
                                     Descuento=n.Descuento,
                                     CondicionPago=n.CondicionPago,
                                     Estatus=n.Estatus,
                                     FechaUltPago=n.FechaUltPago,
                                     MontoUltPago=n.MontoUltPago,
                                     Balance=n.Balance,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona,
                                     UsuarioModifica=n.UsuarioModifica,
                                     FechaModifica=n.FechaModifica,
                                     CodigoRnc=n.CodigoRnc,
                                     PorcComision=n.PorcComision,
                                     CodMoneda=n.CodMoneda,
                                     TelefonoCasa=n.TelefonoCasa,
                                     TelefonoOficina=n.TelefonoOficina,
                                     Celular=n.Celular,
                                     Fax=n.Fax,
                                     Beeper=n.Beeper,
                                     Email=n.Email,
                                     TipoPago=n.TipoPago,
                                     Banco=n.Banco,
                                     CuentaBanco=n.CuentaBanco,
                                     Contacto=n.Contacto,
                                     TipoCuentaBanco=n.TipoCuentaBanco,
                                     ClaseProveedor=n.ClaseProveedor
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
                               CodigoIntermediario=n.CodigoIntermediario,
                               Bruto=n.Bruto,
                               Neto=n.Neto,
                               Comision=n.Comision,
                               Retencion=n.Retencion,
                               Avance=n.Avance,
                               ALiquidar=n.ALiquidar
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
        public UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques ProcesarSolicitudCheques(UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarSolicitudCheques Item,DateTime? FechaDesde, DateTime? FechaHasta,decimal? TotalCobradoVendedor, decimal? ComisionBrutaVendedor,decimal? RetencionVendedor, string Accion) {
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
        #endregion

    }
}
