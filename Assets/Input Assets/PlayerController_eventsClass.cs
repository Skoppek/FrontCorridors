using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController_eventsClass : MonoBehaviour
{
    public Camera cm;
    public bool freeze = false;
    public float moveSpeed = 1.0f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public Vector3 increaseValues = new Vector3(3f, 0, 0);
    public float cp_position_gain;
    public float cp_position_speed;


    


    private GameObject cp;
    private Vector2 moveInput, lastMoveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Vector3 minValues, maxValues;



    private EventInputAction eventInputAction;
    private InputAction move;




    private void Awake()
    {
        eventInputAction = new EventInputAction();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cp = GameObject.Find("CameraPoint");
    }

    private void OnEnable()
    {
        move = eventInputAction.Player.Move;
        move.Enable();

        eventInputAction.Player.Use.performed += DoUse;
        eventInputAction.Player.Use.Enable();
    }

    private void DoUse(InputAction.CallbackContext obj)
    {
        Debug.Log("Used!");
    }

    private void OnDisable()
    {
        move.Disable();
        eventInputAction.Player.Use.Disable();
    }

    private void FixedUpdate()
    {
        minValues = cm.gameObject.GetComponent<CameraFollow>().minValues;
        maxValues = cm.gameObject.GetComponent<CameraFollow>().maxValues;

        moveInput = move.ReadValue<Vector2>();
        if (moveInput.x == 0)
        {
            cp.transform.localPosition = new Vector3(0, 1, 0);
        }
        //Debug.Log("Movement Values " + move.ReadValue<Vector2>());
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



    public bool MovePlayer(Vector2 direction)
    {
        if (
            Math.Abs(cp.transform.localPosition.x) < cp_position_gain
            && cp.transform.position.x < maxValues.x
           
            && cp.transform.position.x > minValues.x
            
            ) cp.transform.localPosition += (increaseValues * direction.x) * Time.fixedDeltaTime * cp_position_speed;
        
        
        
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
                if (direction.x > 0)
                {
                    FacingSide(false);
                }
                else
                {
                    FacingSide(true);
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



    void FacingSide(bool turned)
    {
        if (turned)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


}
