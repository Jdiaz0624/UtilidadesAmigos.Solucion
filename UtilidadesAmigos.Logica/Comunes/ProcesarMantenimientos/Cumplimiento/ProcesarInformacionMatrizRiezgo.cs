using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes.ProcesarMantenimientos.Cumplimiento
{
    public class ProcesarInformacionMatrizRiezgo
    {
        readonly UtilidadesAmigos.Logica.Logica.LogicaCumplimiento.LogicaCumplimiento ObjData = new Logica.LogicaCumplimiento.LogicaCumplimiento();

        private decimal IdRegistro = 0;
        private DateTime FechaCreado = DateTime.Now;
        private decimal IdUsuario = 0;
        private string Nombre = "";
        private int IdTipoIdentificacion = 0;
        private string NumeroIdentificacion = "";
        private int IdTipoTercero = 0;
        private int IdNivel_Riesgo_TipoTercero = 0;
        private int IdArea = 0;
        private int IdNivel_Riesgo_Area = 0;
        private int IdPosicion = 0;
        private int IdNivel_Riesgo_Posicion = 0;
        private int IdNivelAcademico = 0;
        private int IdNivel_Riesgo_NivelAcademico = 0;
        private int IdPaisProcedencia = 0;
        private int IdNivel_Riesgo_PaisProcedencia = 0;
        private int IdPaisResidencia = 0;
        private int IdNivel_Riesgo_PaisResidencia = 0;
        private int IdProvincia = 0;
        private int IdNivel_Riesgo_Provincia = 0;
        private int IdSalarioDevengado = 0;
        private int IdNivel_Riesgo_SalarioDevengado = 0;
        private string ActividadSegundaria = "";
        private int IdNivel_Riesgo_ActividadSegundaria = 0;
        private decimal IngresosAdicionales = 0;
        private int IdNivel_Riesgo_IngresosAdicionales = 0;
        private int IdPEP = 0;
        private int IdNivel_Riesgo_PEP = 0;
        private decimal PrimaAnual = 0;
        private int IdNivel_Riesgo_PrimaAnual = 0;
        private int IdTipoMonitoreo = 0;
        private int IdTipoDebidaDiligencia = 0;
        private int IdNivel_Riesgo_Consolidado = 0;
        private string Observaciones = "";
        private string Accion = "";

        public ProcesarInformacionMatrizRiezgo(
        decimal IdRegistroCON,
        DateTime FechaCreadoCON,
        decimal IdUsuarioCON,
        string NombreCON,
        int IdTipoIdentificacionCON,
        string NumeroIdentificacionCON,
        int IdTipoTerceroCON,
        int IdNivel_Riesgo_TipoTerceroCON,
        int IdAreaCON,
        int IdNivel_Riesgo_AreaCON,
        int IdPosicionCON,
        int IdNivel_Riesgo_PosicionCON,
        int IdNivelAcademicoCON,
        int IdNivel_Riesgo_NivelAcademicoCON,
        int IdPaisProcedenciaCON,
        int IdNivel_Riesgo_PaisProcedenciaCON,
        int IdPaisResidenciaCON,
        int IdNivel_Riesgo_PaisResidenciaCON,
        int IdProvinciaCON,
        int IdNivel_Riesgo_ProvinciaCON,
        int IdSalarioDevengadoCON,
        int IdNivel_Riesgo_SalarioDevengadoCON,
        string ActividadSegundariaCON,
        int IdNivel_Riesgo_ActividadSegundariaCON,
        decimal IngresosAdicionalesCON,
        int IdNivel_Riesgo_IngresosAdicionalesCON,
        int IdPEPCON,
        int IdNivel_Riesgo_PEPCON,
        decimal PrimaAnualCON,
        int IdNivel_Riesgo_PrimaAnualCON,
        int IdTipoMonitoreoCON,
        int IdTipoDebidaDiligenciaCON,
        int IdNivel_Riesgo_ConsolidadoCON,
        string ObservacionesCON,
        string AccionCON)
        {
            IdRegistro = IdRegistroCON;
            FechaCreado = FechaCreadoCON;
            IdUsuario = IdUsuarioCON;
            Nombre = NombreCON;
            IdTipoIdentificacion = IdTipoIdentificacionCON;
            NumeroIdentificacion = NumeroIdentificacionCON;
            IdTipoTercero = IdTipoTerceroCON;
            IdNivel_Riesgo_TipoTercero = IdNivel_Riesgo_TipoTerceroCON;
            IdArea = IdAreaCON;
            IdNivel_Riesgo_Area = IdNivel_Riesgo_AreaCON;
            IdPosicion = IdPosicionCON;
            IdNivel_Riesgo_Posicion = IdNivel_Riesgo_PosicionCON;
            IdNivelAcademico = IdNivelAcademicoCON;
            IdNivel_Riesgo_NivelAcademico = IdNivel_Riesgo_NivelAcademicoCON;
            IdPaisProcedencia = IdPaisProcedenciaCON;
            IdNivel_Riesgo_PaisProcedencia = IdNivel_Riesgo_PaisProcedenciaCON;
            IdPaisResidencia = IdPaisResidenciaCON;
            IdNivel_Riesgo_PaisResidencia = IdNivel_Riesgo_PaisResidenciaCON;
            IdProvincia = IdProvinciaCON;
            IdNivel_Riesgo_Provincia = IdNivel_Riesgo_ProvinciaCON;
            IdSalarioDevengado = IdSalarioDevengadoCON;
            IdNivel_Riesgo_SalarioDevengado = IdNivel_Riesgo_SalarioDevengadoCON;
            ActividadSegundaria = ActividadSegundariaCON;
            IdNivel_Riesgo_ActividadSegundaria = IdNivel_Riesgo_ActividadSegundariaCON;
            IngresosAdicionales = IngresosAdicionalesCON;
            IdNivel_Riesgo_IngresosAdicionales = IdNivel_Riesgo_IngresosAdicionalesCON;
            IdPEP = IdPEPCON;
            IdNivel_Riesgo_PEP = IdNivel_Riesgo_PEPCON;
            PrimaAnual = PrimaAnualCON;
            IdNivel_Riesgo_PrimaAnual = IdNivel_Riesgo_PrimaAnualCON;
            IdTipoMonitoreo = IdTipoMonitoreoCON;
            IdTipoDebidaDiligencia = IdTipoDebidaDiligenciaCON;
            IdNivel_Riesgo_Consolidado = IdNivel_Riesgo_ConsolidadoCON;
            Observaciones = ObservacionesCON;
            Accion = AccionCON;
        }
        public void ProcesarInformacion() {

            UtilidadesAmigos.Logica.Entidades.Cumplimiento.EMatrizRiezgo Procesar = new Entidades.Cumplimiento.EMatrizRiezgo();

            Procesar.IdRegistro = IdRegistro;
            Procesar.FechaCreado0 = FechaCreado;
            Procesar.IdUsuario = IdUsuario;
            Procesar.Nombre = Nombre;
            Procesar.IdTipoIdentificacion = IdTipoIdentificacion;
            Procesar.NumeroIdentificacion = NumeroIdentificacion;
            Procesar.IdTipoTercero = IdTipoTercero;
            Procesar.IdNivel_Riesgo_TipoTercero = IdNivel_Riesgo_TipoTercero;
            Procesar.IdArea = IdArea;
            Procesar.IdNivel_Riesgo_Area = IdNivel_Riesgo_Area;
            Procesar.IdPosicion = IdPosicion;
            Procesar.IdNivel_Riesgo_Posicion = IdNivel_Riesgo_Posicion;
            Procesar.IdNivelAcademico = IdNivelAcademico;
            Procesar.IdNivel_Riesgo_NivelAcademico = IdNivel_Riesgo_NivelAcademico;
            Procesar.IdPaisProcedencia = IdPaisProcedencia;
            Procesar.IdNivel_Riesgo_PaisProcedencia = IdNivel_Riesgo_PaisProcedencia;
            Procesar.IdPaisResidencia = IdPaisResidencia;
            Procesar.IdNivel_Riesgo_PaisResidencia = IdNivel_Riesgo_PaisResidencia;
            Procesar.IdProvincia = IdProvincia;
            Procesar.IdNivel_Riesgo_Provincia = IdNivel_Riesgo_Provincia;
            Procesar.IdSalarioDevengado = IdSalarioDevengado;
            Procesar.IdNivel_Riesgo_SalarioDevengado = IdNivel_Riesgo_SalarioDevengado;
            Procesar.ActividadSegundaria = ActividadSegundaria;
            Procesar.IdNivel_Riesgo_ActividadSegundaria = IdNivel_Riesgo_ActividadSegundaria;
            Procesar.IngresosAdicionales = IngresosAdicionales;
            Procesar.IdNivel_Riesgo_IngresosAdicionales = IdNivel_Riesgo_IngresosAdicionales;
            Procesar.IdPEP = IdPEP;
            Procesar.IdNivel_Riesgo_PEP = IdNivel_Riesgo_PEP;
            Procesar.PrimaAnual = PrimaAnual;
            Procesar.IdNivel_Riesgo_PrimaAnual = IdNivel_Riesgo_PrimaAnual;
            Procesar.IdTipoMonitoreo = IdTipoMonitoreo;
            Procesar.IdTipoDebidaDiligencia = IdTipoDebidaDiligencia;
            Procesar.IdNivel_Riesgo_Consolidado = IdNivel_Riesgo_Consolidado;
            Procesar.Observaciones = Observaciones;

            var MAN = ObjData.ProcesarMatrizriezgo(Procesar, Accion);
        }
    }
}
