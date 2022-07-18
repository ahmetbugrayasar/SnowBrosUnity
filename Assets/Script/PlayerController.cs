using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GeneralMovement
{

    private float moveInput;

    //Checks if player is standing on the ground
    private bool isGrounded = true;
    
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        

        /* FLIP
         * If the object is looking left and moving right
           or if the object is looking right and moving left */
        if ((right == false && moveInput > 0) || (right == true && moveInput < 0))
        {
            Flip();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            //anim.SetBool("isJumping",false);
            extraJump = jumpValue;
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJump > 0)
        {
            
            //anim.SetBool("isJumping", true);
            StartCoroutine(JumpStart());
            extraJump -= 1;

        }
        else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))&& extraJump == 0 && isGrounded == true)
        {
            
            //anim.SetBool("isJumping", true);
            StartCoroutine(JumpStart());

        }
    }

}
