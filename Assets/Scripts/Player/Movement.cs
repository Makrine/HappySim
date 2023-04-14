using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    

    private Vector2 move = new();
    private Rigidbody2D rb;
    private Animator anim;

    private PlayerInputs input;

    public PlayerInvenotry playerInventory;

    private void Awake() 
    {
        input = new PlayerInputs();
        input.Player.Enable();

        input.Player.Inventory.performed += OpenInvetory;
    }

    private void OpenInvetory(InputAction.CallbackContext obj)
    {
        if(playerInventory.inventory.IsOpen)
        {
            playerInventory.inventory.OpenInventory(false);
        }
            
        else
        {
            playerInventory.inventory.OpenInventory(true);
        }
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
        // if (move.x != 0 || move.y != 0)
        // {
        //     anim.SetFloat("x", move.x);
        //     anim.SetBool("walk", true);
        // }
        // else
        // {
        //     anim.SetBool("walk", false);
        // }
    }
}
