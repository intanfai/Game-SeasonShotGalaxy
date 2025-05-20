using UnityEngine;

public class BotPaddle : MonoBehaviour
{
    public Transform ball;
    public float speed = 3f;

    void Update()
    {
        Vector2 targetPos = new Vector2(transform.position.x, ball.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        Debug.Log($"BOTTT Input: {transform.position}");
    }
}
