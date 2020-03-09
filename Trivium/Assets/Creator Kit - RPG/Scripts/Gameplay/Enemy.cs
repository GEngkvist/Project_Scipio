using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPGM.Gameplay;
using UnityEngine.U2D;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage TAKEN!");
    }
}
