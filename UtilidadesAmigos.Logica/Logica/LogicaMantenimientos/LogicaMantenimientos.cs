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
                               //Beeper=n.Beeper,
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
        #endregion
    }
}
