using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : GeneralMovement
{
    
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;   
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f,groundLayer);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
            speed *= -1;
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime,rb.velocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * There are 4 tags:
         *      DropLeft: One ON the left boundary of the plane. Here, the AI has two options.
         *      It will select to either drop down or turn back.
         *      
         *      DropRight: One ON the right boundary of the plane. Here the AI has two options.
         *      It will randomly select between dropping down or turning back
         *      
         *      JumpRight: One BELOW the right boundary of the plane. Here the AI has three options.
         *      It will randomly select between jumping up, turning back; or going straight ahead.
         *      
         *      JumpLeft: One BELOW the left boundary of the plane. Here the AI has three options.
         *      It will randomly select between jumping up, turning back; or going straight ahead.
         *      
         */
        switch (collision.tag)
        {
            case "LeftDrop":
                Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + StateNumber(2));
                break;
            case "RightDrop":
                Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + StateNumber(2));
                break;
            case "RightJump":
                Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + StateNumber(3));
                break;
            case "LeftJump":
                Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + StateNumber(3));
                break;
            default:
                break;

        }
        
        //Generates random number for AI decisions. Basically a Numerator.
        //For dual-path options: StateNumber(2)
        //For triple-path options: StateNumber(3)
        int StateNumber(int range)
        {
            return Random.Range(1,range);
        }
    }

}
