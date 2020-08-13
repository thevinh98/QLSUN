<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="LopView.aspx.cs" Inherits="GUI.LopView1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>


            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-th-list"></i>Lớp Học</h2>
                </div>
                <div class="box-content">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <a href="#">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="Btn_Add"><i class="glyphicon glyphicon-plus-sign"></i> Thêm Mới</asp:LinkButton></a>
                            <hr />


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
                            <hr />
                        </div>

                        <div class="col-md-3">
                            <div class="col-sm-12">
                                <label for="comment">Khóa Học:</label>

                                <asp:DropDownList Size="1" ID="dropdow_KhoaHoc" AutoPostBack="True" runat="server" class="form-control" OnSelectedIndexChanged="dropdow_KhoaHoc_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="dataTables_filter" id="DataTables_Table_0_filter">
                                <br />

                                <label>
                                    Tìm Kiếm:
                                </label>
                                <asp:TextBox TextMode="Search" ID="txt_search" runat="server"></asp:TextBox>
                                <asp:LinkButton ID="btn_Search" runat="server" class="btn-sm btn-warning" OnClick="Search_Click"><i class="glyphicon glyphicon-search icon-white"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>


                    <asp:Repeater ID="Gr_View" runat="server" OnItemDataBound="rep_Lop_ItemDataBound">
                        <ItemTemplate>

                            <div class=" pan  col-sm-4">
                                <div class="box-header well" data-original-title="">
                                    <div class="col-sm-12"  style="text-align: center">
                                      
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenLop") %>'></asp:Label>
                                    </div>
                                </div>
                                <div class="panel panel-default  ">
                                    <div class="panel-body" style="background-color: rgba(255, 255, 255,1.0)">
                                        <%--   <div class="row">
                                            <div class="col-sm-3">

                                            </div>

                                            <div class="col-sm-6  btn btn-warning " style="text-align: center">

                                                <div class="col-sm-12">
                                                    <label for="comment">Lớp Học:</label>
                                                    <asp:Label ID="lblName1" runat="server" Text='<%# Eval("TenLop") %>'></asp:Label>
                                                </div>

                                            </div>
                                            <div class="col-sm-3">
                                            </div>
                                        </div>--%>
                                        <div class=" panel panel-primary ">
                                            <div class="panel-body" >
                                                <div class="row">

                                                    <div class="col-sm-12">
                                                        <label for="comment">Khóa Học:</label>
                                                        <asp:Label Font-Bold="true" ForeColor="Blue" ID="lblName2" runat="server" Text='<%# Eval("TenKhoaHoc") %>'></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">

                                                        <label for="comment">Ngày Bắt Đầu:</label>
                                                        <asp:Label ID="lblName23"  ForeColor="Blue" Font-Bold="true" runat="server" Text='<%# DateTime.Parse(Eval("ThoiGianBatDau").ToString()).ToString("dd-MM-yyyy") %>'></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <label for="comment">Ngày Kết Thúc:</label>
                                                        <asp:Label ID="lblname212"  ForeColor="Blue" Font-Bold="true" runat="server" Text='<%# DateTime.Parse(Eval("ThoiGianKetThuc").ToString()).ToString("dd-MM-yyyy") %>'></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <label for="comment">Số Buổi Học:</label>
                                                        <asp:Label ID="lblName13" ForeColor="Blue" Font-Bold="true" runat="server" Text='<%# Eval("SoBuoiHoc") %>'></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <label for="comment">Học Viên Hiện Tại:</label>
                                                        <asp:Repeater runat="server" ID="Rep_Count_hv">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblnamee"  ForeColor="Blue" Font-Bold="true" runat="server" Text='<%# Eval ("TongHV") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <asp:Label ID="lbidlop" Visible="true" Font-Size="0px"  ForeColor="Blue" Font-Bold="true" runat="server" Text='<%# Eval ("IdLop") %>'> </asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">

                                                        <label for="comment">Học Viên Tối Đa:</label>
                                                        <asp:Label ID="lblnamee"  ForeColor="Blue" Font-Bold="true" runat="server" Text='<%# Eval ("HocVienToiDa") %>'> </asp:Label>
                                                    </div>

                                                    <div class="col-sm-12">
                                                        <label for="comment">Học Phí:</label>
                                                        <asp:Label ID="lblName21"  ForeColor="Blue"  Font-Bold="true" runat="server" Text='<%# Eval("HocPhiLop") + "  VND" %>'></asp:Label>
                                                  
                                                         </div>
                                                      <div class="col-sm-12">
                                                        <label for="comment">Trạng Thái:</label>
                                                        <asp:Label ID="lblName213" ForeColor="Blue" runat="server" Text='<%# Eval("TrangThai") %>'></asp:Label>
                                                         </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="col-sm-12" style="text-align: center">

                                                <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-sm btn-success" CommandArgument='<%# Eval("IdLop") %>' OnClick="DanhSach_Click"><i class="glyphicon glyphicon-list-alt"></i> Danh Sách</asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-sm btn-success" CommandArgument='<%# Eval("IdLop") %>' OnClick="DiemDanh_Click"><i class="glyphicon glyphicon-list-alt"></i> Điểm Danh</asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-sm btn-success" CommandArgument='<%# Eval("IdLop") %>' OnClick="LichHoc_Click"><i class="glyphicon glyphicon-list-alt"></i> Lịch Học</asp:LinkButton>
                                            </div>

                                            <div class="col-sm-12" style="text-align: center">
                                            </div>
                                        </div>

                                        <div class="row">
                                            <hr />

                                            <div class="col-sm-12" style="text-align: right">
                                                <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-sm btn-info" CommandArgument='<%# Eval("IdLop") %>' OnClick="Edit_Click"><i class="glyphicon glyphicon-edit icon-white"></i> Sửa</asp:LinkButton>
                                                <asp:LinkButton ID="btn_Delete" runat="server" class="btn btn-sm btn-danger" CommandArgument='<%# Eval("IdLop") %>' OnClick="Delete_Click" OnClientClick="return confirm('Bạn Chắc Chắn Muốn Xóa!')"><i class="glyphicon glyphicon-trash icon-white"></i> Xóa</asp:LinkButton>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                                <hr />
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>

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

