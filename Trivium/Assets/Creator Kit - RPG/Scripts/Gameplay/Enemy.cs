using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPGM.Gameplay;
using UnityEngine.U2D;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

       
    void Die()  
    {
        Debug.Log("Enemy Died!");

        animator.SetBool("IsDead", true);

        Behaviour bhvr = (Behaviour)this;
        Behaviour bhvr2 = (Behaviour)GetComponent<Collider2D>();

        bhvr2.enabled = false;
        bhvr.enabled = false;
    }
}
