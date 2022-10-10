using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float delay;

    [SerializeField] private int maxY;

    private void Start()
    {
        GetComponent<MeshRenderer>().material = door.GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            StartCoroutine(OpenTheDoor());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube")
        {
            StartCoroutine(CloseTheDoor());
        }
    }

    private IEnumerator OpenTheDoor()
    {
        for (int i = 0; i < maxY; i++)
        {
            door.position += new Vector3(0, .1f, 0);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator CloseTheDoor()
    {
        for (int i = 0; i < maxY; i++)
        {
            door.position -= new Vector3(0, .1f, 0);
            yield return new WaitForSeconds(delay);
        }
    }
}
