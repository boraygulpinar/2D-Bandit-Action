using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBanditBehaviour : MonoBehaviour
{
    public int health;
    public int speed;
    public int turnDelay;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int amount)
    {
        animator.SetTrigger("hurt");
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            animator.SetTrigger("attack");
            collision.transform.GetComponent<CharacterStats>().TakeDamage(1);
        }
    }
}
