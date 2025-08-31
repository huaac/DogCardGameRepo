using UnityEngine;
using System.Collections.Generic;

// Individual card properties 
public class Card
{
    public string name;
    public int value;
    public bool isSpecial;

    public Card(string name, int value)
    {
        this.name = name;
        this.value = value;
        this.isSpecial = false;
    }

    public Card(string name)
    {
        this.name = name;
        this.value = 0;
        this.isSpecial = true;
    }
}


