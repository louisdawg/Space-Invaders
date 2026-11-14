using UnityEngine;

public class ChasingEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject chasingEnemyPrefab;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float spawnY = 8f;
    [SerializeField] private float minInterval = 9f;
    [SerializeField] private float maxInterval = 15f;

    private float timer;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        timer -= Time.deltaTime;
        if (timer > 0) return;

        ResetTimer();

        float x = Random.Range(minX, maxX);
        Instantiate(chasingEnemyPrefab, new Vector3(x, spawnY, 0), Quaternion.identity);
    }

    private void ResetTimer()
    {
        timer = Random.Range(minInterval, maxInterval);
    }
}
