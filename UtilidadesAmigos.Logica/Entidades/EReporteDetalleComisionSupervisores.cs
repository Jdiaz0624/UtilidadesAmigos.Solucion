﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades
{
    public class EReporteDetalleComisionSupervisores
    {
        public System.Nullable<decimal> IdUsuario { get; set; }

        public string GeneradoPor { get; set; }

        public System.Nullable<System.DateTime> FechaDesde0 { get; set; }

        public string ValidadoDesde { get; set; }

        public System.Nullable<System.DateTime> FechaHasta0 { get; set; }

        public string ValidadoHasta { get; set; }

        public System.Nullable<int> CodigoSupervisor { get; set; }

        public string Supervisor { get; set; }

        public System.Nullable<int> CodigoIntermediario { get; set; }

        public string Intermediario { get; set; }

        public string Poliza { get; set; }

        public System.Nullable<decimal> NumeroFactura { get; set; }

        public System.Nullable<decimal> Valor { get; set; }

        public string Fecha { get; set; }

        public System.Nullable<System.DateTime> Fecha0 { get; set; }

        public System.Nullable<int> CodigoOficina { get; set; }

        public string Oficina { get; set; }

        public string Conepto { get; set; }

        public System.Nullable<decimal> PorcientoComision { get; set; }

        public System.Nullable<decimal> ComisionPagar { get; set; }
    }
}
