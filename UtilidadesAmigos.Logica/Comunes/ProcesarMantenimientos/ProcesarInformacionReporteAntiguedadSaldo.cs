using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos
{
    public class ProcesarInformacionReporteAntiguedadSaldo
    {
        private decimal IdUsuario = 0;
        private DateTime FechaCorte = DateTime.Now;
        private string DocumentoFormateado = "";
        private decimal DocumentoFiltro = 0;
        private int Tipo = 0;
        private string DescripcionTipo = "";
        private string Asegurado = "";
        private decimal CodCliente = 0;
        private string FechaFactura = "";
        private string Intermediario = "";
        private int CodIntermediario = 0;
        private string Poliza = "";
        private int CodMoneda = 0;
        private string DescripcionMoneda = "";
        private string Estatus = "";
        private int CodRamo = 0;
        private string InicioVigencia = "";
        private DateTime Inicio = DateTime.Now;
        private string FinVigencia = "";
        private DateTime Fin = DateTime.Now;
        private int CodOficina = 0;
        private string Oficina = "";
        private int dias = 0;
        private decimal Facturado = 0;
        private decimal Cobrado = 0;
        private decimal Balance = 0;
        private decimal Impuesto = 0;
        private decimal PorcientoComision = 0;
        private decimal ValorComision = 0;
        private decimal ComisionPendiente = 0;
        private decimal _0_10 = 0;
        private decimal _0_30 = 0;
        private decimal _31_60 = 0;
        private decimal _61_90 = 0;
        private decimal _91_120 = 0;
        private decimal _121_150 = 0;
        private decimal _151_mas = 0;
        private decimal Total = 0;
        private decimal Diferencia = 0;
        private decimal OrigenTipo = 0;
    }
}
