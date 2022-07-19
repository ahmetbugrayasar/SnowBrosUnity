using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : GeneralMovement
{
    
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;   
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f,groundLayer);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
            speed *= -1;
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime,rb.velocity.y);

    }


}
