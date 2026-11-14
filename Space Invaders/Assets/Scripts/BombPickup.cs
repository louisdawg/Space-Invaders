using UnityEngine;

// Zusatzfeature: Nova-Bombe
// Der PowerUpSpawner lässt gelegentlich eine Bombe statt des Doppelschusses fallen.
// Hebt der Spieler sie auf, werden alle Invader und ChasingEnemies zerstört
// und ihre Punkte dem Score gutgeschrieben.
public class BombPickup : MonoBehaviour
{
    [SerializeField] private float lifetime = 8f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Invader[] invaders = FindObjectsByType<Invader>(FindObjectsSortMode.None);
        foreach (Invader invader in invaders)
        {
            invader.Die();
        }

        ChasingEnemy[] chasingEnemies = FindObjectsByType<ChasingEnemy>(FindObjectsSortMode.None);
        foreach (ChasingEnemy chasingEnemy in chasingEnemies)
        {
            chasingEnemy.Die();
        }

        Destroy(gameObject);
    }
}
