<%@ Page Title="" Language="C#" MasterPageFile="~/StyleGV/layout_giaovien.Master" AutoEventWireup="true" CodeBehind="KetQuaHocTapGV.aspx.cs" Inherits="GUI.StyleGV.KetQuaHocTapGV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="table" runat="server">
    Kết Quả Học Tập
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>

            <div class="box-inner" id="div_HocVien" runat="server">

                <div class="box-content">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-md-6">

                            <a href="HocVienAdd.aspx">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="Btn_Add"><i class="glyphicon glyphicon-plus-sign"></i> Thêm Mới</asp:LinkButton></a>
                            <hr />
                            <div id="DataTables_Table_0_length" class="dataTables_length">
                                <div class="row">
                                    <div class="col-md-7">
                                        <label>
                                            <asp:Label ID="lb_op" Visible="false" Font-Size="12px" Text="10" runat="server"></asp:Label>
                                            <asp:DropDownList size="0" runat="server" ID="cboCountry" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="cboCountry_SelectedIndexChanged" Width="50px">

                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>100</asp:ListItem>
                                            </asp:DropDownList>
                                            Tài liệu từng trang</label>
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
                                <asp:LinkButton ID="btn_Search" runat="server" class="btn-sm btn-warning" OnClick="Search_Click"><i class="glyphicon glyphicon-search icon-white"></i></asp:LinkButton>
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
                            <asp:TemplateField HeaderText="Họ Tên">
                                <ItemTemplate>
                                    <asp:Label ID="lblName13" runat="server" Text='<%# Eval("HoTen") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lớp Học">
                                <ItemTemplate>
                                    <asp:Label ID="lblName213" runat="server" Text='<%# Eval("TenLop") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Đợt Kiểm Tra">
                                <ItemTemplate>
                                    <asp:Label ID="lblName233" runat="server" Text='<%# Eval("Ten") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm">
                                <ItemTemplate>
                                    <asp:Label ID="lblName223" runat="server" Text='<%# Eval("Diem") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thời Gian">
                                <ItemTemplate>
                                    <asp:Label ID="lblName23" runat="server" Text='<%# DateTime.Parse(Eval("ThoiGian").ToString()).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Ghi Chú">
                                <ItemTemplate>
                                    <asp:Label ID="lblName253" runat="server" Text='<%# CuttingString( Eval("GhiChu"), 30) %>' ToolTip='<%#  Eval("GhiChu") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                          <%--  <asp:TemplateField HeaderText="">
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
                            </asp:TemplateField>--%>

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
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title" id="ModalTitle1">Cập Nhật Kết Quả Học Tập</h4>


                                </div>
                                <div class="box-content1" style="margin: 5px 5px">
                                    <div class="alert alert-info">
                                        <asp:Label ID="lb_thongbao_add" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                                    </div>
                                    <asp:Label ID="lb_id" runat="server" Visible="false" ForeColor="Black" class="control"></asp:Label>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <label for="comment">Học Viên:</label>
                                            <asp:DropDownList Size="1" ID="DropDow_NhapHoc" runat="server" class="form-control">
                                            </asp:DropDownList>
                                            <asp:Label ID="lb_NhapHoc" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                            <label for="comment">Đợt Kiểm Tra:</label>
                                            <asp:DropDownList Size="1" ID="Dropdow_Dotkiemtra" runat="server" class="form-control">
                                            </asp:DropDownList>
                                            <asp:Label ID="lb_lop" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>

                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <label for="comment">Thời Gian:</label>

                                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_thoigian" runat="server"></asp:TextBox>
                                            <asp:Label ID="lb_thoigian" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                            <label for="comment">Điểm:</label>

                                            <asp:TextBox class="form-control" ID="txt_diem" runat="server"></asp:TextBox>
                                            <asp:Label ID="lb_diem" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
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
                                    <div class="modal-footer">
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success" OnClick="Update_Click"><i class="glyphicon glyphicon-ok-sign icon-white"></i> Cập Nhật</asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-warning" OnClick="Back_Click"><i class="glyphicon glyphicon glyphicon-remove"></i> Thoát</asp:LinkButton>
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
