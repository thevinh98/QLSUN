using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Public;
using BLL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace GUI
{
    public partial class Default1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TongGiaoVien();
            TongLop();
            TongNhanVien();
            TongHocVien();
            DemHP();
            DemTBGiaoVien();
            DemTBLop();
        }
        //protected void BindListView()
        //{

        //    String myConnection = ConfigurationManager.ConnectionStrings["QLSUN"].ToString();
        //    SqlConnection con = new SqlConnection(myConnection);
        //    String query = "Select top 100 * From HocPhi";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    DataTable tb = new DataTable();
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        tb.Load(dr, LoadOption.OverwriteChanges);
        //        con.Close();
        //    }
        //    catch { }
        //    if (tb != null)
        //    {
        //        String chart = "";
        //        // You can change your chart height by modify height value
        //        chart = "<canvas id=\"line-chart\" width =\"100%\" height=\"40\"></canvas>";
        //        chart += "<script>";
        //        chart += "new Chart(document.getElementById(\"line-chart\"), {type: 'line', data:{labels: [";

        //        // more details in x-axis
        //                for (int i = 0; i < 100; i++)
        //                    chart += i.ToString() + ",";
        //                chart = chart.Substring(0, chart.Length - 1);

        //                chart += "],datasets: [{ data: [";

        //                // put data from database to chart
        //                String value = "";
        //                for (int i = 0; i < tb.Rows.Count; i++)
        //                    value += tb.Rows[i]["TienThanhToan"].ToString() + ",";
        //                value = value.Substring(0, value.Length - 1);

        //                chart += value;

        //                chart += "],label: \"Air Temperature\",borderColor: \"#3e95cd\",fill: true}"; // Chart color
        //                chart += "]},options: { title: { display: true,text: 'Air Temperature (oC)'}}"; // Chart title
        //        chart += "});";
        //        chart += "</script>";

        //        ltChart.Text = chart;
        //    }



        //}
        protected void DemHP()
        {
            String time = DateTime.Now.ToString("MM/dd/yyyy");
            
            List<HocPhi> hp = HocPhiBLL.DemHocPhi(time);
            rep_count_hp.DataSource = hp;
            rep_count_hp.DataBind();
        }
        protected void DemTBLop()
        {
            String time = DateTime.Now.ToString("MM/dd/yyyy");

            List<ThongBaoLop> hp = ThongBaoLopBLL.DemThongBao(time);
            Rep_count_TBLop.DataSource = hp;
            Rep_count_TBLop.DataBind();
        }
        protected void DemTBGiaoVien()
        {
            String time = DateTime.Now.ToString("MM/dd/yyyy");

            List<ThongBaoGiaoVien> hp = ThongBaoGiaoVienBLL.DemThongBao(time);
            Rep_count_TBGiaoVien.DataSource = hp;
            Rep_count_TBGiaoVien.DataBind();
        }
        protected void HocPhi_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachHocPhiHomNay.aspx");
        }
        protected void ThongBaoLopHomNay_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachThongBaoLopHomNay.aspx");
        }
        protected void TbGiaoVien_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachThongBaoGVHomNay.aspx");
        }
        // tong
        protected void TongLop()
        {
         

            List<Lop> lst = LopBLL.TongLop();
            rep_TongLop.DataSource = lst;
            rep_TongLop.DataBind();
        }
        protected void TongNhanVien()
        {


            List<NhanVien> lst = NhanVienBLL.TongNhanVien();
            Rep_TongNV.DataSource = lst;
            Rep_TongNV.DataBind();
        }
        protected void TongGiaoVien()
        {


            List<GiaoVien> lst = GiaoVienBLL.TongGiaoVien();
            Rep_TongGV.DataSource = lst;
            Rep_TongGV.DataBind();
        }
        protected void TongHocVien()
        {


            List<HocVien> lst = HocVienBLL.TongHocVien();
            Rep_TongHV.DataSource = lst;
            Rep_TongHV.DataBind();
        }
        protected void TongNV_Click(object sender, EventArgs e)
        {
            Response.Redirect("NhanVienViewDL.aspx");
        }
        protected void TongGV_Click(object sender, EventArgs e)
        {
            Response.Redirect("GiaoVienView.aspx");
        }
        protected void TongLop_Click(object sender, EventArgs e)
        {
            Response.Redirect("LopView.aspx");
        }
        protected void TongHV_Click(object sender, EventArgs e)
        {
            Response.Redirect("NhapHocView.aspx");
        }

    }
}