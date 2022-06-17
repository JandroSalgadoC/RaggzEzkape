using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayerController : MonoBehaviour
{

    public float LayerOrderSpeed;
    private float layerLenght;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Awake(){
        Debug.Log("Awake");
        startPos = transform.position;
        layerLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Start()
    {
        Debug.Log("Start");
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * Time.deltaTime * GlobalVariables.Velocity * LayerOrderSpeed;
    }
}
