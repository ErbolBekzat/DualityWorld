using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelPrefabs = new List<GameObject>();

    private void Start()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");

        if (level > -1)
        {
            float posX = PlayerPrefs.GetFloat("LevelPosX");
            Instantiate(levelPrefabs[level], new Vector3(posX, 0, 4), Quaternion.identity);
        }
    }

    public void GetNextLevel()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");
        float posX = PlayerPrefs.GetFloat("LevelPosX");
        Instantiate(levelPrefabs[level], new Vector3(posX, 0, 4), Quaternion.identity);
    }
}
