using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public enum CanvasType
{
    MainMenu,
    RegisterMenu,
    GameUI
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    public Text usernameText;

    public GameObject loggedMenu;
    public GameObject unloggedMenu;

    public PlayFabLeatherBoardManager playFabLeatherBoardManager;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
            if(_type == CanvasType.MainMenu){
                mainMenuLogged();
            }
        }
        else {
            Debug.LogWarning("The desired canvas was not found!"); 
        }
    }

    public void mainMenuLogged(){
        if(GlobalVariables.Playername != null){
            usernameText.text = GlobalVariables.Playername.ToUpper();
            unloggedMenu.SetActive(false);
            loggedMenu.SetActive(true);
            playFabLeatherBoardManager.GetLeaderBoard();
        }
    }

    public void mainMenuUnlogged(){
        unloggedMenu.SetActive(true);
        loggedMenu.SetActive(false);
    }
}