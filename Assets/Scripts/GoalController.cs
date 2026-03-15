using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GoalController : MonoBehaviour
{
    public bool isPlayerSideGoal = false;
    public BallMovement ball;

    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;
 
        if (ScoreManager.Instance == null)
        {
            Debug.LogWarning("GoalController: ScoreManager not found!");
            return;
        }
 
        if (isPlayerSideGoal)
        {
            ScoreManager.Instance.AddEnemyScore();
        } else
        {
            ScoreManager.Instance.AddPlayerScore();
        }
            

        if (ball != null) ball.ResetBall(!isPlayerSideGoal);
    }
}
