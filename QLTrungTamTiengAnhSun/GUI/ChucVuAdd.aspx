<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="ChucVuAdd.aspx.cs" Inherits="GUI.ChucVuAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <div class="box-inner">
        <div class="box-header well" data-original-title="">
            <h2><i class="glyphicon glyphicon-user"></i>Thêm Mới Chức Vụ</h2>
        </div>
        <div class="box-content1" style="margin: 5px 5px">
            <div class="alert alert-info">
                <asp:Label ID="lb_ThongBao" runat="server"   ForeColor="Black" Visible="false" class="control"></asp:Label>
            </div>

            <div class="row">
                <div class="col-sm-4">
                    <label for="comment">Tên Chức Vụ:</label>
                    <asp:TextBox class="form-control" ID="txt_Ten" runat="server"></asp:TextBox>
                    <asp:Label ID="lb_Ten" runat="server"  ForeColor="Red" Visible="false" class="control"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <label for="comment">Lương Tháng:</label>
                    <asp:TextBox class="form-control" ID="Txt_luong" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
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
