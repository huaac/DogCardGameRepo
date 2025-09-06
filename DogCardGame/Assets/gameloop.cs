using System.Collections.Generic;
using UnityEngine;

// Game loop

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance; 
    
    public Deck deck;
    public Player player;
    public Player currentPlayer;
    public Player aiPlayer;
    
    public enum GamePhase { Draw, Discard, Betting, Reveal, GameOver }
    public GamePhase currentPhase = GamePhase.Draw;
    public int currentRound = 1;
    public int betAmount = 0;
    public int currentBet = 0;

    void Start()
    {
        InitializeGame();
        StartRound();
    }
    
    void InitializeGame()
    {
        player = new Player("Player");
        aiPlayer = new Player("AI");
        
        if (deck == null)
            deck = GetComponent<Deck>();
    }
    
    public void StartRound()
    {
        Debug.Log($"=== Round {currentRound} ===");
        currentPhase = GamePhase.Draw;
        
        DrawPhase();
    }
    
    void DrawPhase()
    {
        Debug.Log("Draw Phase: Draw 2 cards");
        
        List<int> playerSelectedIndices = GetPlayerCardChoices();
        player.ChooseTwoCards(deck, playerSelectedIndices);
        
        currentPhase = GamePhase.Discard;
        Debug.Log("Discard Phase: Choose a card to discard");
        PlayerDiscard(0); // Default for testing purposes
    }
    
    List<int> GetPlayerCardChoices()
    {

        return new List<int> { 0, 1 };
    }
    
    public void PlayerDiscard(int cardIndex)
    {   

        
        Card discardedCard = player.hand[cardIndex];
        player.Discard(cardIndex);
        
        currentPhase = GamePhase.Betting;
        PlayerBet(1); // Default for testing purposes
    }
  
    
    public void PlayerBet(int amount)
    {
        
        if (amount <= 0)
        {
            Debug.Log("Bet amount must be greater than 0!");
            return;
        }
        
        if (amount > player.kibble)
        {
            Debug.Log($"You don't have enough kibble!");
            return;
        }
        
        if (player.Bet(amount))
        {
            currentBet = amount;
            
            if (aiPlayer.kibble >= amount)
            {
                aiPlayer.Bet(amount);
            }
            else
            {
                aiPlayer.Fold();
                player.kibble += currentBet;
                EndRound();
            }
            
            currentPhase = GamePhase.Reveal;
            RevealPhase();
        }
    }
    
    public void PlayerFold()
    {   
        player.Fold(); 
        EndRound();
    }
    
        
    void RevealPhase()
    {
        currentPhase = GamePhase.Reveal;
        
        Card playerCard = player.GetRevealCard();
        
        DetermineWinner(currentBet);
    }
    
       

    void DetermineWinner(int betAmount)
    {
        Card playerCard = player.GetRevealCard();
        Card aiCard = aiPlayer.GetRevealCard();
        bool playerWins = false;

        // Card Rules:
            // 1 < 20 (S1 > 20) (S1 > S20)
            // S1 > 1 (S20 > 20)
            // S1 > 20 and S1 > S20
            // S1 < 15
            // S20 > 15

        if (playerCard.isSpecial)
        {
            if (playerCard.name == "S1")
            {
                if (aiCard.name == "S20" || aiCard.value == 1 || aiCard.value == 20)
                {
                    playerWins = true;
                } else 
                {
                    if (aiCard.value < 20 || aiCard.value > 1)
                    {
                        playerWins = false;
                    }
                }
            }
            else if (playerCard.name == "S20") 
            {
                if (aiCard.name != "S1"|| aiCard.value >= 20)
                {
                    playerWins = true;
                } else 
                {
                    playerWins = false;
                }
            }
        }
        else
        {
            if (playerCard.value > aiCard.value)
            {
                playerWins = true;
            }
        }
        
        if (playerWins)
        {
            player.kibble += betAmount;
            EndRound();
        }
        else
        {
            aiPlayer.kibble += betAmount;
            EndRound();
        }
    }
        
    
    void EndRound()
    {
        currentRound++;
        StartRound();
    }
}