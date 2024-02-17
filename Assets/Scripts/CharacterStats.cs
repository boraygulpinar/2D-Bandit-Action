using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    // UI
    public Image[] hearts;

    // Stats
    public int health = 5;
    int maxHealth = 5;

    public GameObject restartButton;
    public GameObject congratsText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(health == 0)
        {
            RestartButton();
        }

    }

    public void TakeDamage(int amount)
    {
        hearts[health-1].enabled = false;
        health -= amount;

        rb.AddForce(Vector2.left * 4000);

        animator.SetTrigger("hurt");
    }

    public void Regen(int amount)
    {

        health += amount;
        for(int i = 0; i < health; i++)
        {
            hearts[i].enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Health" && health <5)
        {
            Regen(1);
            GameObject.Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacles")
        {
            health = 0;
            Debug.Log("temas");
        }
    }
    
    private void RestartButton()
    {
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }


}
