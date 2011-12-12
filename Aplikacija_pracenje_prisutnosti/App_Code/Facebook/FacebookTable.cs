using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookLibrary
{
    public class FacebookTable
    {
        string name;
        string lastname;
        string fbStatus;

        public FacebookTable(string result) 
        {
            name = result;
        }

        public FacebookTable(string name, string response) 
        {
            this.name = name;
            //this.lastname = lastname;
            this.fbStatus = fbStatus;
            if (response.Contains("offline")) 
            {
                fbStatus = "offline";    
            }
            if (response.Contains("active")) 
            {
                fbStatus = "active";
            }
            if (response.Contains("idle")) 
            {
                fbStatus = "idle";
            }
            if (response.Contains("null")) 
            {
                fbStatus = "unknown";
            }
 
        }

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        //public string LastName
        //{
        //    get { return lastname; }
        //    set { lastname = value; }
        //}

        public string FBStatus
        {
            get { return fbStatus.ToString(); }
        }

    }
}