<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="NhanVienAdd.aspx.cs" Inherits="GUI.NhanVienAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="box-inner">
        <div class="box-header well" data-original-title="">
            <h2><i class="glyphicon glyphicon-user"></i>Cập Nhật Nhân Viên</h2>
        </div>
        <div class="box-content1" style="margin: 5px 5px">
            <div class="alert alert-info">
                <asp:Label ID="lb_ThongBao" runat="server"   ForeColor="Black" Visible="false" class="control"></asp:Label>
            </div>

            <div class="row">
                <div class="col-sm-4">
                    <label for="comment">Tên Nhân Viên:</label>
                    <asp:TextBox class="form-control" ID="txt_Ten" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_Ten" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <label for="comment">Năm Sinh:</label>
                    <asp:TextBox  TextMode="Date" class="form-control" ID="Txt_NamSinh" runat="server"></asp:TextBox>
                  <asp:Label ID="lb_Namsinh" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <label for="comment">Số Điện Thoại:</label>
                    <asp:TextBox TextMode="Number" class="form-control" ID="txt_SDT" runat="server"></asp:TextBox>
                     <asp:Label ID="lb_SDT" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="col-sm-4">
                    <label for="comment">Email:</label>
                    <asp:TextBox TextMode="Email" class="form-control" ID="txt_Email" runat="server"></asp:TextBox>
                    <asp:Label ID="Lb_Email" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <label for="comment">Địa Chỉ:</label>
                    <asp:TextBox class="form-control" ID="txt_DiaChi" runat="server"></asp:TextBox>

                     <asp:Label ID="lb_diachi" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <label for="comment">Ngày Vào Làm:</label>
                    <asp:TextBox TextMode="Date" class="form-control" ID="txt_NgayLam" runat="server"></asp:TextBox>
                  <asp:Label ID="lb_ngayVaoLam" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="col-sm-4">
                    <label for="comment">Chức Vụ:</label>
                  <asp:DropDownList Size="1" ID="DropDow_ChucVu" runat="server" class="form-control">
                        
                    </asp:DropDownList>
                    <asp:Label ID="lb_chucvu" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <label for="comment">Trạng Thái:</label>
                   
                    <asp:DropDownList Size="1" ID="DropDown_TrangThai" runat="server" class="form-control">
                        <asp:ListItem> Đang Làm</asp:ListItem>
                        <asp:ListItem> Thử Việc</asp:ListItem>
                        <asp:ListItem> Nghỉ</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lb_trangthai" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                 <div class="col-sm-4">
                     <label for="comment">Giới Tính:</label>
                   
                    <asp:DropDownList Size="1" ID="dropdow_gioitinh" runat="server" class="form-control">
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Nữ</asp:ListItem>
                        <asp:ListItem>Khác</asp:ListItem>
                        
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <br />
                </div>

            </div>
            <hr />
            <div class="row">
                <div class="col-sm-4">
                </div>
                <div class="col-sm-4">
                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="Back_Click"><i class="glyphicon glyphicon-arrow-left icon-white"></i> Back</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="Update_Click"><i class="glyphicon glyphicon-ok-sign icon-white"></i> Cập Nhật</asp:LinkButton>
                </div>
                <div class="col-sm-4">
                </div>
            </div>
        </div>

    </div>

</asp:Content>