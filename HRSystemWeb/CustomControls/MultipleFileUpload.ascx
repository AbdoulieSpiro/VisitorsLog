<%@ Control Language="C#" CodeFile="MultipleFileUpload.ascx.cs" Inherits="HRSystemWeb.MultipleFileUpload" %>
<br />
<asp:Panel ID="pnlParent" runat="server" Width="395px" Height="272px">
    <asp:Panel ID="pnlFiles" runat="server" Width="400px" HorizontalAlign="Left" CssClass="fileinputs">
        <input type="file" class="file" id="IpFile" style="width: 298px" runat="server" />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlListBox" runat="server" Width="385px" BorderStyle="Inset" Height="184px">
    </asp:Panel>
    <div id="files_list">
    </div>
    <br />
    <asp:Panel ID="pnlButton" runat="server" Width="392px" HorizontalAlign="center" Height="20px">
        <asp:Image ID="btnAdd" onClick="javascript:Add();" runat="server" SkinID="uploadBtnAdd" />
        <asp:ImageButton ID="btnUpload" OnClientClick="javascript:return DisableTop();" runat="server"
            OnClick="btnUpload_Click" SkinID="UploadFiles" />
        <asp:Image ID="btnClear" onClick="javascript:Clear();" SkinID="uploadBtnClear" runat="server" />
    </asp:Panel>
</asp:Panel>

<script language="javascript" type="text/javascript">
      	var W3CDOM = (document.createElement && document.getElementsByTagName);
	        initFileUploads()
    	    function initFileUploads()
	        {
		        if (!W3CDOM) return;
		        var fakeFileUpload = document.createElement('div');
		        var span=document.createElement('span');
		        fakeFileUpload.className = 'fakefile';
		        var text =document.createElement('input')
		        text.id='txtdata'
		        text.style.width='210px'
		        span.appendChild(text);
		        //span.className='top';
		        fakeFileUpload.appendChild(span);
		        var image = document.createElement('img');
		        image.src='../App_Themes/HRGray/images/SelectFile.gif';
		        fakeFileUpload.appendChild(image);
		        var x = document.getElementsByTagName('input');
		        for (var i=0;i<x.length;i++)
		        {
			        if (x[i].type != 'file') continue;
			        if (x[i].parentNode.className != 'fileinputs') continue;
			        x[i].className = 'file hidden';
			        var clone = fakeFileUpload.cloneNode(true);
			        x[i].parentNode.appendChild(clone);
			        x[i].relatedElement = clone.getElementsByTagName('input')[0];
			        x[i].onchange = function ()
			        {
				        this.relatedElement.value = this.value;
			        }
		        }
	}
</script>

