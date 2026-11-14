using UnityEngine;

public class InvaderSpin : MonoBehaviour
{
    [SerializeField] private float minRotationSpeed = 30f;
    [SerializeField] private float maxRotationSpeed = 120f;

    private float rotationSpeed;

    private void Start()
    {
        // A negative Z angle rotates clockwise; randomize so not every alien spins equally fast.
        rotationSpeed = -Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
    }
}
