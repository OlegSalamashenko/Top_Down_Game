using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private void Update()
    {
        FaceMouse();
    }

    private void FaceMouse()
    {
        Vector3 mousePositio = Input.mousePosition;
        mousePositio = Camera.main.ScreenToViewportPoint(mousePositio);

        Vector2 direction = transform.position - mousePositio;

        transform.right = -direction;
    }
}
