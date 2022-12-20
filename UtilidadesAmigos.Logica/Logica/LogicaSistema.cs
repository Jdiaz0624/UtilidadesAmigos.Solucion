using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesAmigos.Logica.Entidades;

namespace UtilidadesAmigos.Logica.Logica
{
    public class LogicaSistema
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionDataContext Objdata = new Data.Conexiones.LINQ.BDConexionDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);


        #region BUSCAR LISTAS
        public List<Entidades.EListas> BuscaListas(string NombreLista = null, string PrimerFiltro = null, string SegundoFiltro = null, string TerceFiltro = null, string CuartoFiltro = null, string QuintoFiltro = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_LISTAS(NombreLista, PrimerFiltro, SegundoFiltro, TerceFiltro, CuartoFiltro, QuintoFiltro)
                          select new Entidades.EListas
                          {
                              Descripcion=n.Descripcion,
                              PrimerValor=n.PrimerValor,
                              SegundoValor=n.SegundoValor,
                              TerceValor=n.TerceValor

                          }).ToList();
            return Buscar;
        }
        #endregion

        #region MANTENIMIENTO DE USUARIOS
        //LISTADO DE USUARIOS
        public List<UtilidadesAmigos.Logica.Entidades.EUsuarios> BuscaUsuarios(decimal? IdUsuario = null, decimal? IdSucursal = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdPerfil = null, string UsuarioConsulta = null, string Usuario = null, string Clave = null, bool? Estatus = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_USUARIO(IdUsuario, IdSucursal, IdOficina, IdDepartamento, IdPerfil, UsuarioConsulta, Usuario, Clave, Estatus)
                          select new Entidades.EUsuarios
                          {
                              IdUsuario = n.IdUsuario,
                              IdSucursal=n.IdSucursal,
                              Sucursal=n.Sucursal,
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              IdPerfil=n.IdPerfil,
                              Perfil=n.Perfil,
                              Usuario=n.Usuario,
                              Clave=n.Clave,
                              Persona=n.Persona,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              LlevaEmail=n.LlevaEmail,
                              LlevaEmail0=n.LlevaEmail0,
                              Email=n.Email,
                              Contador =n.Contador,
                              CambiaClave=n.CambiaClave,
                              CambiaClave0=n.CambiaClave0,
                              RazonBloqueo=n.RazonBloqueo,
                              IdTipoPersona=n.IdTipoPersona,
                              TipoPersona=n.TipoPersona,
                              PermisoImpresionMarbete0=n.PermisoImpresionMarbete0,
                              PermisoImpresionMarbete=n.PermisoImpresionMarbete
                              

                          }).ToList();
            return Buscar;
        }

        //internal object MantenimientoUsuarios(EUsuarios procesar, string accion)
        //{
        //    throw new NotImplementedException();
        //}

        //MANTENIMIENTO DE USUARIOS
        public UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios MantenimientoUsuarios(UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios Mantenimiento = null;

            var Usuario = Objdata.SP_MANTENIMIENTO_USUARIOS(
                Item.IdUsuario,
                Item.IdSucursal,
                Item.IdOficina,
                Item.IdDepartamento,
                Item.IdPerfil,
                Item.Usuario,
                Item.Clave,
                Item.Persona,
                Item.Estatus,
                Item.LlevaEmail,
                Item.Email,
                Item.Contador,
                Item.CambiaClave,
                Item.RazonBloqueo,
                Item.IdTipoPersona,
                Item.PermisoImpresionMarbete,
                Accion);
            if (Usuario != null)
            {
                Mantenimiento = (from n in Usuario
                                 select new UtilidadesAmigos.Logica.Entidades.EMantenimientoUsuarios
                                 {
                                     IdUsuario=n.IdUsuario,
                                     IdSucursal=n.IdSucursal,
                                     IdOficina=n.IdOficina,
                                     IdDepartamento=n.IdDepartamento,
                                     IdPerfil=n.IdPerfil,
                                     Usuario=n.Usuario,
                                     Clave=n.Clave,
                                     Persona=n.Persona,
                                     Estatus=n.Estatus,
                                     LlevaEmail=n.LlevaEmail,
                                     Email=n.Email,
                                     Contador=n.Contador,
                                     CambiaClave=n.CambiaClave,
                                     RazonBloqueo=n.RazonBloqueo,
                                     IdTipoPersona = n.IdTipoPersona,
                                     PermisoImpresionMarbete =n.PermisoImpresionMarbete
                                    
                                 }).FirstOrDefault();

            }
            return Mantenimiento;
        }

        #endregion

        #region CARGAR LISTAS
        //CARGAR LOS RAMOS
        public List<Entidades.EListaRamos> CargarRamos(int? IdRamo = null, string Ramo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Cargar = (from n in Objdata.SP_LISTA_CARGAR_RAMOS(IdRamo, Ramo)
                          select new Entidades.EListaRamos
                          {
                              IdRamo=n.IdRamo,
                              Ramo=n.Ramo
                          }).ToList();
            return Cargar;
        }

        //CARGAR LOS DEPARTAMENTOS
        public List<Entidades.EListaDepartamentos> CargarDepartamentos(decimal? IdDepartamento = null, string Departamento = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_LISTA_DEPARTAMENTOS(IdDepartamento, Departamento)
                          select new Entidades.EListaDepartamentos
                          {
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento
                          }).ToList();
            return Buscar;
        }

        //CARGAR LAS OFICINAS
        //public List<Entidades.EOficinas> CargarOficinas(int? Oficina = null, string Descripcion = null)
        //{
        //    Objdata.CommandTimeout = 999999999;

        //    var Buscar = (from n in Objdata.SP_BUSCA_LISTA_OFICINAS(Oficina, Descripcion)
        //                  select new Entidades.EOficinas
        //                  {
        //                      Oficina=n.Oficina,
        //                      Descripcion=n.Descripcion
        //                  }).ToList();
        //    return Buscar;
        //}

        //CARGAR LOS EMPLEADOS
        public List<Entidades.EBuscarEmpleados> CargarEmpleados(decimal? IdDepartamento = null, decimal? IdOficina = null, decimal? IdEmpleado = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCAR_EMPLEADOS(IdDepartamento, IdOficina, IdEmpleado)
                          select new Entidades.EBuscarEmpleados
                          {
                              IdEmpleado=n.IdEmpleado,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                             Nombre=n.Nombre,
                             Oficina=n.Oficina,
                             IdOficinaPertenece=n.IdOficinaPertenece
                          }).ToList();
            return Buscar;
        }

        //CARGAR LOS SUB RAMS DETALLES
        public List<Entidades.ESacarSubramoDetalle> SacarSubRamoDetalle(string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarSubramo = (from n in Objdata.SP_SACAR_SUB_RAMOS_DETALLE(Poliza)
                                select new Entidades.ESacarSubramoDetalle
                                {
                                    SubRamo=n.SubRamo,
                                    Descripcion=n.Descripcion
                                }).ToList();
            return SacarSubramo;
        }

        //CARGAR LOS ITEM DE LA POLIZA
        public List<Entidades.ESacarItemPoliza> SacarItemsPoliza(string Poliza = null, string Ramo = null, int? SubRamo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarItem = (from n in Objdata.SP_SACAR_ITEM_POLIZA_DETALLE(Poliza, Ramo, SubRamo)
                             select new Entidades.ESacarItemPoliza
                             {
                                 Item=n.Item,
                                 ItemLetra=n.ItemLetra
                             }).ToList();
            return SacarItem;
        }

        //CARGAR LOS PERFILES
        public List<Entidades.ECargarPerfiles> CargarPerfiles(decimal? IdPerfil = null, string Perfil = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_CARGAR_PERFILES(IdPerfil, Perfil)
                          select new Entidades.ECargarPerfiles
                          {
                              IdPerfil=n.IdPerfil,
                              Perfil=n.Perfil
                          }).ToList();
            return Buscar;
        }
        public List<Entidades.ESacarRamoPoliza> SacarRamoPoliza(string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarRamo = (from n in Objdata.SP_SACAR_RAMO_DE_POLIZA(Poliza)
                             select new Entidades.ESacarRamoPoliza
                             {
                                 Ramo=n.Ramo
                             }).ToList();
            return SacarRamo;
        }
        //CARGAR LAS ACCIONES
        public List<Entidades.EAccion> BuscaAccion(int? IdAccion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_ACCION(IdAccion)
                          select new Entidades.EAccion
                          {
                              IdAccion=n.IdAccion,
                              Accion=n.Accion
                          }).ToList();
            return Buscar;
        }

        //CARGAR EL LISTADO DE COBERTURAS
        public List<Entidades.EListadoCoberturas> CargarListadoCoberturas()
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_CARGAR_LISTADO_COBERTURAS()
                           select new Entidades.EListadoCoberturas
                           {
                               IdCobertura=n.IdCobertura,
                               Cobertura=n.Cobertura,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }

        //CARGAR EL PLAN DE LA COBERTURA
        public List<Entidades.EPlanCoberturas> CargarPlanCoberturas(decimal? IdCobertuta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_CARGAR_PLAN_COBERTURA(IdCobertuta)
                           select new Entidades.EPlanCoberturas
                           {
                               IdPlanCobertura=n.IdPlanCobertura,
                               IdCobertura=n.IdCobertura,
                               Cobertura=n.Cobertura,
                               CodigoCobertura=n.CodigoCobertura,
                               planCobertura=n.planCobertura,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;


        }
        //CARGAR LOS ESTATUS DE LAS TARJETAS
        public List<Entidades.EEstatusTarjeta> CargarEstatustarjeta(decimal? IdEstatustarjeta = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Cargar = (from n in Objdata.SP_CARGAR_LISTA_ESTATUS_TARJETA(IdEstatustarjeta, Descripcion)
                          select new Entidades.EEstatusTarjeta
                          {
                              IdEstatustarjeta=n.IdEstatustarjeta,
                              Descripcion=n.Descripcion
                          }).ToList();
            return Cargar;
        }
        #endregion

        #region PRODUCCION DIARIA
        //LISTADO DE PRODUCCION DIARIA
        public List<UtilidadesAmigos.Logica.Entidades.EProduccionDiariaConsulta> ProduccionDiaria(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, string NombreRamo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_PRODUCCION_DIARIA(FechaDesde, FechaHasta, Ramo, NombreRamo)
                          select new Entidades.EProduccionDiariaConsulta
                          {
                              CodRamo=n.CodRamo,
                              Ramo=n.Ramo,
                              Concepto=n.Concepto,
                              Cantidad=n.Cantidad,
                              Moneda=n.Moneda,
                              Facturado=n.Facturado,
                              PesosDominicanos=n.PesosDominicanos,
                              TotalFacturado=n.TotalFacturado,
                              TotalPesosDominicanos=n.TotalPesosDominicanos
                          }).ToList();
            return Buscar;
        }
        //PRODUCCION DIARIA DETALLE
        public List<UtilidadesAmigos.Logica.Entidades.ESacarProduccionDiariaDetalle> ProduccionDiariaDetalle(int? Ramo = null, string Concepto = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_DETALLE_PRODUCCION_DIARIA(Ramo, Concepto, FechaDesde, FechaHasta, Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.ESacarProduccionDiariaDetalle
                           {
                               Numero=n.Numero,
                               Poliza=n.Poliza,
                               Valor=n.Valor,
                               FechaFacturacion=n.FechaFacturacion,
                               Fecha=n.Fecha,
                               Concepto=n.Concepto,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               CodSubramo=n.CodSubramo,
                               Subramo=n.Subramo,
                               NombreCliente=n.NombreCliente,
                               Telefonos=n.Telefonos,
                               Direccion=n.Direccion,
                               CodSupervisor=n.CodSupervisor,
                               Supervisor=n.Supervisor,
                               CodIntermediario=n.CodIntermediario,
                               Vendedor=n.Vendedor,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance,
                               CodOficina=n.CodOficina,
                               Oficina=n.Oficina
                           }).ToList();
            return Listado;
        }
        #endregion

        #region PRODUCCION POR USUARIOS
        //LISTADO DE PRODUCCION POR USUARIOS
        public List<Entidades.ProduccionPorUsuario> BuscaProduccionPorUsuarios(DateTime? FechaDesde = null, DateTime? FechaHasta = null,decimal? IdSucursal = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEmpleado = null, int? TipoMovimiento = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarProduccion = (from n in Objdata.SP_PRODUCCION_POR_USUARIO(FechaDesde, FechaHasta, IdSucursal, IdOficina, IdDepartamento, IdEmpleado, TipoMovimiento)
                                   select new Entidades.ProduccionPorUsuario
                                   {
                                    Sucursal=n.Sucursal,
                                    Oficina=n.Oficina,
                                    Departamento=n.Departamento,
                                    Usuario=n.Usuario,
                                    Concepto=n.Concepto,
                                    Cantidad=n.Cantidad,
                                    Total=n.Total,
                                    TotalRegistros=n.TotalRegistros,
                                    TotalValor=n.TotalValor
                                   }).ToList();
            return SacarProduccion;
        }

        //BUSCAR LA PRODUCCION POR USUARIO EN DETALLE
        public List<UtilidadesAmigos.Logica.Entidades.EProduccionUsuariosDetalle> BuscaProduccionUsuarioDetalle(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? IdSucursal = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEmpleado = null, int? TipoMovimiento = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_PRODUCCION_POR_USUARIO_DELATTE(FechaDesde, FechaHasta, IdSucursal, IdOficina, IdDepartamento, IdEmpleado, TipoMovimiento)
                           select new UtilidadesAmigos.Logica.Entidades.EProduccionUsuariosDetalle
                           {
                               Sucursal=n.Sucursal,
                               Oficina=n.Oficina,
                               Departamento=n.Departamento,
                               Usuario=n.Usuario,
                               Concepto=n.Concepto,
                               Poliza=n.Poliza,
                               Monto=n.Monto,
                               TotalRegistros=n.TotalRegistros,
                               TotalValor=n.TotalValor
                           }).ToList();
            return Listado;
        }
        #endregion

        #region PRODUCCION DIARIA TODOS LOS RAMOS
        //LISTADO DE PRODUCCION TODOS LOS RAMOS
        public List<Entidades.EProduccionTodosLosRamos> BuscaProduccionTodosLosRamos(decimal? IdUsuario = null, decimal? IdDepartamento = null, decimal? IdPerfil = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_PRODUCCION_DIARIA_TODOS_LOS_RAMOS(IdUsuario, IdDepartamento, IdPerfil)
                          select new Entidades.EProduccionTodosLosRamos
                          {
                              IdUsuario=n.IdUsuario,
                              Persona=n.Persona,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              IdPerfil=n.IdPerfil,
                              Perfl=n.Perfl,
                              Ramo=n.Ramo,
                              Concepto=n.Concepto,
                              Total=n.Total,
                              FacturadoEnPesos=n.FacturadoEnPesos,
                              FacturadoEnDollar=n.FacturadoEnDollar,
                              FacturadoTotal=n.FacturadoTotal,
                              FacturadoNeto=n.FacturadoNeto,
                              ValidadoDesde=n.ValidadoDesde,
                              ValidadoHasta=n.ValidadoHasta
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE PRODUCCION TODOS LOS RAMOS
        public Entidades.EMantenimientoProduccionTodosLosRamos MantenimientoProduccionTodosLosRamos(Entidades.EMantenimientoProduccionTodosLosRamos Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.EMantenimientoProduccionTodosLosRamos Mantenimiento = null;

            var TodosRamos = Objdata.SP_MANTENIMIENTO_PRODUCCION_DIARIA_TODOS_LOS_RAMOS(
                Item.IdUsuario,
                Item.IdDepartamento,
                Item.IdPerfil,
                Item.Ramo,
                Item.Concepto,
                Item.Total,
                Item.FacturadoEnPesos,
                Item.FacturadoEnDollar,
                Item.FacturadoTotal,
                Item.FacturadoNeto,
                Item.ValidadoDesde,
                Item.ValidadoHasta,
                Accion);
            if (TodosRamos != null)
            {
                Mantenimiento = (from n in TodosRamos
                                 select new Entidades.EMantenimientoProduccionTodosLosRamos
                                 {
                                     IdUsuario=n.IdUsuario,
                                     IdDepartamento=n.IdDepartamento,
                                     IdPerfil=n.IdPerfil,
                                     Ramo=n.Ramo,
                                     Concepto=n.Concepto,
                                     Total=n.Total,
                                     FacturadoEnPesos=n.FacturadoEnPesos,
                                     FacturadoEnDollar=n.FacturadoEnDollar,
                                     FacturadoTotal=n.FacturadoTotal,
                                     FacturadoNeto=n.FacturadoNeto,
                                     ValidadoDesde=n.ValidadoDesde,
                                     ValidadoHasta=n.ValidadoHasta
                                 }).FirstOrDefault();

            }
            return Mantenimiento;
        }
        #endregion

        #region MOSTRAR DETALLE FACTURACION, COBROS Y RECLAMACIONES
        //MOSTRAR EL DETALLE DE LA FACTURACION
        public List<Entidades.EBuscaDetalleFacturacion> BuscaDetalleFacturacion(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Usuario = null, string Concepto = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_DETALLE_FACTURACION(FechaDesde, FechaHasta, Usuario, Concepto)
                          select new Entidades.EBuscaDetalleFacturacion
                          {
                              Usuario = n.Usuario,
                              Numero = n.Numero,
                              Valor = n.Valor,
                              Poliza = n.Poliza,
                              Fecha = n.Fecha,
                              Balance = n.Balance,
                              Concepto = n.Concepto,
                              TotalPrima=n.TotalPrima
                          }).ToList();
            return Buscar;

        }

        //MOSTRAR EL DETALLE DE LOS COBROS
        public List<Entidades.EBuscaDetallesCobros> BuscaDetalleCobros(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Usuario = null, string Concepto = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.sp_BUSCA_DETALLE_COBROS(FechaDesde, FechaHasta, Usuario, Concepto)
                          select new Entidades.EBuscaDetallesCobros
                          {
                             Usuario=n.Usuario,
                             Numero=n.Numero,
                             Valor=n.Valor,
                             Poliza=n.Poliza,
                             Fecha=n.Fecha,
                             Balance=n.Balance,
                             Concepto=n.Concepto
                          }).ToList();
            return Buscar;
        }

        //MOSTRAR EL DETALLE DE LAS RECLAMACIONES
        public List<Entidades.EBuscaDetalleReclamaciones> BuscaDetalleReclamaciones(DateTime? FechaDesde = null, DateTime? FechaHAsta = null, string Usuario = null, string Accion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_DETALLE_RECLAMACIONES(FechaDesde, FechaHAsta, Usuario)
                          select new Entidades.EBuscaDetalleReclamaciones
                          {
                              Usuario=n.Usuario,
                              Reclamacion=n.Reclamacion,
                              Poliza=n.Poliza,
                              Estatus=n.Estatus,
                              Reclamado=n.Reclamado,
                              Pagado=n.Pagado,
                              Apertura=n.Apertura,
                              Siniestro=n.Siniestro,
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region SACAR EL ENCABEZADO DE LA PANTALLA
        public List<Entidades.EDetalleInformacionEncabezado> SacarDatosEncabezado(string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_DATOS_DETALLE_INFORMACION_ENCABEZADO(Poliza)
                          select new Entidades.EDetalleInformacionEncabezado
                          {
                              Poliza=n.Poliza,
                              Cotizacion=n.Cotizacion,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              Cliente=n.Cliente,
                              TipoIdentificacion=n.TipoIdentificacion,
                              Identificacion=n.Identificacion,
                              Direccion=n.Direccion,
                              Ciudad=n.Ciudad,
                              TelefonoResidencia=n.TelefonoResidencia,
                              TelefonoOficina=n.TelefonoOficina,
                              Celular=n.Celular,
                              Supervisor=n.Supervisor,
                              Intermdiario=n.Intermdiario,
                              Facturado=n.Facturado,
                              Cobrado=n.Cobrado,
                              Balance=n.Balance,
                              IdRamo=n.IdRamo,
                              Ramo=n.Ramo,
                              Oficina=n.Oficina
                          }).ToList();
            return Buscar;
        }

        //SACAMOS LOS DATOS DEL VEHICULO

        public List<Entidades.ESacarDatosVehiculoDetalle> SacarDatosVehiculosDetalle(string Poliza = null, int? Ramo = null, int? SubRamo = null, int? Secuencia = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarDatos = (from n in Objdata.SP_SACAR_DATOS_VEHICULO_DETALLE(Poliza, Ramo, SubRamo, Secuencia)
                              select new Entidades.ESacarDatosVehiculoDetalle
                              {
                                  TipoVehiculo=n.TipoVehiculo,
                                  Marca=n.Marca,
                                  Modelo=n.Modelo,
                                  Uso=n.Uso,
                                  Color=n.Color,
                                  Ano=n.Ano,
                                  ValorVehiculo=n.ValorVehiculo,
                                  Chasis=n.Chasis,
                                  Placa=n.Placa,
                                  SumaAsegurada=n.SumaAsegurada
                              }).ToList();
            return SacarDatos;
        }

        //MOSTRAR LOS DEPENDIENTES
        public List<Entidades.EDependientesDetalle> SacarDependientes(string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_DEPENDIENTES_DETALLE(Poliza)
                          select new Entidades.EDependientesDetalle
                          {
                              Dependiente=n.Dependiente,
                              Parentezco=n.Parentezco,
                              Identificacion=n.Identificacion,
                              Sexo=n.Sexo,
                              FechaNacimiento=n.FechaNacimiento
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region SEGURIDAD
        //BUSCA CLAVE DE SEGURIDAD
        public List<Entidades.EClaveSeguridad> BuscaClaveSeguridad(decimal? IdUsuario = null, string ClaveSeguridad = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_CLAVE_SEGURIDAD(IdUsuario, ClaveSeguridad)
                          select new Entidades.EClaveSeguridad
                          {
                              IdClaveSeguridad=n.IdClaveSeguridad,
                              IdUsuario=n.IdUsuario,
                              Usuario=n.Usuario,
                              Clave=n.Clave,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region PROCESAR DATOS PARA POWER BI
        //CARGAR LOS DATOS PARA LLENAR LA TABLA DE PRODUCCION
        //CON ESTA LISTA VAMOS A BUSCAR TODOS LOS REGISTROS SEGUN LOS RANGOS DE FECHAS INGRESADOS
        public List<Entidades.ECargarTablaProduccionPowerBi> CargarTablaProduccionPowerBi(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Cargar = (from n in Objdata.SP_CARGAR_TABLA_PRODUCCION_POWER_BI(FechaDesde, FechaHasta)
                          select new Entidades.ECargarTablaProduccionPowerBi
                          {
                              Supervisor=n.Supervisor,
                              Intermediario=n.Intermediario,
                              Mes=n.Mes,
                              Ano=n.Ano,
                              Facturado=n.Facturado,
                              FacturadoNeto=n.FacturadoNeto,
                              Cobrado=n.Cobrado,
                              CobradoNeto=n.CobradoNeto,
                              Poliza=n.Poliza,
                              Ramo=n.Ramo,
                              Prima=n.Prima,
                              ValorAsegurado=n.ValorAsegurado,
                              Fianza=n.Fianza,
                              ValorVehiculo=n.ValorVehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Año=n.Año
                          }).ToList();
            return Cargar;
        }

        //CON ESTE MANTENIMIENTO GUARDAMOS Y ELIMINASMOS LOS DATOS DE LA TABLA DE PRODUCCION SEGUN EL PARAMETRO DE ACCION INGRESADO.
        public Entidades.ECargarDatosTablaProduccionPowerBi CargarDatosTablaProduccionPowerBi(Entidades.ECargarDatosTablaProduccionPowerBi Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.ECargarDatosTablaProduccionPowerBi CargarData = null;

            var TablaProduccionPowerBi = Objdata.SP_CARGAR_DATOS_TABLA_PRODUCCION_POWER_BI(
                Item.Supervisor,
                Item.Intermediario,
                Item.Mes,
                Item.Año,
                Item.Facturado,
                Item.FacturadoNeto,
                Item.Cobrado,
                Item.CobradoNeto,
                Item.Poliza,
                Item.Ramo,
                Item.Prima,
                Item.ValorAsegurado,
                Item.ValorFianza,
                Item.ValorVehiculo,
                Item.Marca,
                Item.Modelo,
                Item.AñoVehiculo,
                Accion);
            if (TablaProduccionPowerBi != null)
            {
                CargarData = (from n in TablaProduccionPowerBi
                              select new Entidades.ECargarDatosTablaProduccionPowerBi
                              {
                                  Supervisor=n.Supervisor,
                                  Intermediario=n.Intermediario,
                                  Mes=n.Mes,
                                  Facturado=n.Facturado,
                                  FacturadoNeto=n.FacturadoNeto,
                                  Cobrado=n.Cobrado,
                                  CobradoNeto=n.CobradoNeto,
                                  Poliza=n.Poliza,
                                  Ramo=n.Ramo,
                                  Prima=n.Prima,
                                  ValorAsegurado=n.ValorAsegurado,
                                  ValorFianza=n.ValorFianza,
                                  ValorVehiculo=n.ValorVehiculo,
                                  Marca=n.Marca,
                                  Modelo=n.Modelo,
                                  AñoVehiculo=n.AñoVehiculo
                              }).FirstOrDefault();
            }
            return CargarData;
        }

        //CARGAMOS LA DATA QUE SE VA A EXPORTAR A EXEL
        public List<Entidades.ECargarDataproduccionPowerBi> CargarDataProduccionpowerBi()
        {
            Objdata.CommandTimeout = 999999999;

            var Cargar = (from n in Objdata.SP_CARGAR_DATA_PRODUCCION_POWER_BI()
                          select new Entidades.ECargarDataproduccionPowerBi
                          {
                              Supervisor=n.Supervisor,
                              Intermediario=n.Intermediario,
                              Mes=n.Mes,
                              Facturado=n.Facturado,
                              FacturadoNeto=n.FacturadoNeto,
                              Cobrado=n.Cobrado,
                              CobradoNeto=n.CobradoNeto,
                              Poliza=n.Poliza,
                              Ramo=n.Ramo,
                              Prima=n.Prima,
                              ValorAsegurado=n.ValorAsegurado,
                              ValorFianza=n.ValorFianza,
                              ValorVehiculo=n.ValorVehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              AñoVehiculo=n.AñoVehiculo
                          }).ToList();
            return Cargar;
        }

        //CARGAR LOS DATOS PARA LLENAR LA TABLA DE RECLAMACION
        //CON ESTA LISTA VAMOS A BUSCAR LOS REGISTRO SEGUN LOS RANGOS DE FECHA INDICADOS
        public List<Entidades.ECargarTablaReclamacionPowerBi> CargarTablaReclamacionpowerBi(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Lista = (from n in Objdata.SP_CARGAR_TABLA_RECLAMACION_POWER_BI(FechaDesde, FechaHasta)
                         select new Entidades.ECargarTablaReclamacionPowerBi
                         {
                             Supervisor=n.Supervisor,
                             intermediario=n.intermediario,
                             Mes=n.Mes,
                             Ano=n.Ano,
                             Poliza=n.Poliza,
                             Reclamacion=n.Reclamacion,
                             MontoReclamado=n.MontoReclamado,
                             MontoAjustado=n.MontoAjustado,
                             Estatus=n.Estatus,
                             Marca=n.Marca,
                             Modelo=n.Modelo,
                             Año=n.Año
                         }).ToList();
            return Lista;
        }

        //CON ESTE MANTENIMIENTO GUARDAREMOS Y ELIMINAREMOS LOS DATOS DE LA TABLA DE RECLAMACION SEGUN EL PARAMETRO DE INGRESADO
        public Entidades.ECargarDatosTablaReclamacionpowerBi CargarDatosTablaReclamacionPowerBi(Entidades.ECargarDatosTablaReclamacionpowerBi Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.ECargarDatosTablaReclamacionpowerBi CargarDatos = null;

            var TablaReclamacionPowerBi = Objdata.SP_CARGAR_DATOS_TABLA_RECLAMACION_POWER_BI(
                Item.Supervisor,
                Item.Intermediario,
                Item.Mes,
                Item.ano,
                Item.Poliza,
                Item.Reclamacion,
                Item.MontoReclamado,
                Item.MontoAjustado,
                Item.Estatus,
                Item.Marca,
                Item.Modelo,
                Item.Anovehiculo,
                Accion);
            if (TablaReclamacionPowerBi != null)
            {
                CargarDatos = (from n in TablaReclamacionPowerBi
                               select new Entidades.ECargarDatosTablaReclamacionpowerBi
                               {
                                   Supervisor=n.Supervisor,
                                   Intermediario=n.Intermediario,
                                   Mes=n.Mes,
                                   ano=n.ano,
                                   Poliza=n.Poliza,
                                   Reclamacion=n.Reclamacion,
                                   MontoReclamado=n.MontoReclamado,
                                   MontoAjustado=n.MontoAjustado,
                                   Estatus=n.Estatus,
                                   Marca=n.Marca,
                                   Modelo=n.Modelo,
                                   Anovehiculo=n.Anovehiculo
                               }).FirstOrDefault();
            }
            return CargarDatos;
        }

        //CARGAMOS LA DATA QUE SE VA A EXPORTAR A EXEL
        public List<Entidades.ECargarDataReclamacionPowerBi> CargarDataReclamacionPowerBi()
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_CARGAR_DATA_RECLAMACION_POWER_BI()
                           select new Entidades.ECargarDataReclamacionPowerBi
                           {
                               Supervisor=n.Supervisor,
                               Intermediario=n.Intermediario,
                               Mes=n.Mes,
                               Poliza=n.Poliza,
                               Reclamacion=n.Reclamacion,
                               MontoReclamado=n.MontoReclamado,
                               MontoAjustado=n.MontoAjustado,
                               Estatus=n.Estatus,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Anovehiculo=n.Anovehiculo
                           }).ToList();
            return Listado;
        }
        #endregion

        #region SACAR LO COBRADO EN LA PRODUCCION POR USUARIOS
        public List<Entidades.ESacarCobrado> SacarCobrado(DateTime? FechaDesde = null, DateTime? FechaHAsta = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdUsuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_COBRADO(FechaDesde, FechaHAsta, IdOficina, IdDepartamento, IdUsuario)
                          select new Entidades.ESacarCobrado
                          {
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              IdEmpleado=n.IdEmpleado,
                              Usuario=n.Usuario,
                              Concepto=n.Concepto,
                              Cantidad=n.Cantidad
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region SACAR EL DETALLE DE LO COBRADO
        //SACAR EL DETALLE DE LOS COBRADOS
        public List<Entidades.EDetalleCobrado> SacarDetalleCobrado(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Usuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarData = (from n in Objdata.SP_SACAR_DETALLE_COBRADO(FechaDesde, FechaHasta, Usuario)
                             select new Entidades.EDetalleCobrado
                             {
                                 Usuario=n.Usuario,
                                 Numerorecibo=n.Numerorecibo,
                                 Valor=n.Valor,
                                 Poliza=n.Poliza,
                                 FechaPago=n.FechaPago,
                                 Balance=n.Balance,
                                 Concepto=n.Concepto,
                                 Anulado=n.Anulado
                             }).ToList();   
            return SacarData;
        }
        #endregion

        #region VALIDAR LAS POLIZAS CANCELADAS DE LAS COBERTURAS
        public List<Entidades.EValidarPolizasCanceladasCoberturas> ValidarPolizasCancaladasCoberturas(string Poliza = null, int? Cobertura = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_VALIDAR_POLIZAS_CANCELADAS_COBERTURAS(Poliza, Cobertura)
                           select new Entidades.EValidarPolizasCanceladasCoberturas
                           {
                               Poliza=n.Poliza,
                               Estatus=n.Estatus,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Concepto=n.Concepto,
                               FechaMovimiento=n.FechaMovimiento,
                               DiasConsumidos=n.DiasConsumidos,
                               Total=n.Total,
                               Cobertura=n.Cobertura,
                               Comentario=n.Comentario
                           }).ToList();
            return Listado;
        }
        #endregion

        #region REPORTE DE LA UAF
        //REPORTE DE OPERACIONES SOSPECHOSAS
        public List<Entidades.EOperacionesSospechosas> ReporteOperacionesSospechosas(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var OperacionesSospechosos = (from n in Objdata.SP_REPORTE_OPERACIONES_SOSPECHOSAS(FechaDesde, FechaHasta)
                                          select new Entidades.EOperacionesSospechosas
                                          {
                                                        NoReporte =n.NoReporte,
                                                         Poliza =n.Poliza,                                                 
                                                         CodigoRegistroEntidad=n.CodigoRegistroEntidad,
                                                         Usuario =n.Usuario,
                                                         Oficina =n.Oficina,
                                                         FechaEnvio =n.FechaEnvio,
                                                         HoraEnvio =n.HoraEnvio,
                                                         TipoPersonaCliente =n.TipoPersonaCliente,
                                                         PEPCliente =n.PEPCliente,
                                                         PEPClienteTipo =n.PEPClienteTipo,
                                                         SexoCliente =n.SexoCliente,
                                                         NombreRazonSocialCliente =n.NombreRazonSocialCliente,
                                                         ApellidoRazonSocialCliente =n.ApellidoRazonSocialCliente,
                                                         NacionalidadorigenCliente =n.NacionalidadorigenCliente,
                                                         NacionalidadAdquiridaCliente =n.NacionalidadAdquiridaCliente,
                                                         TipoDocumentoCliente =n.TipoDocumentoCliente,
                                                         NoDocumentoIdentidadCliente =n.NoDocumentoIdentidadCliente,
                                                         SiTipoDocumentoIgualOtroEspesificar =n.SiTipoDocumentoIgualOtroEspesificar,
                                                         ActividadEconomicaCliente =n.ActividadEconomicaCliente,
                                                         TipoProductoCliente =n.TipoProductoCliente,
                                                         NoCuenta1 =n.NoCuenta1,
                                                         NoCuenta2 =n.NoCuenta2,
                                                         NoCuenta3 =n.NoCuenta3,
                                                         ProvinciaCliente =n.ProvinciaCliente,
                                                         MunicipioCliente =n.MunicipioCliente,
                                                         SectorCliente =n.SectorCliente,
                                                         DireccionCliente =n.DireccionCliente,
                                                         TelefonoCasaCliente =n.TelefonoCasaCliente,
                                                         TelefonoOficinaCliente =n.TelefonoOficinaCliente,
                                                         Celular1Cliente =n.Celular1Cliente,
                                                         Celular2Cliente =n.Celular2Cliente,
                                                         TipoTransaccion =n.TipoTransaccion,
                                                         DescripcionTransaccion =n.DescripcionTransaccion,
                                                         TipoMoneda =n.TipoMoneda,
                                                         MontoOriginal =n.MontoOriginal,
                                                         MontoPesosDominicanos =n.MontoPesosDominicanos,
                                                         PagoAcumuladoPesos=n.PagoAcumuladoPesos,
                                                         PagoAcumuladoDollar=n.PagoAcumuladoDollar,
                                                         TasaCambio=n.TasaCambio,
                                                         TipoInstrumento=n.TipoInstrumento,
                                                         FechaTransaccion=n.FechaTransaccion,
                                                         HoraTransaccion=n.HoraTransaccion,
                                                         FechaEnvio1=n.FechaEnvio1,
                                                         HoraTransaccion1=n.HoraTransaccion1,
                                                         OrigenFondos=n.OrigenFondos,
                                                         TransaccionRealizada=n.TransaccionRealizada,
                                                         MotivoTransaccion =n.MotivoTransaccion,
                                                         PaisOrigen=n.PaisOrigen,
                                                         PaisDestino =n.PaisDestino,
                                                         EntidadCorresponsal =n.EntidadCorresponsal,
                                                         Remesador =n.Remesador,
                                                         IntermediarioIgualCliente =n.IntermediarioIgualCliente,
                                                         SexoIntermediario =n.SexoIntermediario,
                                                         NombreRazonIntermediario =n.NombreRazonIntermediario,
                                                         ApellidoRazonIntermediario =n.ApellidoRazonIntermediario,
                                                         NacionalidadOrigenIntermediario =n.NacionalidadOrigenIntermediario,
                                                         NacionalidadAdquiridaIntermediario =n.NacionalidadAdquiridaIntermediario,
                                                         TipoRncIntermediario =n.TipoRncIntermediario,
                                                         NoDocumentoIntermediario =n.NoDocumentoIntermediario,
                                                         SiTipoDocumentoIgualOtroEspesificarIntermdiario =n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                                                         ProvinciaIntermediario =n.ProvinciaIntermediario,
                                                         MunicipioIntermediario =n.MunicipioIntermediario,
                                                         SectorIntermediario =n.SectorIntermediario,
                                                         DireccionIntermediario =n.DireccionIntermediario,
                                                         BeneficiarioIgualCliente =n.BeneficiarioIgualCliente,
                                                         SexoBeneficiario =n.SexoBeneficiario,
                                                         NombreRazonSocialBeneficiario =n.NombreRazonSocialBeneficiario,
                                                         ApellidoRazonSocialBeneficiario =n.ApellidoRazonSocialBeneficiario,
                                                         NacionalidadBeneficiario =n.NacionalidadBeneficiario,
                                                         NacionalidadAdquiridaBeneficiario =n.NacionalidadAdquiridaBeneficiario,
                                                         TipoIdentificacionBeneficiario =n.TipoIdentificacionBeneficiario,
                                                         NoDocumentoIdentidadBeneficiario =n.NoDocumentoIdentidadBeneficiario,
                                                         SiTipoDocumentoIgualOtroEspesificar1 =n.SiTipoDocumentoIgualOtroEspesificar1,
                                                         ProvinciaBeneficiario =n.ProvinciaBeneficiario,
                                                         MunicipioBeneficiario =n.MunicipioBeneficiario,
                                                         SectorBeneficiario =n.SectorBeneficiario,
                                                         DireccionBeneficiario =n.DireccionBeneficiario,
                                                         MotivoReporte =n.MotivoReporte,
                                                         EspesifiquePrioridadReporte =n.EspesifiquePrioridadReporte,
                                                         Anexo =n.Anexo,
                                                         ValidadoDesde =n.ValidadoDesde,
                                                         ValidadoHAsta =n.ValidadoHAsta
                                          }).ToList();
            return OperacionesSospechosos;
        }

        //REPORTE DE TRANSACCIONES EN EFECTIVO
        public List<Entidades.ETransaccionesEfectivo> ReporteTransaccionesEfectivo(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var TransaccionesEfectivo = (from n in Objdata.SP_REPORTE_TRANSACCIONES_EFECTIVO(FechaDesde, FechaHasta)
                                         select new Entidades.ETransaccionesEfectivo
                                         {
                                              NoReporte =n.NoReporte,
                                              Poliza =n.Poliza,
                                              CodigoRegistroEntidad=n.CodigoRegistroEntidad,
                                              Usuario=n.Usuario,
                                              Oficina=n.Oficina,
                                              FechaEnvio=n.FechaEnvio,
                                              HoraEnvio=n.HoraEnvio,
                                              TipoPersonaCliente=n.TipoPersonaCliente,
                                              PEPCliente=n.PEPCliente,
                                              PEPClienteTipo=n.PEPClienteTipo,
                                              SexoCliente=n.SexoCliente,
                                              NombreRazonSocialCliente=n.NombreRazonSocialCliente,
                                              ApellidoRazonSocialCliente=n.ApellidoRazonSocialCliente,
                                              NacionalidadorigenCliente=n.NacionalidadorigenCliente,
                                              NacionalidadAdquiridaCliente=n.NacionalidadAdquiridaCliente,
                                              TipoDocumentoCliente=n.TipoDocumentoCliente,
                                              NoDocumentoIdentidadCliente=n.NoDocumentoIdentidadCliente,
                                              SiTipoDocumentoIgualOtroEspesificar=n.SiTipoDocumentoIgualOtroEspesificar,
                                              ActividadEconomicaCliente=n.ActividadEconomicaCliente,
                                              TipoProductoCliente =n.TipoProductoCliente,
                                              NoCuenta1 =n.NoCuenta1,
                                              NoCuenta2=n.NoCuenta2,
                                              NoCuenta3=n.NoCuenta3,
                                              ProvinciaCliente=n.ProvinciaCliente,
                                              MunicipioCliente=n.MunicipioCliente,
                                              SectorCliente=n.SectorCliente,
                                              DireccionCliente=n.DireccionCliente,
                                              TelefonoCasaCliente=n.TelefonoCasaCliente,
                                              TelefonoOficinaCliente=n.TelefonoOficinaCliente,
                                              Celular1Cliente=n.Celular1Cliente,
                                              Celular2Cliente=n.Celular2Cliente,
                                              TipoTransaccion=n.TipoTransaccion,
                                              DescripcionTransaccion=n.DescripcionTransaccion,
                                              TipoMoneda=n.TipoMoneda,
                                              MontoOriginal=n.MontoOriginal,
                                               MontoPesosDominicanos=n.MontoPesosDominicanos,
                                              PagoAcumuladoPesos=n.PagoAcumuladoPesos,
                                             PagoAcumuladoDollar=n.PagoAcumuladoDollar,
                                             TasaCambio=n.TasaCambio,
                                              TipoInstrumento=n.TipoInstrumento,
                                              FechaTransaccion=n.FechaTransaccion,
                                              HoraTransaccion=n.HoraTransaccion,
                                              FechaEnvio1=n.FechaEnvio1,
                                              HoraTransaccion1=n.HoraTransaccion1,
                                              OrigenFondos=n.OrigenFondos,
                                              TransaccionRealizada=n.TransaccionRealizada,
                                              MotivoTransaccion=n.MotivoTransaccion,
                                              PaisOrigen=n.PaisOrigen,
                                              PaisDestino=n.PaisDestino,
                                              EntidadCorresponsal=n.EntidadCorresponsal,
                                              Remesador=n.Remesador,
                                              IntermediarioIgualCliente=n.IntermediarioIgualCliente,
                                              SexoIntermediario=n.SexoIntermediario,
                                              NombreRazonIntermediario=n.NombreRazonIntermediario,
                                              ApellidoRazonIntermediario=n.ApellidoRazonIntermediario,
                                              NacionalidadOrigenIntermediario=n.NacionalidadOrigenIntermediario,
                                              NacionalidadAdquiridaIntermediario=n.NacionalidadAdquiridaIntermediario,
                                              TipoRncIntermediario=n.TipoRncIntermediario,
                                              NoDocumentoIntermediario=n.NoDocumentoIntermediario,
                                              SiTipoDocumentoIgualOtroEspesificarIntermdiario=n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                                              ProvinciaIntermediario=n.ProvinciaIntermediario,
                                              MunicipioIntermediario=n.MunicipioIntermediario,
                                              SectorIntermediario=n.SectorIntermediario,
                                              DireccionIntermediario=n.DireccionIntermediario,
                                              BeneficiarioIgualCliente=n.BeneficiarioIgualCliente,
                                              SexoBeneficiario=n.SexoBeneficiario,
                                              NombreRazonSocialBeneficiario =n.NombreRazonSocialBeneficiario,
                                              ApellidoRazonSocialBeneficiario=n.ApellidoRazonSocialBeneficiario,
                                              NacionalidadBeneficiario =n.NacionalidadBeneficiario,
                                              NacionalidadAdquiridaBeneficiario =n.NacionalidadAdquiridaBeneficiario,
                                              TipoIdentificacionBeneficiario =n.TipoIdentificacionBeneficiario,
                                              NoDocumentoIdentidadBeneficiario =n.NoDocumentoIdentidadBeneficiario,
                                              SiTipoDocumentoIgualOtroEspesificar1 =n.SiTipoDocumentoIgualOtroEspesificar1,
                                              ProvinciaBeneficiario =n.ProvinciaBeneficiario,
                                              MunicipioBeneficiario =n.MunicipioBeneficiario,
                                              SectorBeneficiario =n.SectorBeneficiario,
                                              DireccionBeneficiario =n.DireccionBeneficiario,
                                              MotivoReporte =n.MotivoReporte,
                                              EspesifiquePrioridadReporte =n.EspesifiquePrioridadReporte,
                                              Anexo =n.Anexo
                                         }).ToList();
            return TransaccionesEfectivo;
        }

        public List<Entidades.EGenerarReporteTransaccionesEfectivo> GenerarReporteTransaccionesEfectivo(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? Tasa = null, decimal? UsuarioGenera = null, decimal? MontoCondicion = null, decimal? NumeroRecibo = null, string Poliza = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_GENERAR_REPORTE_DE_TRANSACCIONES_EFECTIVO(FechaDesde, FechaHasta, Tasa, UsuarioGenera, MontoCondicion, NumeroRecibo, Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.EGenerarReporteTransaccionesEfectivo
                           {
                               NumeroReporte=n.NumeroReporte,
                               Poliza=n.Poliza,
                               CodigoRegistroEntidad=n.CodigoRegistroEntidad,
                               Usuario=n.Usuario,
                               Oficina=n.Oficina,
                               FechaEnvio=n.FechaEnvio,
                               HoraEnvio=n.HoraEnvio,
                               TipoPersonaCliente=n.TipoPersonaCliente,
                               PEPCliente=n.PEPCliente,
                               PEPClienteTipo=n.PEPClienteTipo,
                               SexoCliente=n.SexoCliente,
                               NombreRazonSocialCliente=n.NombreRazonSocialCliente,
                               ApellidoRazonSocialCliente=n.ApellidoRazonSocialCliente,
                               NacionalidadorigenCliente=n.NacionalidadorigenCliente,
                               NacionalidadAdquiridaCliente=n.NacionalidadAdquiridaCliente,
                               TipoDocumentoCliente=n.TipoDocumentoCliente,
                               NoDocumentoIdentidadCliente=n.NoDocumentoIdentidadCliente,
                               SiTipoDocumentoIgualOtroEspesificar=n.SiTipoDocumentoIgualOtroEspesificar,
                               ActividadEconomicaCliente=n.ActividadEconomicaCliente,
                               TipoProductoCliente=n.TipoProductoCliente,
                               NoCuenta1=n.NoCuenta1,
                               NoCuenta2=n.NoCuenta2,
                               NoCuenta3=n.NoCuenta3,
                               ProvinciaCliente=n.ProvinciaCliente,
                               MunicipioCliente=n.MunicipioCliente,
                               SectorCliente=n.SectorCliente,
                               DireccionCliente=n.DireccionCliente,
                               TelefonoCasaCliente=n.TelefonoCasaCliente,
                               TelefonoOficinaCliente=n.TelefonoOficinaCliente,
                               Celular1Cliente=n.Celular1Cliente,
                               Celular2Cliente=n.Celular2Cliente,
                               TipoTransaccion=n.TipoTransaccion,
                               DescripcionTransaccion=n.DescripcionTransaccion,
                               TipoMoneda=n.TipoMoneda,
                               NumeroRecibo=n.NumeroRecibo,
                               FechaRecibo=n.FechaRecibo,
                               MontoOriginal=n.MontoOriginal,
                               PagoAcumuladoPesos=n.PagoAcumuladoPesos,
                               PagoAcumuladoDollar=n.PagoAcumuladoDollar,
                               TasaCambio=n.TasaCambio,
                               TipoInstrumento=n.TipoInstrumento,
                               FechaTransaccion=n.FechaTransaccion,
                               HoraTransaccion=n.HoraTransaccion,
                               FechaEnvio1=n.FechaEnvio1,
                               HoraTransaccion1=n.HoraTransaccion1,
                               OrigenFondos=n.OrigenFondos,
                               TransaccionRealizada=n.TransaccionRealizada,
                               MotivoTransaccion=n.MotivoTransaccion,
                               PaisOrigen=n.PaisOrigen,
                               PaisDestino=n.PaisDestino,
                               EntidadCorresponsal=n.EntidadCorresponsal,
                               Remesador=n.Remesador,
                               IntermediarioIgualCliente=n.IntermediarioIgualCliente,
                               SexoIntermediario=n.SexoIntermediario,
                               NombreRazonIntermediario=n.NombreRazonIntermediario,
                               ApellidoRazonIntermediario=n.ApellidoRazonIntermediario,
                               NacionalidadOrigenIntermediario=n.NacionalidadOrigenIntermediario,
                               NacionalidadAdquiridaIntermediario=n.NacionalidadAdquiridaIntermediario,
                               TipoRncIntermediario=n.TipoRncIntermediario,
                               NoDocumentoIntermediario=n.NoDocumentoIntermediario,
                               SiTipoDocumentoIgualOtroEspesificarIntermdiario=n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                               ProvinciaIntermediario=n.ProvinciaIntermediario,
                               MunicipioIntermediario=n.MunicipioIntermediario,
                               SectorIntermediario=n.SectorIntermediario,
                               DireccionIntermediario=n.DireccionIntermediario,
                               BeneficiarioIgualCliente=n.BeneficiarioIgualCliente,
                               SexoBeneficiario=n.SexoBeneficiario,
                               NombreRazonSocialBeneficiario=n.NombreRazonSocialBeneficiario,
                               ApellidoRazonSocialBeneficiario=n.ApellidoRazonSocialBeneficiario,
                               NacionalidadBeneficiario=n.NacionalidadBeneficiario,
                               NacionalidadAdquiridaBeneficiario=n.NacionalidadAdquiridaBeneficiario,
                               TipoIdentificacionBeneficiario=n.TipoIdentificacionBeneficiario,
                               NoDocumentoIdentidadBeneficiario=n.NoDocumentoIdentidadBeneficiario,
                               SiTipoDocumentoIgualOtroEspesificar1 = n.SiTipoDocumentoIgualOtroEspesificar1,
                               ProvinciaBeneficiario=n.ProvinciaBeneficiario,
                               MunicipioBeneficiario=n.MunicipioBeneficiario,
                               SectorBeneficiario=n.SectorBeneficiario,
                               DireccionBeneficiario=n.DireccionBeneficiario,
                               MotivoReporte=n.MotivoReporte,
                               EspesifiquePrioridadReporte=n.EspesifiquePrioridadReporte,
                               Anexo=n.Anexo,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               MontoCondicion=n.MontoCondicion,
                               GeneradoPor=n.GeneradoPor,
                               MontoAcumulado=n.MontoAcumulado
                                
                           }).ToList();
            return Listado;
        }

        public List<UtilidadesAmigos.Logica.Entidades.EGenerarReporteOperacionesSospechosas> GenerarReporteDeOperacionesSospechisas(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? Tasa = null, decimal? UsuarioGenera = null, decimal? MontoCondicion = null, decimal? NumeroRecio = null, string Poliza = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_GENERAR_REPORTE_DE_OPERACIONES_SOSPECHOSAS(FechaDesde, FechaHasta, Tasa, UsuarioGenera, MontoCondicion, NumeroRecio, Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.EGenerarReporteOperacionesSospechosas
                           {
                               NumeroReporte = n.NumeroReporte,
                               Poliza = n.Poliza,
                               CodigoRegistroEntidad = n.CodigoRegistroEntidad,
                               Usuario = n.Usuario,
                               Oficina = n.Oficina,
                               FechaEnvio = n.FechaEnvio,
                               HoraEnvio = n.HoraEnvio,
                               TipoPersonaCliente = n.TipoPersonaCliente,
                               PEPCliente = n.PEPCliente,
                               PEPClienteTipo = n.PEPClienteTipo,
                               SexoCliente = n.SexoCliente,
                               NombreRazonSocialCliente = n.NombreRazonSocialCliente,
                               ApellidoRazonSocialCliente = n.ApellidoRazonSocialCliente,
                               NacionalidadorigenCliente = n.NacionalidadorigenCliente,
                               NacionalidadAdquiridaCliente = n.NacionalidadAdquiridaCliente,
                               TipoDocumentoCliente = n.TipoDocumentoCliente,
                               NoDocumentoIdentidadCliente = n.NoDocumentoIdentidadCliente,
                               SiTipoDocumentoIgualOtroEspesificar = n.SiTipoDocumentoIgualOtroEspesificar,
                               ActividadEconomicaCliente = n.ActividadEconomicaCliente,
                               TipoProductoCliente = n.TipoProductoCliente,
                               NoCuenta1 = n.NoCuenta1,
                               NoCuenta2 = n.NoCuenta2,
                               NoCuenta3 = n.NoCuenta3,
                               ProvinciaCliente = n.ProvinciaCliente,
                               MunicipioCliente = n.MunicipioCliente,
                               SectorCliente = n.SectorCliente,
                               DireccionCliente = n.DireccionCliente,
                               TelefonoCasaCliente = n.TelefonoCasaCliente,
                               TelefonoOficinaCliente = n.TelefonoOficinaCliente,
                               Celular1Cliente = n.Celular1Cliente,
                               Celular2Cliente = n.Celular2Cliente,
                               TipoTransaccion = n.TipoTransaccion,
                               DescripcionTransaccion = n.DescripcionTransaccion,
                               TipoMoneda = n.TipoMoneda,
                               NumeroRecibo = n.NumeroRecibo,
                               FechaRecibo = n.FechaRecibo,
                               MontoOriginal = n.MontoOriginal,
                               PagoAcumuladoPesos = n.PagoAcumuladoPesos,
                               PagoAcumuladoDollar = n.PagoAcumuladoDollar,
                               TasaCambio = n.TasaCambio,
                               TipoInstrumento = n.TipoInstrumento,
                               FechaTransaccion = n.FechaTransaccion,
                               HoraTransaccion = n.HoraTransaccion,
                               FechaEnvio1 = n.FechaEnvio1,
                               HoraTransaccion1 = n.HoraTransaccion1,
                               OrigenFondos = n.OrigenFondos,
                               TransaccionRealizada = n.TransaccionRealizada,
                               MotivoTransaccion = n.MotivoTransaccion,
                               PaisOrigen = n.PaisOrigen,
                               PaisDestino = n.PaisDestino,
                               EntidadCorresponsal = n.EntidadCorresponsal,
                               Remesador = n.Remesador,
                               IntermediarioIgualCliente = n.IntermediarioIgualCliente,
                               SexoIntermediario = n.SexoIntermediario,
                               NombreRazonIntermediario = n.NombreRazonIntermediario,
                               ApellidoRazonIntermediario = n.ApellidoRazonIntermediario,
                               NacionalidadOrigenIntermediario = n.NacionalidadOrigenIntermediario,
                               NacionalidadAdquiridaIntermediario = n.NacionalidadAdquiridaIntermediario,
                               TipoRncIntermediario = n.TipoRncIntermediario,
                               NoDocumentoIntermediario = n.NoDocumentoIntermediario,
                               SiTipoDocumentoIgualOtroEspesificarIntermdiario = n.SiTipoDocumentoIgualOtroEspesificarIntermdiario,
                               ProvinciaIntermediario = n.ProvinciaIntermediario,
                               MunicipioIntermediario = n.MunicipioIntermediario,
                               SectorIntermediario = n.SectorIntermediario,
                               DireccionIntermediario = n.DireccionIntermediario,
                               BeneficiarioIgualCliente = n.BeneficiarioIgualCliente,
                               SexoBeneficiario = n.SexoBeneficiario,
                               NombreRazonSocialBeneficiario = n.NombreRazonSocialBeneficiario,
                               ApellidoRazonSocialBeneficiario = n.ApellidoRazonSocialBeneficiario,
                               NacionalidadBeneficiario = n.NacionalidadBeneficiario,
                               NacionalidadAdquiridaBeneficiario = n.NacionalidadAdquiridaBeneficiario,
                               TipoIdentificacionBeneficiario = n.TipoIdentificacionBeneficiario,
                               NoDocumentoIdentidadBeneficiario = n.NoDocumentoIdentidadBeneficiario,
                               SiTipoDocumentoIgualOtroEspesificar1 = n.SiTipoDocumentoIgualOtroEspesificar1,
                               ProvinciaBeneficiario = n.ProvinciaBeneficiario,
                               MunicipioBeneficiario = n.MunicipioBeneficiario,
                               SectorBeneficiario = n.SectorBeneficiario,
                               DireccionBeneficiario = n.DireccionBeneficiario,
                               MotivoReporte = n.MotivoReporte,
                               EspesifiquePrioridadReporte = n.EspesifiquePrioridadReporte,
                               Anexo = n.Anexo,
                               ValidadoDesde = n.ValidadoDesde,
                               ValidadoHasta = n.ValidadoHasta,
                               MontoCondicion = n.MontoCondicion,
                               GeneradoPor = n.GeneradoPor,
                               MontoAcumulado = n.MontoAcumulado
                           }).ToList();
            return Listado;
        }
        #endregion

        #region SACAR DATA COBERTURAS
        //SACAR LA DATA DE LAS COBERTURAS
        public List<Entidades.ESacarDataCobertura> SacarDataCobertura(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Cobertura = null, string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_DATA_CASA_COBERTURAS(FechaDesde, FechaHasta, Cobertura, Poliza)
                           select new Entidades.ESacarDataCobertura
                           {
                               Poliza=n.Poliza,
                               Intermediario=n.Intermediario,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               MesValidado=n.MesValidado,
                               TipoVehiculo=n.TipoVehiculo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Capacidad=n.Capacidad,
                               Ano=n.Ano,
                               Color=n.Color,
                               Chasis=n.Chasis,
                               Placa=n.Placa,
                               ValorAsegurado=n.ValorAsegurado,
                               ConceptoMov=n.ConceptoMov,
                               Estatus=n.Estatus,
                               Cobertura=n.Cobertura
                           }).ToList();
            return Listado;
        }
        #endregion

        #region SACAR LA CARTERA DE LOS SUPERVISORES
        //SACAR EL LISTADO DE LA CARTERA DE LOS SUPERVISORES
        public List<UtilidadesAmigos.Logica.Entidades.ECarteraSupervisor> SacarCarteraSupervisor(decimal? CodigoSupervisor = null, decimal? CodigoIntermediario = null,string NombreIntermediario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_CARTERA_SUPERVISORES(CodigoSupervisor, CodigoIntermediario,NombreIntermediario)
                           select new UtilidadesAmigos.Logica.Entidades.ECarteraSupervisor
                           {
                               Supervisor=n.Supervisor,
                               Intermediario=n.Intermediario,
                               CodIntermediario=n.CodIntermediario,
                               Telefono=n.Telefono,
                               Direccion=n.Direccion,
                               Estatus=n.Estatus,
                               OficinaSupervisor=n.OficinaSupervisor
                           }).ToList();
            return Listado;
        }

        //MOSTRAR EL LISTADO DE LOS CLIENTES DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaClienteIntermediario> ListadoClientesintermediarios(decimal? IdIntermediario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_CLIENTES_INTERMEDIARIO(IdIntermediario)
                           select new UtilidadesAmigos.Logica.Entidades.EBuscaClienteIntermediario
                           {
                               Poliza=n.Poliza,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               CodSubramo=n.CodSubramo,
                               Subramo=n.Subramo,
                               Estatus=n.Estatus,
                               CodOficina=n.CodOficina,
                               Oficina=n.Oficina,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Neto=n.Neto,
                               Supervisor=n.Supervisor,
                               Vendedor=n.Vendedor,
                               TelefonosVendedor=n.TelefonosVendedor,
                               DireccionVendedor=n.DireccionVendedor,
                               Cliente=n.Cliente,
                               Direccion=n.Direccion,
                               TipoIdentificacion=n.TipoIdentificacion,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               TelefonosClientes=n.TelefonosClientes,
                               TipoVehiculo=n.TipoVehiculo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Capacidad=n.Capacidad,
                               Ano=n.Ano,
                               Color=n.Color,
                               Chasis=n.Chasis,
                               Placa=n.Placa,
                               Uso=n.Uso,
                               ValorVehiculo=n.ValorVehiculo,
                               CantidadPuerta=n.CantidadPuerta,
                               Fianza=n.Fianza,
                               Onservacion=n.Onservacion,
                               Deducible=n.Deducible,
                               Coaseguro=n.Coaseguro,
                               TotalFacturado=n.TotalFacturado,
                               TotalCobrado=n.TotalCobrado,
                               Balance=n.Balance,
                               __1_30=n._1_30,
                               __31_60=n._31_60,
                               __61_90=n._61_90,
                               __91_120=n._91_120,
                               __121_O_MAS=n._121_O_MAS
                           }).ToList();
            return Listado;
        }

        //SACAR LAS COMISIONES DE LOS SUPERVISORES
        public List<UtilidadesAmigos.Logica.Entidades.EComisionesSupervisores> ComisionesSupervisores(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string CodigoSupervisor = null, int? Oficina = null,decimal? UsuarioGenera = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_COMISIONES_SUPERVISORES(FechaDesde, FechaHasta, CodigoSupervisor, Oficina, UsuarioGenera)
                           select new UtilidadesAmigos.Logica.Entidades.EComisionesSupervisores
                           {
                            CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               Poliza=n.Poliza,
                               NumeroFactura=n.NumeroFactura,
                               Valor=n.Valor,
                               Fecha=n.Fecha,
                               Fecha0=n.Fecha0,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               Concepto=n.Concepto,
                               PorcuentoComision=n.PorcuentoComision,
                               ComisionPagar=n.ComisionPagar,
                               GeneradoPor=n.GeneradoPor,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta
                           }).ToList();
            return Listado;
        }

        //SACAR LOS MONTOS DE LAS COMISIONES DE LOS SUPERVISORES
        public List<UtilidadesAmigos.Logica.Entidades.ESacarMontoComisionesSupervisores> SacarmontoComisiones(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? CodigoSupervisor = null, int? Oficina = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Monto = (from n in Objdata.SP_SACAR_MONTO_COMISIONES_SUPERVISORES(FechaDesde, FechaHasta, CodigoSupervisor, Oficina)
                         select new UtilidadesAmigos.Logica.Entidades.ESacarMontoComisionesSupervisores
                         {
                             ComisionPagar = n.ComisionPagar
                         }).ToList();
            return Monto;
        }
        #endregion

        #region SACAR EL LISTADO DE LAS RECLAMACIONES
        public List<Entidades.ESacarreclamaciones> SacarReclamacionesHeader(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Oficina = null,decimal? Departamento = null, decimal? Usuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_RECLAMACIONES(FechaDesde, FechaHasta, Oficina,Departamento, Usuario)
                           select new Entidades.ESacarreclamaciones
                           {
                               Oficina=n.Oficina,
                               Departamento=n.Departamento,
                               Usuario=n.Usuario,
                               Concepto=n.Concepto,
                               Cantidad=n.Cantidad
                           }).ToList();
            return Listado;
        }
        #endregion

        #region SACAR EL DETALLE DE LO COBRADO POR USUARIO
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDetalleCobradoUsuario> SacarDetalleCobradoUsuario(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Usuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Detalle = (from n in Objdata.SP_SACAR_DETALLE_COBRADO_USUARIO(FechaDesde, FechaHasta, Usuario)
                           select new UtilidadesAmigos.Logica.Entidades.ESacarDetalleCobradoUsuario
                           {
                               Usuario=n.Usuario,
                               Numero=n.Numero,
                               Valor=n.Valor,
                               Poliza=n.Poliza,
                               Fecha=n.Fecha,
                               Facturado=n.Facturado,
                               TotalPagado=n.TotalPagado,
                               Balance=n.Balance,
                               Concepto=n.Concepto,
                               TotalPrima=n.TotalPrima

                           }).ToList();
            return Detalle;
        }
        #endregion

        #region GENERAR DATA COBERTURAS
        //GENERAR LA DATA DE AEROAMBULANCIA
        public List<UtilidadesAmigos.Logica.Entidades.EGenerarDataGruaAeroAmbulancia> GenerarDataAeroAmbulancia(decimal? Cobertura = null, string Poliza = null, string Chasis = null, string Estatus = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_GENERAR_DATA_GRUAS_AERO_AMBULANCIA(Cobertura,Poliza,Chasis,Estatus,FechaDesde,FechaHasta)
                          select new UtilidadesAmigos.Logica.Entidades.EGenerarDataGruaAeroAmbulancia
                          {
                              Poliza=n.Poliza,
                              Cliente=n.Cliente,
                              NumeroIdentificacion=n.NumeroIdentificacion,
                              Telefonos=n.Telefonos,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              TipoVehiculo=n.TipoVehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Capacidad=n.Capacidad,
                              Color=n.Color,
                              Ano=n.Ano,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              ValorAsegurado=n.ValorAsegurado,
                              Cobertura=n.Cobertura,
                              TipoPlan=n.TipoPlan,
                              Estatus=n.Estatus
                          }).ToList();
            return Buscar;
        }

        //GENERAR LA DATA DE CEDENSA
        public List<UtilidadesAmigos.Logica.Entidades.EGenerarDataCedensa> GenerarDataCedensa()
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_GENERAR_DATA_CEDENSA()
                           select new UtilidadesAmigos.Logica.Entidades.EGenerarDataCedensa
                           {
                              Poliza=n.Poliza,
                              Fecha_de_Adiciona=n.Fecha_de_Adiciona,
                              Inicio_de_Vigencia=n.Inicio_de_Vigencia,
                              Fin_de_Vigencia=n.Fin_de_Vigencia,
                              Tipo_de_Plan=n.Tipo_de_Plan,
                              Estatus=n.Estatus,
                              Parentezco=n.Parentezco,
                              Nombre=n.Nombre,
                              Provincia=n.Provincia,
                              Direccion=n.Direccion,
                              Telefono=n.Telefono,
                              Cedula=n.Cedula,
                              Fecha_de_Nacimiento=n.Fecha_de_Nacimiento,
                              Prima=n.Prima
                           }).ToList();
            return Listado;
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LAS POLIZAS A LAS CUALES SE LES A ELIMINAR EL BALANCE
        //LISTADO
        public List<Entidades.EPolizaEliminarBalanceCreditos> ListadPolizasEliminarBalance(string Poliza = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_POLIZAS_ELIMINAR_BALANCE_CREDITO(Poliza)
                          select new Entidades.EPolizaEliminarBalanceCreditos
                          {
                              Poliza=n.Poliza,
                              Balance=n.Balance
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region MANTENIMIENTO DE COBERTURAS Y PLAN DE COBERTURAS
        //LISTADO DE COBERTURAS
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento> BuscaCoberturaMantenimiento(decimal? IdCobertura = null, string Cobertura = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_COBERTURAS(IdCobertura, Cobertura)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento
                          {
                              IdCobertura=n.IdCobertura,
                              Descripcion=n.Descripcion,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus
                          }).ToList();
            return Buscar;
        }
        //MANTENIMIENTO DE COBERTURAS
        public UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento MantenimientoCobertura(UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento Mantenimiento = null;

            var Cobertura = Objdata.SP_MANTENIMIENTO_COBERTURA(
                Item.IdCobertura,
                Item.Descripcion,
                Item.Estatus0,
                Accion);
            if (Cobertura != null)
            {
                Mantenimiento = (from n in Cobertura
                                 select new UtilidadesAmigos.Logica.Entidades.EBuscaCoberturasMantenimiento
                                 {
                                     IdCobertura=n.IdCobertura,
                                     Descripcion=n.Descripcion,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }


        //LISTADO DE PLAN DE COBERTURAS
        public List<UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento> BuscaPlanCoberturas(decimal? IdPlanCobertura = null, decimal? IdCobertura = null, decimal? CodigoCobertura = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_PLAN_COBERTURAS(IdPlanCobertura, IdCobertura, CodigoCobertura, Descripcion)
                          select new UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento
                          {
                              IdPlanCobertura=n.IdPlanCobertura,
                              IdCobertura=n.IdCobertura,
                              Cobertura=n.Cobertura,
                              CodigoCobertura=n.CodigoCobertura,
                              PlanCobertura=n.PlanCobertura,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE PLAND E COBERTURAS
        public UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento MantenimientoPlanCoberturas(UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento Mantenimiento = null;

            var PlanCobertura = Objdata.SP_MANTENIMIENTO_PLAN_COBERTURA(
                Item.IdPlanCobertura,
                Item.IdCobertura,
                Item.CodigoCobertura,
                Item.PlanCobertura,
                Item.Estatus0,
                Accion);
            if (Mantenimiento != null)
            {
                Mantenimiento = (from n in PlanCobertura
                                 select new UtilidadesAmigos.Logica.Entidades.EPlanCoberturasMantenimiento
                                 {
                                     IdPlanCobertura=n.IdPlanCobertura,
                                     IdCobertura=n.IdCobertura,
                                     CodigoCobertura=n.CodigoCobertura,
                                     PlanCobertura=n.Descripcion,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region SACAR DATA DE LA CASA DEL CONDUCTOR
        //SACAR EL LISTADO DE LA DATA DE LA CASA DEL CONDUCTOR
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDataCasaConductor> SacarDataCasaConductor(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null, int? Cobertura = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_DATA_CASA_CONDUCTOR(FechaDesde, FechaHasta, Poliza, Cobertura)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarDataCasaConductor
                          {
                              Poliza=n.Poliza,
                              Items=n.Items,
                              Estatus=n.Estatus,
                              Concepto=n.Concepto,
                              Cliente=n.Cliente,
                              TipoIdentificacion=n.TipoIdentificacion,
                              NumeroIdentificacion=n.NumeroIdentificacion,
                              Intermediario=n.Intermediario,
                              FechaInicioVigencia=n.FechaInicioVigencia,
                              FechaFinVigencia=n.FechaFinVigencia,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              FechaProcesoBruto=n.FechaProcesoBruto,
                              FechaProceso=n.FechaProceso,
                              MesValidado=n.MesValidado,
                              Tipovehiculo=n.Tipovehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Capacidad=n.Capacidad,
                              Ano=n.Ano,
                              Color=n.Color,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              ValorAsegurado=n.ValorAsegurado,
                              Cobertura=n.Cobertura,
                              TipoMovimiento=n.TipoMovimiento,
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region SACAR LA DATA DE CEDENSA
        //SACAMOS EL LISTADO DE LA DATA DE CEDENSA
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDataCedensa> SacarDataCedensa(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null, int? Subramo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_DATA_CEDENSA(FechaDesde, FechaHasta, Poliza, Subramo)
                           select new UtilidadesAmigos.Logica.Entidades.ESacarDataCedensa
                           {
                               Poliza=n.Poliza,
                               Cobertura=n.Cobertura,
                               Parentezco=n.Parentezco,
                               Nombre=n.Nombre,
                               Cotizacion=n.Cotizacion,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               Estatus = n.Estatus,
                               Concepto=n.Concepto,
                               Cliente=n.Cliente,
                               TipoIdentificacion=n.TipoIdentificacion,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               Intermediario=n.Intermediario,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               FechaFinVigencia=n.FechaFinVigencia,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               FechaProcesoBruto=n.FechaProcesoBruto,
                               FechaProceso=n.FechaProceso,
                               MesValidado=n.MesValidado,
                               Provincia=n.Provincia,
                               Direccion=n.Direccion,
                               Telefono=n.Telefono,
                               Cedula=n.Cedula,
                               FechadeNacimiento=n.FechadeNacimiento,
                               Edad=n.Edad,
                               Prima=n.Prima,
                               TipoMovimiento=n.TipoMovimiento
                           }).ToList();
            return Listado;
        }
        #endregion

        #region SACAR LA DATA DE TU ASISTENCIA
        //SACAR EL LISTADO DE TU ASISTENCIA
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDataTuAsistencia> SacarDataTuAsistencia(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null, int? Cobertura = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_DATA_TU_ASISTENCIA(FechaDesde, FechaHasta, Poliza, Cobertura)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarDataTuAsistencia
                          {
                              Nombre=n.Nombre,
                              Apellido=n.Apellido,
                              Poliza=n.Poliza,
                              Ciudad=n.Ciudad,
                              Direccion=n.Direccion,
                              Telefono=n.Telefono,
                              TipoIdentificacion=n.TipoIdentificacion,
                              NumeroIdentificacion=n.NumeroIdentificacion,
                              Tipovehiculo=n.Tipovehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Ano=n.Ano,
                              Color=n.Color,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              Estatus=n.Estatus,
                              Cobertura = n.Cobertura,
                              Items=n.Items,
                              Concepto=n.Concepto,
                              Cliente=n.Cliente,
                              TipoIdentificacion1=n.TipoIdentificacion1,
                              NumeroIdentificacion1=n.NumeroIdentificacion1,
                              Intermediario=n.Intermediario,
                              FechaInicioVigencia=n.FechaInicioVigencia,
                              FechaFinVigencia=n.FechaFinVigencia,
                              Prima=n.Prima,
                              FechaProcesoBruto=n.FechaProcesoBruto,
                              FechaProceso=n.FechaProceso,
                              MesValidado=n.MesValidado,
                              TipoMovimiento=n.TipoMovimiento
                          }).ToList();
            return Buscar;
        }

        #endregion

        #region SACAR LA DATA DE LAS COBERTURAS FINAL
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDataCoberturasFinal> SacarDataCoberturasFinal(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null, int? Cobertura = null, int? Oficina = null, decimal? UsuarioGenera = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_DATA_COBERTURA_FINAL(FechaDesde, FechaHasta, Poliza, Cobertura, Oficina, UsuarioGenera)
                           select new UtilidadesAmigos.Logica.Entidades.ESacarDataCoberturasFinal
                           {
                               Poliza=n.Poliza,
                               Items=n.Items,
                               Estatus = n.Estatus,
                               Concepto=n.Concepto,
                               Cliente=n.Cliente,
                               NombreCliente=n.NombreCliente,
                               ApellidoCliente=n.ApellidoCliente,
                               Ciudad=n.Ciudad,
                               DireccionCliente=n.DireccionCliente,
                               Telefono=n.Telefono,
                               TipoIdentificacion=n.TipoIdentificacion,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               Intermediario=n.Intermediario,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               FechaFinVigencia=n.FechaFinVigencia,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               FechaProceso=n.FechaProceso,
                               FechaProcesoBruto=n.FechaProcesoBruto,
                               MesValidado=n.MesValidado,
                               Tipovehiculo=n.Tipovehiculo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Capacidad=n.Capacidad,
                               Ano=n.Ano,
                               Color=n.Color,
                               Chasis=n.Chasis,
                               Placa=n.Placa,
                               ValorAsegurado=n.ValorAsegurado,
                               Cobertura=n.Cobertura,
                               TipoMovimiento=n.TipoMovimiento,
                               CantidadRegistros=n.CantidadRegistros,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               GeneradoPor=n.GeneradoPor,
                               Oficina=n.Oficina
                           }).ToList();
            return Listado;
        }
        #endregion

        #region CONTAR REGISTROS
        //CONTAR LOS REGISTROS DE TU ASISTENCIA
        public List<UtilidadesAmigos.Logica.Entidades.EContarRegistros> ContarRegistrosTuAsistencia(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null, int? Cobertura = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Contar = (from n in Objdata.SP_CONTAR_DATA_TU_ASISTENCIA(FechaDesde, FechaHasta, Poliza, Cobertura)
                          select new UtilidadesAmigos.Logica.Entidades.EContarRegistros
                          {
                              Total=n.Total
                          }).ToList();
            return Contar;
        }

        //CONTAR LOS REGISTROS CORRESPONDIENTE A CEDENSA
        public List<UtilidadesAmigos.Logica.Entidades.EContarRegistros> ContarRegistrosCedensa(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null, int? Subramo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Contar = (from n in Objdata.SP_CONTAR_DATA_CEDENSA(FechaDesde, FechaHasta, Poliza, Subramo)
                          select new UtilidadesAmigos.Logica.Entidades.EContarRegistros
                          {
                              Total=n.Total
                          }).ToList();
            return Contar;
        }

        //CONTAR LOS REGISTROS CORRESPONDIENTE A CASA DEL CONDUCTOR Y AEROAMBULANCIA
        public List<UtilidadesAmigos.Logica.Entidades.EContarRegistros> ContarRegistrosCasaConductoraeroAmbulancia(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Poliza = null,int? Cobertura = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Contar = (from n in Objdata.SP_CONTAR_DATA_CASA_CONDUCTOR(FechaDesde, FechaHasta, Poliza, Cobertura)
                          select new UtilidadesAmigos.Logica.Entidades.EContarRegistros
                          {
                              Total=n.Total
                          }).ToList();
            return Contar;

            }
        #endregion

        #region MANTENIMIENTO DE DEPENDIENTES
        //MOSTRAR EL LISTADO DE LOS DEPENDIENTES
        public List<UtilidadesAmigos.Logica.Entidades.EDependientes> BuscaDependientes(string Poliza = null,decimal? IdAsegurado = null,string NombreDependiente = null, string NumeroIdentificacion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCAR_DEPENDIENTES(Poliza, IdAsegurado, NombreDependiente, NumeroIdentificacion)
                          select new UtilidadesAmigos.Logica.Entidades.EDependientes
                          {
                              Poliza=n.Poliza,
                              Ramo=n.Ramo,
                              SubRamo=n.SubRamo,
                              Estatus=n.Estatus,
                              Compania=n.Compania,
                              Cotizacion=n.Cotizacion,
                              Secuencia=n.Secuencia,
                              IdAsegurado=n.IdAsegurado,
                              Nombre=n.Nombre,
                              Parentezco=n.Parentezco,
                              Cedula=n.Cedula,
                              FechaNacimiento0=n.FechaNacimiento0,
                              FechaNacimiento=n.FechaNacimiento,
                              Sexo=n.Sexo,
                              PorcPrima=n.PorcPrima,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              FechaAdiciona0=n.FechaAdiciona0,
                              FechaAdiciona=n.FechaAdiciona,
                              Estatus0=n.Estatus0,
                              ValorAsegurado=n.ValorAsegurado,
                              PorcCobertura=n.PorcCobertura,
                              FechaInclusion=n.FechaInclusion,
                              FechaInclusion0=n.FechaInclusion0,
                              FechaInicioCobertura=n.FechaInicioCobertura,
                              FechaInicioCobertura0=n.FechaInicioCobertura0
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE DEPENDIENTES
        public UtilidadesAmigos.Logica.Entidades.EDependientes MantenimientoDependientes(UtilidadesAmigos.Logica.Entidades.EDependientes Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EDependientes Mantenimiento = null;

            var Dependientes = Objdata.SP_GUARDAR_DEPENDIENTES(
                Item.Compania,
                Item.Cotizacion,
                Item.Secuencia,
                Item.IdAsegurado,
                Item.Nombre,
                Item.Parentezco,
                Item.Cedula,
                Item.FechaNacimiento0,
                Item.Sexo,
                Item.PorcPrima,
                Item.UsuarioAdiciona,
                Item.FechaAdiciona0,
                Item.Estatus0,
                Item.ValorAsegurado,
                Item.PorcCobertura,
                Item.FechaInclusion0,
                Item.FechaInicioCobertura0,
                Accion);
            if (Dependientes != null)
            {
                Mantenimiento = (from n in Dependientes
                                 select new UtilidadesAmigos.Logica.Entidades.EDependientes
                                 {
                                     //Compania=n.Compania,
                                     //Cotizacion=n.Cotizacion,
                                     //Secuencia=n.Secuencia,
                                     //IdAsegurado=n.IdAsegurado,
                                     //Nombre=n.Nombre,
                                     //Parentezco=n.Parentezco,
                                     //Cedula=n.NumeroId,
                                     //FechaNacimiento0=n.FechaNacimiento,
                                     //Sexo=n.Sexo,
                                     //PorcPrima=n.PorcPrima,
                                     //UsuarioAdiciona=n.UsuarioAdiciona,
                                     //FechaAdiciona0=n.FechaAdiciona,
                                     //Estatus0=n.Estatus,
                                     //ValorAsegurado=n.ValorAsegurado,
                                     //PorcCobertura=n.PorcCobertura,
                                     //FechaInclusion0=n.FechaInclusion,
                                     //FechaInicioCobertura0=n.FechaInicioCobertura
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region CARTERA INTERMEDIARIO
        //SACAR LOS DATOS DEL INTERMEDIARIO
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDatosIntermediarios> SacarDatosIntermediarios(string CodigoSupervisor = null, string CodigoIntermediario = null, int? OficinaIntermediario = null, string NombreIntermediario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarDatos = (from n in Objdata.SP_SACAR_DATOS_INTERMEDIARIOS(CodigoSupervisor, CodigoIntermediario, OficinaIntermediario, NombreIntermediario)
                              select new UtilidadesAmigos.Logica.Entidades.ESacarDatosIntermediarios
                              {
                                  CodSupervisor=n.CodSupervisor,
                                  Supervisor=n.Supervisor,
                                  Codigo=n.Codigo,
                                  NombreVendedor=n.NombreVendedor,
                                  Oficina=n.Oficina,
                                  Estatus=n.Estatus,
                                  CantidadRegistros=n.CantidadRegistros
                              }).ToList();
            return SacarDatos;
        }

        //SACAR LA CARTERA DE INTERMEDIARIO
        public List<UtilidadesAmigos.Logica.Entidades.ESacarCarteraIntermediario> BuscaSacarCarteraIntermediario(decimal? CodigoSupervisor = null, decimal? CodigoIntermediario = null, int? OficinaIntermediario = null, string NombreIntermediario = null)
        {
            Objdata.CommandTimeout = 99999999;

            var Buscar = (from n in Objdata.SP_SACAR_CARTERA_INTERMEDIARIO(CodigoSupervisor, CodigoIntermediario, OficinaIntermediario, NombreIntermediario)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarCarteraIntermediario
                          {
                              Supervisor=n.Supervisor,
                              Intermediario=n.Intermediario,
                              CodigoSupervisor=n.CodigoSupervisor,
                              CodigoIntermediario=n.CodigoIntermediario,
                              Poliza=n.Poliza,
                              Estatus=n.Estatus,
                              Ramo=n.Ramo,
                              SubRamo=n.SubRamo,
                              Cliente=n.Cliente,
                              Telefonos=n.Telefonos,
                              SumaAsegurada=n.SumaAsegurada,
                              prima=n.prima,
                              TotalFacturado=n.TotalFacturado,
                              TotalPagado=n.TotalPagado,
                              Balance=n.Balance
                          }).ToList();
            return Buscar;
        }

        //GENERAR LAS COMISIONES DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.EGenerarComisionIntermediario> GenerarComisionIntermediario(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string CodigoIntermediario = null, int? Oficina = null,int? Ramo = null, decimal? MontoMinimo = null,string Poliza = null,string NumeroRecibo = null,string NumeroFactura = null, decimal? Tasa = null, decimal? Usuario = null)
        {
            Objdata.CommandTimeout = 99999999;

            var Generar = (from n in Objdata.SP_SACAR_COMISIONES_INTERMEDIARIOS(FechaDesde, FechaHasta, CodigoIntermediario, Oficina, Ramo,MontoMinimo,Poliza,NumeroRecibo,NumeroFactura, Tasa, Usuario)
                           select new UtilidadesAmigos.Logica.Entidades.EGenerarComisionIntermediario
                           {
                               Supervisor = n.Supervisor,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Codigo = n.Codigo,
                               Intermediario = n.Intermediario,
                               CodigoOficina=n.CodigoOficina,
                               Oficina = n.Oficina,
                               NumeroIdentificacion = n.NumeroIdentificacion,
                               CuentaBanco = n.CuentaBanco,
                               TipoCuenta = n.TipoCuenta,
                               Banco = n.Banco,
                               CodigoBanco=n.CodigoBanco,
                               NumeroRecibo=n.NumeroRecibo,
                               Cliente = n.Cliente,
                               Recibo = n.Recibo,
                               Fecha = n.Fecha,
                               Factura = n.Factura,
                               FechaFactura = n.FechaFactura,
                               Moneda = n.Moneda,
                               Poliza = n.Poliza,
                               Ramo=n.Ramo,
                               Producto = n.Producto,
                               Bruto=n.Bruto,
                               Neto=n.Neto,
                               PorcientoComision=n.PorcientoComision,
                               Comision=n.Comision,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar,
                               CantidadRegistros=n.CantidadRegistros,
                               Usuario=n.Usuario,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta
                           }).ToList();
            return Generar;
        }

        //SACAR LA PRODUCCION DE LOS INTERMEDIARIOS
        public List<UtilidadesAmigos.Logica.Entidades.ESacarProduccionIntermediario> SacarProduccionIntermediario(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? Vendedor = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_PRODUCCION_INTERMEDIARIO(FechaDesde, FechaHasta, Vendedor)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarProduccionIntermediario
                          {
                              Poliza=n.Poliza,
                              NoFactura=n.NoFactura,
                              Fecha0=n.Fecha0,
                              Mes=n.Mes,
                              Fecha=n.Fecha,
                              Valor=n.Valor,
                              Cliente=n.Cliente,
                              Vendedor=n.Vendedor,
                              Cobrador=n.Cobrador,
                              Concepto=n.Concepto,
                              Balance=n.Balance,
                              Ncf=n.Ncf,
                              Tasa=n.Tasa,
                              Moneda=n.Moneda,
                              Oficina=n.Oficina,
                              Total=n.Total,
                              TipoVehiculo=n.TipoVehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Capacidad=n.Capacidad,
                              Ano=n.Ano,
                              Color=n.Color,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              Uso=n.Uso,
                              ValorVehiculo=n.ValorVehiculo
                          }).ToList();
            return Buscar;
        }

        //SACAR LAS COMISIONES DE LOS INTERMEDIARIOS RESUMIDO
        public List<UtilidadesAmigos.Logica.Entidades.EComisionIntermediarioResumido> ComisionIntermediarioResumido(decimal? IdUsuario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_GENERAR_REPORTE_COMISIONES_INTERMEDIARIO_RESUMIDO(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.EComisionIntermediarioResumido
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               Supervisor=n.Supervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario =n.Intermediario,
                               Oficina=n.Oficina,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               CuentaBanco=n.CuentaBanco,
                               TipoCuenta=n.TipoCuenta,
                               Banco=n.Banco,
                               Producto=n.Producto,
                               MontoBruto=n.MontoBruto,
                               MontoNeto=n.MontoNeto,
                               Comision=n.Comision,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar,
                               ValidadoDesde=n.ValidadoDesde,
                               FechaDesde=n.FechaDesde,
                               FechaHasta=n.FechaHasta

                           }).ToList();
            return Listado;
        }

        //SACAR LAS COMISIONES DE LOS INTERMEDIARIOS EN DETALLE
        public List<UtilidadesAmigos.Logica.Entidades.ComisionesIntermediarioDetalle> ComisionIntermediarioDetalle(decimal? IdUsuario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_GENERAR_REPORTE_COMISIONES_INTERMEDIARIO(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.ComisionesIntermediarioDetalle
                           {
                               IdUsuario=n.IdUsuario,
                               Supervisor=n.Supervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               Oficina=n.Oficina,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               CuentaBanco=n.CuentaBanco,
                               TipoCuenta=n.TipoCuenta,
                               Banco=n.Banco,
                               Cliente=n.Cliente,
                               NumeroRecibo=n.NumeroRecibo,
                               FechaRecibo=n.FechaRecibo,
                               NumeroFactura=n.NumeroFactura,
                               FechaFactura=n.FechaFactura,
                               Moneda=n.Moneda,
                               Poliza=n.Poliza,
                               Producto=n.Producto,
                               MontoBruto=n.MontoBruto,
                               MontoNeto=n.MontoNeto,
                               PorcientoComision=n.PorcientoComision,
                               Comsiion=n.Comsiion,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar,
                               CantidadRegistros=n.CantidadRegistros,
                               ValidadoDesde=n.ValidadoDesde,
                               FechaDesde=n.FechaDesde,
                               ValidadoHasta=n.ValidadoHasta,
                               FechaHasta=n.FechaHasta
                           }).ToList();
            return Listado;
        }

        //BUSCAR ACUMULADOS DE COMISIONES POR PAGAR DE LOS INTERMEDIARIOS
        /// <summary>
        /// Este metodo es para mostrar el listado de los intermediarios que aplican y los que no aplcian para pararle al comision.
        /// </summary>
        /// <param name="Intermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="Ramo"></param>
        /// <param name="MontoMinimo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.EComisionesAcumuladosIntermediario> ComisionesAcumuladasIntermediarios(int? Intermediario = null, int? Oficina = null, int? Ramo = null,decimal? NumeroRecibo = null,decimal? MontoMinimo = null,int? TipoOperacion = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_ACUMULADO_INTERMEDIARIOS_COMISIONES(Intermediario, Oficina, Ramo, NumeroRecibo, MontoMinimo, TipoOperacion)
                           select new UtilidadesAmigos.Logica.Entidades.EComisionesAcumuladosIntermediario
                           {
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               Oficina=n.Oficina,
                               ValorReciboBruto=n.ValorReciboBruto,
                               ValorReciboNeto=n.ValorReciboNeto,
                               ComisionGenerada=n.ComisionGenerada,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               Aliquidar=n.Aliquidar,
                               GeneraCheque=n.GeneraCheque,
                               CantiadRegistros=n.CantiadRegistros
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para sacar todas las comisiones que esten por dejajo del monto minimo para poder procesarlas
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="CodigoIntermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="Ramo"></param>
        /// <param name="Poliza"></param>
        /// <param name="NumeroRecibo"></param>
        /// <param name="NumeroFactura"></param>
        /// <param name="Tasa"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.ESacarComisionesIntermediariosMontoMinimo> SacarComisionesIntermediariosMontoMinimo(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string CodigoIntermediario = null, int? Oficina = null, int? Ramo = null, string Poliza = null, string NumeroRecibo = null, string NumeroFactura = null, decimal? Tasa = null, decimal? Usuario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_COMISIONES_INTERMEDIARIOS_MENOR_MONTO_MINIMO(FechaDesde, FechaHasta, CodigoIntermediario, Oficina, Ramo, Poliza, NumeroRecibo, NumeroFactura, Tasa, Usuario)
                           select new UtilidadesAmigos.Logica.Entidades.ESacarComisionesIntermediariosMontoMinimo
                           {
                               Supervisor=n.Supervisor,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Codigo=n.Codigo,
                               Intermediario=n.Intermediario,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               CuentaBanco=n.CuentaBanco,
                               TipoCuenta=n.TipoCuenta,
                               Banco=n.Banco,
                               Cliente=n.Cliente,
                               NumeroRecibo=n.NumeroRecibo,
                               Recibo=n.Recibo,
                               Fecha=n.Fecha,
                               Factura=n.Factura,
                               FechaFactura=n.FechaFactura,
                               Moneda=n.Moneda,
                               Poliza=n.Poliza,
                               Ramo=n.Ramo,
                               Producto=n.Producto,
                               Bruto=n.Bruto,
                               Neto=n.Neto,
                               PorcientoComision=n.PorcientoComision,
                               Comision=n.Comision,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar,
                               CantidadRegistros=n.CantidadRegistros,
                               Usuario=n.Usuario,
                               ValidadoDesde=n.ValidadoDesde,
                               ValidadoHasta=n.ValidadoHasta
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo es para procesar la informacion de los montos acmulados de los intermediarios
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.EProcesarInformacionComisionesIntermediariosMontosAcumulados ProcesarInformacionInformacionMontosAcumuladosIntermediario(UtilidadesAmigos.Logica.Entidades.EProcesarInformacionComisionesIntermediariosMontosAcumulados Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EProcesarInformacionComisionesIntermediariosMontosAcumulados Procesar = null;

            var ComisionesMontosAcumuladas = Objdata.SP_PROCESAR_INFORMACION_COMISIONES_INTERMEDIARIOS_MONTOS_ACUMULADOS(
                Item.CodigoIntermediario,
                Item.NumeroRecibo,
                Item.FechaRecibo,
                Item.NumeroFacturaAfecta,
                Item.Poliza,
                Item.Ramo,
                Item.ValorReciboBruto,
                Item.ValorReciboNeto,
                Item.PorcientoComision,
                Item.ComisionGenerada,
                Item.Retencion,
                Item.AvanceComision,
                Item.ALiquidar,
                Item.Estatus,
                Item.Oficina,
                Accion);
            if (ComisionesMontosAcumuladas != null) {
                Procesar = (from n in ComisionesMontosAcumuladas
                            select new UtilidadesAmigos.Logica.Entidades.EProcesarInformacionComisionesIntermediariosMontosAcumulados
                            {
                                CodigoIntermediario=n.CodigoIntermediario,
                                NumeroRecibo=n.NumeroRecibo,
                                FechaRecibo=n.FechaRecibo,
                                NumeroFacturaAfecta=n.NumeroFacturaAfecta,
                                Poliza=n.Poliza,
                                Ramo=n.Ramo,
                                ValorReciboBruto=n.ValorReciboBruto,
                                ValorReciboNeto=n.ValorReciboNeto,
                                PorcientoComision=n.PorcientoComision,
                                ComisionGenerada=n.ComisionGenerada,
                                Retencion=n.Retencion,
                                AvanceComision=n.AvanceComision,
                                ALiquidar=n.ALiquidar,
                                Estatus=n.Estatus,
                                Oficina=n.Oficina
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        public List<UtilidadesAmigos.Logica.Entidades.EBuscarDetalleIntermediarioComisiones> ValidarDetalleIntermediarioComisiones(int? Intermediario = null, int? Oficina = null, int? Ramo = null, decimal? Numerorecibo = null, decimal? NumeroFactura=null, string Poliza = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_DETALLE_INTERMEDIARIO_COMISIONES(Intermediario, Oficina, Ramo, Numerorecibo, NumeroFactura, Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.EBuscarDetalleIntermediarioComisiones
                           {
                               CodigoIntermediario=n.CodigoIntermediario,
                               NumeroRecibo=n.NumeroRecibo,
                               FechaRecibo=n.FechaRecibo,
                               NumeroFacturaAfecta=n.NumeroFacturaAfecta,
                               Poliza=n.Poliza,
                               Ramo=n.Ramo,
                               NombreRamo=n.NombreRamo,
                               ValorReciboBruto=n.ValorReciboBruto,
                               ValorReciboNeto=n.ValorReciboNeto,
                               PorcientoComision=n.PorcientoComision,
                               ComisionGenerada=n.ComisionGenerada,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus,
                               Oficina=n.Oficina,
                               NombreOficina=n.NombreOficina
                           }).ToList();
            return Listado;
        }
        #endregion

        #region REPORTE DE RENOVACION DE POLIZAS
        public List<UtilidadesAmigos.Logica.Entidades.EListadoRenovacion> ReporteRenovacionPoliza(DateTime? FechaDesde = null, DateTime? FechaFin = null, int? Ramo = null, int? SubRamo = null, string Poliza = null, decimal? Cotizacion = null, int? Oficina = null, string CodSupervisor = null, string CodIntermediario = null, int? ValidarBalance = null,int? ExcluirRegistros = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_MOSTRAR_LISTADO_RENOVACION(FechaDesde, FechaFin, Ramo, SubRamo, Poliza, Cotizacion, Oficina, CodSupervisor, CodIntermediario, ValidarBalance, ExcluirRegistros)
                           select new UtilidadesAmigos.Logica.Entidades.EListadoRenovacion
                           {
                               Poliza=n.Poliza,
                               Cotizacion=n.Cotizacion,
                               Estatus=n.Estatus,
                               Prima=n.Prima,
                               SumaAsegurada=n.SumaAsegurada,
                               CodRamo=n.CodRamo,
                               CodSubramo=n.CodSubramo,
                               Ramo=n.Ramo,
                               SubRamo=n.SubRamo,
                               Asegurado=n.Asegurado,
                               TelefonoResidencia=n.TelefonoResidencia,
                               Celular=n.Celular,
                               TelefonoOficina=n.TelefonoOficina,
                               Items=n.Items,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               InicioVigenciaFormateado=n.InicioVigenciaFormateado,
                               FinVigenciaFormateado=n.FinVigenciaFormateado,
                               Secuencia=n.Secuencia,
                               Supervisor=n.Supervisor,
                               Intermediario=n.Intermediario,
                               CodSupervisor=n.CodSupervisor,
                               CodIntermediario=n.CodIntermediario,
                               Oficina=n.Oficina,
                               Facturado=n.Facturado,
                               Cobrado=n.Cobrado,
                               Balance=n.Balance,
                               FechaDesde=n.FechaDesde,
                               FechaHasta=n.FechaHasta,
                               Dias=n.Dias,
                               Mes=n.Mes,
                               Anos=n.Anos,
                               CantidadComentarios=n.CantidadComentarios,
                               Chasis=n.Chasis,
                               CantidadReclamaciones=n.CantidadReclamaciones,
                               UltimaReclamacion=n.UltimaReclamacion,
                               FechaUltimoComentario=n.FechaUltimoComentario,
                               HoraUltimoComentario=n.HoraUltimoComentario,
                               UltimoEstatusLlamada=n.UltimoEstatusLlamada,
                               UltimoConceptollamada=n.UltimoConceptollamada,
                               UltimoComentario=n.UltimoComentario,
                               UsuarioComento=n.UsuarioComento
                           }).ToList();
            return Listado;
        }
        #endregion

        #region GENERAR REPORTE FIANZAS
        public List<UtilidadesAmigos.Logica.Entidades.EGenerarProduccionFianza> GenerarProduccionFianzas(string Poliza = null, decimal? Subramo = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_GENERAR_PRODUCCION_FIANZAS(Poliza, Subramo, FechaDesde, FechaHasta)
                          select new UtilidadesAmigos.Logica.Entidades.EGenerarProduccionFianza
                          {
                              NoFactura=n.NoFactura,
                              Poliza=n.Poliza,
                              Item=n.Item,
                              Estatus=n.Estatus,
                              NoFormulario=n.NoFormulario,
                              CodRamo=n.CodRamo,
                              CodSubramo=n.CodSubramo,
                              Ramo=n.Ramo,
                              SubRamo=n.SubRamo,
                              Cliente=n.Cliente,
                              Deudor=n.Deudor,
                              TelefonoResidencia=n.TelefonoResidencia,
                              TelefonoOficina=n.TelefonoOficina,
                              Celular=n.Celular,
                              fax=n.fax,
                              Otro=n.Otro,
                              Direccion=n.Direccion,
                              UbicacionCliente=n.UbicacionCliente,
                              ProvinciaCliente=n.ProvinciaCliente,
                              MunicipioCliente=n.MunicipioCliente,
                              SectorCliente=n.SectorCliente,
                              Supervisor=n.Supervisor,
                              Intermediario=n.Intermediario,
                              UbicacionIntermediario=n.UbicacionIntermediario,
                              ProvinciaIntermediario=n.ProvinciaIntermediario,
                              MunicipioIntermediario=n.MunicipioIntermediario,
                              SectorIntermediario=n.SectorIntermediario,
                              Fecha=n.Fecha,
                              FechaFacturacion=n.FechaFacturacion,
                              SecuenciaFactura=n.SecuenciaFactura,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              SumaAsegurada=n.SumaAsegurada,
                              Neto=n.Neto,
                              Tasa=n.Tasa,
                              Impuesto=n.Impuesto,
                              PorcComision=n.PorcComision,
                              Facturado=n.Facturado,
                              Cobrado=n.Cobrado,
                              Balance=n.Balance,
                              LeyInfraccionImputado=n.LeyInfraccionImputado,
                              Cantidad=n.Cantidad
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region SACAR LA PRODUCCION DE CONTABILIDAD
        public List<UtilidadesAmigos.Logica.Entidades.ESacarProduccionContabilidad> SacarProduccionDiariaContabilidad(DateTime? Fechadesde = null, DateTime? FechaHasta = null, DateTime? FechadesdeAnterior = null, DateTime? FechaHastaAnterior = null, int? Ramo = null, int? Oficina = null, int? TipoDocumento = null, string CodigoIntermediario = null, int? LlevaIntermediario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarData = (from n in Objdata.SP_SACAR_PRODUCCION_CONTABILIDAD(Fechadesde, FechaHasta, FechadesdeAnterior, FechaHastaAnterior, Ramo, Oficina, TipoDocumento, CodigoIntermediario, LlevaIntermediario)
                             select new UtilidadesAmigos.Logica.Entidades.ESacarProduccionContabilidad
                             {
                                 Intermediario=n.Intermediario,
                                 Codigo=n.Codigo,
                                 Ramo=n.Ramo,
                                 Descripcion=n.Descripcion,
                                 Tipo=n.Tipo,
                                 DescripcionTipo=n.DescripcionTipo,
                                 CodOficina=n.CodOficina,
                                 Oficina=n.Oficina,
                                 Concepto=n.Concepto,
                                 FacturadoMes=n.FacturadoMes,
                                 Total=n.Total,
                                 MesAnterior=n.MesAnterior,
                                 Hoy=n.Hoy,
                                 TotalCredito=n.TotalCredito,
                                 TotalDebito=n.TotalDebito,
                                 TotalOtros=n.TotalOtros
                             }).ToList();
            return SacarData;
        }
        #endregion

        #region SACAR EL LISTADO DE MESES
        public List<UtilidadesAmigos.Logica.Entidades.EMeses> BuscaListadoMeses(decimal? IdMes = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCAR_MESES(IdMes)
                          select new UtilidadesAmigos.Logica.Entidades.EMeses
                          {
                              IdMes=n.IdMes,
                              Meses=n.Meses
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region MOSTRAR EL LISTADO DE LO COBRADO CONTABILIDAD
        public List<UtilidadesAmigos.Logica.Entidades.EReporteCobradoContabilidad> ReporteCobradoCOntabilidad(DateTime? FechaDesde = null, DateTime? FechaHasta = null, DateTime? FechaDesdeAnterior = null, DateTime? FechaHastaAnterior = null, int? Ramo = null, int? Oficina = null, int? LlevaIntermediario = null, string CodigoIntermediario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Cobrado = (from n in Objdata.SP_SACAR_REPORTE_COBRADO_CONTABILIDAD(FechaDesde, FechaHasta, FechaDesdeAnterior, FechaHastaAnterior, Ramo, Oficina, LlevaIntermediario, CodigoIntermediario)
                           select new UtilidadesAmigos.Logica.Entidades.EReporteCobradoContabilidad
                           {
                               Intermediario=n.Intermediario,
                               CodigoIntermediario=n.CodigoIntermediario,
                               CodRamo=n.CodRamo,
                               Ramo=n.Ramo,
                               CodOficina=n.CodOficina,
                               Oficina=n.Oficina,
                               Cobrado=n.Cobrado,
                               CobradoHoy=n.CobradoHoy,
                               CobradoSantoDomingo=n.CobradoSantoDomingo,
                               CobradoSantiago=n.CobradoSantiago,
                               CobradoOtros=n.CobradoOtros,
                               Total=n.Total,
                               CobradoMesAnterior=n.CobradoMesAnterior
                              
                           }).ToList();
            return Cobrado;
        }
        #endregion

        #region SACAR LA DESCRIPCION DEL PRODUCTO SELECCIONADO3
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDescripcionProducto> SacarDescripcionProducto(int? TipoProducto = null, int? Codigoproducto = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarListado = (from n in Objdata.SP_SACAR_DESCRIPCION_PRODUCTO(TipoProducto, Codigoproducto)
                                select new UtilidadesAmigos.Logica.Entidades.ESacarDescripcionProducto
                                {
                                    IdProductoSubramo=n.IdProductoSubramo,
                                    TipoProducto=n.TipoProducto,
                                    CodigoSubramo=n.CodigoSubramo,
                                    DescripcionSubramo=n.DescripcionSubramo,
                                    Descripcion=n.Descripcion,
                                    Estatus=n.Estatus
                                }).ToList();
            return SacarListado;
        }
        #endregion

        #region MANTENIMIENTO DE SUGERENCIAS
        //LISTADO DE SUGERENCIAS
        public List<UtilidadesAmigos.Logica.Entidades.ESugerencias> BuscaSugerencias(decimal? IdSugerencia = null, decimal? IdUsuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_SUGERENCIAS(IdSugerencia, IdUsuario)
                          select new UtilidadesAmigos.Logica.Entidades.ESugerencias
                          {
                              IdSugerencia=n.IdSugerencia,
                              IdUsuario=n.IdUsuario,
                              Usuario=n.Usuario,
                              Sugerencia=n.Sugerencia,
                              Respuesta=n.Respuesta
                          }).ToList();
            return Buscar;
        }
        //MANTENIMIENTO DE SUGERENCIAS
        public UtilidadesAmigos.Logica.Entidades.ESugerencias MantenimientoSugeencias(UtilidadesAmigos.Logica.Entidades.ESugerencias Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.ESugerencias Mantenimiento = null;

            var Sugerencia = Objdata.SP_MANTENIMIENTO_SUGERENCIAS(
                Item.IdSugerencia,
                Item.IdUsuario,
                Item.Sugerencia,
                Item.Respuesta,
                Accion);
            if (Sugerencia != null)
            {
                Mantenimiento = (from n in Sugerencia
                                 select new UtilidadesAmigos.Logica.Entidades.ESugerencias
                                 {
                                     IdSugerencia=n.IdSugerencia,
                                     IdUsuario=n.IdUsuario,
                                     Sugerencia=n.Sugerencia,
                                     Respuesta=n.Respuesta
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE DATOS POLIZA
        //SACAR LOS DATOS DE LA POLIZA
        public List<UtilidadesAmigos.Logica.Entidades.ESacarDatosDatosPoliza> SacarDatosDatosPoliza(string Poliza = null, int? Item = null)
        {
            Objdata.CommandTimeout = 999999999;
            var Buscar = (from n in Objdata.SP_SACAR_DATOS_DATOS_POLIZA(Poliza, Item)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarDatosDatosPoliza
                          {
                              Poliza=n.Poliza,
                              Estatus=n.Estatus,
                              Cotizacion=n.Cotizacion,
                              Item=n.Item,
                              CodRamo=n.CodRamo,
                              Ramo=n.Ramo,
                              SubRamo=n.SubRamo,
                              Tipo=n.Tipo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Capacidad=n.Capacidad,
                              Ano=n.Ano,
                              Color=n.Color,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              Uso=n.Uso,
                              Valor=n.Valor,
                              Fianza=n.Fianza,
                              Asegurado=n.Asegurado,
                              Cliente=n.Cliente,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              Supervisor=n.Supervisor,
                              Intermediario=n.Intermediario,
                              Neto=n.Neto
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region ACTUALIZAR VALOR EN CONDICIONES PARTICULARES
        public UtilidadesAmigos.Logica.Entidades.ECambiaValorPolizaCondiciones CambiaValorPolizaCOndicion(UtilidadesAmigos.Logica.Entidades.ECambiaValorPolizaCondiciones Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.ECambiaValorPolizaCondiciones Mantenimiento = null;

            var CambiaValores = Objdata.SP_CAMBIA_VALOR_POLIZA_CONDICIONES(
                Item.Cotizacion,
                Item.Secuencia,
                Item.Neto,
                Accion,
                Item.MontoImpuesto,
                Item.PrimaBruta);
            if (CambiaValores != null)
            {
                Mantenimiento = (from n in CambiaValores
                                 select new UtilidadesAmigos.Logica.Entidades.ECambiaValorPolizaCondiciones
                                 {
                                     Cotizacion=n.Cotizacion,
                                     Secuencia=n.Secuencia,
                                     Neto=n.Neto,
                                     MontoImpuesto=n.MontoImpuesto,
                                     PrimaBruta=n.PrimaBruta
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        public UtilidadesAmigos.Logica.Entidades.EModificarVigenciaPoliza CambiaVigenciaPoliza(UtilidadesAmigos.Logica.Entidades.EModificarVigenciaPoliza Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EModificarVigenciaPoliza Modificar = null;

            var VigenciaPoliza = Objdata.SP_MODIFICAR_VIGENCIA_POLIZA(
                Item.Cotizacion,
                Item.Secuencia,
                Item.FechaInicioVigencia,
                Item.FechaFinVigencia,
                Accion);
            if (VigenciaPoliza != null)
            {
                Modificar = (from n in VigenciaPoliza
                             select new UtilidadesAmigos.Logica.Entidades.EModificarVigenciaPoliza
                             {
                                 Cotizacion=n.Cotizacion,
                                 Secuencia=n.Secuencia,
                                 FechaInicioVigencia=n.FechaInicioVigencia,
                                 FechaFinVigencia=n.FechaFinVigencia
                             }).FirstOrDefault();
            }
            return Modificar;
        }
        #endregion

        #region SACAR EL NOMBRE DE COBRADOR
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaDatosCobrador> SacarNombreCobrador(decimal? Codigo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_DATOS_COBRADOR(Codigo)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaDatosCobrador
                          {
                              NombreCobrador=n.NombreCobrador
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region MOSTRAR LAS ESTADISTICAS DE LAS RENOVACIONES3
        //LISTADO DE ESTADISTICA DE RENOVACION
        public List<UtilidadesAmigos.Logica.Entidades.EEstadisticaRenovacion> SacarEstadisticaRenovacion(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, int? Subramo = null, int? Oficina = null, int? ValidarBalance = null, int? ExcluirRegistros = null, int? Persona = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarData = (from n in Objdata.SP_SACAR_ESTADISTICA_RENOVACION(FechaDesde, FechaHasta, Ramo, Subramo, Oficina, ValidarBalance, ExcluirRegistros, Persona)
                             select new UtilidadesAmigos.Logica.Entidades.EEstadisticaRenovacion
                             {
                                 Persona=n.Persona,
                                 CantidadPoliza=n.CantidadPoliza,
                                 Monto=n.Monto
                             }).ToList();
            return SacarData;
        }
        #endregion

        #region MOSTRAR LA PRODUCCION DE RECLAMOS
        //MOSTRAR LA CONSULTA DE LA PRODUCCION DE RECLAMOS
        public List<UtilidadesAmigos.Logica.Entidades.EProduccionReclamos> BuscaProduccionReclamos(DateTime? FechaDesde = null, DateTime? FechaHAsta = null, int? IdOficina = null, int? IdDepartamento = null, int? IdUaurio = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCAR_PRODUCCION_RECLAMACIONES(FechaDesde, FechaHAsta, IdOficina, IdDepartamento, IdUaurio)
                          select new UtilidadesAmigos.Logica.Entidades.EProduccionReclamos
                          {
                              Oficina=n.Oficina,
                              Departamento=n.Departamento,
                              Usuario=n.Usuario,
                              Concepto=n.Concepto,
                              IdOficina=n.IdOficina,
                              IdDepartamento=n.IdDepartamento,
                              IdUsuario=n.IdUsuario,
                              Cantidad=n.Cantidad
                          }).ToList();
            return Buscar;
        }

        //MOSTRAR LA CONSULTA DE LA PRODUCCION DE RECLAMOS DETALLE
        public List<UtilidadesAmigos.Logica.Entidades.EprogramacionReclamoDetalle> BuscarProduccionReclamosDetalle(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Usuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCAR_PRODUCCION_RECLAMACIONES_DETALLE(FechaDesde, FechaHasta, Usuario)
                          select new UtilidadesAmigos.Logica.Entidades.EprogramacionReclamoDetalle
                          {
                              Usuario=n.Usuario,
                              Numero=n.Numero,
                              Valor=n.Valor,
                              ValorAjustado=n.ValorAjustado,
                              ValorSalvamento=n.ValorSalvamento,
                              ValorAsegurado=n.ValorAsegurado,
                              Poliza=n.Poliza,
                              Fecha=n.Fecha,
                              FechaSiniestro=n.FechaSiniestro,
                              FechaCierre = n.FechaCierre,
                              Balance=n.Balance,
                              Concepto=n.Concepto,
                              CodRamo=n.CodRamo,
                              Ramo=n.Ramo,
                              CodSubramo=n.CodSubramo,
                              SubRamo=n.SubRamo,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia=n.FinVigencia,
                              TipoVehiculo=n.TipoVehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Capacidad=n.Capacidad,
                              Ano=n.Ano,
                              Color=n.Color,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              Uso=n.Uso,
                              ValorVehiculo=n.ValorVehiculo,
                              Fianza=n.Fianza,
                              Asegurado=n.Asegurado,
                              Comentario=n.Comentario

                          }).ToList();
            return Buscar;
        }
        #endregion

        #region SACAR LA PRODUCCION DE SUPERVISORES
        public List<UtilidadesAmigos.Logica.Entidades.ESacarProduccionSupervisor> SacarProduccionSupervisor(int? CodigoSupervisor = null, string Poliza = null, int? Ramo = null, int? Subramo = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? ExcluirMotores = null)
        {
            Objdata.CommandTimeout = 999999999;

            var ProduccionSupervisor = (from n in Objdata.SP_SACAR_PRODUCCION_SUPERVISOR(CodigoSupervisor, Poliza, Ramo, Subramo, FechaDesde, FechaHasta, ExcluirMotores)
                                        select new UtilidadesAmigos.Logica.Entidades.ESacarProduccionSupervisor
                                        {
                                            Poliza=n.Poliza,
                                            Estatus=n.Estatus,
                                            Prima=n.Prima,
                                            SumaAsegurada=n.SumaAsegurada,
                                            InicioVigencia=n.InicioVigencia,
                                            FinVigencia=n.FinVigencia,
                                            CodRamo=n.CodRamo,
                                            Ramo=n.Ramo,
                                            CodSubRamo=n.CodSubRamo,
                                            Subramo=n.Subramo,
                                            CodCliente=n.CodCliente,
                                            Cliente=n.Cliente,
                                            CodSupervisor=n.CodSupervisor,
                                            Supervisor=n.Supervisor,
                                            CodIntermediario=n.CodIntermediario,
                                            Intermediario=n.Intermediario,
                                            Fecha=n.Fecha,
                                            Valor=n.Valor,
                                            Numero=n.Numero,
                                            Concepto=n.Concepto,
                                            CreadoPor=n.CreadoPor,
                                            Facturado=n.Facturado,
                                            Cobrado=n.Cobrado,
                                            Balance=n.Balance,
                                            TotalFacturado=n.TotalFacturado
                                        }).ToList();
            return ProduccionSupervisor;
        }
        #endregion

        #region BUSCA_HISTORICO_FIANZAS
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaHistoricoPolizaFianza> BuscaHistoriclPoliza(string Poliza = null, int? Subramo = null, DateTime? FechaDede = null, DateTime? FechaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_HISTORICO_POLIZA_FIANZAS(Poliza, Subramo, FechaDede, FechaHasta)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaHistoricoPolizaFianza
                          {
                              Poliza=n.Poliza,
                              Estatus=n.Estatus,
                              Cliente=n.Cliente,
                              Intermediario=n.Intermediario,
                              Prima=n.Prima,
                              SumaAsegurada=n.SumaAsegurada,
                              Ramo=n.Ramo,
                              Subramo=n.Subramo,
                              Concepto=n.Concepto,
                              Fecha=n.Fecha,
                              Fecha0=n.Fecha0,
                              Usuario=n.Usuario,
                              Valor=n.Valor,
                              TotalFacturado=n.TotalFacturado,
                              TotalCobrado=n.TotalCobrado,
                              Balance=n.Balance,
                              CantidadRegistros=n.CantidadRegistros

                          }).ToList();
            return Buscar;
        }
        #endregion

        #region MANTENIMIENTO DE RECLAMACIONES
        //LISTADO DE RECLAMACIONES
        public List<UtilidadesAmigos.Logica.Entidades.EReclamacion> BuscaReclamaciones(decimal? Numero = null, string Reclamacion = null, string Poliza = null, string Intermediario = null, string Asegurado = null, decimal? IdCondicion = null, string Beneficiario = null, decimal? IdTipo = null, DateTime? InicioVigenciaDesde = null, DateTime? InicioVigenciaHasta = null, DateTime? FinVigenciaDesde = null, DateTime? FinVigenciaHasta = null, DateTime? FechaAperturaDesde = null, DateTime? FechaAperturaHasta = null, DateTime? FechaSiniestroDesde = null, DateTime? FechaSiniestroHAsta = null, decimal? IdEstatus = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_LISTADO_RECLAMACIONES(Numero, Reclamacion, Poliza, Intermediario, Asegurado, IdCondicion, Beneficiario, IdTipo, InicioVigenciaDesde, InicioVigenciaHasta, FinVigenciaDesde, FinVigenciaHasta, FechaAperturaDesde, FechaAperturaHasta, FechaSiniestroDesde, FechaSiniestroHAsta, IdEstatus)
                          select new UtilidadesAmigos.Logica.Entidades.EReclamacion
                          {
                              Numero=n.Numero,
                              Reclamacion=n.Reclamacion,
                              Poliza=n.Poliza,
                              Estatus=n.Estatus,
                              Intermediario=n.Intermediario,
                              NombreIntermediario=n.NombreIntermediario,
                              Asegurado=n.Asegurado,
                              IdCondicion=n.IdCondicion,
                              Condicion=n.Condicion,
                              Monto=n.Monto,
                              Beneficiario=n.Beneficiario,
                              IdTipo=n.IdTipo,
                              TipoReclamacion=n.TipoReclamacion,
                              InicioVigencia0=n.InicioVigencia0,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia0=n.FinVigencia0,
                              FinVigencia=n.FinVigencia,
                              FechaApertura0=n.FechaApertura0,
                              FechaApertura=n.FechaApertura,
                              FechaSiniestro0=n.FechaSiniestro0,
                              FechaSiniestro=n.FechaSiniestro,
                              FechaCreacion0=n.FechaCreacion0,
                              FechaCreacion=n.FechaCreacion,
                              IdEstatus=n.IdEstatus,
                              EstatusReclamacion=n.EstatusReclamacion,
                              IdUsuario=n.IdUsuario,
                              Usuario=n.Usuario,
                              Comentario=n.Comentario,
                              CantidadRegistros=n.CantidadRegistros
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE RECLAMACIONES
        public UtilidadesAmigos.Logica.Entidades.EReclamacion MantenimientoReclamaciones(UtilidadesAmigos.Logica.Entidades.EReclamacion Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EReclamacion Mantenimiento = null;

            var Reclamaciones = Objdata.SP_MANTENIMIENTO_RECLAMACIONES(
                Item.Numero,
                Item.Reclamacion,
                Item.Poliza,
                Item.Intermediario,
                Item.Asegurado,
                Item.IdCondicion,
                Item.Monto,
                Item.Beneficiario,
                Item.IdTipo,
                Item.InicioVigencia0,
                Item.FinVigencia0,
                Item.FechaApertura0,
                Item.FechaSiniestro0,
                Item.IdEstatus,
                Item.IdUsuario,
                Item.Comentario,
                Accion);
            if (Reclamaciones != null)
            {
                Mantenimiento = (from n in Reclamaciones
                                 select new UtilidadesAmigos.Logica.Entidades.EReclamacion
                                 {
                                     Numero=n.Numero,
                                     Reclamacion=n.Reclamacion,
                                     Poliza=n.Poliza,
                                     Intermediario=n.Intermediario,
                                     Asegurado=n.Asegurado,
                                     IdCondicion=n.IdCondicion,
                                     Monto=n.Monto,
                                     Beneficiario=n.Beneficiario,
                                     IdTipo=n.IdTipo,
                                     InicioVigencia0=n.InicioVigencia,
                                     FinVigencia0=n.FinVigencia,
                                     FechaApertura0=n.FechaApertura,
                                     FechaSiniestro0=n.FechaSiniestro,
                                     FechaCreacion0=n.FechaCreacion,
                                     IdEstatus=n.IdEstatus,
                                     IdUsuario=n.IdUsuario,
                                     Comentario=n.Comentario
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMEINTO DE CONDICION DE RECLAMACIONES
        //LISTADO DE CONDICIONES DE RECLAMACIONES
        public List<UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion> BuscaCondicionReclamaciones(decimal? IdCondicion = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var CondicionReclamacion = (from n in Objdata.SP_BUSCA_CONDICION_RECLAMACION(IdCondicion, Descripcion)
                                        select new UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion
                                        {
                                            IdCondicion=n.IdCondicion,
                                            Condicion=n.Condicion,
                                            Estatus0=n.Estatus0,
                                            Estatus=n.Estatus
                                        }).ToList();
            return CondicionReclamacion;
        }

        //MANTENIMIENTO DE CONDICIONE DE RECLAMACIONES
        public UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion MantenimientoCondicionesReclamos(UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion Mantenimiento = null;

            var CondicionReclamacion = Objdata.SP_MANTENIMIENTO_CONDICION_RECLAMACION(
                Item.IdCondicion,
                Item.Condicion,
                Item.Estatus0,
                Accion);
            if (CondicionReclamacion != null)
            {
                Mantenimiento = (from n in CondicionReclamacion
                                 select new UtilidadesAmigos.Logica.Entidades.ECondicionReclamacion
                                 {
                                     IdCondicion=n.IdCondicion,
                                     Condicion=n.Descripcion,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;

        }
        #endregion

        #region MANTENIMIENTO DE TIPO DE RECLAMACION
        //LISTADO DE TIPO DE RECLAMACIONES
        public List<UtilidadesAmigos.Logica.Entidades.ETipoReclamacion> BuscaTipoReclamacion(decimal? IdTipoReclamacion = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var TipoReclamacion = (from n in Objdata.SP_BUSCA_TIPO_RECLAMACION(IdTipoReclamacion, Descripcion)
                                        select new UtilidadesAmigos.Logica.Entidades.ETipoReclamacion
                                        {
                                            IdTipoReclamacion = n.IdTipoReclamacion,
                                            Tipo = n.Tipo,
                                            Estatus0 = n.Estatus0,
                                            Estatus = n.Estatus
                                        }).ToList();
            return TipoReclamacion;
        }

        //MANTENIMIENTO DE TIPO DE RECLAMACIONES
        public UtilidadesAmigos.Logica.Entidades.ETipoReclamacion MantenimientoTipoReclamos(UtilidadesAmigos.Logica.Entidades.ETipoReclamacion Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.ETipoReclamacion Mantenimiento = null;

            var TipoReclamacion = Objdata.SP_MANTENIMIENTO_TIPO_RECLAMACION(
                Item.IdTipoReclamacion,
                Item.Tipo,
                Item.Estatus0,
                Accion);
            if (TipoReclamacion != null)
            {
                Mantenimiento = (from n in TipoReclamacion
                                 select new UtilidadesAmigos.Logica.Entidades.ETipoReclamacion
                                 {
                                     IdTipoReclamacion = n.IdTipoReclamacion,
                                     Tipo = n.Descripcion,
                                     Estatus0 = n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;

        }
        #endregion

        #region MANTENIMIENTO DE ESTATUS DE RECLAMACION
        //LISTADO DE ESTATUS DE RECLAMACION
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion> BuscaEstatusReclamacion(decimal? IdEstatusReclamacion = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_ESTATUS_RECLAMACION(IdEstatusReclamacion, Descripcion)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion
                          {
                              IdEstatusReclamacion=n.IdEstatusReclamacion,
                              DescripcionEstatus=n.DescripcionEstatus,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus
                              
                          }).ToList();
            return Buscar;
        }
        //MANTENIMIENTO DE ESTATUS DE RECLAMACION
        public UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion MantenimientoEstatusReclamacion(UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion Mantenimeinto = null;

            var EstatusReclamacion = Objdata.SP_MANTENIMIENTO_ESTATUS_RECLAMACION(
                Item.IdEstatusReclamacion,
                Item.DescripcionEstatus,
                Item.Estatus0,
                Accion);
            if (EstatusReclamacion != null)
            {
                Mantenimeinto = (from n in EstatusReclamacion
                                 select new UtilidadesAmigos.Logica.Entidades.EBuscaEstatusReclamacion
                                 {
                                     IdEstatusReclamacion=n.IdEstatusReclamacion,
                                     DescripcionEstatus=n.Descripcion,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimeinto;
        }
        #endregion

        #region SACAR LAS FECHA DE LAS RECLAMACIONES
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaFechaReclamos> BuscaFechaReclamos(decimal? NumeroReclamacion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_FECHA_RECLAMACIONES(NumeroReclamacion)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaFechaReclamos
                          {
                              Reclamacion=n.Reclamacion,
                              InicioVigencia0=n.InicioVigencia0,
                              InicioVigencia=n.InicioVigencia,
                              FinVigencia0=n.FinVigencia0,
                              FinVigencia=n.FinVigencia,
                              FechaApertura0=n.FechaApertura0,
                              FechaApertura=n.FechaApertura,
                              FechaSiniestro0=n.FechaSiniestro0,
                              FechaSiniestro=n.FechaSiniestro
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region BUSCAR FACTURAS RECLAMACIONES PAGADAS
        //MOSTRAR EL LISTADO DE LAS FACTURAS DE LAS RECLAMACIONE PAGADAS
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaFActurasPagadasReclamacion> BuscaFActurasPagadasReclamos(string Numeroreclamacion = null, string Anulado = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_FACTURAS_PAGADAS_RECLAMACIONES(Numeroreclamacion, Anulado)
                           select new UtilidadesAmigos.Logica.Entidades.EBuscaFActurasPagadasReclamacion
                           {
                               Compania=n.Compania,
                               Tipo=n.Tipo,
                               Anulado0=n.Anulado0,
                               Anulado=n.Anulado,
                               Numero=n.Numero,
                               Fecha0=n.Fecha0,
                               Fecha=n.Fecha,
                               Valor=n.Valor,
                               proveedor=n.proveedor,
                               NombreProveedor=n.NombreProveedor,
                               TipoProveedor=n.TipoProveedor,
                               FechaCobro0=n.FechaCobro0,
                               FechaCobro=n.FechaCobro,
                               FacturaProveedor=n.FacturaProveedor,
                               FechaProveedor0=n.FechaProveedor0,
                               FechaProveedor=n.FechaProveedor,
                               balance=n.balance,
                               Prima=n.Prima,
                               ValorItbis=n.ValorItbis,
                               PorcItbis=n.PorcItbis,
                               CodMoneda=n.CodMoneda,
                               DescMoneda=n.DescMoneda,
                               SiglasMoneda=n.SiglasMoneda,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               TipoOrden=n.TipoOrden,
                               NumeroOrden=n.NumeroOrden,
                               Clasificacion=n.Clasificacion,
                               Ncf=n.Ncf,
                               ItbisRetenido=n.ItbisRetenido,
                               ValorLey=n.ValorLey,
                               ValorReal=n.ValorReal,
                               SubProveedor=n.SubProveedor,
                               FechaAdiciona=n.FechaAdiciona,
                               IdOficina=n.IdOficina,
                               Referencia=n.Referencia,
                               AreaReferencia=n.AreaReferencia
                           }).ToList();
            return Listado;
        }
        #endregion


        #region SACAR LOS CODIGOS DE LOS INTERMENIDARIOS PARA PAGAR LAS COMISIONES
        public List<UtilidadesAmigos.Logica.Entidades.ESacarCodigoIntermediarios> SacarCodigoIntermediarios(DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Ramo = null, int? Oficina = null)
        {
            Objdata.CommandTimeout = 999999999;

            var BuscarRegistro = (from n in Objdata.SP_SACAR_CODIGOS_INTERMEDIARIOS_COMISION(FechaDesde, FechaHasta, Ramo, Oficina)
                                  select new UtilidadesAmigos.Logica.Entidades.ESacarCodigoIntermediarios
                                  {
                                      Vendedor=n.Vendedor,
                                      Intermediario=n.Intermediario,
                                      Oficina=n.Oficina,
                                      NumeroIdentificacion=n.NumeroIdentificacion,
                                      CuentaBanco=n.CuentaBanco,
                                      Banco=n.Banco
                                  }).ToList();
            return BuscarRegistro;
        }
        #endregion

        #region GUARDAR LAS COMISIONES DE LOS INTERMEDIARIOS
        public UtilidadesAmigos.Logica.Entidades.EGuardarDatosComisionIntermediario GuardarComisionesIntermediario(UtilidadesAmigos.Logica.Entidades.EGuardarDatosComisionIntermediario Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EGuardarDatosComisionIntermediario Guardar = null;

            var ComisionesIntermediarios = Objdata.SP_GUARDAR_DATOS_COMISION_INTERMEDIARIO(
                Item.IdUsuario,
                Item.FechaDesde,
                Item.FechaHasta,
                Item.Supervisor,
                Item.CodigoIntermediario,
                Item.Intermediario,
                Item.Oficina,
                Item.NumeroIdentificacion,
                Item.CuentaBanco,
                Item.TipoCuenta,
                Item.Banco,
                Item.Cliente,
                Item.Recibo,
                Item.Fecha,
                Item.Factura,
                Item.FechaFactura,
                Item.Moneda,
                Item.Poliza,
                Item.Producto,
                Item.Bruto,
                Item.Neto,
                Item.PorcientoComision,
                Item.Comision,
                Item.Retencion,
                Item.AvanceComision,
                Item.ALiquidar,
                Accion);
            if (ComisionesIntermediarios != null)
            {
                Guardar = (from n in ComisionesIntermediarios
                           select new UtilidadesAmigos.Logica.Entidades.EGuardarDatosComisionIntermediario
                           {
                               IdUsuario=n.IdUsuario,
                               FechaDesde=n.FechaDesde,
                               FechaHasta=n.FechaHasta,
                               Supervisor=n.Supervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               Oficina=n.Oficina,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               CuentaBanco=n.CuentaBanco,
                               TipoCuenta=n.TipoCuenta,
                               Banco=n.Banco,
                               Cliente=n.Cliente,
                               Recibo=n.Recibo,
                               Fecha=n.Fecha,
                               Factura=n.Factura,
                               FechaFactura=n.FechaFactura,
                               Moneda=n.Moneda,
                               Poliza=n.Poliza,
                               Producto=n.Producto,
                               Bruto=n.Bruto,
                               Neto=n.Neto,
                               PorcientoComision=n.PorcientoComision,
                               Comision=n.Comision,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar
                           }).FirstOrDefault();
            }
            return Guardar;
        }
        #endregion

        #region EXPORTAR COMISIONES
        public List<UtilidadesAmigos.Logica.Entidades.EExportarComisiones> ExportarComisionesIntermediario(decimal? IdUsuario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_EXPORTAR_COMISIONES(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.EExportarComisiones
                           {
                               CodigoIntermediario=n.CodigoIntermediario,
                               FechaDesde0=n.FechaDesde0,
                               FechaHasta0=n.FechaHasta0,
                               FechaDesde=n.FechaDesde,
                               FechaHasta=n.FechaHasta,
                               Intermediario=n.Intermediario,
                               Oficina=n.Oficina,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               CuentaBanco=n.CuentaBanco,
                               TipoCuenta=n.TipoCuenta,
                               Banco=n.Banco,
                               Cantidad=n.Cantidad,
                               Bruto=n.Bruto,
                               Neto=n.Neto,
                               ComisionBruta=n.ComisionBruta,
                               Retencion=n.Retencion,
                               AvanceComision=n.AvanceComision,
                               ALiquidar=n.ALiquidar
                           }).ToList();
            return Listado;
        }
        #endregion

        #region GENERAR DATOS PARA FACTURAS EN PDF
        public List<UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF> GenerarDatosFacturasPDF(decimal? IdComprobante = null, string Poliza = null, string Comprobante = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_GENERAR_DATOS_FACTURAS_PDF(IdComprobante,Poliza,Comprobante)
                           select new UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF
                           {
                               IdComprobante=n.IdComprobante,
                               Comprobante=n.Comprobante,
                               ComprobanteAfectado=n.ComprobanteAfectado,
                               DescripcionComprobante=n.DescripcionComprobante,
                               FechaVencimiento0=n.FechaVencimiento0,
                               FechaVencimiento=n.FechaVencimiento,
                               NumeroFactura=n.NumeroFactura,
                               Oficina=n.Oficina,
                               Deudor=n.Deudor,
                               Direccion=n.Direccion,
                               Asegurado=n.Asegurado,
                               Comunicacion=n.Comunicacion,
                               Cedula=n.Cedula,
                               Intermediario=n.Intermediario,
                               DireccionIntermediario=n.DireccionIntermediario,
                               ComunicacionIntermediario=n.ComunicacionIntermediario,
                               Supervisor=n.Supervisor,
                               Concepto=n.Concepto,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               FechaProceso=n.FechaProceso,
                               Poliza=n.Poliza,
                               SumaAsegurada=n.SumaAsegurada,
                               SubTotal=n.SubTotal,
                               ISC=n.ISC,
                               Total=n.Total,
                               Tasa=n.Tasa,
                               PieNota=n.PieNota,
                               DireccionCompania=n.DireccionCompania,
                               CantidadRegistros=n.CantidadRegistros
                                   

    }).ToList();
            return Listado;
        }

        public UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF MantenimientoFacturasPDF(UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF Item, string Accion) {

            UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF Mantenimeinto = null;

            var FacturasPDF = Objdata.SP_ELIMINAR_REGISTROS_PDF(
                Item.IdComprobante,
                Item.Comprobante,
                Item.ComprobanteAfectado,
                Accion);
            if (FacturasPDF != null) {
                Mantenimeinto = (from n in FacturasPDF
                                 select new UtilidadesAmigos.Logica.Entidades.EGenerarDatosFacturasPDF
                                 {
                                     IdComprobante = n.IdComprobante,
                                     Comprobante = n.Comprobante,
                                     ComprobanteAfectado=n.ComprobanteAfectado
                                 }).FirstOrDefault();
            }
            return Mantenimeinto;
        }
        #endregion
        #region GUARDAR LOS DATOS PARA EL REPORTE DE LA PRODUCCION DE UN INTERMEDIARIO
        public UtilidadesAmigos.Logica.Entidades.EGuardarRegistrosProduccionIntermediario GaurdarRegistrosProduccionIntermediario(UtilidadesAmigos.Logica.Entidades.EGuardarRegistrosProduccionIntermediario Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EGuardarRegistrosProduccionIntermediario Guardar = null;

            var RegistrosProduccionIntermediario = Objdata.SP_GUARDAR_REGISTROS_REPORTE_PRODUCCION_INTERMEIARIO(
                Item.IdUsuario,
                Item.Poliza,
                Item.NoFactura,
                Item.FechaSinFormato,
                Item.Mes,
                Item.Fecha,
                Item.Valor,
                Item.Cliente,
                Item.Vendedor,
                Item.Cobreaor,
                Item.Concepto,
                Item.Balance,
                Item.NCF,
                Item.Tasa,
                Item.Moneda,
                Item.Ofiicna,
                Item.Total,
                Item.TipoVehiculo,
                Item.Marca,
                Item.Modelo,
                Item.Capacidad,
                Item.Ano,
                Item.Color,
                Item.Chasis,
                Item.Placa,
                Item.Uso,
                Item.ValorVehiculo,
                Accion);
            if (RegistrosProduccionIntermediario != null) {
                Guardar = (from n in RegistrosProduccionIntermediario
                           select new UtilidadesAmigos.Logica.Entidades.EGuardarRegistrosProduccionIntermediario
                           {
                               IdUsuario=n.IdUsuario,
                               Poliza=n.Poliza,
                               NoFactura=n.NoFactura,
                               FechaSinFormato=n.FechaSinFormato,
                               Mes=n.Mes,
                               Fecha=n.Fecha,
                               Valor=n.Valor,
                               Cliente=n.Cliente,
                               Vendedor=n.Vendedor,
                               Cobreaor=n.Cobreaor,
                               Concepto=n.Concepto,
                               Balance=n.Balance,
                               NCF=n.NCF,
                               Tasa=n.Tasa,
                               Moneda=n.Moneda,
                               Ofiicna=n.Ofiicna,
                               Total=n.Total,
                               TipoVehiculo=n.TipoVehiculo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Capacidad=n.Capacidad,
                               Ano=n.Ano,
                               Color=n.Color,
                               Chasis=n.Chasis,
                               Placa=n.Placa,
                               Uso=n.Uso,
                               ValorVehiculo=n.ValorVehiculo
                           }).FirstOrDefault();

            }
            return Guardar;
        }
        #endregion

        #region MOSTRAR LA COBERTURAS DE LAS POLIZAS
        public List<UtilidadesAmigos.Logica.Entidades.EBuscarCoberturasPoliza> BuscarCoberturaPolizas(string Poliza = null, int? Item = null, int? CodigoCobertura = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCAR_COBERTURAS_POLIZA(Poliza, Item, CodigoCobertura)
                           select new UtilidadesAmigos.Logica.Entidades.EBuscarCoberturasPoliza
                           {
                               Poliza=n.Poliza,
                               Cotizacion=n.Cotizacion,
                               Estatus=n.Estatus,
                               Prima=n.Prima,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               SecuenciaCot=n.SecuenciaCot,
                               Secuencia =n.Secuencia,
                               Descripcion=n.Descripcion,
                               MontoInformativo=n.MontoInformativo,
                               PorcDeducible=n.PorcDeducible,
                               MinimoDeducible=n.MinimoDeducible,
                               PorcCobertura=n.PorcCobertura
                           }).ToList();
            return Listado;
        }
        //MODIFICAR LA DATA DE LAS COBERTURAS
        public UtilidadesAmigos.Logica.Entidades.EModificarCoberturasPolizas ModificarCoberturasPolizas(UtilidadesAmigos.Logica.Entidades.EModificarCoberturasPolizas Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EModificarCoberturasPolizas Modificar = null;

            var CoberturaPoliza = Objdata.SP_MODIFICAR_COBERTURAS_POLIZAS(
                Item.Compania,
                Item.Cotizacion,
                Item.Ramo,
                Item.SubRamo,
                Item.SecuenciaCot,
                Item.Secuencia,
                Item.Descripcion,
                Item.MontoInformativo,
                Item.TieneCobertura,
                Item.Porciento,
                Item.Prima,
                Item.PorcDeducible,
                Item.MinimoDeducible,
                Item.Endoso,
                Item.PorcCobertura,
                Item.ValorServicio,
                Accion);
            if (CoberturaPoliza != null) {
                Modificar = (from n in CoberturaPoliza
                             select new UtilidadesAmigos.Logica.Entidades.EModificarCoberturasPolizas
                             {
                                 Compania =n.Compania,
                                 Cotizacion =n.Cotizacion,
                                 Ramo=n.Ramo,
                                 SubRamo=n.SubRamo,
                                 SecuenciaCot=n.SecuenciaCot,
                                 Secuencia=n.Secuencia,
                                 Descripcion=n.Descripcion,
                                 MontoInformativo=n.MontoInformativo,
                                 TieneCobertura=n.TieneCobertura,
                                 Porciento=n.Porciento,
                                 Prima=n.Prima,
                                 PorcDeducible=n.PorcDeducible,
                                 MinimoDeducible=n.MinimoDeducible,
                                 Endoso=n.Endoso,
                                 PorcCobertura=n.PorcCobertura,
                                 ValorServicio=n.ValorServicio
                             }).FirstOrDefault();
            }
            return Modificar;
        }
        #endregion

        #region SACAR EL NUMERO DE COTIZACION DE POLIZAS
        public List<UtilidadesAmigos.Logica.Entidades.ESacarNumeroCotizacionPoliza> SacarNumeroCotizacion(string Poliza = null) {
            Objdata.CommandTimeout = 999999999;

            var Numero = (from n in Objdata.SP_SACAR_NUMERO_COTIZACION_POLIZA(Poliza)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarNumeroCotizacionPoliza
                          {
                              Cotizacion=n.Cotizacion
                          }).ToList();
            return Numero;
        }
        #endregion

        #region OTROS TIPOS DE BUSQUEDA
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaOtrosTiposBusqurdaPolizas> BuscaOtrosTipoFiltros(string DatoBusqueda = null, int? TipoDato = null, decimal? Cotizacion = null, int? Item = null) {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_OTROS_TIPOS_BUSQUEDA_POLIZA(DatoBusqueda, TipoDato, Cotizacion, Item)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaOtrosTiposBusqurdaPolizas
                          {
                              Poliza=n.Poliza,
                              Item=n.Item,
                              Estatus=n.Estatus,
                              SumaAsegurada=n.SumaAsegurada,
                              Cliente=n.Cliente,
                              Asegurado=n.Asegurado,
                              Intermediario=n.Intermediario,
                              Prima=n.Prima,
                              Cotizacion=n.Cotizacion,
                              Ramo=n.Ramo,
                              Subramo=n.Subramo,
                              TipoVehiculo=n.TipoVehiculo,
                              Marca=n.Marca,
                              Modelo=n.Modelo,
                              Capacidad=n.Capacidad,
                              Ano=n.Ano,
                              Color=n.Color,
                              Chasis=n.Chasis,
                              Placa=n.Placa,
                              Uso=n.Uso,
                              ValorVehiculo=n.ValorVehiculo
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region PROCESAR INFORMACION COMISIONES INTERMEDIARIO
        public UtilidadesAmigos.Logica.Entidades.EProcesarComisionesIntermediario ProcesarInformacionReporteComisioIntermediario(UtilidadesAmigos.Logica.Entidades.EProcesarComisionesIntermediario Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EProcesarComisionesIntermediario Procesar = null;

            var InformacionReporteComisionIntermediario = Objdata.SP_PROCESAR_INFORMACION_REPORTE_COMISIONES_INTERMEDIARIO(
                Item.IdUsuario,
                Item.Supervisor,
                Item.CodigoIntermediario,
                Item.Intermediario,
                Item.Oficina,
                Item.NumeroIdentificacion,
                Item.CuentaBanco,
                Item.TipoCuenta,
                Item.Banco,
                Item.Cliente,
                Item.NumeroRecibo,
                Item.FechaRecibo,
                Item.NumeroFactura,
                Item.FechaFactura,
                Item.Moneda,
                Item.Poliza,
                Item.Producto,
                Item.MontoBruto,
                Item.MontoNeto,
                Item.PorcientoComision,
                Item.Comsiion,
                Item.Retencion,
                Item.AvanceComision,
                Item.ALiquidar,
                Item.CantidadRegistros,
                Item.ValidadoDesde,
                Item.ValidadoHasta,
                Accion);
            if (InformacionReporteComisionIntermediario != null) {
                Procesar = (from n in InformacionReporteComisionIntermediario
                            select new UtilidadesAmigos.Logica.Entidades.EProcesarComisionesIntermediario
                            {
                                IdUsuario=n.IdUsuario,
                                Supervisor=n.Supervisor,
                                CodigoIntermediario=n.CodigoIntermediario,
                                Intermediario=n.Intermediario,
                                Oficina=n.Oficina,
                                NumeroIdentificacion=n.NumeroIdentificacion,
                                CuentaBanco=n.CuentaBanco,
                                TipoCuenta=n.TipoCuenta,
                                Banco=n.Banco,
                                Cliente=n.Cliente,
                                NumeroRecibo=n.NumeroRecibo,
                                FechaRecibo=n.FechaRecibo,
                                NumeroFactura=n.NumeroFactura,
                                FechaFactura=n.FechaFactura,
                                Moneda=n.Moneda,
                                Poliza=n.Poliza,
                                Producto=n.Producto,
                                MontoBruto=n.MontoBruto,
                                MontoNeto=n.MontoNeto,
                                PorcientoComision=n.PorcientoComision,
                                Comsiion=n.Comsiion,
                                Retencion=n.Retencion,
                                AvanceComision=n.AvanceComision,
                                ALiquidar=n.ALiquidar,
                                CantidadRegistros=n.CantidadRegistros,
                                ValidadoDesde=n.ValidadoDesde,
                                ValidadoHasta=n.ValidadoHasta
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        #region MANTENIMIENTO DE CODIGOS DE SUPERVISORES PERMITIDOS
        //BUSCAR LOS CODIGOS DE SUPERVISORES PERMITIDOS

        public List<UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos> BuscarCodigosSupervisoresPermitidos(decimal? IdRegistro = null, string CodigoSupervisor = null, string NombreSupervisor = null, decimal? IdUsuario = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null) {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCAR_CODIGOS_SUPERVISORES_PERMITIDOS(IdRegistro, CodigoSupervisor, NombreSupervisor, IdUsuario, FechaDesde, FechaHasta)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos
                          {
                              IdRegistro=n.IdRegistro,
                              CodigoSupervisor=n.CodigoSupervisor, /*(*_*)*/
                              Nombre=n.Nombre,/*(*_*)*/
                              CodigoOficina =n.CodigoOficina,
                              Oficina=n.Oficina,/*(*_*)*/
                              FechaAgregado0 =n.FechaAgregado0,
                              FechaAgregado=n.FechaAgregado,/*(*_*)*/
                              IdUsuario =n.IdUsuario,
                              CreadoPor=n.CreadoPor/*(*_*)*/
                          }).ToList();
            return Buscar;
        }

        //MANTENIMEINTO DE CODIGOS SUPERVISORES PERMITIDOS
        public UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos MantenimientoCodigoSupervisoresPermitidos(UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos Mantenimiento = null;

            var CodigosSupervisoresPermitidos = Objdata.SP_MANTENIMEINTO_CODIGOS_PERMITIDOS(
                Item.IdRegistro,
                Item.CodigoSupervisor,
                Item.IdUsuario,
                Accion);
            if (CodigosSupervisoresPermitidos != null) {
                Mantenimiento = (from n in CodigosSupervisoresPermitidos
                                 select new UtilidadesAmigos.Logica.Entidades.EBuscarCodigosSupervisoresPermitidos
                                 {
                                     IdRegistro=n.IdRegistro,
                                     CodigoSupervisor=n.CodigoSupervisor,
                                     IdUsuario=n.IdUsuario,
                                     FechaAgregado0=n.FechaAgregado
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }

        #region BUSCAR INFORMACION SUPERVISOR CODIGOS PERMITIDOS
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaInformacionSupervisorCodigoPermitido> BuscaInformacionSUperisor(string Codigo = null, string Nombre = null) {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_INFORMACION_SUPERVISOR_CODIGOS_PERMITIDOS(Codigo, Nombre)
                          select new UtilidadesAmigos.Logica.Entidades.EBuscaInformacionSupervisorCodigoPermitido
                          {
                              Codigo=n.Codigo,
                              Nombre=n.Nombre,
                              Estatus=n.Estatus,
                              CodigoOficina=n.CodigoOficina,
                              Oficina=n.Oficina
                          }).ToList();
            return Buscar;

        }
        #endregion
        #endregion
        #region GENERAR CODIGOS COMISIONES SUPERVISORES
        //PROCESAR DATOS COMISIONES SUPERVISORES
        public UtilidadesAmigos.Logica.Entidades.EProcesarDatosComisionesSupervisores ProcesarDatosComisionesSupervisores(UtilidadesAmigos.Logica.Entidades.EProcesarDatosComisionesSupervisores Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EProcesarDatosComisionesSupervisores Procesar = null;

            var DatosComisionesSupervisores = Objdata.SP_PROCESAR_DATOS_COMISIONES_SUPERVISORES(
                Item.IdUsuario,
                Item.FechaDesde,
                Item.FechaHasta,
                Item.CodigoSupervisor,
                Item.Supervisor,
                Item.CodigoIntermediario,
                Item.Intermediario,
                Item.Poliza,
                Item.NumeroFactura,
                Item.Valor,
                Item.Fecha,
                Item.Fecha0,
                Item.CodigoOficina,
                Item.Oficina,
                Item.Conepto,
                Item.PorcientoComision,
                Item.ComisionPagar,
                Accion);
            if (DatosComisionesSupervisores != null) {
                Procesar = (from n in DatosComisionesSupervisores
                            select new UtilidadesAmigos.Logica.Entidades.EProcesarDatosComisionesSupervisores
                            {
                                IdUsuario=n.IdUsuario,
                                FechaDesde=n.FechaDesde,
                                FechaHasta=n.FechaHasta,
                                CodigoSupervisor=n.CodigoSupervisor,
                                Supervisor=n.Supervisor,
                                CodigoIntermediario=n.CodigoIntermediario,
                                Intermediario=n.Intermediario,
                                Poliza=n.Poliza,
                                NumeroFactura=n.NumeroFactura,
                                Valor=n.Valor,
                                Fecha=n.Fecha,
                                Fecha0=n.Fecha0,
                                CodigoOficina=n.CodigoOficina,
                                Oficina=n.Oficina,
                                Conepto=n.Conepto,
                                PorcientoComision=n.PorcientoComision,
                                ComisionPagar=n.ComisionPagar
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
        #region CONSULTAR DATOS COMISIONES SUPERVISOR
        //REPORTE RESUMIDO
        public List<UtilidadesAmigos.Logica.Entidades.EReporteComisionSupervisorResumido> ReporteComisionesSupervisorResumido(decimal? IdUsuario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_REPORTE_DETALLE_COMISION_RESUMIDO(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.EReporteComisionSupervisorResumido
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               FechaDesde0=n.FechaDesde0,
                               ValidadoDesde=n.ValidadoDesde,
                               FechaHasta0=n.FechaHasta0,
                               ValidadoHasta=n.ValidadoHasta,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               Oficina=n.Oficina,
                               ComisionPagar=n.ComisionPagar

                           }).ToList();
            return Listado;
        }

        //REPORTE COMISIONES DETALLE
        public List<UtilidadesAmigos.Logica.Entidades.EReporteDetalleComisionSupervisores> ReporteComisionesSupervisoresDetalle(decimal? IdUsuario = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_REPORTE_DETALLE_COMISION_SUPERVISORES(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.EReporteDetalleComisionSupervisores
                           {
                               IdUsuario=n.IdUsuario,
                               GeneradoPor=n.GeneradoPor,
                               FechaDesde0=n.FechaDesde0,
                               ValidadoDesde=n.ValidadoDesde,
                               FechaHasta0=n.FechaHasta0,
                               ValidadoHasta=n.ValidadoHasta,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               CodigoIntermediario=n.CodigoIntermediario,
                               Intermediario=n.Intermediario,
                               Poliza=n.Poliza,
                               NumeroFactura=n.NumeroFactura,
                               Valor=n.Valor,
                               Fecha=n.Fecha,
                               Fecha0=n.Fecha0,
                               CodigoOficina=n.CodigoOficina,
                               Oficina=n.Oficina,
                               Conepto=n.Conepto,
                               PorcientoComision=n.PorcientoComision,
                               ComisionPagar=n.ComisionPagar
                           }).ToList();
            return Listado;
        }
        #endregion

        #region BUSCAR DATOS PARA LA UBICACION GEOGRAFICA
        public List<UtilidadesAmigos.Logica.Entidades.EDatosUbicacionGeografica> BuscaDatosUbicacionGeografica(int? CodigoPais = null, int? CodigoZona = null, int? CodigoProvincia = null, int? CodigoMunicipio = null, int? CodigoSector = null, int? CodigoUbicacion = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_DATOS_UBICACION_GEOGRAFICA(CodigoPais, CodigoZona, CodigoProvincia, CodigoMunicipio, CodigoSector, CodigoUbicacion)
                           select new UtilidadesAmigos.Logica.Entidades.EDatosUbicacionGeografica
                           {
                               CodPais=n.CodPais,
                               Pais=n.Pais,
                               CodZona=n.CodZona,
                               Zona=n.Zona,
                               CodProvincia=n.CodProvincia,
                               Provincia=n.Provincia,
                               CodMunicipio=n.CodMunicipio,
                               Municipio=n.Municipio,
                               CodSector=n.CodSector,
                               Sector=n.Sector,
                               CodUbicacion=n.CodUbicacion,
                               Ubicacion=n.Ubicacion
                           }).ToList();
            return Listado;
        }
        #endregion

        #region SACAR NOMBRE DE CLIENTE
        public List<UtilidadesAmigos.Logica.Entidades.ESacarNombreCliente> SacarNombreCliente(string CodigoCliente = null) {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_SACAR_NOMBRE_CLIENTE(CodigoCliente)
                          select new UtilidadesAmigos.Logica.Entidades.ESacarNombreCliente
                          {
                              Cliente=n.Cliente
                          }).ToList();
            return Buscar;
        }
        #endregion


        #region MANTENIMIENTO DE CONTROL DE VISITAS
        /// <summary>
        /// Este metodo es para buscar el listado de las visitas y entregas de documentos entregadas
        /// </summary>
        /// <param name="NoRegistro"></param>
        /// <param name="IdTipoProcesoRecepcion"></param>               
        /// <param name="Nombre"></param>
        /// <param name="Remitente"></param>
        /// <param name="Destinatario"></param>
        /// <param name="UsuarioDigita"></param>
        /// <param name="FechaDigitaDesde"></param>
        /// <param name="FechaDigitaHasta"></param>
        /// <param name="UsuarioGenera"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.EControlVisitas> BuscaControlVisitas(decimal? NoRegistro = null, int? IdTipoProcesoRecepcion = null, string Nombre = null, string Remitente = null, string Destinatario = null, decimal? UsuarioDigita = null, DateTime? FechaDigitaDesde = null, DateTime? FechaDigitaHasta = null, decimal? UsuarioGenera = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_CONTROL_VISITA(NoRegistro, IdTipoProcesoRecepcion, Nombre, Remitente, Destinatario, UsuarioDigita, FechaDigitaDesde, FechaDigitaHasta, UsuarioGenera)
                           select new UtilidadesAmigos.Logica.Entidades.EControlVisitas
                           {
                               NoRegistro=n.NoRegistro,
                               IdTipoProcesoRecepcion=n.IdTipoProcesoRecepcion,
                               TipoProceso=n.TipoProceso,
                               Nombre=n.Nombre,
                               Remitente=n.Remitente,
                               Destinatario=n.Destinatario,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               CantidadDocumentos=n.CantidadDocumentos,
                               CantidadPersonas=n.CantidadPersonas,
                               UsuarioDigita=n.UsuarioDigita,
                               DigitadoPor=n.DigitadoPor,
                               FechaDigita0=n.FechaDigita0,
                               FechaDigita=n.FechaDigita,
                               HoraDigita=n.HoraDigita,
                               UsuarioModifica=n.UsuarioModifica,
                               Modificado=n.Modificado,
                               FechaModifica0=n.FechaModifica0,
                               HoraModifica=n.HoraModifica,
                               FechaModifica=n.FechaModifica,
                               Comentario=n.Comentario,
                               GeneradoPor=n.GeneradoPor

                           }).ToList();
            return Listado;
        
        }


        public UtilidadesAmigos.Logica.Entidades.EControlVisitas ProcesarControlVisitas(UtilidadesAmigos.Logica.Entidades.EControlVisitas Item, string Accion) {
            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EControlVisitas Procesar = null;

            var ControlVisitas = Objdata.SP_PROCESAR_CONTROL_VISITAS(
                Item.NoRegistro,
                Item.IdTipoProcesoRecepcion,
                Item.Nombre,
                Item.Remitente,
                Item.Destinatario,
                Item.NumeroIdentificacion,
                Item.CantidadDocumentos,
                Item.CantidadPersonas,
                Item.UsuarioDigita,
                Item.UsuarioModifica,
                Item.Comentario,
                Accion);
            if (ControlVisitas != null) {
                Procesar = (from n in ControlVisitas
                            select new UtilidadesAmigos.Logica.Entidades.EControlVisitas
                            {
                                NoRegistro=n.NoRegistro,
                                IdTipoProcesoRecepcion=n.IdTipoProcesoRecepcion,
                                Nombre=n.Nombre,
                                Remitente=n.Remitente,
                                Destinatario=n.Destinatario,
                                NumeroIdentificacion=n.NumeroIdentificacion,
                                CantidadDocumentos=n.CantidadDocumentos,
                                CantidadPersonas=n.CantidadPersonas,
                                UsuarioDigita=n.UsuarioDigita,
                                FechaDigita0=n.FechaDigita,
                                UsuarioModifica=n.UsuarioModifica,
                                FechaModifica0=n.FechaModifica,
                                Comentario=n.Comentario
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion

        public List<UtilidadesAmigos.Logica.Entidades.EValidarPoliza> ValidarPoliza(string Poliza = null) {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_VALIDAR_POLIZA(Poliza)
                           select new UtilidadesAmigos.Logica.Entidades.EValidarPoliza
                           {
                               Compania = n.Compania,
                               Cotizacion = n.Cotizacion,
                               Cliente = n.Cliente,
                               Intermediario = n.Intermediario,
                               Poliza = n.Poliza,
                               MontoNeto = n.MontoNeto,
                               UsuarioAdiciona = n.UsuarioAdiciona,
                               FechaAdiciona = n.FechaAdiciona,
                               UsuarioModifica = n.UsuarioModifica,
                               FechaModifica = n.FechaModifica,
                               Estatus = n.Estatus,
                               Ramo = n.Ramo,
                               Hora = n.Hora,
                               SumaAsegurada = n.SumaAsegurada,
                               Deudor = n.Deudor,
                               CodMoneda = n.CodMoneda,
                               Prima = n.Prima,
                               Observacion = n.Observacion,
                               PorcComision = n.PorcComision,
                               Oficina = n.Oficina
                           }).ToList();
            return Listado;
        }


        #region ESTADISTICA DE POLIZAS SIN PAGOS
        /// <summary>
        /// Muestra la cantidad de estadistica de las polizas sin pagos cantidad
        /// </summary>
        /// <param name="CodigoProceso"></param>
        /// <param name="Ramo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.EBuscaEstadisticaPagosPolizaCantidad> BuscaEstadisticaPolizasSinPagosCantidad(int? CodigoProceso = null, int? Ramo = null) {

            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_ESTADISTICA_COBROS_POLIZAS_CANTIDAD(CodigoProceso, Ramo)
                           select new UtilidadesAmigos.Logica.Entidades.EBuscaEstadisticaPagosPolizaCantidad
                           {
                               Cantidad=n.Cantidad
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Muestra la estadistica de polizas sin pagos Registros
        /// </summary>
        /// <param name="CodigoProceso"></param>
        /// <param name="Ramo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.EEEstadisticaPolizaRegistros> BuscaEstadisticaPolizaSinPagosRegistros(int? CodigoProceso = null, int? Ramo = null) {

            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_ESTADISTICA_COBROS_POLIZAS_REGISTROS(CodigoProceso, Ramo)
                           select new UtilidadesAmigos.Logica.Entidades.EEEstadisticaPolizaRegistros
                           {
                               Poliza=n.Poliza,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Numero=n.Numero,
                               Balance=n.Balance,
                               Tipo=n.Tipo,
                               CodigoRamo=n.CodigoRamo,
                               Ramo=n.Ramo,
                               CodigoSubRamo=n.CodigoSubRamo,
                               SubRamo=n.SubRamo,
                               CodigoAsegurado=n.CodigoAsegurado,
                               Asegurado=n.Asegurado,
                               CodigoVendedor=n.CodigoVendedor,
                               Vendedor=n.Vendedor,
                               CodigoSupervisor=n.CodigoSupervisor,
                               Supervisor=n.Supervisor,
                               Codigooficina=n.Codigooficina,
                               Oficina=n.Oficina,
                               Fecha0=n.Fecha0,
                               Fecha=n.Fecha,
                               Hora=n.Hora,
                               DiasTranscurridos=n.DiasTranscurridos,
                               Ncf=n.Ncf,
                               MontoBruto=n.MontoBruto,
                               ISC=n.ISC,
                               MontoNeto=n.MontoNeto,
                               Cobrado=n.Cobrado,
                               CodMoneda=n.CodMoneda,
                               Moneda=n.Moneda,
                               Siglas=n.Siglas,
                               Concepto=n.Concepto
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Procesar la informacion para generar el reporte de estadistica de polizas sin pagos.
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.EReporteEstadisticaPolizasSinPagos ProcesarEstadisticaPolizasSinPagos(UtilidadesAmigos.Logica.Entidades.EReporteEstadisticaPolizasSinPagos Item, string Accion) {

            Objdata.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.EReporteEstadisticaPolizasSinPagos Procesar = null;

            var Estadistica = Objdata.SP_PROCESAR_INFORMACION_REPORTE_ESTADISTICA_POLIZAS_SIN_PAGOS(
                Item.IdUsuario,
                Item.Poliza,
                Item.NumeroFactura,
                Item.Tipo,
                Item.CodigoRamo,
                Item.Ramo,
                Item.CodigoSubRamo,
                Item.SubRamo,
                Item.CodigoAsegurado,
                Item.NombreAsegurado,
                Item.CodigoVendedor,
                Item.NombreVendedor,
                Item.CodigoSupervisor,
                Item.NombreSupervisor,
                Item.CodigoOficina,
                Item.NombreOficina,
                Item.Fecha,
                Item.FechaFormateada,
                Item.Hora,
                Item.DiasTranscurridos,
                Item.Ncf,
                Item.MontoBruto,
                Item.ISC,
                Item.MontoNeto,
                Item.Cobrado,
                Item.CodMoneda,
                Item.Moneda,
                Item.Siglas,
                Item.Concepto,
                Item.CodigoEstatus,
                Accion);
            if (Estadistica != null) {

                Procesar = (from n in Estadistica
                            select new UtilidadesAmigos.Logica.Entidades.EReporteEstadisticaPolizasSinPagos
                            {
                                IdUsuario=n.IdUsuario,
                                Poliza = n.Poliza,
                                NumeroFactura = n.NumeroFactura,
                                Tipo = n.Tipo,
                                CodigoRamo = n.CodigoRamo,
                                Ramo = n.Ramo,
                                CodigoSubRamo = n.CodigoSubRamo,
                                SubRamo = n.SubRamo,
                                CodigoAsegurado = n.CodigoAsegurado,
                                NombreAsegurado = n.NombreAsegurado,
                                CodigoVendedor = n.CodigoVendedor,
                                NombreVendedor = n.NombreVendedor,
                                CodigoSupervisor = n.CodigoSupervisor,
                                NombreSupervisor = n.NombreSupervisor,
                                CodigoOficina = n.CodigoOficina,
                                NombreOficina = n.NombreOficina,
                                Fecha = n.Fecha,
                                FechaFormateada = n.FechaFormateada,
                                Hora = n.Hora,
                                DiasTranscurridos = n.DiasTranscurridos,
                                Ncf = n.Ncf,
                                MontoBruto = n.MontoBruto,
                                ISC = n.ISC,
                                MontoNeto = n.MontoNeto,
                                Cobrado = n.Cobrado,
                                CodMoneda = n.CodMoneda,
                                Moneda = n.Moneda,
                                Siglas = n.Siglas,
                                Concepto = n.Concepto,
                                CodigoEstatus=n.CodigoEstatus
                            }).FirstOrDefault();
            }
            return Procesar;
        }

        /// <summary>
        /// Este metodo muestra los datos de la estadistica de cobros por antiguedad
        /// </summary>
        /// <param name="CodigoProceso"></param>
        /// <param name="Ramo"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.EEstadisticaCobrosPolizasAntiguedad> BuscaEstadisticaCobrosAntiguedad(int? CodigoProceso = null, int? Ramo = null) {

            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_BUSCA_ESTADISTICA_COBROS_POLIZAS_ANTIGUEDAD(CodigoProceso, Ramo)
                           select new UtilidadesAmigos.Logica.Entidades.EEstadisticaCobrosPolizasAntiguedad
                           {
                               E_0_30=n.E_0_30,
                               E_31_60=n.E_31_60,
                               E_61_90=n.E_61_90,
                               E_91_120=n.E_91_120,
                               E_121_150=n.E_121_150,
                               E_151_MAS=n.E_151_MAS,
                               CantidadAcumulada=n.CantidadAcumulada
                           }).ToList();
            return Listado;
        }
        #endregion
    }
}
