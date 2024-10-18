<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemUserList.aspx.cs" Inherits="HRSystemWeb.SystemUserList" Title="System User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="../assets/css/theme.css" rel="stylesheet">
    <link href="../Content/bootstrap.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="System User List" />


    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="System User List" SkinID="LabelPageTitle"></asp:Label>

                </div>
                <div class="col-auto align-self-center">

                    <asp:Button ID="lnkCreate" runat="server" ToolTip="Create New User" CssClass="btn btn-primary btn-sm"
                        OnClick="lnkCreate_Click1" Text="Create"></asp:Button>
                    <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                        OnClick="lnkCancel_Click1" Text="Back"></asp:Button>

                </div>
            </div>

        </div>


        <br />
        <div class="card-body pt-0">
            <div class="row g-3">
                <div class="col-md-12">

                    <asp:LinkButton ID="lnkA" runat="server" CommandArgument="A" CommandName="lnkA" OnClick="lnkAll_Command">A</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkB" runat="server" CommandArgument="B" CommandName="lnkB" OnClick="lnkAll_Command">B</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkC" runat="server" CommandArgument="C" CommandName="lnkC" OnClick="lnkAll_Command">C</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkD" runat="server" CommandArgument="D" CommandName="lnkD" OnClick="lnkAll_Command">D</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkE" runat="server" CommandArgument="E" CommandName="lnkE" OnClick="lnkAll_Command">E</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkF" runat="server" CommandArgument="F" CommandName="lnkF" OnClick="lnkAll_Command">F</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkG" runat="server" CommandArgument="G" CommandName="lnkG" OnClick="lnkAll_Command">G</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkH" runat="server" CommandArgument="H" CommandName="lnkH" OnClick="lnkAll_Command">H</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkI" runat="server" CommandArgument="I" CommandName="lnkI" OnClick="lnkAll_Command">I</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkJ" runat="server" CommandArgument="J" CommandName="lnkJ" OnClick="lnkAll_Command">J</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkK" runat="server" CommandArgument="K" CommandName="lnkK" OnClick="lnkAll_Command">K</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkL" runat="server" CommandArgument="L" CommandName="lnkL" OnClick="lnkAll_Command">L</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkM" runat="server" CommandArgument="M" CommandName="lnkM" OnClick="lnkAll_Command">M</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkN" runat="server" CommandArgument="N" CommandName="lnkN" OnClick="lnkAll_Command">N</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkO" runat="server" CommandArgument="O" CommandName="lnkO" OnClick="lnkAll_Command">O</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkP" runat="server" CommandArgument="P" CommandName="lnkP" OnClick="lnkAll_Command">P</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkQ" runat="server" CommandArgument="Q" CommandName="lnkQ" OnClick="lnkAll_Command">Q</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkR" runat="server" CommandArgument="R" CommandName="lnkR" OnClick="lnkAll_Command">R</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkS" runat="server" CommandArgument="S" CommandName="lnkS" OnClick="lnkAll_Command">S</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkT" runat="server" CommandArgument="T" CommandName="lnkT" OnClick="lnkAll_Command">T</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkU" runat="server" CommandArgument="U" CommandName="lnkU" OnClick="lnkAll_Command">U</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkV" runat="server" CommandArgument="V" CommandName="lnkV" OnClick="lnkAll_Command">V</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkW" runat="server" CommandArgument="W" CommandName="lnkW" OnClick="lnkAll_Command">W</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkX" runat="server" CommandArgument="X" CommandName="lnkX" OnClick="lnkAll_Command">X</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkY" runat="server" CommandArgument="Y" CommandName="lnkY" OnClick="lnkAll_Command">Y</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkZ" runat="server" CommandArgument="Z" CommandName="lnkZ" OnClick="lnkAll_Command">Z</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkAll" runat="server" CommandArgument="ALL" CommandName="lnkAll"
                    OnCommand="lnkAll_Command">ALL</asp:LinkButton>


                </div>
            </div>


            <br />

            <div class="row g-3">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtSearch"  CssClass="form-control" style="Display:inline-block" runat="server">
                    </asp:TextBox>
                    <asp:Button ID="btnSearch"  CssClass="btn btn-primary btn-sm" ToolTip="Click to Search" 
                        runat="server" OnClick="btnSearch_Click1" Text="Search" ></asp:Button>
                </div>
                <div class="col-md-3">
                </div>
            </div>
            <div class="row g-3">
                <div class="col-md-12">

                    <asp:Label ID="lblSchoolAccess" runat="server" Visible="False"> Click "Grant Access" for each person you wish to add to the Company user list.</asp:Label>
                </div>
            </div>

            <br />
            <br />

            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Label ID="lblConfirmation" Visible="false" runat="server" />
                </div>
                <div class="row g-3">
                    <div class="col-md-12">

                        <asp:DataGrid ID="grdPage" runat="server" AutoGenerateColumns="False" CellPadding="3" CssClass="table table-hover table-bordered table-striped overflow-hidden"
                            GridLines="None" OnItemCommand="grdPage_ItemCommand" OnItemDataBound="grdPage_ItemDataBound"
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
                                <asp:BoundColumn DataField="LoginName" HeaderText="Login Id" ItemStyle-HorizontalAlign="Left"></asp:BoundColumn>
                                <asp:BoundColumn DataField="EmailAddress" HeaderText="Email Address" ItemStyle-HorizontalAlign="Left"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SystemRoleTypeX" HeaderText="System Role" ItemStyle-HorizontalAlign="Left"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Active">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgUserActivate" CommandName="DeactivateUser" ImageUrl="~/App_Themes/HRGray/images/Deactivate.gif"  ToolTip="Deactivate User"
                                            CssClass="imgCursor" CommandArgument='<%# Eval("SystemUser") %>' Visible='<%# Convert.ToBoolean(Eval("IsActive")) %>'
                                            runat="server" SkinID="Deactivate" />
                                        <asp:ImageButton ID="imgUserDeactivate" CommandName="ActivateUser" ImageUrl="~/App_Themes/HRGray/images/Activate.gif" ToolTip="Activate User"
                                            CssClass="imgCursor" CommandArgument='<%# Eval("SystemUser") %>' Visible='<%#! Convert.ToBoolean(Eval("IsActive")) %>'
                                            runat="server" SkinID="Activate" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Locked">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgUserLock" CommandName="UnlockUser" ImageUrl="~/App_Themes/HRGray/images/Lock.gif" CssClass="imgCursor" ToolTip="Unlock User"
                                            CommandArgument='<%# Eval("SystemUser") %>' Visible='<%# Convert.ToBoolean(Eval("IsLocked")) %>'
                                            runat="server" SkinID="imgLock" />
                                        <asp:ImageButton ID="imgUserUnlock" CommandName="LockUser" ImageUrl="~/App_Themes/HRGray/images/UnLock.gif" CssClass="imgCursor" ToolTip="Lock User"
                                            CommandArgument='<%# Eval("SystemUser") %>' Visible='<%#! Convert.ToBoolean(Eval("IsLocked")) %>'
                                            runat="server" SkinID="imgUnLock" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Reset">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgResetPassword" CommandArgument='<%# Eval("SystemUser") %>'
                                            CommandName="ResetPassword" CssClass="imgCursor" ImageUrl="~/App_Themes/HRGray/images/ResetPassword.jpg" ToolTip="Reset Password" runat="server"
                                            SkinID="ResetPassword" OnClientClick="return confirmResetPassword()" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Delete">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" CommandArgument='<%# Eval("SystemUser") %>' ImageUrl="~/App_Themes/HRGray/images/delete.gif" CommandName="Delete"
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
                    </div>
                </div>


                <div class="row g-3">
                    <div class="col-md-6">
                        <div id="divEmpty" class="emptyData" visible="false" runat="server">
                            <span class="emptyDataText">No Records Found. </span>
                        </div>
                    </div>
                </div>

            </div>
            <script language="javascript" type="text/javascript">
                function confirmDeletion() {
                    if (confirm("Deleteing the user?"))
                        return true;
                    else
                        return false;
                }
                function confirmResetPassword() {
                    if (confirm("Reseting the Password?"))
                        return true;
                    else
                        return false;
                }
            </script>
        </div>
    </div>
</asp:Content>
