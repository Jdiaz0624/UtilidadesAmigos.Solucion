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
        private string Accion = "";

        public ProcesarInformacionDetail(
            decimal SecuenciaDetalleCON,
            string NumeroConectorCON,
            decimal CodigoArticuloCON,
            string DescripcionCON,
            int IdMedidaCON,
            int CantidadCON,
            string AccionCON)
        {
            SecuenciaDetalle = SecuenciaDetalleCON;
            NumeroConector = NumeroConectorCON;
            CodigoArticulo = CodigoArticuloCON;
            Descripcion = DescripcionCON;
            IdMedida = IdMedidaCON;
            Cantidad = CantidadCON;
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

            var MAN = ObjData.ProcesarSuministroDetalle(Procesar, Accion);
        }
    }
}
