using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedx = 0.1f;
    public float speedy = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal")*speedx*Time.deltaTime, Input.GetAxis("Vertical")*speedy*Time.deltaTime);
    }
}
