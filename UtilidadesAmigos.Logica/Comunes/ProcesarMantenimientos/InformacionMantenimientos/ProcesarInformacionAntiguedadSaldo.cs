using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionMantenimientos
{
    public class ProcesarInformacionAntiguedadSaldo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();


        private decimal IdUsuario = 0;
        private string Poliza = "";
        private decimal Cotizacion = 0;
        private decimal CodigoCliente = 0;
        private int CodigoIntermediario = 0;
        private int CodigoSupervisor = 0;
        private int CodigoOficina = 0;
        private int CodigoMoneda = 0;
        private int CodigoRamo = 0;
        private decimal Valor = 0;
        private decimal NumeroFactura = 0;
        private decimal Balance = 0;
        private int Tipo = 0;
        private DateTime Fecha = DateTime.Now;
        private DateTime FechaCorte = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionAntiguedadSaldo(
            decimal IdUsuarioCON,
        string PolizaCON,
        decimal CotizacionCON,
        decimal CodigoClienteCON,
        int CodigoIntermediarioCON,
        int CodigoSupervisorCON,
        int CodigoOficinaCON,
        int CodigoMonedaCON,
        int CodigoRamoCON,
        decimal ValorCON,
        decimal NumeroFacturaCON,
        decimal BalanceCON,
        int TipoCON,
        DateTime FechaCON,
        DateTime FechaCorteCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Cotizacion = CotizacionCON;
            CodigoCliente = CodigoClienteCON;
            CodigoIntermediario = CodigoIntermediarioCON;
            CodigoSupervisor = CodigoSupervisorCON;
            CodigoOficina = CodigoOficinaCON;
            CodigoMoneda = CodigoMonedaCON;
            CodigoRamo = CodigoRamoCON;
            Valor = ValorCON;
            NumeroFactura = NumeroFacturaCON;
            Balance = BalanceCON;
            Tipo = TipoCON;
            Fecha = FechaCON;
            FechaCorte = FechaCorteCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Mantenimientos.EProcesarInformacionDatosAntiguedadSaldo Procesar = new Entidades.Mantenimientos.EProcesarInformacionDatosAntiguedadSaldo();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Cotizacion = Cotizacion;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.CodigoSupervisor = CodigoSupervisor;
            Procesar.CodigoOficina = CodigoOficina;
            Procesar.CodigoMoneda = CodigoMoneda;
            Procesar.CodigoRamo = CodigoRamo;
            Procesar.Valor = Valor;
            Procesar.NumeroFactura = NumeroFactura;
            Procesar.Balance = Balance;
            Procesar.Tipo = Tipo;
            Procesar.Fecha = Fecha;
            Procesar.FechaCorte = FechaCorte;


            var MAN = ObjData.ProcesarDatosAntiguedadSaldo(Procesar, Accion);
        }
    }
}
