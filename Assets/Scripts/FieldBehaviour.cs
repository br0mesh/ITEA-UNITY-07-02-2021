using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] new string name;
    public string Name { get => name; }
    [SerializeField] private bool empty;
    public bool NamefieldName { get => empty; }

    public static Action<FieldBehaviour> OnMouseDownField { get; set; }

    public void Init(FieldsSriptableObjects fieldsSriptableObjects)
    {
        sprite.sprite = fieldsSriptableObjects.sprite;
        name = fieldsSriptableObjects.Name;
        empty = false;
        
    }

    public void OnMouseDown()
    {
        OnMouseDownField?.Invoke(this);
    }
    
}
