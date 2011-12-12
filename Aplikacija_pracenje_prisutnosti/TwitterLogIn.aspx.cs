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

public partial class _Default : System.Web.UI.Page 
{
    string authUrl;
    TwitterService twitterService = new TwitterService(TwitterAcount.ClientInfo);
    OAuthToken requestToken;
    OAuthToken accessToken;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonGetPin_Click(object sender, EventArgs e)
    {
        CreateAuthUrl();
        Process.Start(authUrl);
    }

    protected void ButtonAuthorize_Click(object sender, EventArgs e)
    {
        OAuthToken accessToken;
        accessToken = twitterService.GetAccessToken(requestToken, this.TextBoxPin.Text);

        Session["TwitterToken"] = accessToken.Token;
        Session["TwitterTokenSecret"] = accessToken.TokenSecret;
              
        Page.Response.Redirect(@"~\TwitterTable.aspx");
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

    //protected void ButtonGetPin_PreRender(object sender, EventArgs e)
    //{
    //    TwitterClientInfo twitterClientInfo = new TwitterClientInfo();
    //    twitterClientInfo.ConsumerKey = TwitterAcount.ConsumerKey;
    //    twitterClientInfo.ConsumerSecret = TwitterAcount.ConsumerSecret;

    //    TwitterAcount.twitterService = new TwitterService(twitterClientInfo);

    //    TwitterAcount.requestToken = TwitterAcount.twitterService.GetRequestToken();
    //    authUrl = TwitterAcount.twitterService.GetAuthorizationUrl(TwitterAcount.requestToken);

    //    authUrl = Page.ResolveClientUrl(authUrl);
    //    ButtonGetPin.OnClientClick = "window.open('" + authUrl + "'); return false;";
    //}

    private void CreateAuthUrl()
    {
        requestToken = twitterService.GetRequestToken();
        authUrl = twitterService.GetAuthorizationUrl(requestToken);

        authUrl = Page.ResolveClientUrl(authUrl);
    }

}