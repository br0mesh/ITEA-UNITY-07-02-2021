using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public Transform sphereMove;
    void FixedUpdate ()
    {
        transform.position = sphereMove.position;
    }
}
