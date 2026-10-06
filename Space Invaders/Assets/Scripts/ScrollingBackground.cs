using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    private Vector3 startPos;
    private float height;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Repeat(Time.time * speed, height);
        transform.position = startPos + Vector3.down * offset;
    }
}
