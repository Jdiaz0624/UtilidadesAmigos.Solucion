using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class SacarNombreIntermediarioSupervisor
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMantenimientos.LogicaMantenimientos ObjData = new Logica.LogicaMantenimientos.LogicaMantenimientos();

        private string Codigo = "";

        public SacarNombreIntermediarioSupervisor(
            string CodigoCON)
        {
            Codigo = CodigoCON;
        }

        //DECLARAMOS LOS METODOS
        /// <summary>
        /// Este metodo es para sacar el nombre del supervisor mediante el codigo
        /// </summary>
        /// <returns></returns>
        public string SacarNombreSupervisor() {
            string Nombre = "";
            var SacarInformacion = ObjData.BuscaListadoIntermediario(
                null,
                null,
                Codigo,
                null,
                null);
            if (SacarInformacion.Count() < 1) {
                Nombre = "";
            }
            else {
                foreach (var n in SacarInformacion) {
                    Nombre = n.NombreSupervisor;
                }
            }
            return Nombre;
        }

        /// <summary>
        /// Este metodo es para sacar el nombre del intermediario
        /// </summary>
        /// <returns></returns>
        public string SacarNombreIntermediario() {
            string Nombre = "";

            var Buscar = ObjData.BuscaListadoIntermediario(
                Codigo,
                null, null, null, null);
            if (Buscar.Count() < 1) {
                Nombre = "";
            }
            else {
                foreach (var n in Buscar) {
                    Nombre = n.NombreVendedor;
                }
            }
            return Nombre;
        }


    }
}
