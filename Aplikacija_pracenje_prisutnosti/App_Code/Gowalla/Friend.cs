using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace gowalaWarp2
{
    public class Friend
    {
        public string firstName;
        public string lastName;
        public string alias;
        public Image avatar;
        public DateTime lastCheckin;

        public Friend(string fN, string lN) 
        {
            this.firstName = fN;
            this.lastName = lN;
        }

        public string FirstName
        {
            get{return firstName;}
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }

        public string Alias
        {
            get { return alias; }
            set { this.alias = value; }
        }

        public DateTime LastCheckin
        {
            get { return lastCheckin; }
            set { lastCheckin = value; }
        }

    }
}
