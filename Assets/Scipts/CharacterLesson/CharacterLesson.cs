using Assets.Scipts.BuildingLesson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scipts.CharacterLesson
{
    public class CharacterLesson : MonoBehaviour
    {
        [SerializeField] private BuildingPlaceLesson buildingPlace;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var buildingPlace = collision.gameObject.GetComponent<BuildingLesson.BuildingPlaceLesson>();
            if (buildingPlace != null)
            {
                this.buildingPlace = buildingPlace;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            var buildingPlace = collision.gameObject.GetComponent<BuildingLesson.BuildingPlaceLesson>();
            if (buildingPlace != null)
            {
                this.buildingPlace = null;
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (buildingPlace != null)
                {
                    buildingPlace.Build();
                }
            }
        }
    }
}
