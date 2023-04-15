using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float reachedDistance = 0.1f;
    private GameObject menu; 
    private Vector2 move = new();
    private Rigidbody2D rb;
    private Animator anim;

    private PlayerInputs input;

    public PlayerInvenotry playerInventory;

    private CanvasGroup menuCanvasGroup;

    private Vector2 targetPosition; // The position to which the player will move
    private bool reached = true; // Whether the player has reached the target position

    private void OnEnable()
    {
        move = Vector2.zero;
        input = new PlayerInputs();
        input.Player.Enable();

        input.Player.Inventory.performed += playerInventory.OpenInvetory;
    }
    private void OnDisable()
    {
        input.Player.Disable();
        input.Player.Inventory.performed -= playerInventory.OpenInvetory;
    }
    private void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    private void FixedUpdate()
    { 
        if(!reached)
            move = (targetPosition - rb.position);

        // if mouse hasnt clicked to move, use keyboard input
        if(targetPosition == Vector2.zero)
            move = input.Player.Move.ReadValue<Vector2>();
        move.Normalize();
        // Move the player
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        FaceDirection();
        Animations();
    }

    private void Update()
    {
        // Check if the left mouse button has been clicked
        if (Mouse.current.leftButton.wasPressedThisFrame  && !EventSystem.current.IsPointerOverGameObject())
        {
            // Get the position of the mouse click in world space
            targetPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            reached = false;
        }

        //Debug.Log("Target Pos: " + targetPosition + " | RB position: " + rb.position);
        // if the player is reachedDistance unit close to the targetPosition, stop
        if (Vector2.Distance(rb.position, targetPosition) <= reachedDistance)
        {
            //Debug.Log("Reached");
            reached = true;
            targetPosition = Vector2.zero;
            move = Vector2.zero;
        }

    }


    // temporary flip
    private void FaceDirection()
    {
        if (move.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Animations()
    {
         anim.SetFloat("move", move.magnitude);
    }
}
