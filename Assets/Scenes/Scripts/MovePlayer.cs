using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        Vector3 direction = transform.right * hor;
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
