using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 1.5f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float chaseDistance = 10f;
    [SerializeField] private int scoreValue = 2;

    private GameManager gameManager;
    private PlayerController player;
    private Rigidbody2D rb;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        player = FindFirstObjectByType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            rb.linearVelocity = Vector2.down * normalSpeed;
            return;
        }

        Vector2 toPlayer = (Vector2)player.transform.position - rb.position;

        if (toPlayer.magnitude <= chaseDistance)
        {
            rb.linearVelocity = toPlayer.normalized * chaseSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.down * normalSpeed;
        }
    }

    private void Update()
    {
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        gameManager.TriggerGameOver();
        Destroy(gameObject);
    }

    public void Die()
    {
        gameManager.IncreaseScore(scoreValue);
        Destroy(gameObject);
    }
}
