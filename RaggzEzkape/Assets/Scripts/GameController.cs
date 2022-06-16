using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Game;
    public bool isOver = false;
    public PlayFabLeatherBoardManager playFabLeatherBoardManager;
    public void GameStart()
    {
        Game.SetActive(true);
    }

    public void GameOver()
    {
        //Game.SetActive(false);        
        if (!isOver)
        {
            isOver = true;
            Debug.Log("Game Over");
            if (GlobalVariables.Playername != "Guest" && GlobalVariables.Playername != null)
            {
                playFabLeatherBoardManager.SendLeaderBoard(GlobalVariables.Distance);
            }
            else
            {
                Debug.Log("Login to upload Score");
            }
        }
    }
}
