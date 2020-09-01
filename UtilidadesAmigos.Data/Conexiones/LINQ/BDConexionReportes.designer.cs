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
	public partial class BDConexionReportesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public BDConexionReportesDataContext() : 
				base(global::UtilidadesAmigos.Data.Properties.Settings.Default.SysFlexSegurosConnectionString2, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionReportesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionReportesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionReportesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionReportesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDO")]
		public ISingleResult<SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDOResult> SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(20,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Sucursal", DbType="VarChar(100)")] string sucursal, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Oficina", DbType="VarChar(100)")] string oficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Departaemnto", DbType="VarChar(100)")] string departaemnto, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Usuario", DbType="VarChar(100)")] string usuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Concepto", DbType="VarChar(1000)")] string concepto, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Cantidad", DbType="Decimal(20,0)")] System.Nullable<decimal> cantidad, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Total", DbType="Decimal(20,2)")] System.Nullable<decimal> total, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TipoMovimiento", DbType="Int")] System.Nullable<int> tipoMovimiento, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TotalRegistros", DbType="Decimal(20,0)")] System.Nullable<decimal> totalRegistros, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TotalPrima", DbType="Decimal(20,2)")] System.Nullable<decimal> totalPrima, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaDesde", DbType="Date")] System.Nullable<System.DateTime> fechaDesde, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaHasta", DbType="Date")] System.Nullable<System.DateTime> fechaHasta, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idUsuario, sucursal, oficina, departaemnto, usuario, concepto, cantidad, total, tipoMovimiento, totalRegistros, totalPrima, fechaDesde, fechaHasta, accion);
			return ((ISingleResult<SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLE")]
		public ISingleResult<SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLEResult> SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLE([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(20,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaDesde", DbType="Date")] System.Nullable<System.DateTime> fechaDesde, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FechaHasta", DbType="Date")] System.Nullable<System.DateTime> fechaHasta, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Sucursal", DbType="VarChar(100)")] string sucursal, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Oficina", DbType="VarChar(100)")] string oficina, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Departamento", DbType="VarChar(100)")] string departamento, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Usuario", DbType="VarChar(100)")] string usuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Concepto", DbType="VarChar(1000)")] string concepto, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Poliza", DbType="VarChar(50)")] string poliza, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Monto", DbType="Decimal(20,2)")] System.Nullable<decimal> monto, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TotalRegistros", DbType="Decimal(20,0)")] System.Nullable<decimal> totalRegistros, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TotalValor", DbType="Decimal(20,2)")] System.Nullable<decimal> totalValor, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idUsuario, fechaDesde, fechaHasta, sucursal, oficina, departamento, usuario, concepto, poliza, monto, totalRegistros, totalValor, accion);
			return ((ISingleResult<SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLEResult>)(result.ReturnValue));
		}
	}
	
	public partial class SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDOResult
	{
		
		private System.Nullable<decimal> _IdUsuario;
		
		private string _Sucursal;
		
		private string _Oficina;
		
		private string _Departaemnto;
		
		private string _Usuario;
		
		private string _Concepto;
		
		private System.Nullable<decimal> _Cantidad;
		
		private System.Nullable<decimal> _Total;
		
		private System.Nullable<int> _TipoMovimiento;
		
		private System.Nullable<decimal> _TotalRegistros;
		
		private System.Nullable<decimal> _TotalPrima;
		
		private System.Nullable<System.DateTime> _FechaDesde;
		
		private System.Nullable<System.DateTime> _FechaHasta;
		
		public SP_GUARDAR_DATOS_REPORTE_POR_USUARIO_RESUMIDOResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					this._IdUsuario = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Departaemnto", DbType="VarChar(100)")]
		public string Departaemnto
		{
			get
			{
				return this._Departaemnto;
			}
			set
			{
				if ((this._Departaemnto != value))
				{
					this._Departaemnto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usuario", DbType="VarChar(100)")]
		public string Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				if ((this._Usuario != value))
				{
					this._Usuario = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Concepto", DbType="VarChar(1000)")]
		public string Concepto
		{
			get
			{
				return this._Concepto;
			}
			set
			{
				if ((this._Concepto != value))
				{
					this._Concepto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this._Cantidad = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this._Total = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipoMovimiento", DbType="Int")]
		public System.Nullable<int> TipoMovimiento
		{
			get
			{
				return this._TipoMovimiento;
			}
			set
			{
				if ((this._TipoMovimiento != value))
				{
					this._TipoMovimiento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalRegistros", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> TotalRegistros
		{
			get
			{
				return this._TotalRegistros;
			}
			set
			{
				if ((this._TotalRegistros != value))
				{
					this._TotalRegistros = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalPrima", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> TotalPrima
		{
			get
			{
				return this._TotalPrima;
			}
			set
			{
				if ((this._TotalPrima != value))
				{
					this._TotalPrima = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaDesde", DbType="Date")]
		public System.Nullable<System.DateTime> FechaDesde
		{
			get
			{
				return this._FechaDesde;
			}
			set
			{
				if ((this._FechaDesde != value))
				{
					this._FechaDesde = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaHasta", DbType="Date")]
		public System.Nullable<System.DateTime> FechaHasta
		{
			get
			{
				return this._FechaHasta;
			}
			set
			{
				if ((this._FechaHasta != value))
				{
					this._FechaHasta = value;
				}
			}
		}
	}
	
	public partial class SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLEResult
	{
		
		private System.Nullable<decimal> _IdUsuario;
		
		private System.Nullable<System.DateTime> _FechaDesde;
		
		private System.Nullable<System.DateTime> _FechaHasta;
		
		private string _Sucursal;
		
		private string _Oficina;
		
		private string _Departamento;
		
		private string _Usuario;
		
		private string _Concepto;
		
		private string _Poliza;
		
		private System.Nullable<decimal> _Monto;
		
		private System.Nullable<decimal> _TotalRegistros;
		
		private System.Nullable<decimal> _TotalValor;
		
		public SP_GUARDAR_DATOS_PRODUCCION_USUARIO_DETALLEResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUsuario", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> IdUsuario
		{
			get
			{
				return this._IdUsuario;
			}
			set
			{
				if ((this._IdUsuario != value))
				{
					this._IdUsuario = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaDesde", DbType="Date")]
		public System.Nullable<System.DateTime> FechaDesde
		{
			get
			{
				return this._FechaDesde;
			}
			set
			{
				if ((this._FechaDesde != value))
				{
					this._FechaDesde = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaHasta", DbType="Date")]
		public System.Nullable<System.DateTime> FechaHasta
		{
			get
			{
				return this._FechaHasta;
			}
			set
			{
				if ((this._FechaHasta != value))
				{
					this._FechaHasta = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usuario", DbType="VarChar(100)")]
		public string Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				if ((this._Usuario != value))
				{
					this._Usuario = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Concepto", DbType="VarChar(1000)")]
		public string Concepto
		{
			get
			{
				return this._Concepto;
			}
			set
			{
				if ((this._Concepto != value))
				{
					this._Concepto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Poliza", DbType="VarChar(50)")]
		public string Poliza
		{
			get
			{
				return this._Poliza;
			}
			set
			{
				if ((this._Poliza != value))
				{
					this._Poliza = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Monto", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> Monto
		{
			get
			{
				return this._Monto;
			}
			set
			{
				if ((this._Monto != value))
				{
					this._Monto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalRegistros", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> TotalRegistros
		{
			get
			{
				return this._TotalRegistros;
			}
			set
			{
				if ((this._TotalRegistros != value))
				{
					this._TotalRegistros = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalValor", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> TotalValor
		{
			get
			{
				return this._TotalValor;
			}
			set
			{
				if ((this._TotalValor != value))
				{
					this._TotalValor = value;
				}
			}
		}
	}
}
#pragma warning restore 1591