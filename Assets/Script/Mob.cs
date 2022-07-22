using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This script was written by Ahmet Buðra Yaþar for Lost Tales' Snowbros Project. 21.07.2022*/

/*
 * Mobs in SnowBros delay their actions for various miliseconds. So each mob entity will have an IMob interface.
 *
        Wait() : Basically just a timer. Every function defined for a Mob will call the Wait() function.
 */
public interface IMob
{
    IEnumerator Wait();
}

public abstract class Mob : Entity
{

    //Checks if Mob should move through the scene.
    public bool mustPatrol;
    //Checks if Mob should turn if encountered a wall.
    private bool mustTurn;

    /*
         * There are 4 tags:
         *      dropLeft: One ON the left boundary of the plane. Here, the AI has two options.
         *      It will select to either drop down or turn back.
         *      
         *      dropRight: One ON the right boundary of the plane. Here the AI has two options.
         *      It will randomly select between dropping down or turning back
         *      
         *      jumpLeft: One BELOW the left boundary of the plane. Here the AI has two options.
         *      It will randomly select between jumping up or going straight ahead.
         *      
         *      jumpRight: One BELOW the right boundary of the plane. Here the AI has two options.
         *      It will randomly select between jumping up or going straight ahead.
         *      
         *      Booleans below check if Mob has collided with any.
         
    */
    public bool dropLeft,dropRight,
                jumpLeft,jumpRight;

    //NumericalValue for the movement decision of all Mobs.
    public int decisionValue;
}
