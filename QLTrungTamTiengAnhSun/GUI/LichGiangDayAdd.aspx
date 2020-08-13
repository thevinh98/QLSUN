<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="LichGiangDayAdd.aspx.cs" Inherits="GUI.LichGiangDayAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Cập Nhật Lịch Giảng Dạy</h2>
                </div>
                <div class="box-content1" style="margin: 5px 5px">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label for="comment">Lớp Học:</label>
                             <asp:DropDownList Size="1" ID="DropDow_Lop" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <label for="comment">Buổi Học:</label>
                            <asp:TextBox  class="form-control" ID="txt_buoihoc" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_buoihoc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <label for="comment">Phòng Học:</label>
                             <asp:DropDownList Size="1" ID="DropDow_PhongHoc" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <label for="comment">Thời Gian Bắt Đầu:</label>
                            <asp:TextBox  TextMode="DateTimeLocal" class="form-control" ID="txt_thoigianbatdau" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_thoigianbatdau" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <label for="comment">Thời Gian Kết Thúc:</label>
                            <asp:TextBox TextMode="DateTimeLocal" class="form-control" ID="txt_thoigianketthuc" runat="server"></asp:TextBox>

                            <asp:Label ID="lb_thoigianketthuc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <label for="comment">Số Giờ Học:</label>
                            <asp:TextBox  class="form-control" ID="txt_sogio" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_sogiohoc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <label for="comment">Giáo Viên:</label>
                            <asp:DropDownList Size="1" ID="DropDow_GiaoVien" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:Label ID="lb_GiaoVien" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            
                        </div>
                        <div class="col-sm-4">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
