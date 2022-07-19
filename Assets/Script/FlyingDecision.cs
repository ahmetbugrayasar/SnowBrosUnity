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
    private float distance;
    private float hdistance;
    private float vdistance;


    public TMPro.TextMeshPro statusText;
    [SerializeField]
    [Range(0,20)]
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
        hdistance = Mathf.Abs(plPosition.x - goPosition.x);
        vdistance = Mathf.Abs(plPosition.y - goPosition.y);
        if(hdistance < distanceThreshold && vdistance <= 3)
        {
            statusText.text = "REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEe!";
            statusText.color = Color.red;
            gameObject.GetComponent<AIPath>().enabled = true;
            gameObject.GetComponent <AIPatrol> ().enabled = false;
        }
        else
        {
            statusText.text = "Patrolling!";
            statusText.color = Color.green;
            gameObject.GetComponent<AIPath>().enabled = false;
            gameObject.GetComponent<AIPatrol>().enabled = true;
        }
    }
    // Update is called once per frame
    

}
