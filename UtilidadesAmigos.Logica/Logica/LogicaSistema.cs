using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<UtilidadesAmigos.Logica.Entidades.EUsuarios> BuscaUsuarios(decimal? IdUsuario = null, decimal? IdDepartamento = null, decimal? IdPerfil = null, string UsuarioConsulta = null, string Usuario = null, string Clave = null, bool? Estatus = null, int? NumeroPagina = null, int? NumeroRegistros = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_USUARIO(IdUsuario, IdDepartamento, IdPerfil, UsuarioConsulta, Usuario, Clave, Estatus, NumeroPagina,NumeroRegistros)
                          select new Entidades.EUsuarios
                          {
                              IdUsuario = n.IdUsuario,
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

                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE USUARIOS
        public Entidades.EMantenimientoUsuarios MantenimientoUsuarios(Entidades.EMantenimientoUsuarios item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.EMantenimientoUsuarios Mantenimiento = null;

            var Usuario = Objdata.SP_MANTENIMIENTO_USUARIOS(
                item.IdUsuario,
                item.IdDepartamento,
                item.IdPerfil,
                item.Usuario,
                item.Clave,
                item.Persona,
                item.Estatus,
                item.LlevaEmail,
                item.Email,
                item.Contador,
                item.CambiaClave,
                item.RazonBloqueo,
                Accion);
            if (Usuario != null)
            {
                Mantenimiento = (from n in Usuario
                                 select new Entidades.EMantenimientoUsuarios
                                 {
                                     IdUsuario=n.IdUsuario,
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
                                     RazonBloqueo=n.RazonBloqueo
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
        public List<Entidades.EOficinas> CargarOficinas(int? Oficina = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_LISTA_OFICINAS(Oficina, Descripcion)
                          select new Entidades.EOficinas
                          {
                              Oficina=n.Oficina,
                              Descripcion=n.Descripcion
                          }).ToList();
            return Buscar;
        }

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
                              PesosDominicanos=n.PesosDominicanos
                          }).ToList();
            return Buscar;
        }
        //PRODUCCION DIARIA DETALLE
        public List<Entidades.EProduccionDiariaDetalle> MostrarProduccionDiariaDetalle(DateTime? FechaDesde = null, DateTime? FechaHasta = null, string Concepto = null, string Ramo = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_PRODUCCION_DIARIA_DETALLE(FechaDesde, FechaHasta, Concepto, Ramo)
                          select new Entidades.EProduccionDiariaDetalle
                          {
                              Ramo=n.Ramo,
                              Subramo=n.Subramo,
                              Concepto=n.Concepto,
                              Cantidad=n.Cantidad,
                              FacturadoPesos=n.FacturadoPesos,
                              FacturadoDollar=n.FacturadoDollar,
                              FacturadoTotal=n.FacturadoTotal,
                              FacturadoNeto=n.FacturadoNeto
                          }).ToList();
            return Buscar;
        }
        #endregion

        #region PRODUCCION POR USUARIOS
        //LISTADO DE PRODUCCION POR USUARIOS
        public List<Entidades.ProduccionPorUsuario> BuscaProduccionPorUsuarios(DateTime? FechaDesde = null, DateTime? FechaHasta = null, decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEmpleado = null)
        {
            Objdata.CommandTimeout = 999999999;

            var SacarProduccion = (from n in Objdata.SP_PRODUCCION_POR_USUARIO(FechaDesde, FechaHasta, IdOficina, IdDepartamento, IdEmpleado)
                                   select new Entidades.ProduccionPorUsuario
                                   {
                                       IdOficina=n.IdOficina,
                                       Oficina=n.Oficina,
                                       IdDepartamento=n.IdDepartamento,
                                       Departamento=n.Departamento,
                                       IdEmpleado=n.IdEmpleado,
                                       Usuario=n.Usuario,
                                       Concepto=n.Concepto,
                                       Cantidad=n.Cantidad,
                                       FechaDesde=n.FechaDesde,
                                       FechaHasta=n.FechaHasta
                                   }).ToList();
            return SacarProduccion;
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
                              Usuario=n.Usuario,
                              Factura=n.Factura,
                              Valor=n.Valor,
                              Poliza=n.Poliza,
                              Fecha=n.Fecha,
                              Balance=n.Balance,
                              Concepto=n.Concepto
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
                              NumeroPago=n.NumeroPago,
                              Valor=n.Valor,
                              Poliza=n.Poliza,
                              Fecha=n.Fecha,
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
                              Clave=n.Clave
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

        #region MANTENIMIENTO DE TARJETAS DE ACCESOS
        //LISTADO DE TARJETAS DE ACCESO
        public List<Entidades.ETarjetaAcceso> BuscarTarjetaAcceso(decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEmpleado = null, decimal? IdTarjetaAcceso = null, string NumeroTarjeta = null, string SecuenciaInterna = null, DateTime? FechaEntregaDesde = null, DateTime? FechaEntregaHasta = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_TARJETA_ACCESO(IdOficina, IdDepartamento, IdEmpleado, IdTarjetaAcceso, NumeroTarjeta, SecuenciaInterna, FechaEntregaDesde, FechaEntregaHasta)
                          select new Entidades.ETarjetaAcceso
                          {
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              IdEmpleado=n.IdEmpleado,
                              Empleado=n.Empleado,
                              IdTarjetaAcceso=n.IdTarjetaAcceso,
                              SecuenciaInterna0=n.SecuenciaInterna0,
                              SecuenciaInterna=n.SecuenciaInterna,
                              NumeroTarjeta=n.NumeroTarjeta,
                              FechaEntrega0=n.FechaEntrega0,
                              FechaEntrega=n.FechaEntrega,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                             CreadoPor=n.CreadoPor,
                             FechaAdiciona=n.FechaAdiciona,
                             UsuarioModicia=n.UsuarioModicia,
                             ModificadoPor=n.ModificadoPor,
                             FechaModifica=n.FechaModifica
                          }).ToList();
            return Buscar;

            
        }
        //MANTENIMIENTO DE TARJETAS DE ACCESO
        public Entidades.ETarjetaAcceso MantenimientoTarjetaAcceso(Entidades.ETarjetaAcceso Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.ETarjetaAcceso Mantenimiento = null;

            var tarjetaAcceso = Objdata.SP_MANTENIMIENTO_TARJETAS_ACCESO(
                Item.IdOficina,
                Item.IdDepartamento,
                Item.IdEmpleado,
                Item.IdTarjetaAcceso,
                Item.SecuenciaInterna0,
                Item.NumeroTarjeta,
                Item.FechaEntrega0,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (tarjetaAcceso != null)
            {
                Mantenimiento = (from n in tarjetaAcceso
                                 select new Entidades.ETarjetaAcceso
                                 {
                                     IdOficina=n.IdOficina,
                                     IdDepartamento=n.IdDepartamento,
                                     IdEmpleado=n.IdEmpleado,
                                     IdTarjetaAcceso=n.IdTarjetaAcceso,
                                     SecuenciaInterna0=n.SecuenciaInterna,
                                     NumeroTarjeta=n.NumeroTarjeta,
                                     FechaEntrega0=n.FechaEntrega,
                                     Estatus0=n.Estatus,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona,
                                     UsuarioModicia=n.UsuarioModicia,
                                     FechaModifica=n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
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
        public List<UtilidadesAmigos.Logica.Entidades.ECarteraSupervisor> SacarCarteraSupervisor(decimal? CodigoSupervisor = null, decimal? CodigoIntermediario = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Listado = (from n in Objdata.SP_SACAR_CARTERA_SUPERVISORES(CodigoSupervisor, CodigoIntermediario)
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
                               Recibo=n.Recibo,
                               Valor=n.Valor,
                               Poliza=n.Poliza,
                               Fecha=n.Fecha,
                               Facturado=n.Facturado,
                               TotalPagado=n.TotalPagado,
                               Balance=n.Balance

                           }).ToList();
            return Detalle;
        }
#endregion
    }
}
