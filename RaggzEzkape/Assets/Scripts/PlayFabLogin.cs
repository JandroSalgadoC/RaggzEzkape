using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour{

    [Header("UI")]
    public Text outputText;
    public InputField mail;

    public InputField password;

    String outputMessage;



    public void LoginButton()
    {
        var mailText = mail.text;
        var passwordText = password.text;
        outputMessage ="";

        if(mailText.Length == 0 || passwordText.Length == 0){
            outputMessage = "All fields are required.";
        }
        else{
            LoginRequest(mail.text,password.text);
        }
        try{
            outputText.text = outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }

    void LoginRequest(String mailText, String passwordText){
        var request = new LoginWithEmailAddressRequest{
            Email = mailText,
            Password = passwordText
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
    }

    void OnLoginSuccess(LoginResult result){
        outputMessage = "Logged successfully!";
        outputText.text = outputMessage;
        Debug.Log(result.SessionTicket);
    }

    void OnLoginError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        outputText.text = outputMessage;
    }

}
