using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGroupController : MonoBehaviour
{
    public List<Transform> platformsList = new List<Transform>();
    public Transform lastPlatform;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform child in transform){
            platformsList.Add(child);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sendPlatformToGame();
        //Debug.Log(platformsList[0].GetComponent<PlatformController>().GetTopColliderRightPosition());
    }

    void sendPlatformToGame(){
        platformsList[choosePlatform()].GetComponent<PlatformController>().isEnabled=true;
    }

    int choosePlatform(){
        if(platformsList.Count>0){
            return Random.Range(0, platformsList.Count-1);
        }
        else{
            return -1;
        }
    }
}
