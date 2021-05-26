using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionCodigosEmpleadosVolantesPagos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private decimal IdRegistro = 0;
        private decimal CodigoEmpleado = 0;
        private string Nombre = "";
        private string Correo = "";
        private bool EnvioCorreo0 = false;
        private string Accion = "";


        public ProcesarInformacionCodigosEmpleadosVolantesPagos(
            decimal IdRegistroCON,
        decimal CodigoEmpleadoCON,
        string NombreCON,
        string CorreoCON,
        bool EnvioCorreo0CON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            CodigoEmpleado = CodigoEmpleadoCON;
            Nombre = NombreCON;
            Correo = CorreoCON;
            EnvioCorreo0 = EnvioCorreo0CON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo es para modificar los correos y el empleado se le envia volante de pagos.
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos Procesar = new Entidades.Procesos.ECodigoEmpleadosVolantePagos();

            Procesar.IdRegistro = IdRegistro;
            Procesar.CodigoEmpleado = CodigoEmpleado;
            Procesar.Nombre = Nombre;
            Procesar.Correo = Correo;
            Procesar.EnvioCorreo0 = EnvioCorreo0;

            var MAN = ObjData.ModificarCodigosEmpleadosVolantePagos(Procesar, Accion);
        }
    }
}
