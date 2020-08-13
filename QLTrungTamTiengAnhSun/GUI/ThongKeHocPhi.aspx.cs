using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Public;
using BLL;

namespace GUI
{
    public partial class ThongKeHocPhi : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div_ThongKeHocPhi.Visible = false;
        }

        protected void ThongKe_HocPhi_Click(object sender, EventArgs e)
        {

            String a = txt_thoigianbatdau.Text.Trim();
            String b = txt_thoigianketthuc.Text;
            List<HocPhi> lst = HocPhiBLL.ThongKeHocPhi(a,b);
            
            Gr_View.DataSource = lst;
            Gr_View.DataBind();
            div_ThongKeHocPhi.Visible = true;               
        }
    }
}