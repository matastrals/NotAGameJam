using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject resumeButton;
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
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            ColorBlock colorBlock = button.colors;
            colorBlock.selectedColor = Color.gray;
            button.colors = colorBlock;
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
