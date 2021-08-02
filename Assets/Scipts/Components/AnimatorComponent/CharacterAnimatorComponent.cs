using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorComponent : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Transform parentTransform;
    private float direction;
    private bool isAttack;

    public Action OnAttackExecuted;

    public void Init(Transform transform)
    {
        parentTransform = transform;
    }
    public void OnCharaterMove(float direction)
    {
        if(isAttack)
        {
            return;
        }
        this.direction = direction;
    }
    public void OnCharacterIdle()
    {
        animator.SetBool("IsRun", false);
    }
    public void OnCharacterAttack()
    {
        //if (direction != 0)
        //{
        //    return;
        //}
        animator.SetTrigger("IsAttackTriger");
        isAttack = true;
        //animator.SetBool("IsAttack", isAttack);
    }
    public void ExecuteAttack()
    {
        OnAttackExecuted?.Invoke();
        Debug.Log("ExecuteAttack");
        isAttack = false;
        //animator.SetBool("IsAttack", isAttack);
    }

    public void Update()
    {
        if (direction > 0)
            parentTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (direction < 0)
            parentTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("HasVelocity", direction != 0f);
        animator.SetBool("IsAttack", isAttack);
        
        //isAttack = false;
        direction = 0f;
    }
}
