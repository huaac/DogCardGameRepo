using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Card Management 
public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    void Start()
    {
        InitializeDeck();
        ShuffleDeck();
    }

    void InitializeDeck()
    {
        // Number cards 1-20
        for (int i = 1; i <= 20; i++)
        {
            deck.Add(new Card("Card " + i, i));
        }

        // 2 special action cards
        deck.Add(new Card("S1"));
        deck.Add(new Card("S2"));
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }


    public List<Card> ChooseTwoCards(List<int> chosenIndices)
    {
        List<Card> chosenCards = new List<Card>();


        foreach (int index in chosenIndices)
        {
            if (index >= 0 && index < deck.Count)
            {
                chosenCards.Add(deck[index]);
                deck.RemoveAt(index);
            }
        }

        return chosenCards;
    }
}