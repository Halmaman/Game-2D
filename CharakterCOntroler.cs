using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterCOntroler : MonoBehaviour
{

    public float moveSpeed;
    public float jumpheight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;



    // Use this for initialization
    void Start()
    {

    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    // Update is called once per frame
    void Update()
    {
        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            // GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, y: jumpheight);
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.W) && !doubleJumped && !grounded)
        {
            // GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, y: jumpheight);
            Jump();
            doubleJumped = true;
        }



        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }


    }
    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, y: jumpheight);

    }
}