using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{ 
    private const float MAX_SPEED = 5f;
    private const int CHANGE_DIRECTION_THRESHOLD = 2;

    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private int changeDirectionCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void  OnCollisionEnter2D(Collision2D collision)
    { 
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        var angle = Vector3.Angle(lastVelocity.normalized, direction);
        if (angle == 180 || (angle > 80 && angle < 110) || hasReachedChangeDirectionThreshold()) {
            direction = Random.insideUnitCircle.normalized;
        }
        Debug.Log(angle);

        rb.velocity = direction * MAX_SPEED;

        if (hasReachedChangeDirectionThreshold()) {
            resetChangeDirectionCount();
        } else {
            incrementChangeDirectionCount();
        }

        new GameData().Money += 1f;
    }

    private bool hasReachedChangeDirectionThreshold() 
    {
        return changeDirectionCount == CHANGE_DIRECTION_THRESHOLD;
    }

    private void resetChangeDirectionCount() 
    {
        changeDirectionCount = 0;
    }

    private void incrementChangeDirectionCount() {
        changeDirectionCount += 1;
    }
}
