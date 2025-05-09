using TMPro;
using UnityEngine;

public class WinGameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winPanel.SetActive(true);
        }
    }
}
