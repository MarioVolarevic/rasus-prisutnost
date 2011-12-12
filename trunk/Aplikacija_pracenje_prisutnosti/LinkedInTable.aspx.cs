using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Attassa;
using System.Xml;
using System.Xml.XPath;
using Facebook_Graph_Toolkit.Helpers;



public partial class _Default : System.Web.UI.Page 
{
    static int a = 0;
   
    //private OAuthLinkedIn _oauth = new OAuthLinkedIn();
    protected void Page_Load(object sender, EventArgs e)
    {
        string previousUrl="";
        if(Request.UrlReferrer!=null)
            previousUrl=Request.UrlReferrer.AbsolutePath;
        if (previousUrl.CompareTo("/Aplikacija_pracenje_prisutnosti/LinkedInTable.aspx")!=0)
        {


            string queryParams = HttpContext.Current.Request.Url.Query;
            string _token = null;
            string _verifier = null;
            if (queryParams.Length > 0)
            {
                //Store the Token and Token Secret
                NameValueCollection qs = HttpUtility.ParseQueryString(queryParams);
                if (qs["oauth_token"] != null)
                {
                    _token = qs["oauth_token"];
                }
                if (qs["oauth_verifier"] != null)
                {
                    _verifier = qs["oauth_verifier"];
                }
                OAuthObject._oauth.Token = _token;
                OAuthObject._oauth.Verifier = _verifier;
                String accessToken = OAuthObject._oauth.getAccessToken();
            }

            ListBox1.Items.Clear();
            List<Person> osobe = GetAllConections();
            int num = 0;
            if (osobe != null)
                num = osobe.Count;
            for (int i = 0; i < num; i++)
            {
                ListBox1.Items.Add(Status(osobe.ElementAt(i).name, osobe.ElementAt(i).surname));
            }
        }

    }

    private string Status(string name, string surname)
    {
        List<Person> people = GetAllConections();
        Person person = people.Find(delegate(Person p) { return p.name.Equals(name) && p.surname.Equals(surname); });
        XmlDocument status = new XmlDocument();
        status.LoadXml(OAuthObject._oauth.APIWebRequest("GET", "http://api.linkedin.com/v1/people/id=" + person.id + ":(current-share)", null));
        //XmlNode root=status.DocumentElement;
        XmlNode timestamp=status.SelectSingleNode("//timestamp");
        XmlNode statusText = status.SelectSingleNode("//comment");
        double seconds = Convert.ToDouble(timestamp.InnerText)/1000;
        DateTime postDate=new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(seconds);
        //Button1_Click(null,null);
        return "[" + postDate.ToLongDateString() + "] --> " +name+" "+surname+" " + " says: " + statusText.InnerText + "."; 
           // postDate.ToLongDateString()+" "+name+" "+surname+" "+statusText.InnerText;
    }

    private List<Person> GetAllConections()
    {
        try
        {
            
            XmlDocument connections = new XmlDocument();
            connections.LoadXml(OAuthObject._oauth.APIWebRequest("GET", "http://api.linkedin.com/v1/people/~/connections", null));
            connections.Save(Console.Out);
            XmlNode root = connections.DocumentElement;
            XmlNodeList listOfPersonElements = root.SelectNodes("/connections/person");
            List<Person> persons = new List<Person>();

            foreach (XmlNode node in listOfPersonElements)
            {
                XmlNodeList listOfPersonAttributes = node.SelectNodes("//person/*");
                Person p = new Person(listOfPersonAttributes.Item(0).InnerText, listOfPersonAttributes.Item(1).InnerText, listOfPersonAttributes.Item(2).InnerText);
                persons.Add(p);
                //Console.Write("*" + _oauth.APIWebRequest("GET", "http://api.linkedin.com/v1/people/id=" + node.InnerText, null) + "*");
            }
            return persons;
        }
        catch (Exception exp)
        {
            //txtOutput.Text += "\nException: " + exp.Message;
            return null;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xml += "<current-status>" + "josip" + "</current-status>";

            string response = OAuthObject._oauth.APIWebRequest("PUT", "http://api.linkedin.com/v1/people/~/current-status", xml);
            if (response == "")
                TextBox1.Text += "\nYour new status updated.  view linkedin for status.";
        }
        catch (Exception exp)
        {
            TextBox1.Text += "\nException: " + exp.Message;
        }
    }

    protected void ImageButtonGowalla_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(@"~\GowallaTable.aspx");
    }

    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~\TwitterTable.aspx");
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {
        //if (GPlusFriends.CreateInstance() != null)
        Response.Redirect(@"~\GPlusTable.aspx");
        //else
        //    Page.Response.Redirect(@"~\GPlusLogIn.aspx");
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        IframeHelper.IframeRedirect("", true, true);
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        ListBox1.Items.Clear();
        List<Person> osobe = GetAllConections();
        int num = 0;
        if (osobe != null)
            num = osobe.Count;
        for (int i = 0; i < num; i++)
        {
            ListBox1.Items.Add(Status(osobe.ElementAt(i).name, osobe.ElementAt(i).surname));
        }
    }
}