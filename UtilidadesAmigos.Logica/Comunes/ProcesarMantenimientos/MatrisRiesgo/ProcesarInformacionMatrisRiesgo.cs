using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.MatrisRiesgo
{
    public class ProcesarInformacionMatrisRiesgo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaMatrisRiesgo.LogicaMatrisRiesgo ObjData = new Logica.LogicaMatrisRiesgo.LogicaMatrisRiesgo();

        private decimal IdRegistro = 0;
        private int IdOficina = 0;
        private decimal IdUsuario = 0;
        private DateTime Fecha = DateTime.Now;
        private string Nombres = "";
        private int IdTipoIdentificacion = 0;
        private string NumeroIdentificacion = "";
        private int IdProducto = 0;
        private int IdProductoNivel = 0;
        private int IdSubProducto = 0;
        private int IdSUbProductoNivel = 0;
        private int IdCanalDistribucion = 0;
        private int IdCanalDistribucionNivel = 0;
        private int IdPaisResidencia = 0;
        private int IdPaisResidenciaNivel = 0;
        private int IdPaisProcedencia = 0;
        private int IdPaisProcedenciaNivel = 0;
        private int IdProvincia = 0;
        private int IdProvinciaNivel = 0;
        private int IdMontoRiesgo = 0;
        private int IdMontoRIesgoNivel = 0;
        private int IdActividadEconomica = 0;
        private int IdActivicadEconomicaNivel = 0;
        private int IdPromedioIngresoAnual = 0;
        private int IdPromedioIngresoAnualNivel = 0;
        private int IdPEP = 0;
        private int IDPEPNivel = 0;
        private int IdPrimaAnual = 0;
        private int IdPrimaAnualNivel = 0;
        private int IdTipoMonitoreo = 0;
        private int IdTipoDebidaDiligencia = 0;
        private string Observaciones = "";
        private string Accion = "";

        public ProcesarInformacionMatrisRiesgo(
            decimal IdRegistroCON,
        int IdOficinaCON,
        decimal IdUsuarioCON,
        DateTime FechaCON,
        string NombresCON,
        int IdTipoIdentificacionCON,
        string NumeroIdentificacionCON,
        int IdProductoCON,
        int IdProductoNivelCON,
        int IdSubProductoCON,
        int IdSUbProductoNivelCON,
        int IdCanalDistribucionCON,
        int IdCanalDistribucionNivelCON,
        int IdPaisResidenciaCON,
        int IdPaisResidenciaNivelCON,
        int IdPaisProcedenciaCON,
        int IdPaisProcedenciaNivelCON,
        int IdProvinciaCON,
        int IdProvinciaNivelCON,
        int IdMontoRiesgoCON,
        int IdMontoRIesgoNivelCON,
        int IdActividadEconomicaCON,
        int IdActivicadEconomicaNivelCON,
        int IdPromedioIngresoAnualCON,
        int IdPromedioIngresoAnualNivelCON,
        int IdPEPCON,
        int IDPEPNivelCON,
        int IdPrimaAnualCON,
        int IdPrimaAnualNivelCON,
        int IdTipoMonitoreoCON,
        int IdTipoDebidaDiligenciaCON,
        string ObservacionesCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            IdOficina = IdOficinaCON;
            IdUsuario = IdUsuarioCON;
            Fecha = FechaCON;
            Nombres = NombresCON;
            IdTipoIdentificacion = IdTipoIdentificacionCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            IdProducto = IdProductoCON;
            IdProductoNivel = IdProductoNivelCON;
            IdSubProducto = IdSubProductoCON;
            IdSUbProductoNivel = IdSUbProductoNivelCON;
            IdCanalDistribucion = IdCanalDistribucionCON;
            IdCanalDistribucionNivel = IdCanalDistribucionNivelCON;
            IdPaisResidencia = IdPaisResidenciaCON;
            IdPaisResidenciaNivel = IdPaisResidenciaNivelCON;
            IdPaisProcedencia = IdPaisProcedenciaCON;
            IdPaisProcedenciaNivel = IdPaisProcedenciaNivelCON;
            IdProvincia = IdProvinciaCON;
            IdProvinciaNivel = IdProvinciaNivelCON;
            IdMontoRiesgo = IdMontoRiesgoCON;
            IdMontoRIesgoNivel = IdMontoRIesgoNivelCON;
            IdActividadEconomica = IdActividadEconomicaCON;
            IdActivicadEconomicaNivel = IdActivicadEconomicaNivelCON;
            IdPromedioIngresoAnual = IdPromedioIngresoAnualCON;
            IdPromedioIngresoAnualNivel = IdPromedioIngresoAnualNivelCON;
            IdPEP = IdPEPCON;
            IDPEPNivel = IDPEPNivelCON;
            IdPrimaAnual = IdPrimaAnualCON;
            IdPrimaAnualNivel = IdPrimaAnualNivelCON;
            IdTipoMonitoreo = IdTipoMonitoreoCON;
            IdTipoDebidaDiligencia = IdTipoDebidaDiligenciaCON;
            Observaciones = ObservacionesCON;
            Accion = AccionCON;
        }

        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.MatrizRiesgo.EMatrisRiesgo Procesar = new Entidades.MatrizRiesgo.EMatrisRiesgo();

            Procesar.IdRegistro = IdRegistro;
            Procesar.IdOficina = IdOficina;
            Procesar.IdUsuario = IdUsuario;
            Procesar.Fecha = Fecha;
            Procesar.Nombres = Nombres;
            Procesar.IdTipoIdentificacion = IdTipoIdentificacion;
            Procesar.NumeroIdentificacion = NumeroIdentificacion;
            Procesar.IdProducto = IdProducto;
            Procesar.IdProductoNivel = IdProductoNivel;
            Procesar.IdSubProducto = IdSubProducto;
            Procesar.IdSUbProductoNivel = IdSUbProductoNivel;
            Procesar.IdCanalDistribucion = IdCanalDistribucion;
            Procesar.IdCanalDistribucionNivel = IdCanalDistribucionNivel;
            Procesar.IdPaisResidencia = IdPaisResidencia;
            Procesar.IdPaisResidenciaNivel = IdPaisResidenciaNivel;
            Procesar.IdPaisProcedencia = IdPaisProcedencia;
            Procesar.IdPaisProcedenciaNivel = IdPaisProcedenciaNivel;
            Procesar.IdProvincia = IdProvincia;
            Procesar.IdProvinciaNivel = IdProvinciaNivel;
            Procesar.IdMontoRiesgo = IdMontoRiesgo;
            Procesar.IdMontoRIesgoNivel = IdMontoRIesgoNivel;
            Procesar.IdActividadEconomica = IdActividadEconomica;
            Procesar.IdActivicadEconomicaNivel = IdActivicadEconomicaNivel;
            Procesar.IdPromedioIngresoAnual = IdPromedioIngresoAnual;
            Procesar.IdPromedioIngresoAnualNivel = IdPromedioIngresoAnualNivel;
            Procesar.IdPEP = IdPEP;
            Procesar.IDPEPNivel = IDPEPNivel;
            Procesar.IdPrimaAnual = IdPrimaAnual;
            Procesar.IdPrimaAnualNivel = IdPrimaAnualNivel;
            Procesar.IdTipoMonitoreo = IdTipoMonitoreo;
            Procesar.IdTipoDebidaDiligencia = IdTipoDebidaDiligencia;
            Procesar.Observaciones = Observaciones;

            var MAN = ObjData.ProcesarMatrisRiesgo(Procesar, Accion);

        }
    }
}
