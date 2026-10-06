using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 9.6f;
    [SerializeField] private float minInterval = 5f;
    [SerializeField] private float maxInterval = 10f;

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

        if (GameManager.Instance.HasFullLives) return;
        if (FindFirstObjectByType<HeartPickup>() is not null) return;

        float x = Random.Range(minX, maxX);
        Instantiate(heartPrefab, new Vector3(x, player.position.y, 0), Quaternion.identity);
    }
    
    private void ResetTimer()
    {
        timer = Random.Range(minInterval, maxInterval);
    }
}
