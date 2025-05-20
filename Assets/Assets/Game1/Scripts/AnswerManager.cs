using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerManager : MonoBehaviour
{
    public GameObject wrongAnswerPanel;
    public GameObject correctAnswerPanel;
    public string nextSceneName;

    public AudioSource sceneAudio;              // Audio utama di scene
    public AudioSource correctAnswerAudio;      // Audio untuk jawaban benar
    public AudioSource wrongAnswerAudio;        // Audio untuk jawaban salah

    public void WrongAnswer()
    {
        wrongAnswerPanel.SetActive(true);
        if (sceneAudio.isPlaying)
        {
            sceneAudio.Stop();
        }
        wrongAnswerAudio.Play();
    }

    public void CorrectAnswer()
    {
        correctAnswerPanel.SetActive(true);
        if (sceneAudio.isPlaying)
        {
            sceneAudio.Stop();
        }
        correctAnswerAudio.Play();
    }

    public void CloseWrongPanel()
    {
        wrongAnswerPanel.SetActive(false);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
