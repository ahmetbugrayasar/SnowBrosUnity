using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To continue go to this link: https://youtu.be/K4loGbMWm80?t=180
public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    public bool isShooting;
    public Transform shootPos;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isShooting == false)
            {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
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
        GameObject newBullet = Instantiate(bullet,shootPos.position,Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
