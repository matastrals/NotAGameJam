using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : Character
{
    private Transform target;
    private Rigidbody2D rb;
    private bool isChasing;
    private Vector2 randomDirection;

    private static List<GameObject> engagedEnemies = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        SetRandomDirection();
    }

    private void SetRandomDirection()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float randomX = Random.Range(0f, screenWidth);
        float randomY = Random.Range(0f, screenHeight);

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(randomX, randomY, Camera.main.nearClipPlane));

        randomDirection = (worldPosition - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        if (isChasing && target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * (ROAMING_SPEED * 2);
        }
        else
        {
            rb.velocity = randomDirection * ROAMING_SPEED;
        }

        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D: {other.gameObject.name}, tag: {other.gameObject.tag}, has Player component: {other.GetComponent<Player>() != null}");

        if (other.CompareTag("Player") && other.GetComponent<Player>() != null)
        {
            Debug.Log("Joueur detecte par ennemi: " + gameObject.name);
            target = other.transform;
            isChasing = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Player>() != null)
        {
            // Méthode pour lancer le combat
            RepositionEnemies(collision.transform);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            SetRandomDirection();
        }
    }

    private void RepositionEnemies(Transform playerTransform)
    {
        // Ajouter l'ennemi dans la liste s'il n'y est pas encore
        if (!engagedEnemies.Contains(gameObject))
        {
            engagedEnemies.Add(gameObject);
            
            rb.velocity = Vector2.zero;
            isChasing = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }

        int enemyCount = engagedEnemies.Count;
    
        // Définir un padding pour éviter le chevauchement avec le joueur
        float yPadding = 1.0f;  // Distance minimale en Y entre le joueur et les ennemis
        float spacing = 1.5f;   // Distance entre chaque ennemi sur l'axe X

        // Nouvelle position de base avec un padding en Y
        Vector2 basePosition = new Vector2(playerTransform.position.x, playerTransform.position.y + yPadding);

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = engagedEnemies[i];

            if (enemyCount == 1)
            {
                // Un seul ennemi, il est en face du joueur avec un léger offset en Y
                enemy.transform.position = basePosition;
            }
            else
            {
                // Alternance gauche/droite en fonction de l'index
                int side = (i % 2 == 0) ? -1 : 1; // Pair à gauche, impair à droite
                float offset = (i / 2 + 1) * spacing * side; // Décalage progressif en X

                enemy.transform.position = new Vector2(basePosition.x + offset, basePosition.y);
            }
        }
    }

    
}
