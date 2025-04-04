using UnityEngine;

public class Enemy : Character
{
    private Transform target;
    private Rigidbody2D rb;
    private bool isChasing;
    private Vector2 randomDirection;
    
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
            Debug.Log("Combat initie");
            rb.velocity = Vector2.zero;
            isChasing = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            
            //methode pour lancer le combat

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            SetRandomDirection();
        }
    }
}
