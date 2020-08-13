using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Public;
using BLL;
using SubSonic;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class NhanVienAdd : BasePage
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
                LoadDDLChuVu();

                if (!string.IsNullOrEmpty(curentId))
                {
                    NhanVien view = NhanVienBLL.GwtById(curentId);
                    if (view != null)
                    {
                        txt_Ten.Text = view.HoTen;
                        Txt_NamSinh.Text = view.NamSinh.ToString("yyyy-MM-dd");
                        txt_DiaChi.Text = view.DiaChi;
                        txt_Email.Text = view.Email;
                        txt_SDT.Text = view.Sdt;
                        txt_NgayLam.Text = view.NgayVaoLam.ToString("yyyy-MM-dd");



                        if (DropDow_ChucVu.Items.FindByValue(view.IdChucVu.ToString()) != null)
                            DropDow_ChucVu.SelectedValue = view.IdChucVu.ToString();
                        DropDown_TrangThai.SelectedValue = view.TrangThai;
                        dropdow_gioitinh.SelectedValue = view.GioiTinh;
                    }
                }
                else
                {
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("NhanVienViewDL.aspx");
        }
        private void LoadDDLChuVu()
        {
            List<ChucVu> lstvaitro = ChucVuBLL.GetListChucVu();
           
            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.TenChucVu;
                listItem.Value = item.IdChucVu.ToString();
                DropDow_ChucVu.Items.Add(listItem);
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;
            lb_chucvu.Visible = false;
            lb_diachi.Visible = false;
            Lb_Email.Visible = false;
            lb_Namsinh.Visible = false;
            lb_ngayVaoLam.Visible = false;
            lb_SDT.Visible = false;
            lb_trangthai.Visible = false;
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
            if (string.IsNullOrEmpty(txt_NgayLam.Text.Trim()))
            {
                lb_ngayVaoLam.Text = "Vui Lòng nhập ngày vào làm !";
                lb_ngayVaoLam.Visible = true;
                valid = true;
                lb_Ten.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            

                if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng nhập tên nhân viên !";
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
            if (string.IsNullOrEmpty(DropDow_ChucVu.Text.Trim()))
            {
                lb_chucvu.Text = "Vui Lòng chọn chức Vụ !";
                valid = true;
                lb_chucvu.Visible = true;
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(DropDown_TrangThai.Text.Trim()))
            {
                lb_trangthai.Text = "Vui Lòng chọn trạng thai !";
                valid = true;
                lb_trangthai.Visible = true;
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
                NhanVien update = NhanVienBLL.GwtById(id);
                if (update != null)
                {
                    string idChucVu = DropDow_ChucVu.SelectedItem.Value;
                    update.HoTen = txt_Ten.Text;
                    if (!string.IsNullOrEmpty(Txt_NamSinh.Text))
                        update.NamSinh = DateTime.Parse( Txt_NamSinh.Text);
                    if (!string.IsNullOrEmpty(txt_NgayLam.Text))
                        update.NgayVaoLam = DateTime.Parse( txt_NgayLam.Text);
                    update.Sdt = txt_SDT.Text;
                    update.DiaChi = txt_DiaChi.Text;
                    update.Email = txt_Email.Text;
                    update.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                    update.HoTen = txt_Ten.Text;
                    update.IdChucVu = Guid.Parse(idChucVu);
                    update.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                    update = NhanVienBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
            }



            else
            {

                NhanVien insert = new NhanVien();
                insert.Id = Guid.NewGuid();
                string idChucVu = DropDow_ChucVu.SelectedItem.Value;
                insert.IdChucVu = Guid.Parse(idChucVu);
                insert.HoTen = txt_Ten.Text;
                insert.NamSinh = DateTime.Parse( Txt_NamSinh.Text);
                insert.Sdt = txt_SDT.Text;
                insert.Email = txt_Email.Text;
                insert.DiaChi = txt_DiaChi.Text;
                insert.NgayVaoLam =DateTime.Parse( txt_NgayLam.Text);
                insert.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                insert.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                insert = NhanVienBLL.InsertFile(insert);
                txt_DiaChi.Text = null;
                txt_Email.Text = null;
                Txt_NamSinh.Text = null;
                txt_NgayLam.Text = null;
                txt_SDT.Text = null;
                txt_Ten.Text = null;
                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;

            }

        }
    }
}