<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Visitors.aspx.cs" Inherits="HRSystemWeb.Visitors"
    Title="Visitors Log" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .selected-image {
            margin: 20px;
        }

            .selected-image img {
                max-width: 300px;
                max-height: 300px;
            }

        .horizontal-grid {
            display: flex;
            flex-wrap: wrap;
        }

            .horizontal-grid .item {
                margin: 10px;
                text-align: center;
            }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" class="form-label" Level="4" runat="server" TailName="Visitors " />

    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="Visitors Log" CssClass="mb-0 h5" SkinID="LabelPageTitle"></asp:Label>
                </div>

                <div class="col-auto">
                    <asp:Button ID="btnList" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                        OnClick="btnList_Click" Text="List"></asp:Button>
                    <asp:Button ID="btnNew" runat="server" CssClass="btn btn-warning btn-sm" CausesValidation="False"
                        OnClick="btnNew_Click" Text="New"></asp:Button>

                </div>
            </div>
        </div>
        <br />
        <div class="card-body pt-0">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label6" CssClass="form-label" runat="server" Text="First name:"> </asp:Label>
                                <asp:TextBox ID="txtFstName" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label7" CssClass="form-label" runat="server" Text="Last Name:"> </asp:Label>
                                <asp:TextBox ID="txtLstName" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>                       

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label16" CssClass="form-label" runat="server" Text="Grnder:"> </asp:Label>

                                <asp:DropDownList ID="txtGender" CssClass="form-control" runat="server" Columns="35" Width="312px">
                                    <asp:ListItem>Select Gender</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label17" CssClass="form-label" runat="server" Text="Photo:"> </asp:Label>
                                <div class="Photo">
                                    <asp:Image ID="imgPhotoView" runat="server" Height="100px" Width="120px" BorderStyle="Solid"
                                        AlternateText="Photo" CssClass="form-control" />
                                </div>
                            </div>
                        </div>                     

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label14" CssClass="form-label" runat="server" Text=" Address:"> </asp:Label>
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label15" CssClass="form-label" runat="server" Text="Address 2:"> </asp:Label>
                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>
                   

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label12" CssClass="form-label" runat="server" TextMode="Date" Text="DOB:"> </asp:Label>
                                <asp:TextBox ID="txtDOB" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label13" CssClass="form-label" runat="server" Text="Email:" TextMode="Email"> </asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label9" CssClass="form-label" runat="server" TextMode="Phone" Text="Telephone:"> </asp:Label>
                                <asp:TextBox ID="txtTel" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label11" CssClass="form-label" runat="server" TextMode="Phone" Text="Mobile:"> </asp:Label>
                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Nationality:"> </asp:Label>
                                <asp:TextBox ID="txtNational" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label8" CssClass="form-label" runat="server" Text="Company:"> </asp:Label>
                                <asp:TextBox ID="txtCompany" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label3" CssClass="form-label" runat="server" Text="Visit Reason:"> </asp:Label>
                                <asp:TextBox ID="txtReason" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Contact Person:"> </asp:Label>
                                <asp:TextBox ID="txtContPerson" runat="server" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>
                       

                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Department: *"> </asp:Label>
                                <asp:DropDownList ID="drpDepartment" CssClass="form-select form-select-sm" runat="server">
                                </asp:DropDownList>
                                <%--                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpDepartment"
                                    Display="Dynamic" ErrorMessage="Field Required" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Unit: *"> </asp:Label>
                                <asp:DropDownList ID="drpUnit" CssClass="form-select form-select-sm" runat="server">
                                </asp:DropDownList>                              
                                <%--                                <asp:RequiredFieldValidator ID="drpUnit" runat="server" ControlToValidate="drpUnit"
                                    Display="Dynamic" ErrorMessage="Field Required" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        </div>

                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>



            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                </div>
                <div class="col-auto ms-auto">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkUpdate_Click"
                        Text="Save"></asp:Button>
                    <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnEdit_Click"
                        Text="Edit"></asp:Button>
                    <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-warning btn-sm" CausesValidation="False"
                        OnClick="lnkCancel_Click" Text="Cancel"></asp:Button>
                    <br />
                    <br />
                </div>
            </div>






            <div class="modal fade" id="error-modals" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document" style="max-width: 500px">
                    <div class="modal-content position-relative">
                        <div class="position-absolute top-0 end-0 mt-2 me-2 z-1">
                            <button class="btn-close btn btn-sm btn-circle d-flex flex-center transition-base" style="float: right;" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body p-0">
                            <div class="rounded-top-3 py-3 ps-4 pe-6 bg-body-tertiary">
                                <asp:Label ID="lblMessageHeader" CssClass="form-label mb-1 h4" ForeColor="Red" runat="server" Text=""> </asp:Label>

                            </div>
                            <div class="p-4 pb-0">
                                <asp:Label ID="lblMessage" CssClass="form-label" ForeColor="Red" runat="server" Text=""> </asp:Label>

                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="modal fade" id="img-modal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document" style="max-width: 500px">
                    <div class="modal-content position-relative">
                        <div class="position-absolute top-0 end-0 mt-2 me-2 z-1">
                            <button class="btn-close btn btn-sm btn-circle d-flex flex-center transition-base" style="float: right;" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body p-0">
                            <div class="rounded-top-3 py-3 ps-4 pe-6 bg-body-tertiary">
                                <asp:Label ID="Label10" CssClass="form-label mb-1 h4" ForeColor="Red" runat="server" Text=""> </asp:Label>

                            </div>
                            <div class="p-4 pb-0">

                                <div id="selectedImageDiv" class="selected-image" runat="server">
                                    <asp:Image ID="SelectedImage" runat="server" Visible="true" Style="display: block;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>

    </div>

    <script type="text/javascript">
        function initModal() {
            const myModal = new bootstrap.Modal(document.getElementById('error-modals'), {});
            myModal.show();
        }
        function initImgModal() {
            const ImgModal = new bootstrap.Modal(document.getElementById('img-modal'), {});
            ImgModal.show();
        }






        function closeModal() {
            const myModals = bootstrap.Modal.getInstance(document.getElementById('error-modal'));
            if (myModals) {
                myModals.hide();
            }
        }

        function closeModals() {
            const myModal = bootstrap.Modal.getInstance(document.getElementById('error-modals'));
            if (myModal) {
                myModal.hide();
            }
        }
        function closeImgModal() {
            const ImgModal = bootstrap.Modal.getInstance(document.getElementById('img-modal'));
            if (ImgModal) {
                ImgModal.hide();
            }
        }

    </script>
</asp:Content>

