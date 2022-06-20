using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    
    //Checks player direction, if right => player is going right
    private bool right = true;

    //Checks if player is standing on the ground
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private Rigidbody2D rb;

    //For Double jump or more
    private int extraJump;
    public int jumpValue;
    public float jumpTimer;

    // Start is called before the first frame update
    void Start()
    {
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
            extraJump = jumpValue;
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump -= 1;

        }
        else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))&& extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
    }

    /*
     * Inverses the right boolean
     * Gets the local scale of player object to Scaler
     * Multiplies the x of Scaler by -1
     * Equalizes object scale to Scaler (which the x of is multiplied by -1)
     */
    void Flip()
    {
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    IEnumerator JumpStart()
    {
        Debug.Log("JumpStart");
        yield return new WaitForSeconds(jumpTimer);
        rb.velocity = Vector2.up * jumpForce;
        Debug.Log("JumpEnd");
    }
}
