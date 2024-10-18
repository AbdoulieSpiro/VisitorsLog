<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemUserEdit.aspx.cs" Inherits="HRSystemWeb.SystemUserEdit" Title="System User" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="../assets/css/theme.css" rel="stylesheet">
    <link href="../Content/bootstrap.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="3" runat="server" TailName="System User Edit" />



    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblSearchHeaderText" Text="System User Edit" SkinID="LabelPageTitle"
                        runat="server"></asp:Label>

                </div>
                <div class="col-auto align-self-center">
                    <asp:Button ID="lnkUpdate" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkUpdate_Click1"
                        Text="Save"></asp:Button>
                    <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                        Text="Back" OnClick="LinkCancel_Click"></asp:Button>
                </div>
            </div>
        </div>


        <br />
        <div class="card-body pt-0">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Label ID="lblConfirmation" Visible="false" runat="server" />
                </div>
            </div>



            <%--<td class="darkgreybgcolor">Personal details
                                    </td>--%>



            <div class="row g-3">
                <div class="col-md-6">

                    <asp:Label ID="lblFirstName" runat="Server" CssClass="form-label" Text="First Name"></asp:Label>


                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["FirstName"] %>'
                        MaxLength="50">
                    </asp:TextBox>
                    <span class="rqField">*</span>
                    <asp:RequiredFieldValidator ID="valLastName" runat="server" ControlToValidate="txtFirstName"
                        Display="dynamic" ErrorMessage="Field required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Not Valide Name [A-Z],[a-z]"
                        ControlToValidate="txtFirstName" ValidationExpression="^[a-zA-Z\s.]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-6">


                    <asp:Label ID="lblLastName" runat="Server" CssClass="form-label" Text="Last Name"></asp:Label>



                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["LastName"] %>'
                        MaxLength="50">
                    </asp:TextBox>
                    <span class="rqField">*</span>
                    <asp:RequiredFieldValidator ID="valFirstName" runat="server" Display="Dynamic" ControlToValidate="txtLastName"
                        ErrorMessage="Field required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REVLName" runat="server" ErrorMessage="Not Valide Name [A-Z],[a-z]"
                        ControlToValidate="txtLastName" ValidationExpression="^[a-zA-Z\s.]*$"></asp:RegularExpressionValidator>

                </div>
            </div>
            <div class="row g-3">
                <div class="col-md-6">


                    <asp:Label ID="lblEmailID" runat="Server" CssClass="form-label" Text="Email Address"></asp:Label>


                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["EmailAddress"] %>'
                        MaxLength="50">
                    </asp:TextBox>
                    <span class="rqField">*</span>
                    <asp:RequiredFieldValidator ID="valEmailAddressRequired" runat="server" Display="Dynamic"
                        ControlToValidate="txtEmailAddress" ErrorMessage="Field required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valEmailAddress" runat="server" Display="Dynamic"
                        ControlToValidate="txtEmailAddress" ErrorMessage="Not a valid email address"
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </div>

                <div class="col-md-6">
                    <asp:Label ID="Label9" runat="server" CssClass="form-label" Text="Branch: "></asp:Label>

                    <asp:DropDownList ID="drpBranch" CssClass="form-select form-select-sm" runat="server" SkinID="aspPopupDropDown">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="redtext"
                        ValidationGroup="grpRequest" ControlToValidate="drpBranch" ErrorMessage="Enter Branch"
                        Display="Dynamic">*
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <hr />
            <div class="row g-3">
                <div class="col-md-6">





                    <asp:Label ID="lblLoginID" CssClass="form-label" runat="server" Text="Login ID"></asp:Label>


                    <asp:TextBox ID="txtLoginEmailAddress" CssClass="form-control" runat="server" Text='<%# ds.Tables[0].Rows[0]["LoginName"] %>'
                        Columns="35" MaxLength="50">
                    </asp:TextBox>
                    <span class="rqField">*</span>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Not Valide Login [A-Z],[a-z]"
                        ControlToValidate="txtLoginEmailAddress" ValidationExpression="^[0-9a-zA-Z''_''@''.'\s.]*$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="valLoginEmailAddressRequired" runat="server" CssClass="Validator"
                        Display="Dynamic" ControlToValidate="txtLoginEmailAddress" ErrorMessage="Field required"></asp:RequiredFieldValidator>
                    <asp:Label ID="valDuplicatePassword" runat="server" Visible="False">
                                    <span class="rqField">This Login Id is already in use by another user.</span>
                    </asp:Label>


                </div>
                <div class="col-md-6">

                    <asp:Label ID="lblPassword" CssClass="form-label" runat="server" Text="Password"></asp:Label>


                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Text='<%#ds.Tables[0].Rows[0]["Password"] %>'
                        TextMode="Password"></asp:TextBox>



                </div>
            </div>
            <div class="row g-3">
                <div class="col-md-6">

                    <asp:Label ID="lblSystemRoleType" CssClass="form-label" runat="server" Text="System Role Type"></asp:Label>


                    <asp:DropDownList ID="drpSystemRoleType"  CssClass="form-select form-select-sm"  runat="server" >
                    </asp:DropDownList>
                    <span class="rqField">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpSystemRoleType"
                        Display="Dynamic" ErrorMessage="Field Required" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator>


                </div>
                <div class="col-md-6">

                    <asp:Label ID="lblFailedLoginCount" CssClass="form-label" runat="server" Text="Failed Login Count"></asp:Label>


                    <asp:TextBox ID="txtFailedLoginCount" runat="server" CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["FailedLoginCount"] %>'
                        MaxLength="1" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="valFailedLoginCount" runat="server" CssClass="Validator"
                        Display="Dynamic" ControlToValidate="txtFailedLoginCount" ErrorMessage="Invalid number"
                        MaximumValue="1000" MinimumValue="0" Type="Integer"></asp:RangeValidator>



                </div>
            </div>
            <div class="row g-3">
                <div class="col-md-6">

                    <asp:Label ID="lblActive" CssClass="form-label" runat="server" Text="Active"></asp:Label>


                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# ds.Tables[0].Rows[0]["IsActive"] %>'></asp:CheckBox>


                </div>

                <div class="col-md-6">
                    <asp:Label ID="lblLastLogin" CssClass="form-label" Text="Last Login" runat="server" />


                    <asp:Label ID="lblLastLoginResult" CssClass="form-label" runat="server" Text='<%# ds.Tables[0].Rows[0]["LastLogin"] %>'>
                    </asp:Label>


                </div>
            </div>
            <%--    <div class="row g-3">
<div class="col-md-6">
             


                        <asp:Button ID="LinkButton2" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkUpdate_Click1"
                            Text="Save"></asp:Button>
                        <asp:Button ID="LinkButton3" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                            OnClick="LinkCancel_Click" Text="Back"></asp:Button>
               
    </div>

                             </div>--%>
        </div>
    </div>
</asp:Content>
