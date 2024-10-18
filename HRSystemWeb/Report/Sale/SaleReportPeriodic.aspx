<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SaleReportPeriodic.aspx.cs" Inherits="HRSystemWeb.SaleReportPeriodic"
    Title="Untitled Page" %>


<%--<%@ Register Src="../../CustomControls/StockList.ascx" TagName="AdministrationHome"
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
    <UC1:BreadCrumb ID="BreadCrumb1" Level="4" runat="server" TailName="Periodic Sale Transaction Report" />



    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="Request List" CssClass="mb-0 h5" SkinID="LabelPageTitle"></asp:Label>

                </div>
                <div class="col-auto align-self-center">
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                        OnClick="btnBack_Click" Text="Back"></asp:Button>
                    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-warning btn-sm" CausesValidation="False"
                        OnClick="btnExport_Click" Text="Export"></asp:Button>
                </div>

            </div>
        </div>
        <br />
        <div class="card-body pt-0">


            <div class="row g-3">
                <div class="col-md-3">
                    <asp:Label ID="lblStartDate" CssClass="form-label" runat="server" Text="Start date"></asp:Label>

                    <asp:TextBox ID="txtStartDate" CssClass="form-control" runat="server" SkinID="textProjectList1" Style="width: 150px; display: inline-block;">
                    </asp:TextBox>
                    <asp:ImageButton ID="calSDate" runat="server" SkinID="calen" ImageUrl="~/images/calendar.gif"
                        ValidationGroup="grpMeeting"></asp:ImageButton>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblEndDate" CssClass="form-label" runat="server" Text="End Date"></asp:Label>

                    <asp:TextBox ID="txtEndDate" CssClass="form-control" runat="server" SkinID="textProjectList1" Style="width: 150px; display: inline-block;">
                    </asp:TextBox>
                    <asp:ImageButton ID="calEDate" runat="server" SkinID="calen" ImageUrl="~/images/calendar.gif"
                        ValidationGroup="grpMeeting"></asp:ImageButton>
                </div>


                <div class="col-md-3">
                    <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Depot"></asp:Label>
                    <asp:DropDownList ID="drpBranch" CssClass="form-select " runat="server" SkinID="aspPopupDropDown" AutoPostBack="true" OnSelectedIndexChanged="drpBranch_SelectedIndexChanged" Style="width: 150px; display: inline-block;">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Item"></asp:Label>
                            <asp:DropDownList ID="drpItem" CssClass="form-select " runat="server" AutoPostBack="true" SkinID="aspPopupDropDown" Style="width: 150px; display: inline-block;">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="drpBranch" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnSearch_Click"
                        Text="Search"></asp:Button>
                </div>
            </div>

            <div style="z-index: 9999;">
                <asp:CalendarExtender ID="calDate" runat="server" Format="dd/MM/yyyy" CssClass="calendarExtenderPopup" TargetControlID="txtStartDate"
                    PopupButtonID="calSDate" EnabledOnClient="true">
                </asp:CalendarExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" CssClass="calendarExtenderPopup" TargetControlID="txtEndDate"
                    PopupButtonID="calEDate" EnabledOnClient="true">
                </asp:CalendarExtender>
            </div>
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


                                    <%--<asp:GridView ID="GridView1" runat="server" PageSize="20" AllowPaging="True" CssClass="table table-hover table-bordered table-striped overflow-hidden"
                                        AutoGenerateColumns="false" Width="100%" DataKeyNames="Item Code"
                                        OnRowCommand="grdRequest_RowCommand" OnPageIndexChanging="grdRequest_PageIndexChanging"
                                        OnRowDataBound="grdRequest_RowDataBound" OnRowCreated="grdRequest_RowCreated"
                                        ShowFooter="True">--%>

                                    <asp:GridView ID="grdRequests" runat="server" PageSize="20" AllowPaging="True" CssClass="table table-hover table-bordered table-striped overflow-hidden"
                                        AutoGenerateColumns="false" Width="100%" DataKeyNames="Item Code" ShowFooter="True" OnPageIndexChanging="grdRequest_PageIndexChanging">
                                        <%--OnRowCommand="grdRequest_RowCommand" OnPageIndexChanging="grdRequest_PageIndexChanging" ShowFooter="True">--%>

                                        <Columns>
                                         
                                            <%--<asp:BoundField DataField="Se" HeaderText="Date" />--%>
                                            <asp:BoundField DataField="Date" HeaderText="Date" />
                                            <asp:BoundField DataField="SeqNo" HeaderText="SeqNo" />
                                            <asp:BoundField DataField="Item Code" HeaderText="Item Code" />
                                            <asp:BoundField DataField="Item Name" HeaderText="Item Name" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                            <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="Selling Price" HeaderText="Selling Price" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField DataField="IsReversed" HeaderText="Reversed" />
                                            <asp:BoundField DataField="IsReversalTxn" HeaderText="Reversal Txn" />
                                        </Columns>

                                    </asp:GridView>
                                </div>



                                <div class="row g-3">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label3" CssClass="form-label" runat="server" Text=" Sale Amount: "></asp:Label>
                                        <asp:Label ID="ltxIssue" CssClass="form-label" Style="font-weight: bold;" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Sale Reversal Amount:"></asp:Label>
                                        <asp:Label ID="ltxIssueRev" CssClass="form-label" Style="font-weight: bold;" runat="server" Text=""></asp:Label>

                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Net:"></asp:Label>
                                        <asp:Label ID="ltxNet" CssClass="form-label" Style="font-weight: bold;" runat="server" Text=""></asp:Label>


                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>





                    </div>


                </div>


            </div>



        </div>
    </div>
</asp:Content>
