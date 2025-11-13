using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Animation variables
    private Animator animator;

    // Interaction variables
    public float interactionRange = 2.0f;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Update animation
        HandleAnimation();

        // Handle interaction
        if (Input.GetButtonDown("Interact"))
        {
            HandleInteraction();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void HandleAnimation()
    {
        animator.SetFloat("Speed", movement.magnitude);
    }

    void HandleInteraction()
    {
        RaycastHit2D hit = Physics2D.Raycast(mainCamera.transform.position, mainCamera.ScreenToWorldPoint(Input.mousePosition) - mainCamera.transform.position, interactionRange);
        if (hit.collider != null)
        {
            // Interact with the object
            hit.collider.SendMessage("Interact");
        }
    }
}