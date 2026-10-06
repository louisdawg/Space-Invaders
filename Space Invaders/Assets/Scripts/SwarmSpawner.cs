using System.Collections.Generic;
using UnityEngine;

public class SwarmSpawner : MonoBehaviour
{
    public static SwarmSpawner Instance { get; private set; }

    [SerializeField] private InvaderSwarm swarmPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float rowHeight = 1f;

    private readonly List<InvaderSwarm> swarms = new List<InvaderSwarm>();

    private void Awake()
    {
        Instance = this;
    }

    public void Register(InvaderSwarm swarm)
    {
        swarms.Add(swarm);
    }

    public void Unregister(InvaderSwarm swarm)
    {
        swarms.Remove(swarm);
    }

    public void DropAll()
    {
        foreach (InvaderSwarm swarm in swarms)
        {
            swarm.transform.position += Vector3.down * rowHeight;
        }
    }

    public void SpawnSwarm()
    {
        InvaderSwarm swarm = Instantiate(swarmPrefab);

        BoxCollider2D box = swarm.GetComponent<BoxCollider2D>();
        swarm.transform.position = spawnPoint.position - (Vector3)box.offset;

        swarm.spawnsNewSwarms = true;
        swarm.direction = Random.value < 0.5f ? -1 : 1;
    }
}