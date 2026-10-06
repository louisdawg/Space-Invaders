using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 9.6f;
    [SerializeField] private float minInterval = 10f;
    [SerializeField] private float maxInterval = 20f;

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

        if (FindFirstObjectByType<PowerUpPickup>() is not null) return;

        float x = Random.Range(minX, maxX);
        Instantiate(powerUpPrefab, new Vector3(x, player.position.y, 0), Quaternion.identity);
    }
    
    private void ResetTimer()
    {
        timer = Random.Range(minInterval, maxInterval);
    }
}
