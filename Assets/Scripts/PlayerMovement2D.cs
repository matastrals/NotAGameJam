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

}