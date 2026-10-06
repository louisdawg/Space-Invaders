using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const int MaxLives = 3;

    private int score = 0;
    private bool isGameOver = false;

    [SerializeField]
    private int lives = 3;

    public bool IsGameOver { get { return isGameOver; } }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = Mathf.Clamp(value, 0, MaxLives);
            UIManager.Instance.UpdateLives();

            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOver();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        score = 0;
        lives = MaxLives;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}