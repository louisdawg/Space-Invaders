using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    
    public GameObject bulletPrefab;

    [SerializeField] private Transform barrel;
    [SerializeField] private Transform bulletSpawnPos;

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

        AimBarrelAtMouse();

        if (timer <= bulletCoolOffTime)
        {
            timer += Time.deltaTime;
        }   else if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void AimBarrelAtMouse()
    {
        if (barrel == null) return;

        Vector3 direction = GetMousePosition() - barrel.position;
        direction.z = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            barrel.up = direction.normalized;
        }
    }

    private void Shoot()
    {
        Transform spawn = bulletSpawnPos != null ? bulletSpawnPos : transform;

        if (GameManager.Instance.DoubleShotActive)
        {
            Vector3 offset = spawn.right * 0.3f;
            Instantiate(bulletPrefab, spawn.position + offset, spawn.rotation);
            Instantiate(bulletPrefab, spawn.position - offset, spawn.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        }

        timer = 0;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
