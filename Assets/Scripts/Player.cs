using UnityEngine;

public class Player : Character
{
    private float Energy { get; set; }
    
    public Player(string name, float health, float atk, float def, float speed)
        : base(name, health, atk, def, speed)
    {
        Energy = 100;
    }
    
    public void Defend()
    {
        Debug.Log(Name + " se defend.");
    }

    public void Flee()
    {
        Debug.Log(Name + " fuit le combat!");
        BattleManager.Instance.RemoveFromCombat(this);
        BattleManager.Instance.DesactivateCombatUI();
    }
    
    public void OpenInventory()
    {
        Debug.Log(Name + " ouvre l inventaire.");
        //TODO: ouvrir inventaire

    }
        
}