using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class Ghost : MonoBehaviour
{
    private GameManager gameManager;
    private Player player;
    private new Rigidbody2D rigidbody2D;
    private Enemy enemy;

    public float movementSpeed = 3f;
    public int hitPoints = 2;
    public int attackDamage = 1;

    // In which frame should the action be done in FixedUpdate.
    public int attackTick = 50;
    private int currentTick = 0;
    private bool isAttacking = false;
    
    private void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponentInChildren<GameManager>();
        //player = gameManager.player;
        player = GameObject.Find("Player").GetComponent<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        GhostMovement(player.transform.position);
    }

    private void FixedUpdate()
    {
        currentTick++;
        if (currentTick == attackTick)
        {
            HandleTick();
            currentTick = 0;
        }
        print(isAttacking);
        print(currentTick);
    }
    
    private void HandleTick()
    {
        isAttacking = false;
        print("Tick!");
    }

    private void GhostMovement(Vector3 targetPosition)
    {
        Vector2 moveDirection =
            new Vector2(targetPosition.x - transform.position.x, 
                        targetPosition.y - transform.position.y);
        moveDirection = moveDirection.normalized;

        rigidbody2D.velocity = moveDirection * movementSpeed;
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;
        if (hitPoints <= 0)
            enemy.StartEvent(); Destroy(this.gameObject);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isAttacking) return;
            print("Player takes Damage");
            isAttacking = true;
        }
    }
}
