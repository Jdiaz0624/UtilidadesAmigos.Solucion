﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Entidades.Procesos
{
    public class EProcesarHistoricoImprsionMarbete
    {
        public System.Nullable<decimal> IdRegistro {get;set;}

        public string Poliza {get;set;}

        public System.Nullable<decimal> Cotizacion {get;set;}

        public System.Nullable<decimal> CodigoCliente {get;set;}

        public System.Nullable<int> Secuencia {get;set;}

        public string NombreCliente {get;set;}

        public string InicioVigencia { get; set; }

        public string FinVigencia { get; set; }

        public string Asegurado {get;set;}

        public string TipoVehiculo {get;set;}

        public string MarcaVehiculo {get;set;}

        public string ModeloVehiculo {get;set;}

        public string Chasis {get;set;}

        public string Placa {get;set;}

        public string Color {get;set;}

        public string uso {get;set;}

        public string Ano {get;set;}

        public string Capacidad {get;set;}

        public System.Nullable<decimal> ValorVehiculo {get;set;}

        public string FianzaJudicial {get;set;}

        public string Vendedor {get;set;}

        public string Grua {get;set;}

        public string AeroAmbulancia {get;set;}

        public string OtrosServicios {get;set;}

        public System.Nullable<System.DateTime> FechaCreado {get;set;}

        public string UsuarioImprime {get;set;}

        public System.Nullable<int> TipoImpresion {get;set;}

        public System.Nullable<int> CantidadImpreso {get;set;}
    }
}
