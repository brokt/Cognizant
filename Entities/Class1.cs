
public class Rootobject
{
    public WareHouse_[] Property1 { get; set; }
}

public class WareHouse_
{
    public string _id { get; set; }
    public string name { get; set; }
    public Location_ location { get; set; }
    public Cars_ cars { get; set; }
}

public class Location_
{
    public string lat { get; set; }
    public string _long { get; set; }
}

public class Cars_
{
    public string location { get; set; }
    public Vehicle_[] vehicles { get; set; }
}

public class Vehicle_
{
    public int _id { get; set; }
    public string make { get; set; }
    public string model { get; set; }
    public int year_model { get; set; }
    public float price { get; set; }
    public bool licensed { get; set; }
    public string date_added { get; set; }
}
//using System;

//namespace Entities
//{
//    public class Class1
//    {
//    }
//}
