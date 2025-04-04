using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    private List<Character> turnOrder = new();
    private int currentCharacterIndex;
    
    private bool isFirstEnemy = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        turnOrder.AddRange(Character.GetAllCharacters());
        turnOrder.Sort((a, b) => b.CompareSpeeds(a));

        StartNextTurn();
    }

    private void StartNextTurn()
    {
        if (currentCharacterIndex >= turnOrder.Count)
        {
            currentCharacterIndex = 0;
        }

        Character currentCharacter = turnOrder[currentCharacterIndex];

        if (currentCharacter.CompareTag("Player"))
        {
            Debug.Log("C est le tour du joueur !");
            ShowPlayerActionMenu(currentCharacter);
        }
        else if (currentCharacter.CompareTag("Enemy"))
        {
            Debug.Log("C est le tour de l ennemi !");
            Character player = turnOrder.Find(c => c.CompareTag("Player"));
            currentCharacter.DoDamage(player);
        }

        currentCharacterIndex++;

        StartNextTurn();
    }
    
    private void ShowPlayerActionMenu(Character player)
    {
        //TODO : Appeler une des methodes dans player.cs selon le choix sur l ui
    }

    public void RemoveFromCombat(Character character)
    {
        turnOrder.Remove(character);
        Debug.Log(character + " a quitte le combat.");
    }
    
    public bool IsCharacterInCombat(Character character)
    {
        return turnOrder.Contains(character);
    }

    public void AddToCombat(Character character)
    {
        if (!IsCharacterInCombat(character))
        {
            turnOrder.Add(character);
            Debug.Log(character + " a rejoint le combat.");
            
            if (isFirstEnemy)
            {
                isFirstEnemy = false;
                ActivateCombatUI();
            }
        }
    }
    
    public void ActivateCombatUI()
    {
        FightInventory fi = GameObject.Find("InventoryCanvas").GetComponent<FightInventory>();
        fi.StateUiFight(true);
        Debug.Log("L UI de combat est maintenant activee.");
    }
    
    public void DesactivateCombatUI()
    {
        FightInventory fi = GameObject.Find("InventoryCanvas").GetComponent<FightInventory>();
        fi.StateUiFight(true);
        Debug.Log("L UI de combat est maintenant fermee.");
    }
}