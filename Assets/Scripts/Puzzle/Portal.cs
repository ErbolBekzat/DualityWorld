using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform connectedPortalTransform;

    private Camera mainCamera;

    private Portal connectedPortal;

    private GameObject player = null;

    private void Start()
    {
        mainCamera = Camera.main;
        connectedPortal = connectedPortalTransform.GetComponent<Portal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && player == null)
        {
            other.transform.position = new Vector3(connectedPortalTransform.position.x, 0, connectedPortalTransform.position.z);
            mainCamera.transform.position = new Vector3(connectedPortalTransform.position.x, 6f, connectedPortalTransform.position.z - 4f);
            connectedPortal.SetPlayer(other.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }

    public void SetPlayer(GameObject teleportedPlayer)
    {
        player = teleportedPlayer;
    }
}
