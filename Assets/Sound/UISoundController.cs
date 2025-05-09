using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISoundController : MonoBehaviour
{
    public GameObject soundMenu;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            soundMenu.SetActive(isOpen);
        }
    }
    private void Start()
    {
        
    }
    public void CloseSoundPanel()
    {
        soundMenu.SetActive(false);
    }
}
