using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class Enumeraciones
    {
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
    }
}
