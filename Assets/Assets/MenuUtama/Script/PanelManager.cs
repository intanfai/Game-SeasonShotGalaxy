using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject overlayButton; // Transparan button yang menutupi layar

    public void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }

        // Tampilkan overlay agar bisa mendeteksi klik di luar panel
        if (overlayButton != null)
        {
            overlayButton.SetActive(true);
        }
    }

    // Fungsi ini dipanggil dari tombol transparan di luar panel
    public void ReturnToCredit()
    {
        SceneManager.LoadScene("Credit"); // Ganti sesuai nama scene Credit kamu
    }
}
