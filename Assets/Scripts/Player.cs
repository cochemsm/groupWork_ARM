using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    Rigidbody2D rigidbody2d;
    public float speed = 0;
    public Vector2 input;

    public delegate void playerdeath();
    public event playerdeath Onplayerdeath;

    public int HP;
    public int damage;
    public int MaxHP = 10;

    public bool inweapon = false;
    GameObject weapon;

    private Image healthBar;

    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        healthBar = GameObject.FindGameObjectWithTag("playerHealth").GetComponent<Image>();
    }

    private void Start() {
        healthBar.fillAmount = HP / MaxHP;
    }

    private void Update() {
        if (HP == 0) {
            speed = 0;
            transform.DetachChildren();
        }
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        if (inweapon == true && Input.GetKey(KeyCode.E)) {
            transform.GetChild(0).DetachChildren();
            weapon.transform.SetParent(transform.GetChild(0));
            weapon.transform.localPosition = Vector2.zero;
        }
    }

    private void FixedUpdate() {
        rigidbody2d.velocity = input * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("wall")) {
            rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x, -rigidbody2d.velocity.y);
        }

        if (collision.gameObject.CompareTag("weapon")) {
            weapon = collision.gameObject;
            inweapon = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("weapon")) {
            weapon = collision.gameObject;
            inweapon = false;
        }
    }

    public void Heal(int healingAmount) {
        if (HP + healingAmount <= MaxHP) {
            HP = HP + healingAmount;
        } else {
            HP = MaxHP;
            GameManager.Instance.Wait(2);
            healthBar.gameObject.SetActive(false);
        }

        healthBar.fillAmount = HP / MaxHP;
    }

    public void Damage(int damageAmount) {
        if (HP - damageAmount < 0) {
            HP = 0;
        } else {
            HP = HP - damageAmount;
        }
        healthBar.gameObject.SetActive(true);
        healthBar.fillAmount = HP / MaxHP;
    }
}