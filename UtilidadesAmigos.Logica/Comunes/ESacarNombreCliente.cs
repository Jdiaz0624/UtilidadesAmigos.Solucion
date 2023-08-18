using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class ESacarNombreCliente
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSistema ObjDataSistema = new Logica.LogicaSistema();

        private string CodigoColiente = "";

        public ESacarNombreCliente(string CodigoColienteCON) {
            CodigoColiente = CodigoColienteCON;
        }

        public string SacarCodigoCLiente() {
            string NombreCliente = "";

            var SacarNombre = ObjDataSistema.SacarNombreCliente(CodigoColiente);
            if (SacarNombre.Count() < 1) {
                NombreCliente = "CLIENTE NO VALIDO";
            }
            else {
                foreach (var n in SacarNombre)
                {
                    NombreCliente = n.Cliente;
                }
            }
            return NombreCliente;
        }

    
    }
}
