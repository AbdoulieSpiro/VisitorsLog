<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageHeader.ascx.cs" Inherits="HRSystemWeb.CustomControls_PageHeader" %>

<script type="text/javascript">
        window.addEvent('load', function() {
            var imgs = [];
             <%= image %>
             
            var myshow = new Slideshow('slideshow', { 
                type: 'combo',
                externals: 0,
                showTitleCaption: 1,
                captionHeight: 45,
                width: 980, 
                height: 200,
                pan: 50,
                zoom: 35,
                loadingDiv: 1,
                resize: true,
                duration: [2000, 9000],
                transition: Fx.Transitions.Expo.easeOut,
                images: imgs, 
                path: 'http://kei.iquasar.com/kei/Header/'
            });

            myshow.caps.h2.setStyles({color: '#fff', fontSize: '13px'});
            myshow.caps.p.setStyles({color: '#ccc', fontSize: '11px'});
        });
  </script>

<asp:Panel ID="pnlPageHeader" runat="server">
    <div id="leftcolumn" style="float: left">
        <div class="moduletable">
            <div id="slidewrap">
                <div id="slideshow">
                </div>
                <div id="loadingDiv">
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
