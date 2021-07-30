using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private float direction;
    public void OnCharaterMove(float direction)
    {
        this.direction = direction;
    }
    public void OnCharacterIdle()
    {
        animator.SetBool("IsRun", false);
    }

    public void Update()
    {
        if (direction > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (direction < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("HasVelocity", direction != 0f);
        animator.SetFloat("Velocity", direction);
        direction = 0f;
    }
}
