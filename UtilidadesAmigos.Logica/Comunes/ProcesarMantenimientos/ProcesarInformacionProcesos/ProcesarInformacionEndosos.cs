using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.ProcesarInformacionProcesos
{
    public class ProcesarInformacionEndosos
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();

        private decimal NumeroRegistro = 0;
        private string Poliza = "";
        private int Secuencia = 0;
        private int Item = 0;
        private string Cliente = "";
        private int TipoRnc = 0;
        private string NumeroRnc = "";
        private string Direccion = "";
        private string TelefonoResidencia = "";
        private string TelefonoOficina = "";
        private string Celular = "";
        private string fax = "";
        private string InicioVigencia = "";
        private string FinVigencia = "";
        private string Estatus = "";
        private string Marca = "";
        private string Modelo = "";
        private string Chasis = "";
        private string Placa = "";
        private string Color = "";
        private int TipoEndoso = 0;
        private string LicenciaExtrajero = "";
        private string NombreConductorUnico = "";
        private string CedulaConductorUnico = "";
        private int TipoGrua = 0;
        private DateTime Fecha = DateTime.Now;
        private decimal IdUsuario = 0;
        private string Accion = "";

        public ProcesarInformacionEndosos(
            decimal NumeroRegistroCON,
            string PolizaCON,
            int SecuenciaCON,
            int ItemCON,
            string ClienteCON,
            int TipoRncCON,
            string NumeroRncCON,
            string DireccionCON,
            string TelefonoResidenciaCON,
            string TelefonoOficinaCON,
            string CelularCON,
            string faxCON,
            string InicioVigenciaCON,
            string FinVigenciaCON,
            string EstatusCON,
            string MarcaCON,
            string ModeloCON,
            string ChasisCON,
            string PlacaCON,
            string ColorCON,
            int TipoEndosoCON,
            string LicenciaExtrajeroCON,
            string NombreConductorUnicoCON,
            string CedulaConductorUnicoCON,
            int TipoGruaCON,
            DateTime FechaCON,
            decimal IdUsuarioCON,
            string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            Poliza = PolizaCON;
            Secuencia = SecuenciaCON;
            Item = ItemCON;
            Cliente = ClienteCON;
            TipoRnc = TipoRncCON;
            NumeroRnc = NumeroRncCON;
            Direccion = DireccionCON;
            TelefonoResidencia = TelefonoResidenciaCON;
            TelefonoOficina = TelefonoOficinaCON;
            Celular = CelularCON;
            fax = faxCON;
            InicioVigencia = InicioVigenciaCON;
            FinVigencia = FinVigenciaCON;
            Estatus = EstatusCON;
            Marca = MarcaCON;
            Modelo = ModeloCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            Color = ColorCON;
            TipoEndoso = TipoEndosoCON;
            LicenciaExtrajero = LicenciaExtrajeroCON;
            NombreConductorUnico = NombreConductorUnicoCON;
            CedulaConductorUnico = CedulaConductorUnicoCON;
            TipoGrua = TipoGruaCON;
            Fecha = FechaCON;
            IdUsuario = IdUsuarioCON;
            Accion = AccionCON;

        }
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.Procesos.EInformacionEndosos Procesar = new Entidades.Procesos.EInformacionEndosos();


            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.Poliza = Poliza;
            Procesar.Secuencia = Secuencia;
            Procesar.Item = Item;
            Procesar.Cliente = Cliente;
            Procesar.TipoRnc = TipoRnc;
            Procesar.NumeroRnc = NumeroRnc;
            Procesar.Direccion = Direccion;
            Procesar.TelefonoResidencia = TelefonoResidencia;
            Procesar.TelefonoOficina = TelefonoOficina;
            Procesar.Celular = Celular;
            Procesar.fax = fax;
            Procesar.InicioVigencia = InicioVigencia;
            Procesar.FinVigencia = FinVigencia;
            Procesar.Estatus = Estatus;
            Procesar.Marca = Marca;
            Procesar.Modelo = Modelo;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;
            Procesar.Color = Color;
            Procesar.CodigoTipoEndoso = TipoEndoso;
            Procesar.LicenciaExtrajero = LicenciaExtrajero;
            Procesar.NombreConductorUnico = NombreConductorUnico;
            Procesar.CedulaConductorUnico = CedulaConductorUnico;
            Procesar.CodigoTipoGrua = TipoGrua;
            Procesar.Fecha0 = Fecha;
            Procesar.IdUsuario = IdUsuario;

            var MAN = ObjData.InformacionEndosos(Procesar, Accion);


        }   
    }       
}           
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
           