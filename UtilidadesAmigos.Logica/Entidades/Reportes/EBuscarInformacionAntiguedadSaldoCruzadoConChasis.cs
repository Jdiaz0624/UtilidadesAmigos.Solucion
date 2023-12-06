using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscarInformacionAntiguedadSaldoCruzadoConChasis
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string Poliza { get; set; }

        public string Chasis { get; set; }

        public string Origen { get; set; }

        public string EstatusSistema { get; set; }

        public System.Nullable<int> CodigoRamo { get; set; }

        public string Ramo { get; set; }

        public System.Nullable<int> CodigoSubRamo { get; set; }

        public string SubRamo { get; set; }

        public System.Nullable<int> Item { get; set; }

        public string InicioVigencia { get; set; }

        public string FInVigencia { get; set; }

        public System.Nullable<decimal> MontoNeto { get; set; }

        public System.Nullable<int> CodigoSupervisor { get; set; }

        public string NombreSupervisor { get; set; }

        public System.Nullable<int> CodigoIntermediario { get; set; }

        public string NombreIntermediario { get; set; }

        public System.Nullable<decimal> Codigocliente { get; set; }

        public string NombreCliente { get; set; }

        public string NumeroIdentificacionCliente { get; set; }

        public string TelefonoOficinaCliente { get; set; }

        public string TelefonoResidenciaCliente { get; set; }

        public string CelularCliente { get; set; }

        public string FaxCliente { get; set; }

        public System.Nullable<decimal> Facturado { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public System.Nullable<int> CantidadDias { get; set; }

        public System.Nullable<decimal> ValorPorDia { get; set; }

        public string UltimaFechaPago { get; set; }

        public System.Nullable<decimal> MontoUltimoPago { get; set; }

        public string FinCobertura { get; set; }

        public System.Nullable<decimal> @__0_30 { get; set; }

        public System.Nullable<decimal> @__31_60 { get; set; }

        public System.Nullable<decimal> @__61_90 { get; set; }

        public System.Nullable<decimal> @__91_120 { get; set; }

        public System.Nullable<decimal> @__121_150 { get; set; }

        public System.Nullable<decimal> @__151_MAS { get; set; }
    }
}
