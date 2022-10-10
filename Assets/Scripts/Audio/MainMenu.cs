using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetFloat("PosX", 0);
        PlayerPrefs.SetFloat("PosZ", 0);
        Application.Quit();
    }
}
