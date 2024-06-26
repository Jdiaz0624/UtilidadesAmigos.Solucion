﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Consulta
{
    public class EClienteSinPolizaResumido
    {
		public string Mes { get; set; }

		public System.Nullable<int> CodigoMes { get; set; }

		public System.Nullable<int> CodigoAno { get; set; }

		public System.Nullable<int> CodigoOficina { get; set; }

		public string Oficina { get; set; }

		public System.Nullable<int> Cantidad { get; set; }

		public string GeneradoPor { get; set; }
	}
}
