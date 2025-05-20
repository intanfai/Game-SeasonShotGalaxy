using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // penting untuk coroutine

public class SceneChangerMenu2 : MonoBehaviour
{
    // Fungsi umum untuk pindah scene
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Atau versi cepat untuk dipanggil dari tombol
    public void LoadMenuAG()
    {
        SceneManager.LoadScene("MenuAG");
    }

    public void Game1()
    {
        SceneManager.LoadScene("Home");
    }

    public void Game2()
    {
        SceneManager.LoadScene("MenuGame2");
    }

    public void Game3()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void ChooseGame()
    {
        SceneManager.LoadScene("ChooseGame");
    }

    public GameObject panel;

    public void ShowPanel()
    {
        if (panel != null)
            panel.SetActive(true);
    }

    public void HidePanel()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        // Debug.Log("Keluar dari permainan dalam 2 detik...");
        // StartCoroutine(QuitGameWithDelay); // delay 2 detik
    }

    // private IEnumerator QuitGameWithDelay()
    // {
        // yield return new WaitForSeconds(delay);
        // Application.Quit();

// #if UNITY_EDITOR
//         UnityEditor.EditorApplication.isPlaying = false;
// #else
//         Application.Quit();
// #endif
    // }
}
