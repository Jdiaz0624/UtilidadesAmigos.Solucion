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
	public partial class BDConexionSuministroDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public BDConexionSuministroDataContext() : 
				base(global::UtilidadesAmigos.Data.Properties.Settings.Default.SysFlexSegurosConnectionString9, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionSuministroDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionSuministroDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionSuministroDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BDConexionSuministroDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_BUSCA_SUMINISTRO_INVENTARIO")]
		public ISingleResult<SP_BUSCA_SUMINISTRO_INVENTARIOResult> SP_BUSCA_SUMINISTRO_INVENTARIO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CodigoArticulo", DbType="Decimal(20,0)")] System.Nullable<decimal> codigoArticulo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Articulo", DbType="VarChar(1000)")] string articulo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdMedida", DbType="Int")] System.Nullable<int> idMedida, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Estatus", DbType="VarChar(100)")] string estatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="GeneradoPor", DbType="Decimal(20,0)")] System.Nullable<decimal> generadoPor)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), codigoArticulo, articulo, idMedida, estatus, generadoPor);
			return ((ISingleResult<SP_BUSCA_SUMINISTRO_INVENTARIOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIO")]
		public ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIOResult> SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CodigoArticulo", DbType="Decimal(20,0)")] System.Nullable<decimal> codigoArticulo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Articulo", DbType="VarChar(1000)")] string articulo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdMedida", DbType="Int")] System.Nullable<int> idMedida, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Stock", DbType="Int")] System.Nullable<int> stock, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(20,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), codigoArticulo, articulo, idMedida, stock, idUsuario, accion);
			return ((ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJO")]
		public ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJOResult> SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(20,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CodigoArticulo", DbType="Decimal(20,0)")] System.Nullable<decimal> codigoArticulo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Descripcion", DbType="VarChar(1000)")] string descripcion, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdMedida", DbType="Int")] System.Nullable<int> idMedida, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Cantidad", DbType="Int")] System.Nullable<int> cantidad, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idUsuario, codigoArticulo, descripcion, idMedida, cantidad, accion);
			return ((ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJO")]
		public ISingleResult<SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJOResult> SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJO([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(20,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CodigoArticulo", DbType="Decimal(20,0)")] System.Nullable<decimal> codigoArticulo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), idUsuario, codigoArticulo);
			return ((ISingleResult<SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJOResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADER")]
		public ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADERResult> SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADER([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NumeroSolicitud", DbType="Decimal(20,0)")] System.Nullable<decimal> numeroSolicitud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NumeroConector", DbType="VarChar(100)")] string numeroConector, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdUsuario", DbType="Decimal(20,0)")] System.Nullable<decimal> idUsuario, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EstatusSolicitud", DbType="Bit")] System.Nullable<bool> estatusSolicitud, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), numeroSolicitud, numeroConector, idUsuario, estatusSolicitud, accion);
			return ((ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADERResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Utililades.SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLE")]
		public ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLEResult> SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLE([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SecuenciaDetalle", DbType="Decimal(20,0)")] System.Nullable<decimal> secuenciaDetalle, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NumeroConector", DbType="VarChar(100)")] string numeroConector, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CodigoArticulo", DbType="Decimal(20,0)")] System.Nullable<decimal> codigoArticulo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Descripcion", DbType="VarChar(1000)")] string descripcion, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IdMedida", DbType="Int")] System.Nullable<int> idMedida, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Cantidad", DbType="Int")] System.Nullable<int> cantidad, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Accion", DbType="VarChar(150)")] string accion)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), secuenciaDetalle, numeroConector, codigoArticulo, descripcion, idMedida, cantidad, accion);
			return ((ISingleResult<SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLEResult>)(result.ReturnValue));
		}
	}
	
	public partial class SP_BUSCA_SUMINISTRO_INVENTARIOResult
	{
		
		private System.Nullable<decimal> _CodigoArticulo;
		
		private string _Articulo;
		
		private System.Nullable<int> _IdMedida;
		
		private string _Medida;
		
		private System.Nullable<int> _Stock;
		
		private string _Estatus;
		
		private System.Nullable<decimal> _UsuarioCrea;
		
		private string _CreadoPor;
		
		private System.Nullable<System.DateTime> _FechaCrea0;
		
		private string _FechaCreado;
		
		private string _HoraCreado;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private string _ModificadoPor;
		
		private System.Nullable<System.DateTime> _FechaModifica0;
		
		private string _FechaModificado;
		
		private string _HoraModificado;
		
		private string _GeneradoPor;
		
		public SP_BUSCA_SUMINISTRO_INVENTARIOResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodigoArticulo", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> CodigoArticulo
		{
			get
			{
				return this._CodigoArticulo;
			}
			set
			{
				if ((this._CodigoArticulo != value))
				{
					this._CodigoArticulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Articulo", DbType="VarChar(1000)")]
		public string Articulo
		{
			get
			{
				return this._Articulo;
			}
			set
			{
				if ((this._Articulo != value))
				{
					this._Articulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdMedida", DbType="Int")]
		public System.Nullable<int> IdMedida
		{
			get
			{
				return this._IdMedida;
			}
			set
			{
				if ((this._IdMedida != value))
				{
					this._IdMedida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Medida", DbType="VarChar(100)")]
		public string Medida
		{
			get
			{
				return this._Medida;
			}
			set
			{
				if ((this._Medida != value))
				{
					this._Medida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stock", DbType="Int")]
		public System.Nullable<int> Stock
		{
			get
			{
				return this._Stock;
			}
			set
			{
				if ((this._Stock != value))
				{
					this._Stock = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estatus", DbType="VarChar(16) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioCrea", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> UsuarioCrea
		{
			get
			{
				return this._UsuarioCrea;
			}
			set
			{
				if ((this._UsuarioCrea != value))
				{
					this._UsuarioCrea = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaCrea0", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaCrea0
		{
			get
			{
				return this._FechaCrea0;
			}
			set
			{
				if ((this._FechaCrea0 != value))
				{
					this._FechaCrea0 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaCreado", DbType="NVarChar(4000)")]
		public string FechaCreado
		{
			get
			{
				return this._FechaCreado;
			}
			set
			{
				if ((this._FechaCreado != value))
				{
					this._FechaCreado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoraCreado", DbType="NVarChar(4000)")]
		public string HoraCreado
		{
			get
			{
				return this._HoraCreado;
			}
			set
			{
				if ((this._HoraCreado != value))
				{
					this._HoraCreado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(20,0)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModifica0", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaModifica0
		{
			get
			{
				return this._FechaModifica0;
			}
			set
			{
				if ((this._FechaModifica0 != value))
				{
					this._FechaModifica0 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaModificado", DbType="NVarChar(4000)")]
		public string FechaModificado
		{
			get
			{
				return this._FechaModificado;
			}
			set
			{
				if ((this._FechaModificado != value))
				{
					this._FechaModificado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoraModificado", DbType="NVarChar(4000)")]
		public string HoraModificado
		{
			get
			{
				return this._HoraModificado;
			}
			set
			{
				if ((this._HoraModificado != value))
				{
					this._HoraModificado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GeneradoPor", DbType="VarChar(150)")]
		public string GeneradoPor
		{
			get
			{
				return this._GeneradoPor;
			}
			set
			{
				if ((this._GeneradoPor != value))
				{
					this._GeneradoPor = value;
				}
			}
		}
	}
	
	public partial class SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIOResult
	{
		
		private System.Nullable<decimal> _CodigoArticulo;
		
		private string _Articulo;
		
		private System.Nullable<int> _IdMedida;
		
		private System.Nullable<int> _Stock;
		
		private System.Nullable<decimal> _UsuarioCrea;
		
		private System.Nullable<System.DateTime> _FechaCrea;
		
		private System.Nullable<decimal> _UsuarioModifica;
		
		private System.Nullable<System.DateTime> _FechaModifica;
		
		public SP_PROCESAR_INFORMACION_SUMINISTRO_INVENTARIOResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodigoArticulo", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> CodigoArticulo
		{
			get
			{
				return this._CodigoArticulo;
			}
			set
			{
				if ((this._CodigoArticulo != value))
				{
					this._CodigoArticulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Articulo", DbType="VarChar(1000)")]
		public string Articulo
		{
			get
			{
				return this._Articulo;
			}
			set
			{
				if ((this._Articulo != value))
				{
					this._Articulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdMedida", DbType="Int")]
		public System.Nullable<int> IdMedida
		{
			get
			{
				return this._IdMedida;
			}
			set
			{
				if ((this._IdMedida != value))
				{
					this._IdMedida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Stock", DbType="Int")]
		public System.Nullable<int> Stock
		{
			get
			{
				return this._Stock;
			}
			set
			{
				if ((this._Stock != value))
				{
					this._Stock = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioCrea", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> UsuarioCrea
		{
			get
			{
				return this._UsuarioCrea;
			}
			set
			{
				if ((this._UsuarioCrea != value))
				{
					this._UsuarioCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaCrea", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaCrea
		{
			get
			{
				return this._FechaCrea;
			}
			set
			{
				if ((this._FechaCrea != value))
				{
					this._FechaCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioModifica", DbType="Decimal(20,0)")]
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
	
	public partial class SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJOResult
	{
		
		private System.Nullable<decimal> _IdUsuario;
		
		private System.Nullable<decimal> _CodigoArticulo;
		
		private string _Descripcion;
		
		private System.Nullable<int> _IdMedida;
		
		private System.Nullable<int> _Cantidad;
		
		public SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_ESPEJOResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodigoArticulo", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> CodigoArticulo
		{
			get
			{
				return this._CodigoArticulo;
			}
			set
			{
				if ((this._CodigoArticulo != value))
				{
					this._CodigoArticulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(1000)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdMedida", DbType="Int")]
		public System.Nullable<int> IdMedida
		{
			get
			{
				return this._IdMedida;
			}
			set
			{
				if ((this._IdMedida != value))
				{
					this._IdMedida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
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
	}
	
	public partial class SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJOResult
	{
		
		private System.Nullable<decimal> _IdUsuario;
		
		private System.Nullable<decimal> _CodigoArticulo;
		
		private string _Descripcion;
		
		private System.Nullable<int> _IdMedida;
		
		private string _Medida;
		
		private System.Nullable<int> _Cantidad;
		
		public SP_BUSCA_SUMINISTRO_SOLICITUD_ESPEJOResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodigoArticulo", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> CodigoArticulo
		{
			get
			{
				return this._CodigoArticulo;
			}
			set
			{
				if ((this._CodigoArticulo != value))
				{
					this._CodigoArticulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(1000)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdMedida", DbType="Int")]
		public System.Nullable<int> IdMedida
		{
			get
			{
				return this._IdMedida;
			}
			set
			{
				if ((this._IdMedida != value))
				{
					this._IdMedida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Medida", DbType="VarChar(100)")]
		public string Medida
		{
			get
			{
				return this._Medida;
			}
			set
			{
				if ((this._Medida != value))
				{
					this._Medida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
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
	}
	
	public partial class SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADERResult
	{
		
		private System.Nullable<decimal> _NumeroSolicitud;
		
		private string _NumeroConector;
		
		private System.Nullable<decimal> _IdUsuario;
		
		private System.Nullable<System.DateTime> _FechaSolicitud;
		
		private System.Nullable<bool> _EstatusSolicitud;
		
		public SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_HEADERResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumeroSolicitud", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> NumeroSolicitud
		{
			get
			{
				return this._NumeroSolicitud;
			}
			set
			{
				if ((this._NumeroSolicitud != value))
				{
					this._NumeroSolicitud = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumeroConector", DbType="VarChar(100)")]
		public string NumeroConector
		{
			get
			{
				return this._NumeroConector;
			}
			set
			{
				if ((this._NumeroConector != value))
				{
					this._NumeroConector = value;
				}
			}
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaSolicitud", DbType="DateTime")]
		public System.Nullable<System.DateTime> FechaSolicitud
		{
			get
			{
				return this._FechaSolicitud;
			}
			set
			{
				if ((this._FechaSolicitud != value))
				{
					this._FechaSolicitud = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstatusSolicitud", DbType="Bit")]
		public System.Nullable<bool> EstatusSolicitud
		{
			get
			{
				return this._EstatusSolicitud;
			}
			set
			{
				if ((this._EstatusSolicitud != value))
				{
					this._EstatusSolicitud = value;
				}
			}
		}
	}
	
	public partial class SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLEResult
	{
		
		private System.Nullable<decimal> _SecuenciaDetalle;
		
		private string _NumeroConector;
		
		private System.Nullable<decimal> _CodigoArticulo;
		
		private string _Descripcion;
		
		private System.Nullable<int> _IdMedida;
		
		private System.Nullable<int> _Cantidad;
		
		public SP_PROCESAR_INFORMACION_SUMINISTRO_SOLICITUD_DETALLEResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecuenciaDetalle", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> SecuenciaDetalle
		{
			get
			{
				return this._SecuenciaDetalle;
			}
			set
			{
				if ((this._SecuenciaDetalle != value))
				{
					this._SecuenciaDetalle = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumeroConector", DbType="VarChar(100)")]
		public string NumeroConector
		{
			get
			{
				return this._NumeroConector;
			}
			set
			{
				if ((this._NumeroConector != value))
				{
					this._NumeroConector = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodigoArticulo", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> CodigoArticulo
		{
			get
			{
				return this._CodigoArticulo;
			}
			set
			{
				if ((this._CodigoArticulo != value))
				{
					this._CodigoArticulo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="VarChar(1000)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdMedida", DbType="Int")]
		public System.Nullable<int> IdMedida
		{
			get
			{
				return this._IdMedida;
			}
			set
			{
				if ((this._IdMedida != value))
				{
					this._IdMedida = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int")]
		public System.Nullable<int> Cantidad
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
	}
}
#pragma warning restore 1591
