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

/// <summary>
/// Summary description for TwitterAcount
/// </summary>
public class TwitterAppInfo
{
	public TwitterAppInfo()
	{
	}

    public static string ConsumerSecret
    {
        get { return "0KFxhhapnscNrmjFs0nJxZn5XhpNzUmRVSdPKhphd6U"; }
    }

    public static string ConsumerKey
    {
        get { return "NurbulMLmW3cY9wTovQgBQ"; }
    }

    public static TwitterClientInfo ClientInfo
    {
        get 
        {
            TwitterClientInfo twitterClientInfo = new TwitterClientInfo();
            twitterClientInfo.ConsumerKey = TwitterAppInfo.ConsumerKey;
            twitterClientInfo.ConsumerSecret = TwitterAppInfo.ConsumerSecret;
            return twitterClientInfo;
        }
    }

}