using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionIntermediarioCadenaDetalle
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private int Compania = 0;
        private int IdIntermediario = 0;
        private int IdIntermediarioSupervisa = 0;
        private string UsuarioAdiciona = "";
        private DateTime FechaAdiciona = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionIntermediarioCadenaDetalle(
            int CompaniaCON,
            int IdIntermediarioCON,
            int IdIntermediarioSupervisaCON,
            string UsuarioAdicionaCON,
            DateTime FechaAdicionaCON,
            string AccionCON)
        {
            Compania = CompaniaCON;
            IdIntermediario = IdIntermediarioCON;
            IdIntermediarioSupervisa = IdIntermediarioSupervisaCON;
            UsuarioAdiciona = UsuarioAdicionaCON;
            FechaAdiciona = FechaAdicionaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformaicon() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.ECadenaIntermediarioDetalle Procesar = new Entidades.Mantenimientos.ECadenaIntermediarioDetalle();

            Procesar.Compania = Compania;
            Procesar.IdIntermediario = IdIntermediario;
            Procesar.IdIntermediarioSupervisa = IdIntermediarioSupervisa;
            Procesar.UsuarioAdiciona = UsuarioAdiciona;
            Procesar.FechaAdiciona = FechaAdiciona;

            var MAN = ObjData.MantenimientoIntermediarioCadenaDetalle(Procesar, Accion);
        }
    }
}
