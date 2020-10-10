using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionSolicitudCuentas
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private int Compania = 0;
        private string Anulado = "";
        private int Sistema = 0;
        private int Solicitud = 0;
        private int Secuencia = 0;
        private string Cuenta = "";
        private int Auxiliar = 0;
        private string DescCuenta = "";
        private string Origen = "";
        private decimal Valor = 0;
        private int TipoCompromiso = 0;
        private int Departamento = 0;
        private DateTime FechaDesde = DateTime.Now;
        private DateTime FechaHasta = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionSolicitudCuentas(
        int CompaniaCON,
        string AnuladoCON,
        int SistemaCON,
        int SolicitudCON,
        int SecuenciaCON,
        string CuentaCON,
        int AuxiliarCON,
        string DescCuentaCON,
        string OrigenCON,
        decimal ValorCON,
        int TipoCompromisoCON,
        int DepartamentoCON,
        DateTime FechaDesdeCON,
        DateTime FechaHastaCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Anulado = AnuladoCON;
            Sistema = SistemaCON;
            Solicitud = SolicitudCON;
            Secuencia = SecuenciaCON;
            Cuenta = CuentaCON;
            Auxiliar = AuxiliarCON;
            DescCuenta = DescCuentaCON;
            Origen = OrigenCON;
            Valor = ValorCON;
            TipoCompromiso = TipoCompromisoCON;
            Departamento = DepartamentoCON;
            FechaDesde = FechaDesdeCON;
            FechaHasta = FechaHastaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarDatosSolicitudChequesCuentas Procesar = new Entidades.Mantenimientos.EProcesarDatosSolicitudChequesCuentas();

            Procesar.Compania = Convert.ToByte(Compania);
            Procesar.Anulado = Anulado;
            Procesar.Sistema = Convert.ToByte(Sistema);
            Procesar.Solicitud = Solicitud;
            Procesar.Secuencia = Secuencia;
            Procesar.Cuenta = Cuenta;
            Procesar.Auxiliar = Auxiliar;
            Procesar.DescCuenta = DescCuenta;
            Procesar.Origen = Origen;
            Procesar.Valor = Valor;
            Procesar.TipoCompromiso = TipoCompromiso;
            Procesar.Departamento = Departamento;

            var MAN = ObjData.ProcesarDatosSolicitudCuentas(Procesar, FechaDesde, FechaHasta, Accion);
        }
    }
}
