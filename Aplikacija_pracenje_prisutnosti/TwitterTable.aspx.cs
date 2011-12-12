﻿using System;
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

public partial class _Default : System.Web.UI.Page 
{
    TwitterService twitterService = new TwitterService(TwitterAppInfo.ClientInfo);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TwitterAccessToken"] == null)
        {
            Response.Redirect(@"~\TwitterLogIn.aspx");
        }
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
        twitterService.SendTweet(TextBoxNewTweet.Text);
    }

    protected void refreshFriendTweets()
    {
        IEnumerable<TwitterStatus> tweets = twitterService.ListTweetsOnFriendsTimeline();
        foreach (TwitterStatus tweet in tweets)
        {
            ListBoxTweets.Items.Add("[" + tweet.CreatedDate + "] --> " + tweet.User.ScreenName + " says: " + tweet.Text + ".");
        }
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        //if (GPlusFriends.CreateInstance() != null)
            Page.Response.Redirect(@"~\GPlusTable.aspx");
        //else
        //    Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
}