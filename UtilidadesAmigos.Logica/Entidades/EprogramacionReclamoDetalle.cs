using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EprogramacionReclamoDetalle
    {
        public string Usuario { get; set; }

        public decimal? Numero { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public System.Nullable<decimal> ValorAjustado { get; set; }

        public System.Nullable<decimal> ValorSalvamento { get; set; }

        public System.Nullable<decimal> ValorAsegurado { get; set; }

        public string Poliza { get; set; }

        public string Fecha { get; set; }

        public string FechaSiniestro { get; set; }

        public string FechaCierre { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public string Concepto { get; set; }

        public int? CodRamo { get; set; }

        public string Ramo { get; set; }

        public int? CodSubramo { get; set; }

        public string SubRamo { get; set; }

        public string InicioVigencia { get; set; }

        public string FinVigencia { get; set; }

        public string TipoVehiculo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Capacidad { get; set; }

        public string Ano { get; set; }

        public string Color { get; set; }

        public string Chasis { get; set; }

        public string Placa { get; set; }

        public string Uso { get; set; }

        public string ValorVehiculo { get; set; }

        public string Fianza { get; set; }

        public string Asegurado { get; set; }

        public string Comentario { get; set; }
    }
}
