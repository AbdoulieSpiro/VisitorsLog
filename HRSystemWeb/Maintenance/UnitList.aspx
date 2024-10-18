<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UnitList.aspx.cs" Inherits="HRSystemWeb.UnitList"
    Title="Untitled Page" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="4" runat="server" TailName="Unit List " />



    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="Unit List" CssClass="mb-0 h5" SkinID="LabelPageTitle"></asp:Label>

                </div>


                <div class="col-auto">
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-success btn-sm" CausesValidation="False"
                        OnClick="btnCreate_Click" Text="Create"></asp:Button>
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-warning btn-sm" CausesValidation="False"
                        OnClick="btnBack_Click" Text="Back"></asp:Button>

                </div>

            </div>
        </div>
        <br />
        <div class="card-body pt-0">



            <div class="row g-3">
                <div class="col-md-12">
                    <div class="content" style="background: white; min-height: 100px; width: 100%">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="table-responsive scrollbar">
                                    <%-- <asp:GridView ID="grdPosting" runat="server" AutoGenerateColumns="true" Width="100%"
                                        PageSize="15" AllowPaging="true" AllowSorting="True" CssClass="table table-hover table-bordered table-striped overflow-hidden"
                                        OnRowDataBound="grdPosting_RowDataBound" OnDataBound="grdPosting_DataBound">
                                    </asp:GridView>--%>


                                    <asp:GridView ID="grdRequest" runat="server" PageSize="20" AllowPaging="True" CssClass="table table-hover table-bordered table-striped overflow-hidden"
                                        AutoGenerateColumns="false" Width="100%" DataKeyNames="Unit"
                                        OnRowCommand="grdRequest_RowCommand" OnPageIndexChanging="grdRequest_PageIndexChanging">

                                        <Columns>
                                         
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("Unit") %>' CssClass="btn btn-primary btn-sm" />
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="SelectItem" CommandArgument='<%# Eval("Unit") %>' CssClass="btn btn-primary btn-sm" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="JumpParam" Visible="false" Text="View" DataNavigateUrlFormatString="Unit.aspx?{0}"
                                                HeaderText="Unit " DataTextField="Unit">
                                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="UnitX" HeaderText="Code" />
                                            <asp:BoundField DataField="UnitXX" HeaderText="Name" />
                                        </Columns>

                                    </asp:GridView>



                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>


            </div>
        </div>
    </div>
</asp:Content>
