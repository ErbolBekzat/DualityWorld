using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;

    [SerializeField] private int width;
    [SerializeField] private int height;

    private List<GameObject> spawnedTiles = new List<GameObject>();
    public void GeneratePlatform()
    {
        ClearPlatform();
        spawnedTiles.Clear();

        int tileIndex = 0;
        int step = 0;
        if (tiles.Length == 1)
        {
            for (int i = 0; i < width * height; i++)
            {
                spawnedTiles.Add(Instantiate(tiles[0], transform));
            }
        }
        else
        {
            for (int i = 0; i < width * height; i++)
            {
                spawnedTiles.Add(Instantiate(tiles[tileIndex], transform));

                step++;

                if (height % 2 == 0)
                {
                    if (step == height)
                    {
                        if (tileIndex == 0)
                        {
                            tileIndex = 1;
                        }
                        else
                        {
                            tileIndex = 0;
                        }
                        step = 0;
                    }
                }
                

                if (tileIndex == 0)
                {
                    tileIndex = 1;
                }
                else
                {
                    tileIndex = 0;
                }

            }
        }
        

        int index = 0;

        for (float x = -((float)width / 2 - .5f); x < (float)width / 2; x++)
        {
            for (float z = -((float)height / 2 - .5f); z < (float)height / 2; z++)
            {
                spawnedTiles[index].transform.localPosition = new Vector3(x, -1, z);
                index++;
            }
        }
    }

    public void ClearPlatform()
    {
        List<GameObject> childrenObjects = new List<GameObject>();

        foreach (Transform child in transform)
        {
            childrenObjects.Add(child.gameObject);
        }

        foreach (GameObject tile in childrenObjects)
        {
            DestroyImmediate(tile);
        }
    }
}
