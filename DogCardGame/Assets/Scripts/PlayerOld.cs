// using System.Collections.Generic;
// using UnityEngine;

// // Player Info + Actions
// public class Player
// {
//     public string name;
//     public List<Card> hand = new List<Card>();
//     public int kibble = 10;
//     public Card discardedCard;

//     public Player(string name)
//     {
//         this.name = name;
//     }

//     // public void ChooseTwoCards(Deck deck)
//     // {
//     //     hand.Clear();
//     //     List<Card> chosen = deck.ChooseTwoCards();
//     //     hand.AddRange(chosen);
//     // }


//     public void Discard(int index)
//     {
//         if (index >= 0 && index < hand.Count)
//         {
//             discardedCard = hand[index];
//             hand.RemoveAt(index);
//         }
//     }

//     public bool Bet(int amount)
//     {
//         if (amount <= kibble)
//         {
//             kibble -= amount;
//             return true;
//         }
//         else
//         {
//             Debug.Log("Amount greater than kibble.");
//             return false;
//         }
//     }

//     public void Fold()
//     {
//         Debug.Log(name + " folds");
//     }

//     public Card GetRevealCard()
//     {
//         return discardedCard;
//     }
// }


