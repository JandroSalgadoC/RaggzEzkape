using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayerController : MonoBehaviour
{

    public float LayerOrderSpeed;
    private float layerLenght;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        layerLenght = GetComponent<SpriteRenderer>().bounds.size.x;


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
