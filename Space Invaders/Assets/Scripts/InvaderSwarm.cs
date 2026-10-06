using UnityEngine;

public class InvaderSwarm : MonoBehaviour
{
    public float moveDistance = 1;
    public float seconds = 1;

    public float timer = 0;
    public int direction = 1;

    public bool spawnsNewSwarms = true;
    public float destroyBelowY = -8f;

    void Start()
    {
        SwarmSpawner.Instance.Register(this);
    }

    void OnDestroy()
    {
        if (SwarmSpawner.Instance != null)
        {
            SwarmSpawner.Instance.Unregister(this);
        }
    }

    void Update()
    {
        if (transform.position.y < destroyBelowY) { Destroy(gameObject); return; }
        if (!spawnsNewSwarms && transform.childCount == 0)
        {
            Destroy(gameObject);
            return;
        }

        if (timer <= seconds)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            transform.position = new Vector3(transform.position.x + moveDistance * direction, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("InvaderWall")) return;

        int wallSide = collision.bounds.center.x > transform.position.x ? 1 : -1;
        if (wallSide != direction) return;

        direction *= -1;

        if (spawnsNewSwarms)
        {
            spawnsNewSwarms = false;
            SwarmSpawner.Instance.DropAll();
            SwarmSpawner.Instance.SpawnSwarm();
        }
    }
}