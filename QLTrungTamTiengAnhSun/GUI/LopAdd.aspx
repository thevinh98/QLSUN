<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="LopAdd.aspx.cs" Inherits="GUI.LopAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
    <div class="box-inner">
        <div class="box-header well" data-original-title="">
            <h2><i class="glyphicon glyphicon-user"></i>Cập Nhật Lớp Học</h2>
        </div>
        <div class="box-content1" style="margin: 5px 5px">
            <div class="alert alert-info">
                <asp:Label ID="lb_ThongBao" runat="server"   ForeColor="Black" Visible="false" class="control"></asp:Label>
            </div>

            <div class="row">
                <div class="col-sm-3">
                    <label for="comment">Tên Lớp học:</label>
                    <asp:TextBox class="form-control" ID="txt_Ten" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_Ten" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <label for="comment">Khóa Học:</label>
                   
                    <asp:DropDownList Size="1" ID="dropdow_KhoaHoc" runat="server" class="form-control">
                                     
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3">
                    <label for="comment">Học viên Tối Đa:</label>
                   
                     <asp:TextBox class="form-control" ID="txt_hocvientoida" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_hocvientoida" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
       
                </div>
                 <div class="col-sm-3">
                    <label for="comment">Trạng Thái:</label>
                   
                     <asp:DropDownList Size="1" ID="DropDown_TrangThai" runat="server" class="form-control">
                        <asp:ListItem>Sắp Mở</asp:ListItem>
                        <asp:ListItem>Đang mở</asp:ListItem>
                          <asp:ListItem>Đã Kết Thúc</asp:ListItem>
                        
                    </asp:DropDownList>
       
       
                </div>
            </div>
              <div class="row">
                   <div class="col-sm-3">
                    <label for="comment">Số buổi học:</label>
                   
                     <asp:TextBox class="form-control" ID="txt_sobuoihoc" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_sobuoihoc" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
       
                </div>
                <div class="col-sm-3">
                    <label for="comment">Thời gian Bắt Đầu:</label>
                    <asp:TextBox  TextMode="Date" class="form-control" ID="txt_thoigianbatdau" runat="server"></asp:TextBox>
                <asp:Label ID="lb_thoigianbatdau" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <label for="comment">Thời gian Kết Thúc:</label>
                    <asp:TextBox  TextMode="Date" class="form-control" ID="txt_thoigianketthuc" runat="server"></asp:TextBox>
                <asp:Label ID="lb_thoigianketthuc" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <label for="comment">Học phí:</label>
                   
                     <asp:TextBox class="form-control" ID="txt_hocphi" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_hocphi" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
       
       
                </div>
                   
            </div>
            <div class="row">
                <div class="col-sm-12">
                     <div class="form-group">
                        <label for="comment">Ghi Chú:</label>
                        <textarea class="form-control" rows="5" id="txt_Ghichu" runat="server"></textarea>
                    </div>
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

