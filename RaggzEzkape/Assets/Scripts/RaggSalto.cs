using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaggSalto : MonoBehaviour
{
    //Creo las variables para el RigidBody y los multiplicadores de salto:
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    Rigidbody2D  rb;

    private Vector2 groundedVectorRight;
    private Vector2 groundedVectorLeft;

    private Vector3 groundedRaycastDirection;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.3f;
    private float jumpBufferCounter;

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
        if(rb.velocity.y < 0 && !IsGrounded()){
            rb.gravityScale = fallMultiplier;
        }else if(rb.velocity.y > 0 && !IsGrounded() && !(Input.GetKey(KeyCode.Space))){
            rb.gravityScale = fallMultiplier;
            coyoteTimeCounter = 0;
        }else{
            rb.gravityScale = 1f;
        }
    }

    void Update(){

        if(IsGrounded()){
            coyoteTimeCounter = coyoteTime;

        }else{
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            jumpBufferCounter = jumpBufferTime;

        }else{
            jumpBufferCounter -= Time.deltaTime;
        }

        if((jumpBufferCounter > 0 && coyoteTimeCounter > 0)){
            Jump();
            jumpBufferCounter = 0;
            
        }

    }

    private void Jump(){
        rb.AddForce(Vector2.up*jumpForce);
    }

    private bool IsGrounded(){
        groundedRaycastDirection = transform.TransformDirection(Vector3.down) * 1f;
        groundedVectorLeft = new Vector2(transform.position.x-0.5f, transform.position.y);
        groundedVectorRight = new Vector2(transform.position.x+0.5f, transform.position.y);
        Debug.DrawRay(groundedVectorLeft, groundedRaycastDirection, Color.red);
        Debug.DrawRay(groundedVectorRight, groundedRaycastDirection, Color.yellow);


        if(Physics2D.Raycast(groundedVectorLeft, Vector2.down, 1f) || Physics2D.Raycast(groundedVectorRight, Vector2.down, 1f)){
            return true;
        }else{
            return false;
        }
    }
}
