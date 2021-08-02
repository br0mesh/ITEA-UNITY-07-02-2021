using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Components.InputComponents
{
    public class CharacterInputKeyComponent : CharacterBaseInputComponent
    {
        void Update()
        {
            float moveInput = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                moveInput = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveInput = 1;
            }

            if (moveInput != 0f)
            {
                OnCharacterMove?.Invoke(moveInput);
            }
            else
            {
                OnCharacterIdle?.Invoke();
            }

            if(Input.GetKey(KeyCode.Mouse0))
            {
                OnCharacterAttack?.Invoke();
            }

            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                OnCharacterBlock?.Invoke(false);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                OnCharacterBlock?.Invoke(true);
            }
        }
    }
}
