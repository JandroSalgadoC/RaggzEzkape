using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeatherBoardManager : MonoBehaviour
{

    String outputMessage;
    public GameObject rowPrefab;
    public Transform rowParent;


    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "WorldLeatherboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnLeaderBoardError);
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowParent){
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(rowPrefab, rowParent);
            Text[] texts = newRow.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();
        }

    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "WorldLeatherboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnLeaderBoardError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        outputMessage = "Leaderboard Successfully Updated!";
        Debug.Log(outputMessage);
    }


    void OnLeaderBoardError(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport().Split(':');
        outputMessage = "Error: " + errorMessage[errorMessage.Length - 1];
        //outputText.text = outputMessage;
        Debug.Log(outputMessage);
    }
}