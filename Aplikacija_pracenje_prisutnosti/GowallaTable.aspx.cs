﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gowalaWarp2;
using Facebook_Graph_Toolkit.Helpers;

public partial class GowallaTable : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
           
        //Ukoliko za korisnika nije stvorena sjednica, odnosno on nije prijavljen
        //preusmjerava ga se na ~\GowallaLogIn.aspx
        if (Session["GowallaUsername"] == null || Session["GowallaPassword"] == null)
        {                                      
                Response.Redirect(@"~\GowallaLogIn.aspx");           
        }
        /*Svaki put kad kliknete na neki od gumbića (Twitter, Gplus...) napravite POST zahtjev na trenutnu
         * stranicu na kojoj se nalazite. Ako imate učitavanje podataka - kao što ja imam ovo dolje, to znači da 
         * će vam se ponovno učitavati podaci PRIJE nego se pokrene npr. ImageButtonTwitter_Click. To znači 
         * nepotrebno čekanje prije preusmjeravanja na Twitter dio. Zato sam dodao ovo if (Page.IsPostBack == false)
         * Na twitteru i G+u se događa ista stvar pa, iako se kod njih radi o 1 sekundi koju ušparamo, kod mene je
         * riječ o 20-tak ušparanih sekundi. :) */
        if (Page.IsPostBack == false)
        {
            //ukoliko je već stvorena sjednica, imamo korisnikove podatke te se prijavljujemo
            //na Gowallin poslužitelj i dohvaćamo podatke
            Gowalla user = new Gowalla(Session["GowallaUsername"].ToString(), Session["GowallaPassword"].ToString());
            List<Friend> friends = user.CatchFriends();
            
            string everything = "";
            foreach (Friend oneFriend in friends)
            {
                everything += oneFriend.firstName + " ";
                everything += oneFriend.lastName + " ";
                everything += oneFriend.alias + " ";
                everything += oneFriend.LastCheckin + " ";                
                ListBoxGowalla.Items.Add(everything);
                everything = "";
            }

           

        }

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
    protected void ImageButtonFacebook_Click(object sender, ImageClickEventArgs e)
    {
        IframeHelper.IframeRedirect("", true, true);

    }
}