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
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonGetPin_Click(object sender, EventArgs e)
    {
        TwitterClientInfo twitterClientInfo = new TwitterClientInfo();
        twitterClientInfo.ConsumerKey = TwitterAcount.ConsumerKey;
        twitterClientInfo.ConsumerSecret = TwitterAcount.ConsumerSecret;

        TwitterAcount.twitterService = new TwitterService(twitterClientInfo);

        TwitterAcount.requestToken = TwitterAcount.twitterService.GetRequestToken();
        string authUrl = TwitterAcount.twitterService.GetAuthorizationUrl(TwitterAcount.requestToken);

        Process.Start(authUrl);
    }

    protected void ButtonAuthorize_Click(object sender, EventArgs e)
    {
        TwitterAcount.accessToken = TwitterAcount.twitterService.GetAccessToken(TwitterAcount.requestToken, this.TextBoxPin.Text);
        TwitterAcount.twitterService.AuthenticateWith(TwitterAcount.accessToken.Token, TwitterAcount.accessToken.TokenSecret);
        TwitterAcount.logedIn = true;
        
        Page.Response.Redirect(@"~\TwitterTable.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        if (GPlusFriends.CreateInstance() != null)
            Page.Response.Redirect(@"~\GPlusTable.aspx");
        else
            Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
}