using UnityEngine;

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
    public int TakeDamage(int damage)
    {
        Debug.Log(Name + " recoit " + damage + " de degats !");
        Health = Substract(Health, damage);
        if (Health <= 0)
        {
            if (Name == "Player")
            {
                Debug.Log("Vous etes mort !");
            }
            else
            {
                Debug.Log(Name + " a peri !");
            }
        }
        return (int)Health;
    }
}