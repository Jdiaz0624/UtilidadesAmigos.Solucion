using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EHistoricoImpresionResumido
    {
        public System.Nullable<decimal> IdUsuario { get; set; }
        public System.Nullable<decimal> IdRegistro { get; set; }

        public string UsuarioImprime { get; set; }

        public string TipoImprecion { get; set; }

        public System.Nullable<int> CantidadImpresion { get; set; }

        public System.Nullable<int> CantidadPVC { get; set; }

        public System.Nullable<int> CantidadHoja { get; set; }

        public System.Nullable<int> TotalImpresiones { get; set; }

        public System.Nullable<int> CantidadMovimientos { get; set; }
    }
}
