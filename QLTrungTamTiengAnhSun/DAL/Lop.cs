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
	/// Strongly-typed collection for the Lop class.
	/// </summary>
    [Serializable]
	public partial class LopCollection : ActiveList<Lop, LopCollection>
	{	   
		public LopCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LopCollection</returns>
		public LopCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Lop o = this[i];
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
	/// This is an ActiveRecord class which wraps the Lop table.
	/// </summary>
	[Serializable]
	public partial class Lop : ActiveRecord<Lop>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Lop()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Lop(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Lop(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Lop(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Lop", TableType.Table, DataService.GetInstance("QLSUN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdLop = new TableSchema.TableColumn(schema);
				colvarIdLop.ColumnName = "IdLop";
				colvarIdLop.DataType = DbType.Guid;
				colvarIdLop.MaxLength = 0;
				colvarIdLop.AutoIncrement = false;
				colvarIdLop.IsNullable = false;
				colvarIdLop.IsPrimaryKey = true;
				colvarIdLop.IsForeignKey = false;
				colvarIdLop.IsReadOnly = false;
				
						colvarIdLop.DefaultSetting = @"(newid())";
				colvarIdLop.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLop);
				
				TableSchema.TableColumn colvarIdKhoaHoc = new TableSchema.TableColumn(schema);
				colvarIdKhoaHoc.ColumnName = "IdKhoaHoc";
				colvarIdKhoaHoc.DataType = DbType.Guid;
				colvarIdKhoaHoc.MaxLength = 0;
				colvarIdKhoaHoc.AutoIncrement = false;
				colvarIdKhoaHoc.IsNullable = false;
				colvarIdKhoaHoc.IsPrimaryKey = false;
				colvarIdKhoaHoc.IsForeignKey = true;
				colvarIdKhoaHoc.IsReadOnly = false;
				colvarIdKhoaHoc.DefaultSetting = @"";
				
					colvarIdKhoaHoc.ForeignKeyTableName = "KhoaHoc";
				schema.Columns.Add(colvarIdKhoaHoc);
				
				TableSchema.TableColumn colvarTenLop = new TableSchema.TableColumn(schema);
				colvarTenLop.ColumnName = "TenLop";
				colvarTenLop.DataType = DbType.String;
				colvarTenLop.MaxLength = 50;
				colvarTenLop.AutoIncrement = false;
				colvarTenLop.IsNullable = true;
				colvarTenLop.IsPrimaryKey = false;
				colvarTenLop.IsForeignKey = false;
				colvarTenLop.IsReadOnly = false;
				colvarTenLop.DefaultSetting = @"";
				colvarTenLop.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTenLop);
				
				TableSchema.TableColumn colvarSoBuoiHoc = new TableSchema.TableColumn(schema);
				colvarSoBuoiHoc.ColumnName = "SoBuoiHoc";
				colvarSoBuoiHoc.DataType = DbType.Int32;
				colvarSoBuoiHoc.MaxLength = 0;
				colvarSoBuoiHoc.AutoIncrement = false;
				colvarSoBuoiHoc.IsNullable = true;
				colvarSoBuoiHoc.IsPrimaryKey = false;
				colvarSoBuoiHoc.IsForeignKey = false;
				colvarSoBuoiHoc.IsReadOnly = false;
				colvarSoBuoiHoc.DefaultSetting = @"";
				colvarSoBuoiHoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSoBuoiHoc);
				
				TableSchema.TableColumn colvarThoiGianBatDau = new TableSchema.TableColumn(schema);
				colvarThoiGianBatDau.ColumnName = "ThoiGianBatDau";
				colvarThoiGianBatDau.DataType = DbType.DateTime;
				colvarThoiGianBatDau.MaxLength = 0;
				colvarThoiGianBatDau.AutoIncrement = false;
				colvarThoiGianBatDau.IsNullable = false;
				colvarThoiGianBatDau.IsPrimaryKey = false;
				colvarThoiGianBatDau.IsForeignKey = false;
				colvarThoiGianBatDau.IsReadOnly = false;
				colvarThoiGianBatDau.DefaultSetting = @"";
				colvarThoiGianBatDau.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThoiGianBatDau);
				
				TableSchema.TableColumn colvarThoiGianKetThuc = new TableSchema.TableColumn(schema);
				colvarThoiGianKetThuc.ColumnName = "ThoiGianKetThuc";
				colvarThoiGianKetThuc.DataType = DbType.DateTime;
				colvarThoiGianKetThuc.MaxLength = 0;
				colvarThoiGianKetThuc.AutoIncrement = false;
				colvarThoiGianKetThuc.IsNullable = false;
				colvarThoiGianKetThuc.IsPrimaryKey = false;
				colvarThoiGianKetThuc.IsForeignKey = false;
				colvarThoiGianKetThuc.IsReadOnly = false;
				colvarThoiGianKetThuc.DefaultSetting = @"";
				colvarThoiGianKetThuc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThoiGianKetThuc);
				
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
				
				TableSchema.TableColumn colvarHocVienToiDa = new TableSchema.TableColumn(schema);
				colvarHocVienToiDa.ColumnName = "HocVienToiDa";
				colvarHocVienToiDa.DataType = DbType.Int32;
				colvarHocVienToiDa.MaxLength = 0;
				colvarHocVienToiDa.AutoIncrement = false;
				colvarHocVienToiDa.IsNullable = true;
				colvarHocVienToiDa.IsPrimaryKey = false;
				colvarHocVienToiDa.IsForeignKey = false;
				colvarHocVienToiDa.IsReadOnly = false;
				colvarHocVienToiDa.DefaultSetting = @"";
				colvarHocVienToiDa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHocVienToiDa);
				
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
				
				TableSchema.TableColumn colvarHocPhiLop = new TableSchema.TableColumn(schema);
				colvarHocPhiLop.ColumnName = "HocPhiLop";
				colvarHocPhiLop.DataType = DbType.Decimal;
				colvarHocPhiLop.MaxLength = 0;
				colvarHocPhiLop.AutoIncrement = false;
				colvarHocPhiLop.IsNullable = true;
				colvarHocPhiLop.IsPrimaryKey = false;
				colvarHocPhiLop.IsForeignKey = false;
				colvarHocPhiLop.IsReadOnly = false;
				colvarHocPhiLop.DefaultSetting = @"";
				colvarHocPhiLop.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHocPhiLop);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["QLSUN"].AddSchema("Lop",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdLop")]
		[Bindable(true)]
		public Guid IdLop 
		{
			get { return GetColumnValue<Guid>(Columns.IdLop); }
			set { SetColumnValue(Columns.IdLop, value); }
		}
		  
		[XmlAttribute("IdKhoaHoc")]
		[Bindable(true)]
		public Guid IdKhoaHoc 
		{
			get { return GetColumnValue<Guid>(Columns.IdKhoaHoc); }
			set { SetColumnValue(Columns.IdKhoaHoc, value); }
		}
		  
		[XmlAttribute("TenLop")]
		[Bindable(true)]
		public string TenLop 
		{
			get { return GetColumnValue<string>(Columns.TenLop); }
			set { SetColumnValue(Columns.TenLop, value); }
		}
		  
		[XmlAttribute("SoBuoiHoc")]
		[Bindable(true)]
		public int? SoBuoiHoc 
		{
			get { return GetColumnValue<int?>(Columns.SoBuoiHoc); }
			set { SetColumnValue(Columns.SoBuoiHoc, value); }
		}
		  
		[XmlAttribute("ThoiGianBatDau")]
		[Bindable(true)]
		public DateTime ThoiGianBatDau 
		{
			get { return GetColumnValue<DateTime>(Columns.ThoiGianBatDau); }
			set { SetColumnValue(Columns.ThoiGianBatDau, value); }
		}
		  
		[XmlAttribute("ThoiGianKetThuc")]
		[Bindable(true)]
		public DateTime ThoiGianKetThuc 
		{
			get { return GetColumnValue<DateTime>(Columns.ThoiGianKetThuc); }
			set { SetColumnValue(Columns.ThoiGianKetThuc, value); }
		}
		  
		[XmlAttribute("TrangThai")]
		[Bindable(true)]
		public string TrangThai 
		{
			get { return GetColumnValue<string>(Columns.TrangThai); }
			set { SetColumnValue(Columns.TrangThai, value); }
		}
		  
		[XmlAttribute("HocVienToiDa")]
		[Bindable(true)]
		public int? HocVienToiDa 
		{
			get { return GetColumnValue<int?>(Columns.HocVienToiDa); }
			set { SetColumnValue(Columns.HocVienToiDa, value); }
		}
		  
		[XmlAttribute("GhiChu")]
		[Bindable(true)]
		public string GhiChu 
		{
			get { return GetColumnValue<string>(Columns.GhiChu); }
			set { SetColumnValue(Columns.GhiChu, value); }
		}
		  
		[XmlAttribute("HocPhiLop")]
		[Bindable(true)]
		public decimal? HocPhiLop 
		{
			get { return GetColumnValue<decimal?>(Columns.HocPhiLop); }
			set { SetColumnValue(Columns.HocPhiLop, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public Public.LichGiangDayCollection LichGiangDayRecords()
		{
			return new Public.LichGiangDayCollection().Where(LichGiangDay.Columns.IdLop, IdLop).Load();
		}
		public Public.NhapHocCollection NhapHocRecords()
		{
			return new Public.NhapHocCollection().Where(NhapHoc.Columns.IdLop, IdLop).Load();
		}
		public Public.ThongBaoLopCollection ThongBaoLopRecords()
		{
			return new Public.ThongBaoLopCollection().Where(ThongBaoLop.Columns.IdLop, IdLop).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a KhoaHoc ActiveRecord object related to this Lop
		/// 
		/// </summary>
		public Public.KhoaHoc KhoaHoc
		{
			get { return Public.KhoaHoc.FetchByID(this.IdKhoaHoc); }
			set { SetColumnValue("IdKhoaHoc", value.IdKhoaHoc); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varIdLop,Guid varIdKhoaHoc,string varTenLop,int? varSoBuoiHoc,DateTime varThoiGianBatDau,DateTime varThoiGianKetThuc,string varTrangThai,int? varHocVienToiDa,string varGhiChu,decimal? varHocPhiLop)
		{
			Lop item = new Lop();
			
			item.IdLop = varIdLop;
			
			item.IdKhoaHoc = varIdKhoaHoc;
			
			item.TenLop = varTenLop;
			
			item.SoBuoiHoc = varSoBuoiHoc;
			
			item.ThoiGianBatDau = varThoiGianBatDau;
			
			item.ThoiGianKetThuc = varThoiGianKetThuc;
			
			item.TrangThai = varTrangThai;
			
			item.HocVienToiDa = varHocVienToiDa;
			
			item.GhiChu = varGhiChu;
			
			item.HocPhiLop = varHocPhiLop;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varIdLop,Guid varIdKhoaHoc,string varTenLop,int? varSoBuoiHoc,DateTime varThoiGianBatDau,DateTime varThoiGianKetThuc,string varTrangThai,int? varHocVienToiDa,string varGhiChu,decimal? varHocPhiLop)
		{
			Lop item = new Lop();
			
				item.IdLop = varIdLop;
			
				item.IdKhoaHoc = varIdKhoaHoc;
			
				item.TenLop = varTenLop;
			
				item.SoBuoiHoc = varSoBuoiHoc;
			
				item.ThoiGianBatDau = varThoiGianBatDau;
			
				item.ThoiGianKetThuc = varThoiGianKetThuc;
			
				item.TrangThai = varTrangThai;
			
				item.HocVienToiDa = varHocVienToiDa;
			
				item.GhiChu = varGhiChu;
			
				item.HocPhiLop = varHocPhiLop;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdLopColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdKhoaHocColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TenLopColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SoBuoiHocColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ThoiGianBatDauColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ThoiGianKetThucColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TrangThaiColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn HocVienToiDaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn GhiChuColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn HocPhiLopColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdLop = @"IdLop";
			 public static string IdKhoaHoc = @"IdKhoaHoc";
			 public static string TenLop = @"TenLop";
			 public static string SoBuoiHoc = @"SoBuoiHoc";
			 public static string ThoiGianBatDau = @"ThoiGianBatDau";
			 public static string ThoiGianKetThuc = @"ThoiGianKetThuc";
			 public static string TrangThai = @"TrangThai";
			 public static string HocVienToiDa = @"HocVienToiDa";
			 public static string GhiChu = @"GhiChu";
			 public static string HocPhiLop = @"HocPhiLop";
						
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
