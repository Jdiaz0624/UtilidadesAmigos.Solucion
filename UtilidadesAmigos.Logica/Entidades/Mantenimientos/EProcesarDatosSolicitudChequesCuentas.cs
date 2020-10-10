using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EProcesarDatosSolicitudChequesCuentas
    {
        public System.Nullable<byte> Compania { get; set; }

        public string Anulado { get; set; }

        public System.Nullable<byte> Sistema { get; set; }

        public System.Nullable<int> Solicitud { get; set; }

        public System.Nullable<int> Secuencia { get; set; }

        public string Cuenta { get; set; }

        public System.Nullable<int> Auxiliar { get; set; }

        public string DescCuenta { get; set; }

        public string Origen { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public System.Nullable<int> TipoCompromiso { get; set; }

        public System.Nullable<int> Departamento { get; set; }
    }
}
