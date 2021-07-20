using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementComponent : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Transform Target { get => target; }

    public Action OnTargetReached { get; set; }
    public Action<Transform> OnTargetSet { get; set; }

    [ContextMenu("Set Target")]
    public void test()
    {
        SetTarget(target);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        StartCoroutine(MoveToTarget());
        OnTargetSet?.Invoke(target);
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector2.Distance(transform.position, target.position) > 0.1f)
        {
            Vector2 targetPos = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime);

            yield return null;
        }
    }
}
