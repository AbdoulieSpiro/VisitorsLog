<%--<%@ Register TagPrefix="oboutEM" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>--%>
<%@ Register TagPrefix="oem" Namespace="OboutInc.EasyMenu_Pro" Assembly="obout_EasyMenu_Pro" %>
<%@ Control Language="c#" Inherits="HRSystemWeb.LoginMenu" CodeFile="LoginMenu.ascx.cs" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%" class="Menu">
    <tr>
        <td valign="top">
            <oem:EasyMenu ID="EasymenuMain" runat="server" ShowEvent="Always" StyleFolder="styles/horizontal1"
                Position="Horizontal" CSSMenu="ParentMenu" CSSMenuItemContainer="ParentItemContainer"
                Width="390">
                <CSSClassesCollection>
                    <oem:CSSClasses ObjectType="OboutInc.EasyMenu_Pro.MenuItem" ComponentSubMenuCellOver="ParentItemSubMenuCellOver"
                        ComponentContentCell="ParentItemContentCell" Component="ParentItem" ComponentSubMenuCell="ParentItemSubMenuCell"
                        ComponentIconCellOver="ParentItemIconCellOver" ComponentIconCell="ParentItemIconCell"
                        ComponentOver="ParentItemOver" ComponentContentCellOver="ParentItemContentCellOver">
                    </oem:CSSClasses>
                    <oem:CSSClasses ObjectType="OboutInc.EasyMenu_Pro.MenuSeparator" ComponentSubMenuCellOver="ParentSeparatorSubMenuCellOver"
                        ComponentContentCell="ParentSeparatorContentCell" Component="ParentSeparator"
                        ComponentSubMenuCell="ParentSeparatorSubMenuCell" ComponentIconCellOver="ParentSeparatorIconCellOver"
                        ComponentIconCell="ParentSeparatorIconCell" ComponentOver="ParentSeparatorOver"
                        ComponentContentCellOver="ParentSeparatorContentCellOver"></oem:CSSClasses>
                </CSSClassesCollection>
                <Components>
                    <oem:MenuItem Url="~//Home//Home.aspx" InnerHtml="&nbsp;Home&nbsp;&nbsp;" ID="Home">
                    </oem:MenuItem>
                    <oem:MenuSeparator Visible="false" InnerHtml="|" ID="MenuSeparator7">
                    </oem:MenuSeparator>
                    <oem:MenuItem Visible="false" InnerHtml="&nbsp; Modules" ID="module">
                    </oem:MenuItem>
                    <oem:MenuSeparator InnerHtml="|" ID="MenuSeparator6">
                    </oem:MenuSeparator>
                    <oem:MenuItem InnerHtml="&nbsp;Features & benifits" ID="School" Url="~//Home/Feature.aspx">
                    </oem:MenuItem>
                    <oem:MenuSeparator InnerHtml="|" ID="MenuSeparator3">
                    </oem:MenuSeparator>
                    <oem:MenuItem InnerHtml="&nbsp;Support" ID="support" Url="~//Home/support.aspx">
                    </oem:MenuItem>
                    <oem:MenuSeparator InnerHtml="|" ID="MenuSeparator2">
                    </oem:MenuSeparator>
                    <oem:MenuItem InnerHtml="&nbsp;Pricing" ID="Reports" Url="~//Home/Pricing.aspx">
                    </oem:MenuItem>
                    <oem:MenuSeparator InnerHtml="|" ID="MenuSeparator1">
                    </oem:MenuSeparator>
                    <oem:MenuItem InnerHtml="&nbsp;About Us" ID="aboutUs">
                    </oem:MenuItem>
                    <oem:MenuSeparator InnerHtml="|" ID="MenuSeparator5">
                    </oem:MenuSeparator>
                    <oem:MenuItem InnerHtml="&nbsp;Login" Url="~//login//login.aspx?" ID="MenuItem14">
                    </oem:MenuItem>
                </Components>
            </oem:EasyMenu>
            <%-- First Order --%>
            <oem:EasyMenu ID="Easymenu2" runat="server" ShowEvent="MouseOver" AttachTo="module"
                Align="Under" OffsetVertical="-2" Width="200" StyleFolder="styles/horizontal1">
                <Components>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Registration" ID="MenuItem1">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Admission" ID="MenuItem2">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Fee mangement" ID="MenuItem3">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Pay Roll" ID="MenuItem12">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Acounting" ID="MenuItem4">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Attendence" ID="MenuItem5">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="TimeTable" ID="MenuItem6">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="SMS Service" ID="MenuItem7">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//School//SchoolList.aspx?" InnerHtml="Online Classes" ID="MenuItem13">
                    </oem:MenuItem>
                </Components>
            </oem:EasyMenu>
            <oem:EasyMenu ID="Easymenu1" runat="server" ShowEvent="MouseOver" AttachTo="aboutUs"
                Align="Under" OffsetVertical="-2" Width="200" StyleFolder="styles/horizontal1">
                <Components>
                    <oem:MenuItem Url="~//home//Overview.aspx" InnerHtml="Overview" ID="MenuItem8">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//home//Company.aspx" InnerHtml="Company" ID="MenuItem9">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//home//ContactUs.aspx" InnerHtml="ContactUs" ID="MenuItem10">
                    </oem:MenuItem>
                    <oem:MenuItem Url="~//home//Privacy.aspx" InnerHtml="Privacy Statement" ID="MenuItem11">
                    </oem:MenuItem>
                </Components>
            </oem:EasyMenu>
        </td>
    </tr>
</table>
