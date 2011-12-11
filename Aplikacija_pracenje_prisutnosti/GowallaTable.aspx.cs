using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GowallaTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userID"];
        string userId = cookie.Value;

        GridView1.DataSource = UserX.listOfAllUser[userId].friends;
        GridView1.DataBind();


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
}