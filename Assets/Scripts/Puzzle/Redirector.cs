using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SnowBall")
        {
            other.GetComponent<SnowBall>().SetDirection(transform.forward);
        }
    }
}
