using UnityEngine;

public class InvaderShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float minInterval = 1.2f;
    [SerializeField] private float maxInterval = 2.5f;
    [SerializeField] private int maxBullets = 3;
    
    private float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Instantiate(bulletPrefab, shooter.transform.position, Quaternion.identity);
    }
}
