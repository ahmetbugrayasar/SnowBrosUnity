using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This script was written by Ahmet Buðra Yaþar for Lost Tales' Snowbros Project. 21.07.2022*/


public class Player : MonoBehaviour,IEntity,IShooter
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {

    }

    public void Flip()
    {

    }

    public IEnumerator Jump()
    {
        yield return new WaitForSeconds(1);
    }

    public void Death()
    {

    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
    }
}
