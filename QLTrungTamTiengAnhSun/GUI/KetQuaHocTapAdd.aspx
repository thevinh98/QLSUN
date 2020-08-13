<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="KetQuaHocTapAdd.aspx.cs" Inherits="GUI.KetQuaHocTapAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Cập Nhật Kết Quả Học Tập</h2>
                </div>
                <div class="box-content1" style="margin: 5px 5px">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-sm-3">
                            <label for="comment">Học Viên:</label>
                            <asp:DropDownList Size="1" ID="DropDow_NhapHoc" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:Label ID="lb_NhapHoc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Đợt Kiểm Tra:</label>
                            <asp:DropDownList Size="1" ID="Dropdow_Dotkiemtra" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:Label ID="lb_lop" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Thời Gian:</label>

                            <asp:TextBox  TextMode="Date" class="form-control" ID="txt_thoigian" runat="server"></asp:TextBox> 
                            <asp:Label ID="lb_thoigian" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                          <div class="col-sm-3">
                            <label for="comment">Điểm:</label>

                            <asp:TextBox   class="form-control" ID="txt_diem" runat="server"></asp:TextBox> 
                            <asp:Label ID="lb_diem" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                    </div>
                    <hr />                    

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label for="comment">Ghi Chú:</label>
                                <textarea class="form-control" rows="5" id="txt_ghichu" runat="server"></textarea>
                            </div>
                        </div>

                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-4">
                        </div>
                        <div class="col-sm-4">
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="Back_Click"><i class="glyphicon glyphicon-arrow-left icon-white"></i> Back</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-success" OnClick="Update_Click"><i class="glyphicon glyphicon-ok-sign icon-white"></i> Cập Nhật</asp:LinkButton>
                        </div>
                        <div class="col-sm-4">
                        </div>
                    </div>
                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>