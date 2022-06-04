using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabRegister : MonoBehaviour{

    [Header("UI")]
    public Text outputText;
    public InputField mail;

    public InputField password;
    public InputField passwordR;
    


    public void RegisterButton()
    {
        try{
            outputText.text = "Output:";
            outputText.text += "\nMail: "+mail.text+"\nPassword: " + password.text + "\nPasswordR: " + passwordR.text;
        }
        catch(Exception e){
            Debug.LogException(e, this);
        }
    }


}
