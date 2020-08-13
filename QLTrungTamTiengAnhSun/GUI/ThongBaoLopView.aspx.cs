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
using System.IO;

namespace GUI
{
    public partial class ThongBaoLopView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //time
                var localDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                LoadDDLLop();

                //  inputDate.Value = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
              
                BindListView();
               
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
                Dropdow_lop.Items.Add(listItem);
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

            List<ThongBaoLop> lst = ThongBaoLopBLL.GetListThongBaoLop();
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
                ThongBaoLop view = ThongBaoLopBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {
                    txt__tieude.Text = view.TieuDe;
                    txt_noidung.InnerText = view.NoiDung;
                    txt_thoigian.Text = view.ThoiGian.ToString("yyyy-MM-dd");
                    Dropdow_TrangThai.SelectedValue = view.TrangThai;
                    if (Dropdow_lop.Items.FindByValue(view.IdLop.ToString()) != null)
                        Dropdow_lop.SelectedValue = view.IdLop.ToString();
                    lb_id.Text = btn.CommandArgument;
                }
                lb_tieude.Visible = false;
                lb_thoigian.Visible = false;
                lb_thongbao_add.Visible = false;
                lb_noidung.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                ThongBaoLopBLL.DeleteFile(btn.CommandArgument);
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
            List<ThongBaoLop> lst = ThongBaoLopBLL.SearchList(a);
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
        protected void Update_Click(object sender, EventArgs e)
        {


            lb_tieude.Visible = false;
            lb_thoigian.Visible = false;
            lb_noidung.Visible = false;
            lb_thongbao_add.Visible = false;
            bool valid = false;


            if (string.IsNullOrEmpty(txt__tieude.Text.Trim()))
            {
                lb_tieude.Text = "Vui Lòng Nhập Tiêu Đề !";
                valid = true;
                lb_tieude.Visible = true;
                lb_thongbao_add.Text = "Cập Nhật Thất Bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_noidung.InnerText.Trim()))
            {
                lb_noidung.Text = "Vui Lòng Nhập Nội Dung !";
                valid = true;
                lb_noidung.Visible = true;
                lb_thongbao_add.Text = "Cập Nhật Thất Bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_thoigian.Text.Trim()))
            {
                lb_thoigian.Text = "Vui Lòng Nhập Thời Gian !";
                valid = true;
                lb_thoigian.Visible = true;
                lb_thongbao_add.Text = "Cập Nhật Thất Bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (valid)
            {
                return;
            }

            if (!string.IsNullOrEmpty(lb_id.Text))
            {
                Guid id = Guid.Parse(lb_id.Text);
                ThongBaoLop update = ThongBaoLopBLL.GwtById(id);
                if (update != null)
                {
                    string idlop = Dropdow_lop.SelectedItem.Value;
                    update.IdLop = Guid.Parse(idlop);
                    update.TieuDe = txt__tieude.Text.Trim();
                    update.NoiDung = txt_noidung.InnerText.Trim();
                    update.TrangThai = Dropdow_TrangThai.SelectedItem.Text.Trim();
                    update.ThoiGian = DateTime.Parse(txt_thoigian.Text);
                    update = ThongBaoLopBLL.UpDateFile(update);
                }
                lb_thongbao_add.Text = "Sửa Thành Công";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();

            }



            else
            {

                try
                {
                    ThongBaoLop insert = new ThongBaoLop();
                    insert.Id = Guid.NewGuid();
                    string idlop = Dropdow_lop.SelectedItem.Value;
                    insert.IdLop = Guid.Parse(idlop);
                    insert.TieuDe = txt__tieude.Text.Trim();
                    insert.NoiDung = txt_noidung.InnerText.Trim();
                    insert.TrangThai = Dropdow_TrangThai.SelectedItem.Text.Trim();
                    insert.ThoiGian = DateTime.Parse(txt_thoigian.Text);
                    insert = ThongBaoLopBLL.InsertFile(insert);

                    lb_thongbao_add.Text = "Thêm Thành Công";
                    lb_thongbao_add.Visible = true;
                    txt__tieude.Text = null;
                    txt_noidung.InnerText = null;
                    txt_thoigian.Text = null;

                }
                catch
                {
                    lb_thongbao_add.Text = "Thêm thất bại ";
                    lb_thongbao_add.Visible = true;
                }
                UpdatePanel2.Update();


            }


        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThongBaoLopView.aspx");

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
        protected void Btn_Add(object sender, EventArgs e)
        {
            txt__tieude.Text = null;
            txt_thoigian.Text = null;
            txt_noidung.InnerText = null;
            lb_id.Text = null;
            lb_tieude.Visible = false;
            lb_thoigian.Visible = false;
            lb_thongbao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

        }
        protected void XuatDuLieuRaExcel()
        {


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Gr_View.AllowPaging = false;
                this.BindListView();

                Gr_View.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Gr_View.HeaderRow.Cells)
                {
                    cell.BackColor = Gr_View.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Gr_View.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Gr_View.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Gr_View.RowStyle.BackColor;
                        }

                    }
                }

                Gr_View.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }


        }
        protected void XuatExcel_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Gr_View.AllowPaging = false;


                Gr_View.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Gr_View.HeaderRow.Cells)
                {
                    cell.BackColor = Gr_View.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Gr_View.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Gr_View.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Gr_View.RowStyle.BackColor;
                        }

                    }
                }

                Gr_View.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();


            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
          server control at run time. */
        }
        private void XuatDuLieuGridRaWord(GridView MyGridview)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Gr_View.AllowPaging = false;


                Gr_View.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Gr_View.HeaderRow.Cells)
                {
                    cell.BackColor = Gr_View.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Gr_View.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Gr_View.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Gr_View.RowStyle.BackColor;
                        }

                    }
                }

                Gr_View.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        protected void Word_Click(object sender, EventArgs e)
        {
            XuatDuLieuGridRaWord(Gr_View);

        }
    }
}