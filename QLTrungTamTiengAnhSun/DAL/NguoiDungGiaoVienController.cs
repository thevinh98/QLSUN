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
    public partial class NguoiDungGiaoVien
    {
        public string HoTen { get; set; }
    }

    /// <summary>
    /// Controller class for NguoiDungGiaoVien
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class NguoiDungGiaoVienController
    {
        // Preload our schema..
        NguoiDungGiaoVien thisSchemaLoad = new NguoiDungGiaoVien();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public NguoiDungGiaoVienCollection FetchAll()
        {
            NguoiDungGiaoVienCollection coll = new NguoiDungGiaoVienCollection();
            Query qry = new Query(NguoiDungGiaoVien.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public NguoiDungGiaoVienCollection FetchByID(object Id)
        {
            NguoiDungGiaoVienCollection coll = new NguoiDungGiaoVienCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public NguoiDungGiaoVienCollection FetchByQuery(Query qry)
        {
            NguoiDungGiaoVienCollection coll = new NguoiDungGiaoVienCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (NguoiDungGiaoVien.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (NguoiDungGiaoVien.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public NguoiDungGiaoVien Insert(NguoiDungGiaoVien item)
	    {
		   
		    item.Save(UserName);
            return item; 
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public NguoiDungGiaoVien  Update(NguoiDungGiaoVien item)
	    {
		    
	        item.Save(UserName);
            return item;
	    }
    }
}