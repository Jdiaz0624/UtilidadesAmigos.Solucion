﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionComentarioGestionCObros
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjDa = new Logica.LogicaConsulta.LogicaConsulta();

        private decimal ID = 0;
        private string Poliza = "";
        private string Comentario = "";
        private decimal IdUsuario = 0;
        private DateTime FechaProceso = DateTime.Now;
        private int IdEstatusLlamada = 0;
        private int IdConceptoLlamada = 0;
        private string FechaFinVigencia = "";
        private string Accion = "";

        public ProcesarInformacionComentarioGestionCObros(
        decimal IDCON,
        string PolizaCON,
        string ComentarioCON,
        decimal IdUsuarioCON,
        DateTime FechaProcesoCON,
        int IdEstatusLlamadaCON,
        int IdConceptoLlamadaCON,
        string FechaFinVigenciaCON,
        string AccionCON)
        {
            ID = IDCON;
            Poliza = PolizaCON;
            Comentario = ComentarioCON;
            IdUsuario = IdUsuarioCON;
            FechaProceso = FechaProcesoCON;
            IdEstatusLlamada = IdEstatusLlamadaCON;
            IdConceptoLlamada = IdConceptoLlamadaCON;
            FechaFinVigencia = FechaFinVigenciaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Consulta.EComentarioGestionCobro Procesar = new Entidades.Consulta.EComentarioGestionCobro();

            Procesar.ID = ID;
            Procesar.Poliza = Poliza;
            Procesar.Comentario = Comentario;
            Procesar.IdUsuario = IdUsuario;
            Procesar.FechaProceso = FechaProceso;
            Procesar.IdEstatusLlamada = IdEstatusLlamada;
            Procesar.IdConceptoLlamada = IdConceptoLlamada;
            Procesar.FechaFinVigencia = FechaFinVigencia;

            var MAN = ObjDa.ProcesarComentarioPolizaGestionCObro(Procesar, Accion);
        }
    }
}
