using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Mantenimientos
{
    public class EProcesarSolicitudCheques
    {
        public System.Nullable<byte> Compania { get; set; }

        public string Anulado { get; set; }

        public System.Nullable<byte> Sistema { get; set; }

        public System.Nullable<int> Solicitud { get; set; }

        public System.Nullable<byte> TipoSolicitud { get; set; }

        public string DescTipoSolicitud { get; set; }

        public System.Nullable<System.DateTime> FechaSolicitud { get; set; }

        public System.Nullable<byte> Sucursal { get; set; }

        public string DescSucursal { get; set; }

        public System.Nullable<byte> Departamento { get; set; }

        public string DescDepto { get; set; }

        public System.Nullable<byte> Seccion { get; set; }

        public string DescSeccion { get; set; }

        public System.Nullable<byte> RNCTipo { get; set; }

        public string RNC { get; set; }

        public System.Nullable<int> CodigoBeneficiario { get; set; }

        public string Beneficiario1 { get; set; }

        public string Beneficiario2 { get; set; }

        public string Endosable { get; set; }

        public System.Nullable<byte> CtaBanco { get; set; }

        public string CuentaBanco { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Concepto1 { get; set; }

        public string Concepto2 { get; set; }

        public System.Nullable<int> NumeroCheque { get; set; }

        public System.Nullable<System.DateTime> FechaCheque { get; set; }

        public System.Nullable<int> AnoMesConciliado { get; set; }

        public System.Nullable<System.DateTime> FechaConciliado { get; set; }

        public string UsuarioDigita { get; set; }

        public string UsuarioModifica { get; set; }

        public System.Nullable<System.DateTime> FechaDigita { get; set; }

        public System.Nullable<System.DateTime> FechaModifica { get; set; }

        public System.Nullable<int> Aprobado { get; set; }

        public System.Nullable<System.DateTime> FechaAprobado { get; set; }

        public string UsuarioCheque { get; set; }

        public string PrimeraFirma { get; set; }

        public string SegundaFirma { get; set; }

        public string UsuarioCancel { get; set; }

        public System.Nullable<byte> Estatus { get; set; }

        public System.Nullable<char> Impresion { get; set; }

        public System.Nullable<int> TipoDoc { get; set; }
    }
}
