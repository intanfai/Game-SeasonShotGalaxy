using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;

    [Header("Target Dropzone")]
    public string correctDropZoneName; // Nama dropzone yang cocok

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogWarning("CanvasGroup not found on " + gameObject.name + ". Please add one!");
            canvasGroup = gameObject.AddComponent<CanvasGroup>(); // auto add if missing
        }

        startPosition = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        GameObject dropTarget = eventData.pointerEnter;

        if (dropTarget != null && dropTarget.CompareTag("DropZone"))
        {
            // Cek apakah drop zone-nya benar
            if (dropTarget.name == correctDropZoneName)
            {
                // Snap ke posisi dropzone, tapi jangan ubah parent
                // rectTransform.SetPositionAndRotation(dropTarget.transform.position, Quaternion.identity);
                rectTransform.anchoredPosition = dropTarget.GetComponent<RectTransform>().anchoredPosition;  
            }
            else
            {
                ReturnToStart();
            }
        }
        else
        {
            ReturnToStart();
        }
    }

    private void ReturnToStart()
    {
        rectTransform.position = startPosition;
    }
}
