using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionComisionesMontosAcumulados
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjData = new Logica.LogicaSistema();

        private int CodigoIntermediario = 0;
        private decimal NumeroRecibo = 0;
        private DateTime FechaRecibo = DateTime.Now;
        private decimal NumeroFacturaAfecta = 0;
        private string Poliza = "";
        private int Ramo = 0;
        private decimal ValorReciboBruto = 0;
        private decimal ValorReciboNeto = 0;
        private decimal PorcientoComision = 0;
        private decimal ComisionGenerada = 0;
        private decimal Retencion = 0;
        private decimal AvanceComision = 0;
        private decimal ALiquidar = 0;
        private bool Estatus = false;
        private int Oficina = 0;
        private string Accion = "";

        public ProcesarInformacionComisionesMontosAcumulados(
        int CodigoIntermediarioCON,
        decimal NumeroReciboCON,
        DateTime FechaReciboCON,
        decimal NumeroFacturaAfectaCON,
        string PolizaCON,
        int RamoCON,
        decimal ValorReciboBrutoCON,
        decimal ValorReciboNetoCON,
        decimal PorcientoComisionCON,
        decimal ComisionGeneradaCON,
        decimal RetencionCON,
        decimal AvanceComisionCON,
        decimal ALiquidarCON,
        bool EstatusCON,
        int OficinaCON,
        string AccionCON)
        {
            CodigoIntermediario = CodigoIntermediarioCON;
            NumeroRecibo = NumeroReciboCON;
            FechaRecibo = FechaReciboCON;
            NumeroFacturaAfecta = NumeroFacturaAfectaCON;
            Poliza = PolizaCON;
            Ramo = RamoCON;
            ValorReciboBruto = ValorReciboBrutoCON;
            ValorReciboNeto = ValorReciboNetoCON;
            PorcientoComision = PorcientoComisionCON;
            ComisionGenerada = ComisionGeneradaCON;
            Retencion = RetencionCON;
            AvanceComision = AvanceComisionCON;
            ALiquidar = ALiquidarCON;
            Estatus = EstatusCON;
            Oficina = OficinaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.EProcesarInformacionComisionesIntermediariosMontosAcumulados Procesar = new Entidades.EProcesarInformacionComisionesIntermediariosMontosAcumulados();

            Procesar.CodigoIntermediario = CodigoIntermediario;
            Procesar.NumeroRecibo = NumeroRecibo;
            Procesar.FechaRecibo = FechaRecibo;
            Procesar.NumeroFacturaAfecta = NumeroFacturaAfecta;
            Procesar.Poliza = Poliza;
            Procesar.Ramo = Ramo;
            Procesar.ValorReciboBruto = ValorReciboBruto;
            Procesar.ValorReciboNeto = ValorReciboNeto;
            Procesar.PorcientoComision = PorcientoComision;
            Procesar.ComisionGenerada = ComisionGenerada;
            Procesar.Retencion = Retencion;
            Procesar.AvanceComision = AvanceComision;
            Procesar.ALiquidar = ALiquidar;
            Procesar.Estatus = Estatus;
            Procesar.Oficina = Oficina;

            var MAN = ObjData.ProcesarInformacionInformacionMontosAcumuladosIntermediario(Procesar, Accion);
        }

    }
}
