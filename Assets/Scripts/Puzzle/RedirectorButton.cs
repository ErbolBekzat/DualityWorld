using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectorButton : MonoBehaviour
{
    [SerializeField] Transform redirector;

    private void OnMouseDown()
    {
        redirector.Rotate(new Vector3(0f, 90f, 0f));
    }
}
