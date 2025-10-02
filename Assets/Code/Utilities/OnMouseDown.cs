using UnityEngine;
using UnityEngine.InputSystem;

public class OnMouseDown : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(
                    Camera.main.ScreenPointToRay(
                        Mouse.current.position.ReadValue()),
                    out RaycastHit raycastHit,
                    Mathf.Infinity))
            {
                IOnMouseDown onMouse = raycastHit.collider.gameObject.GetComponent<IOnMouseDown>();

                onMouse?.OnMouseDown();
            }
        }
    }
}