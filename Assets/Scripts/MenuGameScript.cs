using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (Input.GetKey(KeyCode.Pause))
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

}
