using UnityEngine;

public class InvaderShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float minInterval = 1.2f;
    [SerializeField] private float maxInterval = 2.5f;
    [SerializeField] private int maxBullets = 3;
    
    private float timer;
    private PlayerController player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;

        ResetTimer();
        Shoot();
    }
    
    private void ResetTimer()
    {
        float difficulty = Mathf.Clamp(1f - GameManager.Instance.Score * 0.02f, 0.5f, 1f);
        timer = Random.Range(minInterval, maxInterval) * difficulty;
    }
    
    private void Shoot()
    {
        if (FindObjectsByType<InvaderBullet>(FindObjectsSortMode.None).Length >= maxBullets) return;

        Invader[] invaders = FindObjectsByType<Invader>(FindObjectsSortMode.None);
        if (invaders.Length == 0) return;

        Invader shooter = invaders[Random.Range(0, invaders.Length)];

        // Aim the laser at the player and rotate it into the shot direction.
        Vector3 direction = Vector3.down;
        if (player != null)
        {
            direction = (player.transform.position - shooter.transform.position).normalized;
        }

        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, direction);
        Instantiate(bulletPrefab, shooter.transform.position, rotation);
    }
}
