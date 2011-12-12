using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP;
using agsXMPP.protocol.client;



/// <summary>
/// Summary description for GPlusFriends
/// </summary>
public class GPlusFriends : System.Web.UI.Page
{
    XmppClientConnection xmppConn;
    List<GFriend> allFriendsList = new List<GFriend>();

    //Dictionary<string, string> activeFriendsList = new Dictionary<string, string>();
    //static private GPlusFriends instance;

    public System.Threading.EventWaitHandle eventWaitH;    
    public GPlusFriends(string UserName, string Password)
    {
        //GPlusLoginStatus.LoggedIn = true;
        xmppConn = new XmppClientConnection();
        Login(UserName, Password);
    }
    //public static GPlusFriends CreateInstance(string UserName, string Password)
    //{
    //    if (instance == null)
    //    {
    //        instance = new GPlusFriends(UserName, Password);
    //        return instance;
    //    }
    //    else return instance;
    //}

    public List<GFriend> GetAllFriends()
    {
        return allFriendsList;
    }

    private void initUserRcvHandlers()
    {
        xmppConn.OnRosterItem += new XmppClientConnection.RosterHandler(xmppConn_OnRosterItem);
        xmppConn.OnRosterEnd += new ObjectHandler(xmppConn_OnRosterEnd);
        xmppConn.OnPresence += new PresenceHandler(xmppConn_OnPresence);
    }

    void xmppConn_OnRosterEnd(object sender)
    {
        eventWaitH.Set();
    }

    void xmppConn_OnPresence(object sender, Presence pres)
    {
        for (int i = 0; i < allFriendsList.Count; i++)
        {
            GFriend curFriend = allFriendsList[i];
            if (curFriend.BareName == pres.From.Bare)
            {
                curFriend.Availability = pres.Show;
                curFriend.StatusMessage = pres.Status;
                curFriend.OnOff = pres.Type;
            }
        }
        eventWaitH.Set();
        //activeFriendsList.Add(pres.From.Bare + ";" + pres.Show.ToString() + ";" + pres.Status);
        //lb.Items.Add(pres.From.Bare + " " + pres.Show.ToString() + " " + pres.Status + " " + pres.Type.ToString());
        //activeFriendsList.Add(pres.From.Bare, pres.Show.ToString() + ";" + pres.Status + ";" + pres.Type.ToString());        
    }

    void xmppConn_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
    {
        allFriendsList.Add(new GFriend(item.Name, item.Jid.Bare));
        //allFriendsList.Add(item.Name + ";" + item.Jid.Bare);
    }
    private void Login(string UserName, string Password)
    {
        Session["Error"] = "NE";
        if (!UserName.Contains("@gmail.com"))
        {
            UserName += "@gmail.com";
        }
        Jid jid = new Jid(UserName);
        xmppConn.Username = jid.User;
        //xmppConn.Server = jid.Server;
        xmppConn.Server = "gmail.com";
        xmppConn.Password = Password;
        xmppConn.ConnectServer = "talk.google.com";
        xmppConn.AutoResolveConnectServer = true;
        xmppConn.OnAuthError += new XmppElementHandler(xmppConn_OnAuthError);
        xmppConn.OnLogin += new ObjectHandler(xmppConn_OnLogin);
        xmppConn.Open();
    }

    void xmppConn_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
    {
        Session["Error"] = "DA";
        eventWaitH.Set();
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
        Session["Error"] = "NE";
        eventWaitH.Set();
        initUserRcvHandlers();
    }
    //public void ClearActiveFriendsList()
    //{
    //    activeFriendsList.Clear();
    //    //xmppConn.SendMyPresence();
    //}
    //public static GPlusFriends CreateInstance()
    //{
    //    return instance;
    //}

    //System.Web.UI.WebControls.ListBox lb;
    //public void Attach(System.Web.UI.WebControls.ListBox listBox)
    //{
    //    lb = listBox;
    //}
}
