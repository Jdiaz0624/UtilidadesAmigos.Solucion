using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaCotizador
{
    public class LogicaCotizador
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDCotizadorDataContext ObjData = new Data.Conexiones.LINQ.BDCotizadorDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region VERIFICAR LOS PERMISOS DE LOS TIPOS DE COBERTURA
        public List<Entidades.Cotizador.EVerificarServicios> VerificarTipoCbertura(decimal? IdTipoCotizador = null,decimal? IdServicio = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_VERIFICAR_PERMISO_SERVICIOS(IdTipoCotizador, IdServicio)
                           select new Entidades.Cotizador.EVerificarServicios
                           {
                               IdTipoCotizador=n.IdTipoCotizador,
                               TipoCotizador=n.TipoCotizador,
                               Estatus0=n.Estatus0,
                               EstatusTipoCotizador=n.EstatusTipoCotizador,
                               IdServicio=n.IdServicio,
                               Servicio=n.Servicio,
                               Estatus00=n.Estatus00,
                               EstatusServicios=n.EstatusServicios,
                               TieneAcceso0=n.TieneAcceso0,
                               TieneAcceso=n.TieneAcceso
                           }).ToList();
            return Listado;
        }
        #endregion

        #region MANTENIMIENTO DE TIPO DE COTIZADOR
        //LISTADO DE TIPO DE COTIZADOR
        public List<Entidades.Cotizador.ETipoCotizador> BuscaTipoCotizador(decimal? IdTipoCotizador = null, string Descripcion = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_COTIZADOR_TIPO_COTIZADOR(IdTipoCotizador, Descripcion)
                           select new Entidades.Cotizador.ETipoCotizador
                           {
                               IdTipoCotizador=n.IdTipoCotizador,
                               TipoCotizador=n.TipoCotizador,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }

        //MANTENIMIENTO DE TIPO DE COTIZADOR
        public Entidades.Cotizador.ETipoCotizador MantenimientoTipoCotizador(Entidades.Cotizador.ETipoCotizador Item, string Accion)
        {
            ObjData.CommandTimeout = 999999999;

            Entidades.Cotizador.ETipoCotizador Mantenimiento = null;

            var TipoCotizador = ObjData.SP_COTIZADOR_MANTENIMIENTO_TIPO_COTIZADOR(
                Item.IdTipoCotizador,
                Item.TipoCotizador,
                Item.Estatus0,
                Accion);
            if (TipoCotizador != null)
            {
                Mantenimiento = (from n in TipoCotizador
                                 select new Entidades.Cotizador.ETipoCotizador
                                 {
                                     IdTipoCotizador=n.IdTipoCotizador,
                                     TipoCotizador=n.Descripcion,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE VALOR DE VEHICULO
        //LISTADO DE VALOR DE VEHICULO
        public List<Entidades.Cotizador.EValorVehiculo> BuscaValorVehiculo(decimal? IdTipoCotizador = null, decimal? IdValorVehiculo = null, string Descripcion = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Buscar = (from n in ObjData.SP_BUSCA_COTIZADOR_VALOR_VEHICULO(IdTipoCotizador, IdValorVehiculo, Descripcion)
                          select new Entidades.Cotizador.EValorVehiculo
                          {
                              IdTipoCotizador=n.IdTipoCotizador,
                              TipoCotizador=n.TipoCotizador,
                              IdValorVehiculo=n.IdValorVehiculo,
                              ValorVehiculo=n.ValorVehiculo,
                              Estatus=n.Estatus,
                              Estatus0=n.Estatus0
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE VALOR DE VEHICULO
        public Entidades.Cotizador.EValorVehiculo MantenimientoValorVehiculo(Entidades.Cotizador.EValorVehiculo Item, string Accion)
        {
            ObjData.CommandTimeout = 999999999;

            Entidades.Cotizador.EValorVehiculo Mantenimiento = null;

            var ValorVehiculo = ObjData.SP_COTIZADOR_MANTENIMIENTO_VALOR_VEHICULO(
                Item.IdTipoCotizador,
                Item.IdValorVehiculo,
                Item.ValorVehiculo,
                Item.Estatus0,
                Accion);
            if (ValorVehiculo != null)
            {
                Mantenimiento = (from n in ValorVehiculo
                                 select new Entidades.Cotizador.EValorVehiculo
                                 {
                                     IdTipoCotizador=n.IdTipoCotizador,
                                     IdValorVehiculo=n.IdValorVehiculo,
                                     ValorVehiculo=n.ValorVehiculo,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE AÑO DE VEHICULO

        //MOSTRAR EL LISTADO DE AÑO DE VEHICULO

        public List<Entidades.Cotizador.EAnoVehiculo> BuscaAnoVehiculo(decimal? IdTipoCotizador = null, decimal? IdValorVehiculo = null, decimal? IdAnoVehiculo = null, string AnoVehiculo = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Buscar = (from n in ObjData.SP_COTIZADOR_BUSCA_ANO_VEHICULO(IdTipoCotizador, IdValorVehiculo, IdAnoVehiculo, AnoVehiculo)
                          select new Entidades.Cotizador.EAnoVehiculo
                          {
                              IdTipoCotizador=n.IdTipoCotizador,
                              TipoCotizador=n.TipoCotizador,
                              IdValorVehiculo=n.IdValorVehiculo,
                              ValorVehiculo=n.ValorVehiculo,
                              IdAnoVehiculo=n.IdAnoVehiculo,
                              AnoVehiculo=n.AnoVehiculo,
                              Estatus=n.Estatus,
                              Estatus0=n.Estatus0
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE AÑO DE VEHICULO
        public Entidades.Cotizador.EAnoVehiculo MantenimientoAnoVehiculo(Entidades.Cotizador.EAnoVehiculo Item, string Accion)
        {
            ObjData.CommandTimeout = 999999999;

            Entidades.Cotizador.EAnoVehiculo Mantenimiento = null;

            var AnoVehiculo = ObjData.SP_COTIZADOR_MANTENIMIENTO_ANO_VEHICULO(
                Item.IdTipoCotizador,
                Item.IdValorVehiculo,
                Item.IdAnoVehiculo,
                Item.AnoVehiculo,
                Item.Estatus0,
                Accion);
            if (AnoVehiculo != null)
            {
                Mantenimiento = (from n in AnoVehiculo
                                 select new Entidades.Cotizador.EAnoVehiculo
                                 {
                                     IdTipoCotizador=n.IdTipoCotizador,
                                     IdValorVehiculo=n.IdValorVehiculo,
                                     IdAnoVehiculo=n.IdAnoVehiculo,
                                     AnoVehiculo=n.AnoVehiculo,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE SERVICIOS FIJOS
        //MOSTRAR EL LISTADO DE LOS SERVICIOS FIJOS
        public List<Entidades.Cotizador.EServiciosFijos> BuscaServiciosFijos(decimal? IdServiciosFijos = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Buscar = (from n in ObjData.SP_COTIZADOR_BUSCA_SERVICIOS_FIJOS(IdServiciosFijos)
                          select new Entidades.Cotizador.EServiciosFijos
                          {
                              IdServiciosFijos=n.IdServiciosFijos,
                              Impuesto=n.Impuesto,
                              ImpuestoFijo0=n.ImpuestoFijo0,
                              ImpuestoFijo=n.ImpuestoFijo,
                              CasaConductor=n.CasaConductor,
                              CasaConductorFijo0=n.CasaConductorFijo0,
                              CasaConductorFijo=n.CasaConductorFijo,
                              ServicioGrua=n.ServicioGrua,
                              ServicioGruaFijo0=n.ServicioGruaFijo0,
                              ServicioGruaFijo=n.ServicioGruaFijo,
                              VehiculoRentado=n.VehiculoRentado,
                              VehiculoRentadoFijo0=n.VehiculoRentadoFijo0,
                              VehiculoRentadoFijo=n.VehiculoRentadoFijo,
                              FuturoExequial=n.FuturoExequial,
                              FuturoExequialFijo0=n.FuturoExequialFijo0,
                              FuturoExequialFijo=n.FuturoExequialFijo,
                              AeroAmbulancia=n.AeroAmbulancia,
                              AeroAmbulanciaFijo=n.AeroAmbulanciaFijo,
                              AeroAmbulanciaFijo0=n.AeroAmbulanciaFijo0
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE SERVICIOS FIJOS
        public Entidades.Cotizador.EServiciosFijos MantenimientoServiciosFijos(Entidades.Cotizador.EServiciosFijos Item, string Accion)
        {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Cotizador.EServiciosFijos Mantenimiento = null;

            var ServiciosFijos = ObjData.SP_COTIZADOR_MANTENIMIENTO_SERVICIOS_FIJOS(
                Item.IdServiciosFijos,
                Item.Impuesto,
                Item.ImpuestoFijo0,
                Item.CasaConductor,
                Item.CasaConductorFijo0,
                Item.ServicioGrua,
                Item.ServicioGruaFijo0,
                Item.VehiculoRentado,
                Item.VehiculoRentadoFijo0,
                Item.FuturoExequial,
                Item.FuturoExequialFijo0,
                Item.AeroAmbulancia,
                Item.AeroAmbulanciaFijo0,
                Accion);
            if (ServiciosFijos != null)
            {
                Mantenimiento = (from n in ServiciosFijos
                                 select new Entidades.Cotizador.EServiciosFijos
                                 {
                                     IdServiciosFijos=n.IdServiciosFijos,
                                     Impuesto=n.Impuesto,
                                     ImpuestoFijo0=n.ImpuestoFijo,
                                     CasaConductor=n.CasaConductor,
                                     CasaConductorFijo0=n.CasaConductorFijo,
                                     ServicioGrua=n.ServicioGrua,
                                     ServicioGruaFijo0=n.ServicioGruaFijo,
                                     VehiculoRentado=n.VehiculoRentado,
                                     VehiculoRentadoFijo0=n.VehiculoRentadoFijo
                                     
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE COALICION E INCENDIO Y ROBO
        //LISTADO DE COALICION E INCENDIO Y ROBO
        public List<Entidades.Cotizador.EComprensivoIncendioRobo> BuscaComprensivoIncendioRobo(decimal? IdTipoCotizador = null, decimal? IdValorVehiculo = null, decimal? IdAnoVehiculo = null, decimal? IdComprensivoIncendioRobo = null, string ComprensivoIncendioRobo = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Buscar = (from n in ObjData.SP_COTIZADOR_BUSCA_COMPRENSIVO_INCENDIO_ROBO(IdTipoCotizador, IdValorVehiculo, IdAnoVehiculo, IdComprensivoIncendioRobo, ComprensivoIncendioRobo)
                          select new Entidades.Cotizador.EComprensivoIncendioRobo
                          {
                              IdTipoCotizador=n.IdTipoCotizador,
                              TipoCotizador=n.TipoCotizador,
                              IdValorVehiculo=n.IdValorVehiculo,
                              ValorVehiculo=n.ValorVehiculo,
                              IdAnoVehiculo=n.IdAnoVehiculo,
                              AnoVehiculo=n.AnoVehiculo,
                              IdComprensivoIncendioRobo=n.IdComprensivoIncendioRobo,
                              ComprensivoIncendioRobo=n.ComprensivoIncendioRobo,
                              Estatus=n.Estatus,
                              Estatus0=n.Estatus0
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE COALICION E INCENDIO Y ROBO
        public Entidades.Cotizador.EComprensivoIncendioRobo MantenimientoComprensivoIncendioRobo(Entidades.Cotizador.EComprensivoIncendioRobo Item, string Accion)
        {
            ObjData.CommandTimeout = 999999999;

            Entidades.Cotizador.EComprensivoIncendioRobo Mantenimiento = null;

            var ComprensivoIncendioRobo = ObjData.SP_COTIZADOR_MANTENIMIENTO_COMPRENSIVO_INCENDIO_ROBO(
                Item.IdTipoCotizador,
                Item.IdValorVehiculo,
                Item.IdAnoVehiculo,
                Item.IdComprensivoIncendioRobo,
                Item.ComprensivoIncendioRobo,
                Item.Estatus0,
                Accion);
            if (ComprensivoIncendioRobo != null)
            {
                Mantenimiento = (from n in ComprensivoIncendioRobo
                                 select new Entidades.Cotizador.EComprensivoIncendioRobo
                                 {
                                     IdTipoCotizador=n.IdTipoCotizador,
                                     IdValorVehiculo=n.IdValorVehiculo,
                                     IdAnoVehiculo=n.IdAnoVehiculo,
                                     IdComprensivoIncendioRobo=n.IdComprensivoIncendioRobo,
                                     ComprensivoIncendioRobo=n.ComprensivoIncendioRobo,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE ACCESOS DE LOS TIPOS DE COTIZADOR
        public List<Entidades.Cotizador.EVerificarTipoServicioCotiador> VeriticarAccesos(decimal? IdTipoCotizador = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Buscar = (from n in ObjData.SP_COTIZADOR_VERIFICAR_TIENE_SERICIO_TIPO_COTIZADOR(IdTipoCotizador)
                          select new Entidades.Cotizador.EVerificarTipoServicioCotiador
                          {
                              IdTipoCotizador=n.IdTipoCotizador,
                              TieneServicio=n.TipoCotizador,
                              IdServicio=n.IdServicio,
                              Servicio=n.Servicio,
                              TipoCotizador=n.TipoCotizador,
                              TieneServicio0=n.TieneServicio0
                          }).ToList();
            return Buscar;
        }

#endregion
    }
}
