using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_tj : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;


    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        bool success = MovePlayer(moveInput);
        
        if (!success)
        {
            success = MovePlayer(new Vector2(moveInput.x, 0));
            if (!success)
            {
                success = MovePlayer(new Vector2(moveInput.y, 0));
            }
        }
    }

    void FacingSide(Vector2 dir)
    {
        if(dir.x >= 0.0f)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        FacingSide(moveInput);
    }

    public bool MovePlayer(Vector2 direction)
    {
        
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveVector);
            
            return true;
        }
        else
        {
            foreach (RaycastHit2D hit in castCollisions) 
            {
                //print(hit.ToString());
            }
            return false;
        }
    }

}

