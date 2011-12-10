using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gowalaWarp2;

public partial class GowallaLogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GowallaUser.user != null)
        {
            Page.Response.Redirect(@"~\GowallaTable.aspx");
        }
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
        //if (GPlusFriends.CreateInstance() != null)
            Page.Response.Redirect(@"~\GPlusTable.aspx");
        //else
        //    Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }

    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        GowallaUser.user = new Gowalla(TextBoxUsername.Text, TextBoxPassword.Text);
        if (GowallaUser.user.Status == false)
        {
            LabelError.Text = "Wrong username and/or password";
        }
        else
        {
            Page.Response.Redirect(@"~\GowallaTable.aspx");
        }
    }
}