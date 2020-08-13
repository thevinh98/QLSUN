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
    public partial class LopAdd : BasePage
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
             
                var localDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                LoadDDLKhoaHoc();
                if (!string.IsNullOrEmpty(curentId))
                {
                    Lop view = LopBLL.GwtById(curentId);
                    if (view != null)
                    {
                        txt_Ten.Text = view.TenLop;
                        txt_hocphi.Text = view.HocPhiLop.ToString();
                        txt_hocvientoida.Text = view.HocVienToiDa.ToString();
                        txt_sobuoihoc.Text = view.SoBuoiHoc.ToString();
                        txt_Ghichu.InnerText = view.GhiChu.ToString().Trim();

                        txt_thoigianbatdau.Text = view.ThoiGianBatDau.ToString("yyyy-MM-dd");
                        txt_thoigianketthuc.Text = view.ThoiGianKetThuc.ToString("yyyy-MM-dd");
                        if (dropdow_KhoaHoc.Items.FindByValue(view.IdKhoaHoc.ToString()) != null)
                            dropdow_KhoaHoc.SelectedValue = view.IdKhoaHoc.ToString();
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
            Response.Redirect("LopView.aspx");
        }

        private void LoadDDLKhoaHoc()
        {
            List<KhoaHoc> lstvaitro = KhoaHocBLL.GetListKhoaHocMo();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.TenKhoaHoc;
                listItem.Value = item.IdKhoaHoc.ToString();
                dropdow_KhoaHoc.Items.Add(listItem);
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;
            lb_hocphi.Visible = false;
            lb_hocvientoida.Visible = false;
            lb_sobuoihoc.Visible = false;
        
            lb_thoigianbatdau.Visible = false;
            lb_thoigianketthuc.Visible = false;
            bool valid = false;


            if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng tên Lớp Học !";
                valid = true;
                lb_Ten.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_hocvientoida.Text.Trim()))
            {
                lb_hocvientoida.Text = "Vui Lòng nhập học viên tối đa !";
                valid = true;
                lb_hocvientoida.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_thoigianbatdau.Text.Trim()))
            {
                lb_thoigianbatdau.Text = "Vui Lòng Nhập thời gian bắt đầu !";
                valid = true;
                lb_thoigianbatdau.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_thoigianketthuc.Text.Trim()))
            {
                lb_thoigianketthuc.Text = "Vui Lòng nhập thời gian kết thúc !";
                valid = true;
                lb_thoigianketthuc.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_hocphi.Text.Trim()))
            {
                lb_hocphi.Text = "Vui Lòng Nhập Học Phí !";
                valid = true;
                lb_hocphi.Visible = true;
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
                Lop update = LopBLL.GwtById(id);
                if (update != null)
                {
                    update.TenLop = txt_Ten.Text;
                    string idKhoaHoc = dropdow_KhoaHoc.SelectedItem.Value;
                    update.IdKhoaHoc = Guid.Parse(idKhoaHoc);
                    update.HocPhiLop = Decimal.Parse( txt_hocphi.Text.Trim());
                    update.HocVienToiDa = int.Parse(txt_hocvientoida.Text.Trim());
                    update.SoBuoiHoc =int.Parse( txt_sobuoihoc.Text.Trim());
                    update.ThoiGianBatDau = DateTime.Parse(txt_thoigianbatdau.Text);
                    update.ThoiGianKetThuc = DateTime.Parse(txt_thoigianketthuc.Text);
                    update.GhiChu = txt_Ghichu.InnerText.Trim();
                    update.TrangThai = DropDown_TrangThai.SelectedItem.Text.Trim();
                    update = LopBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
               
            }



            else
            {

                Lop insert = new Lop();
                insert.IdLop = Guid.NewGuid();
                insert.TenLop = txt_Ten.Text;
                string idKhoaHoc = dropdow_KhoaHoc.SelectedItem.Value;
                insert.IdKhoaHoc = Guid.Parse(idKhoaHoc);
                insert.HocPhiLop = Decimal.Parse(txt_hocphi.Text.Trim());
                insert.HocVienToiDa = int.Parse(txt_hocvientoida.Text.Trim());
                insert.SoBuoiHoc = int.Parse(txt_sobuoihoc.Text.Trim());
                insert.ThoiGianBatDau = DateTime.Parse(txt_thoigianbatdau.Text);
                insert.ThoiGianKetThuc = DateTime.Parse(txt_thoigianketthuc.Text);
                insert.GhiChu = txt_Ghichu.InnerText.Trim();
                insert.TrangThai = DropDown_TrangThai.SelectedItem.Text.Trim();

                insert = LopBLL.InsertFile(insert);

                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;
                txt_Ten.Text = null;
                txt_Ghichu.InnerText = null;
                txt_hocphi.Text = null;
                txt_sobuoihoc.Text = null;
                txt_hocvientoida.Text = null;
                txt_thoigianbatdau.Text = null;
                txt_thoigianketthuc.Text = null;

            }

        }
        protected string CuttingString(object text, int number)
        {
            if (text != null && text.ToString() != string.Empty && text.ToString().Length > number)
            {
                string value = string.Empty;
                for (int i = 0; i < text.ToString().Length; i++)
                {
                    if (i == number)
                        return value + "...";
                    value += text.ToString()[i];
                }
            }
            return text.ToString();
        }
        protected string VisibleButtonViewMore(object text, int number)
        {
            if (text != null && text.ToString() != string.Empty && text.ToString().Length > number)
            {
                return string.Empty;
            }
            return "display:none";
        }
    }
}