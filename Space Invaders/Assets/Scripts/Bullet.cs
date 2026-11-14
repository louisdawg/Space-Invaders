using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float lifetime = 5f;
    public Rigidbody2D rb;
    private float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Fly in the direction the bullet is rotated to (its local up axis).
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * speed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Invader invader))
        {
            invader.Die();
            Destroy(gameObject);
        }
        else if (collision.TryGetComponent(out ChasingEnemy chasingEnemy))
        {
            chasingEnemy.Die();
            Destroy(gameObject);
        }
    }
}
