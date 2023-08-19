using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class Enumeraciones
    {

        public enum TipoAgrupacionReportePolizaTransito { 
        
           Supervisor=1,
           Intermediario=2,
           Ramo=3,
           Sub_Ramo=4,
           Oficina=5,
           Usuario=6
        }

        public enum PerfilesUsuarios
        {
            ADMINISTRADOR = 1,
            CONTABILIDAD = 2,
            AUDITORIA = 3,
            NEGOCIOS = 4,
            TECNICO = 5,
            RECLAMACIONES = 6,
            ADMINISTRACION = 7,
            ARCHIVO = 8,
            RECEPCION = 9,
            COBROS = 10,
            CUMPLIMIENTO = 11,
            Cobros_Especial = 12,
            Tecnico_Especial = 13
        }


        public enum CodigoEstatusClientesSinPoliza
        {
            Negocios = 1,
            Tecnico = 2,
            Devuelto = 3
        }

        public enum EstatusSolicitudSuministro
        {

            Activa = 1,
            Procesada = 2,
            Cancelada = 3,
            Rechazada = 4,
            Pendiente = 5
        }

        public enum CorreosEmisiorSistema
        {

            Backup_Base_Datos = 1,
            Volante_Pagos = 2,
            Cotizador_Futuro_Seguros = 3,
            Suministro_Inventario = 4
        }
    }
}
