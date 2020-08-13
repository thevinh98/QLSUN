using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;

namespace GUI.StyleGV
{
    public partial class layout_giaovien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
            }
        }
        protected void LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("/LogIn.aspx"));
        }
        protected void BindListView()
        {
            if (Session["Currentuser"] != null)
            {
                NguoiDungGiaoVien user = Session["Currentuser"] as NguoiDungGiaoVien;
                if (user != null)
                {
                    var id = user.IdGiaoVien.ToString();

                    List<GiaoVien> lst = GiaoVienBLL.ThongTinGiaoVien(id);

                    Rep_View_TT.DataSource = lst;
                    Rep_View_TT.DataBind();

                }
            }

        }
        // doi pass
        protected void PassWork_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
        }
        protected void btn_Pass_Click(object sender, EventArgs e)
        {
            if (Session["Currentuser"] != null)
            {

                NguoiDungGiaoVien user = Session["Currentuser"] as NguoiDungGiaoVien;
                lb_Password1.Visible = false;
                lb_pass.Visible = false;
                lb_Password2.Visible = false;
                lb_notipass.Visible = false;
                lb_noti_nd.Visible = false;



                bool valid = false;

                if (txtPassword1.Text.Trim() == txtPass.Text.Trim() && txtPassword1.Text.Trim() != null)
                {
                    lb_Password1.Text = "Mật khẩu trùng mật khẩu cũ ! Vui Lòng Nhập Lại !";
                    valid = true;
                    lb_Password2.Visible = false;
                    lb_Password1.Visible = true;
                    //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
                    UpdatePanel2.Update();

                }
                if (txtPassword1.Text.Length <= 5 || txtPassword1.Text.Length >= 19)
                {
                    lb_Password1.Text = "Độ dài mật khẩu phải từ 6 đến 20 kí tự !";
                    valid = true;
                    lb_Password1.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
                    UpdatePanel2.Update();
                }
                if (txtPass.Text.Trim() != user.MatKhau.ToString())
                {
                    lb_pass.Text = "Mật Khẩu Không chính Xác !";
                    valid = true;
                    lb_pass.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
                    UpdatePanel2.Update();

                }
                if (string.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    lb_pass.Text = "Vui Lòng Nhập Mật Khẩu Cũ !";
                    valid = true;
                    lb_pass.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
                    UpdatePanel2.Update();

                }
                if (string.IsNullOrEmpty(txtPassword1.Text.Trim()))
                {
                    lb_Password1.Text = "Vui Lòng Nhập Mật Khẩu Mới !";
                    valid = true;
                    lb_Password1.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
                    UpdatePanel2.Update();

                }
                if (string.IsNullOrEmpty(txtPassword1.Text.Trim()))
                {
                    lb_Password2.Text = "Vui Lòng Nhập Lại Mật Khẩu Mới !";
                    valid = true;
                    lb_Password2.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
                    UpdatePanel2.Update();

                }
                if (txtPassword2.Text.Trim() != txtPassword1.Text.Trim())
                {
                    lb_Password2.Text = "Nhập Lại Mật Khẩu không chính xác !";
                    valid = true;
                    lb_Password2.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PassModal", "$('#PassModal').modal();", true);
                    UpdatePanel2.Update();

                }


                if (valid)
                {
                    return;
                }
                else
                {

                    if (user != null)
                    {
                        var idnd = user.Id.ToString();
                        // eidt
                        Guid id = Guid.Parse(idnd);
                        NguoiDungGiaoVien updatend = NguoiDungGiaoVienBLL.GwtById(id);

                        if (updatend != null)
                        {

                            updatend.MatKhau = txtPassword1.Text;



                            updatend = NguoiDungGiaoVienBLL.UpDateFile(updatend);
                            //Response.Redirect(string.Format("Default.aspx"));
                            lb_Password1.Visible = false;
                            lb_pass.Visible = false;
                            lb_Password2.Visible = false;

                            txtPass.Visible = false;
                            txtPassword1.Visible = false;
                            txtPassword2.Visible = false;
                            lb_notipass.Visible = false;
                            lb_notipassword1.Visible = false;
                            lb_notipass2.Visible = false;
                            lb_noti_nd.Visible = true;
                            btnLogin.Visible = false;

                            UpdatePanel2.Update();
                        }

                    }


                }
            }


        }
    }
}