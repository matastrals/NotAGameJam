using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameScript : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf)
            {
                panel.SetActive(false);
            } else
            {
                panel.SetActive(true);
            }
        }
    }


    public void ResumeGame()
    {
        panel.SetActive(false);
    }


    public void ReturnToLobby()
    {
        SceneManager.LoadScene("Menu");
    }
}
