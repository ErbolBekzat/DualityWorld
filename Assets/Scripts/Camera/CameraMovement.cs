using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform player;

    [SerializeField] private Vector3 offset;

    private void Start()
    {
        FollowPlayer();
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void MoveTheCamera()
    {

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.position += new Vector3(-mouseX, 0, -mouseY) * speed * Time.deltaTime;
        }
    }

    public void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
        
    }

    private void CameraBorders()
    {
        if (transform.position.x <= -3f)
        {
            transform.position = new Vector3(-3f, 6f, transform.position.z);
        }
        if (transform.position.x >= 120f)
        {
            transform.position = new Vector3(120f, 6f, transform.position.z);
        }
        if (transform.position.z <= -14f)
        {
            transform.position = new Vector3(transform.position.x, 6f, -14f);
        }
        if (transform.position.z >= 4f)
        {
            transform.position = new Vector3(transform.position.x, 6f, 4f);
        }

    }
}
