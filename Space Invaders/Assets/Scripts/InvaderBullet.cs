using UnityEngine;

public class InvaderBullet : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float lifetime = 6f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}
