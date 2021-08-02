using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components
{
    public class BlockComponent : MonoBehaviour
    {
        private Collider2D collider2D;

        public void Init(Collider2D collider2D)
        {
            this.collider2D = collider2D;
        }
        public void Block(bool value)
        {
            collider2D.enabled = value;
        }
    }
}
