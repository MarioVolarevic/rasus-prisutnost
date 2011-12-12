using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agsXMPP.protocol.client;

/// <summary>
/// Summary description for GFriend
/// </summary>
public class GFriend
{
    public string FullName;
    public string BareName;
    public ShowType Availability; //NONE je online, dnd je busy itd.    
    public string StatusMessage;
    public PresenceType OnOff;

    public GFriend(string fName, string bareName)
    {
        this.FullName = fName;
        this.BareName = bareName;
    }
}
