using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Season : MonoBehaviour
{
    public GameObject FadeOutPanel;
    public float delayBeforeLoad = 1f; // durasi delay sebelum load scene

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
        FadeOut();
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneName);
    }

    public void GoToMenu() => GoToScene("MenuGame1");

    // Australia
    public void AustraliaSeason1() => GoToScene("SpringAustralia");
    public void AustraliaSeason2() => GoToScene("SummerAustralia");
    public void AustraliaSeason3() => GoToScene("AutumnAustralia");
    public void AustraliaSeason4() => GoToScene("WinterAustralia");

    // Indonesia
    public void IndonesiaSeason1() => GoToScene("RainyIndonesia");
    public void IndonesiaSeason2() => GoToScene("DrySeasonIndonesia");

    // Japan
    public void JapanSeason1() => GoToScene("SpringJapan");
    public void JapanSeason2() => GoToScene("SummerJapan");
    public void JapanSeason3() => GoToScene("AutumnJapan");
    public void JapanSeason4() => GoToScene("WinterJapan");

    // Canada
    public void CanadaSeason1() => GoToScene("SpringCanada");
    public void CanadaSeason2() => GoToScene("SummerCanada");
    public void CanadaSeason3() => GoToScene("AutumnCanada");
    public void CanadaSeason4() => GoToScene("WinterCanada");

    // South Korea
    public void SouthKoreaSeason1() => GoToScene("SpringSouthKorea");
    public void SouthKoreaSeason2() => GoToScene("SummerSouthKorea");
    public void SouthKoreaSeason3() => GoToScene("AutumnSouthKorea");
    public void SouthKoreaSeason4() => GoToScene("WinterSouthKorea");

    // Saudi Arabia
    public void SaudiArabiaSeason1() => GoToScene("RainySaudiarabia");
    public void SaudiArabiaSeason2() => GoToScene("DrySeasonSaudiarabia");

    // Russia
    public void RussiaSeason1() => GoToScene("SpringRussia");
    public void RussiaSeason2() => GoToScene("SummerRussia");
    public void RussiaSeason3() => GoToScene("AutumnRussia");
    public void RussiaSeason4() => GoToScene("WinterRussia");

    // Switzerland
    public void SwitzerlandSeason1() => GoToScene("SpringSwitzerland");
    public void SwitzerlandSeason2() => GoToScene("SummerSwitzerland");
    public void SwitzerlandSeason3() => GoToScene("AutumnSwitzerland");
    public void SwitzerlandSeason4() => GoToScene("WinterSwitzerland");
}
