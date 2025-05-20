using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public int force = 1000;
    public AudioClip bounceClip;

    private Rigidbody2D rigid;
    private AudioSource audioSource;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        LaunchBall();
    }

    void LaunchBall()
    {
        int arahX = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 arah = new Vector2(arahX, Random.Range(-0.5f, 0.5f)).normalized;
        rigid.linearVelocity = Vector2.zero; // gunakan velocity bukan linearVelocity
        rigid.AddForce(arah * force);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlayerPaddle") || 
            coll.gameObject.CompareTag("BotPaddle") || 
            coll.gameObject.CompareTag("Wall")) 
        {
            if (bounceClip != null)
            {
                audioSource.PlayOneShot(bounceClip);
            }
        }

        if (coll.gameObject.name == "PlayerPaddle" || coll.gameObject.name == "BotPaddle")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.linearVelocity.x, sudut).normalized;
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(arah * force);
        }
    }

    public void ResetBall(bool keKanan)
    {
        transform.localPosition = Vector2.zero;
        rigid.linearVelocity = Vector2.zero;

        Vector2 arah = new Vector2(keKanan ? 1 : -1, Random.Range(-0.5f, 0.5f)).normalized;
        rigid.AddForce(arah * force);
    }
}
