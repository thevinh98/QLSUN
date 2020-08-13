using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;
using System.Drawing;

namespace GUI
{
    public partial class DotTuyenSinhView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                //time
                var localDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
              

              //  inputDate.Value = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                Txt_ThoiGian.Text = localDateTime;
                BindListView();
                
            }
         

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

            List<DotTuyenSinh> lst = DotTuyenSinhBLL.GetListDotTuyenSinh();
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
                DotTuyenSinh view = DotTuyenSinhBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {
                    txt_Ten.Text = view.TenDotTuyenSinh;
                    txt_Noidung.InnerText = view.NoiDung;
                    Txt_ThoiGian.Text = view.ThoiGian.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                    DropDown_TrangThai.SelectedValue = view.TrangThai;
                    lb_id.Text = btn.CommandArgument;
                }
                lb_Ten.Visible = false;
                lb_thoiGian.Visible = false;
                lb_ThongBao_add.Visible = false;

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                DotTuyenSinhBLL.DeleteFile(btn.CommandArgument);
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
            List<DotTuyenSinh> lst = DotTuyenSinhBLL.SearchList(a);
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

        //cập nhật

        public string curentId
        {
            get
            {
                return Request.QueryString["Id"];
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

        //them

        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_Ten.Text = null;
            txt_Noidung.InnerText = null;
            Txt_ThoiGian.Text = null;

            lb_id.Text = null;
            lb_Ten.Visible = false;
            lb_thoiGian.Visible = false;
         
            lb_ThongBao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("DotTuyenSinhView.aspx");

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;
            lb_thoiGian.Visible = false;
            lb_ThongBao_add.Visible = false;
            bool valid = false;
            if (string.IsNullOrEmpty(Txt_ThoiGian.Text.Trim()))
            {
                lb_thoiGian.Text = "Vui Lòng chọn thời gian !";
                valid = true;
                lb_thoiGian.Visible = true;
                lb_ThongBao_add.Text = "Cập Nhật Thất Bại";
                lb_ThongBao_add.Visible = true;
                UpdatePanel2.Update();
            }

            if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng Nhập Tên Đợt Tuyển Sinh !";
                valid = true;
                lb_Ten.Visible = true;
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
                DotTuyenSinh update = DotTuyenSinhBLL.GwtById(id);
                if (update != null)
                {
                    update.TenDotTuyenSinh = txt_Ten.Text.Trim();
                    update.ThoiGian = DateTime.Parse(Txt_ThoiGian.Text);
                    update.NoiDung = txt_Noidung.InnerText.Trim();
                    update.TrangThai = DropDown_TrangThai.SelectedItem.Text.Trim();
                    update = DotTuyenSinhBLL.UpDateFile(update);
                }
                lb_ThongBao_add.Text = "Sửa Thành Công";
                lb_ThongBao_add.Visible = true;
                BindListView();
                UpdatePanel2.Update();
            }



            else
            {


                DotTuyenSinh insert = new DotTuyenSinh();
                insert.IdDotTuyenSinh = Guid.NewGuid();
                insert.TenDotTuyenSinh = txt_Ten.Text.Trim();
                insert.ThoiGian = DateTime.Parse(Txt_ThoiGian.Text);
                insert.NoiDung = txt_Noidung.InnerText.Trim();
                insert.TrangThai = DropDown_TrangThai.SelectedItem.Text.Trim();

                insert = DotTuyenSinhBLL.InsertFile(insert);

                lb_ThongBao_add.Text = "Thêm Thành Công";
                lb_ThongBao_add.Visible = true;
                txt_Ten.Text = null;
                Txt_ThoiGian.Text = null;
                txt_Noidung.InnerText = null;
                UpdatePanel2.Update();


            }

        }

      
    }
}