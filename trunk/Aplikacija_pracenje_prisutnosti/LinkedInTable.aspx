<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="LinkedInTable.aspx.cs" Inherits="_Default" %>

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
        
        
        
        style="height: 73px; color: #789CEF; width: 760px; background-color: #EFEFEF; font-weight: 700; font-size: xx-small; text-align: center;">
        &nbsp;<span class="style4">Select Social Network: </span>&nbsp;<br />
        &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" 
            ImageUrl="~/Images/FacebookLogo.png" Width="30px" 
            onclick="ImageButtonFacebook_Click" />
&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" 
            ImageUrl="~/Images/GoogleLogo.png" Width="30px" 
            onclick="ImageButtonGoogle_Click"  />
&nbsp;
        <asp:ImageButton ID="ImageButton3" runat="server" Height="30px" 
            ImageUrl="~/Images/TwitterLogo.png" Width="30px" 
            onclick="ImageButtonTwitter_Click" />
&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton4" runat="server" Height="30px" 
            ImageUrl="~/Images/GowallaLogo.png" Width="30px" 
            onclick="ImageButtonGowalla_Click" />
&nbsp;
        <asp:ImageButton ID="ImageButton5" runat="server" Height="30px" 
            ImageUrl="~/Images/LinkedInLogopngSelected.png" Width="30px" 
            onclick="ImageButton5_Click" />
        <br />
        <hr />
    </div>
     <div class="style2" 
        
        
        
        
        style="height: 387px; color: #789CEF; width: 760px; background-color: #EFEFEF; font-weight: 700; font-size: medium; font-family: Calibri; text-align: center;">

         &nbsp;&nbsp;&nbsp;
         <br />
         <asp:ListBox ID="ListBox1" runat="server" Height="269px" Width="622px">
         </asp:ListBox>

         <br />
         <br />
         <asp:TextBox ID="TextBox1" runat="server" Width="616px"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
             Text="Update status" />

    </div>
    </form>
</body>
</html>
