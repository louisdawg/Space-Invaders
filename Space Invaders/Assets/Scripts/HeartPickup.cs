using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] private float lifetime = 8f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (GameManager.Instance.TryAddLife())
        {
            Destroy(gameObject);
        }
    }
}