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
    public partial class HocPhiAdd : BasePage
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
                LoadDDLNhapHoc();
                if (!string.IsNullOrEmpty(curentId))
                {
                    HocPhi view = HocPhiBLL.GwtById(curentId);
                    if (view != null)
                    {

                        Txt_thoigiandong.Text = view.ThoiGianDong.ToString("yyyy-MM-dd");
                        txt_handong.Text = view.HanDong.ToString("yyyy-MM-dd");
                        txt_Giamtru.Text = view.GiamTru.ToString();
                        txt_tiendong.Text = view.TienThanhToan.ToString();
                        if (DropDow_NhapHoc.Items.FindByValue(view.IdNhapHoc.ToString()) != null)
                            DropDow_NhapHoc.SelectedValue = view.IdNhapHoc.ToString();
                        // txt_hp.Text = DropDow_NhapHoc.SelectedItem.Value;
                        List<NhapHoc> lst = NhapHocBLL.GetListNhapHoc_HocPhi(DropDow_NhapHoc.SelectedItem.Value);
                        Rep_HocPhi.DataSource = lst;
                        Rep_HocPhi.DataBind();

                        //hoadon
                        List<NhapHoc> hd = NhapHocBLL.GetListNhapHoc_HocPhi(DropDow_NhapHoc.SelectedItem.Value);
                        rep_hoadon.DataSource = hd;
                        rep_hoadon.DataBind();
                        List<HocPhi> lst1 = HocPhiBLL.HocPhiHocVien(DropDow_NhapHoc.SelectedItem.Value);
                        rep_HocPhidaDong.DataSource = lst1;
                        rep_HocPhidaDong.DataBind();
                        List<HocPhi> lst2 = HocPhiBLL.HocPhiHocVien(DropDow_NhapHoc.SelectedItem.Value);
                        Rep_hocPhiConLai.DataSource = lst2;
                        Rep_hocPhiConLai.DataBind();
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
        private void LoadDDLNhapHoc()
        {
            List<NhapHoc> lstvaitro = NhapHocBLL.GetListNhapHoc();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen + "-" + item.TenLop;
                listItem.Value = item.IdNhapHoc.ToString();
                DropDow_NhapHoc.Items.Add(listItem);
                
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("DongHocPhi.aspx");
        }
        protected void Update_Click(object sender, EventArgs e)
        {
           

            lb_Giamtru.Visible = false;
            lb_handong.Visible = false;
          
           
            lb_NhapHoc.Visible = false;
            lb_thoigiandong.Visible = false;
            lb_tiendong.Visible = false;


            bool valid = false;


            if (string.IsNullOrEmpty(txt_Giamtru.Text.Trim()))
            {
                lb_Giamtru.Text = "Vui Lòng nhập số tiền giảm trừ!";
                valid = true;
                lb_Giamtru.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_handong.Text.Trim()))
            {
                lb_handong.Text = "Vui Lòng nhập hạn đóng !";
                valid = true;
                lb_handong.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(Txt_thoigiandong.Text.Trim()))
            {
                lb_thoigiandong.Text = "Vui Lòng nhập thời gian đóng !";
                valid = true;
                lb_thoigiandong.Visible = true;
                lb_ThongBao.Text = "Cập Nhật Thất Bại";
                lb_ThongBao.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_tiendong.Text.Trim()))
            {
                lb_tiendong.Text = "Vui Lòng nhập số tiền đóng !";
                valid = true;
                lb_tiendong.Visible = true;
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
                HocPhi update = HocPhiBLL.GwtById(id);
                if (update != null)
                {
                    string idNhapHoc = DropDow_NhapHoc.SelectedItem.Value;
                    update.IdNhapHoc = Guid.Parse(idNhapHoc);
                    update.ThoiGianDong = DateTime.Parse(Txt_thoigiandong.Text);
                    update.HanDong = DateTime.Parse(txt_handong.Text);
                    update.TienThanhToan = decimal.Parse(txt_tiendong.Text.Trim());
                    update.GhiChu = txt_ghichu.InnerText.Trim();
                    update.GiamTru = decimal.Parse(txt_Giamtru.Text.Trim());
                    update = HocPhiBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
            }



            else
            {

                HocPhi insert = new HocPhi();
                insert.Id = Guid.NewGuid();
                string idNhapHoc = DropDow_NhapHoc.SelectedItem.Value;
                insert.IdNhapHoc = Guid.Parse(idNhapHoc);
                insert.ThoiGianDong = DateTime.Parse(Txt_thoigiandong.Text);
                insert.HanDong = DateTime.Parse(txt_handong.Text);
                insert.TienThanhToan = decimal.Parse(txt_tiendong.Text.Trim());
                insert.GhiChu = txt_ghichu.InnerText.Trim();
                insert.GiamTru = decimal.Parse(txt_Giamtru.Text.Trim());

                insert = HocPhiBLL.InsertFile(insert);

                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;
                txt_ghichu.InnerText = null;
                txt_Giamtru.Text = null;
                txt_handong.Text = null;

               
                Txt_thoigiandong.Text = null;
                txt_tiendong.Text = null;

            }

        }

        protected void HocPhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = DropDow_NhapHoc.Items[DropDow_NhapHoc.SelectedIndex].Value;
            string b = DropDow_NhapHoc.SelectedItem.Value;

            List<NhapHoc> lst = NhapHocBLL.GetListNhapHoc_HocPhi(b);
            Rep_HocPhi.DataSource = lst;
            Rep_HocPhi.DataBind();

            //hoadon
            List<NhapHoc> hd = NhapHocBLL.GetListNhapHoc_HocPhi(b);
            rep_hoadon.DataSource = hd;
            rep_hoadon.DataBind();

            List<HocPhi> lst1 = HocPhiBLL.HocPhiHocVien(b);
            rep_HocPhidaDong.DataSource = lst1;
            rep_HocPhidaDong.DataBind();
            List<HocPhi> lst2 = HocPhiBLL.HocPhiHocVien(b);
            Rep_hocPhiConLai.DataSource = lst2;
            Rep_hocPhiConLai.DataBind();

        }
        protected void Rep_hocphi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }
        // nhap txt

        // hóa đơn
       
        protected void HoaDon_Click(object sender, EventArgs e)
        {
            Lb_tienthanhtoan1.Text = txt_tiendong.Text + "VND";
            date.Text = "Khánh Hòa," + Txt_thoigiandong.Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(),
            "LoginModal", "$('#LoginModal').modal();", true); ScriptManager.RegisterStartupScript(Page, Page.GetType(),
            "LoginModal", "$('#LoginModal').modal();", true);
        }
    }
}