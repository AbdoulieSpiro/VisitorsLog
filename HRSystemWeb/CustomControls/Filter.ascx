<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Filter.ascx.cs" Inherits="HRSystemWeb.Filter"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="width: 100%">
    <tr>
        <td>
            <asp:GridView ID="grvFilter" Width="100%" runat="server" GridLines="Horizontal" AutoGenerateColumns="false"
                OnRowDataBound="grvFilter_RowDataBound" SkinID="p" OnRowDeleting="grvFilter_RowDeleting">
                <Columns>
                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:Label ID="lblColumnName" Visible="false" runat="server" Text='<%#Eval("ColumnName") %>'></asp:Label>
                            <asp:DropDownList ID="ddlColumnName" AutoPostBack="true" runat="server" Width="200px"
                                OnSelectedIndexChanged="ddlColumnName_SelectedIndexChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:Label ID="lblFilterCriteria" Visible="false" runat="server" Text='<%#Eval("FilterCriteria") %>'></asp:Label>
                            <asp:DropDownList ID="ddlTextFilterCriteria" runat="server" Width="200px">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:TextBox ID="tbFirstBoxValue" EnableTheming="false" runat="server" Text='<%#Eval("TextBox1") %>' />
                            <asp:TextBox ID="tbSecondBoxValue" runat="server" Visible="false" Text='<%#Eval("TextBox2") %>' />
                            <asp:CompareValidator ID="compFirstBoxValue" Operator="DataTypeCheck" runat="server"
                                ControlToValidate="tbFirstBoxValue" Display="Dynamic" Text="*"></asp:CompareValidator>
                            <asp:CompareValidator ID="compSecondBoxValue" Operator="DataTypeCheck" runat="server"
                                ControlToValidate="tbSecondBoxValue" Display="Dynamic" Text="*"></asp:CompareValidator>
                            <cc1:CalendarExtender ID="calStartDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="tbFirstBoxValue" />
                            <cc1:CalendarExtender  ID="calEndDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="tbSecondBoxValue" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="Delete" Text="Delete" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:Button ID="Button1" runat="server" CssClass="linkButton1" Text="Add New Filter" OnClick="Button1_Click" />
<asp:Button ID="lblApplyFilter" runat="server" CssClass="linkButton1" Text="Apply Filter" OnClick="lblApplyFilter_Click" />
