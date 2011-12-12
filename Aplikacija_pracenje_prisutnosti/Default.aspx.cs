﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook_Graph_Toolkit;
using Facebook_Graph_Toolkit.GraphApi;
using Facebook_Graph_Toolkit.FacebookObjects;
using Facebook_Graph_Toolkit.Helpers;
using JSON;
using FacebookLibrary;

public partial class _Default : CanvasPage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        RequireLogin = true;
        ExtendedPermissions = "friends_online_presence";
        CheckExtendedPermissions = true;              
    }

    protected void OnLoad(object sender, EventArgs e)
    {

       

    }

    protected void Page_Load(object sender, EventArgs e)
    {      
        //JsonObject newObject = new JsonObject();
        //Facebook_Graph_Toolkit.GraphApi.User user = new User(FBUserID);
        //newObject = user.JsonData;

      
        //vjekin kod

        List<FacebookTable> table = FacebookClient.Connect(Api, FBUserID);
        foreach (FacebookTable item in table) 
        {
            ListBoxFB.Items.Add(item.Name + " " + item.FBStatus);
        }
        //GridView1.DataSource = FacebookClient.Connect(Api, FBUserID);
        //GridView1.DataBind();

    }

    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e) 
    {
        List<FacebookTable> table = FacebookClient.Connect(Api, FBUserID);
        foreach (FacebookTable item in table)
        {
            ListBoxFB.Items.Add(item.Name + " " + item.FBStatus);
        }
        //GridView1.DataSource = FacebookClient.Connect(Api, FBUserID);
        //GridView1.DataBind();    
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
        //IframeHelper.IframeRedirect(@"\GPlusLogIn.aspx", false, true);
    }

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {                
            Page.Response.Redirect(@"~\GowallaTable.aspx");
    }
    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
    }
}