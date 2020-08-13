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
    public partial class KetQuaHocTapAdd : BasePage
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
                LoadDDLDotKiemTra();
                LoadDDLNhapHoc(); 

                if (!string.IsNullOrEmpty(curentId))
                {
                    KetQuaHocTap view = KetQuaHocTapBLL.GwtById(curentId);
                    if (view != null)
                    {
                        txt_diem.Text = view.Diem;
                        txt_thoigian.Text = view.ThoiGian.ToString("yyyy-MM-dd");
                        txt_ghichu.InnerText = view.GhiChu;
                        
                        if (Dropdow_Dotkiemtra.Items.FindByValue(view.IdDotKiemTra.ToString()) != null)
                            Dropdow_Dotkiemtra.SelectedValue = view.IdDotKiemTra.ToString();
                        if (DropDow_NhapHoc.Items.FindByValue(view.IdNhapHoc.ToString()) != null)
                            DropDow_NhapHoc.SelectedValue = view.IdNhapHoc.ToString();

                    }
                }
                else
                {
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("KetQuaHocTapView.aspx");
        }
        private void LoadDDLDotKiemTra()
        {
            List<DotKiemTra> lstvaitro = DotKiemTraBLL.GetListDotKiemTra();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.Ten;
                listItem.Value = item.IdDotKiemTra.ToString();
                Dropdow_Dotkiemtra.Items.Add(listItem);
            }
        }
        private void LoadDDLNhapHoc()
        {
            List<NhapHoc> lstvaitro = NhapHocBLL.GetListNhapHoc();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen;
                listItem.Value = item.IdNhapHoc.ToString();
                DropDow_NhapHoc.Items.Add(listItem);
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            lb_diem.Visible = false;
            lb_thoigian.Visible = false;
           
            bool valid = false;

            if (string.IsNullOrEmpty(txt_diem.Text.Trim()))
            {
                lb_diem.Text = "Vui Lòng nhập điểm !";
                lb_diem.Visible = true;
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
                KetQuaHocTap update = KetQuaHocTapBLL.GwtById(id);
                if (update != null)
                {
                    string idNhapHoc = DropDow_NhapHoc.SelectedItem.Value;
                    string idDotKiemTra = Dropdow_Dotkiemtra.SelectedItem.Value;
                    if (!string.IsNullOrEmpty(txt_thoigian.Text))
                        update.ThoiGian = DateTime.Parse(txt_thoigian.Text);
                    update.IdDotKiemTra = Guid.Parse(idDotKiemTra);
                    update.IdNhapHoc = Guid.Parse(idNhapHoc);
                    update.Diem = txt_diem.Text.Trim();
                    update.GhiChu = txt_ghichu.InnerText.Trim();                 
                    update = KetQuaHocTapBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
            }
            else
            {
                KetQuaHocTap insert = new KetQuaHocTap();
                insert.Id = Guid.NewGuid();
                string idNhapHoc = DropDow_NhapHoc.SelectedItem.Value;
                string idDotKiemTra = Dropdow_Dotkiemtra.SelectedItem.Value;
                if (!string.IsNullOrEmpty(txt_thoigian.Text))
                    insert.ThoiGian = DateTime.Parse(txt_thoigian.Text);
                insert.IdDotKiemTra = Guid.Parse(idDotKiemTra);
                insert.IdNhapHoc = Guid.Parse(idNhapHoc);
                insert.Diem = txt_diem.Text.Trim();
                insert.GhiChu = txt_ghichu.InnerText.Trim();
                insert = KetQuaHocTapBLL.InsertFile(insert);
                txt_diem.Text = null;
                txt_thoigian.Text = null;
                txt_ghichu.InnerText = null;               
                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;
            }

        }
    }
}