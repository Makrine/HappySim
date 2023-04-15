using UnityEngine;

/// <summary>
/// This class handles player controls
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;


    private Vector2 move = new();
    private Rigidbody2D rb;
    private Animator anim;

    private PlayerInputs input;

    public PlayerInvenotry playerInventory;
    public UkePlaying ukePlaying;

    private CanvasGroup menuCanvasGroup;

    private void OnEnable()
    {
        move = Vector2.zero;
        input = new PlayerInputs();
        input.Player.Enable();

        input.Player.Inventory.performed += playerInventory.OpenInvetory;
        input.Player.Move.performed += ctx => ukePlaying.PlayUke(false);
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
        move = input.Player.Move.ReadValue<Vector2>();
        move.Normalize();

        // Move the player
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        
        FaceDirection();
        Animations();
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
