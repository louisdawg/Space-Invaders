using UnityEngine;

public class InvaderBullet : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float lifetime = 6f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // The shooter sets the rotation; the laser flies along its local up axis.
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * speed;
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
