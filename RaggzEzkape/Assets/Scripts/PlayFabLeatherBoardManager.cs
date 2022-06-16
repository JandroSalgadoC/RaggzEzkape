using System.Net.Mail;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeatherBoardManager : MonoBehaviour{

    String outputMessage;


    public void SendLeaderBoard(int score){
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "WorldLeatherboard", 
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnLeaderBoardError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result){
        //var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Leaderboard Successfully Updated!";
        //outputText.text = outputMessage;
        Debug.Log(outputMessage);
    }


    void OnLeaderBoardError(PlayFabError error){
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length-1];
        //outputText.text = outputMessage;
        Debug.Log(outputMessage);
    }

}