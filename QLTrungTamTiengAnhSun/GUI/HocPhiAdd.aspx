<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="HocPhiAdd.aspx.cs" Inherits="GUI.HocPhiAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>

            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Đóng Học Phí</h2>
                </div>
                <div class="box-content1" style="margin: 5px 5px">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-sm-3">
                            <label for="comment">Học Viên:</label>
                            <asp:DropDownList Size="1" ID="DropDow_NhapHoc" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="HocPhi_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="lb_NhapHoc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Học Phí:</label>

                            <label class="form-control">
                                <asp:Repeater ID="Rep_HocPhi" runat="server" OnItemDataBound="Rep_hocphi_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("HocPhiLop") %>' runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Thời Gian Đóng:</label>
                            <asp:TextBox TextMode="Date" class="form-control" ID="Txt_thoigiandong" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_thoigiandong" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Hạn Đóng:</label>
                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_handong" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_handong" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-3">
                            <label for="comment">Học Phí Đã Đóng:</label>
                            <label class="form-control">
                                <asp:Repeater ID="rep_HocPhidaDong" runat="server">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("DaDong") %>' runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </label>

                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Học Phí Còn Lại:</label>
                            <label class="form-control">
                                <asp:Repeater ID="Rep_hocPhiConLai" runat="server">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("HocPhiConLai") %>' runat="server"></asp:Label>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Tiền Đóng:</label>
                            <asp:TextBox class="form-control" ID="txt_tiendong" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_tiendong" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <label for="comment">Giảm Trừ:</label>
                            <asp:TextBox class="form-control" ID="txt_Giamtru" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_Giamtru" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                    </div>
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
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="Back_Click"><i class="glyphicon glyphicon-arrow-left icon-white"></i> Back</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="Update_Click"><i class="glyphicon glyphicon-ok-sign icon-white"></i> Cập Nhật</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-success" OnClick="HoaDon_Click"><i class="glyphicon glyphicon-print"></i>In Hóa Đơn</asp:LinkButton>
                        </div>
                        <div class="col-sm-4">
                        </div>
                    </div>
                </div>

            </div>


            <div class="modal  fade box-inner" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
                aria-hidden="true">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-dialog ">
                            <div class="modal-content">
                                <div class="box-header well" data-original-title="">
                                    <h2><i class="glyphicon glyphicon-user"></i>

                                        Hóa đơn thanh toán
                                            
                                    </h2>
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                </div>
                                <div class="box-content1" style="margin: 5px 5px">
                                    <div class="panel panel-default" id="bill">
                                        <div class="panel-body">

                                            <div class="row" style="padding: 30px 80px 5px">
                                                <div class="col-sm-4">
                                                    <img src="StyleHv/images/logo.png" />
                                                </div>

                                                <div class="col-sm-8" style="font-size: 15px; padding-top: 30px; text-align: right; text-transform: uppercase; font-family: initial;">
                                                    Trung Tâm Tiếng Anh Sun
                                                </div>
                                            </div>

                                            <br />
                                            <div class="" style="font-size: 20px; font-family: initial; text-align: center; text-transform: uppercase;">
                                                <p>Hóa Đơn Thanh Toán</p>


                                            </div>
                                            <div class="" style="font-size: 20px; text-align: center; text-transform: uppercase;">


                                                <p>-----☆ ☆ ☆ ☆ ☆ ----- </p>
                                            </div>

                                            <div class="" style="padding: 30px 80px">
                                                <asp:Repeater ID="rep_hoadon" runat="server">
                                                    <ItemTemplate>
                                                        <div style="display: inline-block; max-width: 100%; margin-bottom: 5px; font-weight: bold; font-family: initial; font-weight: unset; font-size: 15px;">

                                                            <label>Họ Tên Học Viên:</label>
                                                            <asp:Label Text='<%# Eval("HoTen") %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label>Lớp:</label>
                                                            <asp:Label Text='<%# Eval("TenLop") %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label>Địa Chỉ:</label>
                                                            <asp:Label Text='<%# Eval("DiaChi") %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label>SDT:</label>
                                                            <asp:Label Text='<%# Eval("SDT") %>' runat="server"></asp:Label>

                                                        </div>
                                                    </ItemTemplate>

                                                </asp:Repeater>
                                                <br />
                                                <div class="" style="display: inline-block; max-width: 100%; margin-bottom: 5px; font-weight: bold; font-family: initial; font-weight: unset; font-size: 15px;">
                                                    <label>Số Tiền Thanh Toán:</label>
                                                    <asp:Label runat="server" ID="Lb_tienthanhtoan1"></asp:Label>
                                                    <br />

                                                </div>
                                                <div class="row" style="padding: 30px 80px 5px">
                                                    <div class="col-sm-2">
                                                    </div>

                                                    <div class="col-sm-10" style="font-size: 15px; padding-top: 30px; text-align: center; text-transform: uppercase; font-family: initial;">
                                                        <asp:Label runat="server" ID="date"> </asp:Label>
                                                        <br />
                                                        <asp:Label runat="server" ID="Label1"> Nhân Viên </asp:Label>
                                                        <br />
                                                        <asp:Repeater ID="rep_NhanVien" runat="server">
                                                            <ItemTemplate>
                                                                <div style="display: inline-block; max-width: 100%; margin-bottom: 5px; font-weight: bold; font-family: initial; font-weight: unset; font-size: 15px;">


                                                                    <asp:Label Text='<%# Eval("HoTen") %>' runat="server"></asp:Label>


                                                                </div>
                                                            </ItemTemplate>

                                                        </asp:Repeater>
                                                    </div>
                                                </div>

                                            </div>


                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:LinkButton ID="LinkButton3" runat="server"  data-dismiss="modal" aria-hidden="true" class="  btn btn-success"  onclientclick="javascript:CallPrint('bill');"><i class="glyphicon glyphicon-print"></i> In Hóa Đơn</asp:LinkButton>

                                        
                                    </div>

                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
