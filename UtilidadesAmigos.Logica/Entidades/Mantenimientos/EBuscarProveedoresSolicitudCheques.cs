using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EBuscarProveedoresSolicitudCheques
    {
        public byte? Compania { get; set; }

        public int? Codigo { get; set; }

        public System.Nullable<int> TipoCliente { get; set; }

        public System.Nullable<byte> TipoRnc { get; set; }
        public string RNC { get; set; }

        public string NombreCliente { get; set; }

        public string Direccion { get; set; }

        public System.Nullable<int> Ubicacion { get; set; }

        public System.Nullable<decimal> LimiteCredito { get; set; }

        public System.Nullable<decimal> Descuento { get; set; }

        public System.Nullable<byte> CondicionPago { get; set; }

        public System.Nullable<byte> Estatus { get; set; }

        public System.Nullable<System.DateTime> FechaUltPago { get; set; }

        public System.Nullable<decimal> MontoUltPago { get; set; }

        public System.Nullable<decimal> Balance { get; set; }

        public string UsuarioAdiciona { get; set; }

        public System.Nullable<System.DateTime> FechaAdiciona { get; set; }

        public string FechaCreado { get; set; }

        public string UsuarioModifica { get; set; }

        public System.Nullable<System.DateTime> FechaModifica { get; set; }

        public string FechaModificado { get; set; }

        public System.Nullable<int> CodigoRnc { get; set; }

        public System.Nullable<decimal> PorcComision { get; set; }

        public System.Nullable<int> CodMoneda { get; set; }

        public string TelefonoCasa { get; set; }

        public string TelefonoOficina { get; set; }

        public string Celular { get; set; }

        public string Fax { get; set; }

        public string Beeper { get; set; }

        public string Email { get; set; }

        public System.Nullable<byte> TipoPago { get; set; }

        public System.Nullable<int> Banco { get; set; }

        public string CuentaBanco { get; set; }

        public string Contacto { get; set; }

        public string TipoCuentaBanco { get; set; }

        public string ClaseProveedor { get; set; }
    }
}
