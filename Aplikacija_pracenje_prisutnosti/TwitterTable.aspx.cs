using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetSharp;
using TweetSharp.Model;
using TweetSharp.Twitter.Model;
using TweetSharp.Twitter.Service;
using Facebook_Graph_Toolkit.Helpers;

public partial class _Default : System.Web.UI.Page 
{
    TwitterService twitterService = new TwitterService(TwitterAppInfo.ClientInfo);

    protected void Page_Load(object sender, EventArgs e)
    {
        // prvo provjeravamo postoji li pristupni token u sesijskoj varijabli
        // ukoliko ne postoji preusmjeravamo korisnika na logIn stranicu
        if (Session["TwitterAccessToken"] == null)
        {
            Response.Redirect(@"~\TwitterLogIn.aspx");
        }
        // inače autoriziramo aplikaciju
        else
        {
            OAuthToken accessToken = (OAuthToken)Session["TwitterAccessToken"];
            twitterService.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            ListBoxTweets.Items.Clear();
            refreshFriendTweets();
        }
    }

    protected void ButtonPostNewTweet_Click(object sender, EventArgs e)
    {
        // postavljanje novog tweeta
        twitterService.SendTweet(TextBoxNewTweet.Text);
    }

    protected void refreshFriendTweets()
    {
        // dohvaćanje tweetova prijatelja i sortiranje po vremenu stvaranja
        IEnumerable<TwitterStatus> tweets = twitterService.ListTweetsOnFriendsTimeline();
        foreach (TwitterStatus tweet in tweets)
        {
            ListBoxTweets.Items.Add("[" + tweet.CreatedDate + "] --> " + tweet.User.ScreenName + " says: " + tweet.Text + ".");
        }
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GPlusTable.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        IframeHelper.IframeRedirect("", true, true);
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