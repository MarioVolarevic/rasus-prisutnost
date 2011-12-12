using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook_Graph_Toolkit.Helpers;

public partial class GPlusLogIn : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Error"] != null)
            if (Session["Error"].ToString() == "DA")
                invalidUP.Text = "Invalid User/Pass";
    }
    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\TwitterTable.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
            Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect(@"~\Default.aspx");
        IframeHelper.IframeRedirect(@"http://apps.facebook.com/lab_profil_test/Default.aspx", false, true);
    }

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GowallaTable.aspx");
    }

    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        Session["GUname"] = TextBoxUsername.Text;
        Session["GPass"] = TextBoxPassword.Text;
        Response.Redirect(@"~\GPlusTable.aspx");
    }
    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
    }
}