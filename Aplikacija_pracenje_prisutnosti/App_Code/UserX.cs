using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gowalaWarp2;

/// <summary>
/// Summary description for AllUsers
/// </summary>
public class UserX
{
    public static Dictionary<string, Gowalla> listOfAllUser = new Dictionary<string, Gowalla>(20);
  

    public UserX(string userId, Gowalla user)
	{	       
       
        listOfAllUser.Add(userId, user);
        
	}   

  
}