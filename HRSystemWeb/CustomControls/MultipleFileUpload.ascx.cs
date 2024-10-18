using System;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using HRSystemServer.BusinessLayer;

namespace HRSystemWeb
{
    public partial class MultipleFileUpload : System.Web.UI.UserControl
    {
        /* This is Click event defenition for MultipleFileUpload control. */
        public event MultipleFileUploadClick Click;

        /* No of Rows to Display. */
        private int _Rows = 9;
        public int Rows
        {
            get
            {
                return _Rows;
            }
            set
            {
                _Rows = value < 9 ? 9 : value;
            }
        }

        /* No of Max Files to Upload */
        private int _UpperLimit = 0;
        public int UpperLimit
        {
            get
            {
                return _UpperLimit;
            }
            set
            {
                _UpperLimit = value;
            }
        }

        /// <summary>
        /// Method for Page Load Event
        /// </summary>
        /// <param name="sender">Reference of the object that raises this Event.</param>
        /// <param name="e">Contains information regarding page load click event Data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlListBox.Attributes["style"] = "overflow:auto;";
            pnlListBox.Height = Unit.Pixel(20 * _Rows - 1);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "MyScript", GetJavaScript());
        }

        /// <summary>
        /// Method for btnUpload Click Event. 
        /// </summary>
        /// <param name="sender">Reference of the object that raises this event.</param>
        /// <param name="e">Contains information regarding button click event Data.</param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /* Fire the Event. */
            Click(this, new FileCollectionEventArgs(this.Request));
            System.Threading.Thread.Sleep(3000);
        }

        /* This method is used to generate javascript code for MultipleFileUpload control that execute at client side. */
        private string GetJavaScript()
        {
            StringBuilder JavaScript = new StringBuilder();

            JavaScript.Append("<script type='text/javascript'>");
            JavaScript.Append("var Id = 0;\n");
            JavaScript.AppendFormat("var MAX = {0};\n", _UpperLimit);
            JavaScript.AppendFormat("var DivFiles = document.getElementById('{0}');\n", pnlFiles.ClientID);
            JavaScript.AppendFormat("var DivListBox = document.getElementById('{0}');\n", pnlListBox.ClientID);
            JavaScript.AppendFormat("var BtnAdd = document.getElementById('{0}');\n", btnAdd.ClientID);
            JavaScript.Append("function Add()");
            JavaScript.Append("{\n");
            JavaScript.Append("var IpFile = GetTopFile();\n");
            JavaScript.Append("if(IpFile == null || IpFile.value == null || IpFile.value.length == 0)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("alert('Please Select a file to Add.');\n");
            JavaScript.Append("return;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("var NewIpFile = CreateFile();\n");
            JavaScript.Append("DivFiles.insertBefore(NewIpFile,IpFile);\n");
            JavaScript.Append("if(MAX != 0 && GetTotalFiles() - 1 == MAX)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("NewIpFile.disabled = true;\n");
            JavaScript.Append("BtnAdd.disabled = true;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("IpFile.style.display = 'none';\n");
            JavaScript.Append("DivListBox.appendChild(CreateItem(IpFile));\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function CreateFile()");
            JavaScript.Append("{\n");
            JavaScript.Append("var IpFile = document.createElement('input');\n");
            JavaScript.Append("var txtdata=document.getElementById('txtdata');\n");
            JavaScript.Append(" IpFile.style.width='298'\n");
            JavaScript.Append(" IpFile.onchange = function (){ txtdata.value = this.value;}\n");
            JavaScript.Append("IpFile.id = IpFile.name = 'IpFile_' + Id++;\n");
            JavaScript.Append("IpFile.type = 'file';\n");
            JavaScript.Append("IpFile.className = 'file';\n");
            JavaScript.Append("return IpFile;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function CreateItem(IpFile)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Item = document.createElement('div');\n");
            JavaScript.Append("Item.style.backgroundColor = '#ffffff';\n");
            JavaScript.Append("Item.style.fontWeight = 'normal';\n");
            JavaScript.Append("Item.style.textAlign = 'left';\n");
            JavaScript.Append("Item.style.verticalAlign = 'middle'; \n");
            JavaScript.Append("Item.style.cursor = 'default';\n");
            JavaScript.Append("Item.style.height = 20 + 'px';\n");
            JavaScript.Append("var Splits = IpFile.value.split('\\\\');\n");
            JavaScript.Append("Item.innerHTML = Splits[Splits.length - 1] + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';\n");
            JavaScript.Append("Item.value = IpFile.id;\n");
            JavaScript.Append("Item.title = IpFile.value;\n");
            JavaScript.Append("var A = document.createElement('a');\n");
            JavaScript.Append("A.innerHTML = 'Delete';\n");
            JavaScript.Append("A.id = 'A_' + Id++;\n");
            JavaScript.Append("A.href = '#';\n");
            JavaScript.Append("A.style.color = 'blue';\n");
            JavaScript.Append("A.onclick = function()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("DivFiles.removeChild(document.getElementById(this.parentNode.value));\n");
            JavaScript.Append("DivListBox.removeChild(this.parentNode);\n");
            JavaScript.Append("if(MAX != 0 && GetTotalFiles() - 1 < MAX)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("GetTopFile().disabled = false;\n");
            JavaScript.Append("BtnAdd.disabled = false;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("}\n");
            JavaScript.Append("Item.appendChild(A);\n");
            JavaScript.Append("Item.onmouseover = function()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("Item.bgColor = Item.style.backgroundColor;\n");
            JavaScript.Append("Item.fColor = Item.style.color;\n");
            JavaScript.Append("Item.style.backgroundColor = '#D6EDF8';\n");
            JavaScript.Append("Item.style.color = '#2882BD';\n");
            JavaScript.Append("Item.style.fontWeight = 'bold';\n");
            JavaScript.Append("}\n");
            JavaScript.Append("Item.onmouseout = function()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("Item.style.backgroundColor = Item.bgColor;\n");
            JavaScript.Append("Item.style.color = Item.fColor;\n");
            JavaScript.Append("Item.style.fontWeight = 'normal';\n");
            JavaScript.Append("}\n");
            JavaScript.Append("return Item;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function Clear()\n");
            JavaScript.Append("{ \n");
            JavaScript.Append("DivListBox.innerHTML = '';\n");
            JavaScript.Append("DivFiles.innerHTML = '';\n");
            JavaScript.Append("DivFiles.appendChild(CreateFile());\n");
            JavaScript.Append("BtnAdd.disabled = false;\n");
            JavaScript.Append("initFileUploads();}\n");
            JavaScript.Append("function GetTopFile()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n");
            JavaScript.Append("var IpFile = null;\n");
            JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("IpFile = Inputs[n];\n");
            JavaScript.Append("break;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("return IpFile;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function GetTotalFiles()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n");
            JavaScript.Append("var Counter = 0;\n");
            JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n");
            JavaScript.Append("Counter++;\n");
            JavaScript.Append("return Counter;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function GetTotalItems()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Items = DivListBox.getElementsByTagName('div');\n");
            JavaScript.Append("return Items.length;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function DisableTop()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("if(GetTotalItems() == 0)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("alert('Please browse at least one file to upload.');\n");
            JavaScript.Append("return false;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("GetTopFile().disabled = true;\n");
            JavaScript.Append("return true;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("</script>");

            return JavaScript.ToString();
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
        }
    }

    /* The EventArgs class has some readonly properties regarding Posted files corresponding to MultipleFileUpload control. */

    public class FileCollectionEventArgs : System.EventArgs
    {
        private System.Web.HttpRequest _HttpRequest;

        public System.Web.HttpFileCollection PostedFiles
        {
            get
            {
                return _HttpRequest.Files;
            }
        }

        public int Count
        {
            get
            {
                return _HttpRequest.Files.Count;
            }
        }

        public bool HasFiles
        {
            get
            {
                return _HttpRequest.Files.Count > 0 ? true : false;
            }
        }

        public double TotalSize
        {
            get
            {
                double Size = 0D;
                for (int n = 0; n < _HttpRequest.Files.Count; ++n)
                {
                    if (_HttpRequest.Files[n].ContentLength < 0)
                        continue;
                    else
                        Size += _HttpRequest.Files[n].ContentLength;
                }

                return System.Math.Round(Size / 1024D, 2);
            }
        }

        public FileCollectionEventArgs(System.Web.HttpRequest oHttpRequest)
        {
            _HttpRequest = oHttpRequest;
        }
    }

    /* Delegate that represents the Click event signature for MultipleFileUpload control. */
    public delegate void MultipleFileUploadClick(object sender, FileCollectionEventArgs e);
}