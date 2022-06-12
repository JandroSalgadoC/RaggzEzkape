using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public bool isEnabled;
    // Awake is called before the first frame update
    void Awake(){
        isEnabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnabled) {
            transform.position += Vector3.left * Time.deltaTime * GlobalVariables.Velocity;
            if(transform.position.x < -10){
                transform.position = new Vector3(35,0,0);
                isEnabled = false;
            }
        }
    }
}
