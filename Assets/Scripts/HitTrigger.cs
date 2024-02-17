using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    public int damage;
    Animator animator;

    private void Start()
    {
        animator= GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.GetComponent<EnemyBanditBehaviour>().TakeDamage(damage);
        }
        if(collision.transform.tag == "Player")
        {
            collision.GetComponent<CharacterStats>().TakeDamage(damage);
            Debug.Log("damage yedi");
        }
    }
}
