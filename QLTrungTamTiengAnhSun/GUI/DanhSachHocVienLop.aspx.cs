﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;
using System.Drawing;
using System.Data;
using System.IO;

namespace GUI
{
    public partial class DanhSachHocVienLop : BasePage
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

             
                LoadDDLHocVien();
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

            List<NhapHoc> lst = NhapHocBLL.GetListDanhSachHV(curentId);
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

                NhapHoc view = NhapHocBLL.GwtById(btn.CommandArgument);
                var id = view.IdHocVien.ToString();
                if (view != null)
                {
                    txt_ghichu.InnerText = view.GhiChu;



                    if (DropDow_HocVien.Items.FindByValue(view.IdHocVien.ToString()) != null)
                        DropDow_HocVien.SelectedValue = view.IdHocVien.ToString();
                    
                    DropDown_TrangThai.SelectedValue = view.TrangThai;
                    lb_id.Text = btn.CommandArgument;
                }
                List<KetQuaTuyenSinh> hv = KetQuaTuyenSinhBLL.GetListKetQuaTuyenSinh_TT(id);
                Gr_TT.DataSource = hv;
                Gr_TT.DataBind();
                UpdatePanel2.Update();
            }
           
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                NhapHocBLL.DeleteFile(btn.CommandArgument);
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
            if (String.IsNullOrEmpty(txt_search.Text))
            {
                BindListView();
            }
            else
            {
                String a = txt_search.Text.Trim();
                List<NhapHoc> lst = NhapHocBLL.SearchList(a);
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

        protected string VisibleButtonViewMore(object text, int number)
        {
            if (text != null && text.ToString() != string.Empty && text.ToString().Length > number)
            {
                return string.Empty;
            }
            return "display:none";
        }
        //them Mói

        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_ghichu.InnerText = null;

            lb_id.Text = null;

            lb_thongbao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

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
        protected void BackView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("LopView.aspx"));
        }
        protected void Update_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(lb_id.Text))
            {
                try
                {
                    Guid id = Guid.Parse(lb_id.Text);
                    NhapHoc update = NhapHocBLL.GwtById(id);
                    if (update != null)
                    {
                        string idHocVien = DropDow_HocVien.SelectedItem.Value;
                        update.IdHocVien = Guid.Parse(idHocVien);
                       
                        update.IdLop = Guid.Parse(curentId);

                        update.GhiChu = txt_ghichu.InnerText.Trim();

                        update.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                        update = NhapHocBLL.UpDateFile(update);
                    }
                    lb_thongbao_add.Text = "Sửa Thành Công";
                    lb_thongbao_add.Visible = true;
                }
                catch
                {
                    lb_thongbao_add.Text = "Sửa Thất bại";
                    lb_thongbao_add.Visible = true;
                }
                UpdatePanel2.Update();
            }



            else
            {
                try
                {
                    NhapHoc insert = new NhapHoc();
                    insert.IdNhapHoc = Guid.NewGuid();
                    string idHocVien = DropDow_HocVien.SelectedItem.Value;
                    insert.IdHocVien = Guid.Parse(idHocVien);
                  
                    insert.IdLop = Guid.Parse(curentId);

                    insert.GhiChu = txt_ghichu.InnerText.Trim();

                    insert.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                    insert = NhapHocBLL.InsertFile(insert);
                    txt_ghichu.InnerText = null;

                    lb_thongbao_add.Text = "Thêm Thành Công";
                    lb_thongbao_add.Visible = true;
                }

                catch
                {
                    lb_thongbao_add.Text = "Thêm Thất Bại";
                    lb_thongbao_add.Visible = true;
                }

                UpdatePanel2.Update();

            }

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format ("DanhSachHocVienLop.aspx?Id={0}",curentId));
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

        //

        protected void HocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = DropDow_HocVien.Items[DropDow_HocVien.SelectedIndex].Value;
            List<KetQuaTuyenSinh> hv = KetQuaTuyenSinhBLL.GetListKetQuaTuyenSinh_TT(id);
            Gr_TT.DataSource = hv;
            Gr_TT.DataBind();
            UpdatePanel2.Update();

            lb_thongbao_add.Visible = false;

        }
    }
}