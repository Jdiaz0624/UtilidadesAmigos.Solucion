using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Gerencia
{
    public class ProcesarInformacionPolizasConAtraso
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaGerencia.LogicaGerencia ObjData = new Logica.LogicaGerencia.LogicaGerencia();

        private decimal IdUsuario = 0;
        private string Poliza = "";
        private int Codigo_Intermediario = 0;
        private string Intermediario = "";
        private int Codigo_Supervisor = 0;
        private string Supervisor = "";
        private decimal Codigo = 0;
        private string Cliente = "";
        private string Direccion = "";
        private string Telefonos = "";
        private string Concepto = "";
        private string Fecha_Facturacion = "";
        private string Inicio_Vigencia = "";
        private string Fin_Vigencia = "";
        private string Fecha_Ultimo_Pago = "";
        private int DiasTranscurridos = 0;
        private int Dias_Transcurridos_Pago = 0;
        private decimal Valor_Poliza = 0;
        private decimal Total_Pagado = 0;
        private decimal Balance_Pendiente = 0;
        private int Ramo = 0;
        private int SubRamo = 0;
        private string NombreRamo = "";
        private string NombreSubRamo = "";
        private decimal Inicial = 0;
        private string Inicial_Pagado = "";
        private decimal Cuota = 0;
        private string C1_Pagada = "";
        private decimal C1 = 0;
        private string C2_Pagada = "";
        private decimal C2 = 0;
        private string C3_Pagada = "";
        private decimal C3 = 0;
        private string C4_Pagada = "";
        private decimal C4 = 0;
        private string C5_Pagada = "";
        private decimal C5 = 0;
        private decimal TotalDescuento = 0;
        private string Accion = "";

        public ProcesarInformacionPolizasConAtraso(
            decimal IdUsuarioCON,
        string PolizaCON,
        int Codigo_IntermediarioCON,
        string IntermediarioCON,
        int Codigo_SupervisorCON,
        string SupervisorCON,
        decimal CodigoCON,
        string ClienteCON,
        string DireccionCON,
        string TelefonosCON,
        string ConceptoCON,
        string Fecha_FacturacionCON,
        string Inicio_VigenciaCON,
        string Fin_VigenciaCON,
        string Fecha_Ultimo_PagoCON,
        int DiasTranscurridosCON,
        int Dias_Transcurridos_PagoCON,
        decimal Valor_PolizaCON,
        decimal Total_PagadoCON,
        decimal Balance_PendienteCON,
        int RamoCON,
        int SubRamoCON,
        string NombreRamoCON,
        string NombreSubRamoCON,
        decimal InicialCON,
        string Inicial_PagadoCON,
        decimal CuotaCON,
        string C1_PagadaCON,
        decimal C1CON,
        string C2_PagadaCON,
        decimal C2CON,
        string C3_PagadaCON,
        decimal C3CON,
        string C4_PagadaCON,
        decimal C4CON,
        string C5_PagadaCON,
        decimal C5CON,
        decimal TotalDescuentoCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Poliza = PolizaCON;
            Codigo_Intermediario = Codigo_IntermediarioCON;
            Intermediario = IntermediarioCON;
            Codigo_Supervisor = Codigo_SupervisorCON;
            Supervisor = SupervisorCON;
            Codigo = CodigoCON;
            Cliente = ClienteCON;
            Direccion = DireccionCON;
            Telefonos = TelefonosCON;
            Concepto = ConceptoCON;
            Fecha_Facturacion = Fecha_FacturacionCON;
            Inicio_Vigencia = Inicio_VigenciaCON;
            Fin_Vigencia = Fin_VigenciaCON;
            Fecha_Ultimo_Pago = Fecha_Ultimo_PagoCON;
            DiasTranscurridos = DiasTranscurridosCON;
            Dias_Transcurridos_Pago = Dias_Transcurridos_PagoCON;
            Valor_Poliza = Valor_PolizaCON;
            Total_Pagado = Total_PagadoCON;
            Balance_Pendiente = Balance_PendienteCON;
            Ramo = RamoCON;
            SubRamo = SubRamoCON;
            NombreRamo = NombreRamoCON;
            NombreSubRamo = NombreSubRamoCON;
            Inicial = InicialCON;
            Inicial_Pagado = Inicial_PagadoCON;
            Cuota = CuotaCON;
            C1_Pagada = C1_PagadaCON;
            C1 = C1CON;
            C2_Pagada = C2_PagadaCON;
            C2 = C2CON;
            C3_Pagada = C3_PagadaCON;
            C3 = C3CON;
            C4_Pagada = C4_PagadaCON;
            C4 = C4CON;
            C5_Pagada = C5_PagadaCON;
            C5 = C5CON;
            TotalDescuento = TotalDescuentoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Gerencia.EProcesarInformacionGuardarAntiguedadPorAtraso Procesar = new Entidades.Gerencia.EProcesarInformacionGuardarAntiguedadPorAtraso();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Poliza = Poliza;
            Procesar.Codigo_Intermediario = Codigo_Intermediario;
            Procesar.Intermediario = Intermediario;
            Procesar.Codigo_Supervisor = Codigo_Supervisor;
            Procesar.Supervisor = Supervisor;
            Procesar.Codigo = Codigo;
            Procesar.Cliente = Cliente;
            Procesar.Direccion = Direccion;
            Procesar.Telefonos = Telefonos;
            Procesar.Concepto = Concepto;
            Procesar.Fecha_Facturacion = Fecha_Facturacion;
            Procesar.Inicio_Vigencia = Inicio_Vigencia;
            Procesar.Fin_Vigencia = Fin_Vigencia;
            Procesar.Fecha_Ultimo_Pago = Fecha_Ultimo_Pago;
            Procesar.DiasTranscurridos = DiasTranscurridos;
            Procesar.Dias_Transcurridos_Pago = Dias_Transcurridos_Pago;
            Procesar.Valor_Poliza = Valor_Poliza;
            Procesar.Total_Pagado = Total_Pagado;
            Procesar.Balance_Pendiente = Balance_Pendiente;
            Procesar.Ramo = Ramo;
            Procesar.SubRamo = SubRamo;
            Procesar.NombreRamo = NombreRamo;
            Procesar.NombreSubRamo = NombreSubRamo;
            Procesar.Inicial = Inicial;
            Procesar.Inicial_Pagado = Inicial_Pagado;
            Procesar.Cuota = Cuota;
            Procesar.C1_Pagada = C1_Pagada;
            Procesar.C1 = C1;
            Procesar.C2_Pagada = C2_Pagada;
            Procesar.C2 = C2;
            Procesar.C3_Pagada = C3_Pagada;
            Procesar.C3 = C3;
            Procesar.C4_Pagada = C4_Pagada;
            Procesar.C4 = C4;
            Procesar.C5_Pagada = C5_Pagada;
            Procesar.C5 = C5;
            Procesar.TotalDescuento = TotalDescuento;

            var MAN = ObjData.ProcesarPolizasConAtrasos(Procesar, Accion);
        }
    }
}
