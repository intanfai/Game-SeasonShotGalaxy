using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject FadeOutPanel;

    public void FadeOut()
    {
        if (FadeOutPanel != null)
            FadeOutPanel.SetActive(true);
    }
    public float delayWaktu = 0.5f; 

    public void GoToHome()
    {
        StartCoroutine(LoadSceneWithDelay("MenuGame2"));
    }

    public void GoToMenu()
    {
        StartCoroutine(LoadSceneWithDelay("LevelGame2"));
    }

    public void GoToLevel1()
    {
        StartCoroutine(LoadSceneWithDelay("Level1Game2"));
    }

    public void GoToLevel2()
    {
        StartCoroutine(LoadSceneWithDelay("Level2Game2"));
    }

    public void GoToLevel3()
    {
        StartCoroutine(LoadSceneWithDelay("Level3Game2"));
    }

    public void GoToChooseGame()
    {
    StartCoroutine(LoadSceneWithDelay("ChooseGame"));
    }

    private System.Collections.IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayWaktu);
        SceneManager.LoadScene(sceneName);
    }
}
