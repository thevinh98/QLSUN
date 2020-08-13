<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutADM.Master" AutoEventWireup="true" CodeBehind="ThongKeKhoanChi.aspx.cs" Inherits="GUI.ThongKeKhoanChi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
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

                            <asp:LinkButton ID="btn_Search" runat="server" class="btn btn-warning " OnClick="ThongKe_ThuChi_Click"><i class="glyphicon glyphicon-search icon-white"> Thống Kê</i></asp:LinkButton>
                        </div>

                    </div>


                    <hr />

                </div>

            </div>
            <br />
            <div class="box-inner" id="div_ThongKeThuChi"  visible="false" runat="server">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i>Thống Kê Khoản Chi</h2>
                </div>
                <div class="box-content">
                    <div class="alert alert-info">
                        <asp:Label ID="lb_ThongBao" runat="server" ForeColor="Black" Visible="false" class="control"></asp:Label>
                    </div>

                 

                    <asp:GridView AutoGenerateColumns="False" ID="Gr_View"
                        class="table table-striped table-bordered bootstrap-datatable datatable responsive" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Tổng Tiền">
                                <ItemTemplate>
                                    <asp:Label ID="lblName13" runat="server"  Text='<%# Eval("TongTien") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterStyle Font-Bold="True" />
                            </asp:TemplateField>
                            
                          



                           

                        </Columns>
                    </asp:GridView>

                </div>
              
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
