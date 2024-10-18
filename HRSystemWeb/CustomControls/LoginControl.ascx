<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs"
    Inherits="Custom_Controls_LoginControl" %>
<asp:Panel ID="panLogin" runat="server" DefaultButton="btnLogin">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" SkinID="LabelPageTitle">User Login</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table1" border="0" runat="server">
                    <tr>
                        <td class="FieldPrompt">
                            <asp:Label ID="lblUserID" runat="server">User ID:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLoginId" runat="server" Width="166px" MaxLength="100"></asp:TextBox><asp:CustomValidator
                                ID="valSignIn" runat="server" Width="8px" ErrorMessage="<br>Invalid user Name Or Password."
                                Display="Dynamic" CssClass="validator">*</asp:CustomValidator><asp:CustomValidator
                                    ID="valLockOut" runat="server" Width="10px" CssClass="validator" Display="Dynamic"
                                    ErrorMessage="<br>Your account has been locked.<br>Contact your Administrator.">*</asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldPrompt">
                            Password:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" Width="167px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldPrompt">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkForgetPsw" runat="server" OnClick="lnkForgetPsw_Click">Forgot Password</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldPrompt">
                        </td>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" />
