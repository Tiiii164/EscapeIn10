using UnityEngine;
using UnityEngine.EventSystems;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class SimpleCursorToggle : MonoBehaviour
{
    private bool isCursorVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ToggleCursor();
        }

        if (isCursorVisible && Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUI())
            {
                Debug.Log("CLICK UI → Ẩn chuột lại");
                ToggleCursor();
            }
        }
    }

    bool IsPointerOverUI()
    {
#if ENABLE_INPUT_SYSTEM
        return EventSystem.current.IsPointerOverGameObject(Mouse.current.deviceId);
#else
        return EventSystem.current.IsPointerOverGameObject();
#endif
    }

    void ToggleCursor()
    {
        isCursorVisible = !isCursorVisible;
        Cursor.visible = isCursorVisible;
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
