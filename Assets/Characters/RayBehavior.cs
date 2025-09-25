using UnityEngine;
using UnityEngine.Tilemaps;

public class RayBehavior : MonoBehaviour
{
    [HideInInspector] public PlayerMovement2D playerMovement; // assigned on spawn
    private float raySpeed = 40f;

    private Vector3 moveDirection;

    void Start()
    {
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement2D reference not assigned!");
            return;
        }

        // Set movement vector and sprite rotation based on player's direction
        switch (playerMovement.direction)
        {
            case "up":
                moveDirection = Vector3.up;
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case "right":
                moveDirection = Vector3.right;
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case "down":
                moveDirection = Vector3.down;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case "left":
                moveDirection = Vector3.left;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            default:
                moveDirection = Vector3.up; // default direction
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    void Update()
    {
        // Move the bullet along the precomputed move direction
        transform.position += moveDirection * raySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy bullet on hitting walls or enemies
        EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject); // destroy enemy
            Destroy(gameObject);       // destroy bullet
            return;
        }

        if (collision is TilemapCollider2D || collision is CompositeCollider2D)
        {
            Destroy(gameObject);
            return;
        }

        // Generic: destroy on anything else
        Destroy(gameObject);
        }
}
