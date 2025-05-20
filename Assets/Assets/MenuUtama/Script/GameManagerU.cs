using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManagerU : MonoBehaviour
{
    public static GameManagerU Instance;

    [Header("Exit Confirmation Panel")]
    public GameObject confirmationPanel;

    [Header("UI Popup Panel")]
    public GameObject popupPanelBackground; // transparan full-screen panel
    public GameObject popupContent;         // panel konten (child dari background)

    [Header("General Purpose Panel")]
    public GameObject infoPanel;            // panel tambahan (misalnya info, tutorial, dll)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ====== EXIT LOGIC ======
    public void ShowExitPopup()
    {
        confirmationPanel.SetActive(true);
    }

    public void HideExitPopup()
    {
        confirmationPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }

    // public void BackToMenu()
    // {
    //     SceneManager.LoadScene("MainMenu");
    // }

    // ====== UI POPUP LOGIC ======
    public void ShowUIPopup()
    {
        popupPanelBackground.SetActive(true);
    }

    public void HideUIPopup()
    {
        popupPanelBackground.SetActive(false);
    }

    public void OnPopupBackgroundClicked()
    {
        // Cek apakah klik terjadi di luar konten popup
        if (!RectTransformUtility.RectangleContainsScreenPoint(
            popupContent.GetComponent<RectTransform>(),
            Input.mousePosition,
            Camera.main))
        {
            HideUIPopup();
        }
    }

    // ====== GENERAL INFO PANEL (triggered by button) ======
    public void ShowInfoPanel()
    {
        infoPanel.SetActive(true);
    }

    public void HideInfoPanel()
    {
        infoPanel.SetActive(false);
    }

    public void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}
