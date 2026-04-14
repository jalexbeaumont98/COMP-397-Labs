using UnityEngine;
using UnityEngine.InputSystem;

public class MouseDebug : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Mouse.current = " + (Mouse.current == null ? "NULL" : "FOUND"));
        Debug.Log("Keyboard.current = " + (Keyboard.current == null ? "NULL" : "FOUND"));
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
                Debug.Log("NEW INPUT: Left click detected");

            Vector2 delta = Mouse.current.delta.ReadValue();
            if (delta != Vector2.zero)
                Debug.Log("NEW INPUT: Mouse delta " + delta);
        }
    }
}
