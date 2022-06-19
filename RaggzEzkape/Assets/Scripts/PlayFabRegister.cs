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
    public InputField userName;
    public InputField password;
    public InputField passwordR;
    String outputMessage;



    public void RegisterButton()
    {
        var mailText = mail.text;
        var userNameText = userName.text;
        var passwordText = password.text;
        var passwordRText = passwordR.text;
        var regex = new Regex(@"\s");
        outputMessage ="";

        if(mailText.Length == 0 || userNameText.Length == 0 ||passwordText.Length == 0 || passwordRText.Length == 0){
            outputMessage = "All fields are required.";
        }
        else if (regex.IsMatch(mailText) || regex.IsMatch(userNameText) || regex.IsMatch(passwordText) || regex.IsMatch(passwordText)){

            outputMessage = "Whitespaces are not allowed in any field.";
        }
        else if(userNameText.Length<3 || userNameText.Length > 13){
            outputMessage = "Username must be between 3 and 13 characters long.";
        }
        else if(passwordText.Length<6){
            outputMessage = "Password must be at least 6 characters long.";
        }
        else if(passwordText != passwordRText){
            outputMessage = "Passwords don't match.";
        }
        else{
            RegisterRequest(mailText,userNameText,passwordText);
        }
        try{
            outputText.text = outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }

    void RegisterRequest(String mailText, String userNameText ,String passwordText){
        var request = new RegisterPlayFabUserRequest{
            Email = mailText,
            Username = userNameText,
            Password = passwordText,
            DisplayName = userNameText,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams{
                GetUserAccountInfo = true
            }
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        outputMessage = "Registered and logged successfully!";
        outputText.text = outputMessage;
        GlobalVariables.Score = 0;
        GlobalVariables.Playername = userName.text.ToLower();
        mail.text=null;
        userName.text=null;
        password.text=null;
        passwordR.text=null;

    }

    void OnRegisterError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        outputText.text = outputMessage;
    }



}
