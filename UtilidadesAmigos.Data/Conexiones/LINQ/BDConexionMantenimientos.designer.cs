﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UtilidadesAmigos.Data.Conexiones.LINQ
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SysFlexSeguros")]
	public partial class BDConexionMantenimientosDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public BDConexionMantenimientosDataContext() : 
				base(global::UtilidadesAmigos.Data.Properties.Settings.Default.SysFlexSegurosConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionMantenimientosDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionMantenimientosDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionMantenimientosDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionMantenimientosDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_MAN_BUSCA_DEPARTAMENTOS")]
		public ISingleResult<SP_MAN_BUSCA_DEPARTAMENTOSResult> SP_MAN_BUSCA_DEPARTAMENTOS([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdOficina", DbType="Decimal(20,0)")] System.Nullable<decimal> idOficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdDepartamento", DbType="Decimal(20,0)")] System.Nullable<decimal> idDepartamento, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Descripcion", DbType="VarChar(100)")] string descripcion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idOficina, idDepartamento, descripcion);
			return ((ISingleResult<SP_MAN_BUSCA_DEPARTAMENTOSResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_MAN_MANTENIMIENTO_DEPARTAMENTOS")]
		public ISingleResult<SP_MAN_MANTENIMIENTO_DEPARTAMENTOSResult> SP_MAN_MANTENIMIENTO_DEPARTAMENTOS([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdOficina", DbType="Decimal(18,0)")] System.Nullable<decimal> idOficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdDepartamento", DbType="Decimal(18,0)")] System.Nullable<decimal> idDepartamento, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Descripcion", DbType="VarChar(100)")] string descripcion, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Estatus", DbType="Bit")] System.Nullable<bool> estatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="UsuarioAdiciona", DbType="Decimal(18,0)")] System.Nullable<decimal> usuarioAdiciona, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idOficina, idDepartamento, descripcion, estatus, usuarioAdiciona, accion);
			return ((ISingleResult<SP_MAN_MANTENIMIENTO_DEPARTAMENTOSResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_MAN_MANTENIMIENTO_EMPLEADO")]
		public ISingleResult<SP_MAN_MANTENIMIENTO_EMPLEADOResult> SP_MAN_MANTENIMIENTO_EMPLEADO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdOficina", DbType="Decimal(18,0)")] System.Nullable<decimal> idOficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdDepartamento", DbType="Decimal(18,0)")] System.Nullable<decimal> idDepartamento, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdEmpleado", DbType="Decimal(18,0)")] System.Nullable<decimal> idEmpleado, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nombre", DbType="VarChar(100)")] string nombre, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Estatus", DbType="Bit")] System.Nullable<bool> estatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(18,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idOficina, idDepartamento, idEmpleado, nombre, estatus, idUsuario, accion);
			return ((ISingleResult<SP_MAN_MANTENIMIENTO_EMPLEADOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_BUSCA_OFICINAS")]
		public ISingleResult<SP_BUSCA_OFICINASResult> SP_BUSCA_OFICINAS([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdOficina", DbType="Decimal(18,0)")] System.Nullable<decimal> idOficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdSucursal", DbType="Decimal(20,0)")] System.Nullable<decimal> idSucursal, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Descripcion", DbType="VarChar(100)")] string descripcion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idOficina, idSucursal, descripcion);
			return ((ISingleResult<SP_BUSCA_OFICINASResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_MANTENIMIENTO_OFICINAS")]
		public ISingleResult<SP_MANTENIMIENTO_OFICINASResult> SP_MANTENIMIENTO_OFICINAS([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdOficina", DbType="Decimal(18,0)")] System.Nullable<decimal> idOficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdSucursal", DbType="Decimal(20,0)")] System.Nullable<decimal> idSucursal, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Descripcion", DbType="VarChar(100)")] string descripcion, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Estatus", DbType="Bit")] System.Nullable<bool> estatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(18,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idOficina, idSucursal, descripcion, estatus, idUsuario, accion);
			return ((ISingleResult<SP_MANTENIMIENTO_OFICINASResult>)(result.ReturnValue));
		}
	}
	
	public partial class SP_MAN_BUSCA_DEPARTAMENTOSResult
	{
		
		private decimal _IdOficina;
		
		private string _Oficina;
		
		private decimal _IdDepartamento;
		
		private string _Departamento;
		
		private System.Nullable<bool> _Estatus0;
		
		private string _Estatus;
		
		private System.Nullable<decimal> _UsuarioAdiciona;
		
		private string _CreadoPor;
		
		private System.Nullable<System.DateTime> _FechaAdiciona;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private string _ModificadoPor;
		
		private System.Nullable<System.DateTime> _FechaModifica;
		
		public SP_MAN_BUSCA_DEPARTAMENTOSResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOficina", DbType="Decimal(18,0) NOT NULL")]
		public decimal IdOficina
		{
			get
			{
				return this._IdOficina;
			}
			set
			{
				if ((this._IdOficina != value))
				{
					this._IdOficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Oficina", DbType="VarChar(100)")]
		public string Oficina
		{
			get
			{
				return this._Oficina;
			}
			set
			{
				if ((this._Oficina != value))
				{
					this._Oficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdDepartamento", DbType="Decimal(18,0) NOT NULL")]
		public decimal IdDepartamento
		{
			get
			{
				return this._IdDepartamento;
			}
			set
			{
				if ((this._IdDepartamento != value))
				{
					this._IdDepartamento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Departamento", DbType="VarChar(100)")]
		public string Departamento
		{
			get
			{
				return this._Departamento;
			}
			set
			{
				if ((this._Departamento != value))
				{
					this._Departamento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus0", DbType="Bit")]
		public System.Nullable<bool> Estatus0
		{
			get
			{
				return this._Estatus0;
			}
			set
			{
				if ((this._Estatus0 != value))
				{
					this._Estatus0 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus", DbType="VarChar(8) NOT NULL", CanBeNull=false)]
		public string Estatus
		{
			get
			{
				return this._Estatus;
			}
			set
			{
				if ((this._Estatus != value))
				{
					this._Estatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioAdiciona", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioAdiciona
		{
			get
			{
				return this._UsuarioAdiciona;
			}
			set
			{
				if ((this._UsuarioAdiciona != value))
				{
					this._UsuarioAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreadoPor", DbType="VarChar(150)")]
		public string CreadoPor
		{
			get
			{
				return this._CreadoPor;
			}
			set
			{
				if ((this._CreadoPor != value))
				{
					this._CreadoPor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaAdiciona", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaAdiciona
		{
			get
			{
				return this._FechaAdiciona;
			}
			set
			{
				if ((this._FechaAdiciona != value))
				{
					this._FechaAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioModifica
		{
			get
			{
				return this._UsuarioModifica;
			}
			set
			{
				if ((this._UsuarioModifica != value))
				{
					this._UsuarioModifica = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModificadoPor", DbType="VarChar(150)")]
		public string ModificadoPor
		{
			get
			{
				return this._ModificadoPor;
			}
			set
			{
				if ((this._ModificadoPor != value))
				{
					this._ModificadoPor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModifica", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaModifica
		{
			get
			{
				return this._FechaModifica;
			}
			set
			{
				if ((this._FechaModifica != value))
				{
					this._FechaModifica = value;
				}
			}
		}
	}
	
	public partial class SP_MAN_MANTENIMIENTO_DEPARTAMENTOSResult
	{
		
		private System.Nullable<decimal> _IdOficina;
		
		private System.Nullable<decimal> _IdDepartamento;
		
		private string _Descripcion;
		
		private System.Nullable<bool> _Estatus;
		
		private System.Nullable<decimal> _UsuarioAdiciona;
		
		private System.Nullable<System.DateTime> _FechaAdiciona;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private System.Nullable<System.DateTime> _FechaModifica;
		
		public SP_MAN_MANTENIMIENTO_DEPARTAMENTOSResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOficina", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> IdOficina
		{
			get
			{
				return this._IdOficina;
			}
			set
			{
				if ((this._IdOficina != value))
				{
					this._IdOficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdDepartamento", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> IdDepartamento
		{
			get
			{
				return this._IdDepartamento;
			}
			set
			{
				if ((this._IdDepartamento != value))
				{
					this._IdDepartamento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(100)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this._Descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus", DbType="Bit")]
		public System.Nullable<bool> Estatus
		{
			get
			{
				return this._Estatus;
			}
			set
			{
				if ((this._Estatus != value))
				{
					this._Estatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioAdiciona", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioAdiciona
		{
			get
			{
				return this._UsuarioAdiciona;
			}
			set
			{
				if ((this._UsuarioAdiciona != value))
				{
					this._UsuarioAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaAdiciona", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaAdiciona
		{
			get
			{
				return this._FechaAdiciona;
			}
			set
			{
				if ((this._FechaAdiciona != value))
				{
					this._FechaAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioModifica
		{
			get
			{
				return this._UsuarioModifica;
			}
			set
			{
				if ((this._UsuarioModifica != value))
				{
					this._UsuarioModifica = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModifica", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaModifica
		{
			get
			{
				return this._FechaModifica;
			}
			set
			{
				if ((this._FechaModifica != value))
				{
					this._FechaModifica = value;
				}
			}
		}
	}
	
	public partial class SP_MAN_MANTENIMIENTO_EMPLEADOResult
	{
		
		private System.Nullable<decimal> _IdOficina;
		
		private System.Nullable<decimal> _IdDepartamento;
		
		private System.Nullable<decimal> _IdEmpleado;
		
		private string _Nombre;
		
		private System.Nullable<bool> _Estatus;
		
		private System.Nullable<decimal> _UsuarioAdiciona;
		
		private System.Nullable<System.DateTime> _FechaAdiciona;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private System.Nullable<System.DateTime> _FechaModifica;
		
		public SP_MAN_MANTENIMIENTO_EMPLEADOResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOficina", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> IdOficina
		{
			get
			{
				return this._IdOficina;
			}
			set
			{
				if ((this._IdOficina != value))
				{
					this._IdOficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdDepartamento", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> IdDepartamento
		{
			get
			{
				return this._IdDepartamento;
			}
			set
			{
				if ((this._IdDepartamento != value))
				{
					this._IdDepartamento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdEmpleado", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> IdEmpleado
		{
			get
			{
				return this._IdEmpleado;
			}
			set
			{
				if ((this._IdEmpleado != value))
				{
					this._IdEmpleado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(100)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this._Nombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus", DbType="Bit")]
		public System.Nullable<bool> Estatus
		{
			get
			{
				return this._Estatus;
			}
			set
			{
				if ((this._Estatus != value))
				{
					this._Estatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioAdiciona", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioAdiciona
		{
			get
			{
				return this._UsuarioAdiciona;
			}
			set
			{
				if ((this._UsuarioAdiciona != value))
				{
					this._UsuarioAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaAdiciona", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaAdiciona
		{
			get
			{
				return this._FechaAdiciona;
			}
			set
			{
				if ((this._FechaAdiciona != value))
				{
					this._FechaAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioModifica
		{
			get
			{
				return this._UsuarioModifica;
			}
			set
			{
				if ((this._UsuarioModifica != value))
				{
					this._UsuarioModifica = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModifica", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaModifica
		{
			get
			{
				return this._FechaModifica;
			}
			set
			{
				if ((this._FechaModifica != value))
				{
					this._FechaModifica = value;
				}
			}
		}
	}
	
	public partial class SP_BUSCA_OFICINASResult
	{
		
		private decimal _IdOficina;
		
		private decimal _IdSucursal;
		
		private string _Sucursal;
		
		private string _Oficina;
		
		private System.Nullable<bool> _Estatus0;
		
		private string _Estatus;
		
		private System.Nullable<decimal> _UsuarioAdiciona;
		
		private string _Creadopor;
		
		private System.Nullable<System.DateTime> _FechaAdiciona;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private string _ModificadoPor;
		
		private System.Nullable<System.DateTime> _FechaModifica;
		
		public SP_BUSCA_OFICINASResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOficina", DbType="Decimal(18,0) NOT NULL")]
		public decimal IdOficina
		{
			get
			{
				return this._IdOficina;
			}
			set
			{
				if ((this._IdOficina != value))
				{
					this._IdOficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdSucursal", DbType="Decimal(20,0) NOT NULL")]
		public decimal IdSucursal
		{
			get
			{
				return this._IdSucursal;
			}
			set
			{
				if ((this._IdSucursal != value))
				{
					this._IdSucursal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sucursal", DbType="VarChar(100)")]
		public string Sucursal
		{
			get
			{
				return this._Sucursal;
			}
			set
			{
				if ((this._Sucursal != value))
				{
					this._Sucursal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Oficina", DbType="VarChar(100)")]
		public string Oficina
		{
			get
			{
				return this._Oficina;
			}
			set
			{
				if ((this._Oficina != value))
				{
					this._Oficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus0", DbType="Bit")]
		public System.Nullable<bool> Estatus0
		{
			get
			{
				return this._Estatus0;
			}
			set
			{
				if ((this._Estatus0 != value))
				{
					this._Estatus0 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus", DbType="VarChar(8)")]
		public string Estatus
		{
			get
			{
				return this._Estatus;
			}
			set
			{
				if ((this._Estatus != value))
				{
					this._Estatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioAdiciona", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioAdiciona
		{
			get
			{
				return this._UsuarioAdiciona;
			}
			set
			{
				if ((this._UsuarioAdiciona != value))
				{
					this._UsuarioAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Creadopor", DbType="VarChar(150)")]
		public string Creadopor
		{
			get
			{
				return this._Creadopor;
			}
			set
			{
				if ((this._Creadopor != value))
				{
					this._Creadopor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaAdiciona", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaAdiciona
		{
			get
			{
				return this._FechaAdiciona;
			}
			set
			{
				if ((this._FechaAdiciona != value))
				{
					this._FechaAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioModifica
		{
			get
			{
				return this._UsuarioModifica;
			}
			set
			{
				if ((this._UsuarioModifica != value))
				{
					this._UsuarioModifica = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModificadoPor", DbType="VarChar(150)")]
		public string ModificadoPor
		{
			get
			{
				return this._ModificadoPor;
			}
			set
			{
				if ((this._ModificadoPor != value))
				{
					this._ModificadoPor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModifica", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaModifica
		{
			get
			{
				return this._FechaModifica;
			}
			set
			{
				if ((this._FechaModifica != value))
				{
					this._FechaModifica = value;
				}
			}
		}
	}
	
	public partial class SP_MANTENIMIENTO_OFICINASResult
	{
		
		private System.Nullable<decimal> _IdOficina;
		
		private System.Nullable<decimal> _IdSucursal;
		
		private string _Descripcion;
		
		private System.Nullable<bool> _Estatus;
		
		private System.Nullable<decimal> _UsuarioAdiciona;
		
		private System.Nullable<System.DateTime> _FechaAdiciona;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private System.Nullable<System.DateTime> _FechaModifica;
		
		public SP_MANTENIMIENTO_OFICINASResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOficina", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> IdOficina
		{
			get
			{
				return this._IdOficina;
			}
			set
			{
				if ((this._IdOficina != value))
				{
					this._IdOficina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdSucursal", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> IdSucursal
		{
			get
			{
				return this._IdSucursal;
			}
			set
			{
				if ((this._IdSucursal != value))
				{
					this._IdSucursal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(100)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this._Descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus", DbType="Bit")]
		public System.Nullable<bool> Estatus
		{
			get
			{
				return this._Estatus;
			}
			set
			{
				if ((this._Estatus != value))
				{
					this._Estatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioAdiciona", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioAdiciona
		{
			get
			{
				return this._UsuarioAdiciona;
			}
			set
			{
				if ((this._UsuarioAdiciona != value))
				{
					this._UsuarioAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaAdiciona", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaAdiciona
		{
			get
			{
				return this._FechaAdiciona;
			}
			set
			{
				if ((this._FechaAdiciona != value))
				{
					this._FechaAdiciona = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> UsuarioModifica
		{
			get
			{
				return this._UsuarioModifica;
			}
			set
			{
				if ((this._UsuarioModifica != value))
				{
					this._UsuarioModifica = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModifica", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaModifica
		{
			get
			{
				return this._FechaModifica;
			}
			set
			{
				if ((this._FechaModifica != value))
				{
					this._FechaModifica = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
