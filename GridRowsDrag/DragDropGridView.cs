using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace GridRowsDrag
{

    /// <summary>
    /// Drag and Drop is the grid view with drag and drop the item for ordering
    /// </summary>
    public class DragAndDropEventArgs : EventArgs
    {
        private string _startIndex;
        /// <summary>
        /// Index of the source item
        /// </summary>
        public string StartIndex
        {
            get { return _startIndex; }

        }
        private string _endIndex;
        /// <summary>
        /// Index of the destination item
        /// </summary>
        public string EndIndex
        {
            get { return _endIndex; }

        }
        public DragAndDropEventArgs(string startIndex, string endindex)
        {
            _startIndex = startIndex;
            _endIndex = endindex;
        }
    }
    public delegate void DragAndDrop(object sender, DragAndDropEventArgs e);

    public class DragDropGridView : GridView
    {
        /// <summary>
        /// Handle the event for the ordering
        /// </summary>
        public event DragAndDrop DragAndDrop;

        public DragDropGridView()
        {

        }

        protected override void OnPagePreLoad(object sender, EventArgs e)
        {
            base.OnPagePreLoad(sender, e);
            //this.Attributes.Add("onmouseleave", "cleardragging();");
            //call this method for the register __doPostback event on the client side
            Page.ClientScript.GetPostBackEventReference(this, "");

        }
        protected override void OnPreRender(EventArgs e)
        {
            //register the script for item dragging
            RegisterScript();
            base.OnPreRender(e);
        }
        protected override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);
            //Handle the post back event
            //and set the values of the source and destination items
            if (Page.Request["__EVENTARGUMENT"] != null && Page.Request["__EVENTARGUMENT"] != "" && Page.Request["__EVENTARGUMENT"].StartsWith("GridDragging"))
            {
                char[] sep = { ',' };
                string[] col = eventArgument.Split(sep);
                DragAndDrop(this, new DragAndDropEventArgs(col[1], col[2]));
            }
        }

        /* FUNCTION TO GET THE MEDIUM ICON */
        #region "GET MEDIUM IMAGE RELATED TO UPLOADED DOCUMENT"
        public string GetImagePathMediumIcon(string strFileName, string Type, string Theme)
        {

            string strExtension;
            try
            {
                if (Type == "False")
                {
                    strExtension = new System.IO.FileInfo(strFileName).Extension;
                    switch (strExtension.ToLower())
                    {
                        case ".doc":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumDoc.gif";
                        case ".pdf":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumPDF.gif";
                        case ".xls":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumXLS.gif";
                        case ".css":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumCSS.gif";
                        case ".ppt":
                        case ".pps":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumPPT.gif";
                        case ".zip":
                        case ".rar":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumZip.gif";
                        default:
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumDefault.gif";
                    }
                }
                else
                {
                    return "~/App_Themes/" + Theme + "/TPCImages/MediumFolder.gif";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        /* FUNCTION TO GET THE MEDIUM ICON SHARED */
        #region "GET MEDIUM IMAGE RELATED TO UPLOADED DOCUMENT"
        public string GetImagePathMediumIconShared(string strFileName, string Type, string Theme)
        {

            string strExtension;
            try
            {
                if (Type == "False")
                {
                    strExtension = new System.IO.FileInfo(strFileName).Extension;
                    switch (strExtension.ToLower())
                    {
                        case ".doc":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumDoc_Shared.gif";
                        case ".pdf":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumPDF_Shared.gif";
                        case ".xls":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumXLS_Shared.gif";
                        case ".css":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumCSS_Shared.gif";
                        case ".ppt":
                        case ".pps":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumPPT_Shared.gif";
                        case ".zip":
                        case ".rar":
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumZip_Shared.gif";
                        default:
                            return "~/App_Themes/" + Theme + "/TPCImages/MediumDefault_Shared.gif";
                    }
                }
                else
                {
                    return "~/App_Themes/" + Theme + "/TPCImages/MediumFolder_Shared.gif";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            LinkButton lnkEditTag, lnkEditDescription;
            ImageButton imgMediumIcon, imgDeleteFile, imgShareViaEmail, imgRename;
            Label lblID;
            HtmlInputCheckBox chkSharedDoc, chkisFolder;
            Image imgDeleteFileDisable, imgRenameFileDisable, imgShareViaEmailDisable;
            base.OnRowDataBound(e);

            /* set the java script method for the dragging */
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lnkEditTag = (LinkButton)e.Row.FindControl("lnkEditTag");
                lnkEditTag.CommandArgument = e.Row.RowIndex.ToString();
                lnkEditDescription = (LinkButton)e.Row.FindControl("lnkEditDescription");
                lnkEditDescription.CommandArgument = e.Row.RowIndex.ToString();
                lblID = (Label)e.Row.FindControl("lblID");
                //imgComment = (LinkButton)e.Row.FindControl("imgComment");
                //imgComment.CommandArgument = e.Row.RowIndex.ToString();
                bool IsFolder = true;
                //imgDeleteFile = (ImageButton)e.Row.FindControl("imgDeleteFile");
                //imgDeleteFile.CommandArgument = e.Row.RowIndex.ToString();
               // imgDeleteFileDisable = (Image)e.Row.FindControl("imgDeleteFileDisable");
               // imgRenameFileDisable = (Image)e.Row.FindControl("imgRenameFileDisable");
               // imgRename = (ImageButton)e.Row.FindControl("imgRename");
               // imgRename.CommandArgument = e.Row.RowIndex.ToString();
                //chkSharedDoc = (HtmlInputCheckBox)e.Row.FindControl("chkSharedDoc");
               // if (IsFolder)
                    //imgDeleteFile.Attributes.Add("onclick", "return(confirm('Are you sure you want to delete the folder and its all subfolders?'))");
               // else
                   // imgDeleteFile.Attributes.Add("onclick", "return(confirm('Are you sure you want to delete the document?'))");

                imgMediumIcon = (ImageButton)e.Row.FindControl("imgMediumIcon");
                //if (chkSharedDoc.Value == "1")
                //    imgMediumIcon.ImageUrl = GetImagePathMediumIconShared(lblID.Text, IsFolder.ToString(), Page.Theme);
                //else
                imgMediumIcon.ImageUrl = GetImagePathMediumIcon(lblID.Text, IsFolder.ToString(), Page.Theme);
                imgMediumIcon.CommandArgument = e.Row.RowIndex.ToString();
                e.Row.Attributes.Add("onmousedown", "startDragging" + this.ClientID + "(" + e.Row.RowIndex + ",this); ");
                e.Row.Attributes.Add("onmouseover", "this.className='dragDrophover'");
                e.Row.Attributes.Add("onmouseout", "this.className='dragDrophover1'");
            }

        }

        private void RegisterClientScriptVariableDeclarection(string variableName)
        {
            string strvardecl = "var " + variableName + ";";
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), variableName, strvardecl, true);
        }

        private void RegisterScript()
        {
            RegisterClientScriptVariableDeclarection("__gridview" + this.ClientID);
            RegisterClientScriptVariableDeclarection("__item" + this.ClientID);
            RegisterClientScriptVariableDeclarection("__startPosition" + this.ClientID);
            RegisterClientScriptVariableDeclarection("__endPosition" + this.ClientID);
            RegisterClientScriptVariableDeclarection("__tempDocumentmouseMove" + this.ClientID);
            RegisterClientScriptVariableDeclarection("__tempDocumentselectstart" + this.ClientID);
            RegisterClientScriptVariableDeclarection("__tempDocumentmouseup" + this.ClientID);
            string strvardecl = "var ____isDrag" + this.ClientID + "=false;";
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "____isDrag" + this.ClientID, strvardecl, true);
            string strvardecl1 = "var __el" + this.ClientID + "= document.createElement('DIV');";
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "__el" + this.ClientID, strvardecl1, true);

            string cleardragging =
            @" function cleardragging" + this.ClientID + @"()
            {   
            if(__isDrag" + this.ClientID + @" == true)
             {
                if(__item" + this.ClientID + @" != null)
                {
                    __item" + this.ClientID + @".innerHTML = '';
                }
                __gridview" + this.ClientID + @" = null;
                __item" + this.ClientID + @" = null;
                __startPosition" + this.ClientID + @" = null;
                __endPosition" + this.ClientID + @" = null;
                document.onmousemove =  __tempDocumentmouseMove" + this.ClientID + @"  ;
                document.onselectstart = __tempDocumentselectstart" + this.ClientID + @"  ;
                document.onmouseup = __tempDocumentmouseup" + this.ClientID + @"   ;
                document.body.style.cursor='default'
                el.style.display='block'
            }
            __isDrag" + this.ClientID + @" = false;
        }";
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "cleardragging" + this.ClientID, cleardragging, true);
            string strStartDragging =
                @"function startDragging" + this.ClientID + @"(position,item)
            {

           __isDrag" + this.ClientID + @" = true;
                __startPosition" + this.ClientID + @" = position;
               
                __item" + this.ClientID + @" = item;
               el = __el" + this.ClientID + @";
                el.style.display='none'
                el.style.borderright='blue';
                el.style.bordertop ='blue';
                el.style.backgroundcolor= 'lightgrey';
                el.id='dragicon'
                el.style.position = 'absolute';
              el.innerHTML =ShowViewDoc(" + this.ClientID + ",item,position" + @");
                el.style.left = item.style.left;
                    el.style.top = item.style.top;
                    el.style.cursor = 'move';
                document.body.appendChild(el);
                __item" + this.ClientID + @" = el;
                __tempDocumentmouseMove" + this.ClientID + @" = document.onmousemove;
                __tempDocumentselectstart" + this.ClientID + @" = document.onselectstart;
                __tempDocumentmouseup" + this.ClientID + @" =  document.onmouseup;
               document.onselectstart = function() { return  false; }
               document.onmousemove = function ()
                {
el.style.display='block'
                    if(__item" + this.ClientID + @" != null){
                        __item" + this.ClientID + @".style.left=  window.event.clientX + document.body.scrollLeft + document.documentElement.scrollLeft ;
                        __item" + this.ClientID + @".style.top =   window.event.clientY + document.body.scrollTop + document.documentElement.scrollTop ;
                      }
                } 
               document.onmouseup = function () { cleardragging" + this.ClientID + @"(); }
            }
            ";

            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "strStartDragging" + this.ClientID, strStartDragging, true);
            string strStoptDragging =
                @"function stopDraggingstartDraggingOnTreeView" + "" + @"(position,path)
            {
                if(typeof(__isDrag" + this.ClientID + @") != 'undefined' && __isDrag" + this.ClientID + @" == true)
                {
                      document.body.style.cursor='text'
                    startPosition =  __startPosition" + this.ClientID + @";
                    endPosition = position
                    cleardragging" + this.ClientID + @"();
                    if(startPosition != -1 && endPosition != -1)
                    {
                        __doPostBack('" + this.ClientID.Replace("_", "$") + @"','GridDragging,'+startPosition+','+endPosition+'~'+path);
                    }
                }
            }
            
            ";
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "strStoptDragging" + this.ClientID, strStoptDragging, true);

        }
    }
}