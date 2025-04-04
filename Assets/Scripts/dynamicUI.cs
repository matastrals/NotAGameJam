using UnityEngine;
using UnityEngine.UI;

public class DynamicMenu : MonoBehaviour
{
    public GameObject buttonPrefab; // Pr�fabriqu� pour un bouton
    public Transform contentPanel; // Panel parent o� les boutons seront ajout�s
    public InventoryAndAbilities inventory; // R�f�rence � l'inventaire et aux attaques sp�ciales

    public void DisplayItems()
    {
        // Supprimer les anciens boutons avant de g�n�rer de nouveaux
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // G�n�rer un bouton pour chaque objet
        foreach (string item in inventory.items)
        {
            GameObject button = Instantiate(buttonPrefab, contentPanel);
            button.GetComponentInChildren<Text>().text = item;

            // Ajouter un listener pour g�rer les clics sur ce bouton
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
        Debug.Log($"Objet s�lectionn� : {item}");
        // Ajoutez ici la logique pour utiliser l'objet
    }

    void OnAttackClicked(string attack)
    {
        Debug.Log($"Attaque sp�ciale s�lectionn�e : {attack}");
        // Ajoutez ici la logique pour effectuer l'attaque sp�ciale
    }
}