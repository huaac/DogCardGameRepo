using UnityEngine;
using System.Collections.Generic;

// Individual card properties 
public class Card : MonoBehaviour
{
    //This script will contain all the actions that can be done with the cards

    // public SpecialActionCard[] SACs;
    
    
    // public enum CardType
    // {
    //     Number,
    //     SpecialActionCard
    // }

    // public string name;
    // public string desc;
    // public int value;
    // public bool isSpecial;

    public SpecialActionCard sac;
    public SpriteRenderer card_front;
    public SpriteRenderer card_back;

    // public Card(string name, int value)
    // {
    //     this.name = name;
    //     this.value = value;
    //     this.isSpecial = false;
    // }

    // public Card(string name)
    // {
    //     this.name = name;
    //     this.value = 0;
    //     this.isSpecial = true;
    // }
}


