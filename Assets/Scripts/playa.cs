using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    public Rigidbody2D rb; // Composant Rigidbody2D
    private Vector2 _moveDirection; // Direction de déplacement
    public InputActionReference move; // Référence à l'action de mouvement

    private void Update()
    {
        // Vérifier si le joueur appuie sur le bouton de saut
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Appliquer le mouvement dans un environnement 2D
        rb.velocity = new Vector2(_moveDirection.x * speed, _moveDirection.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCombat(collision.gameObject);
        }
    }

    public GameObject combatUI;

    private void OpenCombatInterface()
    {
        combatUI.SetActive(true); // Affiche l'interface de combat
        Time.timeScale = 0; // Met le jeu en pause
    }


    private void StartCombat(GameObject enemy)
    {
        Vector3 playerNewPosition = transform.position + new Vector3(-2f, 0, 0); // Déplace le joueur
        Vector3 enemyNewPosition = enemy.transform.position + new Vector3(2f, 0, 0); // Déplace l'ennemi

        transform.position = playerNewPosition;
        enemy.transform.position = enemyNewPosition;

        OpenCombatInterface(); // Ouvre l'interface de combat
    }


}