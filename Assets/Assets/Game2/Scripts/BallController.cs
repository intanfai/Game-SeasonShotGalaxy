using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [Header("Gameplay Settings")]
    public int force = 300;

    [Header("UI References")]
    [SerializeField] private Text scoreUIP1;
    [SerializeField] private Text scoreUIP2;
    [SerializeField] private GameObject panelSelesai;
    [SerializeField] private Text txPemenang;

    private Rigidbody2D rigid;
    private int scoreP1 = 0;
    private int scoreP2 = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (rigid == null)
        {
            Debug.LogError("Rigidbody2D tidak ditemukan pada bola!");
            return;
        }

        // Validasi UI
        if (scoreUIP1 == null || scoreUIP2 == null || panelSelesai == null || txPemenang == null)
        {
            Debug.LogError("Ada referensi UI yang belum di-assign di Inspector!");
            return;
        }

        panelSelesai.SetActive(false);
        MulaiPermainan();
    }

    void MulaiPermainan()
    {
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            TampilkanScore();

            if (scoreP1 >= 5)
            {
                SelesaikanPermainan("Player Biru Pemenang!");
                return;
            }

            ResetBall(new Vector2(2, 0));
        }
        else if (coll.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            TampilkanScore();

            if (scoreP2 >= 5)
            {
                SelesaikanPermainan("Player Merah Pemenang!");
                return;
            }

            ResetBall(new Vector2(-2, 0));
        }
        else if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.linearVelocity.x, sudut).normalized;

            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall(Vector2 arah)
    {
        transform.localPosition = Vector2.zero;
        rigid.linearVelocity = Vector2.zero;
        rigid.AddForce(arah.normalized * force);
    }

    void TampilkanScore()
    {
        scoreUIP1.text = scoreP1.ToString();
        scoreUIP2.text = scoreP2.ToString();
        Debug.Log("Score P1: " + scoreP1 + " | Score P2: " + scoreP2);
    }

    void SelesaikanPermainan(string pemenang)
    {
        panelSelesai.SetActive(true);
        txPemenang.text = pemenang;
        Destroy(gameObject);
    }
}
