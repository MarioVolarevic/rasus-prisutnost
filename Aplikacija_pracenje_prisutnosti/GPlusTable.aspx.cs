using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GPlusTable : System.Web.UI.Page 
{
    private GPlusFriends gPlusFriends;

    protected void Page_Load(object sender, EventArgs e)
    {
        gPlusFriends = GPlusFriends.CreateInstance();
        //gPlusFriends.ClearActiveList();
        List<string> l = gPlusFriends.GetActiveFriends();
        //boxActiveFriends.ClearSelection();
        foreach (string s in l)
        {
            boxActiveFriends.Items.Add(s);
        }
        //actFriendsBox.ClearSelection();
        //foreach (string s in l)
        //{
        //    actFriendsBox.Items.Add(s);
        //}
        //gPlusFriends.ClearActiveList();
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
        if (GPlusFriends.CreateInstance() != null)
            Page.Response.Redirect(@"~\GPlusTable.aspx");
        else
            Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
}