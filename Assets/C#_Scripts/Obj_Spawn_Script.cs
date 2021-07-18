using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Spawn_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab; //Adds a prefab field to Inspector


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
