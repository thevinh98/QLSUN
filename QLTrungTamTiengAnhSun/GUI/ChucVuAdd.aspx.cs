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
    public partial class ChucVuAdd : BasePage
    {
        public string curentId
        {
            get
            {
                return Request.QueryString["Id"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (!string.IsNullOrEmpty(curentId))
                {
                    ChucVu view = ChucVuBLL.GwtById(curentId);
                    if (view != null)
                    {
                        txt_Ten.Text = view.TenChucVu;
                        Txt_luong.Text = view.LuongThang.ToString();
                        
                    }
                }
                else
                {
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChucVuView.aspx");
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;

            bool valid = false;

          
            if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng tên chức vụ !";
                valid = true;
                lb_Ten.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (valid)
            {
                return;
            }

            if (!string.IsNullOrEmpty(curentId))
            {
                Guid id = Guid.Parse(curentId);
                ChucVu update = ChucVuBLL.GwtById(id);
                if (update != null)
                {
                    update.TenChucVu = txt_Ten.Text;
                    update.LuongThang = Decimal.Parse(Txt_luong.Text);

                    update = ChucVuBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
            }



            else
            {

                ChucVu insert = new ChucVu();
                insert.IdChucVu = Guid.NewGuid();
                insert.TenChucVu = txt_Ten.Text;
                if(string.IsNullOrEmpty(Txt_luong.Text))
                {
                    insert.LuongThang = null;
                }
                else
                {
                    insert.LuongThang = Decimal.Parse(Txt_luong.Text);
                }
               
                insert = ChucVuBLL.InsertFile(insert);

                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;
                txt_Ten.Text = null;
                Txt_luong.Text = null;

            }

        }
    }
}