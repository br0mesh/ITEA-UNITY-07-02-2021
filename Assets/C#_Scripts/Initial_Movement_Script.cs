using UnityEngine;

public class Initial_Movement_Script : MonoBehaviour
{
    int counter = 0;

    [SerializeField]
    int speedIndex = 5;


    //FixedUpdate will process Physics, no mater what FPS is.
    private void FixedUpdate()
    {
        if (counter <= 300)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speedIndex);

            counter++;
        }
    }
}
