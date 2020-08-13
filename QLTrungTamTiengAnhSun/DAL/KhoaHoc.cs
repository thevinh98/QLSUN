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
namespace Public
{
	/// <summary>
	/// Strongly-typed collection for the KhoaHoc class.
	/// </summary>
    [Serializable]
	public partial class KhoaHocCollection : ActiveList<KhoaHoc, KhoaHocCollection>
	{	   
		public KhoaHocCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>KhoaHocCollection</returns>
		public KhoaHocCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                KhoaHoc o = this[i];
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
	/// This is an ActiveRecord class which wraps the KhoaHoc table.
	/// </summary>
	[Serializable]
	public partial class KhoaHoc : ActiveRecord<KhoaHoc>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public KhoaHoc()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public KhoaHoc(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public KhoaHoc(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public KhoaHoc(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("KhoaHoc", TableType.Table, DataService.GetInstance("QLSUN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdKhoaHoc = new TableSchema.TableColumn(schema);
				colvarIdKhoaHoc.ColumnName = "IdKhoaHoc";
				colvarIdKhoaHoc.DataType = DbType.Guid;
				colvarIdKhoaHoc.MaxLength = 0;
				colvarIdKhoaHoc.AutoIncrement = false;
				colvarIdKhoaHoc.IsNullable = false;
				colvarIdKhoaHoc.IsPrimaryKey = true;
				colvarIdKhoaHoc.IsForeignKey = false;
				colvarIdKhoaHoc.IsReadOnly = false;
				
						colvarIdKhoaHoc.DefaultSetting = @"(newid())";
				colvarIdKhoaHoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdKhoaHoc);
				
				TableSchema.TableColumn colvarTenKhoaHoc = new TableSchema.TableColumn(schema);
				colvarTenKhoaHoc.ColumnName = "TenKhoaHoc";
				colvarTenKhoaHoc.DataType = DbType.String;
				colvarTenKhoaHoc.MaxLength = 50;
				colvarTenKhoaHoc.AutoIncrement = false;
				colvarTenKhoaHoc.IsNullable = true;
				colvarTenKhoaHoc.IsPrimaryKey = false;
				colvarTenKhoaHoc.IsForeignKey = false;
				colvarTenKhoaHoc.IsReadOnly = false;
				colvarTenKhoaHoc.DefaultSetting = @"";
				colvarTenKhoaHoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTenKhoaHoc);
				
				TableSchema.TableColumn colvarGhiChu = new TableSchema.TableColumn(schema);
				colvarGhiChu.ColumnName = "GhiChu";
				colvarGhiChu.DataType = DbType.String;
				colvarGhiChu.MaxLength = 1073741823;
				colvarGhiChu.AutoIncrement = false;
				colvarGhiChu.IsNullable = true;
				colvarGhiChu.IsPrimaryKey = false;
				colvarGhiChu.IsForeignKey = false;
				colvarGhiChu.IsReadOnly = false;
				colvarGhiChu.DefaultSetting = @"";
				colvarGhiChu.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGhiChu);
				
				TableSchema.TableColumn colvarTrangThai = new TableSchema.TableColumn(schema);
				colvarTrangThai.ColumnName = "TrangThai";
				colvarTrangThai.DataType = DbType.String;
				colvarTrangThai.MaxLength = 20;
				colvarTrangThai.AutoIncrement = false;
				colvarTrangThai.IsNullable = true;
				colvarTrangThai.IsPrimaryKey = false;
				colvarTrangThai.IsForeignKey = false;
				colvarTrangThai.IsReadOnly = false;
				colvarTrangThai.DefaultSetting = @"";
				colvarTrangThai.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrangThai);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["QLSUN"].AddSchema("KhoaHoc",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdKhoaHoc")]
		[Bindable(true)]
		public Guid IdKhoaHoc 
		{
			get { return GetColumnValue<Guid>(Columns.IdKhoaHoc); }
			set { SetColumnValue(Columns.IdKhoaHoc, value); }
		}
		  
		[XmlAttribute("TenKhoaHoc")]
		[Bindable(true)]
		public string TenKhoaHoc 
		{
			get { return GetColumnValue<string>(Columns.TenKhoaHoc); }
			set { SetColumnValue(Columns.TenKhoaHoc, value); }
		}
		  
		[XmlAttribute("GhiChu")]
		[Bindable(true)]
		public string GhiChu 
		{
			get { return GetColumnValue<string>(Columns.GhiChu); }
			set { SetColumnValue(Columns.GhiChu, value); }
		}
		  
		[XmlAttribute("TrangThai")]
		[Bindable(true)]
		public string TrangThai 
		{
			get { return GetColumnValue<string>(Columns.TrangThai); }
			set { SetColumnValue(Columns.TrangThai, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public Public.LopCollection LopRecords()
		{
			return new Public.LopCollection().Where(Lop.Columns.IdKhoaHoc, IdKhoaHoc).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varIdKhoaHoc,string varTenKhoaHoc,string varGhiChu,string varTrangThai)
		{
			KhoaHoc item = new KhoaHoc();
			
			item.IdKhoaHoc = varIdKhoaHoc;
			
			item.TenKhoaHoc = varTenKhoaHoc;
			
			item.GhiChu = varGhiChu;
			
			item.TrangThai = varTrangThai;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varIdKhoaHoc,string varTenKhoaHoc,string varGhiChu,string varTrangThai)
		{
			KhoaHoc item = new KhoaHoc();
			
				item.IdKhoaHoc = varIdKhoaHoc;
			
				item.TenKhoaHoc = varTenKhoaHoc;
			
				item.GhiChu = varGhiChu;
			
				item.TrangThai = varTrangThai;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdKhoaHocColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TenKhoaHocColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn GhiChuColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TrangThaiColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdKhoaHoc = @"IdKhoaHoc";
			 public static string TenKhoaHoc = @"TenKhoaHoc";
			 public static string GhiChu = @"GhiChu";
			 public static string TrangThai = @"TrangThai";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
