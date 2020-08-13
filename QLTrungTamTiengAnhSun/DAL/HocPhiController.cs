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
    public partial class HocPhi
    {
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public decimal HocPhiLop { get; set; }
        public string SDT { get; set; }
        public decimal DaDong { get; set; }
        public decimal HocPhiConLai { get; set; }
        public Int32 DemHP { get; set; }
    }

    /// <summary>
    /// Controller class for HocPhi
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class HocPhiController
    {
        // Preload our schema..
        HocPhi thisSchemaLoad = new HocPhi();
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
        public HocPhiCollection FetchAll()
        {
            HocPhiCollection coll = new HocPhiCollection();
            Query qry = new Query(HocPhi.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public HocPhiCollection FetchByID(object Id)
        {
            HocPhiCollection coll = new HocPhiCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public HocPhiCollection FetchByQuery(Query qry)
        {
            HocPhiCollection coll = new HocPhiCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (HocPhi.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (HocPhi.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public HocPhi Insert(HocPhi item)
	    {
		   
		    item.Save(UserName);
            return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public HocPhi Update(HocPhi item)
	    {
		    
	        item.Save(UserName);
            return item;
	    }
    }
}