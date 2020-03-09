using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPGM.Gameplay;
using UnityEngine.U2D;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos = null;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    void update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.G))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                timeBtwAttack = startTimeBtwAttack;
            }

        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }


    } 
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
