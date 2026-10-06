using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    
    public GameObject bulletPrefab;

    public float bulletCoolOffTime = 1;
    public float timer = 0;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(horizontalInput * movespeed,0,0);

        if (timer <= bulletCoolOffTime)
        {
            timer += Time.deltaTime;
        }   else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
