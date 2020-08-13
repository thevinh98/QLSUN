﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="LichDayGiaoVienView.aspx.cs" Inherits="GUI.LichDayGiaoVienView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>--%>

            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i></i></h2>
                </div>
                <div class="box-content1" style="margin: 5px 5px">


                    <div class="row">
                        <div class="col-sm-4">
                            <label for="comment">Giáo Viên:</label>
                            <asp:DropDownList Size="1" ID="dropdow_GiaoVien" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropdow_GiaoVien_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-4">
                            <label for="comment">Từ Ngày:</label>
                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_ngaybatdau" runat="server"></asp:TextBox>
                            <asp:Label ID="lb_ngaybatdau" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <label for="comment">Đến Ngày:</label>
                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_ngayKetThuc" runat="server"></asp:TextBox>

                            <asp:Label ID="lb_ngayKetThuc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <br />

                            <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-warning " OnClick="thongKe_Click"><i class="glyphicon glyphicon-search icon-white"> Thống Kê</i></asp:LinkButton>
                        </div>

                    </div>


                    <hr />

                </div>

            </div>
            <div class="box-inner" id="div_lichday" runat="server">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Lịch Dạy</h2>
                </div>
                <div class="box-content">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-md-6">


                          
                            <hr />
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
                            <asp:TemplateField HeaderText="Lớp Học">
                                <ItemTemplate>
                                    <asp:Label ID="lblName13" runat="server" Text='<%# Eval("TenLop") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Buổi Học">
                                <ItemTemplate>
                                    <asp:Label ID="lblName213" runat="server" Text='<%# Eval("BuoiHoc") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thời Gian Bắt Đầu">
                                <ItemTemplate>
                                    <asp:Label ID="lblName2" runat="server" Text='<%# DateTime.Parse(Eval("ThoiGianBatDau").ToString()).ToString("dd-MM-yyyy" +"</br>" +"hh:mm tt") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thời Gian Kết Thúc">
                                <ItemTemplate>
                                    <asp:Label ID="lblName23" runat="server" Text='<%# DateTime.Parse(Eval("ThoiGianKetThuc").ToString()).ToString("dd-MM-yyyy" +"</br>"+"hh:mm tt") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Phòng Học">
                                <ItemTemplate>
                                    <asp:Label ID="lblName223" runat="server" Text='<%# Eval("SoPhong") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Số Giờ Dạy">
                                <ItemTemplate>
                                    <asp:Label ID="lblName233" runat="server" Text='<%# Eval("SoGio") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giáo Viên">
                                <ItemTemplate>
                                    <asp:Label ID="lblName243" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
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


        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>