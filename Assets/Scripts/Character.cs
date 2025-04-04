using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    // Getters et Setters
    protected string Name { get; set; }

    protected float Health { get; set; }

    protected float Atk { get; set; }

    protected float Def { get; set; }

    protected float Speed { get; set; }

    // Constante
    protected const float ROAMING_SPEED = 2f;
    
    private static List<Character> allCharacters = new();
    
    private DeathScreenScript deathScreenScript = GameObject.Find("DeathScreen").GetComponent<DeathScreenScript>();

    // Constructeur
    public Character()
    {
        Health = 100;
        Atk = 10;
        Def = 5;
        Speed = 5;
    }

    public Character(string name, float health, float atk, float def, float speed)
    {
        Name = name;
        Health = health;
        Atk = atk;
        Def = def;
        Speed = speed;
    }

    // Fonction soustraire
    private float Substract(float actualValue, float valueToSubstract)
    {
        return (actualValue - valueToSubstract < 0) ? 0 : actualValue - valueToSubstract;
    }

    // Fonction ajouter
    public float Add(float actualValue, float valueToAdd)
    {
        return actualValue + valueToAdd > (float)Constants.MAX_BATTLE_STAT ? (float)Constants.MAX_BATTLE_STAT : actualValue + valueToAdd;
    }

    // Fonction TakeDamage
    public void TakeDamage(float damage)
    {
        Debug.Log(Name + " recoit " + damage + " de degats !");
        Health = Substract(Health, damage);

        if (Health <= 0)
        {
            if (CompareTag("Player"))
            {
                Debug.Log("Le joueur est mort !");
                BattleManager.Instance.RemoveFromCombat(this);
                deathScreenScript.callDeathScreen();
            }
            else if (CompareTag("Enemy"))
            {
                Debug.Log(Name + " est vaincu !");
                BattleManager.Instance.RemoveFromCombat(this);
                CheckVictory();
            }
            else
            {
                Debug.Log("Tag inconnu pour " + Name);
            }
        }
    }

    
    // Fonction DoDamage
    public void DoDamage(Character otherCharacter)
    {
        float damage = Mathf.Max(0, Atk - otherCharacter.Def);

        Debug.Log(Name + " inflige " + damage + " de degats a " + otherCharacter.Name);
        otherCharacter.TakeDamage(damage);
    }

    // Fonction CheckVictory
    private void CheckVictory()
    {
        List<Character> enemies = allCharacters.FindAll(c => c.CompareTag("Enemy"));

        if (enemies.Count == 0)
        {
            // TODO: Ecran de victoire
            Debug.Log("Tous les ennemis ont ete vaincus ! Vous avez gagne !");
        }
    }
    
    public static List<Character> GetAllCharacters()
    {
        return new List<Character>(allCharacters);
    }
    
    public int CompareSpeeds(Character otherCharacter)
    {
        if (Speed > otherCharacter.Speed)
        {
            return -1;
        }

        if (Speed < otherCharacter.Speed)
        {
            return 1;
        }

        return 0;
    }


    private void Start()
    {
        allCharacters.Add(this);
    }

    private void OnDestroy()
    {
        allCharacters.Remove(this);
    }
}
