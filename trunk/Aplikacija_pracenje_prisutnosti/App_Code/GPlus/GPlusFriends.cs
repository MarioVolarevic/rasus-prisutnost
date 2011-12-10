using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP;
using agsXMPP.protocol.client;

/// <summary>
/// Summary description for GPlusFriends
/// </summary>
public class GPlusFriends
{
    XmppClientConnection xmppConn;
    List<string> allFriendsList = new List<string>();
    List<string> activeFriendsList = new List<string>();
    //Dictionary<string, string> activeFriendsList = new Dictionary<string, string>();
    static private GPlusFriends instance;

    private GPlusFriends(string UserName, string Password)
    {
        //GPlusLoginStatus.LoggedIn = true;
        xmppConn = new XmppClientConnection();
        Login(UserName, Password);
    }
    public static GPlusFriends CreateInstance(string UserName, string Password)
    {
        if (instance == null)
        {
            instance = new GPlusFriends(UserName, Password);
            return instance;
        }
        else return instance;
    }

    public List<string> GetActiveFriends()
    {
        return activeFriendsList;
    }
    public List<string> GetAllFriends()
    {
        return allFriendsList;
    }

    private void initUserRcvHandlers()
    {
        xmppConn.OnRosterItem += new XmppClientConnection.RosterHandler(xmppConn_OnRosterItem);
        xmppConn.OnPresence += new PresenceHandler(xmppConn_OnPresence);
    }

    void xmppConn_OnPresence(object sender, Presence pres)
    {
        activeFriendsList.Add(pres.From.Bare + ";" + pres.Show.ToString() + ";" + pres.Status + ";" + pres.Type.ToString());
        //activeFriendsList.Add(pres.From.Bare, pres.Show.ToString() + ";" + pres.Status + ";" + pres.Type.ToString());
    }

    void xmppConn_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
    {
        allFriendsList.Add(item.Name + ";" + item.Jid.Bare);
    }
    private void Login(string UserName, string Password)
    {
        Jid jid = new Jid(UserName);
        xmppConn.Username = jid.User;
        xmppConn.Server = jid.Server;
        xmppConn.Password = Password;
        xmppConn.ConnectServer = "talk.google.com";
        xmppConn.AutoResolveConnectServer = true;
        xmppConn.OnLogin += new ObjectHandler(xmppConn_OnLogin);
        xmppConn.Open();
    }

    private ShowType show;
    private string statusMessage;
    public void SetStatus(ShowType Show, string StatusMessage)
    {
        show = Show;
        statusMessage = StatusMessage;
        Presence p = new Presence(Show, StatusMessage, 24);
        xmppConn.Send(p);
    }

    void xmppConn_OnLogin(object sender)
    {
        initUserRcvHandlers();
    }
    public void ClearActiveList()
    {
        //activeFriendsList.Clear();
        xmppConn.SendMyPresence();
    }
    public static GPlusFriends CreateInstance()
    {
        return instance;
    }
}
