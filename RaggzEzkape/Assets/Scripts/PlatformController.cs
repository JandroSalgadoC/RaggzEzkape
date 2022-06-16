using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public bool isEnabled;
    public Vector2 topColliderPosition;
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
            if(GetTopColliderRightPosition().x < -16){
                transform.position = new Vector3(20,0,0);
                isEnabled = false;
            }
        }
    }

    public Vector2 GetTopColliderPosition(int point){
        return transform.GetComponent<EdgeCollider2D>().points[point];
    }

    public Vector2 GetTopColliderBounds(){
        return transform.GetComponent<EdgeCollider2D>().bounds.center;
    }

    public Vector2 GetTopColliderLeftPosition(){
        return new Vector2((GetTopColliderBounds().x+GetTopColliderPosition(0).x),GetTopColliderBounds().y);
    }
    public Vector2 GetTopColliderRightPosition(){
        //Debug.Log(new Vector2((GetTopColliderBounds().x+GetTopColliderPosition(1).x),GetTopColliderBounds().y));
        return new Vector2((GetTopColliderBounds().x+GetTopColliderPosition(1).x),GetTopColliderBounds().y);
    }
}
