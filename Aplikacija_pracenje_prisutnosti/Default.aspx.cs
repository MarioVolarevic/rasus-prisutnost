using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook_Graph_Toolkit;
using Facebook_Graph_Toolkit.GraphApi;
using Facebook_Graph_Toolkit.FacebookObjects;
using FacebookLibrary;


public partial class _Default : CanvasPage 
{
    protected void Page_PreInit(object sender, EventArgs e) 
    {
        if (Session["FBLogInReq"] == null)
        {
            RequireLogin = true;
            Session["FBLogInReq"] = "OK";
            ExtendedPermissions = "friends_online_presence";
            CheckExtendedPermissions = true;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("userID");
        HttpCookie cookieRet = Request.Cookies["userID"];

        if (cookieRet == null)
        {            
            cookie.Value = UserX.counter.ToString();
            UserX.counter++;
            Response.Cookies.Add(cookie);
        }
        //vjekin kod
        GridView1.DataSource = FacebookClient.Connect(Api, FBUserID);
        GridView1.DataBind();
        
    }

    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e) 
    {
        GridView1.DataSource = FacebookClient.Connect(Api, FBUserID);
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

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {                
            Page.Response.Redirect(@"~\GowallaLogIn.aspx");
    }
    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
    }
}