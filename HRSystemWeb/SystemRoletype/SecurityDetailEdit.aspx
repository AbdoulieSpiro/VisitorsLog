<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityDetailEdit.aspx.cs" Inherits="SecurityDetail_SecurityDetailEdit"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="SectionTitleLeft">
            </td>
            <td class="SectionTitleLeftMid" style="width: 20%">
                <%--<asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle" Text="Security Detail Edit"></asp:Label>--%>
            </td>
            <td class="SectionTitleRightMid">
            </td>
            <td class="SectionTitleRight">
                <table width="100%">
                    <tbody>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upupContent" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <table class="pageTitleBar" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPageName" runat="server" SkinID="LabelPageTitle"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <asp:Panel ID="panDeyAcces" runat="server" Width="100%">
                                <table>
                                    <tr>
                                        <td class="fieldPrompt">
                                            <asp:Label ID="Label3" runat="server">Page:</asp:Label>
                                        </td>
                                        <td class="fieldpromptvalue">
                                            <asp:Label ID="lblPageMappingX" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fieldPrompt">
                                            <asp:Label ID="Label4" runat="server">System Role Type:</asp:Label>
                                        </td>
                                        <td class="fieldpromptvalue">
                                            <asp:Label ID="lblSystemRoletypeX" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="fieldPrompt">
                                            <asp:Label ID="Label1" runat="server">Deny Acces To Whole Page:</asp:Label>
                                        </td>
                                        <td class="fieldpromptvalue">
                                            <asp:CheckBox ID="chkDeyAccess" runat="server" AutoPostBack="true" OnCheckedChanged="chkDeyAccess_CheckedChanged" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="panPerformControlCheck" runat="server">
                                <table>
                                    <tr>
                                        <td class="fieldPrompt">
                                            <asp:Label ID="Label2" runat="server">Perform Control Check:</asp:Label>
                                        </td>
                                        <td class="fieldpromptvalue">
                                            <asp:CheckBox ID="chkPerformControlCheck" runat="server" AutoPostBack="true" OnCheckedChanged="chkPerformControlCheck_CheckedChanged" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <table class="pageTitleBar" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" SkinID="LabelPageTitle"> Control State</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panSecurityDetail" runat="server" Width="100%">
                                        <asp:DataGrid ID="grdSecurityDetail" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            Width="100%" AllowPaging="true" OnPageIndexChanged="grdSecurityDetail_PageIndexChanged">
                                            <Columns>
                                                <asp:BoundColumn HeaderText="Control" DataField="ControlMappingX"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Control State">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="optControlState" runat="server" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "ControlState") %>'
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="N">Normal</asp:ListItem>
                                                            <asp:ListItem Value="D">Disabled</asp:ListItem>
                                                            <asp:ListItem Value="H">Hidden</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSystemRoleType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SystemRoleType") %>'>Label</asp:Label>
                                                        <asp:Label ID="lblControlMapping" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ControlMapping") %>'>Label</asp:Label>
                                                        <asp:Label ID="lblSecurityDetail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SecurityDetail") %>'>Label</asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
