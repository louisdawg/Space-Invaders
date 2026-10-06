using UnityEngine;

public class Invader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Lives--;
            Destroy(gameObject);
        }
    }
}