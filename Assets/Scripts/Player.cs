using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 0;
    public Vector2 input;
    public float HP;
    public delegate void playerdeath();
    public event playerdeath Onplayerdeath;
    public int damage;
    public int MaxHP = 10;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = input * speed;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("wall"))
       {
            rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x, -rigidbody2d.velocity.y);

        }


    }

       
    public void Heal(int healingAmount)
    {

        if (HP + healingAmount <= MaxHP)
        {

            HP = HP + healingAmount;
        }
        else
        {
            HP = MaxHP;
        }
    }




}
