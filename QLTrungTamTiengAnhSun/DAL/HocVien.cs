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
	/// Strongly-typed collection for the HocVien class.
	/// </summary>
    [Serializable]
	public partial class HocVienCollection : ActiveList<HocVien, HocVienCollection>
	{	   
		public HocVienCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>HocVienCollection</returns>
		public HocVienCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                HocVien o = this[i];
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
	/// This is an ActiveRecord class which wraps the HocVien table.
	/// </summary>
	[Serializable]
	public partial class HocVien : ActiveRecord<HocVien>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public HocVien()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public HocVien(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public HocVien(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public HocVien(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("HocVien", TableType.Table, DataService.GetInstance("QLSUN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdHocVien = new TableSchema.TableColumn(schema);
				colvarIdHocVien.ColumnName = "IdHocVien";
				colvarIdHocVien.DataType = DbType.Guid;
				colvarIdHocVien.MaxLength = 0;
				colvarIdHocVien.AutoIncrement = false;
				colvarIdHocVien.IsNullable = false;
				colvarIdHocVien.IsPrimaryKey = true;
				colvarIdHocVien.IsForeignKey = false;
				colvarIdHocVien.IsReadOnly = false;
				
						colvarIdHocVien.DefaultSetting = @"(newid())";
				colvarIdHocVien.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdHocVien);
				
				TableSchema.TableColumn colvarHoTen = new TableSchema.TableColumn(schema);
				colvarHoTen.ColumnName = "HoTen";
				colvarHoTen.DataType = DbType.String;
				colvarHoTen.MaxLength = 50;
				colvarHoTen.AutoIncrement = false;
				colvarHoTen.IsNullable = true;
				colvarHoTen.IsPrimaryKey = false;
				colvarHoTen.IsForeignKey = false;
				colvarHoTen.IsReadOnly = false;
				colvarHoTen.DefaultSetting = @"";
				colvarHoTen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHoTen);
				
				TableSchema.TableColumn colvarNamSinh = new TableSchema.TableColumn(schema);
				colvarNamSinh.ColumnName = "NamSinh";
				colvarNamSinh.DataType = DbType.DateTime;
				colvarNamSinh.MaxLength = 0;
				colvarNamSinh.AutoIncrement = false;
				colvarNamSinh.IsNullable = false;
				colvarNamSinh.IsPrimaryKey = false;
				colvarNamSinh.IsForeignKey = false;
				colvarNamSinh.IsReadOnly = false;
				colvarNamSinh.DefaultSetting = @"";
				colvarNamSinh.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNamSinh);
				
				TableSchema.TableColumn colvarSdt = new TableSchema.TableColumn(schema);
				colvarSdt.ColumnName = "SDT";
				colvarSdt.DataType = DbType.AnsiString;
				colvarSdt.MaxLength = 15;
				colvarSdt.AutoIncrement = false;
				colvarSdt.IsNullable = true;
				colvarSdt.IsPrimaryKey = false;
				colvarSdt.IsForeignKey = false;
				colvarSdt.IsReadOnly = false;
				colvarSdt.DefaultSetting = @"";
				colvarSdt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSdt);
				
				TableSchema.TableColumn colvarFaceBook = new TableSchema.TableColumn(schema);
				colvarFaceBook.ColumnName = "FaceBook";
				colvarFaceBook.DataType = DbType.String;
				colvarFaceBook.MaxLength = 50;
				colvarFaceBook.AutoIncrement = false;
				colvarFaceBook.IsNullable = true;
				colvarFaceBook.IsPrimaryKey = false;
				colvarFaceBook.IsForeignKey = false;
				colvarFaceBook.IsReadOnly = false;
				colvarFaceBook.DefaultSetting = @"";
				colvarFaceBook.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFaceBook);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "Email";
				colvarEmail.DataType = DbType.AnsiString;
				colvarEmail.MaxLength = 50;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = true;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarDiaChi = new TableSchema.TableColumn(schema);
				colvarDiaChi.ColumnName = "DiaChi";
				colvarDiaChi.DataType = DbType.String;
				colvarDiaChi.MaxLength = 100;
				colvarDiaChi.AutoIncrement = false;
				colvarDiaChi.IsNullable = true;
				colvarDiaChi.IsPrimaryKey = false;
				colvarDiaChi.IsForeignKey = false;
				colvarDiaChi.IsReadOnly = false;
				colvarDiaChi.DefaultSetting = @"";
				colvarDiaChi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiaChi);
				
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
				
				TableSchema.TableColumn colvarGioiTinh = new TableSchema.TableColumn(schema);
				colvarGioiTinh.ColumnName = "GioiTinh";
				colvarGioiTinh.DataType = DbType.String;
				colvarGioiTinh.MaxLength = 5;
				colvarGioiTinh.AutoIncrement = false;
				colvarGioiTinh.IsNullable = true;
				colvarGioiTinh.IsPrimaryKey = false;
				colvarGioiTinh.IsForeignKey = false;
				colvarGioiTinh.IsReadOnly = false;
				colvarGioiTinh.DefaultSetting = @"";
				colvarGioiTinh.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGioiTinh);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["QLSUN"].AddSchema("HocVien",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdHocVien")]
		[Bindable(true)]
		public Guid IdHocVien 
		{
			get { return GetColumnValue<Guid>(Columns.IdHocVien); }
			set { SetColumnValue(Columns.IdHocVien, value); }
		}
		  
		[XmlAttribute("HoTen")]
		[Bindable(true)]
		public string HoTen 
		{
			get { return GetColumnValue<string>(Columns.HoTen); }
			set { SetColumnValue(Columns.HoTen, value); }
		}
		  
		[XmlAttribute("NamSinh")]
		[Bindable(true)]
		public DateTime NamSinh 
		{
			get { return GetColumnValue<DateTime>(Columns.NamSinh); }
			set { SetColumnValue(Columns.NamSinh, value); }
		}
		  
		[XmlAttribute("Sdt")]
		[Bindable(true)]
		public string Sdt 
		{
			get { return GetColumnValue<string>(Columns.Sdt); }
			set { SetColumnValue(Columns.Sdt, value); }
		}
		  
		[XmlAttribute("FaceBook")]
		[Bindable(true)]
		public string FaceBook 
		{
			get { return GetColumnValue<string>(Columns.FaceBook); }
			set { SetColumnValue(Columns.FaceBook, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("DiaChi")]
		[Bindable(true)]
		public string DiaChi 
		{
			get { return GetColumnValue<string>(Columns.DiaChi); }
			set { SetColumnValue(Columns.DiaChi, value); }
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
		  
		[XmlAttribute("GioiTinh")]
		[Bindable(true)]
		public string GioiTinh 
		{
			get { return GetColumnValue<string>(Columns.GioiTinh); }
			set { SetColumnValue(Columns.GioiTinh, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public Public.KetQuaTuyenSinhCollection KetQuaTuyenSinhRecords()
		{
			return new Public.KetQuaTuyenSinhCollection().Where(KetQuaTuyenSinh.Columns.IdHocVien, IdHocVien).Load();
		}
		public Public.NguoiDungHocVienCollection NguoiDungHocVienRecords()
		{
			return new Public.NguoiDungHocVienCollection().Where(NguoiDungHocVien.Columns.IdHocVien, IdHocVien).Load();
		}
		public Public.NhapHocCollection NhapHocRecords()
		{
			return new Public.NhapHocCollection().Where(NhapHoc.Columns.IdHocVien, IdHocVien).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varIdHocVien,string varHoTen,DateTime varNamSinh,string varSdt,string varFaceBook,string varEmail,string varDiaChi,string varGhiChu,string varTrangThai,string varGioiTinh)
		{
			HocVien item = new HocVien();
			
			item.IdHocVien = varIdHocVien;
			
			item.HoTen = varHoTen;
			
			item.NamSinh = varNamSinh;
			
			item.Sdt = varSdt;
			
			item.FaceBook = varFaceBook;
			
			item.Email = varEmail;
			
			item.DiaChi = varDiaChi;
			
			item.GhiChu = varGhiChu;
			
			item.TrangThai = varTrangThai;
			
			item.GioiTinh = varGioiTinh;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varIdHocVien,string varHoTen,DateTime varNamSinh,string varSdt,string varFaceBook,string varEmail,string varDiaChi,string varGhiChu,string varTrangThai,string varGioiTinh)
		{
			HocVien item = new HocVien();
			
				item.IdHocVien = varIdHocVien;
			
				item.HoTen = varHoTen;
			
				item.NamSinh = varNamSinh;
			
				item.Sdt = varSdt;
			
				item.FaceBook = varFaceBook;
			
				item.Email = varEmail;
			
				item.DiaChi = varDiaChi;
			
				item.GhiChu = varGhiChu;
			
				item.TrangThai = varTrangThai;
			
				item.GioiTinh = varGioiTinh;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdHocVienColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn HoTenColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NamSinhColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SdtColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FaceBookColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DiaChiColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn GhiChuColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TrangThaiColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn GioiTinhColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdHocVien = @"IdHocVien";
			 public static string HoTen = @"HoTen";
			 public static string NamSinh = @"NamSinh";
			 public static string Sdt = @"SDT";
			 public static string FaceBook = @"FaceBook";
			 public static string Email = @"Email";
			 public static string DiaChi = @"DiaChi";
			 public static string GhiChu = @"GhiChu";
			 public static string TrangThai = @"TrangThai";
			 public static string GioiTinh = @"GioiTinh";
						
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
