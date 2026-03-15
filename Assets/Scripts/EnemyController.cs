using UnityEngine;

public class EnemyController : PaddleBase
{
    [SerializeField] private Transform ball;
    private float enemyMoveSpeed = 2f;

    void Update()
    {
        Vector3 targetPos = new Vector3(
            ball.position.x,
            ball.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(transform.position, targetPos, enemyMoveSpeed * Time.deltaTime);    
    }
}
