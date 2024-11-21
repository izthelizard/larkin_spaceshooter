using Codice.Client.BaseCommands.CheckIn.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float speed = 3f;
    public float jumpHeight = 7f;

    public enum FacingDirection
    {
        left, right
    }

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        Vector2 playerInput = new Vector2();
        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }

    public bool IsWalking()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }
    public bool IsGrounded()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, jumpHeight);
            return false;
        }
            return true;
    }

    public FacingDirection GetFacingDirection()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return FacingDirection.right;
        }
        return FacingDirection.left;
    }
}
