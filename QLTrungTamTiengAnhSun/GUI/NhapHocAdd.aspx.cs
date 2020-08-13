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
    public partial class NhapHocAdd : BasePage
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
                LoadDDLHocVien();
                LoadDDLLop();
                if (!string.IsNullOrEmpty(curentId))
                {
                    NhapHoc view = NhapHocBLL.GwtById(curentId);
                    if (view != null)
                    {
                        txt_ghichu.InnerText = view.GhiChu;
                        


                        if (DropDow_HocVien.Items.FindByValue(view.IdHocVien.ToString()) != null)
                            DropDow_HocVien.SelectedValue = view.IdHocVien.ToString();
                        if (Dropdow_lop.Items.FindByValue(view.IdLop.ToString()) != null)
                            Dropdow_lop.SelectedValue = view.IdLop.ToString();
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
            Response.Redirect("NhapHocView.aspx");
        }
        private void LoadDDLHocVien()
        {
            List<KetQuaTuyenSinh> lst = KetQuaTuyenSinhBLL.GetListKetQuaTuyenSinh();

            foreach (var item in lst)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen;
                listItem.Value = item.IdHocVien.ToString();
                DropDow_HocVien.Items.Add(listItem);
            }
        }
        private void LoadDDLLop()
        {
            List<Lop> lstvaitro = LopBLL.GetListLopSM();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.TenLop;
                listItem.Value = item.IdLop.ToString();
                Dropdow_lop.Items.Add(listItem);
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
           
           
            if (!string.IsNullOrEmpty(curentId))
            {
                try
                {
                    Guid id = Guid.Parse(curentId);
                    NhapHoc update = NhapHocBLL.GwtById(id);
                    if (update != null)
                    {
                        string idHocVien = DropDow_HocVien.SelectedItem.Value;
                        update.IdHocVien = Guid.Parse(idHocVien);
                        string idLop = Dropdow_lop.SelectedItem.Value;
                        update.IdLop = Guid.Parse(idLop);

                        update.GhiChu = txt_ghichu.InnerText.Trim();

                        update.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                        update = NhapHocBLL.UpDateFile(update);
                    }
                    lb_ThongBao.Text = "Sửa Thành Công";
                    lb_ThongBao.Visible = true;
                }
                catch
                {
                    lb_ThongBao.Text = "Sửa Thất bại";
                    lb_ThongBao.Visible = true;
                }
              
            }



            else
            {
                try
                {
                    NhapHoc insert = new NhapHoc();
                    insert.IdNhapHoc = Guid.NewGuid();
                    string idHocVien = DropDow_HocVien.SelectedItem.Value;
                    insert.IdHocVien = Guid.Parse(idHocVien);
                    string idLop = Dropdow_lop.SelectedItem.Value;
                    insert.IdLop = Guid.Parse(idLop);

                    insert.GhiChu = txt_ghichu.InnerText.Trim();

                    insert.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                    insert = NhapHocBLL.InsertFile(insert);
                    txt_ghichu.InnerText = null;

                    lb_ThongBao.Text = "Thêm Thành Công";
                    lb_ThongBao.Visible = true;
                }

                catch
                {
                    lb_ThongBao.Text = "Thêm Thất Bại";
                    lb_ThongBao.Visible = true;
                }

               

            }

        }
    }
}