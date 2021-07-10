using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorLesson : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject groundHolder;
    [SerializeField] private int groundSize = 100;
    [SerializeField] private GameObject characterPrefab;
    private void Start()
    {
        GenerateGround();
        SpawnCharacter();
    }
    private void GenerateGround()
    {
        for(int i = 0; i < groundSize; i++)
        {
            GameObject groundTile = Instantiate(tilePrefab,groundHolder.transform);
            groundTile.transform.position = new Vector3(-groundSize / 2+i,0,0);
        }
    }
    private void SpawnCharacter()
    {
        Instantiate(characterPrefab);
    }
}
