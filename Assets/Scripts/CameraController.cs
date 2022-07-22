
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.3f;

    public Vector3 offset;
    [SerializeField] float height;

    private void LateUpdate()
    {
        Vector3 aim = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, aim, smoothSpeed);


        transform.position = smoothed;
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }


}
