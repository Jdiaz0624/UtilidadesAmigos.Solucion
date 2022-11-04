using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.InformacionConsulta
{
    public class ProcesarInformacionComentariosClientesSinPoliza
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaConsulta.LogicaConsulta ObjData = new Logica.LogicaConsulta.LogicaConsulta();

        public decimal NumeroRegistro = 0;
        public decimal CodigoCliente = 0;
        public decimal IdUsuario = 0;
        public DateTime Fecha = DateTime.Now;
        public string Comentario = "";
        public string Accion = "";

        public ProcesarInformacionComentariosClientesSinPoliza(
        decimal NumeroRegistroCON,
        decimal CodigoClienteCON,
        decimal IdUsuarioCON,
        DateTime FechaCON,
        string ComentarioCON,
        string AccionCON)
        {
            NumeroRegistro = NumeroRegistroCON;
            CodigoCliente = CodigoClienteCON;
            IdUsuario = IdUsuarioCON;
            Fecha = FechaCON;
            Comentario = ComentarioCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Consulta.EComentariosProcesoClientesSinPoliza Procesar = new Entidades.Consulta.EComentariosProcesoClientesSinPoliza();

            Procesar.NumeroRegistro = NumeroRegistro;
            Procesar.CodigoCliente = CodigoCliente;
            Procesar.IdUsuario = IdUsuario;
            Procesar.Fecha0 = Fecha;
            Procesar.Comentario = Comentario;

            var MAN = ObjData.ProcesarComentariosClientesSinPolizas(Procesar, Accion);
        }
    }
}
