using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    private string characterName;
    private float health;
    private float maxHealth;
    private float energy;
    private float maxEnergy;
    private float atk;
    private float maxAtk;
    private float def;
    private float maxDef;
    private float speed;
    private float maxSpeed;
    private float roamingSpeed = 2f;

    // Getters et Setters
    public string Name { get => characterName; set => characterName = value; }
    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Energy { get => energy; set => energy = value; }
    public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public float Atk { get => atk; set => atk = value; }
    public float MaxAtk { get => maxAtk; set => maxAtk = value; }
    public float Def { get => def; set => def = value; }
    public float MaxDef { get => maxDef; set => maxDef = value; }
    public float Speed { get => speed; set => speed = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public float RoamingSpeed { get => roamingSpeed; set => roamingSpeed = value; }

    // Constructeur
    public character()
    {
    }

    // Fonction soustraire
    public float Soustraire(float valActuelle, float valMax, float ValeurASoustraire)
    {
        if (valActuelle - ValeurASoustraire < 0)
        {
            valActuelle = 0;
        }
        else
        {
            valActuelle -= ValeurASoustraire;
        }
        return valActuelle;
    }

    // Fonction ajouter
    public float Ajouter(float valActuelle, float valMax, float ValeurAAjouter)
    {
        valActuelle += ValeurAAjouter;
        if (valActuelle > valMax)
        {
            valActuelle = valMax;
        }
        return valActuelle;
    }

    // Fonction TakeDamage
    public int TakeDamage(int damage)
    {
        Debug.Log(Name+"reçoit " + damage+"de dégats");
        Health = Soustraire(health, maxHealth, damage);
        if (health <= 0)
        {
            if (Name == "Player")
            {
                Debug.Log("vous êtes mort");
            }
            else
            {
                Debug.Log(Name + " a péri");
            }
        }
        return (int)health;
    }
}
public class Enemy : character
{
    public int Cooldown; // Temps nécessaire avant une action spéciale
    public Enemy(string name, float health, float maxHealth, float atk, float def, float speed)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Atk = atk;
        Def = def;
        Speed = speed;
    }
}

public class Player : character
{
    public Player(string name, float health, float maxHealth, float atk, float def, float speed)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Atk = atk;
        Def = def;
        Speed = speed;
    }
}

