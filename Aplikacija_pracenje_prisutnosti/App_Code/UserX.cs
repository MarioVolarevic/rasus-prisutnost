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
    public static int counter = 0;       

    public UserX(string userId, Gowalla user)
	{	       
        counter++;
        listOfAllUser.Add(userId, user);
	}   

  
}