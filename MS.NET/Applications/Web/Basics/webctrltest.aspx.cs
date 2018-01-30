using System;

namespace BasicWebApp
{
	partial class WebCtrlTestPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GreetLabel.Text = string.Format("Welcome Visitor {0}", Request.QueryString["visitor"]);
			TimeLabel.Text = DateTime.Now.ToString();
		}
	}
}