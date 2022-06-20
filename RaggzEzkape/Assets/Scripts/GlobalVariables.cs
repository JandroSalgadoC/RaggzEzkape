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

    private static int v_distance = 0;
    public static int Distance{
        get{
            return v_distance;
        }
        set{
            if (v_distance == value) {
                return;
            }
            v_distance = value;
        }
    }
    private static float v_velocity = 0;
    public static float Velocity{
        get{
            return v_velocity;
        }
        set{
            if (v_velocity == value) {
                return;
            }
            v_velocity = value;
        }
    }

    private static float v_maxVelocity = 100;
    public static float MaxVelocity{
        get{
            return v_maxVelocity;
        }
        set{
            if (v_maxVelocity == value) {
                return;
            }
            v_maxVelocity = value;
        }
    }
     private static float v_acceleration =10;
    public static float Acceleration{
        get{
            return v_acceleration;
        }
        set{
            if (v_acceleration == value) {
                return;
            }
            v_acceleration = value;
        }
    }

    private static float v_maxAcceleration =10;
    public static float MaxAcceleration{
        get{
            return v_maxAcceleration;
        }
        set{
            if (v_maxAcceleration == value) {
                return;
            }
            v_maxAcceleration = value;
        }
    }

}