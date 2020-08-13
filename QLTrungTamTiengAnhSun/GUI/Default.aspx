<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>


            <div class="ch-container">

                <div class="row">



                    <div class="box col-md-12">
                        <div class="box-inner">
                            <div class="box-header well">
                                <h2><i class="glyphicon glyphicon-list-alt"></i>Bản Tin</h2>

                                <div class="box-icon">
                                    <a href="#" class="btn btn-setting btn-round btn-default"><i
                                        class="glyphicon glyphicon-cog"></i></a>
                                    <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                        class="glyphicon glyphicon-chevron-up"></i></a>
                                    <a href="#" class="btn btn-close btn-round btn-default"><i
                                        class="glyphicon glyphicon-remove"></i></a>
                                </div>
                            </div>
                            <div class="box-content">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div style="background-color: red; margin: 10px 10px; min-height: 160px">
                                            <div style="padding-left: 10%; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">

                                                <asp:Repeater runat="server" ID="rep_count_hp">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("DemHP") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div style="text-align: center; padding: 8%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Danh sách đóng học phí hôm nay</p>
                                            </div>
                                            <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="HocPhi_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>
                                        </div>



                                    </div>
                                    <div class="col-md-4">
                                        <div style="background-color: Blue; margin: 10px 10px; min-height: 160px">
                                            <div style="padding-left: 10%; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">

                                                <asp:Repeater runat="server" ID="Rep_count_TBLop">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("DemTB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div style="text-align: center; padding: 8%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Thông báo lớp hôm nay</p>
                                            </div>

                                            <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="ThongBaoLopHomNay_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="col-md-4">
                                        <div style="background-color: blue; margin: 10px 10px; min-height: 160px">
                                            <div style="padding-left: 10%; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">

                                                <asp:Repeater runat="server" ID="Rep_count_TBGiaoVien">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("DemTB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div style="text-align: center; padding: 8%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Thông báo giáo viên hôm nay</p>
                                            </div>
                                            <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="TbGiaoVien_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <div class="row">
                                </div>

                                <hr />
                                <div class="row">
                                    <div class="col-md-3">
                                        <div style="background-color: blue; margin: 10px 10px; min-height: 100px;padding-top:5px">
                                             <div style="text-align: center; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Tổng số học viên</p>
                                            </div>
                                            <div style="text-align:center; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">
                                                
                                                <asp:Repeater runat="server" ID="Rep_TongHV">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("Tong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                           
                                             <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="TongHV_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>
                                      <div class="col-md-3">
                                        <div style="background-color: blue; margin: 10px 10px; min-height: 100px;padding-top:5px">
                                             <div style="text-align: center; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Tổng số lớp học</p>
                                            </div>
                                            <div style="text-align:center; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">
                                               
                                                <asp:Repeater runat="server" ID="rep_TongLop">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("Tong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                           
                                             <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="TongLop_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>
                                      <div class="col-md-3">
                                        <div style="background-color: blue; margin: 10px 10px; min-height: 100px;padding-top:5px">
                                             <div style="text-align: center; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Tổng số giáo viên</p>
                                            </div>
                                            <div style="text-align:center; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">
                                              
                                                <asp:Repeater runat="server" ID="Rep_TongGV">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("Tong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="TongGV_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>

                                        </div>

                                    </div>
                                      <div class="col-md-3">
                                        <div style="background-color: blue; margin: 10px 10px; min-height: 100px;padding-top:5px">
                                             <div style="text-align: center; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <p>Tổng số nhân viên</p>
                                            </div>
                                            <div style="text-align:center; font-size: 25px; font-family: fantasy; color: white; text-transform: uppercase">
                                                
                                                <asp:Repeater runat="server" ID="Rep_TongNV">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lb_hp" Text='<%# Eval ("Tong") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div style="text-align: center; padding-left: 10%; font-size: 20px; font-family: 'Times New Roman', Times, serif; color: white">
                                                <asp:LinkButton Style="text-align: center; padding-left: 10%; font-size: 18px; font-family: 'Times New Roman', Times, serif; color: white" runat="server" OnClick="TongNV_Click">Chi Tiết <i class="glyphicon glyphicon-plus-sign"></i></asp:LinkButton>
                                            </div>

                                        </div>

                                    </div>
                                   
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--<-- ds học phí-->--%>

            <%--<-- ds thong báo lớp-->--%>
            <%--<-- ds thông báo giáo viên-->--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
