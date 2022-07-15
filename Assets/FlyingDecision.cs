using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class FlyingDecision : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AIPath>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
