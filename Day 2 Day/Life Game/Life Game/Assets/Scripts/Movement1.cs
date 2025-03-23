using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask Solid;
    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!isMoving)
        {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input.x != 0) input.y = 0; // Removes diagonal movement

    {   
        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);

        var targetPos = transform.position;
        targetPos.x += input.x;
        targetPos.y += input.y;

        if(IsWalkable(targetPos))
            StartCoroutine(Move(targetPos));
    }   

    }
    animator.SetBool("isMoving", isMoving);
}
    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private bool IsWalkable(Vector3 targetPos)
    {
       if (Physics2D.OverlapCircle(targetPos, .3f, Solid) != null)
        {
            return false;
        }
        return true;
    }
}
