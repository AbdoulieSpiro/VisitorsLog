<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdministratorPortal.ascx.cs"
    Inherits="HRSystemWeb.AdministratorPortal" %>

<%@ Register Src="AdministratorCalanderEvent.ascx" TagName="AdministratorCalanderEvent"
    TagPrefix="asp" %>
<div align="center">
    <table width="100%" cellspacing="4" cellpadding="4" align="center">
        <tr>
            <td style="width: 33%">
                <asp:ImageButton ID="imgBtnSchool" runat="server" SkinID="imgSchool" PostBackUrl=""
                    OnClick="imgBtnSchool_Click"></asp:ImageButton>
                <br />
                <asp:Label ID="Label1" runat="server" Text="School Setup" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 33%">
                <asp:ImageButton ID="ImageButton4" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/SchoolCategory.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label4" runat="server" Text="School Category" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 34%">
                <asp:ImageButton ID="ImageButton5" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/SchoolType.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label5" runat="server" Text="School Type" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <%--<td onmouseover="bgColor='#E4F5FD'" onmouseout="bgColor='#F7F7F7'">
                    <asp:ImageButton ID="ImageButton2" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/ControlPanel/ControlPanelClassSectionList.aspx">
                    </asp:ImageButton><br />
                    <asp:Label ID="Label2" runat="server" Text="Class/Section" Font-Bold="true"></asp:Label>
                </td>
                <td onmouseover="bgColor='#E4F5FD'" onmouseout="bgColor='#F7F7F7'">
                    <asp:ImageButton ID="ImageButton1" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/ControlPanel/ControlPanelRoomList.aspx">
                    </asp:ImageButton><br />
                    <asp:Label ID="Label1" runat="server" Text="Room" Font-Bold="true"></asp:Label>
                </td>
                <td onmouseover="bgColor='#E4F5FD'" onmouseout="bgColor='#F7F7F7'">
                    <asp:ImageButton ID="ImageButton3" runat="server" SkinID="imgBtnSchoolCal" PostBackUrl="~/ControlPanel/ControlPanelCalanderEventList.aspx">
                    </asp:ImageButton><br />
                    <asp:Label ID="Label3" runat="server" Text="Calander/Event" Font-Bold="true"></asp:Label>
                </td>--%>
            <td style="width: 33%">
                <asp:ImageButton ID="ImageButton12" runat="server" SkinID="imgBTMessage" PostBackUrl="~/SchoolMessage/SchoolMessageList.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label12" runat="server" Text="School Message" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:ImageButton ID="imgStream" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/StreamAddEdit.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="lblSchoolStream" runat="server" Text="School Stream" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:ImageButton ID="imgSubject" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/SubjectAddEdit.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="lblSubject" runat="server" Text="Subject Details" Font-Bold="true"></asp:Label>
            </td>
            <%--<td onmouseover="bgColor='#E4F5FD'" onmouseout="bgColor='#F7F7F7'">
                <asp:ImageButton ID="ImageButton7" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/AddEditSessions.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Sessions" Font-Bold="true"></asp:Label>
            </td>--%>
        </tr>
       
        <tr>
            <td colspan="3">
                <asp:AdministratorCalanderEvent ID="CalanderControlPanel" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 33%">
                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="imgBTComponentDef" PostBackUrl="~/Admin/AddEditSessions.aspx">
                </asp:ImageButton>
                <br />
                <asp:Label ID="Label22" runat="server" Text="Session" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
</div>
