<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="LinkedInLogIn.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Calibri;
        }
        .style2
        {
            font-size: x-large;
        }
        .style4
        {
            font-size: medium;
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1" 
        
        
        
        
        style="height: 103px; color: #FFFFFF; width: 760px; text-align: center; background-color: #E2E2E2">
    
        <br />
        <asp:Image ID="Image1" runat="server" Height="72px" ImageUrl="~/Images/Logo.png" 
            Width="407px" style="text-align: center" />
        <br />
        <br />
    
        <br />
    
    </div>
    <div class="style2" 
        
        
        style="height: 93px; color: #789CEF; width: 760px; background-color: #EFEFEF; font-weight: 700; font-size: xx-small; text-align: center;">
        &nbsp;<span class="style4">Select Social Network: </span>&nbsp;<br />
        &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" 
            ImageUrl="~/Images/FacebookLogo.png" Width="30px" />
&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" 
            ImageUrl="~/Images/Google+Logo.png" Width="30px"  />
&nbsp;
        <asp:ImageButton ID="ImageButton3" runat="server" Height="30px" 
            ImageUrl="~/Images/TwitterLogo.png" Width="30px" />
&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton4" runat="server" Height="30px" 
            ImageUrl="~/Images/GowallaLogo.png" Width="30px" />
&nbsp;
        <asp:ImageButton ID="ImageButton5" runat="server" Height="30px" 
            ImageUrl="~/Images/LinkedInLogopngSelected.png" Width="30px" />
        <br />
        <hr />
    </div>
     <div class="style2" 
        
        
        style="height: 117px; color: #789CEF; width: 760px; background-color: #EFEFEF; font-weight: 700; font-size: medium; font-family: Calibri; text-align: center;">

         Username/Email:
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
         <br />
         Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
         <br />
         <asp:Button ID="Button1" runat="server" Height="24px" Text="Log In" 
             Width="108px" onclick="LogInButtonClick" />

    </div>
    </form>
<ul>

      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
    


      
      
    

  <li class="email-input">
      <label for="session_key-oauthAuthorizeForm">Email:</label>
      <div class="fieldgroup">
        <span class="error" id="session_key-oauthAuthorizeForm-error"></span>
        <input type="text" name="session_key" value="" id="session_key-oauthAuthorizeForm" autocorrect="off" autocapitalization="off" data-ime-mode-disabled="">
      </div>
  </li>
  <li class="password-input">
      <label for="session_password-oauthAuthorizeForm">Password:</label>
      <div class="fieldgroup">
        <span class="error" id="session_password-oauthAuthorizeForm-error"></span>
        <input type="password" name="session_password" value="" id="session_password-oauthAuthorizeForm" autocorrect="off" autocapitalization="off" maxlength="250">
        <a href="http://www.linkedin.com/passwordReset?trk=uas-resetpass">Forgot password?</a>
      </div>
  </li>

 <li id="duration" class="login">
 <label for="duration-oauthAuthorizeForm" class="duration-label">Access Duration:</label>
 <div class="fieldgroup">
 <span class="error" id="duration-oauthAuthorizeForm-error"></span>
 <p class="access">
 <strong>Until Revoked</strong> <a href="#" id="yui-gen1">change</a>

      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
    



   



  
  



  




  
    
  

 
 <script id="controlinit-1" type="text/javascript+initialized" class="li-control">
 
 /* extlib: _toggleclass */
 
 
 
 LI.Controls.addControl('control-1', 'ToggleClass', {
 classname: 'changing',
 on: '#duration',
 stopEvent: true
 });
 </script>
 
 
 </p>
 <div class="access-options">
 <select name="duration" id="duration-oauthAuthorizeForm" class="duration-select">
 <option value="0">Until Revoked</option>
 <option value="720">Thirty Days</option>
 <option value="168">One Week</option>
 <option value="24">One Day</option>
 </select>
 </div>
 </div>
 </li>
</ul>


<div class="actions">
 <ul>
 <li><input type="submit" name="authorize" value="Ok, I'll Allow It" class="btn-primary"></li>
 <li><a href="http://www.linkedin.com?oauth_problem=user_refused" class="btn-secondary">Cancel</a></li>
 </ul>
</div>


 
 
 
 <input type="hidden" name="extra" value="" id="extra-oauthAuthorizeForm"><input type="hidden" name="access" value="-3" id="access-oauthAuthorizeForm"><input type="hidden" name="agree" value="true" id="agree-oauthAuthorizeForm"><input type="hidden" name="oauth_token" value="02ebca26-ee3b-482e-8de3-37b2b4aebbbe" id="oauth_token-oauthAuthorizeForm"><input type="hidden" name="appId" value="" id="appId-oauthAuthorizeForm"><input type="hidden" name="csrfToken" value="ajax:5714287977308852176" id="csrfToken-oauthAuthorizeForm"><input type="hidden" name="sourceAlias" value="0_8L1usXMS_e_-SfuxXa1idxJ207ESR8hAXKfus4aDeAk" id="sourceAlias-oauthAuthorizeForm">
 </form>
</body>
</html>
