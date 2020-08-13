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
    public partial class KetQuaHocTapView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //time
                var localDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');


                LoadDDLNhapHoc();
                LoadDDLDotKiemTra();
               

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

            List<KetQuaHocTap> lst = KetQuaHocTapBLL.GetListKetQuaHocTap();
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
                KetQuaHocTap view = KetQuaHocTapBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {
                    txt_diem.Text = view.Diem;
                    txt_thoigian.Text = view.ThoiGian.ToString("yyyy-MM-dd");
                    txt_ghichu.InnerText = view.GhiChu;

                    if (Dropdow_Dotkiemtra.Items.FindByValue(view.IdDotKiemTra.ToString()) != null)
                        Dropdow_Dotkiemtra.SelectedValue = view.IdDotKiemTra.ToString();
                    if (DropDow_NhapHoc.Items.FindByValue(view.IdNhapHoc.ToString()) != null)
                        DropDow_NhapHoc.SelectedValue = view.IdNhapHoc.ToString();
                    lb_id.Text = btn.CommandArgument;
                    lb_diem.Visible = false;
                    lb_lop.Visible = false;
                    lb_NhapHoc.Visible = false;
                    lb_thoigian.Visible = false;

                    lb_thongbao_add.Visible = false;
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                KetQuaHocTapBLL.DeleteFile(btn.CommandArgument);
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
            List<KetQuaHocTap> lst = KetQuaHocTapBLL.SearchList(a);
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

        // theem


        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_diem.Text = null;
            txt_ghichu.InnerText = null;
            txt_thoigian.Text = null;
            
            lb_thongbao_add.Text = null;
            lb_id.Text = null;
            lb_diem.Visible = false;
            lb_lop.Visible = false;
            lb_NhapHoc.Visible = false;
            lb_thoigian.Visible = false;
           
            lb_thongbao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
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

                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_thoigian.Text.Trim()))
            {
                lb_thoigian.Text = "Vui Lòng nhập thời gian !";
                lb_thoigian.Visible = true;
                valid = true;

                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }



            if (valid)
            {
                return;
            }
            if (!string.IsNullOrEmpty(lb_id.Text))
            {
                try
                {
                    Guid id = Guid.Parse(lb_id.Text);
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
                    lb_thongbao_add.Text = "Sửa Thành Công";
                    lb_thongbao_add.Visible = true;
                }
                catch
                {
                    lb_thongbao_add.Text = "Sửa Thất Bại";
                    lb_thongbao_add.Visible = true;
                }
                UpdatePanel2.Update();
            }



            else
            {
                try
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

                    lb_thongbao_add.Text = "Thêm Thành Công";
                    lb_thongbao_add.Visible = true;
                    
                }

                catch
                {
                    lb_thongbao_add.Text = "Thêm thất bại";
                    lb_thongbao_add.Visible = true;
                }
                UpdatePanel2.Update();
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
                listItem.Text = item.HoTen +"-"+ item.TenLop;
                listItem.Value = item.IdNhapHoc.ToString();
                DropDow_NhapHoc.Items.Add(listItem);
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