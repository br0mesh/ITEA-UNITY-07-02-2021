using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipMove : MonoBehaviour
{
    public Rigidbody rb;

    public float runSpeed = 10f;
    public float strafeSpeed = 100f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;


    void Update()
    {
        if (Input.GetKey("a"))
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }
        if (Input.GetKey("d"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, runSpeed * Time.deltaTime);
        if (strafeLeft)
        {
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (strafeRight)
        {
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
