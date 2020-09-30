using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class MantenimientoComisionesIntermediarios
    {
        public System.Nullable<byte> Compania { get; set; }

        public System.Nullable<int> Codigo { get; set; }

        public System.Nullable<int> Ramo { get; set; }

        public System.Nullable<int> SubRamo { get; set; }

        public System.Nullable<decimal> PorcientoComision { get; set; }

        public System.Nullable<decimal> PorcientoGastos { get; set; }

        public System.Nullable<decimal> PorcientoNivel1 { get; set; }

        public System.Nullable<decimal> PorcientoNivel2 { get; set; }

        public System.Nullable<System.Guid> Record_Id { get; set; }

        public string Usuario { get; set; }
    }
}
