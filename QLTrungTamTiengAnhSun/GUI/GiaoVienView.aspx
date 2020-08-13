<%@ Page Title="" Language="C#"  EnableEventValidation="false" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="GiaoVienView.aspx.cs" Inherits="GUI.GiaoVienView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>--%>

            <div class="box-inner" id="div_HocVien" runat="server">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Giáo Viên</h2>
                </div>
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
                                <asp:LinkButton ID="btn_Search" runat="server" class="btn-sm btn-warning" OnClick="Search_Click"><i class="glyphicon glyphicon-search icon-white"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <asp:Panel runat="server" ID="DivTable">
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
                            <asp:TemplateField HeaderText="Năm Sinh">
                                <ItemTemplate>
                                    <asp:Label ID="lblName23" runat="server" Text='<%# DateTime.Parse(Eval("NamSinh").ToString()).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giới Tính">
                                <ItemTemplate>
                                    <asp:Label ID="lblName1" runat="server" Text='<%# Eval("GioiTinh") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SDT">
                                <ItemTemplate>
                                    <asp:Label ID="lblName213" runat="server" Text='<%# Eval("SDT") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trình Độ">
                                <ItemTemplate>
                                    <asp:Label ID="lblName223" runat="server" Text='<%# Eval("TrinhDo") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblName233" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Địa Chỉ">
                                <ItemTemplate>
                                    <asp:Label ID="lblName243" runat="server" Text='<%# Eval("DiaChi") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày Vào Làm">
                                <ItemTemplate>
                                    <asp:Label ID="lblName253" runat="server" Text='<%# DateTime.Parse(Eval("NgayVaoLam").ToString()).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trạng Thái">
                                <ItemTemplate>
                                    <asp:Label ID="lblName234" runat="server" Text='<%# Eval("TrangThai") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_Edit" runat="server" class="btn btn-info" CommandArgument='<%# Eval("IdGiaoVien") %>' OnClick="Edit_Click"><i class="glyphicon glyphicon-edit icon-white"></i> Sửa</asp:LinkButton>

                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>

                                    <asp:LinkButton ID="btn_Delete" runat="server" class="btn btn-danger" CommandArgument='<%# Eval("IdGiaoVien") %>' OnClick="Delete_Click" OnClientClick="return confirm('Bạn Chắc Chắn Muốn Xóa!')"><i class="glyphicon glyphicon-trash icon-white"></i> Xóa</asp:LinkButton>
                                </ItemTemplate>

                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                        </asp:Panel>
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
                                <div class="box-header well" data-original-title="">
                                    <h2><i class="glyphicon glyphicon-user"></i>

                                        Cập Nhật Giáo Viên
                                            
                                    </h2>
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                </div>
                                <div class="box-content1" style="margin: 5px 5px">
                                    <div class="alert alert-info">
                                        <asp:Label ID="lb_thongbao_add" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                                    </div>
                                    <asp:Label ID="lb_id" runat="server" Visible="false" ForeColor="Black" class="control"></asp:Label>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <label for="comment">Tên Giáo Viên:</label>
                                            <asp:TextBox class="form-control" ID="txt_Ten" runat="server"></asp:TextBox>
                                            <asp:Label ID="lb_Ten" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <label for="comment">Năm Sinh:</label>
                                            <asp:TextBox TextMode="Date" class="form-control" ID="Txt_NamSinh" runat="server"></asp:TextBox>
                                            <asp:Label ID="lb_Namsinh" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <label for="comment">Số Điện Thoại:</label>
                                            <asp:TextBox TextMode="Number" class="form-control" ID="txt_SDT" runat="server"></asp:TextBox>
                                            <asp:Label ID="lb_SDT" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <label for="comment">Email:</label>
                                            <asp:TextBox TextMode="Email" class="form-control" ID="txt_Email" runat="server"></asp:TextBox>
                                            <asp:Label ID="Lb_Email" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <label for="comment">Địa Chỉ:</label>
                                            <asp:TextBox class="form-control" ID="txt_DiaChi" runat="server"></asp:TextBox>

                                            <asp:Label ID="lb_diachi" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <label for="comment">Trình Độ:</label>
                                            <asp:DropDownList Size="1" ID="DropDow_Trinhdo" runat="server" class="form-control">
                                                <asp:ListItem>Trung Cấp</asp:ListItem>
                                                <asp:ListItem>Cao Đẳng</asp:ListItem>
                                                <asp:ListItem>Đại Học</asp:ListItem>
                                                <asp:ListItem>Tiến Sỹ</asp:ListItem>
                                                <asp:ListItem>Thạc Sỹ</asp:ListItem>
                                                <asp:ListItem>Giáo Sư</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <label for="comment">Ngày Vào Làm:</label>
                                            <asp:TextBox TextMode="Date" class="form-control" ID="txt_ngayvaolam" runat="server"></asp:TextBox>
                                            <asp:Label ID="lb_ngayvaolam" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <label for="comment">Trạng Thái:</label>

                                            <asp:DropDownList Size="1" ID="DropDown_TrangThai" runat="server" class="form-control">
                                                <asp:ListItem>Đang Làm</asp:ListItem>
                                                <asp:ListItem>Đã Nghỉ</asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:Label ID="lb_trangthai" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <label for="comment">Giới Tính:</label>

                                            <asp:DropDownList Size="1" ID="dropdow_gioitinh" runat="server" class="form-control">
                                                <asp:ListItem>Nam</asp:ListItem>
                                                <asp:ListItem>Nữ</asp:ListItem>
                                                <asp:ListItem>Khác</asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false" class="control"></asp:Label>
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
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
