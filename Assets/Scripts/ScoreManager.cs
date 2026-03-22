using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [Header("Win Condition")]
    public int scoreToWin = 7;

    public UnityEvent<int, int> onScoreChanged;
    public UnityEvent onPlayerWin;
    public UnityEvent onEnemyWin;

    private int playerScore;
    private int enemyScore;

    private bool gameOver = false;

    public int PlayerScore => playerScore;
    public int OpponentScore => enemyScore;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddPlayerScore(int amount = 1)
    {
        if (gameOver) return;
        playerScore += amount;
        NotifyListeners();
        CheckWinCondition();
    }
 
    public void AddEnemyScore(int amount = 1)
    {
        if (gameOver) return;
        enemyScore += amount;
        NotifyListeners();
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (playerScore >= scoreToWin)
        {
            gameOver = true;
            onPlayerWin?.Invoke();
        }
        else if (enemyScore >= scoreToWin)
        {
            gameOver = true;
            onEnemyWin?.Invoke();
        }
    }

    public void ResetScores()
    {
        playerScore   = 0;
        enemyScore = 0;
        gameOver = false;
        NotifyListeners();
    }

    private void NotifyListeners()
    {
        onScoreChanged?.Invoke(playerScore, enemyScore);
    }
}
