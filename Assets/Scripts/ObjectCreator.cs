using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{

    public GameObject obj;
    void Start()
    {
        Instantiate(obj,transform.position,Quaternion.identity);
    }
}
