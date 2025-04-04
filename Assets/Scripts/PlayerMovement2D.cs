using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement
    public Rigidbody2D rb; // Composant Rigidbody2D
    private Vector2 _moveDirection; // Direction de d�placement
    public InputActionReference move; // R�f�rence � l'action de mouvement

    private void Update()
    {
        // V�rifier si le joueur appuie sur le bouton de saut
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Appliquer le mouvement dans un environnement 2D
        rb.velocity = new Vector2(_moveDirection.x * speed, _moveDirection.y * speed);
    }

}