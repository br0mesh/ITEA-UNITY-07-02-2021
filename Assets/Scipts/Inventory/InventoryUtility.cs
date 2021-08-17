using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

namespace Assets.Scipts.Inventory
{
    public class InventoryUtility
    {
        public Item[] Load(string path = "/Resources/ItemsDataInventory.json")
        {
            JsonData jsonData;
            string jsonString = File.ReadAllText(Application.dataPath + path);
            if (jsonString == null) Debug.LogError("Cant open ItemData file");
            jsonData = JsonMapper.ToObject(jsonString);

            Item[] items = JsonMapper.ToObject<Item[]>(jsonString);

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    items[i].SetSprite();
                }
            }
            return items;
        }
        public void Save(Item[] items)
        {
            string a = JsonMapper.ToJson(items);

            File.WriteAllText(Application.dataPath + "/Resources/ItemsDataInventory.json", a);
        }
    }
}
