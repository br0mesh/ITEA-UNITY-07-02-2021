using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    public void OnCharaterMove(float direction)
    {
        animator.SetFloat("Velocity", direction);
        //animator.SetBool("IsRun", true);
    }
    public void OnCharacterIdle()
    {
        animator.SetBool("IsRun", false);
    }
}
