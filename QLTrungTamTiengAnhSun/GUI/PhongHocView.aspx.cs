using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;

namespace GUI
{
    public partial class PhongHocView : BasePage
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

            BindListView();
           

        }
        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_Ten.Text = null;
            txt_ghichu.InnerText = null;
            lb_id.Text = null;
            lb_Ten.Visible = false;
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

            List<PhongHoc> lst = PhongHocBLL.GetListPhongHoc();
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
                
                    PhongHoc view = PhongHocBLL.GwtById(btn.CommandArgument);
                    if (view != null)
                    {
                        txt_Ten.Text = view.SoPhong;
                        txt_ghichu.InnerText = view.GhiChu;
                        DropDown_TrangThai.SelectedValue = view.TrangThai;
                    lb_id.Text = btn.CommandArgument;
                    }
                lb_Ten.Visible = false;
                lb_ThongBao_add.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }
           
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                PhongHocBLL.DeleteFile(btn.CommandArgument);
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
            List<PhongHoc> lst = PhongHocBLL.SearchList(a);
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
           

            lb_Ten.Visible = false;
            
            bool valid = false;


            if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng Tên Phòng Học !";
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
                PhongHoc update = PhongHocBLL.GwtById(id);
                if (update != null)
                {
                    update.SoPhong = txt_Ten.Text;
                    update.GhiChu =txt_ghichu.InnerText.Trim();
                    update.TrangThai = DropDown_TrangThai.SelectedItem.Text;

                    update = PhongHocBLL.UpDateFile(update);
                }
                lb_ThongBao_add.Text = "Sửa Thành Công";
                lb_ThongBao_add.Visible = true;
                UpdatePanel2.Update();
             
            }



            else
            {

                try
                {
                    PhongHoc insert = new PhongHoc();
                    insert.IdPhongHoc = Guid.NewGuid();
                    insert.SoPhong = txt_Ten.Text.Trim();
                    insert.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                    insert.GhiChu = txt_ghichu.InnerText.Trim();
                    insert = PhongHocBLL.InsertFile(insert);
                   
                    lb_ThongBao_add.Text = "Thêm Thành Công";
                    lb_ThongBao_add.Visible = true;
                    txt_Ten.Text = null;
                    txt_ghichu.InnerText = null;
                    
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
            Response.Redirect("PhongHocView.aspx");
           
        }
    }
}