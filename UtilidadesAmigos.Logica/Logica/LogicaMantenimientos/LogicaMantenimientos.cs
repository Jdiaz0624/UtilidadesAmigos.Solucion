﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaMantenimientos
{
    public class LogicaMantenimientos
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionMantenimientosDataContext Objdata = new Data.Conexiones.LINQ.BDConexionMantenimientosDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MANTENIMIENTO DE OFICINAS
        //LISTADO DE OFICINAS
        public List<UtilidadesAmigos.Logica.Entidades.Mantenimientos.EOficinas> BuscaOficinas(decimal? IdOficina = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_BUSCA_OFICINAS(IdOficina, Descripcion)
                          select new Entidades.Mantenimientos.EOficinas
                          {
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              Creadopor=n.Creadopor,
                              FechaAdiciona=n.FechaAdiciona,
                              UsuarioModifica=n.UsuarioModifica,
                              ModificadoPor=n.ModificadoPor,
                              FechaModifica=n.FechaModifica
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE OFICINAS
        public Entidades.Mantenimientos.EOficinas MantenimientoOficinas(Entidades.Mantenimientos.EOficinas Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.Mantenimientos.EOficinas Mantenimiento = null;

            var MAN = Objdata.SP_MANTENIMIENTO_OFICINAS(
                Item.IdOficina,
                Item.Oficina,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (MAN != null)
            {
                Mantenimiento = (from n in MAN
                                 select new Entidades.Mantenimientos.EOficinas
                                 {
                                     IdOficina=n.IdOficina,
                                     Oficina=n.Descripcion,
                                     Estatus0=n.Estatus,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona,
                                     UsuarioModifica=n.UsuarioModifica,
                                     FechaModifica=n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE DEPARTAMENTOS
        //LISTADO DE DEPARTAMENTOS
        public List<Entidades.Mantenimientos.EDepartamentos> BuscaDepartamentos(decimal? IdOficina = null, decimal? IdDepartamento = null, string Descripcion = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_MAN_BUSCA_DEPARTAMENTOS(IdOficina, IdDepartamento, Descripcion)
                          select new Entidades.Mantenimientos.EDepartamentos
                          {
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              Estatus0=n.Estatus0,
                              Estatus=n.Estatus,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              CreadoPor=n.CreadoPor,
                              FechaAdiciona=n.FechaAdiciona,
                              UsuarioModifica=n.UsuarioModifica,
                              ModificadoPor=n.ModificadoPor,
                              FechaModifica=n.FechaModifica
                          }).ToList();
            return Buscar;
        }

        //MANTENIMIENTO DE DEPARTAMENTOS
        public Entidades.Mantenimientos.EDepartamentos MantenimientoDepartamentos(Entidades.Mantenimientos.EDepartamentos Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.Mantenimientos.EDepartamentos Mantenimiento = null;

            var Departamentos = Objdata.SP_MAN_MANTENIMIENTO_DEPARTAMENTOS(
                Item.IdOficina,
                Item.IdDepartamento,
                Item.Departamento,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (Departamentos != null)
            {
                Mantenimiento = (from n in Departamentos
                                 select new Entidades.Mantenimientos.EDepartamentos
                                 {
                                     IdOficina = n.IdOficina,
                                     IdDepartamento = n.IdDepartamento,
                                     Departamento = n.Descripcion,
                                     Estatus0 = n.Estatus,
                                     UsuarioAdiciona = n.UsuarioAdiciona,
                                     FechaAdiciona = n.FechaAdiciona,
                                     UsuarioModifica = n.UsuarioModifica,
                                     FechaModifica = n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE EMPLEADOS
        //LISTADO DE EMPLEADOS
        public List<Entidades.Mantenimientos.EEmpleado> BuscaEmpleado(decimal? IdOficina = null, decimal? IdDepartamento = null, decimal? IdEmpleado = null, string Nombre = null)
        {
            Objdata.CommandTimeout = 999999999;

            var Buscar = (from n in Objdata.SP_MAN_BUSCA_EMPLEADOS(IdOficina, IdDepartamento, IdEmpleado, Nombre)
                          select new Entidades.Mantenimientos.EEmpleado
                          {
                              IdOficina=n.IdOficina,
                              Oficina=n.Oficina,
                              IdDepartamento=n.IdDepartamento,
                              Departamento=n.Departamento,
                              IdEmpleado=n.IdEmpleado,
                              Nombre=n.Nombre,
                              Estatus=n.Estatus,
                              Estatus0=n.Estatus0,
                              UsuarioAdiciona=n.UsuarioAdiciona,
                              CreadoPor=n.CreadoPor,
                              FechaAdiciona=n.FechaAdiciona,
                              UsuarioModifica=n.UsuarioModifica,
                              ModificadoPor=n.ModificadoPor,
                              FechaModifica=n.FechaModifica
                          }).ToList();
            return Buscar;

        }

        //MANTENIMIENTO DE EMPLEADOS
        public Entidades.Mantenimientos.EEmpleado MantenimientoEmpleado(Entidades.Mantenimientos.EEmpleado Item, string Accion)
        {
            Objdata.CommandTimeout = 999999999;

            Entidades.Mantenimientos.EEmpleado Mantenimiento = null;

            var Empleado = Objdata.SP_MAN_MANTENIMIENTO_EMPLEADO(
                Item.IdOficina,
                Item.IdDepartamento,
                Item.IdEmpleado,
                Item.Nombre,
                Item.Estatus0,
                Item.UsuarioAdiciona,
                Accion);
            if (Empleado != null)
            {
                Mantenimiento = (from n in Empleado
                                 select new Entidades.Mantenimientos.EEmpleado
                                 {
                                     IdOficina=n.IdOficina,
                                     IdDepartamento=n.IdDepartamento,
                                     IdEmpleado=n.IdEmpleado,
                                     Nombre=n.Nombre,
                                     Estatus0=n.Estatus,
                                     UsuarioAdiciona=n.UsuarioAdiciona,
                                     FechaAdiciona=n.FechaAdiciona,
                                     UsuarioModifica=n.UsuarioModifica,
                                     FechaModifica=n.FechaModifica
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion

        #region MANTENIMIENTO DE TARJETA DE ACCESO
        //LISTADO DE TARJETAS DE ACCESO

        //MANTENIMIENTO DE TARJETAS DE ACCESO

        #endregion
    }
}
