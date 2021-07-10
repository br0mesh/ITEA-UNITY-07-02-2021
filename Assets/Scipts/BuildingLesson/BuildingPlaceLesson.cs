using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.BuildingLesson
{
    public class BuildingPlaceLesson : MonoBehaviour
    {
        [SerializeField] private BaseBuildingLesson building;

        [ContextMenu("Build")]
        public void Build()
        {
            building.Spawn(transform);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<CharacterLesson.CharacterLesson>(out var character))
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                return;
            }
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }
        
    }

}
