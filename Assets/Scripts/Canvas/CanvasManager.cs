using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject winPage;
    [SerializeField] private GameObject losePage;

    public void ActivateWinPage()
    {
        winPage.SetActive(true);
        PlayerPrefs.SetFloat("PosX", 0);
        PlayerPrefs.SetFloat("PosZ", 0);
    }

    public void ActivateLosePage()
    {
        losePage.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

        PlayerPrefs.SetFloat("PosX", 0);
        PlayerPrefs.SetFloat("PosZ", 0);
    }
}
