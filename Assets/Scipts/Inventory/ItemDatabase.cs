using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Inventory
{
    public class ItemDatabase : MonoBehaviour
    {
        private List<Item> database = new List<Item>();

        private JsonData jsonData;
        void Awake()
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/ItemsData.json");
            if (jsonString == null) Debug.LogError("Cant open ItemData file");
            jsonData = JsonMapper.ToObject(jsonString);

            ConstructItemDatabase();
        }

        public Item FletchItemByID(int id)
        {
            for (int i = 0; i < database.Count; i++)
            {
                if (database[i].ID == id)
                    return database[i];
            }
            return null;
        }

        private void ConstructItemDatabase()
        {
            for (int i = 0; i < jsonData.Count; i++)
            {
                int id = (int)jsonData[i]["id"];
                string type = jsonData[i]["type"].ToString();
                string title = jsonData[i]["title"].ToString();
                bool stackable = (bool)jsonData[i]["stackable"];
                int amount = (int)jsonData[i]["amount"];
                database.Add(new Item(id, type, title, stackable, amount));
            }
        }
    }
}
