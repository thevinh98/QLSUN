<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="LuongGiaoVienView.aspx.cs" Inherits="GUI.LuongGiaoVienView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>--%>
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i ></i></h2>
                </div>
                <div class="box-content1" style="margin: 5px 5px">
                   

                    <div class="row">
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <label for="comment">Từ Ngày:</label>
                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_thoigianbatdau" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_thoigianbatdau" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <label for="comment">Đến Ngày:</label>
                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_thoigianketthuc" runat="server"></asp:TextBox>

                            <asp:Label ID="lb_thoigianketthuc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <br />

                            <asp:LinkButton ID="btn_Search" runat="server" class="btn btn-warning " OnClick="thongKe_Click"><i class="glyphicon glyphicon-search icon-white"> Thống Kê</i></asp:LinkButton>
                        </div>

                    </div>


                    <hr />

                </div>

            </div>
            <hr />
            <div class="box-inner" id="div_LuongGV" runat="server">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Bảng Lương</h2>
                </div>
                <div class="box-content">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-md-6">


                            <div id="DataTables_Table_0_length" class="dataTables_length">
                                 <div class="row">
                                    <div class="col-md-7">
                                        <label>
                                            <asp:Label ID="lb_op" Visible="false" Font-Size="12px" Text="10" runat="server"></asp:Label>
                                            <asp:DropDownList size="0" runat="server" ID="cboCountry" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="cboCountry_SelectedIndexChanged" Width="50px">

                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>100</asp:ListItem>
                                            </asp:DropDownList>
                                            Tài liệu từng trang</label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Button runat="server" ID="btn_excel" EnableEventValidation="false" Text="Xuất Excel" OnClick="XuatExcel_Click" />
                                        <asp:Button runat="server" ID="Button1" Text="Xuất Word" OnClick="Word_Click" />
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="dataTables_filter" id="DataTables_Table_0_filter">
                                <label>
                                    Tìm Kiếm:
                                </label>
                                <asp:TextBox TextMode="Search" ID="txt_search" runat="server"></asp:TextBox>
                                 <asp:LinkButton ID="LinkButton1" runat="server" class="btn-sm btn-warning " OnClick="Search_Click"><i class="glyphicon glyphicon-search icon-white"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <asp:GridView AutoGenerateColumns="False" ID="Gr_View"
                        class="table table-striped table-bordered bootstrap-datatable datatable responsive" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                                
                            <asp:TemplateField HeaderText="Giáo Viên">
                                <ItemTemplate>
                                    <asp:Label ID="lblName213" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Trình Độ">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" runat="server" Text='<%# Eval("TrinhDo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tổng Giờ">
                                <ItemTemplate>
                                    <asp:Label ID="lblName233" runat="server" Text='<%# Eval("TongGio") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lương">
                                <ItemTemplate>
                                    <asp:Label ID="lblName243" runat="server" Text='<%# Eval("LuongGV") + " VND" %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>

                                    <asp:LinkButton ID="btn_hoadon" runat="server" class="btn btn-danger" CommandArgument='<%# Eval("IdGiaoVien") %>' OnClick="HoaDon_Click"><i class=""></i>Hóa Đơn</asp:LinkButton>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>
                <div class="box-inner" style="margin-top: 20px;">
                    <table style="width: auto;">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbFirst" runat="server"
                                    OnClick="lbFirst_Click">First</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbPrevious" runat="server"
                                    OnClick="lbPrevious_Click">Previous</asp:LinkButton>
                            </td>
                            <td>
                                <asp:DataList ID="rptPaging" runat="server"
                                    OnItemCommand="rptPaging_ItemCommand"
                                    OnItemDataBound="rptPaging_ItemDataBound"
                                    RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbPaging" runat="server"
                                            CommandArgument='<%# Eval("PageIndex") %>'
                                            CommandName="newPage"
                                            Text='<%# Eval("PageText") %> ' Width="20px">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbNext" runat="server"
                                    OnClick="lbNext_Click">Next</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbLast" runat="server"
                                    OnClick="lbLast_Click">Last</asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>

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

                                                            <label>Họ Tên Giáo Viên:</label>
                                                            <asp:Label Text='<%# Eval("HoTen") %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label>Giới Tính:</label>
                                                            <asp:Label Text='<%# Eval("GioiTinh") %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label>Địa Chỉ:</label>
                                                            <asp:Label Text='<%# Eval("DiaChi") %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label>SDT:</label>
                                                            <asp:Label Text='<%# Eval("SDT") %>' runat="server"></asp:Label>
                                                            <br />
                                                             <label> Số Giờ Dạy:</label>
                                                            <asp:Label Text='<%# Eval("TongGio")+ "giờ" %>' runat="server"></asp:Label>
                                                            <br />
                                                            <label> Lương:</label>
                                                            <asp:Label Text='<%# Eval("LuongGV")+ " VND" %>' runat="server"></asp:Label>

                                                        </div>
                                                    </ItemTemplate>

                                                </asp:Repeater>
                                                <br />
                                             <div class="" style="display: inline-block; max-width: 100%; margin-bottom: 5px; font-weight: bold; font-family: initial; font-weight: unset; font-size: 15px;">
                                                    <label>Lương Tính Từ Ngày:</label>
                                                    <asp:Label runat="server" ID="lb_time1"></asp:Label>
                                                      <asp:Label  runat="server"  Text=" đến ngày"></asp:Label>
                                                      <asp:Label runat="server" ID="lb_time2"></asp:Label>
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
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
