using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWalk : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Animator animator;
    int a = 1, b = 1, c = 1, d = 1;

 
    void Start()
    {
        animator = GetComponent<Animator>();
    }  

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (verticalInput < 0&&a==1)
        {
            animator.SetTrigger("isZheng");
            a = 2;
        }
        if (verticalInput == 0 && a == 2)
        {
            animator.SetTrigger("idleZheng");
            a = 1;
        }
        if (verticalInput > 0&&b==1)
        {
            animator.SetTrigger("isHou");
            b = 2;
        }
        if (verticalInput == 0 && b == 2)
        {
            animator.SetTrigger("idleHou");
            b = 1;
        }
        if (horizontalInput < 0&&c==1)
        {
            animator.SetTrigger("isLeft");
            c = 2;
        }
        if (horizontalInput == 0 && c == 2)
        {
            animator.SetTrigger("idleLeft");
            c = 1;
        }
        if (horizontalInput > 0&& d==1)
        {
            animator.SetTrigger("isRight");
            d = 2;
        }
        if (horizontalInput == 0 && d == 2)
        {
            animator.SetTrigger("idleRight");
            d = 1;
        }
    }
}
