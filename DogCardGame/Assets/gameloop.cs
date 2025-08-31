using System.Collections.Generic;
using UnityEngine;

// Game loop

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance; 
    
    public Cards deck;
    public Player player;
    
    public enum GamePhase { Draw, Discard, Betting, Reveal, GameOver }
    public GamePhase currentPhase = GamePhase.Draw;
    public int currentRound = 1;

    void Start()
    {
        InitializeGame();
        StartRound();
    }
    
    void InitializeGame()
    {
        player = new Player("Player");
        
        if (deck == null)
            deck = GetComponent<Cards>();
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
        
        player.ChooseTwoCards(deck);
        
        currentPhase = GamePhase.Discard;
        Debug.Log("Discard Phase: Choose a card to discard");
    }
    
    public void PlayerDiscard(int cardIndex)
    {   
        player.Discard(cardIndex);
        
        currentPhase = GamePhase.Betting;
    }
  
    
    public void PlayerBet(int amount)
    {
        
        if (player.Bet(amount))
        {
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
        
        DetermineWinner();
    }
    
    void DetermineWinner()
    {
        // Card Rules:
        // 1 < 20 (S1 > 20) (S1 > S20)
        // S1 > 1 (S20 > 20)
        // S1 > 20 and S1 > S20
        // S1 < 15
        // S20 > 15
    }
    
    void EndRound()
    {
        currentRound++;
        StartRound();
    }
}