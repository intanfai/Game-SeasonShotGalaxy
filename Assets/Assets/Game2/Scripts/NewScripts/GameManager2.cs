using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    [Header("Start Panel")]
    public GameObject clickToStartPanel;
    private bool hasGameStarted = false;
    public GameObject FadeOutPanel;

    public void FadeOut()
    {
        if (FadeOutPanel != null)
            FadeOutPanel.SetActive(true);
    }
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip backsoundClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    [Header("Timer")]
    public float gameDuration = 60f;
    private float currentTime;

    [Header("Score Ref")]
    public GoalTrigger goalTrigger;

    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject panelDraw;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    [HideInInspector]
    public bool gameEnded = false;

    public void GoToMenu2()
    {
        Debug.Log("Mencoba ganti ke LevelGame2");
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelGame2");
    }

    public void NextLevel2()
    {
        Debug.Log("Mencoba ganti ke Level2Game2");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2Game2");
    }

    public void NextLevel3()
    {
        Debug.Log("Mencoba ganti ke Level3Game2");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2Game2");
    }

    void Start()
    {
        Time.timeScale = 1f;
        currentTime = gameDuration;
        goalTrigger.ResetScore(); 
        UpdateTimerUI();
        HideAllPanels();

        if (backsoundClip != null && audioSource != null)
        {
            audioSource.clip = backsoundClip;
            audioSource.loop = true;
            audioSource.Play();
        }

        if (clickToStartPanel != null)
            clickToStartPanel.SetActive(true);

    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        if (currentTime <= 0)
        {
            EndGame();
        }

        if (!hasGameStarted)
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                hasGameStarted = true;
                Time.timeScale = 1f;

                if (clickToStartPanel != null)
                    clickToStartPanel.SetActive(false);

                if (backsoundClip != null && audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.clip = backsoundClip;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }

            return; 
        }
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds + "s";
    }

    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        int playerScore = GoalTrigger.score1;
        int botScore = GoalTrigger.score2;

        Debug.Log("Final Player Score: " + playerScore);
        Debug.Log("Final Bot Score: " + botScore);

        // Stop backsound before playing SFX
        if (audioSource != null)
            audioSource.Stop();

        if (playerScore > botScore)
        {
            panelWin.SetActive(true);
            winText.text = $"{playerScore} : {botScore}";
            audioSource.PlayOneShot(winClip);
        }
        else if (playerScore < botScore)
        {
            panelLose.SetActive(true);
            loseText.text = $"{playerScore} : {botScore}";
            audioSource.PlayOneShot(loseClip);
        }
        else
        {
            panelDraw.SetActive(true);
            audioSource.PlayOneShot(loseClip); 
        }
    }

    void HideAllPanels()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);
        panelDraw.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        goalTrigger.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelGame2");
    }

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuGame2");
    }

    public void GoToNextLevel(string levelName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }
}
