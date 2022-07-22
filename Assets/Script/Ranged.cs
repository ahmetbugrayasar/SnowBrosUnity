using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This script was written by Ahmet Buðra Yaþar for Lost Tales' Snowbros Project. 21.07.2022*/
/*
 * All ranged entities (Including the player) need a Shooting function. Therefore IShooter Interface is needed.
 * 
        Shoot() : Spawns a projectile from the position of the entity towards the direction it faces.
 *
 */
public interface IShooter
{
    IEnumerator Shoot();
}

public abstract class Ranged : Mob
{

    //How fast the projectile will traverse
    [SerializeField]
    [Range(0f,500f)]
    public float shootSpeed;

    //The time between each shot
    [SerializeField]
    [Range(0f,1f)]
    public float shootDuration;
    
    //To check if shootDuration has passed
    public bool isShooting;

    //The position projectiles are gonna spawn from
    [Tooltip("Create an empty game object as the child of the ranged unit and choose it as the Shoot Position")]
    public Transform shootPosition;

    //The prefab of the projectile
    [Tooltip("Choose a prefab as the projectile")]
    public GameObject projectile;

    public Projectile p_projectile;
    private void Start()
    {
        
    }


    // Start is called before the first frame update

}
