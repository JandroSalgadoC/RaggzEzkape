using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaggCamFollower : MonoBehaviour
{
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3((character.position.x+4), (character.position.y+1), transform.position.z);
    }
}
