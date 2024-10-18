using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using HRSystemServer.BusinessLayer;
using HRSystemWeb;

public partial class _Default : PageBase
{
    protected DataSet ds = new DataSet();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void Page_Load(object sender, EventArgs e)
    {
        PageName = "Default";
        PageCode = "Default";
        this.RequireAuthentication = false;
        base.Page_Load(sender, e);
        Response.Redirect(@"~/login/login.aspx");
        string AppCompId = Guid.NewGuid().ToString();




    }
    public void BindGrid()
    {
        //ds = new DataSet();
        //new AdmissionSubjectMarksBL(SessionContext.SystemUser).FetchMarksSheetForAdmissionAndClass(ds, 112, 2);
        //aaa.DataSource = ds.Tables[0].DefaultView;
        //aaa.DataBind();
    }
}
