// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // Card Management 
// public class Deck : Card
// {
//     public List<Card> deck = new List<Card>();

//     void Start()
//     {
//         InitializeDeck();
//         ShuffleDeck();
//     }

//     void InitializeDeck()
//     {
//         // Number cards 1-20
//         for (int i = 1; i <= 20; i++)
//         {
//             deck.Add(new Card("Card " + i, i));
//         }

//         // 2 special action cards
//         // deck.Add(new Card("S1"));
//         // deck.Add(new Card("S2"));
//     }

//     void ShuffleDeck()
//     {
//         for (int i = 0; i < deck.Count; i++)
//         {
//             Card temp = deck[i];
//             int randomIndex = Random.Range(i, deck.Count);
//             deck[i] = deck[randomIndex];
//             deck[randomIndex] = temp;
//         }
//     }

//     // Allow a player to pick 2 cards from the deck
//     public List<Card> ChooseTwoCards()
//     {
//         List<Card> chosenCards = new List<Card>();

//         for (int i = 0; i < 2 && deck.Count > 0; i++)
//         {
//             chosenCards.Add(deck[0]);
//             deck.RemoveAt(0);
//         }

//         return chosenCards;
        
//     }
// }