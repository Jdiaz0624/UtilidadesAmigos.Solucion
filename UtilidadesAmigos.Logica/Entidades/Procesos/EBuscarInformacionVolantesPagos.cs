using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EBuscarInformacionVolantesPagos
    {
		public int? CodEmpleado {get;set;}

		public int? Ano {get;set;}

		public byte? Mes {get;set;}

		public string NombreMes {get;set;}

		public int? TipoMovimiento {get;set;}

		public string DescTipoMovimiento {get;set;}

		public byte? TipoNomina {get;set;}

		public string DescTipoNomina {get;set;}

		public int NoPago {get;set;}

		public System.Nullable<byte> Sucursal {get;set;}

		public string DescSucursal {get;set;}

		public System.Nullable<byte> Departamento {get;set;}

		public string DescDepto {get;set;}

		public string NombreEmpleado {get;set;}

		public string Origen {get;set;}

		public System.Nullable<decimal> Valor {get;set;}

		public System.Nullable<decimal> Ingresos {get;set;}

		public System.Nullable<decimal> Deducciones {get;set;}

		public System.Nullable<decimal> TotalIngreso {get;set;}

		public System.Nullable<decimal> TotalDeducciones {get;set;}

		public System.Nullable<decimal> Total {get;set;}
	}
}
