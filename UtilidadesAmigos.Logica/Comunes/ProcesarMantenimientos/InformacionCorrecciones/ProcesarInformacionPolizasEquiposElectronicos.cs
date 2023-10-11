using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionCorrecciones
{
    public class ProcesarInformacionPolizasEquiposElectronicos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaCorrecciones.LogicaCorrecciones ObjData = new Logica.LogicaCorrecciones.LogicaCorrecciones();

        private int Compania = 0;
        private decimal Cotizacion = 0;
        private int Secuencia = 0;
        private int IdEquipo = 0;
        private string Descripcion = "";
        private string Marca = "";
        private string Modelo = "";
        private string Serie = "";
        private decimal ValorAsegurado = 0;
        private decimal ValorReposicion = 0;
        private decimal PorcDeducible = 0;
        private string BaseDeducible = "";
        private decimal MinimoDeducible = 0;
        private decimal PorcPrima = 0;
        private DateTime FechaAdiciona = DateTime.Now;
        private string Accion = "";


        public ProcesarInformacionPolizasEquiposElectronicos(
            int CompaniaCON,
        decimal CotizacionCON,
        int SecuenciaCON,
        int IdEquipoCON,
        string DescripcionCON,
        string MarcaCON,
        string ModeloCON,
        string SerieCON,
        decimal ValorAseguradoCON,
        decimal ValorReposicionCON,
        decimal PorcDeducibleCON,
        string BaseDeducibleCON,
        decimal MinimoDeducibleCON,
        decimal PorcPrimaCON,
        DateTime FechaAdicionaCON,
        string AccionCON)
        {
            Compania = CompaniaCON;
            Cotizacion = CotizacionCON;
            Secuencia = SecuenciaCON;
            IdEquipo = IdEquipoCON;
            Descripcion = DescripcionCON;
            Marca = MarcaCON;
            Modelo = ModeloCON;
            Serie = SerieCON;
            ValorAsegurado = ValorAseguradoCON;
            ValorReposicion = ValorReposicionCON;
            PorcDeducible = PorcDeducibleCON;
            BaseDeducible = BaseDeducibleCON;
            MinimoDeducible = MinimoDeducibleCON;
            PorcPrima = PorcPrimaCON;
            FechaAdiciona = FechaAdicionaCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos Procesar = new Entidades.Correcciones.EInformacionPolizasEquiposElectrinicos();

            Procesar.Compania = Compania;
            Procesar.Cotizacion = Cotizacion;
            Procesar.Secuencia = Secuencia;
            Procesar.IdEquipo = IdEquipo;
            Procesar.Descripcion = Descripcion;
            Procesar.Marca = Marca;
            Procesar.Modelo = Modelo;
            Procesar.Serie = Serie;
            Procesar.ValorAsegurado = ValorAsegurado;
            Procesar.ValorReposicion = ValorReposicion;
            Procesar.PorcDeducible = PorcDeducible;
            Procesar.BaseDeducible = BaseDeducible;
            Procesar.MinimoDeducible = MinimoDeducible;
            Procesar.PorcPrima = PorcPrima;
            Procesar.FechaAdiciona0 = FechaAdiciona;

            var MAn = ObjData.ProcesarEquiposElectrionicos(Procesar, Accion);
        }
    }
}
