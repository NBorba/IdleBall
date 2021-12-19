using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private const float CURR_SPEED = 100f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        rb.AddForce(transform.right * CURR_SPEED);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
