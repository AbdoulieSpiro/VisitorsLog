<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UpdatePasword.aspx.cs" Inherits="SystemUser_UpdatePasword" Title="Untitled Page" %>

<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link href="../assets/css/theme.css" rel="stylesheet">
      <link href="../Content/bootstrap.css" rel="stylesheet">

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" Level="2" runat="server" TailName="Update Password " />




    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="Update Password" CssClass="mb-0 h5" SkinID="LabelPageTitle"></asp:Label>



                </div>

                <div class="col-auto align-self-center">
                    <asp:Button ID="btnUpdate" runat="server" Text="Change" CssClass="btn btn-primary btn-sm" OnClick="btnUpdate_Click"
                        ValidationGroup="update" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-sm" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </div>
            </div>
          

        </div>
          <br />

    <div class="card-body pt-0">


        <div class="row g-3">
            <div class="col-md-12">
                <asp:Label ID="Label2" runat="server" Text="Old Password:" CssClass="form-label"></asp:Label>



                <asp:TextBox ID="txtOldPassword" runat="server"  CssClass="form-control" MaxLength="50" Text='<%# ds.Tables[0].Rows[0]["Password"] %>'
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPasswordOld" runat="server" ControlToValidate="txtOldPassword"
                    Display="Dynamic" ErrorMessage="Old Password is required" ValidationGroup="update">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="valOldPassword" runat="server" ControlToValidate="txtOldPassword"></asp:CustomValidator>
            </div>
        </div>

        <div class="row g-3">
            <div class="col-md-12">
                <asp:Label ID="Label3" runat="server" Text="New Password:" CssClass="form-label"></asp:Label>



                <asp:TextBox ID="txtPassword1" runat="server"  CssClass="form-control" MaxLength="50" Text='<%# ds.Tables[0].Rows[0]["Password"] %>'
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPassword1" runat="server" ControlToValidate="txtPassword1"
                    Display="Dynamic" ErrorMessage="New Password is required" ValidationGroup="update">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="valcomPassword" runat="server" ControlToCompare="txtPassword1"
                    ValidationGroup="update" ControlToValidate="txtPassword2" ErrorMessage="The two password fields must match.">*</asp:CompareValidator>


            </div>
        </div>

        <div class="row g-3">
            <div class="col-md-12">
                <asp:Label ID="Label4" runat="server" Text=" Retype New Password:" CssClass="form-label"></asp:Label>



                <asp:TextBox ID="txtPassword2" runat="server"  CssClass="form-control" Text='<%# ds.Tables[0].Rows[0]["Password"] %>'
                    MaxLength="50" TextMode="Password"></asp:TextBox>

            </div>
        </div>

        <div class="row g-3">
            <div class="col-md-12">
                <asp:Label ID="lblError" runat="server" Text="Invalid Old Password" ForeColor="Red" Visible="false" />

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
        </div>
    </div>
    </div>
</asp:Content>
