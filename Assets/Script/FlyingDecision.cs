using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class FlyingDecision : MonoBehaviour
{
    public Transform player;
    public Transform goTransform;
    private Vector3 plPosition;
    private Vector3 goPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AIPath>().enabled = false;
        goTransform = gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        plPosition = player.position;
        goPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
