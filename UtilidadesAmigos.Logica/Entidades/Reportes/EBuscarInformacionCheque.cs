using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Reportes
{
    public class EBuscarInformacionCheque
    {
		public byte Compania { get; set; }

		public string Anulado0 { get; set; }

		public string Anulado { get; set; }

		public byte Sistema { get; set; }

		public byte Sistema1 { get; set; }

		public int Solicitud { get; set; }

		public System.Nullable<byte> TipoSolicitud { get; set; }

		public string DescTipoSolicitud { get; set; }

		public System.Nullable<System.DateTime> FechaSolicitud0 { get; set; }

		public string FechaSolicitud { get; set; }

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

		public string Banco { get; set; }

		public string CuentaBanco { get; set; }

		public System.Nullable<decimal> Valor { get; set; }

		public string Concepto1 { get; set; }

		public string Concepto2 { get; set; }

		public System.Nullable<int> NumeroCheque { get; set; }

		public System.Nullable<System.DateTime> FechaCheque0 { get; set; }

		public string FechaCheque { get; set; }

		public System.Nullable<int> AnoMesConciliado { get; set; }

		public System.Nullable<System.DateTime> FechaConciliado0 { get; set; }

		public string FechaConciliado { get; set; }

		public string UsuarioDigita { get; set; }

		public string UsuarioModifica { get; set; }

		public System.Nullable<System.DateTime> FechaDigita0 { get; set; }

		public string FechaDigita { get; set; }

		public System.Nullable<System.DateTime> FechaModifica0 { get; set; }

		public string FechaModifica { get; set; }

		public System.Nullable<int> Aprobado { get; set; }

		public System.Nullable<System.DateTime> FechaAprobado0 { get; set; }

		public string FechaAprobado { get; set; }

		public string UsuarioCheque { get; set; }

		public string PrimeraFirma { get; set; }

		public string SegundaFirma { get; set; }

		public string UsuarioCancel { get; set; }

		public System.Nullable<byte> Estatus { get; set; }

		public System.Nullable<char> Impresion { get; set; }

		public System.Nullable<int> TipoDoc { get; set; }

		public string DiaCheque { get; set; }

		public string MesCheque { get; set; }

		public System.Nullable<int> AnoCheque { get; set; }
	}
}
