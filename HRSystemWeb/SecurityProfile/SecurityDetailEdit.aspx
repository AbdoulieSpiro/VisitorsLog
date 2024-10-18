<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SecurityDetailEdit.aspx.cs" Inherits="HRSystemWeb.SecurityProfile.SecurityDetailEdit"
    Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="4" runat="server" TailName="Edit Control State  " />
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%" class="pageTitleBar">
        <tr>
            <td>
                <asp:Label ID="lblSearchHeaderText" Text="Edit Control State" runat="server" SkinID="LabelPageTitle"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="lnkUpdate" runat="server" CssClass="linkButton1" Text="Save" OnClick="lnkUpdate_Click" />
                <asp:Button ID="lnkCancel" runat="server" Text="Cancel" CssClass="linkButton1" OnClick="lnkCancel_Click" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="containerHdBg">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:DataGrid ID="grdSecurityDetail" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundColumn HeaderText="Control" DataField="ControlMappingX"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Control State">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="optControlState" runat="server" CssClass="checkBoxList"
                                    Width="238px" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "ControlState") %>'
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="N">Normal</asp:ListItem>
                                    <asp:ListItem Value="D">Disabled</asp:ListItem>
                                    <asp:ListItem Value="H">Hidden</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblSecurityProfile" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SecurityProfile") %>'>Label</asp:Label>
                                <asp:Label ID="lblControlMapping" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ControlMapping") %>'>Label</asp:Label>
                                <asp:Label ID="lblSecurityDetail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SecurityDetail") %>'>Label</asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
