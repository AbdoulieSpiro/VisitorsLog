<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdministrationPortal.ascx.cs"
    Inherits="HRSystemWeb.AdministrationPortal" %>
<table width="100%">
    <tr>
        <td class="LeftWidthTD">
            &nbsp;
        </td>
        <td style="padding-top: 8px">
            <br />
            <div>
                <div class="searchborder">
                    <div class="SeachHeader">
                        <asp:Label ID="lblFilter" runat="server" Text="Administrator List:" EnableTheming="false"
                            Font-Bold="true"></asp:Label>
                    </div>
                    <div class="SeachBackGround">
                        <table width="90%">
                            <tr>
                                <td align="left" colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgMngUser" runat="server" SkinID="imgBTAssignUser" OnClick="imgMngUser_Click" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgStockReport" runat="server" SkinID="imgBTReport" ToolTip=" Stock Report"
                                        OnClick="imgStockReport_Click"></asp:ImageButton>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgStockCard" runat="server" SkinID="imgBTCard" ToolTip=" Stock Card"
                                        OnClick="imgStockCard_Click"></asp:ImageButton>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgDeptBal" runat="server" ImageUrl="~/App_Themes/Default/images/Report Outlet Bal.png"
                                        ToolTip=" Outlet Balance Report" OnClick="imgDeptBal_Click"> </asp:ImageButton>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgDeptSal" runat="server" ImageUrl="~/App_Themes/Default/images/Report Sale bal.png"
                                        ToolTip=" Outlet Sale Report" OnClick="imgDeptSal_Click"> </asp:ImageButton>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageAs" runat="server" ImageUrl="~/App_Themes/Default/images/AsBalRpt.png"
                                        ToolTip=" Stock AsAt Date Balance" OnClick="imgStoreDate_Click"> </asp:ImageButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </td>
        <td class="RightWidthTD">
            &nbsp;
        </td>
    </tr>
</table>
