using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private Button restartButton;
    
    private void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(() => GameManager.Instance.RestartGame());
        
        UpdateScore();
        UpdateLives();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < GameManager.Instance.Lives ? fullHeart : emptyHeart;
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
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }
    
    public void ShowGameOver()
    {
        finalScoreText.text = "Score: " + GameManager.Instance.Score;
        gameOverPanel.SetActive(true);
    }
}
