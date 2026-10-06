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
        GetComponent<Rigidbody2D>().linearVelocity = Vector3.up * speed;
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
        if (collision.gameObject.CompareTag("Invader"))
        {
            GameManager.Instance.Score++;
            Debug.Log("Score: " + GameManager.Instance.Score);

            UIManager.Instance.UpdateScore();
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
