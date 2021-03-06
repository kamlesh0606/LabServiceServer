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
	/// Strongly-typed collection for the LHisDichvu class.
	/// </summary>
    [Serializable]
	public partial class LHisDichvuCollection : ActiveList<LHisDichvu, LHisDichvuCollection>
	{	   
		public LHisDichvuCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LHisDichvuCollection</returns>
		public LHisDichvuCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LHisDichvu o = this[i];
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
	/// This is an ActiveRecord class which wraps the L_HIS_DICHVU table.
	/// </summary>
	[Serializable]
	public partial class LHisDichvu : ActiveRecord<LHisDichvu>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LHisDichvu()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LHisDichvu(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LHisDichvu(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LHisDichvu(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("L_HIS_DICHVU", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdDichVu = new TableSchema.TableColumn(schema);
				colvarIdDichVu.ColumnName = "ID_DichVu";
				colvarIdDichVu.DataType = DbType.Int32;
				colvarIdDichVu.MaxLength = 0;
				colvarIdDichVu.AutoIncrement = false;
				colvarIdDichVu.IsNullable = true;
				colvarIdDichVu.IsPrimaryKey = false;
				colvarIdDichVu.IsForeignKey = false;
				colvarIdDichVu.IsReadOnly = false;
				colvarIdDichVu.DefaultSetting = @"";
				colvarIdDichVu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdDichVu);
				
				TableSchema.TableColumn colvarTenDv = new TableSchema.TableColumn(schema);
				colvarTenDv.ColumnName = "Ten_DV";
				colvarTenDv.DataType = DbType.String;
				colvarTenDv.MaxLength = 500;
				colvarTenDv.AutoIncrement = false;
				colvarTenDv.IsNullable = true;
				colvarTenDv.IsPrimaryKey = false;
				colvarTenDv.IsForeignKey = false;
				colvarTenDv.IsReadOnly = false;
				colvarTenDv.DefaultSetting = @"";
				colvarTenDv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTenDv);
				
				TableSchema.TableColumn colvarIdNhom = new TableSchema.TableColumn(schema);
				colvarIdNhom.ColumnName = "ID_Nhom";
				colvarIdNhom.DataType = DbType.Int32;
				colvarIdNhom.MaxLength = 0;
				colvarIdNhom.AutoIncrement = false;
				colvarIdNhom.IsNullable = true;
				colvarIdNhom.IsPrimaryKey = false;
				colvarIdNhom.IsForeignKey = false;
				colvarIdNhom.IsReadOnly = false;
				colvarIdNhom.DefaultSetting = @"";
				colvarIdNhom.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdNhom);
				
				TableSchema.TableColumn colvarLaTriSo = new TableSchema.TableColumn(schema);
				colvarLaTriSo.ColumnName = "La_TriSo";
				colvarLaTriSo.DataType = DbType.Int32;
				colvarLaTriSo.MaxLength = 0;
				colvarLaTriSo.AutoIncrement = false;
				colvarLaTriSo.IsNullable = true;
				colvarLaTriSo.IsPrimaryKey = false;
				colvarLaTriSo.IsForeignKey = false;
				colvarLaTriSo.IsReadOnly = false;
				colvarLaTriSo.DefaultSetting = @"";
				colvarLaTriSo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLaTriSo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("L_HIS_DICHVU",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdDichVu")]
		[Bindable(true)]
		public int? IdDichVu 
		{
			get { return GetColumnValue<int?>(Columns.IdDichVu); }
			set { SetColumnValue(Columns.IdDichVu, value); }
		}
		  
		[XmlAttribute("TenDv")]
		[Bindable(true)]
		public string TenDv 
		{
			get { return GetColumnValue<string>(Columns.TenDv); }
			set { SetColumnValue(Columns.TenDv, value); }
		}
		  
		[XmlAttribute("IdNhom")]
		[Bindable(true)]
		public int? IdNhom 
		{
			get { return GetColumnValue<int?>(Columns.IdNhom); }
			set { SetColumnValue(Columns.IdNhom, value); }
		}
		  
		[XmlAttribute("LaTriSo")]
		[Bindable(true)]
		public int? LaTriSo 
		{
			get { return GetColumnValue<int?>(Columns.LaTriSo); }
			set { SetColumnValue(Columns.LaTriSo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdDichVu,string varTenDv,int? varIdNhom,int? varLaTriSo)
		{
			LHisDichvu item = new LHisDichvu();
			
			item.IdDichVu = varIdDichVu;
			
			item.TenDv = varTenDv;
			
			item.IdNhom = varIdNhom;
			
			item.LaTriSo = varLaTriSo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdDichVu,string varTenDv,int? varIdNhom,int? varLaTriSo)
		{
			LHisDichvu item = new LHisDichvu();
			
				item.Id = varId;
			
				item.IdDichVu = varIdDichVu;
			
				item.TenDv = varTenDv;
			
				item.IdNhom = varIdNhom;
			
				item.LaTriSo = varLaTriSo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDichVuColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TenDvColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdNhomColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LaTriSoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string IdDichVu = @"ID_DichVu";
			 public static string TenDv = @"Ten_DV";
			 public static string IdNhom = @"ID_Nhom";
			 public static string LaTriSo = @"La_TriSo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
