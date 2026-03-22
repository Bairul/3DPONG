using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject gameOverPanel;

    [Header("UI Elements")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        gameOverPanel.SetActive(false);

        ScoreManager.Instance.onPlayerWin.AddListener(ShowWinScreen);
        ScoreManager.Instance.onEnemyWin.AddListener(ShowLoseScreen);
    }

    public void ShowWinScreen()
    {
        Show("You Win!", Color.green);
    }

    public void ShowLoseScreen()
    {
        Show("You Lose!", Color.red);
    }

    private void Show(string message, Color color)
    {
        gameOverPanel.SetActive(true);
        resultText.text  = message;
        resultText.color = color;
        finalScoreText.text = $"{ScoreManager.Instance.PlayerScore} - {ScoreManager.Instance.OpponentScore}";
        Time.timeScale = 0f;
    }

    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        ScoreManager.Instance.ResetScores();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}