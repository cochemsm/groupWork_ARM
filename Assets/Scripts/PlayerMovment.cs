using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
     public float speed = 0;
     public float input = 0;

    public void Update()
    {
        input = Input.GetAxis("Horizontal");
        input = Input.GetAxis("Vertical");

    }



}
