using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class VariablesPowerBi
    {
        //VARIABLES PARA LA DATA DE PRODUCCION
        public string Supervisor { get; set; }
        public string Intermediario { get; set; }
        public string Mes { get; set; }
        public string Año { get; set; }
        public decimal Facturado { get; set; }
        public decimal FacturadoNeto { get; set; }
        public decimal Cobrado { get; set; }
        public decimal CobradoNeto { get; set; }
        public string Poliza { get; set; }
        public string Ramo { get; set; }
        public decimal Prima { get; set; }
        public decimal ValorAsegurado { get; set; }
        public string ValorFianza { get; set; }
        public decimal ValorVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string AñoVehiculo { get; set; }

        //VARIABLES PARA LA DATA DE RECLAMACION
        public string SupervisorReclamacion { get; set; }
        public string intermediarioReclamacion { get; set; }
        public string MesReclamacion { get; set; }
        public string AnoReclamacion { get; set; }
        public string PolizaReclamacion { get; set; }
        public decimal ReclamacionReclamacion { get; set; }
        public decimal MontoReclamadoReclamacion { get; set; }
        public decimal MontoAjustadoReclamacion { get; set; }
        public string EstatusReclamacion { get; set; }
        public string MarcaReclamacion { get; set; }
        public string ModeloReclamacion { get; set; }
        public string AnovehiculoReclamacion { get; set; }
    }
}
