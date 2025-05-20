using UnityEngine;

public class ClosePanelOnClick : MonoBehaviour
{
    public GameObject panelWrapper;

    public void ClosePanel()
    {
        panelWrapper.SetActive(false);
    }
}
