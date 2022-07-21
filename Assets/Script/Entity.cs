using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script was written by Ahmet Buðra Yaþar for Lost Tales' Snowbros Project. 21.07.2022*/

/*All entities within this game whether Mob or player will be able to move, flip, jump or die
 * 
        Move() : There are 2 variations of the Move() function.
       ----------
     1-) Mobs
        Mobs will communicate with the ground they're walking on while moving. There are 4 spots for each platform.
     These allow for mobs to decide on whether or not will they Flip, Jump, or go ahead and drop to a lower platform.
     2-) Players
         Players will move according to the input given from the user. These inputs are Jump, Move and Shoot.
 *
       Flip() : Basic flip function for all entities.
     ----------
        If the entity decides to go the other way it was going
    The velocity will be inversed and the sprite will be scaled to -1 horizontally.
 *
       Jump() : Basic Jump function for all entities.
     ----------
        Jump function will add a force to the Y-Vector of an entity
    While also zeroing-out the X-Vector.
 *
       Death() : Removing an entity whence it's shot.
     -----------
        Once a Melee user interacts with a player
    or a bullet interacts with any entity
    We will remove the collided object from the game.
*/
public interface IEntity
{
    void Move();
    void Flip();

    /*
     * Jump Function waits for the JumpWaitTimer, then adds a positive Y vector while zeroing-out any X vector for the object.
     */
    IEnumerator Jump();
    void Death();
}

public abstract class Entity : MonoBehaviour
{
    //Movement speed of entity, Horizontal change
    [SerializeField]
    [Range(0f,10f)]
    public float speed;

    //Jump Force of entity, Vertical change
    [SerializeField]
    [Range(0f,10f)]
    public float jumpForce;

    //How many jumps can an entity make before landing
    [SerializeField]
    [Range(0,4)]
    public int jumpAmount = 1;

    //The wait time before the jump occurs. 0 for player.
    [SerializeField,Range(0,4)]
    public float jumpWaitTimer;

    //Checks Entity direction. If right => true, then the object is facing right.
    public bool right = true;

    //Transform to check if object is touching the ground.
    public Transform groundCheck;
    
    //Access and alter the Rigidbody components of Entity
    public Rigidbody2D rb;

    //To animate the actions of Entity.
    private Animator anim;

    //Generates random number for AI decisions. Basically a Numerator.
    //For dual-path options: StateNumber(2)
    //For triple-path options: StateNumber(3)
    protected int StateNumber(int range)
    {
        return Random.Range(1, range + 1);
    }
}
