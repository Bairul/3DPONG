using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    [Header("Score Labels")]
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.onScoreChanged.AddListener(OnScoreChanged);
            OnScoreChanged(ScoreManager.Instance.PlayerScore, ScoreManager.Instance.OpponentScore);
        }
        else
        {
            Debug.LogWarning("ScoreUI: No ScoreManager found in scene.");
        }
    }

    private void OnScoreChanged(int playerScore, int opponentScore)
    {
        if (playerScoreText)
        {
            playerScoreText.text = playerScore.ToString();
        }
 
        if (enemyScoreText)
        {
            enemyScoreText.text = opponentScore.ToString();
        }
    }

    private void OnDestroy()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.onScoreChanged.RemoveListener(OnScoreChanged);
        }
    }
}
