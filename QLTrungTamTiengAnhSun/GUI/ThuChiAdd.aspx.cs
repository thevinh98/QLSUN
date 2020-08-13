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
    public partial class ThuChiAdd : BasePage
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
                NhanVien();

                if (!string.IsNullOrEmpty(curentId))
                {
                    ThuChi view = ThuChiBLL.GwtById(curentId);
                    if (view != null)
                    {
                        txt_tenthuchi.Text = view.TenKhoanChi;
                        txt_thoigian.Text = view.ThoiGian.ToString("yyyy-MM-dd");
                        txt_NoiDung.InnerText = view.NoiDung;

                        txt_sotien.Text = view.SoTien.ToString();

                    }
                }
                else
                {
                }
            }
        }
        private void NhanVien()
        {
            if (Session["Currentuser"] != null)
            {
                NguoiDungADM user = Session["Currentuser"] as NguoiDungADM;
                if (user != null)
                {
                    var id = user.IdNhanVien.ToString();
                    List<NhanVien> lst = NhanVienBLL.GetListNhanVienOne(id);
                    rep_NhanVien.DataSource = lst;
                    rep_NhanVien.DataBind();
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThuChiView.aspx");
        }
        protected void HoaDon_Click(object sender, EventArgs e)
        {
            lb_nguoinhan.Text = txt_tenthuchi.Text;
            lb_ghichu.Text = txt_NoiDung.InnerText;
            Lb_tienthanhtoan1.Text = txt_sotien.Text + "VND";
            date.Text = "Khánh Hòa," + txt_thoigian.Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true); ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            lb_tenthuchi.Visible = false;
            lb_soTien.Visible = false;
            lb_thoigian.Visible = false;
            lb_thoigian.Visible = false;

            bool valid = false;

            if (string.IsNullOrEmpty(txt_tenthuchi.Text.Trim()))
            {
                lb_tenthuchi.Text = "Vui lòng nhập người nhận !";
                lb_tenthuchi.Visible = true;
                valid = true;

                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_sotien.Text.Trim()))
            {
                lb_soTien.Text = "Vui lòng nhập số tiền !";
                lb_soTien.Visible = true;
                valid = true;

                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_thoigian.Text.Trim()))
            {
                lb_thoigian.Text = "Vui Lòng nhập thời gian !";
                lb_thoigian.Visible = true;
                valid = true;

                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }



            if (valid)
            {
                return;
            }
            if (!string.IsNullOrEmpty(curentId))
            {
                Guid id = Guid.Parse(curentId);
                ThuChi update = ThuChiBLL.GwtById(id);
                if (update != null)
                {

                    update.TenKhoanChi = txt_tenthuchi.Text.Trim();
                    update.SoTien = decimal.Parse( txt_sotien.Text.Trim());
                    update.ThoiGian = DateTime.Parse(txt_thoigian.Text);
                    update.NoiDung = txt_NoiDung.InnerText.Trim();

                    update = ThuChiBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
            }



            else
            {

                ThuChi insert = new ThuChi();
                insert.Id = Guid.NewGuid();
                insert.TenKhoanChi = txt_tenthuchi.Text.Trim();
                insert.SoTien = decimal.Parse(txt_sotien.Text.Trim());
                insert.ThoiGian = DateTime.Parse(txt_thoigian.Text);
                insert.NoiDung = txt_NoiDung.InnerText.Trim();
                insert = ThuChiBLL.InsertFile(insert);
                txt_sotien.Text = null;
                txt_thoigian.Text = null;
                txt_NoiDung.InnerText = null;
                txt_tenthuchi.Text = null;
                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;

            }

        }
    }
}