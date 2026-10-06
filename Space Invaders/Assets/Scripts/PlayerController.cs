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
            if (GameManager.Instance.DoubleShotActive)
            {
                Instantiate(bulletPrefab, transform.position + Vector3.left * 0.3f, Quaternion.identity);
                Instantiate(bulletPrefab, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                timer = 0;
            }
            else
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
