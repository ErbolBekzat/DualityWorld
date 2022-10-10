using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private bool activated = false;
    public bool Activated => activated;

    private void OnTriggerEnter(Collider other)
    {
        activated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        activated = false;
    }
}
