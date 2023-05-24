using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro
{
    public class ProcesarInformacionSuministroInventario
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro Objdata = new Logica.LogicaSuministro.LogicaSuministro();

        private decimal IdRegistro = 0;
        private int IdSucursal = 0;
        private int IdOficina = 0;
        private int IdCategoria = 0;
        private int IdUnidadMedida = 0;
        private string Descripcion = "";
        private int Stock = 0;
        private int StockMinimo = 0;
        private string Accion = "";

        public ProcesarInformacionSuministroInventario(
        decimal IdRegistroCON,
        int IdSucursalCON,
        int IdOficinaCON,
        int IdCategoriaCON,
        int IdUnidadMedidaCON,
        string DescripcionCON,
        int StockCON,
        int StockMinimoCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            IdSucursal = IdSucursalCON;
            IdOficina = IdOficinaCON;
            IdCategoria = IdCategoriaCON;
            IdUnidadMedida = IdUnidadMedidaCON;
            Descripcion = DescripcionCON;
            Stock = StockCON;
            StockMinimo = StockMinimoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroInventarioFinal Procesar = new Entidades.Suministro.ESuministroInventarioFinal();

            Procesar.IdRegistro = IdRegistro;
            Procesar.IdSucursal = IdSucursal;
            Procesar.IdOficina = IdOficina;
            Procesar.IdCategoria = IdCategoria;
            Procesar.IdUnidadMedida = IdUnidadMedida;
            Procesar.Articulo = Descripcion;
            Procesar.Stock = Stock;
            Procesar.StockMinimo = StockMinimo;
            Procesar.FechaIngreso0 = DateTime.Now;

            var MAN = Objdata.ProcesarInventario(Procesar, Accion);
        }
    }
}
