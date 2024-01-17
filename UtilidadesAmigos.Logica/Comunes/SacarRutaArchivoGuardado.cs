using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class SacarRutaArchivoGuardado
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaProcesos.LogicaProcesos ObjData = new Logica.LogicaProcesos.LogicaProcesos();


        private int IdRutaArchivo = 0;

        public SacarRutaArchivoGuardado(int IdRutaArchivoCON) {

            IdRutaArchivo = IdRutaArchivoCON;
        }
        public string SacarRuta() {

            string Ruta = "";

            var Informacion = ObjData.SacarRutaArchivosGuardados(IdRutaArchivo);
            foreach (var n in Informacion) {

                Ruta = n.Ruta;
            }
            return Ruta;
        }
    }
}
