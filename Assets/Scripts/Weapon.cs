using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    Camera camera; 
    int Damage;
    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;


    private void Awake()
    {
        camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent != null)
        {


            if (collision.GetComponent<Collider2D>().gameObject.CompareTag("enemy"))
            {
                Ghost ghost = collision.GetComponent<Ghost>();
                ghost.TakeDamage(Damage);



            }

        }
    }

    public void Update()
    {
        if (transform.parent != null) {
            mouse_pos = Input.mousePosition;
            mouse_pos.z = 5.23f; //The distance between the camera and object
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        }
    }

}
