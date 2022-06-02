using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaggMovimiento : MonoBehaviour
{
    public float RaggSpeed;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        RaggSpeed = 5f;
    }

    // Update is called once per frame
    void Update()    {

        Horizontal = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal*RaggSpeed,Rigidbody2D.velocity.y);
    }
}
