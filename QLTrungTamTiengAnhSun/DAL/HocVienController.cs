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
    public partial class HocVien
    {

        public Int32 Tong { get; set; }
    }
    /// <summary>
    /// Controller class for HocVien
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class HocVienController
    {
        // Preload our schema..
        HocVien thisSchemaLoad = new HocVien();
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
        public HocVienCollection FetchAll()
        {
            HocVienCollection coll = new HocVienCollection();
            Query qry = new Query(HocVien.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public HocVienCollection FetchByID(object IdHocVien)
        {
            HocVienCollection coll = new HocVienCollection().Where("IdHocVien", IdHocVien).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public HocVienCollection FetchByQuery(Query qry)
        {
            HocVienCollection coll = new HocVienCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdHocVien)
        {
            return (HocVien.Delete(IdHocVien) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdHocVien)
        {
            return (HocVien.Destroy(IdHocVien) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public HocVien Insert(HocVien item)
	    {
		   
		    item.Save(UserName);
            return item;
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public HocVien Update(HocVien item)
	    {
		    
	        item.Save(UserName);
            return item;
	    }
    }
}
