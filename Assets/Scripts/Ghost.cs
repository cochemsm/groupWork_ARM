using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class Ghost : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private new Rigidbody2D rigidbody2D;
    private Enemy enemy;

    public float movementSpeed = 3f;
    public int hitPoints = 2;
    public int attackDamage = 1;

    private void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponentInChildren<GameManager>();
        //player = gameManager.player;
        player = GameObject.Find("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        GhostMovement(player.transform.position);
    }

    private void GhostMovement(Vector3 targetPosition)
    {
        Vector2 moveDirection =
            new Vector2(targetPosition.x - transform.position.x, 
                        targetPosition.y - transform.position.y);
        moveDirection = moveDirection.normalized;
        print(moveDirection);

        rigidbody2D.velocity = moveDirection * movementSpeed;
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;
        if (hitPoints <= 0)
            enemy.OnDeath.Invoke(this.gameObject);
    }
}
