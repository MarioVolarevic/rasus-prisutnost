﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class GPlusTable : System.Web.UI.Page
{
    EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);
    private GPlusFriends gPlusFriends;
    private List<GFriend> friends;
    //private bool prviPut;
    string username;
    string password;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (gPlusFriends == null && Session["FromPage"].ToString() != "GPlusLogIn")
            Response.Redirect(@"~\GPlusLogIn.aspx");
        //gPlusFriends = GPlusFriends.CreateInstance();
        if (gPlusFriends == null)
        {
            username = Session["Uname"].ToString();
            password = Session["Pass"].ToString();
            gPlusFriends = new GPlusFriends(username, password);
        }
        gPlusFriends.eventWaitH = ewh;
        //GPlusFriends.eventWaitH = ewh;
        
        if (gPlusFriends.GetAllFriends().Count == 0)
            ewh.WaitOne();
        ewh.WaitOne();
        for (int i = 0; i < gPlusFriends.GetAllFriends().Count; i++)
        {
            ewh.WaitOne(100); 
        }

        //boxActiveFriends.DataSource = null;
        boxActiveFriends.Items.Clear();
        ewh.WaitOne(100);
        friends = gPlusFriends.GetAllFriends();

        for (int i = 0; i < friends.Count; i++)
        {
            GFriend cF = friends[i];
            string fullOutput = "";
            if (cF.FullName == null)
                fullOutput += cF.BareName;
            else
                fullOutput += cF.FullName;

            if (cF.OnOff == agsXMPP.protocol.client.PresenceType.available)
            {
                if (cF.Availability == agsXMPP.protocol.client.ShowType.NONE)
                {
                    fullOutput += " (Online): ";
                }
                else if (cF.Availability == agsXMPP.protocol.client.ShowType.dnd)
                {
                    fullOutput += " (Busy): ";
                }
                else if (cF.Availability == agsXMPP.protocol.client.ShowType.away || cF.Availability == agsXMPP.protocol.client.ShowType.xa)
                {
                    fullOutput += " (Away): ";
                }
                else if (cF.Availability == agsXMPP.protocol.client.ShowType.chat)
                {
                    fullOutput += " (Chatting): ";
                }
            }
            else
            {
                fullOutput += " (Offline): ";
            }
            fullOutput += cF.StatusMessage;
            boxActiveFriends.Items.Add(fullOutput);
        }

        //if (IsPostBack)
        //    Response.Redirect(Request.RawUrl);

        //if (prviPut)
        //{
        //    prviPut = false;
        //    ewh.WaitOne(1000);
        //    Response.Redirect(Request.RawUrl);
        //}
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
        Response.Redirect(@"~\GPlusTable.aspx");
        //else
        //    Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~\Default.aspx");
    }
    protected void StatusButton_Click(object sender, EventArgs e)
    {
        string statusMessage = BoxStatusMessage.Text;
        if (AvailList.SelectedValue == "Busy")
            gPlusFriends.SetStatus(agsXMPP.protocol.client.ShowType.dnd, statusMessage);
        else if (AvailList.SelectedValue == "Online")
            gPlusFriends.SetStatus(agsXMPP.protocol.client.ShowType.NONE, statusMessage);
    }
}