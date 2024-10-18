<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs"
    Inherits="HRSystemWeb.Login_Login" MasterPageFile="~/MasterPageLogin.master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row min-vh-100 bg-100" style="width:100%">
        <div class="col-6 d-none d-lg-block position-relative">
            <div class="bg-holder" style="background-image: url(../assets/img/generic/14.jpg); background-position: 50% 20%;">
            </div>
            <!--/.bg-holder-->

        </div>
        <div class="col-sm-10 col-md-6 px-sm-0 align-self-center mx-auto py-5">
            <div class="row justify-content-center g-0">
                <div class="col-lg-9 col-xl-8 col-xxl-6">
                    <div class="card">
                        <div class="card-header bg-circle-shape bg-shape text-center p-2">
                            <a class="font-sans-serif fw-bolder fs-4 z-1 position-relative link-light" href="" data-bs-theme="light">Visitors Log</a></div>
                        <div class="card-body p-4">
                            <div class="row flex-between-center">
                                <div class="col-auto">
                                    <h3>Login</h3>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-md-12">
                                    <asp:Label ID="lblUserID" runat="server" CssClass="form-label" Text="User ID:">  </asp:Label>

                                    <asp:TextBox ID="txtLoginId" runat="server" CssClass="form-control" Columns="35" MaxLength="100"
                                        Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row g-3">
                                <div class="col-md-12">
                                    <asp:Label ID="Label1" runat="server" Text=" Password:" CssClass="form-label">  </asp:Label>



                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="20"
                                        TextMode="Password" Font-Names="Arial, Helvetica, sans-serif"></asp:TextBox>

                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-md-12">
                                    <asp:CustomValidator ID="valSignIn" runat="server" Width="170px" ErrorMessage="UserId or Password is not correct. Please make sure that you have correctly entered your Login details."
                                        Display="Dynamic" CssClass="validator"></asp:CustomValidator>
                                    <asp:CustomValidator ID="valLockOut" runat="server" Width="170px" CssClass="validator"
                                        Display="Dynamic" ErrorMessage="<br>Due to security concerns about your account, it has been locked due to too many failed login attempts.  Please contact your School administrator to reactivate your account."></asp:CustomValidator>
                                    <asp:CustomValidator ID="valTrialExpired" runat="server" Width="170px" CssClass="validator"></asp:CustomValidator>
                                </div>
                            </div>

                            <div class="row flex-between-center">
                                <%--<div class="col-auto">
                                    <div class="form-check mb-0">
                                        <input class="form-check-input" type="checkbox" id="split-checkbox" />
                                        <label class="form-check-label mb-0" for="split-checkbox">Remember me</label>
                                    </div>
                                </div>--%>
                                <div class="col-auto">
                                    
                                    <%--<a class="fs--1" href="../../../pages/authentication/split/forgot-password.html">Forgot Password?</a>--%>
                                    <%-- <asp:HyperLink runat="server" ID="lnkPasswordAss" NavigateUrl="~/SystemUser/PasswordRecovery.aspx"
      CssClass="fs--1">Forgot Password?</asp:HyperLink>--%>

                                </div>
                            </div>
                            <div class="mb-3">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary d-block w-100 mt-3" ToolTip="click to login."
                                        OnClick="btnLogin_Click" />    
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>
