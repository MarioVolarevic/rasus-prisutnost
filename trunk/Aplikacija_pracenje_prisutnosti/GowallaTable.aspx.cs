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
        //HttpCookie cookie = Request.Cookies["userID"];
        //string userId = cookie.Value;

        if (Session["GowallaUsername"] == null || Session["GowallaPassword"] == null)
        {
            Response.Redirect(@"~\GowallaLogIn.aspx");
        }
        else
        {
            string id = Session["GowallaUsername"].ToString() + Session["GowallaPassword"].ToString();
            GridView1.DataSource = UserX.listOfAllUser[id].friends;
            GridView1.DataBind();
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
}