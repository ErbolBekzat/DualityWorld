using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material blueMaterial;


    private bool lava = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (lava)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().Damage();
            }
        }        
    }

    public void TurnIntoIce()
    {
        meshRenderer.material = blueMaterial;
        lava = false;

        if (tag == "Lava")
        {
            tag = "Ice";
        }
        else
        {
            tag = "Finish";
        }

        transform.localScale = new Vector3(.9f, .9f, .9f);
    }
}
