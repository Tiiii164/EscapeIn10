using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UISoundController : MonoBehaviour
{
    public GameObject exitButton;
    //private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Intro");
        }
    }
    private void Start()
    {
        
    }
    //public void CloseSoundPanel()
    //{
    //    soundMenu.SetActive(false);
    //}
}
