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
    public partial class LichGiangDay
    {
        public string TrinhDo { get; set; }
        public string TenLop { get; set; }
        public string SoPhong { get; set; }
        public string HoTen { get; set; }
        public string TenGV { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public Guid IdGV { get; set; }
        public string GioiTinh { get; set; }
        public Int32 TongGio { get; set; }
        public Int32 LuongGV { get; set; }
    }

    /// <summary>
    /// Controller class for LichGiangDay
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LichGiangDayController
    {
        // Preload our schema..
        LichGiangDay thisSchemaLoad = new LichGiangDay();
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
        public LichGiangDayCollection FetchAll()
        {
            LichGiangDayCollection coll = new LichGiangDayCollection();
            Query qry = new Query(LichGiangDay.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LichGiangDayCollection FetchByID(object IdLichGiangDay)
        {
            LichGiangDayCollection coll = new LichGiangDayCollection().Where("IdLichGiangDay", IdLichGiangDay).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LichGiangDayCollection FetchByQuery(Query qry)
        {
            LichGiangDayCollection coll = new LichGiangDayCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdLichGiangDay)
        {
            return (LichGiangDay.Delete(IdLichGiangDay) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdLichGiangDay)
        {
            return (LichGiangDay.Destroy(IdLichGiangDay) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public LichGiangDay Insert(LichGiangDay item)
	    {
		    
            
	    
		    item.Save(UserName);
            return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public LichGiangDay Update(LichGiangDay item)
	    {
		   
				
	        item.Save(UserName);
            return item;
	    }
    }
}