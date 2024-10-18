<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pagger.ascx.cs" Inherits="HRSystemWeb.Pagger" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<table width="100%">
    <tr>
        <td style="width: 20%">
            <asp:TextBox Width="98%" ID="txtSearch" runat="server"></asp:TextBox>
        </td>
        <td style="width: 8%">
            <asp:Button ID="btnsearch" runat="server" Text="search" CssClass="linkButton1" OnClick="btnsearch_Click" />
        </td>
        <td style="width: 12%">
            <asp:Button ID="btnAddFilter" CommandName="add"  CssClass="linkButton1" runat="server" Text="Add Filter"
                OnClick="btnAddFilter_Click" />
        </td>
        <td style="width: 20%">
            <asp:Image ID="imgColumns" ImageUrl="~/Images/Columns.bmp" runat="server" ToolTip="Check Columns you want to display in grid" />
            <%--<asp:Label ID="TextLabel" runat="server" BackColor="Red" Text="Columns" Style="display: block;
                width: 100px; padding: 2px; padding-right: 10px; font-family: Tahoma; font-size: 11px;" />--%>
        </td>
        <td style="width: 20%">
            <asp:Image ID="imgRows" ImageUrl="~/Images/Rows.bmp" runat="server" ToolTip="Select # of Rows you want to display in grid" />
            <%--<asp:Label ID="lblRows" runat="server" BackColor="Red" Text="Rows" Style="display: block;
                width: 100px; padding: 2px; padding-right: 10px; font-family: Tahoma; font-size: 11px;" />--%>
        </td>
        <td style="width: 20%">
            <table width="100%">
                <tr>
                    <td>
                        <asp:ImageButton ID="imgPre" Width="50%" Text="Prev" ImageUrl="~/Images/Previous.jpg"
                            runat="server" OnClick="imgPre_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblPages" runat="server" BackColor="AliceBlue" Text="Page {0} of {1}"
                            Style="display: block; width: 100%; height: 18px; padding: 2px; font-family: Tahoma;
                            font-size: 12px;" />
                    </td>
                    <td width="2px">
                        &nbsp;
                    </td>
                    <td>
                        <asp:ImageButton Width="50%" ID="imgnext" Text="Next" ImageUrl="~/Images/Next.jpg"
                            runat="server" OnClick="imgnext_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--<div style="display: none; visibility: hidden">--%>
<asp:Panel ID="Panel1" runat="server" CssClass="ContextMenuPanel" Width="120px" BackColor="AliceBlue"
    Style="display: none">
    # of Rows<br />
    <asp:LinkButton ID="LinkButton1" runat="server" Text="5" OnCommand="LinkButton_Command"> </asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton2" runat="server" Text="25" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton3" runat="server" Text="50" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton4" runat="server" Text="100" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton6" runat="server" Text="200" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton7" runat="server" Text="500" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton8" runat="server" Text="1000" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <%--<asp:LinkButton ID="LinkButton8" runat="server" Text="75" OnCommand="LinkButton_Command"></asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton5" runat="server" Text="100" OnCommand="LinkButton_Command"></asp:LinkButton><br />--%>
</asp:Panel>
<%--</div>--%>
<ajaxToolkit:PopupControlExtender BehaviorID="pop1" ID="PopupControlExtender1" runat="Server"
    OffsetX="0" TargetControlID="imgRows" PopupControlID="Panel1" Position="Bottom" />
<%--<div id="divColumns" style="display: none; visibility: hidden">--%>
<asp:Panel ID="DropPanel" runat="server" CssClass="ContextMenuPanel" Width="250px"
    Style="display: none">
    <asp:Panel ID="pnl" CssClass="reorderListDemo" runat="server" ScrollBars="Vertical"
        Height="200">
        <asp:GridView ID="grdColumns" Width="93%" runat="server" AutoGenerateColumns="false"
            BackColor="AliceBlue">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Select Columns to be Displayed
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" Checked='<%# Eval("DefaultSelect") %>' />
                        <asp:Label ID="lblColumnX" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("ColumnX"))) %>' />
                        <asp:Label ID="lblType" Visible="false" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("DataType"))) %>' />
                        <asp:Label ID="lblColumn" Visible="false" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Column"))) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClientClick="return hide();" />
</asp:Panel>
<%--</div>--%>
<ajaxToolkit:PopupControlExtender BehaviorID="pop" ID="hme1" runat="Server" OffsetX="-140"
    OffsetY="3" TargetControlID="imgColumns" PopupControlID="DropPanel" Position="Bottom" />
<%--<div id="divPage" style="display: none; visibility: hidden">--%>
<asp:Panel ID="Panel2" runat="server" CssClass="ContextMenuPanel" Width="100px" ScrollBars="Auto"
    Height="200" BackColor="AliceBlue" Style="display: none">
    <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton ID="lnkPage" CommandArgument='<%# Eval("Page") %>' CommandName="pageclick"
                runat="server" Text='<%# Eval("PageX") %>'></asp:LinkButton><br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>
<%--</div>--%>
<ajaxToolkit:PopupControlExtender BehaviorID="pop2" ID="PopupControlExtender2" runat="Server"
    OffsetX="10" OffsetY="3" TargetControlID="lblPages" PopupControlID="Panel2" Position="Bottom" />
