using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    [Header("Gerakan")]
    public float kecepatan = 500f;
    public string axis = "Vertical";

    [Header("Batas Pergerakan")]
    public float batasAtas = 4f;
    public float batasBawah = -4f;

    private void Update()
    {
        float input = Input.GetAxis(axis);
        float gerak = input * kecepatan * Time.deltaTime;

        Debug.Log($"Axis: {axis} | Input: {input} | Gerak: {gerak}");

        float nextPosY = transform.position.y + gerak;

        if (nextPosY > batasAtas)
        {
            gerak = 0f;
            nextPosY = batasAtas;
        }
        else if (nextPosY < batasBawah)
        {
            gerak = 0f;
            nextPosY = batasBawah;
        }

        transform.Translate(0f, gerak, 0f);
    }
}
