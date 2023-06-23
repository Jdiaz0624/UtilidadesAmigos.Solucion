using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro
{
    public class ProcesarInformacionDetail
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro ObjData = new Logica.LogicaSuministro.LogicaSuministro();

        private decimal SecuenciaDetalle = 0;
        private string NumeroConector = "";
        private decimal CodigoArticulo = 0;
        private string Descripcion = "";
        private int IdMedida = 0;
        private int Cantidad = 0;
        private int IdSucursal = 0;
        private int IdOficina = 0;
        private int IdCategoria = 0;
        private int StockMinimo = 0;
        private bool Despachado = false;
        private string Accion = "";

        public ProcesarInformacionDetail(
            decimal SecuenciaDetalleCON,
            string NumeroConectorCON,
            decimal CodigoArticuloCON,
            string DescripcionCON,
            int IdMedidaCON,
            int CantidadCON,
            int IdSucursalCON,
            int IdOficinaCON,
            int IdCategoriaCON,
            int StockMinimoCON,
            bool DespachadoCON,
            string AccionCON)
        {
            SecuenciaDetalle = SecuenciaDetalleCON;
            NumeroConector = NumeroConectorCON;
            CodigoArticulo = CodigoArticuloCON;
            Descripcion = DescripcionCON;
            IdMedida = IdMedidaCON;
            Cantidad = CantidadCON;
            IdSucursal = IdSucursalCON;
            IdOficina = IdOficinaCON;
            IdCategoria = IdCategoriaCON;
            StockMinimo = StockMinimoCON;
            Despachado = DespachadoCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroDetalle Procesar = new Entidades.Suministro.ESuministroDetalle();

            Procesar.SecuenciaDetalle = SecuenciaDetalle;
            Procesar.NumeroConector = NumeroConector;
            Procesar.CodigoArticulo = CodigoArticulo;
            Procesar.Descripcion = Descripcion;
            Procesar.IdMedida = IdMedida;
            Procesar.Cantidad = Cantidad;
            Procesar.IdSucursal = IdSucursal;
            Procesar.IdOficina = IdOficina;
            Procesar.IdCategoria = IdCategoria;
            Procesar.StockMinimo = StockMinimo;
            Procesar.Despachado = Despachado;

            var MAN = ObjData.ProcesarSuministroDetalle(Procesar, Accion);
        }
    }
}
