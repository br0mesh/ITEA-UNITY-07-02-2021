
using System;
using UnityEngine;

[Serializable]
public class Item
{
    public int ID;
    public string Type;
    public string Title;
    [NonSerialized]private Sprite sprite;
    public bool Stackable;
    public int Amount;
    public int MaxStack;

    public Item()
    {

    }
    public Item(int ID, string Type, string Title, bool Stackable, int Amount)
    {
        this.ID = ID;
        this.Type = Type;
        this.Title = Title;
        SetSprite();
        this.Stackable = Stackable;
        this.Amount = Amount;
        MaxStack = 99;
    }

    public void SetSprite()
    {
        this.sprite = (Sprite)Resources.Load<Sprite>("Sprites/Items/" + Title);
        if (!sprite) Debug.LogError("Not found: " + Title);
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
}
