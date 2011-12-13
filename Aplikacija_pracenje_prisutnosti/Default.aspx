<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
        <asp:Image ID="ImageHeader" runat="server" Height="72px" ImageUrl="~/Images/Logo.png" 
            Width="407px" style="text-align: center" />
        <br />
        <br />
    
        <br />
    
    </div>
    <div class="style2" 
        
        
        style="height: 93px; color: #789CEF; width: 760px; background-color: #EFEFEF; font-weight: 700; font-size: xx-small; text-align: center;">
        &nbsp;<span class="style4">Select Social Network: </span>&nbsp;<br />
        &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButtonFacebook" runat="server" Height="35px" 
            ImageUrl="~/Images/FacebookLogoSelected.png" Width="35px"
            onclick="ImageButtonFacebook_Click"/>
&nbsp;
        <asp:ImageButton ID="ImageButtonGoogle" runat="server" Height="35px" 
            ImageUrl="~/Images/GoogleLogo.png" Width="35px" 
            onclick="ImageButtonGoogle_Click"  />
&nbsp;
        <asp:ImageButton ID="ImageButtonTwitter" runat="server" Height="35px" 
            ImageUrl="~/Images/TwitterLogo.png" Width="35px" 
            onclick="ImageButtonTwitter_Click" />
&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButtonGowalla" runat="server" Height="35px" 
            ImageUrl="~/Images/GowallaLogo.png" Width="35px"
            onclick="ImageButtonGowalla_Click" />
&nbsp;
        <asp:ImageButton ID="ImageButtonLinkedIn" runat="server" Height="35px" 
            ImageUrl="~/Images/LinkedInLogopng.png" Width="35px" 
            onclick="ImageButtonLinkedIn_Click" />
        <br />
        <hr />
    </div>
      <div class="style2" 
         style="height: 457px; color: #789CEF; width: 760px; background-color: #EFEFEF; font-weight: 700; font-size: medium; font-family: Calibri; text-align: center;">
         &nbsp;&nbsp;&nbsp;
         <br />
        <asp:ListBox ID="ListBoxFB" runat="server" Height="269px" Width="622px" 
             style="font-family: Calibri; text-align: center;" >
         </asp:ListBox>
    </div>
    </form>
</body>
</html>
