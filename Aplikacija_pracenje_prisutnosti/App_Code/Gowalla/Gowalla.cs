using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;
using System.Threading;
namespace gowalaWarp2
{  
    public enum authentication
    {
        required,notRequired
    };
   
    public class Gowalla
    {
        const int STUPID_DELAY = 1001;
        static readonly string key = "5035f27dc85a407190c3cb290f71a724";
        string firstName; //user
        string lastName;
        Image avatar;
        bool status = true;
        string userName;
        string passWord;       
        string alias;
        public List<Friend> friends = new List<Friend>();
      
        
        //Stvaranje objekta za novog korisnika i prijavljivanje na Gowallu
        public Gowalla(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
                    
            string result = fetchBasicUserData(authentication.required);         
        }
        
        //Metoda dohvaća popis svih prijatelja te 
        //poziva metodu fetchFriendData nad svakim prijateljem
        //kako bi dohvatila njihove podatke
        public List<Friend> CatchFriends()
        {
            #region Load HTML with informations and filter users
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://gowalla.com/users/"+this.alias+"/followings");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader read = new StreamReader(resp.GetResponseStream());
            String oneLine;            
            List<string> alias = new List<string>();
           
            while ((oneLine = read.ReadLine() )!= null)
            {
                if (oneLine.Contains("user-link primary-link"))
                {
                    alias.Add(oneLine.Split('/')[2].Split('"')[0]);                   
                }                
            }
           
          
            #endregion
           
            for(int i = 0;i<alias.Count();i++)
            {                
                friends.Add(fetchFriendData(authentication.required, alias[i]));
            }
            return friends;
            
        }

        //Metoda koja kreira HTTP zahtjev 
        //prima URL traženog resursa te enumerator  koji
        //odredjuje da li je potrebna ovjera
        public HttpWebRequest createRequest(string url, authentication aut)
        {
           
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (aut == authentication.required)
                {
                    request.Credentials = new NetworkCredential(userName, passWord);
                    request.Headers.Add("Authorization", "Basic" + Convert.ToBase64String(new ASCIIEncoding().GetBytes(userName + passWord)));
                }
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Headers.Add("X-Gowalla-API-Key:" + Gowalla.key);
                return request;
            }
            catch (WebException e)
            {
                status = false;
            }

            return null;
        }

        //Metoda dohvaća za određenog prijatelja ime
        //prezime, alias te vrijeme zadnjeg Checkina
        private Friend fetchFriendData(authentication aut, string alias)
        {
            Friend newFriend = new Friend(null, null);
            StreamReader reader = null;
            string result = "";
            String stampsURL = null;

            HttpWebRequest request = createRequest("http://api.gowalla.com/users/" + alias.Replace(" ", ""), aut);
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
            }
            catch (System.Net.WebException e)
            {

                status = false;
            }


            
            string[] data = result.Split(',');

            IEnumerable<string> rez = data.Where(delegate(String row)
            {
                return (row.Contains("first_name") || row.Contains("last_name") ||
                        row.Contains("stamps_url"));
            });


            if (rez.Count() == 3)
            {
                newFriend.firstName = rez.ElementAt(2).Split('"')[3];
                newFriend.lastName = rez.ElementAt(1).Split('"')[3];
                stampsURL = rez.ElementAt(0).Split('"')[3];
                newFriend.alias = alias;
                newFriend.lastCheckin = lastCheckin(stampsURL, aut);
                return newFriend;
            }
            else if (rez.Count() == 2)
            {
                newFriend.firstName = rez.ElementAt(1).Split('"')[3];
                newFriend.lastName = rez.ElementAt(0).Split('"')[3];               
                newFriend.alias = alias;                
                return newFriend;

            }
            else return newFriend;
            
            
            //String imUrl = data.First(x=>x.Contains("image_url")).Split('"')[3];
            //Stream imageStream = getResource(imUrl);
            //newFriend.avatar = Image.FromStream(imageStream);

            
        }

        //Metoda koja preko URL-a dohvaća zadnji Checkin
        private DateTime lastCheckin(string url, authentication aut)
        {
            HttpWebRequest request = createRequest("http://api.gowalla.com" + url, aut);

            StreamReader reader;
            String rightLine = null;
            int stopWatch = 0;
            TryLabel2:
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    reader = new StreamReader(response.GetResponseStream());
                    String[] allLines = reader.ReadToEnd().Split(',');
                    foreach (String oneLine in allLines)
                    {
                        if (oneLine.Contains("last_checkin_at"))
                        {
                            rightLine = oneLine;
                            break;
                        }

                    }
                }
            }
            catch(WebException  e)
            {
                if (stopWatch < 10)
                {
                    stopWatch++;
                    Thread.Sleep(STUPID_DELAY);
                    goto TryLabel2;
                }
            }
            if (rightLine == null)
            {
                return DateTime.MinValue;
            }
            String timeString = rightLine.Split('"')[3];
            

            String[] ymRest = timeString.Split('-');
            int year = (int.Parse(ymRest[0]));
            int month = (int.Parse(ymRest[1]));
            int day = (int.Parse(ymRest[2].Split('T')[0]));
            String[] timeHMS = ymRest[2].Split('T')[1].Split(':');
            int hour = (int.Parse(timeHMS[0]));
            int minute = (int.Parse(timeHMS[1]));
            int second = int.Parse(timeHMS[2].ElementAt(0).ToString() + timeHMS[2].ElementAt(1).ToString());

            DateTime time = new DateTime(year, month, day, hour, minute, second);
            return time;
        }
        


        //Dohvaćanje osnovnih korisničkih podataka
        //kao što su ime, prezime, alias (korisničko ime)...
        private string fetchBasicUserData(authentication aut)
        {
            HttpWebRequest request = createRequest("http://api.gowalla.com/users/me", aut);
            int stopWatch = 0;
            TryLabel3:
            try
            {
           
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string result = reader.ReadToEnd();
                    String[] data = result.Split(',');

                    //string imUrl = data.First(x => x.Contains("image_url"));
                    //imUrl = imUrl.Split('"')[3];
                    //Stream imageStream = getResource(imUrl);
                    //this.avatar = Image.FromStream(imageStream);

                    this.firstName = data.First(x => x.Contains("first_name")).Split('"')[3];
                    this.lastName = data.First(x => x.Contains("last_name")).Split('"')[3];
                    this.alias = data.First(x => x.Contains("username")).Split('"')[3];
                    return result.Replace(',', '\n');
                }
              //  return "jes";
                
            }
            catch (System.Net.WebException e)
            {                
                if (stopWatch < 10)
                {
                    stopWatch++;
                    Thread.Sleep(STUPID_DELAY);
                    goto TryLabel3;
                }
                else
                {
                    status = false;
                    return "greška";
                }            
            }
        }

        public bool Status
        {
            get
            {
                return this.status;
            }
        }

        //Metoda koja preko URL dohvaća resurs (točnije sliku)
        //Avatari se u ovom programu ne koriste.
        private Stream getResource(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            return resp.GetResponseStream();
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
        }
        public Image Avatar
        {
            get
            {
                return avatar;
            }
        }

    }

   

}
