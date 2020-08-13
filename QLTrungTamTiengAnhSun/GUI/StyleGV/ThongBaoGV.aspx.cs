﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Public;
using BLL;

namespace GUI.StyleGV
{
    public partial class ThongBaoGV : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindListView();
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
            
                BindListView();
           
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
           
                BindListView();
           
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            
                BindListView();
           
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
           
                BindListView();
           

        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            
                BindListView();
            
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
            try
            {
                if (Session["Currentuser"] != null)
                {
                    NguoiDungGiaoVien user = Session["Currentuser"] as NguoiDungGiaoVien;
                    if (user != null)
                    {
                        var id = user.IdGiaoVien.ToString();

                        List<ThongBaoGiaoVien> lst = ThongBaoGiaoVienBLL.GetListThongBaoGiaoVien_client(id);
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
                }
            }
            catch
            {

            }

        }
        protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_op.Text = cboCountry.Items[cboCountry.SelectedIndex].Value;

            BindListView();

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
    }
}