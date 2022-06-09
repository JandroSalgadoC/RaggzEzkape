using System.Net.Mail;
using System;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogout : MonoBehaviour{

    public CanvasManager canvasManager;

    [Header("UI")]
    public Text outputText;
    String outputMessage;


    private void Awake(){
        GlobalVariables.OnUsernameChange += UserNameChangeHandler;
    }
    public void LogoutButton()
    {
        outputMessage ="";

        if(GlobalVariables.Playername != null){
            Logout();
        }
        else{
            outputMessage = "You are already logged out";
        }
        try{
            outputText.text = outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }

    void Logout(){

        PlayFabClientAPI.ForgetAllCredentials();
        OnLogoutSuccess();

    }

    void OnLogoutSuccess(){
        GlobalVariables.OnUsernameChange += UserNameChangeHandler;
        outputMessage = "Logged out successfully!";
        outputText.text = outputMessage;
        GlobalVariables.Score= 0;
        GlobalVariables.Playername = null;
    }

    void OnLogoutError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        outputText.text = outputMessage;
    }

    public void UserNameChangeHandler(string username){
        canvasManager.mainMenuUnlogged();
    }

}
