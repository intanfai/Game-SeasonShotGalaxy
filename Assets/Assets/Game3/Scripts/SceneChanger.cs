using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public float delayWaktu = 0.01f; // Delay dalam detik, bisa diubah di Inspector


    public void PindahScene(string namaScene)
    {
        StartCoroutine(PindahSceneDenganDelay(namaScene));
    }

    private IEnumerator PindahSceneDenganDelay(string namaScene)
    {
        yield return new WaitForSeconds(delayWaktu);
        SceneManager.LoadScene(namaScene);
    }
}
