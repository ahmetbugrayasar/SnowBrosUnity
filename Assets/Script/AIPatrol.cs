using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : GeneralMovement
{
    
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    int counter = 0;

    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Collider2D bodyCollider;
    public bool leftDrop, rightDrop,leftJump,rightJump;
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
            Debug.Log("I've touched the wall" + counter + " times.");
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Patrol()
    {
        
        if (bodyCollider.IsTouchingLayers(wallLayer))
        {
            counter +=1;
            Flip();
            speed *= -1;
            
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime,rb.velocity.y);
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int decisionNumber;
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
         *      State 1: Go ahead (Which means dropping down for Drops)
         *      State 2: Turn Around for Drops, Jump for Jumps
         */
        switch (collision.tag)
        {
            
            case "LeftDrop":
                
                decisionNumber = StateNumber(2);
                //Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + decisionNumber);
                if(!leftDrop && !mustTurn)
                {
                    if (decisionNumber == 1 && !bodyCollider.IsTouchingLayers(wallLayer))
                    {
                        mustTurn = false;
                        //Debug.Log("I've decided to drop down");
                    }
                    else if (decisionNumber == 2)
                    {
                        Flip();
                        speed *= -1;
                    }
                }
                leftDrop = true;
                rightDrop = leftJump = rightJump = false;
                break;

            case "RightDrop":
                
                decisionNumber = StateNumber(2);
                //Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + decisionNumber);
                if(!rightDrop && !mustTurn)
                {
                    if (decisionNumber == 1 && !bodyCollider.IsTouchingLayers(wallLayer))
                    {
                        mustTurn = false;
                        //Debug.Log("I've decided to drop down");
                    }
                    else if (decisionNumber == 2)
                    {
                        Flip();
                        speed *= -1;
                    }
                }
                rightDrop = true;
                leftDrop = leftJump = rightJump = false;
                break;

            case "RightJump":
                
                decisionNumber = StateNumber(2);
                //Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + decisionNumber);
                if(!rightJump && !mustTurn)
                {
                    if (decisionNumber == 1 && !bodyCollider.IsTouchingLayers(wallLayer))
                    {
                        mustTurn = false;
                    }

                    else if (decisionNumber == 2)
                    {
                        //Debug.Log("I've decided to Jump!");
                        StartCoroutine(AIJump(1));
                    }
                }
                rightJump = true;
                leftJump = leftDrop = rightDrop = false;
                break;

            case "LeftJump":
                
                decisionNumber = StateNumber(2);
                //Debug.Log("I have collided with a " + collision.tag + " object. My number is: " + decisionNumber);
                if(!leftJump && !mustTurn)
                {
                    if (decisionNumber == 1 && !bodyCollider.IsTouchingLayers(wallLayer))
                    {
                        mustTurn = false;
                    }

                    else if (decisionNumber == 2)
                    {
                        //Debug.Log("I've decided to Jump!");
                        StartCoroutine(AIJump(1));

                    }
                }
                leftJump = true;
                rightJump = rightDrop = leftDrop = false;
                break;
            default:
                break;

        }
        
        //Generates random number for AI decisions. Basically a Numerator.
        //For dual-path options: StateNumber(2)
        //For triple-path options: StateNumber(3)
        int StateNumber(int range)
        {
            return Random.Range(1,range+1);
        }

        
    }
    protected IEnumerator AIJump(int jumpSeconds)
    {
        float _speed = speed;
        speed = 0;
        //Debug.Log("JumpStart");
        yield return new WaitForSeconds(jumpSeconds);
        rb.velocity = Vector2.up * jumpForce;
        yield return new WaitForSeconds(jumpSeconds * 3/2);
        //Debug.Log("JumpEnd");
        speed = _speed;
    }

}
