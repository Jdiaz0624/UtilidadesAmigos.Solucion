using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class VariablesGlobales
    {
        #region VARIABLES ALFANUMERICAS
        public string ClaveEncriptada { get; set; }
        public string NombreUsuario { get; set; }
        public string Ramo { get; set; }
        public string Concepto { get; set; }
        public string Accion { get; set; }

        public string ConceptoDetalle { get; set; }
        public string RamoDetalle { get; set; }
        public string TipoDocumento { get; set; }
        public string PolizaDetalle { get; set; }
        #endregion
        #region VARIABLES DECIMALES
        public decimal IdUsuario { get; set; }
        public decimal FacturadoPesos { get; set; }
        public decimal FacturadoDollar { get; set; }
        public decimal FacturadoTotal { get; set; }
        public decimal FacturadoNeto { get; set; }


        #endregion
        #region VARIABLES BOOLEANAS
        public bool EstatusUsuario { get; set; }
        public bool CambiaClave { get; set; }
        public bool ExportarExel { get; set; }
        #endregion
        #region VARIABLES ENTERAS
        public int Total { get; set; } 
        public int IdRamo { get; set; }
        public int ContadorLogin { get; set; }
        #endregion
        #region VARIABLES TIPO DE FECHA
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        #endregion
    }
}
