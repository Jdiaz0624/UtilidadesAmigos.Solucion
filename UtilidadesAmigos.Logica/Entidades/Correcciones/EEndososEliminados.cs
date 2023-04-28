using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Correcciones
{
    public class EEndososEliminados
    {
        public decimal? IdRegistro {get;set;}

        public System.Nullable<byte> Compania {get;set;}

        public string Poliza {get;set;}

        public System.Nullable<decimal> Cotizacion {get;set;}

        public System.Nullable<int> Secuencia {get;set;}

        public System.Nullable<int> IdBeneficiario {get;set;}

        public string NombreBeneficiario {get;set;}

        public System.Nullable<decimal> ValorEndosoCesion {get;set;}

        public string UsuarioAdiciona {get;set;}

        public System.Nullable<System.DateTime> FechaAdiciona {get;set;}

        public System.Nullable<decimal> UsuarioElimina {get;set;}
        public string EliminadoPor { get; set; }

        public System.Nullable<System.DateTime> FechaProcesoElimina0 {get;set;}

        public string FechaProcesoElimina {get;set;}

        public string HoraProcesoElimina {get;set;}

        public System.Nullable<bool> Estatus0 {get;set;}

        public string Estatus {get;set;}
    }
}
