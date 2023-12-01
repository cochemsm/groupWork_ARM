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
    public bool schlagen;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        schlagen = Input.GetKeyDown("mouse 1");
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = input * speed;
        if (schlagen == true) Console.WriteLine("true"); ;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("enemy"))
        {
            HP--;
            if (HP >= 0)
            {
                Onplayerdeath?.Invoke();
            
            }
            
           
        }
        
    }
    


    

}
