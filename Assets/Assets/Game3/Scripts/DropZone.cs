using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Saat item di-drop
        RectTransform droppedItem = eventData.pointerDrag.GetComponent<RectTransform>();
        droppedItem.position = transform.position; // snap ke tengah dropzone
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Efek tarik: kalau ada draggable mendekat
        if (eventData.pointerDrag != null)
        {
            RectTransform draggedItem = eventData.pointerDrag.GetComponent<RectTransform>();
            draggedItem.position = Vector3.Lerp(draggedItem.position, transform.position, 0.2f); // efek tarik halus
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Tidak perlu efek saat keluar
    }
}
