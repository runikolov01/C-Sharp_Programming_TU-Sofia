using System;
using System.Collections.Generic;
using System.Linq;

public class Contact
{
    private static Random _random = new Random();
    private string _name = "";

    public string Name
    {
        get => _name;
        set => _name = value ?? "user" + _random.Next(10000, 99999);
    }
}