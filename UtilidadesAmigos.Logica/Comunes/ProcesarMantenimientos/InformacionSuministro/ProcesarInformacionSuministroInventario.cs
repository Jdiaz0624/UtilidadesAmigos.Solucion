using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro
{
    public class ProcesarInformacionSuministroInventario
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro Objdata = new Logica.LogicaSuministro.LogicaSuministro();

        private decimal CodigoArticulo = 0;
        private string Articulo = "";
        private int IdMedida = 0;
        private int Stock = 0;
        private decimal IdUsuario = 0;
        private string Accion = "";

        public ProcesarInformacionSuministroInventario(
            decimal CodigoArticuloCON,
            string ArticuloCON,
            int IdMedidaCON,
            int StockCON,
            decimal IdUsuarioCON,
            string AccionCON)
        {
            CodigoArticulo = CodigoArticuloCON;
            Articulo = ArticuloCON;
            IdMedida = IdMedidaCON;
            Stock = StockCON;
            IdUsuario = IdUsuarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventario Procesar = new Entidades.Suministro.ESuministroInventario();

            Procesar.CodigoArticulo = CodigoArticulo;
            Procesar.Articulo = Articulo;
            Procesar.IdMedida = IdMedida;
            Procesar.Stock = Stock;
            Procesar.UsuarioCrea = IdUsuario;
            Procesar.FechaCrea0 = DateTime.Now;
            Procesar.UsuarioModifica = IdUsuario;
            Procesar.FechaModifica0 = DateTime.Now;

            var MAN = Objdata.ProcesarSuministroInventario(Procesar, Accion);
        }
    }
}
