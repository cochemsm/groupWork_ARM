using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
     public float speed = 0;
     public Vector2 input;




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


}
