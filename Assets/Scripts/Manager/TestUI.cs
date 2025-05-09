using UnityEngine;
using UnityEngine.EventSystems;

public class UIClickTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Click trúng UI!");
            }
            else
            {
                Debug.Log("Click KHÔNG trúng UI");
            }
        }
    }
}
