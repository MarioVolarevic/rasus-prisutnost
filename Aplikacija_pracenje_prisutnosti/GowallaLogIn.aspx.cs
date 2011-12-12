using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gowalaWarp2;

public partial class GowallaLogIn : System.Web.UI.Page
{
    private string userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userID"];

        this.userId = cookie.Value;
        if (UserX.listOfAllUser.ContainsKey(userId))
        {
            Page.Response.Redirect(@"~\GowallaTable.aspx");
        }

    }

    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\TwitterTable.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        //if (GPlusFriends.CreateInstance() != null)
            Page.Response.Redirect(@"~\GPlusTable.aspx");
        //else
        //    Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
       
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
     
    }
    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        Gowalla newUser = new Gowalla(TextBoxUsername.Text, TextBoxPassword.Text);
        if (newUser.Status == false)
        {
            LabelError.Text = "Wrong username and/or password";
        }
        else
        {
            UserX.listOfAllUser.Add(userId, newUser);
            Page.Response.Redirect(@"~\GowallaTable.aspx");
        }
    }
}