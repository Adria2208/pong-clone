using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    [SerializeField] Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            if (gameObject.tag.Equals("PlayerGoal"))
            {
                gameManager.AddEnemyScore(1);
                Invoke(nameof(ResetBall), 2);
            }
            else if (gameObject.tag.Equals("EnemyGoal"))
            {
                gameManager.AddPlayerScore(1);
                Invoke(nameof(ResetBall), 2);
            }
        }
    }

    private void ResetBall()
    {
        ball.ResetBall();
    }
}
