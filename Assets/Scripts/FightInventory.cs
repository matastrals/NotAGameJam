using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FightInventory : MonoBehaviour
{
    public GameObject panelActionButton;
    public GameObject panelMoveButton;

    private void Start()
    {
        panelActionButton.SetActive(false);
        panelMoveButton.SetActive(false);
    }


    public void StateUiFight(bool isFighting)
    {
        if (isFighting)
        {
            panelActionButton.SetActive(true);
            GameObject actionButton = GameObject.Find("ActionButton");
            EventSystem.current.SetSelectedGameObject(actionButton);
        } else
        {
            panelActionButton.SetActive(false);
        }
    }



    public void ActionButton()
    {
        panelMoveButton.SetActive(true);
        GameObject attackButton = GameObject.Find("AttaqueButton");
        EventSystem.current.SetSelectedGameObject(attackButton);
    }
}
