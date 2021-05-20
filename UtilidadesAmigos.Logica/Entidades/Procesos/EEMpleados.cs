using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EEMpleados
    {
		public int? CodigoEmpleado {get;set;}

		public string Nombre {get;set;}

		public System.Nullable<byte> Sucursal {get;set;}

		public string DescSucursal {get;set;}

		public System.Nullable<byte> Departamento {get;set;}

		public string DescDepto {get;set;}

		public System.Nullable<int> Cargo {get;set;}

		public string DescCargo {get;set;}

		public string Cedula {get;set;}

		public string Direccion {get;set;}

		public System.Nullable<System.DateTime> FechaIngreso0 {get;set;}

		public string FechaIngreso {get;set;}

		public string Email {get;set;}

		public string Email1 {get;set;}

		public string Email2 {get;set;}

		public string Estatus0 {get;set;}

		public string Estatus {get;set;}
	}
}
