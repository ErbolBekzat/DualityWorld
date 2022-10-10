using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject[] snowBalls;

    [SerializeField] private CanvasManager canvasManager;

    [SerializeField] private float hp;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private int currentLevel = 0;

    private Transform iceTile;

    private void Start()
    {
        Vector3 checkPoint = new Vector3(PlayerPrefs.GetFloat("PosX"), 0, PlayerPrefs.GetFloat("PosZ"));

        if (PlayerPrefs.GetFloat("PosX") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", -1);
        }

        transform.position = checkPoint;
    }

    private void Update()
    {
        Death();

        if (transform.position.y < -1.5f)
        {
            hp = 0;
        }

        if (iceTile != null)
        {
            if (transform.position.x > iceTile.position.x + .6f)
            {
                Destroy(iceTile.parent.parent.parent.gameObject);
            }
        }
    }

    private void Death()
    {
        if (hp <= 0)
        {
            canvasManager.ActivateLosePage();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ice")
        {
            PlayerPrefs.SetFloat("PosX", collision.transform.position.x + 1f);
            PlayerPrefs.SetFloat("PosZ", collision.transform.position.z);

            if (collision.transform.parent.name == "LastLavaPlatform")
            {
                iceTile = collision.transform;

                int level = PlayerPrefs.GetInt("CurrentLevel");

                level++;

                PlayerPrefs.SetInt("CurrentLevel", level);
                PlayerPrefs.SetFloat("LevelPosX", collision.transform.position.x + 1f);

                levelManager.GetNextLevel();
            }
        }
        if (collision.transform.tag == "Finish")
        {
            canvasManager.ActivateWinPage();
        }
    }

    private void OnDestroy()
    {
        canvasManager.ActivateLosePage();
    }

    public void Damage()
    {
        hp = 0;
    }
}