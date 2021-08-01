using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreator : MonoBehaviour
{
    [SerializeField] private GameObject blockOfField;
    [SerializeField] private int numberOfFieldRaws;
    [SerializeField] private int numberOfFieldColumms;

    private List<FieldBehaviour> fieldBehaviours;
    void Awake()
    {
        Init();
    }

    public static Action<List<FieldBehaviour>> OnInitFields; 
    private void Init()
    {
        fieldBehaviours = new List<FieldBehaviour>(numberOfFieldColumms * numberOfFieldRaws);
        for (int x = 0; x < numberOfFieldRaws * 2; x += 2)
        {
            for (int y = 0; y < numberOfFieldColumms * 2; y += 2)
            {
                GameObject obj = Instantiate(blockOfField, new Vector2(x, y), Quaternion.identity);
                fieldBehaviours.Add(obj.GetComponent<FieldBehaviour>());
            }
        }
        OnInitFields?.Invoke(fieldBehaviours);
    }
}
