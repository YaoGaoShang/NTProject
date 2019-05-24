using System;
using System.Collections.Generic;

[Serializable]
public class Info
{

    public string name;
    public string manufacturers;
    public string number;
    public string buyTime;
    public string price;
}

[Serializable]
public class JsonObj
{
    public List<Info> objInfo = new List<Info>();
}

[Serializable]
public class ServerIfo
{
    public string name;
    public string manufacturers;
    public string number;
    public string buyTime;
    public string price;
    public string ipAddress;

}

[Serializable]
public class JsonServerObj
{
    public List<ServerIfo> objServerInfo = new List<ServerIfo>();
    public List<Info> objInfo = new List<Info>();
}
