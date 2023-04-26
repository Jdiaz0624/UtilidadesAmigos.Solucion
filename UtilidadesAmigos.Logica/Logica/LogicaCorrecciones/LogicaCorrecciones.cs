using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaCorrecciones
{
    public class LogicaCorrecciones
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionCorreccionesDataContext ObjData = new Data.Conexiones.LINQ.BDConexionCorreccionesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region ELIMINAR ENDOSOS DE SESION
        /// <summary>
        /// Muestra el listado de los endosos
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso> BuscaEndosos(string Poliza = null, int? Item=null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_ENDOSO_SESION(Poliza, Item)
                           select new UtilidadesAmigos.Logica.Entidades.Correcciones.EEliminarEndoso
                           {
                               Compania=n.Compania,
                               Cotizacion=n.Cotizacion,
                               Poliza=n.Poliza,
                               CodigoRamo=n.CodigoRamo,
                               Ramo=n.Ramo,
                               CodigoSubramo=n.CodigoSubramo,
                               Subramo=n.Subramo,
                               FechaInicioVigencia0=n.FechaInicioVigencia0,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               FechaFinVigencia0=n.FechaFinVigencia0,
                               FechaFinVigencia=n.FechaFinVigencia,
                               Item=n.Item,
                               IdBeneficiario=n.IdBeneficiario,
                               NombreBeneficiario=n.NombreBeneficiario,
                               ValorEndosoCesion=n.ValorEndosoCesion,
                               UsuarioAdiciona=n.UsuarioAdiciona,
                               FechaAdiciona0=n.FechaAdiciona0,
                               Fecha=n.Fecha,
                               Hora=n.Hora
                           }).ToList();
            return Listado;
        
        }
        #endregion
    }
}
