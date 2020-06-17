using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rate
{
    public int SphereSpeed
    {
        get; private set;
    }

    public string TextRate
    {
        get; private set;
    }

    public Rate(string textRate, int sphereSpeed)
    {
        SphereSpeed = sphereSpeed;
        TextRate = textRate;
    }

}
