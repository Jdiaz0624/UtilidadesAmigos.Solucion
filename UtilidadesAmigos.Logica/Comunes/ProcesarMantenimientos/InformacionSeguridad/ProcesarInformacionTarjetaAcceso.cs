using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSeguridad
{
    public class ProcesarInformacionTarjetaAcceso
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSeguridad.LogicaSeguridad ObjData = new Logica.LogicaSeguridad.LogicaSeguridad();

        private decimal IdRegistro = 0;
        private decimal IdOficina = 0;
        private decimal IdDepartamento = 0;
        private string Empleado = "";
        private string NumeroTarjeta = "";
        private string SecuenciaInterna = "";
        private decimal IdEstatus = 0;
        private decimal IdUsuario = 0;
        private string Accion = "";

        public ProcesarInformacionTarjetaAcceso(
            decimal IdRegistroCON,
        decimal IdOficinaCON,
        decimal IdDepartamentoCON,
        string EmpleadoCON,
        string NumeroTarjetaCON,
        string SecuenciaInternaCON,
        decimal IdEstatusCON,
        decimal IdUsuarioCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            IdOficina = IdOficinaCON;
            IdDepartamento = IdDepartamentoCON;
            Empleado = EmpleadoCON;
            NumeroTarjeta = NumeroTarjetaCON;
            SecuenciaInterna = SecuenciaInternaCON;
            IdEstatus = IdEstatusCON;
            IdUsuario = IdUsuarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Seguridad.EControlTarjetasAcceso Procesar = new Entidades.Seguridad.EControlTarjetasAcceso();

            Procesar.IdRegistro = IdRegistro;
            Procesar.IdOficina = IdOficina;
            Procesar.IdDepartamento = IdDepartamento;
            Procesar.Empleado = Empleado;
            Procesar.NumeroTarjeta = NumeroTarjeta;
            Procesar.SecuenciaInterna = SecuenciaInterna;
            Procesar.FechaEntrega0 = DateTime.Now;
            Procesar.IdEstatus = IdEstatus;
            Procesar.IdUsuarioAdiciona = IdUsuario;
            Procesar.FechaAdiciona0 = DateTime.Now;
            Procesar.IdUsuarioModifica = IdUsuario;
            Procesar.FechaModifica0 = DateTime.Now;

            var MAN = ObjData.ProcesarTarjetasAccesp(Procesar, Accion);
        }
    }
}
