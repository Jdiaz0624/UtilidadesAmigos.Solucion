using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.SuperIntendencia
{
    public class ProcesarInformacionPersonasArchivoSuperIntenedencia
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaSuperIntendencia.LogicaSuperIntendencia ObjData = new Logica.LogicaSuperIntendencia.LogicaSuperIntendencia();

        private decimal IdUsuario = 0;
        private string Nombre = "";
        private string NumeroIdentificacion = "";
        private string Chasis = "";
        private string Placa = "";
        private string Accion = "";

        public ProcesarInformacionPersonasArchivoSuperIntenedencia(
            decimal IdUsuarioCON,
            string NombreCON,
            string NumeroIdentificacionCON,
            string ChasisCON,
            string PlacaCON,
            string AccionCON)
        {
            IdUsuario = IdUsuarioCON;
            Nombre = NombreCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            Chasis = ChasisCON;
            Placa = PlacaCON;
            Accion = AccionCON;
        }

        /// <summary>
        /// Este metodo es para mandar la información enviada por el archivo de excel
        /// </summary>
        public void ProcesarInformacion() {
            UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EProcesarArchivoSuperIntendencia Procesar = new Entidades.SuperIntendencia.EProcesarArchivoSuperIntendencia();

            Procesar.IdUsuario = IdUsuario;
            Procesar.Nombre = Nombre;
            Procesar.NumeroIdentificacion = NumeroIdentificacion;
            Procesar.Chasis = Chasis;
            Procesar.Placa = Placa;

            var MAN = ObjData.ProcesarArchivo(Procesar, Accion);
        }

    }
}
