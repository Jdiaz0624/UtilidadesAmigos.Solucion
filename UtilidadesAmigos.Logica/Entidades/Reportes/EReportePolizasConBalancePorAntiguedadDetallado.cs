using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EReportePolizasConBalancePorAntiguedadDetallado
    {
        public string Poliza { get; set; }

        public string OficinaFiltro { get; set; }

        public string Motores { get; set; }

        public System.Nullable<int> Oficina { get; set; }

        public string NombreOficina { get; set; }

        public System.Nullable<decimal> Cliente { get; set; }

        public string NombreCliente { get; set; }

        public int CodigoSupervisor { get; set; }

        public string NombreSupervisor { get; set; }

        public string Supervisor { get; set; }

        public string Asegurado { get; set; }

        public System.Nullable<int> Vendedor { get; set; }

        public string NombreVendedor { get; set; }

        public string Intermediario { get; set; }

        public System.Nullable<int> CodigoRamo { get; set; }

        public System.Nullable<int> CodigoSubramo { get; set; }
        public string NombreRamo { get; set; }

        public string NombreSubRamo { get; set; }

        public string InicioVigencia { get; set; }

        public string FechaProceso { get; set; }

        public System.Nullable<decimal> ValorAnual { get; set; }

        public System.Nullable<decimal> ValorPorDia { get; set; }

        public System.Nullable<decimal> ValorPagado { get; set; }

        public string CoberturaHasta { get; set; }

        public System.Nullable<int> DiasDiferencia { get; set; }

        public string Estatus { get; set; }

        public decimal Factura { get; set; }

        public System.Nullable<int> Comentarios { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> Cobrado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public System.Nullable<int> CantidadDias { get; set; }
        public string CortadoA { get; set; }

        public string GeneradoPor { get; set; }

        public string TipoReporteGenerado { get; set; }
    }
}
