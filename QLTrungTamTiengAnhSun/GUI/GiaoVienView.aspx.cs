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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace GUI
{
    public partial class GiaoVienView : BasePage
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

            List<GiaoVien> lst = GiaoVienBLL.GetListGiaoVien();
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
                GiaoVien view = GiaoVienBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {

                    txt_Ten.Text = view.HoTen;
                    Txt_NamSinh.Text = view.NamSinh.ToString("yyyy-MM-dd");
                    txt_ngayvaolam.Text = view.NgayVaoLam.ToString("yyyy-MM-dd");
                    txt_DiaChi.Text = view.DiaChi;
                    txt_Email.Text = view.Email;
                    txt_SDT.Text = view.Sdt;
                    DropDow_Trinhdo.SelectedValue = view.TrinhDo;
                    dropdow_gioitinh.SelectedValue = view.GioiTinh;
                    DropDown_TrangThai.SelectedValue = view.TrangThai;
                    lb_id.Text = btn.CommandArgument;
                }
                lb_trangthai.Visible = false;
                lb_Ten.Visible = false;
                lb_SDT.Visible = false;
                lb_ngayvaolam.Visible = false;
                lb_Namsinh.Visible = false;
                Lb_Email.Visible = false;
                lb_diachi.Visible = false;
                lb_thongbao_add.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true); ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                GiaoVienBLL.DeleteFile(btn.CommandArgument);
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
            List<GiaoVien> lst = GiaoVienBLL.SearchList(a);
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
        //thêm

        protected void Btn_Add(object sender, EventArgs e)
        {
            txt_DiaChi.Text = null;
            txt_Email.Text = null;
            Txt_NamSinh.Text = null;
            txt_ngayvaolam.Text = null;
            txt_SDT.Text = null;
            txt_Ten.Text = null;
            lb_thongbao_add.Text = null;
            lb_id.Text = null;
            lb_trangthai.Visible = false;
            lb_Ten.Visible = false;
            lb_SDT.Visible = false;
            lb_ngayvaolam.Visible = false;
            lb_Namsinh.Visible = false;
            Lb_Email.Visible = false;
            lb_diachi.Visible = false;
            lb_thongbao_add.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("GiaoVienView.aspx"));
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            lb_Ten.Visible = false;
            lb_diachi.Visible = false;
            Lb_Email.Visible = false;
            lb_Namsinh.Visible = false;
            lb_ngayvaolam.Visible = false;
            bool valid = false;

            if (string.IsNullOrEmpty(Txt_NamSinh.Text.Trim()))
            {
                lb_Namsinh.Text = "Vui Lòng nhập năm sinh !";
                lb_Namsinh.Visible = true;
                valid = true;
                lb_Ten.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_ngayvaolam.Text.Trim()))
            {
                lb_ngayvaolam.Text = "Vui Lòng nhập ngày vào làm !";
                lb_ngayvaolam.Visible = true;
                valid = true;
                lb_Ten.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }

            if (string.IsNullOrEmpty(txt_Ten.Text.Trim()))
            {
                lb_Ten.Text = "Vui Lòng nhập tên học viên !";
                valid = true;
                lb_Ten.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            Regex gmail = new Regex(@"^([\w]*[\w\.]*(?!\.)@gmail.com)");
            if (!gmail.IsMatch(txt_Email.Text))
            {
                Lb_Email.Text = "Định dạng Email không hợp lệ !";
                valid = true;
                Lb_Email.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_Email.Text.Trim()))
            {
                Lb_Email.Text = "Vui Lòng nhập Email !";
                valid = true;
                Lb_Email.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();

            }
            if (string.IsNullOrEmpty(txt_DiaChi.Text.Trim()))
            {
                lb_diachi.Text = "Vui Lòng nhập địa chỉ!";
                valid = true;
                lb_diachi.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();

            }
            Regex regex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");

            if (!regex.IsMatch(txt_SDT.Text))
            {
                lb_SDT.Text = "SDT không hợp lệ !";
                valid = true;
                lb_SDT.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (txt_SDT.Text.Trim().Length <= 8 || txt_SDT.Text.Trim().Length >= 12)
            {
                lb_SDT.Text = "SDT từ 9 đến 13 chữ số !";
                valid = true;
                lb_SDT.Visible = true;
                lb_thongbao_add.Text = "Cập nhật thất bại";
                lb_thongbao_add.Visible = true;
                UpdatePanel2.Update();
            }
            if (string.IsNullOrEmpty(txt_SDT.Text.Trim()))
            {
                lb_SDT.Text = "Vui Lòng nhập Số điện thoại !";
                valid = true;
                lb_SDT.Visible = true;
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
                    GiaoVien update = GiaoVienBLL.GwtById(id);
                    if (update != null)
                    {

                        update.HoTen = txt_Ten.Text;
                        update.NgayVaoLam = DateTime.Parse(txt_ngayvaolam.Text);
                        update.NamSinh = DateTime.Parse(Txt_NamSinh.Text);

                        update.Sdt = txt_SDT.Text;
                        update.DiaChi = txt_DiaChi.Text;
                        update.Email = txt_Email.Text;
                        update.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                        update.TrinhDo = DropDow_Trinhdo.SelectedItem.Text;
                        update.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                        update = GiaoVienBLL.UpDateFile(update);
                        lb_thongbao_add.Text = "Sửa Thành Công";
                        lb_thongbao_add.Visible = true;
                        UpdatePanel2.Update();
                    }

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
                    GiaoVien insert = new GiaoVien();
                    insert.IdGiaoVien = Guid.NewGuid();

                    insert.HoTen = txt_Ten.Text;
                    insert.NgayVaoLam = DateTime.Parse(txt_ngayvaolam.Text);
                    insert.NamSinh = DateTime.Parse(Txt_NamSinh.Text);
                    insert.GioiTinh = dropdow_gioitinh.SelectedItem.Text;
                    insert.Sdt = txt_SDT.Text;
                    insert.DiaChi = txt_DiaChi.Text;
                    insert.Email = txt_Email.Text;
                    insert.TrangThai = DropDown_TrangThai.SelectedItem.Text;
                    insert.TrinhDo = DropDow_Trinhdo.SelectedItem.Text;
                    insert = GiaoVienBLL.InsertFile(insert);
                    txt_DiaChi.Text = null;
                    txt_Email.Text = null;
                    Txt_NamSinh.Text = null;
                    txt_ngayvaolam.Text = null;
                    txt_SDT.Text = null;
                    txt_Ten.Text = null;
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
          
                try
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
                catch
                {

                }

            



        }
        protected void XuatExcel_Click(object sender, EventArgs e)
        {

            XuatDuLieuRaExcel();


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
          server control at run time. */
        }
        private void XuatDuLieuGridRaWord(GridView MyGridview)
        {
            try
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
            catch
            {

            }


        }
        protected void Word_Click(object sender, EventArgs e)
        {
            XuatDuLieuGridRaWord(Gr_View);

        }
    }
}