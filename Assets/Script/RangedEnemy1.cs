using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This script was written by Ahmet Buðra Yaþar for Lost Tales' Snowbros Project. 21.07.2022*/
public class RangedEnemy1 : Ranged, IEntity, IMob, IShooter
{
    // Start is called before the first frame update
    void Start()
    {
        enemies.Add("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            switch(collision.gameObject.tag)
            {
                case "Wall":
                    break;
                case "LeftDrop":
                    break;
                case "RightDrop":
                    break;
                case "LeftJump":
                    break;
                case "RightJump":
                    break;
            }
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    
    public void Flip()
    {
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public IEnumerator Jump()
    {
        Debug.Log(gameObject.name + "Jumped");

        //Wait for the jump countdown
        yield return new WaitForSeconds(jumpWaitTimer);
        //Set velocity for the y axis
        rb.velocity = Vector2.up * jumpForce;
        //Zero-out the X-Axis while retaining the Y-Axis
        rb.velocity.Set(0, rb.velocity.y);
        Debug.Log(gameObject.name + "Finished Jumping");
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Shoot()
    {
        //Gets the direction of entity
        //Sets the shooting direction
        int direction()
        {
            if (transform.localScale.x < 0f)
            {
                return -1;
            }
            else return 1;
        }

        //Starts the shooting sequence
        isShooting = true;
        //Creates a projectile
        //GameObject newProjectile = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        Projectile newProjectile = Instantiate<Projectile>(projectile_temp, shootPosition.position, Quaternion.identity);
        //Sets projectile's speed
        newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        //Sets projectile's direction
        newProjectile.transform.localScale = new Vector2(newProjectile.transform.localScale.x * direction(), newProjectile.transform.localScale.y);
        //Disallows shooting until shootDuration has passed
        yield return new WaitForSeconds(shootDuration);
        //Ends the shooting sequence
        isShooting = false;
    }
}
