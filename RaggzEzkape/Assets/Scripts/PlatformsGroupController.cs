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
        foreach (Transform child in transform)
        {
            platformsList.Add(child);
            
        }

        for(int i = 0; i < platformsList.Count;i++){
            Debug.Log("index: "+i+"name: "+platformsList[i].name);
        }
    }

    void Start()
    {
        platformsList[0].GetComponent<PlatformController>().isEnabled = true;
        platformsList[4].GetComponent<PlatformController>().isEnabled = true;
        platformsList[3].GetComponent<PlatformController>().isEnabled = true;
        lastPlatform = platformsList[3]; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lastPlatform.GetComponent<PlatformController>().GetTopColliderRightPosition().x < 9.54)
        {
            sendPlatformToGame();
        }

        //Debug.Log(platformsList[0].GetComponent<PlatformController>().GetTopColliderRightPosition());
    }

    private static int SortByName(Transform o1, Transform o2) {
     return o1.name.CompareTo(o2.name);
 }

    void sendPlatformToGame()
    {
        lastPlatform = platformsList[choosePlatform()];
        lastPlatform.GetComponent<PlatformController>().isEnabled = true;
    }

    int choosePlatform()
    {
        if (platformsList.Count > 0)
        {
            return Random.Range(0, platformsList.Count - 1);
        }
        else
        {
            return -1;
        }
    }
}
