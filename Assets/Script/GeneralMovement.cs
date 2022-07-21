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

    public float shootSpeed, shootTimer;
    public bool isShooting;
    public Transform shootPos;
    public GameObject bullet;


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

    public IEnumerator Shoot()
    {
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else return 1;
        }
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
    public IEnumerator AIShoot()
    {
        
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else return 1;
        }
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;

        if (right)
        {
            speed = 100;
        }
        else
        {
            speed = -100;
        }
    }
    protected void AIFlip()
    {
        //Debug.Log(gameObject.name + " Flip!");
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        StartCoroutine(AIShoot());
    }
}
