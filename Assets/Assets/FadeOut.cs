using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Animator animator;
    private int sceneToLoad;

    // Dipanggil untuk mulai fade dan ganti scene
    public void StartFadeOut(int sceneIndex)
    {
        gameObject.SetActive(true); // Pastikan panel aktif
        sceneToLoad = sceneIndex;
        // animator.SetTrigger("FadeOut"); 
    }

    // Ini dipanggil dari Animation Event di akhir animasi
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
