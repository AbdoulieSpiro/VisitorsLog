<%--<%@ Register TagPrefix="oboutEM" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>--%>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>
<%@ Control Language="c#" Inherits="HRSystemWeb.MenuControl_Horizontal" CodeFile="MenuControl_Horizontal.ascx.cs" %>

<nav class="navbar navbar-light navbar-glass navbar-top navbar-expand-lg" style="padding-bottom: 0; background: #004F7B;">
    <div class="w-100">
        <div class="d-flex flex-between-center" style="padding: 4px 70px">

            <button class="btn navbar-toggler-humburger-icon navbar-toggler me-1 me-sm-3" type="button" data-bs-toggle="collapse" data-bs-target="#navbarDoubleTop" aria-controls="navbarDoubleTop" aria-expanded="false" aria-label="Toggle Navigation"><span class="navbar-toggle-icon"><span class="toggle-line"></span></span></button>
            <asp:HyperLink runat="server" ID="Home" CssClass="navbar-brand me-1 me-sm-3">
                <div class="d-flex align-items-center">
                    <%--<img class="me-2" src="../Imag/logo.png" alt="" width="40" />--%>
                    <asp:Image ID="logoImage" runat="server" CssClass="me-2" Alt="Logo" Width="30px" />

                    <span class="font-sans-serif text-primary" style="color: white !important;">Visitors Log System</span>
                </div>
            </asp:HyperLink>

        </div>
        <div class="collapse navbar-collapse scrollbar py-lg-2" id="navbarDoubleTop" style="padding: 0 70px; background: rgba(237, 242, 249, 0.96);">
            <ul class="navbar-nav" data-top-nav-dropdowns="data-top-nav-dropdowns">

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="Maintenance">Maintenance</a>
                    <div class="dropdown-menu dropdown-caret dropdown-menu-card border-0 mt-0" aria-labelledby="Maintenance">
                        <div class="bg-white dark__bg-1000 rounded-3 py-2">       
                            <asp:HyperLink runat="server" class="dropdown-item link-600 fw-medium" href="../Maintenance/BranchList.aspx" ID="Branch" Text="Branch"></asp:HyperLink>
                            <asp:HyperLink runat="server" class="dropdown-item link-600 fw-medium" href="../Maintenance/DepartmentList.aspx" ID="Department" Text="Department"></asp:HyperLink>
                            <asp:HyperLink runat="server" class="dropdown-item link-600 fw-medium" href="../Maintenance/UnitList.aspx" ID="Unit" Text="Unit" ></asp:HyperLink>
                        </div>
                    </div>
                </li>

                                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="VisitorsMaintenance">Visitors Maintenance</a>
                    <div class="dropdown-menu dropdown-caret dropdown-menu-card border-0 mt-0" aria-labelledby="Visitors Maintenance">
                        <div class="bg-white dark__bg-1000 rounded-3 py-2">
                            <a class="dropdown-item link-600 fw-medium" href="../Maintenance/Visitors.aspx">Vistors Log</a>
                            <a class="dropdown-item link-600 fw-medium" href="../Maintenance/VisitorsList.aspx">Visitors List</a>
                    </div>
                        </div>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="SystemUser">System User</a>
                    <div class="dropdown-menu dropdown-caret dropdown-menu-card border-0 mt-0" aria-labelledby="SystemUser">
                        <div class="bg-white dark__bg-1000 rounded-3 py-2">
                            <a class="dropdown-item link-600 fw-medium" href="../SystemUser/SystemUserList.aspx">System User List</a>
                            <asp:HyperLink runat="server" class="dropdown-item link-600 fw-medium" ID="UpdatePassword" Text="Change Password"></asp:HyperLink>
                        </div>
                    </div>
                </li>

                                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="Reports"> Reports</a>
                    <div class="dropdown-menu dropdown-caret dropdown-menu-card border-0 mt-0" aria-labelledby="Reports">
<%--                        <div class="bg-white dark__bg-1000 rounded-3 py-2">
                            <a class="dropdown-item link-600 fw-medium" href="../SystemUser/SystemUserList.aspx">System User List</a>
                            <asp:HyperLink runat="server" class="dropdown-item link-600 fw-medium" ID="HyperLink1" Text="Change Password"></asp:HyperLink>
                        </div>--%>
                    </div>
                </li>




                <li class="nav-item dropdown">
                    <asp:HyperLink runat="server" class="nav-link" ID="Logins" Text="Logout" role="button" aria-haspopup="true" aria-expanded="false"></asp:HyperLink>

                </li>

            </ul>
        </div>
    </div>


</nav>
