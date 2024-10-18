<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdministrationHomePortal.ascx.cs"
    Inherits="HRSystemWeb.AdministrationHomePortal" %>
<%@ Register Src="AdministratorPortal.ascx" TagName="AdministratorPortal" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div align="center">
    <table width="100%" cellpadding="0">
        <tr>
            <td>
                <asp:Panel ID="pnlheaderAdmin" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            Student
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgHeader" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlAdmin" runat="server">
                    <table width="100%" cellspacing="4" cellpadding="4" align="center">
                        <tr>
                            <td style="width: 33%">
                                <asp:ImageButton ID="imgbtnApplicantList" runat="server" SkinID="imgBTAdmission"
                                    OnClick="imgAssignUser_Click" PostBackUrl="~/Registration/ApplicantList.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="Label14" runat="server" Text="Registration" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 33%">
                                <asp:ImageButton ID="ImageButton12" runat="server" SkinID="imgBTAdmission" OnClick="imgMngUser_Click"
                                    PostBackUrl="~/Registration/AdmissionList.aspx" />
                                <br />
                                <asp:Label ID="Label13" runat="server" Text="Admission" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 34%">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="cpeAdmin" runat="server" CollapseControlID="pnlheaderAdmin"
                    Collapsed="False" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
                    CollapsedText="Show" Enabled="True" ExpandControlID="pnlheaderAdmin" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
                    ExpandedText="Hide" ImageControlID="imgHeader" SuppressPostBack="True" TargetControlID="pnlAdmin" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFeeHeader" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            Fee Management
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgFee" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlfee" runat="server">
                    <table width="100%" cellspacing="4" cellpadding="4" align="center">
                        <tr>
                            <td style="width: 33%">
                                <asp:ImageButton ID="ImageButton10" runat="server" SkinID="imgBTDemandGen" PostBackUrl="~/Fee/GenerateDemmand.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="Fee Generation" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 33%">
                                <asp:ImageButton ID="ImageButton9" runat="server" SkinID="imgBTDues" PostBackUrl="~/Fee/AddEditDuesPayment.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="lblFeeRegister" runat="server" Text="Fee Register" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 34%">
                                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="imgBTDemandGen" PostBackUrl="~/Fee/DuesCollection.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Fee Collection" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="imgbtnCheckStatus" runat="server" SkinID="imgBTDemandGen" PostBackUrl="~/Fee/CheckStatusEdit.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="lblCheckStatus" runat="server" Text="Check Status" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton6" runat="server" SkinID="imgBTF" PostBackUrl="~/Fee/AddEditFeeComponent.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="Label6" runat="server" Text="Fee Components" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton8" runat="server" SkinID="imgBTF" PostBackUrl="~/Fee/ClassFeeComponents.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="Class Fee Components" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="cpeFee" runat="server" CollapseControlID="pnlFeeHeader"
                    Collapsed="true" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
                    CollapsedText="Show" Enabled="True" ExpandControlID="pnlFeeHeader" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
                    ExpandedText="Hide" ImageControlID="imgFee" SuppressPostBack="True" TargetControlID="pnlfee" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSubAdminHeader" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            School
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgsubheader" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlSubAdmin" runat="server">
                    <table width="100%" cellspacing="4" cellpadding="4" align="center">
                        <tr>
                            <td>
                                <asp:AdministratorPortal ID="ControlPanel" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="cpeSubadmin" runat="server" CollapseControlID="pnlSubAdminHeader"
                    Collapsed="true" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
                    CollapsedText="Show" Enabled="True" ExpandControlID="pnlSubAdminHeader" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
                    ExpandedText="Hide" ImageControlID="imgsubheader" SuppressPostBack="True" TargetControlID="pnlSubAdmin" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlVedioHeader" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            Online Classes
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgVideo" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlVideo" runat="server">
                    <table width="100%" cellspacing="4" cellpadding="4" align="center">
                        <tr>
                            <td style="width: 33%">
                                <asp:ImageButton ID="ImgViewVedio" runat="server" SkinID="imgVideo" OnClick="ImgViewVedio_Click" />
                                <br />
                                <asp:Label ID="lblVedio" runat="server" Text="View Video" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 33%">
                                <asp:ImageButton ID="btnUploadvedio" runat="server" PostBackUrl="~/Media/SchoolMedia.aspx"
                                    SkinID="imgVideoUpload" /><br />
                                <asp:Label ID="lbluploadvedio" runat="server" Text="Upload Video" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 34%">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="cpevideo" runat="server" CollapseControlID="pnlVedioHeader"
                    Collapsed="true" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
                    CollapsedText="Show" Enabled="True" ExpandControlID="pnlVedioHeader" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
                    ExpandedText="Hide" ImageControlID="imgVideo" SuppressPostBack="True" TargetControlID="pnlVideo" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlReportsHeader" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            Reports
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgOpenReport" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlReports" runat="server">
                    <table width="100%" cellspacing="5" cellpadding="5" align="center">
                        <tr>
                            <td>
                                <asp:ImageButton ID="imgReport" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/FeeCollectionReport.aspx" />
                                <br />
                                <asp:Label ID="lblreport" runat="server" Text="Daily Fee Collection" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgYearlyFee" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/FeeReport.aspx" />
                                <br />
                                <asp:Label ID="lblYearlyFee" runat="server" Text="Yearly Fee Collection" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgMonthlyFeeCollectionReport" runat="server" SkinID="imgReports"
                                    PostBackUrl="~/Reports/MonthlyFeeCollectionReport.aspx" />
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="Monthly Fee Collection" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="imgMonthlyClassFeeCollectionReport" runat="server" SkinID="imgReports"
                                    PostBackUrl="~/Reports/ClassWiseMonthlyFeeReport.aspx" />
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Monthly Class Fee Collection" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgbtnAdmissionReport" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/AdmissionReport.aspx" />
                                <br />
                                <asp:Label ID="lblAdmissionReport" runat="server" Text="Admission" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgbtnRegistrationReport" runat="server" SkinID="imgReports"
                                    PostBackUrl="~/Reports/RegistrationReport.aspx" />
                                <br />
                                <asp:Label ID="lblRegistrationReport" runat="server" Text="Registration" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="imgDuesReport" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/DuesReport.aspx" />
                                <br />
                                <asp:Label ID="lblDuesReport" runat="server" Text="Dues Report" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgAbsentStudent" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/AbsentStudentsReport.aspx" />
                                <br />
                                <asp:Label ID="lblAbsentStudent" runat="server" Text="Absent Students Report" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgMarksReport" runat="server" SkinID="imgReports" PostBackUrl="~/Examination/StudentsMarksSheet.aspx" />
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Progress Report" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImgFeeStructure" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/FeeStructureReport.aspx" />
                                <br />
                                <asp:Label ID="Label7" runat="server" Text="Fee Structure Report" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImgFeeRegister" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/FeeRegisterReport.aspx" />
                                <br />
                                <asp:Label ID="Label114" runat="server" Text="Fee Register Report" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgResultRegister" runat="server" SkinID="imgReports" PostBackUrl="~/Reports/ResultRegisterReport.aspx" />
                                <br />
                                <asp:Label ID="lblResultRegister" runat="server" Text="Result Register Report" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" CollapseControlID="pnlReportsHeader"
                    Collapsed="true" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
                    CollapsedText="Show" Enabled="True" ExpandControlID="pnlReportsHeader" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
                    ExpandedText="Hide" ImageControlID="imgOpenReport" SuppressPostBack="True" TargetControlID="pnlReports" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSecurityHeader" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            Security
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgSechead" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlsecurity" runat="server">
                    <table width="100%" cellspacing="4" cellpadding="4" align="center">
                        <tr>
                            <td style="width: 33%">
                                <asp:ImageButton ID="imgSystemUser" runat="server" SkinID="ImgSystemUser" PostBackUrl="~/SystemUser/SystemUserList.aspx" />
                                <br />
                                <asp:Label ID="lblSystemUser" runat="server" Text="System User List" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td style="width: 33%">
                                <asp:ImageButton ID="imgSystemRoleType" runat="server" SkinID="ImgRoleTypes" PostBackUrl="~/SystemRoletype/systemroletypelist.aspx" />
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="System Role Type List" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td style="width: 34%">
                                <asp:ImageButton ID="imgPageMapping" runat="server" SkinID="ImgPageMapping" PostBackUrl="~/PageMapping/PageMappingList.aspx" />
                                <br />
                                <asp:Label ID="lblPageMapping" runat="server" Text="Page Mapping" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="imgSecurityProfile" runat="server" SkinID="ImgChangePassword"
                                    OnClick="imgSecurityProfile_Click" />
                                <br />
                                <asp:Label ID="lblSecurityProfile" runat="server" Text="Security Profile" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgChangePassword" runat="server" SkinID="ImgChangePassword"
                                    OnClick="imgChangePassword_Click" />
                                <br />
                                <asp:Label ID="lblChangePassword" runat="server" Text="Change Password" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:CollapsiblePanelExtender ID="cpeSecurity" runat="server" CollapseControlID="pnlSecurityHeader"
                    Collapsed="true" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
                    CollapsedText="Show" Enabled="True" ExpandControlID="pnlSecurityHeader" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
                    ExpandedText="Hide" ImageControlID="imgSechead" SuppressPostBack="True" TargetControlID="pnlsecurity" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlAcademicHeader" runat="server" CssClass="collapsePanelHeader" Height="23px">
                    <div>
                        <div style="float: left;">
                            Academics/Examination
                        </div>
                        <div class="PanelAlign">
                            <asp:ImageButton ID="imgAcademicheader" runat="server" SkinID="imgExpander" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlAcademics" runat="server">
                    <table width="100%" cellspacing="4" cellpadding="4" align="center">
                        <tr>
                            <%--<td style="width: 33%">
                                <asp:ImageButton ID="imgAcademics" runat="server" SkinID="imgReports" PostBackUrl="~/Examination/ClassTestAddEdit.aspx" />
                                <br />
                                <asp:Label ID="lblAcademics" runat="server" Text="Class Tests" Font-Bold="true"></asp:Label>
                            </td>--%>
                            <td style="width: 33%">
                                <asp:ImageButton ID="imgExams" runat="server" SkinID="imgReports" PostBackUrl="~/Examination/ClassExamination.aspx" />
                                <br />
                                <asp:Label ID="lblExams" runat="server" Text="Examination" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 34%">
                                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Examination/AdmissionSubjectMarks.aspx">
                                </asp:ImageButton>
                                <br />
                                <asp:Label ID="lblAdmissionSubjectMarks" runat="server" Text="Subject Marks" Font-Bold="true">
                                </asp:Label>
                            </td>
                            <td style="width: 33%">
                                <asp:ImageButton ID="imgbnResultGradet" runat="server" SkinID="imgBTComponentDef"
                                    PostBackUrl="~/Admin/ResultGrade.aspx"></asp:ImageButton>
                                <br />
                                <asp:Label ID="lblGrade" runat="server" Text="Result Grade" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 33%">
                            </td>
                            <td style="width: 34%">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
    </asp:Panel>
    <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender4" runat="server" CollapseControlID="pnlAcademicHeader"
        Collapsed="true" CollapsedImage="../App_Themes/Default/images/expand_blue.jpg"
        CollapsedText="Show" Enabled="True" ExpandControlID="pnlAcademicHeader" ExpandedImage="../App_Themes/Default/images/collapse_blue.jpg"
        ExpandedText="Hide" ImageControlID="imgAcademicheader" SuppressPostBack="True"
        TargetControlID="pnlAcademics" />
    </td> </tr> </table>
</div>
