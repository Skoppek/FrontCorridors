using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerx = player.transform.position.x;
        float camerax = this.transform.position.x;
        this.gameObject.transform.position += new Vector3((playerx-camerax)*speed*Time.deltaTime,0);
    }
}
