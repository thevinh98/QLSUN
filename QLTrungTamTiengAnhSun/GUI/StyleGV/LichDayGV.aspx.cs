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

namespace GUI.StyleGV
{
    public partial class LichDayGV : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                div_lichday.Visible = false;
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

            thongKe_Click(sender, e);

        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);


            thongKe_Click(sender, e);

        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;

            thongKe_Click(sender, e);

        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;

            thongKe_Click(sender, e);


        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());

            thongKe_Click(source, e);

        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#00FF00");
        }
        //-------- kết thúc phân trang---------
        


        // sửa



        protected void thongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Currentuser"] != null)
                {
                    NguoiDungGiaoVien user = Session["Currentuser"] as NguoiDungGiaoVien;
                    if (user != null)
                    {
                        var a = user.IdGiaoVien.ToString();

                        div_lichday.Visible = true;
                       
                        String b = txt_ngaybatdau.Text;
                        String c = txt_ngayKetThuc.Text;
                        List<LichGiangDay> lst = LichGiangDayBLL.SearchListLichDayGV(a, b, c);
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
                }
            }
            catch
            {

            }
        }
        protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_op.Text = cboCountry.Items[cboCountry.SelectedIndex].Value;

            thongKe_Click(sender, e);

        }
        protected void dropdow_GiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_op.Text = cboCountry.Items[cboCountry.SelectedIndex].Value;

        }

        //them mới




       


    }
}