using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger2 : MonoBehaviour
{
    public GameObject FadeOutPanel;
    public float delayBeforeLoad = 1f; // delay dalam detik

    public void FadeOut()
    {
        if (FadeOutPanel != null)
            FadeOutPanel.SetActive(true);
    }

    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        FadeOut(); // Munculin panel fade out dulu
        yield return new WaitForSeconds(delayBeforeLoad); // Tunggu sebentar
        SceneManager.LoadScene(sceneName); // Baru load scene
    }

    public void GoToHome() => GoToScene("Home");
    public void GoToMenu() => GoToScene("MenuGame1");

    // Scene Des negara
    public void GoToDesJapan() => GoToScene("DesJapan");
    public void GoToDesSwitzerland() => GoToScene("DesSwitzerland");
    public void GoToDesIndonesia() => GoToScene("DesIndonesia");
    public void GoToDesSaudiarabia() => GoToScene("DesSaudiarabia");
    public void GoToDesSouthkorea() => GoToScene("DesSouthkorea");
    public void GoToDesRussia() => GoToScene("DesRussia");
    public void GoToDesCanada() => GoToScene("DesCanada");
    public void GoToDesAustralia() => GoToScene("DesAustralia");

    // Scene QnA negara
    public void GoToQnAJapan() => GoToScene("QnAJapan");
    public void GoToQnASwitzerland() => GoToScene("QnASwitzerland");
    public void GoToQnAIndonesia() => GoToScene("QnAIndonesia");
    public void GoToQnASaudiarabia() => GoToScene("QnASaudiarabia");
    public void GoToQnASouthkorea() => GoToScene("QnASouthkorea");
    public void GoToQnARussia() => GoToScene("QnARussia");
    public void GoToQnACanada() => GoToScene("QnACanada");
    public void GoToQnAAustralia() => GoToScene("QnAAustralia");

    public void GoToChooseGame() => GoToScene("ChooseGame");
}
