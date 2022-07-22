using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This script was written by Ahmet Buðra Yaþar for Lost Tales' Snowbros Project. 21.07.2022*/

//We don't want the Mobs to commit suicide or friendly fire. Therefore, we need multiple types of projectiles to prevent this.
public enum ShooterType { type_Player, type_Mob };

public class Projectile : MonoBehaviour
{
    //The GameObject of Projectile Class.
    public GameObject GO;

    //Collider2D of Projectile Class
    Collider2D projectileCollider;

    //The particle effect for the projectile Class for when destroyed
    public GameObject diePEffect;

    //Projectile will disappear after a while. This is to prevent too many projectiles at once. That "while" is the dieTime.
    public float dieTime;

    //Declaring a ShooterType variable
    public ShooterType type;


    // Start is called before the first frame update
    void Start()
    {
        
        GO = gameObject;
        projectileCollider = GO.GetComponent<Collider2D>();
        //As soon as the projectile is created, the Timer starts ticking down.
        StartCoroutine(Timer());
    }

    //Countdown function to destroy the projectile object.
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    //Creates the particle effect (if there is any) and destroys the projectile object.
    void Die()
    {
        if (diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //GameObject variable to hold what projectile has collided with
        GameObject collisionGameObject = collision.gameObject;

        //Enable bullets to go through the ground
        if (collisionGameObject.tag == "Ground")
        {
            Physics2D.IgnoreCollision(collision.collider, projectileCollider);
        }

            switch (type)
            {
            case ShooterType.type_Player:
                //As long as the bullet hasn't collided with the player
                if (collision.gameObject.tag != "Player" )
                {
                    //And as long as the collided entity is an Enemy type
                    if (
                       (collisionGameObject.tag == "Enemy"  ||
                        collisionGameObject.tag == "Ranged" ||
                        collisionGameObject.tag == "Flying"  )
                       )
                    {
                        //Destroy what the projectile touched
                        Destroy(collisionGameObject);
                    }
                    //And destroy itself
                    Die();
                 
                }
                break;
            case ShooterType.type_Mob:
                
                //If the projectile touches an enemy, it will ignore it and move on
                if (
                       (collisionGameObject.tag == "Enemy"  ||
                        collisionGameObject.tag == "Ranged" ||
                        collisionGameObject.tag == "Flying"  )
                   )
                {
                    Physics2D.IgnoreCollision(projectileCollider, collision.collider);
                }
                //But if the projectile touches a player, it will destroy the player.
                else if(collisionGameObject.tag == "Player")
                {
                    Destroy(collisionGameObject);
                }
                //And destroy itself
                Die();

                break;
            }
    }
}
