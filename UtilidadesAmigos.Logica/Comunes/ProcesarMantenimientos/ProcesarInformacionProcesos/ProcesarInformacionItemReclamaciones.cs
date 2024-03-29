﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionItemReclamaciones
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private decimal Reclamacion = 0;
        private int Secuencia = 0;
        private string IdReclamante = "";
        private int IdTipoReclamacion = 0;
        private DateTime FechaProceso = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionItemReclamaciones(
            decimal ReclamacionCON,
            int SecuenciaCON,
            string IdReclamanteCON,
            int IdTipoReclamacionCON,
            DateTime FechaAdicionaCON,
            string AccionCON)
        {
            Reclamacion = ReclamacionCON;
            Secuencia = SecuenciaCON;
            IdReclamante = IdReclamanteCON;
            IdTipoReclamacion = IdTipoReclamacionCON;
            FechaProceso = FechaAdicionaCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo es para procesar la información de los items de reclamaciones
        /// </summary>
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Procesos.AgregarEditarEliminarItemsReclamos Procesar = new Entidades.Procesos.AgregarEditarEliminarItemsReclamos();

            Procesar.Reclamacion = Reclamacion;
            Procesar.Secuencia = Secuencia;
            Procesar.IdReclamante = IdReclamante;
            Procesar.IdTipoReclamacion = IdTipoReclamacion;
            Procesar.FechaAdiciona = FechaProceso;

            var MAN = ObjData.ProcesarItemsReclamaciones(Procesar, Accion);
        }

        public void ProcesarInformacionItems() {

            UtilidadesAmigos.Logica.Entidades.Procesos.AgregarEditarEliminarItemsReclamos Procesar = new Entidades.Procesos.AgregarEditarEliminarItemsReclamos();

            Procesar.Reclamacion = Reclamacion;
            Procesar.Secuencia = Secuencia;
            Procesar.IdReclamante = IdReclamante;
            Procesar.IdTipoReclamacion = IdTipoReclamacion;
            Procesar.FechaAdiciona = FechaProceso;

            var MAN = ObjData.ProcesarItemsReclamaciones(Procesar, Accion);
        }


    }
}
