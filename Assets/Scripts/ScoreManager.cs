using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [Header("Win Condition")]
    public int scoreToWin = 7;

    public UnityEvent<int, int> onScoreChanged;

    private int playerScore;
    private int enemyScore;

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
        playerScore += amount;
        NotifyListeners();
        Debug.Log(playerScore + " " + enemyScore);
    }
 
    public void AddEnemyScore(int amount = 1)
    {
        enemyScore += amount;
        NotifyListeners();
        Debug.Log(playerScore + " " + enemyScore);
    }

    public void ResetScores()
    {
        playerScore   = 0;
        enemyScore = 0;
        NotifyListeners();
    }

    private void NotifyListeners()
    {
        onScoreChanged?.Invoke(playerScore, enemyScore);
    }
}
