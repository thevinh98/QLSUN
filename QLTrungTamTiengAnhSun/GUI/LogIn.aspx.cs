using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Public;

namespace GUI
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ispostback sẽ không xóa các value của thẻ html
                // Tức là khi nhấn button nó sẽ không nhảy vào trong hàm iff này. 
                // Chỉ vào khi load lại trang.
                if (Request.Cookies["TenDangNhap"] != null && Request.Cookies["PassWord"] != null)
                {
                    string userName = Request.Cookies["TenDangNhap"].Value;
                    string password = Request.Cookies["PassWord"].Value;

                    NguoiDungADM user = NguoiDungADMBLL.GetUserByUserName(userName);
                    if (user != null)
                    {
                        Session["Currentuser"] = user;
                    }


                }
                else
                {

                    if (Request.Cookies["TenDangNhap"] != null && Request.Cookies["PassWord"] != null)
                    {
                        string userName = Request.Cookies["TenDangNhap"].Value;
                        string password = Request.Cookies["PassWord"].Value;

                        NguoiDungGiaoVien user1 = NguoiDungGiaoVienBLL.GetUserByUserName(userName);
                        if (user1 != null)
                        {
                            Session["Currentuser"] = user1;
                        }

                        //    Kiểm tra xem nếu có đăng nhập rồi thì không cần đăng nhập lại.
                        //  if (Session["Currentuser"] != null)
                        //  {
                        //     Response.Redirect("/default.aspx", false);
                        // }
                    }
                    else
                    {
                        if (Request.Cookies["TenDangNhap"] != null && Request.Cookies["PassWord"] != null)
                        {
                            string userName = Request.Cookies["TenDangNhap"].Value;
                            string password = Request.Cookies["PassWord"].Value;

                            NguoiDungHocVien user2 = NguoiDungHocVienBLL.GetUserByUserName(userName);
                            if (user2 != null)
                            {
                                Session["Currentuser"] = user2;
                            }

                            //    Kiểm tra xem nếu có đăng nhập rồi thì không cần đăng nhập lại.
                            //  if (Session["Currentuser"] != null)
                            //  {
                            //     Response.Redirect("/default.aspx", false);
                            // }
                        }
                    }
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // ẩn lại các label thông báo
            lbNoti_usr.Visible = false;
            LbNoti_pw.Visible = false;
            bool valid = false;
            // Kiểm tra User name password có được nhập hay không
            if (string.IsNullOrEmpty(txt_user1.Text))
            {
                lbNoti_usr.Text = "Vui lòng nhập tài khoản!";
                valid = true;
                lbNoti_usr.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_pw1.Text))
            {
                LbNoti_pw.Text = "vui lòng nhập passord!";
                valid = true;
                LbNoti_pw.Visible = true;
            }
            if (valid)
            {
                return;
            }
            else
            {
                NguoiDungADM user = NguoiDungADMBLL.GetUserByUserName(txt_user1.Text.Trim());
                if (user != null)
                {
                    if (user.TrangThai == true)
                    {
                        // .Trim là loại bỏ các khoảng trắng đầu cuối
                        if (user.MatKhau == txt_pw1.Text.Trim())
                        {
                            // Chỗ này còn một bước lưu cookie, tìm hiểu rồi cập nhật thêm. 
                            // Đó là chức năng remember me
                            if (cb_remenber.Checked)
                            {
                                Response.Cookies["TenDangNhap"].Value = txt_user1.Text;
                                Response.Cookies["PassWord"].Value = txt_pw1.Text;
                                Response.Cookies["TenDangNhap"].Expires = DateTime.Now.AddDays(30);
                                Response.Cookies["PassWord"].Expires = DateTime.Now.AddDays(30);
                            }
                            else
                            {
                                Response.Cookies["TenDangNhap"].Expires = DateTime.Now.AddMinutes(-1);
                                Response.Cookies["PassWord"].Expires = DateTime.Now.AddMinutes(-1);
                            }

                            // Login thành công
                            Session["Currentuser"] = user;
                            Response.Redirect("/default.aspx", false);
                        }
                        else
                        {
                            LbNoti_pw.Text = "Mật khẩu không đúng";
                            LbNoti_pw.Visible = true;
                            return;
                        }
                    }

                    //

                }
                else
                {
                    NguoiDungHocVien user1 = NguoiDungHocVienBLL.GetUserByUserName(txt_user1.Text.Trim());
                    if (user1 != null)
                    {
                        if (user1.TrangThai == true)
                        {
                            // .Trim là loại bỏ các khoảng trắng đầu cuối
                            if (user1.MatKhau == txt_pw1.Text.Trim())
                            {
                                // Chỗ này còn một bước lưu cookie, tìm hiểu rồi cập nhật thêm. 
                                // Đó là chức năng remember me
                                if (cb_remenber.Checked)
                                {
                                    Response.Cookies["TenDangNhap"].Value = txt_user1.Text;
                                    Response.Cookies["PassWord"].Value = txt_pw1.Text;
                                    Response.Cookies["TenDangNhap"].Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies["PassWord"].Expires = DateTime.Now.AddDays(30);
                                }
                                else
                                {
                                    Response.Cookies["TenDangNhap"].Expires = DateTime.Now.AddMinutes(-1);
                                    Response.Cookies["PassWord"].Expires = DateTime.Now.AddMinutes(-1);
                                }

                                // Login thành công
                                Session["Currentuser"] = user1;
                                Response.Redirect("/ThongTinThongBao.aspx", false);
                            }
                            else
                            {
                                LbNoti_pw.Text = "Mật khẩu không đúng";
                                LbNoti_pw.Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            lbNoti_usr.Text = "Tài khoản của bạn đã bị khóa";
                            lbNoti_usr.Visible = true;
                            return;
                        }
                    }
                    else
                    {
                        NguoiDungGiaoVien user2 = NguoiDungGiaoVienBLL.GetUserByUserName(txt_user1.Text.Trim());
                        if (user2 != null)
                        {
                            if (user2.TrangThai == true)
                            {
                                // .Trim là loại bỏ các khoảng trắng đầu cuối
                                if (user2.MatKhau == txt_pw1.Text.Trim())
                                {
                                    // Chỗ này còn một bước lưu cookie, tìm hiểu rồi cập nhật thêm. 
                                    // Đó là chức năng remember me
                                    if (cb_remenber.Checked)
                                    {
                                        Response.Cookies["TenDangNhap"].Value = txt_user1.Text;
                                        Response.Cookies["PassWord"].Value = txt_pw1.Text;
                                        Response.Cookies["TenDangNhap"].Expires = DateTime.Now.AddDays(30);
                                        Response.Cookies["PassWord"].Expires = DateTime.Now.AddDays(30);
                                    }
                                    else
                                    {
                                        Response.Cookies["TenDangNhap"].Expires = DateTime.Now.AddMinutes(-1);
                                        Response.Cookies["PassWord"].Expires = DateTime.Now.AddMinutes(-1);
                                    }

                                    // Login thành công
                                    Session["Currentuser"] = user2;
                                    Response.Redirect("/StyleGV/ThongBaoGV.aspx", false);
                                }
                                else
                                {
                                    LbNoti_pw.Text = "Mật khẩu không đúng";
                                    LbNoti_pw.Visible = true;
                                    return;
                                }
                            }
                            else
                            {
                                lbNoti_usr.Text = "Tài khoản của bạn đã bị khóa";
                                lbNoti_usr.Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            lbNoti_usr.Text = "Tài khoản không đúng";
                            lbNoti_usr.Visible = true;
                            return;
                        }
                    }
                }
            }

        }


    }
}

