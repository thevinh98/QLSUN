<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="GUI.LogIn" %>



<!DOCTYPE html>
<html lang="en">
<head>
    <title>ĐĂNG NHẬP</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="StyleLogin/login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/css/util.css">
    <link rel="stylesheet" type="text/css" href="StyleLogin/login/css/main.css">
    <!--===============================================================================================-->
</head>
<body>


    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-form-title" style="background-image: url(StyleLogin/login/images/bg-01.jpg);">
                    <span class="login100-form-title-1">ĐĂNG NHẬP
                    </span>
                </div>

                <form class="login100-form validate-form" id="form2" runat="server" style="place-content: center;">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                                <span class="label-input100" style=" width:auto;">Tên đăng nhập</span>

                                <%--  <input class="input100" id="txt_user1" runat="server" type="text" name="username" placeholder="Enter username">--%>
                                <asp:TextBox placeholder="Nhập tên đăng nhập " type="Text" ID="txt_user1" runat="server" style="margin-left: 20px;" Class="input100"></asp:TextBox>
                                <span class="focus-input100"></span>
                            </div>
                            <asp:Label ID="lbNoti_usr" runat="server" Style="color: red" Visible="false" />
                            <div class="wrap-input100 validate-input m-b-18" data-validate="Password is required">
                                <span class="label-input100" style=" width:auto;">Mật khẩu</span>
                                <%--  <input class="input100" type="password" id="txt_pw" runat="server" name="pass" placeholder="Enter password">--%>
                                <asp:TextBox placeholder="Nhập mật khẩu " TextMode="Password" ID="txt_pw1" runat="server" style="margin-left: 20px;" Class="input100"></asp:TextBox>

                                <span class="focus-input100"></span>
                            </div>
                            <asp:Label ID="LbNoti_pw" runat="server" Style="color: red" Visible="false" />
                            <div class="flex-sb-m w-full p-b-30">
                                    <asp:CheckBox ID="cb_remenber" runat="server" Text="Nhớ mật khẩu" />
                                    <label >
                                     
                                    </label>
                              
                            </div>

                            <div class="container-login100-form-btn">

                                <%--    <asp:Button  class="login100-form-btn" ID="btn_login1" Text="LogIn" runat="server"  OnClick="btnLogin_Click" />--%>
                                <asp:Button class="login100-form-btn" ID="btn_login" runat="server" Text="ĐĂNG NHẬP" OnClick="btnLogin_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>
    </div>



    <!--===============================================================================================-->
    <script src="StyleLogin/login/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="StyleLogin/login/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="StyleLogin/login/vendor/bootstrap/js/popper.js"></script>
    <script src="StyleLogin/login/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="StyleLogin/login/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="StyleLogin/login/vendor/daterangepicker/moment.min.js"></script>
    <script src="StyleLogin/login/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="StyleLogin/login/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="StyleLogin/login/js/main.js"></script>

</body>
</html>

