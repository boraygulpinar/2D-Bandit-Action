using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    public int damage;

    Animator animator;
    Rigidbody2D rb;

    bool canJump = true;
    bool faceRight = true;
    bool canAttack = true;

    Vector2 forward;
    public Vector3 offset;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            animator.SetBool("jump", true);
        }
        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            Attack();
        }
    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (moveInput > 0 && faceRight == false)
        {
            Flip();
        }
        if (moveInput < 0 && faceRight == true)
        {
            Flip();
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            canJump = true;
            animator.SetBool("jump", false);
        }
    }
    private void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            canJump = false;
            
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = gameObject.transform.localScale;
        scaler.x *= -1;
        gameObject.transform.localScale = scaler;
    }

    private void Attack()
    {
        canAttack = false;

        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2);
        }
        else
        {
            forward = transform.TransformDirection(Vector2.right * 2);
        }

        animator.SetTrigger("attack");
        StartCoroutine(AttackDelay());
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }


}