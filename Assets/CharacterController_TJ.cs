using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_TJ : MonoBehaviour
{

    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position;
        

    }
}
