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
	/// Strongly-typed collection for the ThongBaoGiaoVien class.
	/// </summary>
    [Serializable]
	public partial class ThongBaoGiaoVienCollection : ActiveList<ThongBaoGiaoVien, ThongBaoGiaoVienCollection>
	{	   
		public ThongBaoGiaoVienCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ThongBaoGiaoVienCollection</returns>
		public ThongBaoGiaoVienCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ThongBaoGiaoVien o = this[i];
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
	/// This is an ActiveRecord class which wraps the ThongBaoGiaoVien table.
	/// </summary>
	[Serializable]
	public partial class ThongBaoGiaoVien : ActiveRecord<ThongBaoGiaoVien>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ThongBaoGiaoVien()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ThongBaoGiaoVien(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ThongBaoGiaoVien(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ThongBaoGiaoVien(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ThongBaoGiaoVien", TableType.Table, DataService.GetInstance("QLSUN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Guid;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				
						colvarId.DefaultSetting = @"(newid())";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdGiaoVien = new TableSchema.TableColumn(schema);
				colvarIdGiaoVien.ColumnName = "IdGiaoVien";
				colvarIdGiaoVien.DataType = DbType.Guid;
				colvarIdGiaoVien.MaxLength = 0;
				colvarIdGiaoVien.AutoIncrement = false;
				colvarIdGiaoVien.IsNullable = false;
				colvarIdGiaoVien.IsPrimaryKey = false;
				colvarIdGiaoVien.IsForeignKey = true;
				colvarIdGiaoVien.IsReadOnly = false;
				colvarIdGiaoVien.DefaultSetting = @"";
				
					colvarIdGiaoVien.ForeignKeyTableName = "GiaoVien";
				schema.Columns.Add(colvarIdGiaoVien);
				
				TableSchema.TableColumn colvarTieuDe = new TableSchema.TableColumn(schema);
				colvarTieuDe.ColumnName = "TieuDe";
				colvarTieuDe.DataType = DbType.String;
				colvarTieuDe.MaxLength = 100;
				colvarTieuDe.AutoIncrement = false;
				colvarTieuDe.IsNullable = true;
				colvarTieuDe.IsPrimaryKey = false;
				colvarTieuDe.IsForeignKey = false;
				colvarTieuDe.IsReadOnly = false;
				colvarTieuDe.DefaultSetting = @"";
				colvarTieuDe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTieuDe);
				
				TableSchema.TableColumn colvarNoiDung = new TableSchema.TableColumn(schema);
				colvarNoiDung.ColumnName = "NoiDung";
				colvarNoiDung.DataType = DbType.String;
				colvarNoiDung.MaxLength = 1073741823;
				colvarNoiDung.AutoIncrement = false;
				colvarNoiDung.IsNullable = true;
				colvarNoiDung.IsPrimaryKey = false;
				colvarNoiDung.IsForeignKey = false;
				colvarNoiDung.IsReadOnly = false;
				colvarNoiDung.DefaultSetting = @"";
				colvarNoiDung.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNoiDung);
				
				TableSchema.TableColumn colvarThoiGian = new TableSchema.TableColumn(schema);
				colvarThoiGian.ColumnName = "ThoiGian";
				colvarThoiGian.DataType = DbType.DateTime;
				colvarThoiGian.MaxLength = 0;
				colvarThoiGian.AutoIncrement = false;
				colvarThoiGian.IsNullable = false;
				colvarThoiGian.IsPrimaryKey = false;
				colvarThoiGian.IsForeignKey = false;
				colvarThoiGian.IsReadOnly = false;
				colvarThoiGian.DefaultSetting = @"";
				colvarThoiGian.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThoiGian);
				
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
				DataService.Providers["QLSUN"].AddSchema("ThongBaoGiaoVien",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public Guid Id 
		{
			get { return GetColumnValue<Guid>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdGiaoVien")]
		[Bindable(true)]
		public Guid IdGiaoVien 
		{
			get { return GetColumnValue<Guid>(Columns.IdGiaoVien); }
			set { SetColumnValue(Columns.IdGiaoVien, value); }
		}
		  
		[XmlAttribute("TieuDe")]
		[Bindable(true)]
		public string TieuDe 
		{
			get { return GetColumnValue<string>(Columns.TieuDe); }
			set { SetColumnValue(Columns.TieuDe, value); }
		}
		  
		[XmlAttribute("NoiDung")]
		[Bindable(true)]
		public string NoiDung 
		{
			get { return GetColumnValue<string>(Columns.NoiDung); }
			set { SetColumnValue(Columns.NoiDung, value); }
		}
		  
		[XmlAttribute("ThoiGian")]
		[Bindable(true)]
		public DateTime ThoiGian 
		{
			get { return GetColumnValue<DateTime>(Columns.ThoiGian); }
			set { SetColumnValue(Columns.ThoiGian, value); }
		}
		  
		[XmlAttribute("TrangThai")]
		[Bindable(true)]
		public string TrangThai 
		{
			get { return GetColumnValue<string>(Columns.TrangThai); }
			set { SetColumnValue(Columns.TrangThai, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a GiaoVien ActiveRecord object related to this ThongBaoGiaoVien
		/// 
		/// </summary>
		public Public.GiaoVien GiaoVien
		{
			get { return Public.GiaoVien.FetchByID(this.IdGiaoVien); }
			set { SetColumnValue("IdGiaoVien", value.IdGiaoVien); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,Guid varIdGiaoVien,string varTieuDe,string varNoiDung,DateTime varThoiGian,string varTrangThai)
		{
			ThongBaoGiaoVien item = new ThongBaoGiaoVien();
			
			item.Id = varId;
			
			item.IdGiaoVien = varIdGiaoVien;
			
			item.TieuDe = varTieuDe;
			
			item.NoiDung = varNoiDung;
			
			item.ThoiGian = varThoiGian;
			
			item.TrangThai = varTrangThai;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varId,Guid varIdGiaoVien,string varTieuDe,string varNoiDung,DateTime varThoiGian,string varTrangThai)
		{
			ThongBaoGiaoVien item = new ThongBaoGiaoVien();
			
				item.Id = varId;
			
				item.IdGiaoVien = varIdGiaoVien;
			
				item.TieuDe = varTieuDe;
			
				item.NoiDung = varNoiDung;
			
				item.ThoiGian = varThoiGian;
			
				item.TrangThai = varTrangThai;
			
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
        
        
        
        public static TableSchema.TableColumn IdGiaoVienColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TieuDeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NoiDungColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ThoiGianColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TrangThaiColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string IdGiaoVien = @"IdGiaoVien";
			 public static string TieuDe = @"TieuDe";
			 public static string NoiDung = @"NoiDung";
			 public static string ThoiGian = @"ThoiGian";
			 public static string TrangThai = @"TrangThai";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
