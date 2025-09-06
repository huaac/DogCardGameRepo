using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public int num_players = 0;

    public static GameManager Instance;
    public GameState State;

    // public GameObject[] players;
    public List<Player> all_player_scripts;
    public List<Sprite> card_fronts;

    public static event Action<GameState> OnGameStateChanged;

    public SpecialActionCard[] SACs;

    // public Transform testposition;
    public GameObject testcardprefab;


    // public List<SpecialActionCard> SACList = new SpecialActionCard[2];


    void Awake()
    {
        Instance = this;
        // players = new GameObject[2];
        MonoBehaviour[] found_scripts = FindObjectsOfType<Player>();

        foreach (Player script in found_scripts)
        {
            all_player_scripts.Add(script);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.DrawPhase);
        // GameObject projectile = Instantiate(testcardprefab, testposition.position, transform.rotation);
        // projectile.GetComponent<Card>().sac = SACs[0];
        // Debug.Log(projectile.GetComponent<Card>().sac.card_name);

    }



    public void UpdateGameState(GameState newState) {
        State = newState;
        switch(newState)
        {
            case GameState.DrawPhase:
                HandleDrawPhase();
                break;
            case GameState.DiscardPhase:
                break;
            case GameState.BetPhase:
                break;
            case GameState.RevealPhase:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState {
        DrawPhase,
        DiscardPhase,
        BetPhase,
        RevealPhase

    }

    private void HandleDrawPhase()
    {
        // this phase hands out 2 SAC to the players and 2 faced down number cards

        int max_sacs = SACs.Length;
        int max_front_cards = card_fronts.Count;
        

        foreach (Player player in all_player_scripts)
        {
            GameObject p_sac = Instantiate(testcardprefab, player.player_SAC_pos.position, player.player_SAC_pos.rotation);
            p_sac.GetComponent<Card>().sac = SACs[UnityEngine.Random.Range(0,max_sacs)];

            GameObject num_card = Instantiate(testcardprefab, player.player_num_card_pos.position, player.player_num_card_pos.rotation);
            num_card.GetComponent<Card>().card_front.sprite = card_fronts[UnityEngine.Random.Range(0,max_front_cards)];
            // num_card.GetComponent<SpriteRenderer>().sprite = card_fronts[UnityEngine.Random.Range(0,max_front_cards)];
        }


        // SpecialActionCard SACList[];
    }
}
