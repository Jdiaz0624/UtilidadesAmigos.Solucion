﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EBuscarDetalleIntermediarioComisiones
    {
		public System.Nullable<int> CodigoIntermediario { get; set; }

		public System.Nullable<decimal> NumeroRecibo { get; set; }

		public System.Nullable<System.DateTime> FechaRecibo { get; set; }

		public System.Nullable<decimal> NumeroFacturaAfecta { get; set; }

		public string Poliza { get; set; }

		public System.Nullable<int> Ramo { get; set; }

		public string NombreRamo { get; set; }

		public System.Nullable<decimal> ValorReciboBruto { get; set; }

		public System.Nullable<decimal> ValorReciboNeto { get; set; }

		public System.Nullable<decimal> PorcientoComision { get; set; }

		public System.Nullable<decimal> ComisionGenerada { get; set; }

		public System.Nullable<decimal> Retencion { get; set; }

		public System.Nullable<decimal> AvanceComision { get; set; }

		public System.Nullable<decimal> ALiquidar { get; set; }

		public System.Nullable<bool> Estatus0 { get; set; }

		public string Estatus { get; set; }

		public System.Nullable<int> Oficina { get; set; }

		public string NombreOficina { get; set; }
	}
}
