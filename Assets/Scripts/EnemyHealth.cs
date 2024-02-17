using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    private void Start()
    {

    }
    public void GetDamage(int amount)
    {
        health -= amount;


        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
