using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 targetPosition; // Target position to move towards
    public float speed = 2.0f; // Movement speed

    private Vector2 startPosition; // Starting position of the enemy
    private bool movingToTarget = true; // Track whether moving towards the target position

    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        // Record the starting position of the enemy
        startPosition = transform.position;

        // Get reference to Animator component
        animator = GetComponent<Animator>();

        // Start walking animation immediately
        animator.SetBool("iswalking", true);
    }

    private void Update()
    {
        // Determine the current target (switch between targetPosition and startPosition)
        Vector2 currentTarget = movingToTarget ? targetPosition : startPosition;

        // Move the enemy towards the current target
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Flip the character sprite based on movement direction
        FlipSprite(currentTarget);

        // Check if the enemy reached the target
        if (Vector2.Distance(transform.position, currentTarget) < 0.01f)
        {
            // Switch direction when reaching the target
            movingToTarget = !movingToTarget;
        }
    }

    // Flip the character sprite based on movement direction
    private void FlipSprite(Vector2 target)
    {
        // Get the direction of movement
        float direction = target.x - transform.position.x;

        // Flip the sprite if moving left, unflip if moving right
        if (direction > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Face right
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Face left
        }
    }
}
