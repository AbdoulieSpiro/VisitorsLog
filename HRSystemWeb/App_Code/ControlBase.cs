using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HRSystemWeb;

/// <summary>
/// All the common members and the security related code will go here.
/// </summary>
public class ControlBase : System.Web.UI.UserControl
{
    protected Cargo CargoBag;
    protected URLMessage URLMessage = new URLMessage();
    /// <summary>
    /// 
    /// </summary>
    public ControlBase()
    {
        CargoBag = new Cargo(ViewState);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void Page_Load(object sender, EventArgs e)
    {
        Security.Secure(this);
    }
    /// <summary>
    /// 
    /// </summary>
    protected int RowId
    {
        get
        {
            return CargoBag.GetValue("RowId", -1);
        }
        set
        {
            CargoBag.SetValue("RowId", value);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected int ParentId
    {
        get
        {
            return CargoBag.GetValue("ParentId", -1);
        }
        set
        {
            CargoBag.SetValue("ParentId", value);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected int Parent2Id
    {
        get
        {
            return CargoBag.GetValue("Parent2Id", -1);
        }
        set
        {
            CargoBag.SetValue("Parent2Id", value);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected int Parent3Id
    {
        get
        {
            return CargoBag.GetValue("Parent3Id", -1);
        }
        set
        {
            CargoBag.SetValue("Parent3Id", value);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    protected int Parent4Id
    {
        get
        {
            return CargoBag.GetValue("Parent3Id", -1);
        }
        set
        {
            CargoBag.SetValue("Parent3Id", value);
        }
    }

    protected void InsertSelect(DropDownList drp)
    {
        drp.Items.Insert(0, new ListItem("Select", "-1"));
    }
}
