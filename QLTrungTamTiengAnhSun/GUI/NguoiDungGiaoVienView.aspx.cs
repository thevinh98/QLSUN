using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;
using System.Data;
using System.Drawing;

namespace GUI
{
    public partial class NguoiDungGiaoVienView : BasePage
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
                BindListView();
                LoadDDLGiaoVien();
            }




        }
        private void LoadDDLGiaoVien()
        {
            List<GiaoVien> lstvaitro = GiaoVienBLL.GetListGiaoVien();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen;
                listItem.Value = item.IdGiaoVien.ToString();
                Dropdow_gv.Items.Add(listItem);
            }
        }
        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_tentaikhhoan.Text = null;
            txt_MatKhau.Text = null;

            lb_id.Text = null;
            lb_tentaikhoan.Visible = false;
            lb_matkhau.Visible = false;
            lb_ThongBao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

        }
        //phân trang
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 10;
        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }


        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            // Check last page is greater than total page then reduced it 
            // to total no. of page is last index
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(sender, e);
            }
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(sender, e);
            }
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(sender, e);
            }
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(sender, e);
            }

        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(source, e);
            }
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#00FF00");
        }
        //-------- kết thúc phân trang---------
        protected void BindListView()
        {

            List<NguoiDungGiaoVien> lst = NguoiDungGiaoVienBLL.GetListNguoiDungGiaoVien();
            _pgsource.DataSource = lst;
            _pgsource.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource.PageSize = int.Parse(lb_op.Text);
            _pgsource.CurrentPageIndex = CurrentPage;
            // Keep the Total pages in View State
            ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;
            lbFirst.Enabled = !_pgsource.IsFirstPage;
            lbLast.Enabled = !_pgsource.IsLastPage;

            // Bind data into repeater
            Gr_View.DataSource = _pgsource;
            Gr_View.DataBind();

            // Call the function to do paging
            HandlePaging();



        }


        // sửa
        protected void Edit_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                // Response.Redirect(string.Format("/PhongHocView.aspx?Id={0}", btn.CommandArgument));

                NguoiDungGiaoVien view = NguoiDungGiaoVienBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {
                    txt_tentaikhhoan.Text = view.TenTaiKhoan;
                    txt_MatKhau.Text = view.MatKhau;
                    if (view.TrangThai == true)
                    {
                        cbTrangThai.Checked = true;
                    }
                    else
                    {
                        cbTrangThai.Checked = false;
                    }
                    if (Dropdow_gv.Items.FindByValue(view.IdGiaoVien.ToString()) != null)
                        Dropdow_gv.SelectedValue = view.IdGiaoVien.ToString();

                    lb_id.Text = btn.CommandArgument;
                }
                lb_matkhau.Visible = false;
                lb_tentaikhoan.Visible = false;
                lb_ThongBao_add.Visible = false;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }

        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                NguoiDungGiaoVienBLL.DeleteFile(btn.CommandArgument);
                Gr_View.DataBind();
            }
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(sender, e);
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {

            String a = txt_search.Text.Trim();
            List<NguoiDungGiaoVien> lst = NguoiDungGiaoVienBLL.SearchList(a);
            _pgsource.DataSource = lst;
            _pgsource.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource.PageSize = int.Parse(lb_op.Text);
            _pgsource.CurrentPageIndex = CurrentPage;
            // Keep the Total pages in View State
            ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;
            lbFirst.Enabled = !_pgsource.IsFirstPage;
            lbLast.Enabled = !_pgsource.IsLastPage;
            Gr_View.DataSource = _pgsource;
            Gr_View.DataBind();
            if (!String.IsNullOrEmpty(txt_search.Text))
            {
                lb_ThongBao.Text = "Kết quản tìm kiếm";
                lb_ThongBao.Visible = true;
            }
            else
            {
                lb_ThongBao.Visible = false;
            }
            HandlePaging();
        }
        protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_op.Text = cboCountry.Items[cboCountry.SelectedIndex].Value;
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                Search_Click(sender, e);
            }
        }


        protected void Update_Click(object sender, EventArgs e)
        {


            lb_tentaikhoan.Visible = false;
            lb_matkhau.Visible = false;
            lb_ThongBao_add.Visible = false;
            bool valid = false;


            if (string.IsNullOrEmpty(txt_tentaikhhoan.Text.Trim()))
            {
                lb_tentaikhoan.Text = "Vui Lòng Nhập Tên Tài Khoản !";
                valid = true;
                lb_tentaikhoan.Visible = true;
                lb_ThongBao_add.Text = "Cập Nhật Thất Bại";
                lb_ThongBao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (txt_MatKhau.Text.Length <= 5 || txt_MatKhau.Text.Length >= 31)
            {
                lb_matkhau.Text = "Độ dài mật khẩu phải từ 6 đến 30 kí tự !";
                valid = true;
                lb_matkhau.Visible = true;
                lb_ThongBao_add.Text = "Cập Nhật Thất Bại";
                lb_ThongBao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_MatKhau.Text.Trim()))
            {
                lb_matkhau.Text = "Vui Lòng Nhập Mật Khẩu!";
                valid = true;
                lb_matkhau.Visible = true;
                lb_ThongBao_add.Text = "Cập Nhật Thất Bại";
                lb_ThongBao_add.Visible = true;
                UpdatePanel2.Update();
            }

            if (valid)
            {
                return;
            }

            if (!string.IsNullOrEmpty(lb_id.Text))
            {
                Guid id = Guid.Parse(lb_id.Text);
                NguoiDungGiaoVien update = NguoiDungGiaoVienBLL.GwtById(id);
                if (update != null)
                {
                    string idgv = Dropdow_gv.SelectedItem.Value;
                    update.IdGiaoVien = Guid.Parse(idgv);
                    update.TenTaiKhoan = txt_tentaikhhoan.Text.Trim();
                    update.MatKhau = txt_MatKhau.Text.Trim();
                    if (cbTrangThai.Checked == true)
                    {
                        update.TrangThai = true;
                    }
                    else
                    {
                        update.TrangThai = false;
                    }


                    update = NguoiDungGiaoVienBLL.UpDateFile(update);
                }
                lb_ThongBao_add.Text = "Sửa Thành Công";
                lb_ThongBao_add.Visible = true;
                UpdatePanel2.Update();

            }



            else
            {

                try
                {
                    NguoiDungGiaoVien insert = new NguoiDungGiaoVien();
                    insert.Id = Guid.NewGuid();
                    string idgv = Dropdow_gv.SelectedItem.Value;
                    insert.IdGiaoVien = Guid.Parse(idgv);
                    insert.TenTaiKhoan = txt_tentaikhhoan.Text.Trim();
                    insert.MatKhau = txt_MatKhau.Text.Trim();
                    if (cbTrangThai.Checked == true)
                    {
                        insert.TrangThai = true;
                    }
                    else
                    {
                        insert.TrangThai = false;
                    }
                    insert = NguoiDungGiaoVienBLL.InsertFile(insert);

                    lb_ThongBao_add.Text = "Thêm Thành Công";
                    lb_ThongBao_add.Visible = true;
                    txt_MatKhau.Text = null;

                    txt_tentaikhhoan.Text = null;

                }
                catch
                {
                    lb_ThongBao_add.Text = "Thêm thất bại ";
                    lb_ThongBao_add.Visible = true;
                }
                UpdatePanel2.Update();


            }


        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("NguoiDungGiaoVienView.aspx");

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