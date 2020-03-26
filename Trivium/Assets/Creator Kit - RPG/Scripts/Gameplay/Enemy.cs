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
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    SpriteRenderer spriteRenderer;
    Vector2 currentVelocity;
    public float acceleration = 2;

    void Start()
    {
        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
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

    void Update()
    {
        Vector3 direction = player.position - transform.position;
      //  Debug.Log(direction);
       // float angle = (float)Math.Atan2(direction.x, direction.y)*Mathf.Rad2Deg;
       // rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        rb.velocity = Vector2.SmoothDamp(rb.velocity, direction * moveSpeed, ref currentVelocity, acceleration, moveSpeed);
        spriteRenderer.flipX = rb.velocity.x >= 0 ? true : false;
    }
    void Die()  
    {
        Debug.Log("Enemy Died!");

        animator.SetBool("IsDead", true);

        Behaviour bhvr = (Behaviour)this;
        Behaviour bhvr2 = (Behaviour)GetComponent<Collider2D>();
        rb.velocity = Vector2.zero;
        bhvr2.enabled = false;
        bhvr.enabled = false;
    }
}
