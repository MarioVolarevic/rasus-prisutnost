using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GPlusLogIn : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {
        if (TwitterAcount.logedIn == true)
            Page.Response.Redirect(@"~\TwitterTable.aspx");
        else
            Page.Response.Redirect(@"~\TwitterLogIn.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        if (GPlusFriends.CreateInstance() != null)
            Page.Response.Redirect(@"~\GPlusTable.aspx");
        else
            Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        GPlusFriends.CreateInstance(TextBoxUsername.Text, TextBoxPassword.Text);
        Response.Redirect(@"~\GPlusTable.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~\Default.aspx");
    }

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GowallaLogIn.aspx");
    }
}