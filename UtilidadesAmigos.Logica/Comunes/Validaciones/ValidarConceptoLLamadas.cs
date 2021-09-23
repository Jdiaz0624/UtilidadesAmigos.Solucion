using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.Validaciones
{
    public class ValidarConceptoLLamadas
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        private int IdConceptoLlamada = 0;

        public ValidarConceptoLLamadas(
            int IdConceptoLLamadasCON)
        {
            IdConceptoLlamada = IdConceptoLLamadasCON;
        }

        /// <summary>
        /// Este metodo devuelve un resultado de la columna seleccionada
        /// </summary>
        /// <returns></returns>
        public bool ValidarInformacion() {

            bool Resultado = false;

            var BuscarRegistro = ObjData.BuscaCOnceptoLLamadas(
                IdConceptoLlamada,
                null, null);
            foreach (var n in BuscarRegistro) {
                Resultado = (bool)n.AplicaParaAviso0;
            }
            return Resultado;
        }
    }
}
