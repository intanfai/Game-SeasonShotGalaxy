using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject FadeOutPanel;

    public void FadeOut()
    {
        if (FadeOutPanel != null)
            FadeOutPanel.SetActive(true);
    }
    public static GameManager Instance;

    public LevelConfig levelConfig;

    public TMP_Text timerText;
    public TMP_Text scoreText;

    // UI for WIN popup
    public GameObject winPopup;
    public Text winScoreText;
    public Text winTimeText;

    // UI for LOSE popup
    public GameObject losePopup;
    public Text loseScoreText;
    public Text loseTimeText;

    private int score = 0;
    private int correctCount = 0;
    private float timeRemaining;
    private bool isGameOver = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip backsoundClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    [Range(0.1f, 5f)] public float fadeOutDuration = 1.5f;

    [Header("SFX")] // 🔄 Tambahan
    public AudioSource sfxSource; // AudioSource khusus efek
    public AudioClip clickClip;   // Suara klik tombol

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        timeRemaining = levelConfig.timeLimit;
    }

    void Start()
    {
        // Mulai backsound
        audioSource.clip = backsoundClip;
        audioSource.loop = true;
        audioSource.volume = 1f;
        audioSource.Play();

        scoreText.text = "0";
    }

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timeRemaining) + "s";

        if (timeRemaining <= 0)
        {
            LoseGame();
        }
    }

    public void RegisterCorrectDrop()
    {
        correctCount++;
        score += levelConfig.scorePerItem;
        scoreText.text = "" + score;

        if (correctCount == levelConfig.totalItems)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        winPopup.SetActive(true);
        winScoreText.text = "" + score;
        winTimeText.text = "" + Mathf.Ceil(timeRemaining) + "s";

        StartCoroutine(FadeOutAndPlayResult(winClip));
    }

    void LoseGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        losePopup.SetActive(true);
        loseScoreText.text = "" + score;

        StartCoroutine(FadeOutAndPlayResult(loseClip));
    }

    IEnumerator FadeOutAndPlayResult(AudioClip resultClip)
    {
        float startVolume = audioSource.volume;
        float t = 0f;

        while (t < fadeOutDuration)
        {
            t += Time.unscaledDeltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeOutDuration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        audioSource.PlayOneShot(resultClip);
    }

    // UI Buttons

    public void Replay() // 🔄 Diubah agar suara klik sempat terdengar
    {
        StartCoroutine(ReplayWithSFX());
    }

    IEnumerator ReplayWithSFX() // 🔄 Tambahan coroutine
    {
        if (sfxSource != null && clickClip != null)
        {
            sfxSource.PlayOneShot(clickClip);
        }

        yield return new WaitForSeconds(0.2f); // Delay agar suara sempat terdengar

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
    StartCoroutine(NextLevelWithSFX());
    }

    IEnumerator NextLevelWithSFX()
    {
        if (sfxSource != null && clickClip != null)
        {
            sfxSource.PlayOneShot(clickClip);
        }

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(levelConfig.nextLevelName);
    }

}
