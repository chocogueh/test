using UnityEngine;

public class GC_Rotater : MonoBehaviour
{
    private float speed = 1f;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            transform.Rotate(Vector3.up, -deltaMouse.x * speed, Space.World);
            transform.Rotate(Vector3.right, deltaMouse.y * speed);
            lastMousePosition = Input.mousePosition;
        }
    }
}
