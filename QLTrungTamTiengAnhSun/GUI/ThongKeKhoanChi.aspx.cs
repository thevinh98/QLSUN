using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;

namespace GUI
{
    public partial class ThongKeKhoanChi : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div_ThongKeThuChi.Visible = false;
        }

        protected void ThongKe_ThuChi_Click(object sender, EventArgs e)
        {
            String a = txt_thoigianbatdau.Text.Trim();
            String b = txt_thoigianketthuc.Text;
            List<ThuChi> lst = ThuChiBLL.ThongKeThuChi(a, b);
            Gr_View.DataSource = lst;
            Gr_View.DataBind();
            div_ThongKeThuChi.Visible = true;
        }
    }
}