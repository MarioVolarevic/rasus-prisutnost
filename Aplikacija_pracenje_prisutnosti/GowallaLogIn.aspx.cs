using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gowalaWarp2;
using Facebook_Graph_Toolkit.Helpers;

public partial class GowallaLogIn : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {              

    }

    protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
    {       
            Page.Response.Redirect(@"~\TwitterTable.aspx");      
    }
    protected void ImageButtonGoogle_Click(object sender, ImageClickEventArgs e)
    {       
            Page.Response.Redirect(@"~\GPlusTable.aspx");       
    }
    protected void ImageButtonLinkedIn_Click(object sender, ImageClickEventArgs e)
    {       
        Page.Response.Redirect(@"~\LinkedInLogIn.aspx");     
    }

    //Nakon upisa korisničkog imena i lozinke i pritiska na gumb Log in
    //pokreće se ova metoda.
    //Ukoliko su podaci točni stvara se nova sjednica sa upisanim podacima te
    //se korisnik preusmjerava na stranicu ~\GowallaTable.aspx
    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        string user = TextBoxUsername.Text + TextBoxPassword.Text;

        Gowalla newUser = new Gowalla(TextBoxUsername.Text, TextBoxPassword.Text);
        if (newUser.Status == false)
        {
            LabelError.Text = "Wrong username and/or password";
        }
        else
        {
          
            Session["GowallaUsername"] = TextBoxUsername.Text;
            Session["GowallaPassword"] = TextBoxPassword.Text;
            Response.Redirect(@"~\GowallaTable.aspx");
        }              
    }
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        IframeHelper.IframeRedirect("", true, true);
    }
}