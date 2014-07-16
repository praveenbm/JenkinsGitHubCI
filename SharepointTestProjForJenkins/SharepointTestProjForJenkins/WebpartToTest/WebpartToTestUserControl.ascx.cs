using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace SharepointTestProjForJenkins.WebpartToTest
{
    public partial class WebpartToTestUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {           
                       
            SPSite site = new SPSite("http://abc.com");
            SPWeb web = site.OpenWeb();

            MathUtility math = new MathUtility();
            Label3.Text =Convert.ToString(math.Add(Convert.ToInt16(TextBox1.Text), Convert.ToInt16(TextBox2.Text)));

        }




    }
}
