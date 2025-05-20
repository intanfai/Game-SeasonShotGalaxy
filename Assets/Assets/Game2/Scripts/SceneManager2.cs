using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour
{
    // Panggil ini dari tombol di UI
    public void LoadGameScene()
    {
        SceneManager.LoadScene("PemukulBola");
    }
}
