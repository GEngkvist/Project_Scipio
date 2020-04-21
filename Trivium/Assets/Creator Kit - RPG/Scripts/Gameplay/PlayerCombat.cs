using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPGM.Gameplay;
using UnityEngine.U2D;
using System.Threading.Tasks;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    public static float time = 2;
    public static float timer = time;

    public int maxHealth = 200;
    public int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
       
    }

    void Attack()
    {
        //Play attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            //enemy.GetComponent<EnemySkeleton>().TakeDamage(attackDamage);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            //enemy.GetComponent<EnemySkeleton>().TakeDamage(attackDamage);
        }
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            //enemy.GetComponent<EnemySkeleton>().TakeDamage(attackDamage);
            //enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemySkeleton>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            gameObject.layer = 0;
            Die();
        }
    }

    async void Die()
    {
        Debug.Log("Enemy Died!");

        animator.SetTrigger("Death");
        animator.SetTrigger("Recover");
        await Task.Delay(2000);
        gameObject.layer = 10;
        currentHealth = maxHealth;
    }

    async Task UseDelay()
    {
        await Task.Delay(2000); //wait for one second
    }




}
