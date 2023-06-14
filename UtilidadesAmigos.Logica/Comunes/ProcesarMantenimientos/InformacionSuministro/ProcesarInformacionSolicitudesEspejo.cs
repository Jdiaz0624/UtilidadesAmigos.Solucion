using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionSuministro
{
    public class ProcesarInformacionSolicitudesEspejo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuministro.LogicaSuministro ObjData = new Logica.LogicaSuministro.LogicaSuministro();

        private int Secuencial = 0;
        private int IdSucursal = 0;
        private int IdOficina = 0;
        private int IdDepartamento = 0;
        private decimal IdUsuario = 0;
        private decimal CodigoArticulo = 0;
        private string DescripcionArticulo = "";
        private int IdCategoria = 0;
        private int IdUnidadMedida = 0;
        private int Cantidad = 0;
        private DateTime Fecha = DateTime.Now;
        private int IdEstatusSolicitud = 0;
        private string Accion = "";


        public ProcesarInformacionSolicitudesEspejo(
        int SecuencialCON,
        int IdSucursalCON,
        int IdOficinaCON,
        int IdDepartamentoCON,
        decimal IdUsuarioCON,
        decimal CodigoArticuloCON,
        string DescripcionArticuloCON,
        int IdCategoriaCON,
        int IdUnidadMedidaCON,
        int CantidadCON,
        DateTime FechaCON,
        int IdEstatusSolicitudCON,
        string AccionCON)
        {
            Secuencial = SecuencialCON;
            IdSucursal = IdSucursalCON;
            IdOficina = IdOficinaCON;
            IdDepartamento = IdDepartamentoCON;
            IdUsuario = IdUsuarioCON;
            CodigoArticulo = CodigoArticuloCON;
            DescripcionArticulo = DescripcionArticuloCON;
            IdCategoria = IdCategoriaCON;
            IdUnidadMedida = IdUnidadMedidaCON;
            Cantidad = CantidadCON;
            Fecha = FechaCON;
            IdEstatusSolicitud = IdEstatusSolicitudCON;
            Accion = AccionCON;
        }
        /// <summary>
        /// Procesa toda la informacion de las solicitudes espejo
        /// </summary>
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Suministro.ESuministroSolicitudesEspejo Procesar = new Entidades.Suministro.ESuministroSolicitudesEspejo();

            Procesar.Secuencial = Secuencial;
            Procesar.IdSucursal = IdSucursal;
            Procesar.IdOficina = IdOficina;
            Procesar.IdDepartamento = IdDepartamento;
            Procesar.IdUsuario = IdUsuario;
            Procesar.CodigoArticulo = CodigoArticulo;
            Procesar.DescripcionArticulo = DescripcionArticulo;
            Procesar.IdCategoria = IdCategoria;
            Procesar.IdUnidadMedida = IdUnidadMedida;
            Procesar.Cantidad = Cantidad;
            Procesar.Fecha0 = Fecha;
            Procesar.IdEstatusSolicitud = IdEstatusSolicitud;

            var MAN = ObjData.ProcesarSolicitudesEspepejo(Procesar, Accion);
        }
    }
}
