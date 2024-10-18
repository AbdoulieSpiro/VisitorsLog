using HRSystemServer.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Linq;
using System.Web.DynamicData;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace HRSystemWeb
{
    public partial class CustomControls_ControlPanelGray : ControlBase
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {

          
            base.Page_Load(sender, e);

       


            if (!IsPostBack)
            {
                HideAllPanel();

                DateTime EndOfYear = new DateTime(DateTime.Today.Year, 12, 31);
                DateTime Today = DateTime.Today;
                DateTime RangeStart = EndOfYear.AddDays(-10);


                if (SessionContext.UserOrderLevel != 4)
                {
                    //drpLineDepot.Enabled = false;
                    //WebUtility.SetDropDownListValue(drpLineDepot, SessionContext.Branch);

                }


            }
            if (SessionContext.Branch != "012")
            {
                pnlCard.Visible = true;


            }

            pnlCard.Visible = false;

          


        }

        protected void btnHidden_Click(object sender, EventArgs e)
        {
            // Your code here
            //lbltotal.Text = "Clicked!";

            string url = @"~/RequestList.aspx";

            // Redirect to the new URL
            Response.Redirect(url);
        }

        protected void drpBarDepot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void drpLineDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
         protected void drpMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public class PieChartData
        {
            public double Value { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
        }

        protected void lnkQlink_Click(object sender, EventArgs e)
        {
            LinkButton ProductIdButton = sender as LinkButton;
            int productId = Convert.ToInt32(ProductIdButton.CommandArgument);
            switch (productId)
            {
                case 0:
                   // piechart();
                    break;
                case 1:
                    Response.Redirect(@"~//Employee//AddEditEmployee.aspx?" + URLMessage.Encrypt("action=create"));
                    break;
                case 2:
                    Response.Redirect(@"~//Employee//ExperienceListnew.aspx?" + URLMessage.Encrypt("ref=Awards"));
                    break;
                case 3:
                    Response.Redirect(@"~//Employee//ExperienceListnew.aspx?" + URLMessage.Encrypt("ref=Disciplinary"));
                    break;
                case 4:
                    Response.Redirect(@"~//Employee//ExperienceListnew.aspx?" + URLMessage.Encrypt("ref=Promotions"));
                    break;
                case 5:
                    Response.Redirect(@"~//Employee//ExperienceListnew.aspx?" + URLMessage.Encrypt("ref=Trainings"));
                    break;
            }
        }

        private void HideAllPanel()
        {
            // Hide all panels here
        }

        protected void imgChangePassword_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(@"~/SystemUser/UpdatePasword.aspx?action=update");
        }

        protected void imgSecurityProfile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(@"~/SecurityProfile/SecurityProfileList.aspx?");
        }

        protected void imgBtnSchool_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/School/SchoolList.aspx?");
        }

        protected void imgbtnApplicantList_Click(object sender, ImageClickEventArgs e)
        {
            // Handle event here
        }

        protected void lnkStaff_Click(object sender, EventArgs e)
        {
            HideAllPanel();
            // Show specific panel here
        }
    }
}
