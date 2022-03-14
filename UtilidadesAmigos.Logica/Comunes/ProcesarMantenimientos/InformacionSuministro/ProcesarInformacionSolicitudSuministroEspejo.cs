using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro
{
    public class ProcesarInformacionSolicitudSuministroEspejo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro ObjData = new Logica.LogicaSuministro.LogicaSuministro();

        private decimal IdUsuario = 0;
        private decimal CodigoArticulo = 0;
        private string Descripcion = "";
        private int IdMedida = 0;
        private int Cantidad = 0;
        private string Accion = "";

        public ProcesarInformacionSolicitudSuministroEspejo(
             decimal IdUsuarioCON,
        decimal CodigoArticuloCON,
        string DescripcionCON,
        int IdMedidaCON,
        int CantidadCON,
        string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            CodigoArticulo = CodigoArticuloCON;
            Descripcion = DescripcionCON;
            IdMedida = IdMedidaCON;
            Cantidad = CantidadCON;
            Accion = AccionCON;

        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroEspejo Procesar = new Entidades.Suministro.ESuministroEspejo();

            Procesar.IdUsuario = IdUsuario;
            Procesar.CodigoArticulo = CodigoArticulo;
            Procesar.Descripcion = Descripcion;
            Procesar.IdMedida = IdMedida;
            Procesar.Cantidad = Cantidad;

            var MAN = ObjData.ProcesarSolicitudEspejo(Procesar, Accion);
        }
    }
}
