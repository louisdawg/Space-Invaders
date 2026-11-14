using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.TakeDamage();
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        gameManager.IncreaseScore(scoreValue);
        Destroy(gameObject);
    }
}
