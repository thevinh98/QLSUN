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
    public partial class DiemDanhLop : BasePage
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
                LoadDDLLichGiangDay();
                LoadDDLLichGiangDay2();
                LoadDDLHocVien();

            }
        }
        private void LoadDDLLichGiangDay()
        {
            List<LichGiangDay> lstvaitro = LichGiangDayBLL.GetListLichHoc(curentId);

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.BuoiHoc;
                listItem.Value = item.IdLichGiangDay.ToString();
                dropdow_buoihoc.Items.Add(listItem);
            }
        }
        private void LoadDDLLichGiangDay2()
        {
            List<LichGiangDay> lstvaitro = LichGiangDayBLL.GetListLichHoc(curentId);

            foreach (var item in lstvaitro)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.BuoiHoc;
                listItem.Value = item.IdLichGiangDay.ToString();
                DropDow_lichgiangday.Items.Add(listItem);
            }
        }

        private void LoadDDLHocVien()
        {
            List<NhapHoc> lst = NhapHocBLL.GetListDanhSachHV(curentId);

            foreach (var item in lst)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.HoTen;
                listItem.Value = item.IdNhapHoc.ToString();
                DropDow_HocVien.Items.Add(listItem);
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

            List<DiemDanh> lst = DiemDanhBLL.GetListDiemDanhLopBH(curentId);
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

                DiemDanh view = DiemDanhBLL.GwtById(btn.CommandArgument);
                if (view != null)
                {
                    txt_ghichu.InnerText = view.GhiChu;



                    if (DropDow_HocVien.Items.FindByValue(view.IdNhapHoc.ToString()) != null)
                        DropDow_HocVien.SelectedValue = view.IdNhapHoc.ToString();
                   if (DropDow_lichgiangday.Items.FindByValue(view.IdLichGiangDay.ToString()) != null)
                        DropDow_lichgiangday.SelectedValue = view.IdLichGiangDay.ToString();
                    dropdow_trangthai.SelectedValue = view.TrangThai;
                    lb_id.Text = btn.CommandArgument;
                    lb_ThongBao_add.Visible = false;
                }

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if (btn != null && !string.IsNullOrEmpty(btn.CommandArgument))
            {
                DiemDanhBLL.DeleteFile(btn.CommandArgument);
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
            List<DiemDanh> lst = DiemDanhBLL.SearchList(a);
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
        //tìm kiếm buổi học

        protected void dropdow_buoihoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = dropdow_buoihoc.Items[dropdow_buoihoc.SelectedIndex].Text;
            List<DiemDanh> lst = DiemDanhBLL.SearchList(a);
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
           
            HandlePaging();
        }

        // them
        protected void Btn_Add(object sender, EventArgs e)
        {
            lb_ThongBao_add.Visible = false;
            lb_id.Text = null;
            txt_ghichu.InnerText = null;

         

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);

        }
        protected void BackView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("LopView.aspx"));
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("DiemDanhLop.aspx?Id={0}",curentId));

        }
        protected void Update_Click(object sender, EventArgs e)
        {

            

            if (!string.IsNullOrEmpty(lb_id.Text))
            {
                try
                {
                    Guid id = Guid.Parse(lb_id.Text);
                    DiemDanh update = DiemDanhBLL.GwtById(id);
                    if (update != null)
                    {
                        string idHocVien = DropDow_HocVien.SelectedItem.Value;
                        update.IdNhapHoc = Guid.Parse(idHocVien);
                        string idLGD = DropDow_lichgiangday.SelectedItem.Value;

                        update.IdLichGiangDay = Guid.Parse(idLGD);

                        update.GhiChu = txt_ghichu.InnerText.Trim();
                        update.TrangThai = dropdow_trangthai.SelectedItem.Text.Trim();
                        update = DiemDanhBLL.UpDateFile(update);
                    }
                    lb_ThongBao_add.Text = "Sửa Thành Công";
                    lb_ThongBao_add.Visible = true;
                    BindListView();
                }
                catch
                {
                    lb_ThongBao_add.Text = "Sửa Thất Bại";
                    lb_ThongBao_add.Visible = true;
                }
                UpdatePanel2.Update();
            }



            else
            {
                try
                {
                    DiemDanh insert = new DiemDanh();
                    insert.Id = Guid.NewGuid();
                    string idHocVien = DropDow_HocVien.SelectedItem.Value;
                    insert.IdNhapHoc = Guid.Parse(idHocVien);
                    string idLGD = DropDow_lichgiangday.SelectedItem.Value;
                    insert.IdLichGiangDay = Guid.Parse(idLGD);

                    insert.GhiChu = txt_ghichu.InnerText.Trim();
                    insert.TrangThai = dropdow_trangthai.SelectedItem.Text.Trim();


                    insert = DiemDanhBLL.InsertFile(insert);

                    lb_ThongBao_add.Text = "Thêm Thành Công";
                    lb_ThongBao_add.Visible = true;
                    
                    txt_ghichu.InnerText = null;

                    BindListView();

                }
                catch
                {

                    lb_ThongBao_add.Text = "Thêm Thất Bại";
                    lb_ThongBao_add.Visible = true;
                }
                UpdatePanel2.Update();

            }

        }

        protected void HocVien_SelectedIndexChanged(object sender, EventArgs e)
        {


            lb_ThongBao_add.Visible = false;
            UpdatePanel2.Update();
        }
    }
}