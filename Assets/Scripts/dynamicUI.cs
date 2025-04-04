using UnityEngine;
using UnityEngine.UI;

public class DynamicMenu : MonoBehaviour
{
    public GameObject buttonPrefab; // Préfabriqué pour un bouton
    public Transform contentPanel; // Panel parent où les boutons seront ajoutés
    public InventoryAndAbilities inventory; // Référence à l'inventaire et aux attaques spéciales

    public void DisplayItems()
    {
        // Supprimer les anciens boutons avant de générer de nouveaux
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Générer un bouton pour chaque objet
        foreach (string item in inventory.items)
        {
            GameObject button = Instantiate(buttonPrefab, contentPanel);
            button.GetComponentInChildren<Text>().text = item;

            // Ajouter un listener pour gérer les clics sur ce bouton
            button.GetComponent<Button>().onClick.AddListener(() => OnItemClicked(item));
        }
    }

    public void DisplaySpecialAttacks()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (string attack in inventory.specialAttacks)
        {
            GameObject button = Instantiate(buttonPrefab, contentPanel);
            button.GetComponentInChildren<Text>().text = attack;
            button.GetComponent<Button>().onClick.AddListener(() => OnAttackClicked(attack));
        }
    }

    void OnItemClicked(string item)
    {
        Debug.Log($"Objet sélectionné : {item}");
        // Ajoutez ici la logique pour utiliser l'objet
    }

    void OnAttackClicked(string attack)
    {
        Debug.Log($"Attaque spéciale sélectionnée : {attack}");
        // Ajoutez ici la logique pour effectuer l'attaque spéciale
    }
}