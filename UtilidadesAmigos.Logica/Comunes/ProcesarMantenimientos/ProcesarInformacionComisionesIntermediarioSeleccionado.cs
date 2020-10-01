using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionComisionesIntermediarioSeleccionado
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObData = new Logica.LogicaMantenimientos.LogicaMantenimientos();
        //Guid RegistroHuid = new Guid();


        private int Compania = 0;
        private int Codigo = 0;
        private int Ramo = 0;
        private int SubRamo = 0;
        private decimal PorcientoComision = 0;
        private decimal PorcientoGastos = 0;
        private decimal PorcientoNivel1 = 0;
        private decimal PorcientoNivel2 = 0;
        private Guid Record_Id = Guid.NewGuid();
        private string Usuario = "";
        private string Accion = "";

        public ProcesarInformacionComisionesIntermediarioSeleccionado(
        int CompaniaCON,
        int CodigoCON,
        int RamoCON,
        int SubRamoCON,
        decimal PorcientoComisionCON,
        decimal PorcientoGastosCON,
        decimal PorcientoNivel1CON,
        decimal PorcientoNivel2CON,
        Guid Record_IdCON,
        string UsuarioCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Codigo = CodigoCON;
            Ramo = RamoCON;
            SubRamo = SubRamoCON;
            PorcientoComision = PorcientoComisionCON;
            PorcientoGastos = PorcientoGastosCON;
            PorcientoNivel1 = PorcientoNivel1CON;
            PorcientoNivel2 = PorcientoNivel2CON;
            Record_Id = Record_IdCON;
            Usuario = UsuarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.MantenimientoComisionesIntermediarios Procesar = new Entidades.Mantenimientos.MantenimientoComisionesIntermediarios();

            Procesar.Compania = Convert.ToByte(Compania);
            Procesar.Codigo = Codigo;
            Procesar.Ramo = Ramo;
            Procesar.SubRamo = SubRamo;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.PorcientoGastos = PorcientoGastos;
            Procesar.PorcientoNivel1 = PorcientoNivel1;
            Procesar.PorcientoNivel2 = PorcientoNivel2;
            Procesar.Record_Id = Record_Id;
            Procesar.Usuario = Usuario;


            var MAN = ObData.MantenimientoComisionesIntermediario(Procesar, Accion);
        }

    }
}
