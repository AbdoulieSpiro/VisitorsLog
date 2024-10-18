<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Sale.aspx.cs" Inherits="HRSystemWeb.Sale" Title="System User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="System User List" />
    <table width="99%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" cellspacing="0" cellpadding="0" align="center" class="pageTitleBar">
                    <tr>
                        <td>
                            <asp:Label ID="lblPageName" runat="server" Text="System User List" SkinID="LabelPageTitle"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Button ID="lnkCreate" runat="server" ToolTip="Create New User" CssClass="btn btn-primary btn-sm"
                                OnClick="lnkCreate_Click1" Text="Create"></asp:Button>
                            <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                                OnClick="lnkCancel_Click1" Text="Back"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="containerHdBg">
                &nbsp;<br />
            </td>
        </tr>
    </table>
    <table width="96%" cellspacing="0" cellpadding="0" align="center" border="0">
       
        <tr>
            <td align="center">
                <br />
                <asp:TextBox ID="txtSearch" runat="server">
                </asp:TextBox>
                <asp:ImageButton ID="btnSearch" ImageAlign="middle" ToolTip="Click to Search" SkinID="SearchButton"
                    runat="server" OnClick="btnSearch_Click1" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSchoolAccess" runat="server" Visible="False"> Click "Grant Access" for each person you wish to add to the Company user list.</asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="98%" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lblConfirmation" Visible="false" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="grid-top-border">
                <asp:DataGrid ID="grdPage" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    GridLines="None" CssClass="aspDataGrid" OnItemCommand="grdPage_ItemCommand" OnItemDataBound="grdPage_ItemDataBound"
                    Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                    Font-Underline="False" HorizontalAlign="Left" OnItemCreated="grdPage_ItemCreated"
                    AllowPaging="True" PageSize="18" OnPageIndexChanged="grdPage_PageIndexChanged">
                    <PagerStyle Mode="NumericPages" HorizontalAlign="Left"></PagerStyle>
                    <Columns>
                        <asp:BoundColumn Visible="False" DataField="SystemUser"></asp:BoundColumn>
                        <asp:ButtonColumn Visible="False" Text="Grant Access" CommandName="Select"></asp:ButtonColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:HyperLinkColumn DataNavigateUrlField="JumpParam" DataNavigateUrlFormatString="{0}"
                            DataTextField="FullName" HeaderText="Name">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:HyperLinkColumn>
                        <asp:BoundColumn DataField="LoginEmailAddress" HeaderText="Login Id" ItemStyle-HorizontalAlign="Left">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="EmailAddress" HeaderText="Email Address" ItemStyle-HorizontalAlign="Left">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SystemRoleTypeX" HeaderText="System Role" ItemStyle-HorizontalAlign="Left">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="IsActive">
                            <ItemStyle Width="6%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgUserActivate" CommandName="DeactivateUser" ToolTip="Deactivate User"
                                    CssClass="imgCursor" CommandArgument='<%# Eval("SystemUser") %>' Visible='<%# Convert.ToBoolean(Eval("IsActive")) %>'
                                    runat="server" SkinID="Deactivate" />
                                <asp:ImageButton ID="imgUserDeactivate" CommandName="ActivateUser" ToolTip="Activate User"
                                    CssClass="imgCursor" CommandArgument='<%# Eval("SystemUser") %>' Visible='<%#! Convert.ToBoolean(Eval("IsActive")) %>'
                                    runat="server" SkinID="Activate" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="IsLocked">
                            <ItemStyle Width="6%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgUserLock" CommandName="UnlockUser" CssClass="imgCursor" ToolTip="Unlock User"
                                    CommandArgument='<%# Eval("SystemUser") %>' Visible='<%# Convert.ToBoolean(Eval("IsLocked")) %>'
                                    runat="server" SkinID="imgLock" />
                                <asp:ImageButton ID="imgUserUnlock" CommandName="LockUser" CssClass="imgCursor" ToolTip="Lock User"
                                    CommandArgument='<%# Eval("SystemUser") %>' Visible='<%#! Convert.ToBoolean(Eval("IsLocked")) %>'
                                    runat="server" SkinID="imgUnLock" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Reset">
                            <ItemStyle Width="6%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgResetPassword" CommandArgument='<%# Eval("SystemUser") %>'
                                    CommandName="ResetPassword" CssClass="imgCursor" ToolTip="Reset Password" runat="server"
                                    SkinID="ResetPassword" OnClientClick="return confirmResetPassword()" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Delete">
                            <ItemStyle Width="6%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" CommandArgument='<%# Eval("SystemUser") %>' CommandName="Delete"
                                    CssClass="imgCursor" ToolTip="Delete User" runat="server" SkinID="DeleteGrid"
                                    OnClientClick="return confirmDeletion()"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="IsInternal" Visible="False">
                            <ItemStyle Width="0px" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" CssClass="gridPage" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
    <table width="95%" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <div id="divEmpty" class="emptyData" visible="false" runat="server">
                    <span class="emptyDataText">No Records Found. </span>
                </div>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
    function confirmDeletion()
    {
        if(confirm("Deleteing the user?"))
            return true;
        else
            return false;
    }
    function confirmResetPassword()
    {
        if(confirm("Reseting the Password?"))
           return true;
        else
         return false;
    }
    </script>

</asp:Content>
