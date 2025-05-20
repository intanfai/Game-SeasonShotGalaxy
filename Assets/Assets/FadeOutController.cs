using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutController : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        // Pastikan fade canvas aktif dan transparan saat mulai
        fadeCanvasGroup.alpha = 0f;
        fadeCanvasGroup.gameObject.SetActive(false);
    }

    public void StartFadeOut(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        fadeCanvasGroup.gameObject.SetActive(true);

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeCanvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        fadeCanvasGroup.alpha = 1f;
        SceneManager.LoadScene(sceneIndex);
    }
}
