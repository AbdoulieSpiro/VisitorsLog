<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Sale.aspx.cs" Inherits="HRSystemWeb.Transaction_Sale"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="BreadCrumb" TagPrefix="UC1" Src="~/CustomControls/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <style>
        .image-preview {
            display: inline-block;
            margin: 10px;
        }
        .image-preview img {
            width: 150px;
            height: 150px;
        }
        .selected-image {
            margin-top: 20px;
        }
        .selected-image img {
            max-width: 500px;
            max-height: 500px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <UC1:BreadCrumb ID="BreadCrumb1" class="form-label" Level="4" runat="server" TailName="Sales " />

    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <asp:Label ID="lblPageName" runat="server" Text="Sales" CssClass="mb-0 h5" SkinID="LabelPageTitle"></asp:Label>
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
                                <asp:Label ID="lblItemCode" CssClass="form-label" Style="display: block;" runat="server" Text="Item Code:"> </asp:Label>

                                <asp:TextBox ID="txtItemCode" CssClass="form-control" Enabled="false" Style="display: inline-block;" runat="server" Width="200px" Columns="35"
                                    MaxLength="50">
                                </asp:TextBox>

                                <asp:Button ID="txtFetch" runat="server" data-bs-toggle="modal" data-bs-target="#error-modal" Style="display: inline-block;" CssClass="btn btn-primary" CausesValidation="False"
                                    type="button" Text=">>" OnClick="txtFetch_Click"></asp:Button>

                            </div>
                            <%--   <asp:RequiredFieldValidator ID="valControlMappingX" runat="server" ErrorMessage="<br/>This field is required"
                                    ControlToValidate="txtControlMappingX" Display="Dynamic"></asp:RequiredFieldValidator>
                            --%>
                            <div class="col-md-6">
                                <br />
                                <asp:Label ID="lblItemName" CssClass="form-label bold" Style="font-weight: bold;" runat="server" Text=""> </asp:Label>

                            </div>

                        </div>
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="lblBranchCode" CssClass="form-label" runat="server" Text="Branch:"> </asp:Label>


                                <asp:TextBox ID="txtBranch" runat="server" Enabled="false" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblTxn" CssClass="form-label" runat="server" Text="Txn:"> </asp:Label>

                                <asp:DropDownList ID="cmbTxn" runat="server" Enabled="false" CssClass="form-select form-select-sm" MaxLength="50">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Bank / Cash GL (DR):"> </asp:Label>



                                <asp:DropDownList ID="cmbDebitGl" runat="server" CssClass="form-select form-select-sm" MaxLength="50">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Income GL (CR)::"> </asp:Label>



                                <asp:TextBox ID="txtIncomeGl" runat="server" Enabled="false" MaxLength="50" CssClass="form-control"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label3" CssClass="form-label" runat="server" Text="Stock GL (CR):"> </asp:Label>



                                <asp:TextBox ID="txtAssetGL" runat="server" Enabled="false" CssClass="form-control" MaxLength="50"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label5" CssClass="form-label" runat="server" Text="Intermode GL (DR):"> </asp:Label>



                                <asp:TextBox ID="txtIntermod" runat="server" Enabled="false" CssClass="form-control" MaxLength="50"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label ID="Label6" CssClass="form-label" runat="server" Text="Quantity:"> </asp:Label>



                                <asp:TextBox ID="txtQuantity" runat="server" MaxLength="50" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtQuantity_TextChanged"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label7" CssClass="form-label" runat="server" Text="Selling Price:"> </asp:Label>



                                <asp:TextBox ID="txtSPrice" runat="server" MaxLength="50" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtSPrice_TextChanged"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row g-3">

                            <div class="col-md-6">
                                <asp:Label ID="Label8" CssClass="form-label" runat="server" Text="Amount:"> </asp:Label>


                                <asp:TextBox ID="txtAmount" runat="server" Enabled="false" CssClass="form-control" MaxLength="50"
                                    Columns="35" Width="312px">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <br />
                                <asp:Label ID="Label1" runat="server" Text=" Item Quantity in Stock:" Style="font-weight: bold;" CssClass="form-label" SkinID="LabelPageTitle"></asp:Label>

                                <asp:Label ID="lblQuantityNo" runat="server" Text="0.0" CssClass="form-label" Style="font-weight: bold;" SkinID="LabelPageTitle"></asp:Label>


                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label9" CssClass="form-label" runat="server" Text="   Description:"> </asp:Label>



                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Style="width: 100% !important; position: relative !important;">
                   
                                </asp:TextBox>
                            </div>
                        </div>


                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

           <div class="row g-3">
                            <div class="col-md-12">
                              
                                     <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
            <asp:Button ID="btnDisplay" runat="server" Text="Display Images" OnClick="btnDisplay_Click" />
            <%--<asp:Button ID="Button1" runat="server" Text="Save Images" OnClick="btnSave_Click" />--%>
        
                            </div>
                        </div>

            <div class="row g-3">
                <div class="col-md-6">
                    <br />
                    <asp:Button ID="btnPost" runat="server" Visible="false" CssClass="btn btn-primary btn-sm" OnClick="btnPost_Click"
                        Text="Post"></asp:Button>
                    <asp:Button ID="btnClear" runat="server" Visible="false" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                        OnClick="lnkCancel_Click" Text="Clear"></asp:Button>
                </div>

                <div class="col-md-12">
                     <div id="imageContainer" runat="server"></div>
                </div>
                </div>

                
                                                            <div class="table-responsive scrollbar">
                 <asp:GridView ID="grdImages" runat="server"  OnRowCommand="grdImages_RowCommand"  AutoGenerateColumns="False" CssClass="table table-hover table-striped overflow-hidden">
            <Columns>
                 <asp:BoundField DataField="FilePath" HeaderText="File Path" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkImage" runat="server" CommandName="SelectImage" CommandArgument='<%# Eval("FilePath") %>'>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FilePath") %>' Width="150px" Height="150px" />
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </div>

            <div id="selectedImageDiv" class="selected-image" runat="server">
            <asp:Image ID="SelectedImage" runat="server" Visible="false" />
        </div>



        </div>


        <div class="row flex-between-end">
            <div class="col-auto align-self-center">
            </div>
            <div class="col-auto ms-auto">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lnkUpdate_Click"
                    Text="Save"></asp:Button>
                <asp:Button ID="lnkCancel" runat="server" CssClass="btn btn-primary btn-sm" CausesValidation="False"
                    OnClick="lnkCancel_Click" Text="Cancel"></asp:Button>
                <br />
                <br />

            </div>

        </div>



        <div class="modal fade" id="error-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-lg mt-6" role="document" style="">
                <div class="modal-content position-relative">


                    <div class="position-absolute top-0 end-0 mt-3 me-3 z-1">

                        <button class="btn-close btn btn-sm btn-circle d-flex flex-center transition-base" style="float: right;" data-bs-dismiss="modal" aria-label="Close"></button>

                    </div>
                    <div class="modal-body p-0">
                        <div class="rounded-top-3 py-3 ps-4 pe-6 bg-body-tertiary">
                            <h4 class="mb-1" id="modalExampleDemoLabel">Stock List</h4>
                        </div>
                        <div class="p-4 pb-0">

                            <div class="row g-3">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="ss" runat="server">
                                        <ContentTemplate>

                                            <asp:Panel ID="pnlHomeList" runat="server">
                                                <main class="main" id="top">
                                                    <div class="container" data-layout="container">
                                                        <div class="content">
                                                            <div class="row g-3">
                                                                <div class="col-md-2">
                                                                </div>
                                                                <div class="col-md-8">
                                                                    <asp:TextBox ID="txtSearch" CssClass="form-control" Style="display: inline-block;" runat="server" Width="200px" Columns="35"
                                                                        MaxLength="50">
                                                                    </asp:TextBox>

                                                                    <asp:Button ID="btnSearch" runat="server" Style="display: inline-block;" CssClass="btn btn-primary" CausesValidation="False"
                                                                        type="button" Text=">>" OnClick="btnSearch_Click"></asp:Button>
                                                                </div>
                                                                <div class="col-md-2">
                                                                </div>

                                                            </div>
                                                            <br />


                                                            <div class="table-responsive scrollbar">
                                                                <asp:GridView ID="grdItemList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    PageSize="10" AllowPaging="true" AllowSorting="True" CssClass="table table-hover table-striped overflow-hidden"
                                                                    OnRowCommand="grdItemList_RowCommand" OnPageIndexChanging="grdItemList_PageIndexChanging">
                                                                    <%--OnRowCommand="grdItemList_RowCommand" OnPageIndexChanging="grdItemList_PageIndexChanging" OnDataBound="grdItemList_DataBound">--%>
                                                                    <Columns>
                                                                        <%--     <asp:TemplateField AccessibleHeaderText="Select">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkViewEmp" runat="server" OnClick="lnkViewEmp_Click" CssClass="btn btn-primary">Select</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>

                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnSelect" runat="server" Text="Select" CommandName="SelectItem" CommandArgument='<%# Eval("itemX") %>' CssClass="btn btn-primary" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:BoundField DataField="itemX" HeaderText="ItemCode" ItemStyle-CssClass="text-nowrap" />
                                                                        <asp:BoundField DataField="itemXX" HeaderText="Item Name" ItemStyle-CssClass="text-nowrap" />


                                                                    </Columns>
                                                                </asp:GridView>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </main>

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
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



    </div>


    <script src="../vendors/bootstrap/bootstrap.min.js"></script>

    <script type="text/javascript">
        function initModal() {
            const myModal = new bootstrap.Modal(document.getElementById('error-modals'), {});
            myModal.show();
        }

        function closeModal() {
            const myModal = bootstrap.Modal.getInstance(document.getElementById('error-modal'));
            if (myModal) {
                myModal.hide();
            }
        }

        function closeModals() {
            const myModal = bootstrap.Modal.getInstance(document.getElementById('error-modals'));
            if (myModal) {
                myModal.hide();
            }
        }

            function previewImages() {
                var preview = document.getElementById('image-preview');
                preview.innerHTML = '';
                var files = document.getElementById('<%= FileUpload1.ClientID %>').files;
                if (files) {
                    [].forEach.call(files, function (file) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            var img = document.createElement('img');
                            img.src = e.target.result;
                            img.style.width = '100px';
                            img.style.margin = '10px';
                            preview.appendChild(img);
                        }
                        reader.readAsDataURL(file);
                    });
                }
            }
    </script>


</asp:Content>


<%-- <div class="row g-3">
        <div class="col-md-6">
            <div class="content" style="background: white; min-height: 100px; width: 100%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="table-responsive scrollbar">
                            <asp:GridView ID="grdPosting" runat="server" Visible="false" AutoGenerateColumns="true" Width="100%"
                                PageSize="15" AllowPaging="true" AllowSorting="True" CssClass="table table-hover table-striped overflow-hidden"
                                OnRowDataBound="grdPosting_RowDataBound" OnDataBound="grdPosting_DataBound">
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>


        </div>


    </div>

--%>