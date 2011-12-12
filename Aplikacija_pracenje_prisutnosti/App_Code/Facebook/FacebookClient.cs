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
            IList<NameIDPair> userFriends = new List<NameIDPair>();
            userFriends = Facebook_Graph_Toolkit.GraphApi.User.GetFriends(userID, Api.AccessToken);
            //string friendsQuery = "SELECT uid2 FROM friend WHERE uid1== " + userID;
            //JsonArray friendsResult = Api.Fql(friendsQuery);
            
            //List<string> userFriends = new List<string>();
            //userFriends = ParseUserFriends(friendsResult);
            List<FacebookTable> onlineFriends = new List<FacebookTable>();
            foreach (NameIDPair friend in userFriends)
            {
                try
                {
                    //Facebook_Graph_Toolkit.GraphApi.User user = new Facebook_Graph_Toolkit.GraphApi.User(friend.ID, Api.AccessToken);
                    string query = "SELECT online_presence FROM user WHERE uid== " + friend.ID;
                    JsonArray result = Api.Fql(query);
                    if (result.ToString().Contains("active") || result.ToString().Contains("idle"))
                    {
                        onlineFriends.Add(new FacebookTable(friend.Name,result.ToString()));
                    }
                }
                catch
                {
                    //Label1.Text = friend.ID + "," + Api.AccessToken;
                    return onlineFriends;
                }
                //
            }
            return onlineFriends;
                     
        }

        static List<string> ParseUserFriends(JsonArray result)
        {
            string[] splitResult = result.ToString().Split(',');
            List<string> userFriends = new List<string>();
            for (int i = 0; i < splitResult.Count(); i++) 
            {
                if (i == 0) 
                {
                    splitResult[i] = splitResult[i].Remove(0, 11);
                    splitResult[i] = splitResult[i].Remove(splitResult[i].Length - 2, 2);
                }
                else if (i == splitResult.Count() - 1)
                {
                    splitResult[i] = splitResult[i].Remove(0, 2);
                    splitResult[i] = splitResult[i].Remove(splitResult[i].Length - 4, 4);
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