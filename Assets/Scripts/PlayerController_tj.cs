using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_tj : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public Vector3 increaseValues = new Vector3(3f, 0, 0);

    private GameObject cp;
    private Vector2 moveInput,lastMoveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cp = GameObject.Find("CameraPoint");
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

    void FacingSide(bool turned)
    {
        if(turned)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput.x == 0)
        {
            cp.transform.localPosition = new Vector3(0,1,0);
        }
       
    }

    void CameraPointAjustment(Vector3 dir)
    {

    }

    public bool MovePlayer(Vector2 direction)
    {
        if (Math.Abs(cp.transform.localPosition.x)<2) cp.transform.localPosition += (increaseValues * direction.x )  * Time.fixedDeltaTime*2;
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveVector);

            // Zmiana rozmiarów gracza w zale¿noœci od odleg³oœci od kamery
            //
            // if (direction.y>0) this.transform.localScale -= new Vector3(0.1f, 0.1f);
            // if(direction.y<0) this.transform.localScale += new Vector3(0.1f, 0.1f);

            if (lastMoveInput != direction)
            {
                //print("lmi = "+lastMoveInput.x);
                //print("dir = "+direction.x);
                switch (direction.x)
                {
                    case 1:
                        FacingSide(false);
                        break;
                    case -1:
                        FacingSide(true);
                        break;
                }
            }
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

