using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones
{
    public class ProcesarInformacionEliminarEndosos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones ObjData = new Logica.LogicaCorrecciones.LogicaCorrecciones();

        private byte Compania = 0;
        private decimal Cotizacion = 0;
        private int Secuencia = 0;
        private int IdBeneficiario = 0;
        private string NombreBeneficiario = "";
        private decimal ValorEndosoCesion = 0;
        private string UsuarioAdiciona = "";
        private DateTime FechaAdiciona = DateTime.Now;
        private string Accion = "";

        public ProcesarInformacionEliminarEndosos(
        byte CompaniaCON,
        decimal CotizacionCON,
        int SecuenciaCON,
        int IdBeneficiarioCON,
        string NombreBeneficiarioCON,
        decimal ValorEndosoCesionCON,
        string UsuarioAdicionaCON,
        DateTime FechaAdicionaCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Cotizacion = CotizacionCON;
            Secuencia = SecuenciaCON;
            IdBeneficiario = IdBeneficiarioCON;
            NombreBeneficiario = NombreBeneficiarioCON;
            ValorEndosoCesion = ValorEndosoCesionCON;
            UsuarioAdiciona = UsuarioAdicionaCON;
            FechaAdiciona = FechaAdicionaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso Procesar = new Entidades.Correcciones.EEliminarEndoso();

            Procesar.Compania = Compania;
            Procesar.Cotizacion = Cotizacion;
            Procesar.Item = Secuencia;
            Procesar.IdBeneficiario = IdBeneficiario;
            Procesar.NombreBeneficiario = NombreBeneficiario;
            Procesar.ValorEndosoCesion = ValorEndosoCesion;
            Procesar.UsuarioAdiciona = UsuarioAdiciona;
            Procesar.FechaAdiciona0 = FechaAdiciona;

            var MAN = ObjData.ProcesarEliminarEndosos(Procesar, Accion);
        }

    }
}
