using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPGM.Gameplay;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

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

    public Transform playerRange;
    public float attackRange = 0.5f;
    public LayerMask Player;
    bool run = false;
    //Collider2D[] playerArray;
    //Collider2D[] playerAttackArray;
    public Transform playerAttackRange;
    public float directAttackRange = 0.5f;
    public int attackDamage = 40;
    Vector3 direction;
    float TimeForAttack, Cooldown;
    public string levelName;

    void Start()
    {
        Cooldown = 0.5f;
        TimeForAttack = Cooldown;
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

            if (gameObject.name == "Boss")
            {
                SceneManager.LoadScene(levelName);
            }

        }
    }

    void Update()
    {
        direction = player.position - transform.position;
        //  Debug.Log(direction);
        // float angle = (float)Math.Atan2(direction.x, direction.y)*Mathf.Rad2Deg;
        // rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        Collider2D[] playerArray = Physics2D.OverlapCircleAll(playerRange.position, attackRange, Player);
        Collider2D[] playerAttackArray = Physics2D.OverlapCircleAll(playerAttackRange.position, directAttackRange, Player);

        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (Collider2D Player in playerArray)
        {
            foreach (Collider2D PlayerToAttack in playerAttackArray)
            {
                    Attack();
            }
            moveCharacter(movement);
        }


        //moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        animator.SetBool("run", true);
        animator.SetTrigger("running");
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

    void Attack()
    {
        Collider2D[] playerAttackArray = Physics2D.OverlapCircleAll(playerAttackRange.position, directAttackRange, Player);
        foreach (Collider2D PlayerToAttack in playerAttackArray)
        {
            animator.ResetTrigger("running");
            animator.SetBool("run", false);
            direction.x = 0;
            direction.y = 0;
            direction.z = 0;
            direction.Normalize();
            movement = direction;
            if (TimeForAttack > 0)
            {
                TimeForAttack -= Time.deltaTime;
            }
            else if (TimeForAttack <= 0)
            {
                 PlayerToAttack.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
                 TimeForAttack = Cooldown;
            }
            animator.SetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }
    }

    void OnDrawGizmosSelected()
    {
        //if (attackPoint == null)
        //{
           // return;
        //}
        Gizmos.DrawWireSphere(playerRange.position, attackRange);
        Gizmos.DrawWireSphere(playerAttackRange.position, directAttackRange);
    }
}
