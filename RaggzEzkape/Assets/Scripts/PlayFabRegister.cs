using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabRegister : MonoBehaviour{

    [Header("UI")]
    public Text outputText;
    public InputField mail;

    public InputField password;
    public InputField passwordR;

    String outputMessage;



    public void RegisterButton()
    {
        var mailText = mail.text;
        var passwordText = password.text;
        var passwordRText = passwordR.text;
        var regex = new Regex(@"\s");
        outputMessage ="";

        if(mailText.Length == 0 || passwordText.Length == 0 || passwordRText.Length == 0){
            outputMessage = "All fields are required.";
        }
        else if(regex.IsMatch(mailText) || regex.IsMatch(passwordText) ||regex.IsMatch(passwordText)){
            outputMessage = "Whitespaces are not allowed in any field.";
        }
        else if(passwordText.Length<6){
            outputMessage = "Password must be at least 6 characters long.";
        }
        else if(passwordText != passwordRText){
            outputMessage = "Passwords don't match.";
        }
        else{
            RegisterRequest(mail.text,password.text);
        }
        try{
            outputText.text = outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }

    void RegisterRequest(String mailText, String passwordText){
        var request = new RegisterPlayFabUserRequest{
            Email = mailText,
            Password = passwordText,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        outputMessage = "Registered and logged successfully!";
        outputText.text = outputMessage;
        Debug.Log(result.SessionTicket);
    }

    void OnRegisterError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        outputText.text = outputMessage;
    }

}
