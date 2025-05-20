using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private Transform startParent;
    public Transform correctSlot;
    public float magnetDistance = 50f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector3.Distance(transform.position, correctSlot.position);
        if (distance <= magnetDistance)
        {
            transform.position = correctSlot.position;
            GameManager.Instance.RegisterCorrectDrop();
        }
        else
        {
            transform.position = startPos;
            transform.SetParent(startParent);
        }
    }
}
