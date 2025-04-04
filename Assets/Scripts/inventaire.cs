using System.Collections.Generic;
using UnityEngine;

public class InventoryAndAbilities : MonoBehaviour
{
    public List<string> items = new List<string>(); // Liste des objets
    public List<string> specialAttacks = new List<string>(); // Liste des attaques sp�ciales

    void Start()
    {
        // Ajouter des objets ou attaques initiales
        items.Add("Potion");
        items.Add("�lixir");
        specialAttacks.Add("Coup puissant");
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log($"Objet ajout� : {item}");
    }

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Objet retir� : {item}");
        }
    }

    public void AddSpecialAttack(string attack)
    {
        specialAttacks.Add(attack);
    }
}