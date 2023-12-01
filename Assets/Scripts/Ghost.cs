using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class Ghost : MonoBehaviour
{
    private GameManager gameManager;
    private Player player;
    private new Rigidbody2D rigidbody2D;
    private Enemy enemy;

    [Space(20)]
    [Range(1,10)]
    public float movementSpeed = 3f;
    [Space(5)]

    // In which frame should the action be done in FixedUpdate.
    [Range(1,50)]
    public int attackRatePerSecond = 1;
    private int attackTick;
    private int currentTick;
    private bool isAttacking;
    
    [Space(20)]
    public int attackDamage = 1;
    public int hitPoints = 2;
    
    private void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponentInChildren<GameManager>();
        //player = gameManager.player;
        player = GameObject.Find("Player").GetComponent<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        attackTick = 50 / attackRatePerSecond;
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
            isAttacking = false;
            currentTick = 0;
        }
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
            // player.TakeDamage(attackDamage);
            isAttacking = true;
        }
    }
}
