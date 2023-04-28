using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones
{
    public class ProcesarInformacionEndososEliminados 
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones ObjData = new Logica.LogicaCorrecciones.LogicaCorrecciones();

        private decimal IdRegistro = 0;
        private byte Compania = 0;
        private decimal Cotizacion = 0;
        private int Secuencia = 0;
        private int IdBeneficiario = 0;
        private string NombreBeneficiario = "";
        private decimal ValorEndosoCesion = 0;
        private string UsuarioAdiciona = "";
        private DateTime FechaAdiciona = DateTime.Now;
        private decimal UsuarioElimina = 0;
        private DateTime FechaProcesoElimina = DateTime.Now;
        private bool Estatus = false;
        private string Accion = "";

        public ProcesarInformacionEndososEliminados(
        decimal IdRegistroCON,
        byte CompaniaCON,
        decimal CotizacionCON,
        int SecuenciaCON,
        int IdBeneficiarioCON,
        string NombreBeneficiarioCON,
        decimal ValorEndosoCesionCON,
        string UsuarioAdicionaCON,
        DateTime FechaAdicionaCON,
        decimal UsuarioEliminaCON,
        DateTime FechaProcesoEliminaCON,
        bool EstatusCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            Compania = CompaniaCON;
            Cotizacion = CotizacionCON;
            Secuencia = SecuenciaCON;
            IdBeneficiario = IdBeneficiarioCON;
            NombreBeneficiario = NombreBeneficiarioCON;
            ValorEndosoCesion = ValorEndosoCesionCON;
            UsuarioAdiciona = UsuarioAdicionaCON;
            FechaAdiciona = FechaAdicionaCON;
            UsuarioElimina = UsuarioEliminaCON;
            FechaProcesoElimina = FechaProcesoEliminaCON;
            Estatus = EstatusCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Correcciones.EEndososEliminados Procesar = new Entidades.Correcciones.EEndososEliminados();

            Procesar.IdRegistro = IdRegistro;
            Procesar.Compania = Compania;
            Procesar.Cotizacion = Cotizacion;
            Procesar.Secuencia = Secuencia;
            Procesar.IdBeneficiario = IdBeneficiario;
            Procesar.NombreBeneficiario = NombreBeneficiario;
            Procesar.ValorEndosoCesion = ValorEndosoCesion;
            Procesar.UsuarioAdiciona = UsuarioAdiciona;
            Procesar.FechaAdiciona = FechaAdiciona;
            Procesar.UsuarioElimina = UsuarioElimina;
            Procesar.FechaProcesoElimina0 = FechaProcesoElimina;
            Procesar.Estatus0 = Estatus;

            var MAN = ObjData.ProcesarEndosoEliminados(Procesar, Accion);

        }
    }
}
