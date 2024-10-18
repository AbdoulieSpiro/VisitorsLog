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
using HRSystemServer.UPSLayer;
using System.IO;
namespace HRSystemWeb
{

    public partial class CustomControls_PageHeader : ControlBase
    {
        public string image;
        protected override void Page_Load(object sender, EventArgs e)
        {
            loadImages();
        }
        public void loadImages()
        {

            DirectoryInfo dr = new DirectoryInfo(MapPath("~/Header"));
            foreach (FileInfo fi in dr.GetFiles())
            {
                image = image + "imgs.push({file: '" + fi.Name + "', title: '', desc: '', url: '#'});\n ";
            }

        }
    }
}
