using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalTrigger : MonoBehaviour
{
    public bool isLeftGoal;
    public static int score1 = 0; // UBAH KE STATIC
    public static int score2 = 0; // UBAH KE STATIC
    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;
    public Ball ball;

    public void GoalPlayer1()
    {
        score1++;
        score1Text.text = score1.ToString();
        Debug.Log("Player 1 Scored! Total: " + score1);
        ball.ResetBall(true);
    }

    public void GoalPlayer2()
    {
        score2++;
        score2Text.text = score2.ToString();
        Debug.Log("Bot Scored! Total: " + score2);
        ball.ResetBall(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (isLeftGoal)
                GoalPlayer2();
            else
                GoalPlayer1();
        }
    }

    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        score1Text.text = "0";
        score2Text.text = "0";
    }
}
