using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook_Graph_Toolkit;
using Facebook_Graph_Toolkit.GraphApi;
using Facebook_Graph_Toolkit.FacebookObjects;
using JSON;

namespace FacebookLibrary
{
    public static class FacebookClient
    {

        public static List<FacebookTable> Connect(Api Api, string userID)
        {
            string query = "SELECT name FROM user WHERE online_presence IN ('active', 'idle') AND uid IN (SELECT uid2 FROM friend WHERE uid1 =" + userID + ")";
            JsonArray result = Api.Fql(query);
            try
            {
                List<string> friendsName = ParseUserFriends(result);
                List<FacebookTable> onlineFriends = new List<FacebookTable>();
                foreach (string name in friendsName)
                {
                    onlineFriends.Add(new FacebookTable(name, " is online"));
                }
                return onlineFriends;
            }
            catch 
            {
                return new List<FacebookTable>();    
            }
            
        }

        static List<string> ParseUserFriends(JsonArray result)
        {
            string[] splitResult = result.ToString().Split(',');
            List<string> userFriends = new List<string>();
            for (int i = 0; i < splitResult.Count(); i++) 
            {
                if (i == 0) 
                {
                    splitResult[i] = splitResult[i].Remove(0, 10);
                    splitResult[i] = splitResult[i].Remove(splitResult[i].Length - 2, 2);
                }
                else if (i == splitResult.Count() - 1)
                {
                    splitResult[i] = splitResult[i].Remove(0, 9);
                    splitResult[i] = splitResult[i].Remove(splitResult[i].Length - 3, 3);
                }
                else 
                {
                    splitResult[i] = splitResult[i].Remove(0, 9);
                    splitResult[i] = splitResult[i].Remove(splitResult[i].Length - 2, 2);
                }
                userFriends.Add(splitResult[i]);
            }
            return userFriends;
        }
    }
}