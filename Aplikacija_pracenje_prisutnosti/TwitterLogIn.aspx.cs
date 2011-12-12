using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetSharp;
using TweetSharp.Model;
using TweetSharp.Twitter.Service;
using Facebook_Graph_Toolkit.Helpers;

public partial class _Default : System.Web.UI.Page 
{
    string authUrl;
    TwitterService twitterService = new TwitterService(TwitterAppInfo.ClientInfo);
    OAuthToken requestToken;
    OAuthToken accessToken = new OAuthToken();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonGetPin_Click(object sender, EventArgs e)
    {
        CreateAuthUrl();
        Page.RegisterStartupScript("PopUP", "<script type='text/javascript'>window.open('"+authUrl+"')</script>");
        //Process.Start(authUrl);
    }

    protected void ButtonAuthorize_Click(object sender, EventArgs e)
    {
        OAuthToken accessToken;
        accessToken = twitterService.GetAccessToken((OAuthToken) Session["TwitterRequestToken"], this.TextBoxPin.Text);

        Session["TwitterAccessToken"] = accessToken;
              
        Page.Response.Redirect(@"~\TwitterTable.aspx");
    }

    private void CreateAuthUrl()
    {
        requestToken = twitterService.GetRequestToken();
        Session["TwitterRequestToken"] = requestToken;
        authUrl = twitterService.GetAuthorizationUrl(requestToken);
        authUrl = Page.ResolveClientUrl(authUrl);
    }

    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
    }

    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        IframeHelper.IframeRedirect("", true, true);
    }

    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GPlusTable.aspx");
    }

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GowallaTable.aspx");
    }

}