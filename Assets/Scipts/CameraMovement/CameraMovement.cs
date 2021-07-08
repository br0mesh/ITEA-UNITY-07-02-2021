using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        // transform.Translate((transform.position - target.position) * speed * Time.deltaTime);
    }
}
