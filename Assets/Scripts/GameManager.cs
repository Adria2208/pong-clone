using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text playerScoreText;
    [SerializeField] TMP_Text enemyScoreText;

    private int playerScore = 0;
    private int enemyScore = 0;

    public void AddPlayerScore(int score)
    {
        playerScore += score;
        playerScoreText.SetText(playerScore.ToString());
    }

    public void AddEnemyScore(int score)
    {
        enemyScore += score;
        enemyScoreText.SetText(enemyScore.ToString());
    }
}
