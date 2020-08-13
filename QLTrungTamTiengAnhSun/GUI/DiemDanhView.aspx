﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="DiemDanhView.aspx.cs" Inherits="GUI.DiemDanhView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>

            <div class="box-inner" id="div_HocVien" runat="server">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Điểm Danh</h2>
                </div>
                <div class="box-content">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-md-6">

                           <%-- <a href="HocVienAdd.aspx">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="Btn_Add"><i class="glyphicon glyphicon-plus-sign"></i> Thêm Mới</asp:LinkButton></a>
                         --%>   <hr />
                            <div id="DataTables_Table_0_length" class="dataTables_length">
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
                        </div>
                        <div class="col-md-6">
                            <div class="dataTables_filter" id="DataTables_Table_0_filter">
                                <label>
                                    Tìm Kiếm:
                                </label>
                                <asp:TextBox TextMode="Search" ID="txt_search" runat="server"></asp:TextBox>
                                <asp:LinkButton ID="btn_Search" runat="server" class="btn-sm btn-warning" OnClick="Search_Click"><i class="glyphicon glyphicon-search icon-white"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <asp:GridView AutoGenerateColumns="False" ID="Gr_View"
                        class="table table-striped table-bordered bootstrap-datatable datatable responsive" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ Tên">
                                <ItemTemplate>
                                    <asp:Label ID="lblName13" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Lớp">
                                <ItemTemplate>
                                    <asp:Label ID="lblName213" runat="server" Text='<%# Eval("TenLop") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Buổi Học">
                                <ItemTemplate>
                                    <asp:Label ID="lblName223" runat="server" Text='<%# Eval("BuoiHoc") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Điểm Danh">
                                <ItemTemplate>
                                    <asp:Label ID="lblName233" runat="server" Text='<%# Eval("TrangThai") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Phòng Học">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" runat="server" Text='<%# Eval("SoPhong") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ghi Chú">
                                <ItemTemplate>
                                    <asp:Label ID="lblName253" runat="server" Text='<%#  Eval("GhiChu" )%>' ToolTip='<%#  Eval("GhiChu") %>'>></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_Edit" runat="server" class="btn btn-info" CommandArgument='<%# Eval("Id") %>' OnClick="Edit_Click"><i class="glyphicon glyphicon-edit icon-white"></i> Sửa</asp:LinkButton>

                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>

                                    <asp:LinkButton ID="btn_Delete" runat="server" class="btn btn-danger" CommandArgument='<%# Eval("Id") %>' OnClick="Delete_Click" OnClientClick="return confirm('Bạn Chắc Chắn Muốn Xóa!')"><i class="glyphicon glyphicon-trash icon-white"></i> Xóa</asp:LinkButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>