using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_object : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject spawn;
    bool spawnCheck = true;
    // Update is called once per frame
    private void Start()
    {
        spawnCheck = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && spawnCheck)
        {
            GameObject newSphere = Instantiate(spawn, spawnPosition.position, spawnPosition.rotation);

            //newSphere.GetComponent<MoveSphere>().sphereMove = target;
            spawnCheck = false;
        }
        if(Input.GetKeyDown(KeyCode.C) && !spawnCheck)
        {
            Debug.Log("You have already an object!");
        }
    }
}
