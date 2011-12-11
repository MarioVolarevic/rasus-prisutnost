using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Attassa;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        OAuthObject._oauth = new OAuthLinkedIn();
        String requestToken = OAuthObject._oauth.getRequestToken();
        Page.Response.Redirect(OAuthObject._oauth.AuthorizationLink);
    }
    
    protected void LogInButtonClick(object sender, EventArgs e)
    {
        
    }
}