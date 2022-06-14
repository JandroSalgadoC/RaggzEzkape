using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGroupController : MonoBehaviour
{
    public List<Transform> platformsList = new List<Transform>();
    public Transform lastPlatform;

    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform child in transform)
        {
            platformsList.Add(child);

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
    void Update()
    {
        if (lastPlatform.GetComponent<PlatformController>().GetTopColliderRightPosition().x < 6.5)
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
        var maxY = lastPlatform.GetComponent<PlatformController>().GetTopColliderRightPosition().y > -1.78f? -1.78f : lastPlatform.GetComponent<PlatformController>().GetTopColliderRightPosition().y;
        var minY =  -7f;
        var newY = Random.Range(minY, maxY);

        //var randomY = randomYGenerator();


        lastPlatform = platformsList[choosePlatform()];

        lastPlatform.position = new Vector2 (lastPlatform.position.x,newY); 
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
