using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaggSalto : MonoBehaviour
{
    //Creo las variables para el RigidBody y los multiplicadores de salto:
    private bool grounded;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    Rigidbody2D  rb;

    //Uso Awake en lugar de Start porque necesito que las variables de dentro se 
    //incialicen antes que incluso los que haya dentro de Start en otros scripts 
    //para mejorar la estabilidad del código.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 300f;
        fallMultiplier = 3f;
        lowJumpMultiplier = 2f;
    }

    //Uso FixedUpdate en lugar de Update porque la Documentación recomienda su uso en 
    //caso de tratar con físicas, que es el caso:
    void FixedUpdate()
    {
        if(rb.velocity.y < 0){
            rb.gravityScale = fallMultiplier;
        }else if(rb.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))){
            rb.gravityScale = fallMultiplier;
        }else{
            rb.gravityScale = 1f;
        }
    }

    void Update()
    {
        Vector3 down = transform.TransformDirection(Vector3.down) * 1f;
        Debug.DrawRay(transform.position, down, Color.red);

        if(Physics2D.Raycast(transform.position, Vector2.down, 1f)){
            
            grounded = true;
        }else{
            grounded = false;
        }

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded){
            Jump();
        }

    }

    private void Jump(){
        rb.AddForce(Vector2.up*jumpForce);
    }
}
