using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject specialAttackMenu; // R�f�rence au Panel des attaques sp�ciales
    public GameObject itemMenu;         // R�f�rence au Panel des objets
    public GameObject mainMenu;         // R�f�rence au menu principal

    public void OpenSpecialAttackMenu()
    {
        mainMenu.SetActive(false); // Masquer le menu principal
        specialAttackMenu.SetActive(true); // Afficher le sous-menu des attaques sp�ciales
    }

    public void OpenItemMenu()
    {
        mainMenu.SetActive(false); // Masquer le menu principal
        itemMenu.SetActive(true); // Afficher le sous-menu des objets
    }

    public void BackToMainMenu()
    {
        specialAttackMenu.SetActive(false);
        itemMenu.SetActive(false);
        mainMenu.SetActive(true); // R�afficher le menu principal
    }
}