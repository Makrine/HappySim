using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    

    private Vector2 move = new();
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Get the input from the player
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        move.Normalize(); // Normalize the vector to prevent diagonal movement from being faster
    }

    private void FixedUpdate()
    { 
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
