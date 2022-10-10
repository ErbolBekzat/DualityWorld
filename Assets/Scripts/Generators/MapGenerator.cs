using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject iceTilePrefab;
    [SerializeField] private GameObject lavaGridPrefabs;

    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private int iceTileCount;

    [SerializeField] private float delay;

    private bool[,] mapArray;

    private Vector3 currentIceTilePosition = new Vector3();
    private Vector3Int currentIceTilePositionInt = new Vector3Int();

    private GameObject map = null;

    private int tileScale = 4;
    private void Start()
    {
        StartCoroutine(Generate());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Generate());
        }
    }

    private IEnumerator Generate()
    {
        tileScale = 4;
        currentIceTilePositionInt = new Vector3Int(1, 0, 1);
        currentIceTilePosition = new Vector3(tileScale, 0, tileScale);

        mapArray = new bool[width, height];

        if (map != null)
        {
            Destroy(map);

            GameObject emptyGameObject = new GameObject();

            map = emptyGameObject;
            map.transform.position = Vector3.zero;
            map.name = "NewMap";
        }
        else
        {
            GameObject emptyGameObject = new GameObject();

            map = emptyGameObject;
            map.transform.position = Vector3.zero;
            map.name = "NewMap";
        }

        if (mapArray[currentIceTilePositionInt.x, currentIceTilePositionInt.z] == false)
        {
            Vector3 positionToPlace = new Vector3(currentIceTilePosition.x, 0, currentIceTilePosition.z);

            mapArray[currentIceTilePositionInt.x, currentIceTilePositionInt.z] = true;

            GameObject spawnedIceTile = Instantiate(iceTilePrefab, positionToPlace, Quaternion.identity, map.transform);
            spawnedIceTile.transform.localScale = new Vector3(tileScale, 1, tileScale);
        }

        float offset = 0;

        for (int i = 0; i < iceTileCount; i++)
        {
            yield return new WaitForSeconds(delay);

            tileScale += 2;
            //offset += 1;

            if (tileScale > 20)
            {
                tileScale = 20;
                offset = 1;
            }

            PlaceIceTile(offset);
        }
    }

    private void PlaceIceTile(float offsetCount)
    {

        List<Vector3> availablePositions = new List<Vector3>();
        List<Vector3Int> availablePositionsInt = new List<Vector3Int>();

        int xInt = currentIceTilePositionInt.x;
        int zInt = currentIceTilePositionInt.z;

        float x = currentIceTilePosition.x;
        float z = currentIceTilePosition.z;

        if (xInt + 1 < width)
        {
            if (mapArray[xInt + 1, zInt] == false)
            {
                availablePositions.Add(new Vector3(x + tileScale + offsetCount, 0, z));
                availablePositionsInt.Add(new Vector3Int(xInt + 1, 0, zInt));
            }
        }

        if (zInt + 1 < height)
        {
            if (mapArray[xInt, zInt + 1] == false)
            {
                availablePositions.Add(new Vector3(x, 0, z + tileScale + offsetCount));
                availablePositionsInt.Add(new Vector3Int(xInt, 0, zInt + 1));
            }
        }

        if (availablePositions.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);

            Vector3 tilePosition = availablePositions[randomIndex];

            Vector3 positionToPlace = new Vector3(tilePosition.x, 0, tilePosition.z);

            GameObject firstSpawnedIceTile = Instantiate(iceTilePrefab, positionToPlace, Quaternion.identity, map.transform);

            firstSpawnedIceTile.transform.localScale = new Vector3(tileScale, 1, tileScale);

            if (offsetCount == 0)
            {
                offsetCount = 1;
            }

            for (int i = 0; i < offsetCount; i++)
            {
                for (float j = (tileScale / 2 - .5f) * -1; j < (tileScale / 2 + .5f); j++)
                {
                    if (tilePosition.x > currentIceTilePosition.x)
                    {
                        Instantiate(lavaGridPrefabs, new Vector3(tilePosition.x - (tileScale / 2 + .5f) - i, 0, tilePosition.z + j), Quaternion.identity, map.transform);
                    }
                    else
                    {
                        Instantiate(lavaGridPrefabs, new Vector3(tilePosition.x + j, 0, tilePosition.z - (tileScale / 2 + .5f) - i), Quaternion.identity, map.transform);
                    }
                }
            }

            currentIceTilePosition = tilePosition;
            currentIceTilePositionInt = availablePositionsInt[randomIndex];

            mapArray[currentIceTilePositionInt.x, currentIceTilePositionInt.z] = true;
        }
    }
}
