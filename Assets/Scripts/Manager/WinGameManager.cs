using TMPro;
using UnityEngine;

public class WinGameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Đụng trúng");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Đụng trúng player luôn");
            winPanel.SetActive(true);
        }
        if (other.gameObject == player)
        {
            Debug.Log("Đụng trúng player luôn");
            winPanel.SetActive(true);
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
