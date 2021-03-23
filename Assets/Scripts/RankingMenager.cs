using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RankingMenager : MonoBehaviour
{

    [Header("MAIN OBJS")] 
    public GameObject mainObject;
    public GameObject paintObject;
    
    [Header("Camera")] 
    public GameObject camera;
    
    [Header("Player Companents")]
    public GameObject Player;
    private float PlayerPosition;

    [Header("ListCOmpanents")]
    public List<GameObject> players;
    public List<GameObject> onGamePlayers;
    public List<GameObject> finishedPlayers;
    private List<GameObject> sortedPlayers;
    
    public TextMeshProUGUI  positionText;

    public bool gameFinished;
    //   public Text posText;


    void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            onGamePlayers.Add(players[i]);
        }
        onGamePlayers.Add(Player);
        positionText.text = "1";
    }

   
    void Update()
    {
        PositionFinder();
    }

    public void PositionFinder()
    {
        finishedController();
        
        if (!gameFinished)
        {
            
            List<GameObject> sortedPlayers = onGamePlayers.OrderBy(o=>o.GetComponent<PlayerStats>().distance).ToList();
            onGamePlayers = sortedPlayers;
        
            for (int i = 0; i < onGamePlayers.Count; i++)
            {
                if (onGamePlayers[i].GetComponent<PlayerStats>().isPlayer == true)
                {
                    positionText.text = (finishedPlayers.Count + i + 1).ToString();
                }
            }

            gameFinished = !(Player.GetComponent<PlayerStats>().isFinished == false);

        }
        else
        {
            //mainObject.gameObject.SetActive(false);
            Player.gameObject.SetActive(false);
            camera.gameObject.SetActive(false);
            paintObject.gameObject.SetActive(true);
        }

        

    }

    public void finishedController()
    {
        
        for (int i = 0; i < onGamePlayers.Count; i++)
        {
            if (onGamePlayers[i].GetComponent<PlayerStats>().isFinished == true)
            {
                finishedPlayers.Add(onGamePlayers[i]);
                onGamePlayers.RemoveAt(i);
            }
        }
        
    }
}

