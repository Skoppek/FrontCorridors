using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCpntroler_tomasz : MonoBehaviour
{
    private Vector3 moveDelta;

    private CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Debug.Log(x);
        Debug.Log(y);
    }
}
