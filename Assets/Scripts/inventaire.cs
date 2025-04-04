using System.Collections.Generic;
using UnityEngine;

public class InventoryAndAbilities : MonoBehaviour
{
    public List<string> items = new List<string>(); // Liste des objets
    public List<string> specialAttacks = new List<string>(); // Liste des attaques spéciales

    void Start()
    {
        // Ajouter des objets ou attaques initiales
        items.Add("Potion");
        items.Add("Élixir");
        specialAttacks.Add("Coup puissant");
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log($"Objet ajouté : {item}");
    }

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Objet retiré : {item}");
        }
    }

    public void AddSpecialAttack(string attack)
    {
        specialAttacks.Add(attack);
    }
}