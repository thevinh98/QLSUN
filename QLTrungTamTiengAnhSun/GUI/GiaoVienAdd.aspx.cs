using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class GiaoVienAdd : BasePage
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
                    
                    GiaoVien view = GiaoVienBLL.GwtById(curentId);
                    if (view != null)
                    {

                        txt_Ten.Text = view.HoTen;
                        Txt_NamSinh.Text = view.NamSinh.ToString("yyyy-MM-dd");
                        txt_ngayvaolam.Text = view.NgayVaoLam.ToString("yyyy-MM-dd");
                        txt_DiaChi.Text = view.DiaChi;
                        txt_Email.Text = view.Email;
                        txt_SDT.Text = view.Sdt;
                        DropDow_Trinhdo.SelectedValue = view.TrinhDo;
                        dropdow_gioitinh.SelectedValue = view.GioiTinh;
                        DropDown_TrangThai.SelectedValue = view.TrangThai;
                    }
                }
                else
                {
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("GiaoVienView.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;
            lb_diachi.Visible = false;
            Lb_Email.Visible = false;
            lb_Namsinh.Visible = false;
            lb_ngayvaolam.Visible = false;
            bool valid = false;

            if (string.IsNullOrEmpty(Txt_NamSinh.Text.Trim()))
            {
                lb_Namsinh.Text = "Vui Lòng nhập năm sinh !";
                lb_Namsinh.Visible = true;
                valid = true;
                lb_Ten.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_ngayvaolam.Text.Trim()))
            {
                lb_ngayvaolam.Text = "Vui Lòng nhập ngày vào làm !";
                lb_ngayvaolam.Visible = true;
                valid = true;
                lb_Ten.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }

            if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng nhập tên học viên !";
                valid = true;
                lb_Ten.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;

            }
            Regex gmail = new Regex(@"^([\w]*[\w\.]*(?!\.)@gmail.com)");
            if (!gmail.IsMatch(txt_Email.Text))
            {
                Lb_Email.Text = "Định dạng Email không hợp lệ !";
                valid = true;
                Lb_Email.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_Email.Text.Trim()))
            {
                Lb_Email.Text = "Vui Lòng nhập Email !";
                valid = true;
                Lb_Email.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;

            }
            if (string.IsNullOrEmpty(txt_DiaChi.Text.Trim()))
            {
                lb_diachi.Text = "Vui Lòng nhập địa chỉ!";
                valid = true;
                lb_diachi.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;

            }
            Regex regex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");

            if (!regex.IsMatch(txt_SDT.Text))
            {
                lb_SDT.Text = "SDT không hợp lệ !";
                valid = true;
                lb_SDT.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (txt_SDT.Text.Trim().Length <= 8 || txt_SDT.Text.Trim().Length >= 12)
            {
                lb_SDT.Text = "SDT từ 9 đến 13 chữ số !";
                valid = true;
                lb_SDT.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_SDT.Text.Trim()))
            {
                lb_SDT.Text = "Vui Lòng nhập Số điện thoại !";
                valid = true;
                lb_SDT.Visible = true;
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
                GiaoVien update = GiaoVienBLL.GwtById(id);
                if (update != null)
                {

                    update.HoTen = txt_Ten.Text;
                    update.NgayVaoLam = DateTime.Parse(txt_ngayvaolam.Text);
                    update.NamSinh = DateTime.Parse(Txt_NamSinh.Text);

                    update.Sdt = txt_SDT.Text;
                    update.DiaChi = txt_DiaChi.Text;
                    update.Email = txt_Email.Text;
                    update.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                    update.TrinhDo = DropDow_Trinhdo.SelectedItem.Text;
                    update.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                    update = GiaoVienBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
              
               
            }



            else
            {

                GiaoVien insert = new GiaoVien();
                insert.IdGiaoVien = Guid.NewGuid();

                insert.HoTen = txt_Ten.Text;
                insert.NgayVaoLam = DateTime.Parse(txt_ngayvaolam.Text);
                insert.NamSinh = DateTime.Parse(Txt_NamSinh.Text);

                insert.Sdt = txt_SDT.Text;
                insert.DiaChi = txt_DiaChi.Text;
                insert.Email = txt_Email.Text;
                insert.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                insert.TrinhDo = DropDow_Trinhdo.SelectedItem.Text;
                insert.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                insert = GiaoVienBLL.InsertFile(insert);
                txt_DiaChi.Text = null;
                txt_Email.Text = null;
                Txt_NamSinh.Text = null;
                txt_ngayvaolam.Text = null;
              
                txt_SDT.Text = null;
                txt_Ten.Text = null;
               

                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;
               
              
            }

        }


       

    }
}