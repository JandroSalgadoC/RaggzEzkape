using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{
    public GameObject Game;
    public bool isOver = false;
    public PlayFabLeatherBoardManager playFabLeatherBoardManager;
    public GameObject gameoverUI;
    public CanvasManager canvasManager;

    public AudioClip gameClip;
    public AudioClip menuClip;
    public AudioManager audioManager;
    public void GameStart()
    {
        Game.SetActive(true);
        audioManager.ChangeMusic(gameClip);
    }

    

    public void GameOver()
    {
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
            gameoverUI.SetActive(true);

        }
    }

    public void GoBackToMenuButton(){
        resetValues();
        canvasManager.SwitchCanvas(CanvasType.MainMenu);
        audioManager.ChangeMusic(menuClip);
    }

    public void resetValues(){
        isOver = false;
        Game.SetActive(false);
        gameoverUI.SetActive(false);
        if(GlobalVariables.Playername == "Guest"){
            GlobalVariables.Playername = null;
        }
        GlobalVariables.Acceleration =0;
        GlobalVariables.Score = 0;
        GlobalVariables.Velocity = 0;
        GlobalVariables.Distance =0;
    }


}