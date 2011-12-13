using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookLibrary
{
    public class FacebookTable
    {
        string name;
        string fbStatus;

        public FacebookTable(string result) 
        {
            name = result;
        }

        public FacebookTable(string name, string response) 
        {
            this.name = name;
            this.fbStatus = response;
        }

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public string FBStatus
        {
            get { return fbStatus.ToString(); }
        }

    }
}