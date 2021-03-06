using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace Vietbait.Lablink.Model
{
	/// <summary>
	/// Strongly-typed collection for the TResultLot class.
	/// </summary>
    [Serializable]
	public partial class TResultLotCollection : ActiveList<TResultLot, TResultLotCollection>
	{	   
		public TResultLotCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TResultLotCollection</returns>
		public TResultLotCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TResultLot o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the T_Result_Lot table.
	/// </summary>
	[Serializable]
	public partial class TResultLot : ActiveRecord<TResultLot>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TResultLot()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TResultLot(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TResultLot(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TResultLot(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("T_Result_Lot", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarLotId = new TableSchema.TableColumn(schema);
				colvarLotId.ColumnName = "LotId";
				colvarLotId.DataType = DbType.Int64;
				colvarLotId.MaxLength = 0;
				colvarLotId.AutoIncrement = true;
				colvarLotId.IsNullable = false;
				colvarLotId.IsPrimaryKey = true;
				colvarLotId.IsForeignKey = false;
				colvarLotId.IsReadOnly = false;
				colvarLotId.DefaultSetting = @"";
				colvarLotId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLotId);
				
				TableSchema.TableColumn colvarOperatorX = new TableSchema.TableColumn(schema);
				colvarOperatorX.ColumnName = "Operator";
				colvarOperatorX.DataType = DbType.String;
				colvarOperatorX.MaxLength = 50;
				colvarOperatorX.AutoIncrement = false;
				colvarOperatorX.IsNullable = true;
				colvarOperatorX.IsPrimaryKey = false;
				colvarOperatorX.IsForeignKey = false;
				colvarOperatorX.IsReadOnly = false;
				colvarOperatorX.DefaultSetting = @"";
				colvarOperatorX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOperatorX);
				
				TableSchema.TableColumn colvarBeginTime = new TableSchema.TableColumn(schema);
				colvarBeginTime.ColumnName = "BeginTime";
				colvarBeginTime.DataType = DbType.DateTime;
				colvarBeginTime.MaxLength = 0;
				colvarBeginTime.AutoIncrement = false;
				colvarBeginTime.IsNullable = true;
				colvarBeginTime.IsPrimaryKey = false;
				colvarBeginTime.IsForeignKey = false;
				colvarBeginTime.IsReadOnly = false;
				colvarBeginTime.DefaultSetting = @"";
				colvarBeginTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBeginTime);
				
				TableSchema.TableColumn colvarLotNumber = new TableSchema.TableColumn(schema);
				colvarLotNumber.ColumnName = "LotNumber";
				colvarLotNumber.DataType = DbType.String;
				colvarLotNumber.MaxLength = 50;
				colvarLotNumber.AutoIncrement = false;
				colvarLotNumber.IsNullable = true;
				colvarLotNumber.IsPrimaryKey = false;
				colvarLotNumber.IsForeignKey = false;
				colvarLotNumber.IsReadOnly = false;
				colvarLotNumber.DefaultSetting = @"";
				colvarLotNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLotNumber);
				
				TableSchema.TableColumn colvarExpirationDate = new TableSchema.TableColumn(schema);
				colvarExpirationDate.ColumnName = "ExpirationDate";
				colvarExpirationDate.DataType = DbType.DateTime;
				colvarExpirationDate.MaxLength = 0;
				colvarExpirationDate.AutoIncrement = false;
				colvarExpirationDate.IsNullable = true;
				colvarExpirationDate.IsPrimaryKey = false;
				colvarExpirationDate.IsForeignKey = false;
				colvarExpirationDate.IsReadOnly = false;
				colvarExpirationDate.DefaultSetting = @"";
				colvarExpirationDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpirationDate);
				
				TableSchema.TableColumn colvarAssayName = new TableSchema.TableColumn(schema);
				colvarAssayName.ColumnName = "AssayName";
				colvarAssayName.DataType = DbType.String;
				colvarAssayName.MaxLength = 100;
				colvarAssayName.AutoIncrement = false;
				colvarAssayName.IsNullable = true;
				colvarAssayName.IsPrimaryKey = false;
				colvarAssayName.IsForeignKey = false;
				colvarAssayName.IsReadOnly = false;
				colvarAssayName.DefaultSetting = @"";
				colvarAssayName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAssayName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 500;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("T_Result_Lot",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("LotId")]
		[Bindable(true)]
		public long LotId 
		{
			get { return GetColumnValue<long>(Columns.LotId); }
			set { SetColumnValue(Columns.LotId, value); }
		}
		  
		[XmlAttribute("OperatorX")]
		[Bindable(true)]
		public string OperatorX 
		{
			get { return GetColumnValue<string>(Columns.OperatorX); }
			set { SetColumnValue(Columns.OperatorX, value); }
		}
		  
		[XmlAttribute("BeginTime")]
		[Bindable(true)]
		public DateTime? BeginTime 
		{
			get { return GetColumnValue<DateTime?>(Columns.BeginTime); }
			set { SetColumnValue(Columns.BeginTime, value); }
		}
		  
		[XmlAttribute("LotNumber")]
		[Bindable(true)]
		public string LotNumber 
		{
			get { return GetColumnValue<string>(Columns.LotNumber); }
			set { SetColumnValue(Columns.LotNumber, value); }
		}
		  
		[XmlAttribute("ExpirationDate")]
		[Bindable(true)]
		public DateTime? ExpirationDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ExpirationDate); }
			set { SetColumnValue(Columns.ExpirationDate, value); }
		}
		  
		[XmlAttribute("AssayName")]
		[Bindable(true)]
		public string AssayName 
		{
			get { return GetColumnValue<string>(Columns.AssayName); }
			set { SetColumnValue(Columns.AssayName, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varOperatorX,DateTime? varBeginTime,string varLotNumber,DateTime? varExpirationDate,string varAssayName,string varDescription)
		{
			TResultLot item = new TResultLot();
			
			item.OperatorX = varOperatorX;
			
			item.BeginTime = varBeginTime;
			
			item.LotNumber = varLotNumber;
			
			item.ExpirationDate = varExpirationDate;
			
			item.AssayName = varAssayName;
			
			item.Description = varDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varLotId,string varOperatorX,DateTime? varBeginTime,string varLotNumber,DateTime? varExpirationDate,string varAssayName,string varDescription)
		{
			TResultLot item = new TResultLot();
			
				item.LotId = varLotId;
			
				item.OperatorX = varOperatorX;
			
				item.BeginTime = varBeginTime;
			
				item.LotNumber = varLotNumber;
			
				item.ExpirationDate = varExpirationDate;
			
				item.AssayName = varAssayName;
			
				item.Description = varDescription;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn LotIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn OperatorXColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn BeginTimeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LotNumberColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ExpirationDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AssayNameColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string LotId = @"LotId";
			 public static string OperatorX = @"Operator";
			 public static string BeginTime = @"BeginTime";
			 public static string LotNumber = @"LotNumber";
			 public static string ExpirationDate = @"ExpirationDate";
			 public static string AssayName = @"AssayName";
			 public static string Description = @"Description";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
