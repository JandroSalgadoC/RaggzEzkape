using System.Net.Mail;
using System;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour{

    public CanvasManager canvasManager;

    [Header("UI")]
    public Text outputText;
    public InputField userNameMail;

    public InputField password;

    String outputMessage;


    private void Awake(){
        GlobalVariables.OnUsernameChange += UserNameChangeHandler;
    }
    public void LoginButton()
    {
        var userOrMail = userNameMail.text;
        var passwordText = password.text;
        outputMessage ="";

        if(userOrMail.Length == 0 || passwordText.Length == 0){
            outputMessage = "All fields are required.";
        }
        else if(userOrMail.Contains('@')){
            LoginRequestMail(userOrMail,passwordText);
        }
        else{
            LoginRequestUser(userOrMail,passwordText);
        }
        try{
            outputText.text = outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }

    void LoginRequestMail(String mailText, String passwordText){
        var request = new LoginWithEmailAddressRequest{
            Email = mailText,
            Password = passwordText,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams{
                GetUserAccountInfo = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
    }

    void LoginRequestUser(String userText, String passwordText){
        var request = new LoginWithPlayFabRequest{
            Username = userText,
            Password = passwordText,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams{
                GetUserAccountInfo = true
            }
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginError);
    }

    void OnLoginSuccess(LoginResult result){
        GlobalVariables.OnUsernameChange += UserNameChangeHandler;
        outputMessage = "Logged successfully!";
        outputText.text = outputMessage;
        GlobalVariables.Score= 0;
        GlobalVariables.Playername = result.InfoResultPayload.AccountInfo.Username;
        Debug.Log(outputMessage);
    }

    void OnLoginError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        outputText.text = outputMessage;
    }

    public void UserNameChangeHandler(string username){
        canvasManager.mainMenuLogged();
    }
}
