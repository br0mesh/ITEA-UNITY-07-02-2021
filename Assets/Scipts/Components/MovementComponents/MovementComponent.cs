using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components.MovementComponents
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Transform transformToMove;

        public void Init(Transform transform)
        {
            transformToMove = transform;
        }
        public void Move(float direction)
        {
            float velocity = Mathf.MoveTowards(transformToMove.position.x, transformToMove.position.x + direction, speed * Time.deltaTime);
            transformToMove.position = new Vector2(velocity, transformToMove.position.y);
        }
    }
}
