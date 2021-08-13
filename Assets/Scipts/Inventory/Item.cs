
using UnityEngine;

public class Item
{
    public int ID { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public Sprite Sprite { get; set; }
    public bool Stackable { get; set; }

    public int Amount { get; set; }
    public int MaxStack { get; set; }

    public Item()
    {
        ID = -1;
    }

    public Item(int ID, string Type, string Title, bool Stackable, int Amount)
    {
        this.ID = ID;
        this.Type = Type;
        this.Title = Title;
        this.Sprite = (Sprite)Resources.Load<Sprite>("Sprites/Items/" + Title);
        if (!Sprite) Debug.LogError("Not found: " + Title);
        this.Stackable = Stackable;
        this.Amount = Amount;
        MaxStack = 99;
    }
}
