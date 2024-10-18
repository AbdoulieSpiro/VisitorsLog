

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ItemBalance.aspx.cs" Inherits="HRSystemWeb.ItemBalance"
    Title="Untitled Page" %>


<%--<%@ Register Src="../CustomControls/StockList.ascx" TagName="AdministrationHome"
    TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="../assets/css/theme.css" rel="stylesheet">
    <link href="../Content/bootstrap.css" rel="stylesheet">
    <style>
        .calendarExtenderPopup .ajax__calendar_container {
            z-index: 9999 !important;
            border: 1px solid black;
            background: white;
        }
    </style>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="4" runat="server" TailName="Item Balance By Depot Report" />



    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="Request List" CssClass="mb-0 h5" SkinID="LabelPageTitle"></asp:Label>

                </div>
                <div class="col-auto align-self-center">

                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                        OnClick="btnBack_Click" Text="Back"></asp:Button>
                    
                     <%-- <asp:Button ID="btnExport" runat="server" CssClass="btn btn-warning btn-sm" CausesValidation="False"
     OnClick="btnExport_Click" Text="Export"></asp:Button>--%>
                </div>

            </div>
        </div>
        <br />
        <div class="card-body pt-0">


         

            <br />

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
                                        AutoGenerateColumns="false" Width="100%" DataKeyNames="Item Code"
                                        OnRowCommand="grdRequest_RowCommand" OnPageIndexChanging="grdRequest_PageIndexChanging">

                                        <Columns>
                                         
                                            <asp:BoundField DataField="Item Code" HeaderText="Item Code" />

                                            <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
                                            <asp:BoundField DataField="Unit Price" HeaderText="Cost Price" />
                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="Unit of Measurement" HeaderText="Unit" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        </Columns>

                                    </asp:GridView>



                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>




                        <div class="row g-3">

                            <div class="col-md-4">
                                <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Net:"></asp:Label>
                                <asp:Label ID="ltxNet" CssClass="form-label" Style="font-weight: bold;" runat="server" Text=""></asp:Label>


                            </div>
                        </div>
                    </div>


                </div>


            </div>



        </div>
    </div>
</asp:Content>
