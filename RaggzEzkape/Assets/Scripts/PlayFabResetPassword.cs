using System.Net.Mail;
using System;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabResetPassword : MonoBehaviour{

    [Header("UI")]
    public Text outputText;
    public InputField mail;
    String outputMessage;



    public void ResetPasswordButton()
    {
        var mailText = mail.text;
        outputMessage ="";

        if(mailText.Length == 0){
            outputMessage = "All fields are required.";
        }
        else if(mailText.Contains('@')){
            var request = new SendAccountRecoveryEmailRequest{
                Email = mailText,
                TitleId = "967E2"
            };
            PlayFabClientAPI.SendAccountRecoveryEmail(request, OnSuccess, OnError);
        }
        else{
            outputMessage = "Please enter a valid recovery email address.";
        }

        try{
            outputText.text = outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }

    void OnSuccess(SendAccountRecoveryEmailResult result){
        outputMessage = "Password recovery email sent successfully.";
        outputText.text = outputMessage;
    }

    void OnError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        outputText.text = outputMessage;
    }
}
