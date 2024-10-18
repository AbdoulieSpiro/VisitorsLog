<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ControlPanelHomeList.aspx.cs" Inherits="HRSystemWeb.ControlPanel_ControlPanelHomeList"
    Title="Control Panel" %>

<%@ Register Src="../CustomControls/AdministrationHomePortal.ascx" TagName="AdministrationHome"
    TagPrefix="asp" %>
<%@ Register Src="~/CustomControls/ControlPanelGray.ascx" TagName="AdministrationHomeGray"
    TagPrefix="as" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
    <link href="../vendors/prism/prism-okaidia.css" rel="stylesheet" >    
    <link href="../assets/css/theme.css" rel="stylesheet" >
    <link href="../vendors/simplebar/simplebar.min.css" rel="stylesheet" >
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <%-- <div style="width: 95%; text-align: center; vertical-align: middle">--%>
    <%--<table width="100%">
        <tr>
            <td style="width: 06px">
            </td>
            <td>
                <fieldset>
                    <asp:AdministrationHome ID="ControlPanel" runat="server" />
                </fieldset>
            </td>
            <td style="width: 06px">
            </td>
        </tr>
    </table>--%>
    <%--</div>--%>
    <asp:Panel ID="pnlHomeList" runat="server">
    </asp:Panel>




    

    <!-- ===============================================-->
    <!--    JavaScripts-->
    <!-- ===============================================-->

    <script src="../vendors/popper/popper.min.js"></script>
    <script src="../vendors/bootstrap/bootstrap.min.js"></script>
    <script src="../vendors/anchorjs/anchor.min.js"></script>
    <script src="../vendors/is/is.min.js"></script>
    <script src="../vendors/lodash/lodash.min.js"></script>
    <script src="../vendors/echarts/echarts.min.js"></script>
    <script src="../vendors/dayjs/dayjs.min.js"></script>
    <script src="../assets/js/echarts-example.js"></script>
    <script src="../vendors/prism/prism.js"></script>
    <script src="../vendors/fontawesome/all.min.js"></script>
    <script src="../vendors/lodash/lodash.min.js"></script>
    <script src="https://polyfill.io/v3/polyfill.min.js?features=window.scroll"></script>
    <script src="../vendors/list.js/list.min.js"></script>
    <script src="../assets/js/theme.js"></script>

     <%--<script src="../vendors/bootstrap/bootstrap.min.js"></script> 
     <script src="../vendors/anchorjs/anchor.min.js"></script> 
    <script src="../vendors/lodash/lodash.min.js"></script>
    <script src="../vendors/echarts/echarts.min.js"></script>
    <script src="../assets/js/echarts-example.js"></script>--%>
</asp:Content>

