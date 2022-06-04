using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.UI;

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
            outputMessage = "Validation Ok!";
        }

        try{
            outputText.text = "Output:";
            outputText.text += "\nMail: "+mail.text+"\nPassword: " + password.text + "\nPasswordR: " + passwordR.text;
            outputText.text += "\nMssg: " + outputMessage;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }


}
