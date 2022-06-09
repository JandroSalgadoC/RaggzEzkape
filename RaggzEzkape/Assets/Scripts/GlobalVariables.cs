using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class GlobalVariables : MonoBehaviour
{
    private static int v_score;
    
    
    public static int Score{
        get{
            return v_score;
        }

        set{
            if (v_score == value) {
                return;
            }
            v_score = value;
        }
    }

    private static string v_playername;
    public static string Playername{
        get{
            return v_playername;
        }
        set{
            if (v_playername == value) {
                return;
            }
            v_playername = value;
            if (OnUsernameChange != null){
                OnUsernameChange(value);
            }
             
            
        }
    }

    public delegate void SetUsername(string newVal);
    public static event SetUsername OnUsernameChange;
}