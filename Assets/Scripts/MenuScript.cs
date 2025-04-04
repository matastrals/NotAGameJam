using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            Debug.Log("Bouton sélectionné : " + EventSystem.current.currentSelectedGameObject.name);
            Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            ColorBlock colorBlock = button.colors;
            colorBlock.selectedColor = Color.gray;
            button.colors = colorBlock;
        }
    }
    
    void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    void QuitButton()
    {
        Application.Quit();
    }
}
