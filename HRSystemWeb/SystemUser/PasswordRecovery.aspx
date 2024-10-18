<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PasswordRecovery.aspx.cs" Inherits="SystemUser_PasswordRecovery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" SkinID="LabelPageTitle" Width="250px"></asp:Label>

                </div>
                <div class="col-auto align-self-center">

                    <asp:Button ID="btnCancel" CssClass="linkButton1" runat="server" Text="Back" CausesValidation="false"
                        OnClick="btnCancel_Click" />&nbsp;
           
                </div>
            </div>

        </div>
        <div class="card-body pt-0">

            <asp:UpdatePanel ID="upContent" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td class="fieldPrompt">Enter User Id:
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtUserId" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valtxtUserId" runat="server" ControlToValidate="txtUserId"
                                                Display="Dynamic" ErrorMessage=" User Id is required">*</asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="valUserIdChack" runat="server" ControlToValidate="txtUserId"
                                                ErrorMessage="Invalid User Id.">*</asp:CustomValidator>
                                            &nbsp;&nbsp;
                                    <asp:Button ID="btnUpdate" CssClass="linkButton1" runat="server" Text="Get Password"
                                        OnClick="btnUpdate_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                <asp:Label ID="lblMessage" runat="server" Visible="false"> Your Password has been sent to your email address.</asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
