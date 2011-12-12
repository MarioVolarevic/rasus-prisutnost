using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook_Graph_Toolkit;

public partial class GPlusLogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\TwitterTable.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        //if (GPlusFriends.CreateInstance() != null)
        //    Page.Response.Redirect(@"~\GPlusTable.aspx");
        //else
            Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~\Default.aspx");
    }

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GowallaTable.aspx");
    }

    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        Session["GUname"] = TextBoxUsername.Text;
        Session["GPass"] = TextBoxPassword.Text;
        //GPlusFriends.CreateInstance(TextBoxUsername.Text, TextBoxPassword.Text);     
        Response.Redirect(@"~\GPlusTable.aspx");
    }
    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
    }
}