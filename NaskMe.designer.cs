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

namespace NaskMeAnalytics
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NaskMeDbLive")]
	public partial class NaskMeDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTblEvent(TblEvent instance);
    partial void UpdateTblEvent(TblEvent instance);
    partial void DeleteTblEvent(TblEvent instance);
    #endregion
		
		public NaskMeDataContext() : 
				base(global::NaskMeAnalytics.Properties.Settings.Default.NaskMeDbLiveConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NaskMeDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NaskMeDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NaskMeDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NaskMeDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TblEvent> TblEvents
		{
			get
			{
				return this.GetTable<TblEvent>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.pr_UpdateEventStatus")]
		public int pr_UpdateEventStatus([global::System.Data.Linq.Mapping.ParameterAttribute(Name="EventIds", DbType="VarChar(MAX)")] string eventIds, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="StatusId", DbType="Int")] System.Nullable<int> statusId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), eventIds, statusId);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TblEvents")]
	public partial class TblEvent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private decimal _EventId;
		
		private string _Name;
		
		private decimal _UserId;
		
		private decimal _ObjectId;
		
		private System.Nullable<bool> _IsShared;
		
		private string _SharedWith;
		
		private System.Nullable<bool> _IsMotherload;
		
		private string _MotherloadItem;
		
		private decimal _MotherloadId;
		
		private System.Nullable<bool> _IsDone;
		
		private System.Nullable<bool> _Active;
		
		private string _ActionType;
		
		private string _Price;
		
		private System.Nullable<System.DateTime> _DateCreated;
		
		private System.Nullable<System.DateTime> _DateModified;
		
		private System.Nullable<int> _IsProcessed;
		
		private string _ObjectName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEventIdChanging(decimal value);
    partial void OnEventIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnUserIdChanging(decimal value);
    partial void OnUserIdChanged();
    partial void OnObjectIdChanging(decimal value);
    partial void OnObjectIdChanged();
    partial void OnIsSharedChanging(System.Nullable<bool> value);
    partial void OnIsSharedChanged();
    partial void OnSharedWithChanging(string value);
    partial void OnSharedWithChanged();
    partial void OnIsMotherloadChanging(System.Nullable<bool> value);
    partial void OnIsMotherloadChanged();
    partial void OnMotherloadItemChanging(string value);
    partial void OnMotherloadItemChanged();
    partial void OnMotherloadIdChanging(decimal value);
    partial void OnMotherloadIdChanged();
    partial void OnIsDoneChanging(System.Nullable<bool> value);
    partial void OnIsDoneChanged();
    partial void OnActiveChanging(System.Nullable<bool> value);
    partial void OnActiveChanged();
    partial void OnActionTypeChanging(string value);
    partial void OnActionTypeChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    partial void OnDateCreatedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateCreatedChanged();
    partial void OnDateModifiedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateModifiedChanged();
    partial void OnIsProcessedChanging(System.Nullable<int> value);
    partial void OnIsProcessedChanged();
    partial void OnObjectNameChanging(string value);
    partial void OnObjectNameChanged();
    #endregion
		
		public TblEvent()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventId", AutoSync=AutoSync.OnInsert, DbType="Decimal(18,0) NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public decimal EventId
		{
			get
			{
				return this._EventId;
			}
			set
			{
				if ((this._EventId != value))
				{
					this.OnEventIdChanging(value);
					this.SendPropertyChanging();
					this._EventId = value;
					this.SendPropertyChanged("EventId");
					this.OnEventIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Decimal(18,0) NOT NULL")]
		public decimal UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ObjectId", DbType="Decimal(18,0) NOT NULL")]
		public decimal ObjectId
		{
			get
			{
				return this._ObjectId;
			}
			set
			{
				if ((this._ObjectId != value))
				{
					this.OnObjectIdChanging(value);
					this.SendPropertyChanging();
					this._ObjectId = value;
					this.SendPropertyChanged("ObjectId");
					this.OnObjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsShared", DbType="Bit")]
		public System.Nullable<bool> IsShared
		{
			get
			{
				return this._IsShared;
			}
			set
			{
				if ((this._IsShared != value))
				{
					this.OnIsSharedChanging(value);
					this.SendPropertyChanging();
					this._IsShared = value;
					this.SendPropertyChanged("IsShared");
					this.OnIsSharedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SharedWith", DbType="VarChar(400)")]
		public string SharedWith
		{
			get
			{
				return this._SharedWith;
			}
			set
			{
				if ((this._SharedWith != value))
				{
					this.OnSharedWithChanging(value);
					this.SendPropertyChanging();
					this._SharedWith = value;
					this.SendPropertyChanged("SharedWith");
					this.OnSharedWithChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsMotherload", DbType="Bit")]
		public System.Nullable<bool> IsMotherload
		{
			get
			{
				return this._IsMotherload;
			}
			set
			{
				if ((this._IsMotherload != value))
				{
					this.OnIsMotherloadChanging(value);
					this.SendPropertyChanging();
					this._IsMotherload = value;
					this.SendPropertyChanged("IsMotherload");
					this.OnIsMotherloadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherloadItem", DbType="VarChar(400)")]
		public string MotherloadItem
		{
			get
			{
				return this._MotherloadItem;
			}
			set
			{
				if ((this._MotherloadItem != value))
				{
					this.OnMotherloadItemChanging(value);
					this.SendPropertyChanging();
					this._MotherloadItem = value;
					this.SendPropertyChanged("MotherloadItem");
					this.OnMotherloadItemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherloadId", DbType="Decimal(18,0) NOT NULL")]
		public decimal MotherloadId
		{
			get
			{
				return this._MotherloadId;
			}
			set
			{
				if ((this._MotherloadId != value))
				{
					this.OnMotherloadIdChanging(value);
					this.SendPropertyChanging();
					this._MotherloadId = value;
					this.SendPropertyChanged("MotherloadId");
					this.OnMotherloadIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDone", DbType="Bit")]
		public System.Nullable<bool> IsDone
		{
			get
			{
				return this._IsDone;
			}
			set
			{
				if ((this._IsDone != value))
				{
					this.OnIsDoneChanging(value);
					this.SendPropertyChanging();
					this._IsDone = value;
					this.SendPropertyChanged("IsDone");
					this.OnIsDoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit")]
		public System.Nullable<bool> Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActionType", DbType="VarChar(100)")]
		public string ActionType
		{
			get
			{
				return this._ActionType;
			}
			set
			{
				if ((this._ActionType != value))
				{
					this.OnActionTypeChanging(value);
					this.SendPropertyChanging();
					this._ActionType = value;
					this.SendPropertyChanged("ActionType");
					this.OnActionTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="VarChar(100)")]
		public string Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateModified", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateModified
		{
			get
			{
				return this._DateModified;
			}
			set
			{
				if ((this._DateModified != value))
				{
					this.OnDateModifiedChanging(value);
					this.SendPropertyChanging();
					this._DateModified = value;
					this.SendPropertyChanged("DateModified");
					this.OnDateModifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsProcessed", DbType="Int")]
		public System.Nullable<int> IsProcessed
		{
			get
			{
				return this._IsProcessed;
			}
			set
			{
				if ((this._IsProcessed != value))
				{
					this.OnIsProcessedChanging(value);
					this.SendPropertyChanging();
					this._IsProcessed = value;
					this.SendPropertyChanged("IsProcessed");
					this.OnIsProcessedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ObjectName", DbType="VarChar(400)")]
		public string ObjectName
		{
			get
			{
				return this._ObjectName;
			}
			set
			{
				if ((this._ObjectName != value))
				{
					this.OnObjectNameChanging(value);
					this.SendPropertyChanging();
					this._ObjectName = value;
					this.SendPropertyChanged("ObjectName");
					this.OnObjectNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591