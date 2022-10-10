using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform startPoint;

    [SerializeField] private float laserLength;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, startPoint.position);
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.transform.tag == "Player" || hit.transform.tag == "SnowBall")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position - new Vector3(10f, 0, 0));
        }
    }
}
