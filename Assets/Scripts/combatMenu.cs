using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject specialAttackMenu; // Référence au Panel des attaques spéciales
    public GameObject itemMenu;         // Référence au Panel des objets
    public GameObject mainMenu;         // Référence au menu principal

    public void OpenSpecialAttackMenu()
    {
        mainMenu.SetActive(false); // Masquer le menu principal
        specialAttackMenu.SetActive(true); // Afficher le sous-menu des attaques spéciales
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
        mainMenu.SetActive(true); // Réafficher le menu principal
    }
}