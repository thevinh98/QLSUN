using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Public;
using BLL;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace GUI
{
    public partial class HocVienAdd : BasePage
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

                if (!string.IsNullOrEmpty(curentId))
                {
                    div_HocVien.Visible = true;
                    HocVien view = HocVienBLL.GwtById(curentId);
                    if (view != null)
                    {
                        
                        txt_Ten.Text = view.HoTen;
                        Txt_NamSinh.Text = view.NamSinh.ToString("yyyy-MM-dd");
                        txt_DiaChi.Text = view.DiaChi;
                        txt_Email.Text = view.Email;
                        txt_SDT.Text = view.Sdt;
                        txt_FaceBook.Text = view.FaceBook;
                        txt_ghichu.InnerText = view.GhiChu;                   
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
            Response.Redirect("HocVienViewTS.aspx");
        }
        
        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;

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
                HocVien update = HocVienBLL.GwtById(id);
                if (update != null)
                {
                  
                    update.HoTen = txt_Ten.Text;
                    if (!string.IsNullOrEmpty(Txt_NamSinh.Text))
                        update.NamSinh = DateTime.Parse(Txt_NamSinh.Text);

                    update.Sdt = txt_SDT.Text;
                    update.DiaChi = txt_DiaChi.Text;
                    update.Email = txt_Email.Text;
                    update.FaceBook = txt_FaceBook.Text;
                    update.HoTen = txt_Ten.Text;
                    update.GhiChu = txt_ghichu.InnerText;
                    update.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                    update.TrangThai = DropDown_TrangThai.SelectedItem.Text.Trim();
                    update = HocVienBLL.UpDateFile(update);
                }
                lb_ThongBao.Text = "Sửa Thành Công";
                lb_ThongBao.Visible = true;
                div_HocVien.Visible = true;
                BindListView();
            }



            else
            {

                HocVien insert = new HocVien();
                insert.IdHocVien = Guid.NewGuid();
               
                insert.HoTen = txt_Ten.Text;
                insert.NamSinh = DateTime.Parse(Txt_NamSinh.Text);
                insert.Sdt = txt_SDT.Text;
                insert.Email = txt_Email.Text;
                insert.DiaChi = txt_DiaChi.Text;
                insert.FaceBook = txt_FaceBook.Text;
                insert.GhiChu = txt_ghichu.InnerText;
                insert.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                insert.TrangThai = DropDown_TrangThai.SelectedItem.Text.Trim();
                insert = HocVienBLL.InsertFile(insert);
                txt_DiaChi.Text = null;
                txt_Email.Text = null;
                Txt_NamSinh.Text = null;
                txt_ghichu.InnerText = null;
                txt_FaceBook.Text = null;
                txt_SDT.Text = null;
                txt_Ten.Text = null;
                lb_diachi.Visible = false;
                Lb_Email.Visible = false;
                Lb_Email.Visible = false;
                lb_FaceBook.Visible = false;
                lb_SDT.Visible = false;
                
                lb_ThongBao.Text = "Thêm Thành Công";
                lb_ThongBao.Visible = true;
                div_HocVien.Visible = true;
                BindListView();
            }

        }

        
        //phân trang
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;

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

            List<HocVien> lst = HocVienBLL.GetListHocVien();
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
                Response.Redirect(string.Format("/HocVienAdd.aspx?Id={0}", btn.CommandArgument));
            }
        }
        protected void Delete1_Click(object sender, EventArgs e)
        {

            Response.Redirect(string.Format("/HocVienAdd.aspx"));

        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                HocVienBLL.DeleteFile(btn.CommandArgument);
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
            List<HocVien> lst = HocVienBLL.SearchList(a);
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
        //view


    }
}