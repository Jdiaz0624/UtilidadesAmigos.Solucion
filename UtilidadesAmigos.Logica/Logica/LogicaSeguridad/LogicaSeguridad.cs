using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaSeguridad
{
    public class LogicaSeguridad
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionDataContext ObjData = new Data.Conexiones.LINQ.BDConexionDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMEINTO DE PERFILES
        //LISTADO DE PERFILES
        public List<UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles> ListadoPerfiles(decimal? IdPerfil = null, string Perfil = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_PERFILES(IdPerfil, Perfil)
                           select new UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles
                           {
                               IdPerfil=n.IdPerfil,
                               perfil=n.perfil,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }
        //MANTENIMIENTO DE PERFILES
        public UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles MantenimientoPerfiles(UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles Item, string Accion)
        {
            UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles Mantenimiento = null;

            var Perfil = ObjData.SP_MANTENIMIENTO_PERFILES(
                Item.IdPerfil,
                Item.perfil,
                Item.Estatus0,
                Accion);
            if (Perfil != null)
            {
                Mantenimiento = (from n in Perfil
                                 select new UtilidadesAmigos.Logica.Entidades.Seguridad.EPerfiles
                                 {
                                     IdPerfil=n.IdPerfil,
                                     perfil=n.Perfil,
                                     Estatus0=n.Estatus
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
#endregion
    }
}
