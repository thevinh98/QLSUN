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
    public partial class LichHocLop : BasePage
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
                LoadDDLPhongHoc();

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

            List<LichGiangDay> lst = LichGiangDayBLL.GetListLichHoc(curentId);
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
                LichGiangDay view = LichGiangDayBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {

                    txt_sogio.Text = view.SoGio.ToString();
                    txt_buoihoc.Text = view.BuoiHoc;
                    txt_thoigianbatdau.Text = view.ThoiGianBatDau.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                    txt_thoigianketthuc.Text = view.ThoiGianKetThuc.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                    if (DropDow_GiaoVien.Items.FindByValue(view.IdGiaoVien.ToString()) != null)
                        DropDow_GiaoVien.SelectedValue = view.IdGiaoVien.ToString();
                   
                    if (DropDow_PhongHoc.Items.FindByValue(view.IdPhongHoc.ToString()) != null)
                        DropDow_PhongHoc.SelectedValue = view.IdPhongHoc.ToString();


                    lb_id.Text = btn.CommandArgument;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                LichGiangDayBLL.DeleteFile(btn.CommandArgument);
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
            if(String.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                String a = txt_search.Text.Trim();
                List<LichGiangDay> lst = LichGiangDayBLL.SearchListLH(a);
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
        //them mới


        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_buoihoc.Text = null;
            txt_sogio.Text = null;
            txt_thoigianbatdau.Text = null;
            txt_thoigianketthuc.Text = null;
            lb_id.Text = null;

            lb_thongbao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

        }

        private void LoadDDLPhongHoc()
        {
            List<PhongHoc> lstvaitro = PhongHocBLL.GetListPhongHocHD();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.SoPhong;
                listItem.Value = item.IdPhongHoc.ToString();
                DropDow_PhongHoc.Items.Add(listItem);
            }
        }
        private void LoadDDLGiaoVien()
        {
            List<GiaoVien> lstvaitro = GiaoVienBLL.GetListGiaoVienDL();

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen;
                listItem.Value = item.IdGiaoVien.ToString();
                DropDow_GiaoVien.Items.Add(listItem);
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("LichHocLop.aspx?Id={0}", curentId));
        }
        protected void BackView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("LopView.aspx"));
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            lb_buoihoc.Visible = false;
            lb_sogiohoc.Visible = false;
            lb_thoigianbatdau.Visible = false;
            lb_thoigianketthuc.Visible = false;

            bool valid = false;

            if (string.IsNullOrEmpty(txt_buoihoc.Text.Trim()))
            {
                lb_buoihoc.Text = "Vui Lòng nhập Tên Buổi Học !";
                lb_buoihoc.Visible = true;
                valid = true;

                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_thoigianbatdau.Text.Trim()))
            {
                lb_thoigianbatdau.Text = "Vui Lòng nhập Thời Gian Bắt Đầu !";
                lb_thoigianbatdau.Visible = true;
                valid = true;

                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }

            if (string.IsNullOrEmpty(txt_thoigianketthuc.Text.Trim()))
            {
                lb_thoigianketthuc.Text = "Vui Lòng nhập Thời Gian Kết Thúc !";
                valid = true;
                lb_thoigianketthuc.Visible = true;
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
                    LichGiangDay update = LichGiangDayBLL.GwtById(id);
                    if (update != null)
                    {
                        update.SoGio = int.Parse(txt_sogio.Text);
                        update.BuoiHoc = txt_buoihoc.Text;
                        update.ThoiGianBatDau = DateTime.Parse(txt_thoigianbatdau.Text);
                        update.ThoiGianKetThuc = DateTime.Parse(txt_thoigianketthuc.Text);
                        string idPhongHoc = DropDow_PhongHoc.SelectedItem.Value;
                        update.IdPhongHoc = Guid.Parse(idPhongHoc);
                        string idGiaoVien = DropDow_GiaoVien.SelectedItem.Value;
                        update.IdGiaoVien = Guid.Parse(idGiaoVien); ;

                        update.IdLop = Guid.Parse(curentId);

                        update = LichGiangDayBLL.UpDateFile(update);
                    }
                    lb_thongbao_add.Text = "Sửa Thành Công";
                    lb_thongbao_add.Visible = true;
                    UpdatePanel2.Update();
                }
                catch
                {
                    lb_thongbao_add.Text = "Sửa Thất Bại";
                    lb_thongbao_add.Visible = true;
                    UpdatePanel2.Update();
                }
                

            }



            else
            {
                try
                {
                    LichGiangDay insert = new LichGiangDay();
                    insert.IdLichGiangDay = Guid.NewGuid();

                    insert.SoGio = int.Parse(txt_sogio.Text);
                    insert.BuoiHoc = txt_buoihoc.Text;
                    insert.ThoiGianBatDau = DateTime.Parse(txt_thoigianbatdau.Text);
                    insert.ThoiGianKetThuc = DateTime.Parse(txt_thoigianketthuc.Text);
                    string idPhongHoc = DropDow_PhongHoc.SelectedItem.Value;
                    insert.IdPhongHoc = Guid.Parse(idPhongHoc);
                    string idGiaoVien = DropDow_GiaoVien.SelectedItem.Value;
                    insert.IdGiaoVien = Guid.Parse(idGiaoVien); ;

                    insert.IdLop = Guid.Parse(curentId);
                    insert = LichGiangDayBLL.InsertFile(insert);


                    txt_buoihoc.Text = null;
                    txt_sogio.Text = null;
                    txt_thoigianbatdau.Text = null;
                    txt_thoigianketthuc.Text = null;

                    lb_thongbao_add.Text = "Thêm Thành Công";
                    lb_thongbao_add.Visible = true;
                    UpdatePanel2.Update();
                }

                catch
                {
                    lb_thongbao_add.Text = "Thêm Thất Bại";
                    lb_thongbao_add.Visible = true;
                    UpdatePanel2.Update();
                }

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