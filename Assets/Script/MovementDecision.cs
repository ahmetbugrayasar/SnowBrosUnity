using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MovementDecision : MonoBehaviour
{
    public Transform player;
    public Transform goTransform;
    private Vector3 plPosition;
    private Vector3 goPosition;
    private float distance;
    [SerializeField]
    [Range(0, 20)]
    public float distanceThreshold = 10;
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
        distance = Vector3.Distance(plPosition, goPosition);
        if (distance < distanceThreshold)
        {
            Debug.Log("Distance is lower than distance Threshold");
            gameObject.GetComponent<AIPath>().enabled = true;
            gameObject.GetComponent<AIPatrol>().enabled = false;
        }
        else
        {
            Debug.Log("Distance is higher than distance Threshold");
            gameObject.GetComponent<AIPath>().enabled = false;
            gameObject.GetComponent<AIPatrol>().enabled = true;
        }
    }
}
