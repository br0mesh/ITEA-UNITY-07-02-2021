using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    private float rotation;
    private float horizontalMovement;
    private float verticalMovement;
    private float speed;
    private bool alternativeControl;

    private void Start()
    {
        speed = 1.5f;
        alternativeControl = true;
    }
    void Update()
    {
        if (!alternativeControl)
        {
            noneAlternativeMovement();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            alternativeControl = !alternativeControl;
        }
    }
    private void FixedUpdate()
    {
        if (alternativeControl)
        {
            alternativeMovement();
        }

    }
    private void alternativeMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime*speed);
        rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0f, 0f, -rotation * speed);
    }

    private void noneAlternativeMovement()
    {
            verticalMovement = Input.GetAxis("Vertical");
            horizontalMovement = Input.GetAxis("Horizontal");
            transform.Translate(horizontalMovement * Time.deltaTime * speed, verticalMovement * Time.deltaTime * speed, 0f, Space.World);
    }
}
