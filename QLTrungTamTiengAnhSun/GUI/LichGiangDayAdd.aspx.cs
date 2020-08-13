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
    public partial class LichGiangDayAdd : BasePage
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
                LoadDDLGiaoVien();
                LoadDDLLop();
                LoadDDLPhongHoc();

                if (!string.IsNullOrEmpty(curentId))
                {

                    LichGiangDay view = LichGiangDayBLL.GwtById(curentId);
                    if (view != null)
                    {

                        txt_sogio.Text = view.SoGio.ToString();
                        txt_buoihoc.Text = view.BuoiHoc;
                        txt_thoigianbatdau.Text=view.ThoiGianBatDau.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        txt_thoigianketthuc.Text = view.ThoiGianKetThuc.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        if (DropDow_GiaoVien.Items.FindByValue(view.IdGiaoVien.ToString()) != null)
                            DropDow_GiaoVien.SelectedValue = view.IdGiaoVien.ToString();
                        if (DropDow_Lop.Items.FindByValue(view.IdLop.ToString()) != null)
                            DropDow_Lop.SelectedValue = view.IdLop.ToString();
                        if (DropDow_PhongHoc.Items.FindByValue(view.IdPhongHoc.ToString()) != null)
                            DropDow_PhongHoc.SelectedValue = view.IdPhongHoc.ToString();




                    }
                }
                else
                {
                }
            }
        }
        private void LoadDDLLop()
        {
            List<Lop> lstvaitro = LopBLL.GetListLop();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.TenLop;
                listItem.Value = item.IdLop.ToString();
                DropDow_Lop.Items.Add(listItem);
            }
        }
        private void LoadDDLPhongHoc()
        {
            List<PhongHoc> lstvaitro = PhongHocBLL.GetListPhongHocHD();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.SoPhong;
                listItem.Value = item.IdPhongHoc.ToString();
                DropDow_PhongHoc.Items.Add(listItem);
            }
        }
        private void LoadDDLGiaoVien()
        {
            List<GiaoVien> lstvaitro = GiaoVienBLL.GetListGiaoVienDL();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen;
                listItem.Value = item.IdGiaoVien.ToString();
                DropDow_GiaoVien.Items.Add(listItem);
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("LichGiangDayView.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            lb_buoihoc.Visible = false;
            lb_sogiohoc.Visible = false;
            lb_thoigianbatdau.Visible = false;
            lb_thoigianketthuc.Visible = false;
           
            bool valid = false;

            if (string.IsNullOrEmpty(txt_buoihoc.Text.Trim()))
            {
                lb_buoihoc.Text = "Vui Lòng nhập Tên Buổi Học !";
                lb_buoihoc.Visible = true;
                valid = true;
                
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_thoigianbatdau.Text.Trim()))
            {
                lb_thoigianbatdau.Text = "Vui Lòng nhập Thời Gian Bắt Đầu !";
                lb_thoigianbatdau.Visible = true;
                valid = true;
               
                lb_ThongBao.Text = "Cập nhật thất bại";
                lb_ThongBao.Visible = true;
            }

            if (string.IsNullOrEmpty(txt_thoigianketthuc.Text.Trim()))
            {
                lb_thoigianketthuc.Text = "Vui Lòng nhập Thời Gian Kết Thúc !";
                valid = true;
                lb_thoigianketthuc.Visible = true;
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
                LichGiangDay update = LichGiangDayBLL.GwtById(id);
                if (update != null)
                {
                    update.SoGio =int.Parse( txt_sogio.Text);
                    update.BuoiHoc = txt_buoihoc.Text;
                    update.ThoiGianBatDau = DateTime.Parse(txt_thoigianbatdau.Text);
                    update.ThoiGianKetThuc = DateTime.Parse(txt_thoigianketthuc.Text);
                    string idPhongHoc = DropDow_PhongHoc.SelectedItem.Value;
                    update.IdPhongHoc = Guid.Parse(idPhongHoc);
                    string idGiaoVien = DropDow_GiaoVien.SelectedItem.Value;
                    update.IdGiaoVien = Guid.Parse(idGiaoVien); ;
                    string idLop = DropDow_Lop.SelectedItem.Value;
                    update.IdLop = Guid.Parse(idLop);

                    update = LichGiangDayBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;


            }



            else
            {

                LichGiangDay insert = new LichGiangDay();
                insert.IdLichGiangDay = Guid.NewGuid();

                insert.SoGio = int.Parse(txt_sogio.Text);
                insert.BuoiHoc = txt_buoihoc.Text;
                insert.ThoiGianBatDau = DateTime.Parse(txt_thoigianbatdau.Text);
                insert.ThoiGianKetThuc = DateTime.Parse(txt_thoigianketthuc.Text);
                string idPhongHoc = DropDow_PhongHoc.SelectedItem.Value;
                insert.IdPhongHoc = Guid.Parse(idPhongHoc);
                string idGiaoVien = DropDow_GiaoVien.SelectedItem.Value;
                insert.IdGiaoVien = Guid.Parse(idGiaoVien); ;
                string idLop = DropDow_Lop.SelectedItem.Value;
                insert.IdLop = Guid.Parse(idLop);
                insert = LichGiangDayBLL.InsertFile(insert);


                txt_buoihoc.Text = null;
                txt_sogio.Text = null;
                txt_thoigianbatdau.Text = null;
                txt_thoigianketthuc.Text = null;

              


                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;


            }

        }




    }
}