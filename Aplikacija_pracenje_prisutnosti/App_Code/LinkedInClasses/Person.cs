using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    public String id;
    public String name;
    public String surname;
    public Person(string p, string p_2, string p_3)
    {
        // TODO: Complete member initialization
        this.id = p;
        this.name = p_2;
        this.surname = p_3;
    }
}