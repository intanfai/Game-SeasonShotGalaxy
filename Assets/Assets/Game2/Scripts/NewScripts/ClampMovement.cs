using UnityEngine;

public class ClampMovement : MonoBehaviour
{
    public float minY = -4f;
    public float maxY = 4f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
