using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Public;
using BLL;
using System.Data;
using System.Drawing;
using System.IO;

namespace GUI
{
    public partial class LuongGiaoVienView : BasePage
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
                div_LuongGV.Visible = false;
                
                txt_thoigianbatdau.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txt_thoigianketthuc.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BindListView();
                NhanVien();
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
            
            
                Search_Click(sender, e);
            
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            
                Search_Click(sender, e);
            
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
           
                Search_Click(sender, e);
           
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
           
                Search_Click(sender, e);
           

        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
           
             
                Search_Click(source, e);
            
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

            String b = txt_thoigianbatdau.Text;
            String c = txt_thoigianketthuc.Text;
            List<LichGiangDay> lst = LichGiangDayBLL.LuongGv(b,c);
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


        protected void thongKe_Click(object sender, EventArgs e)
        {
            div_LuongGV.Visible = true;
            String b = txt_thoigianbatdau.Text;
           String c = txt_thoigianketthuc.Text;
            List<LichGiangDay> lst = LichGiangDayBLL.LuongGv(b, c);
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

        protected void Search_Click(object sender, EventArgs e)
        {
            div_LuongGV.Visible = true;
            String b = txt_thoigianbatdau.Text;
            String c = txt_thoigianketthuc.Text;
            String a = txt_search.Text.Trim();
            List<LichGiangDay> lst = LichGiangDayBLL.Search_LuongGv(b, c,a);
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
        protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_op.Text = cboCountry.Items[cboCountry.SelectedIndex].Value;
            if (string.IsNullOrEmpty(txt_search.Text))
            {
               
            }
            else
            {
                thongKe_Click(sender, e);
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
        //hoa don
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
        protected void HoaDon_Click(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true); ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
          //  var id = "541203e1-75b2-410b-88f7-57bb6874bdb4";
            lb_time1.Text = txt_thoigianbatdau.Text;
            lb_time2.Text = txt_thoigianketthuc.Text;
            LinkButton btn = sender as LinkButton;
           if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                String b = txt_thoigianbatdau.Text;
                String c = txt_thoigianketthuc.Text;
                List<LichGiangDay> lst = LichGiangDayBLL.HoaDonLuongGv(b, c, btn.CommandArgument);
                rep_hoadon.DataSource = lst;
                rep_hoadon.DataBind();
            }
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