using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName="SAC", menuName = "ScriptableObjects/SAC")]
public class SpecialActionCard : ScriptableObject
{
    public string card_name;
    public string card_desc;

    public Sprite card_sprite;
    public Sprite card_bg_sprite;

    // public CardType CardType; //in Card script
}
