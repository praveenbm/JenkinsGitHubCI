﻿using System;
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
            Label1.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            Label1.Text =  "You clicked me!!";
            
            Label1.Font.Italic= true;

            SPSite site = new SPSite("http://abc.com");
        }
    }
}
