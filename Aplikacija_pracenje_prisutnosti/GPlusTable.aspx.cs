using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Facebook_Graph_Toolkit.Helpers;

public partial class GPlusTable : System.Web.UI.Page
{
    EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);
    private GPlusFriends gPlusFriends;
    private List<GFriend> friends;
    string username;
    string password;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GUname"] == null || Session["GPass"] == null)
        {
            Response.Redirect(@"~\GPlusLogIn.aspx");
        }
        else
        {
            username = Session["GUname"].ToString();
            password = Session["GPass"].ToString();
            gPlusFriends = new GPlusFriends(username, password);
            gPlusFriends.eventWaitH = ewh;
            //dretva nastavlja dalje kada stigne odgovor o uspjesnom ili nesupjesnom prijavljivanju
            ewh.WaitOne();
            if (Session["Error"].ToString() == "DA")
                Response.Redirect(@"~\GPlusLogIn.aspx");
        }

        if (gPlusFriends.GetAllFriends().Count == 0)
        {
            //ako lista prijatelja nije dohvacena onda se ceka dok nije garantirano da je stigla sa zavrsetkom RosterEnd
            ewh.WaitOne(10000);
        }
        //ceka se na obradu bar jednog presence paketa
        ewh.WaitOne(10000);
        for (int i = 0; i < gPlusFriends.GetAllFriends().Count; i++)
        {
            //ceka se na obradu ostalih presence paketa, ceka se i vise nego sto je potrebno, ali ne previse
            ewh.WaitOne(30);
        }

        boxActiveFriends.Items.Clear();
        //jos malo cekanja za svaki slucaj, ako je negdje nesto zapelo
        ewh.WaitOne(100);
        friends = gPlusFriends.GetAllFriends();
        if (friends.Count != 0)
            for (int i = 0; i < friends.Count; i++)
            {
                //formatiranje ispisa ovisno o statusu
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
                    fullOutput += cF.StatusMessage;
                    boxActiveFriends.Items.Add(fullOutput);
                }
            }
        else
        {
            boxActiveFriends.Items.Add("Nemate Prijatelja");
        }

    }


    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\TwitterTable.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~\GPlusTable.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        IframeHelper.IframeRedirect("", true, true);
    }

    protected void StatusButton_Click(object sender, EventArgs e)
    {
        //postavljanje vlastitog statusa
        string statusMessage = BoxStatusMessage.Text;
        if (AvailList.SelectedValue == "Busy")
            gPlusFriends.SetStatus(agsXMPP.protocol.client.ShowType.dnd, statusMessage);
        else if (AvailList.SelectedValue == "Online")
            gPlusFriends.SetStatus(agsXMPP.protocol.client.ShowType.NONE, statusMessage);
    }

    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");
    }
    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GowallaTable.aspx");

    }
}