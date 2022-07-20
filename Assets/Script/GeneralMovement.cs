using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int jumpValue;
    public float jumpTimer;

    //Checks player direction, if right => player is going right
    public bool right = true;
    //For Double jump or more
    public int extraJump;

    public Transform groundCheck;
    public Rigidbody2D rb;

    
    

    /*
     * Inverses the right boolean
     * Gets the local scale of player object to Scaler
     * Multiplies the x of Scaler by -1
     * Equalizes object scale to Scaler (which the x of is multiplied by -1)
     */
    protected void Flip()
    {
        //Debug.Log(gameObject.name + " Flip!");
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    protected IEnumerator JumpStart()
    {
        Debug.Log("JumpStart");
        yield return new WaitForSeconds(jumpTimer);
        rb.velocity = Vector2.up * jumpForce;
        Debug.Log("JumpEnd");
    }
}
