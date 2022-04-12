using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_trigger : MonoBehaviour
{
    public GameObject prefab;
    private GameObject marker;
    public float markerYOffset = 0;
    void OnTriggerEnter2D(Collider2D col) {
        marker = Instantiate<GameObject>(
            prefab,
            transform.position + new Vector3(0, markerYOffset, 0),
            transform.rotation);
        Debug.Log("podejscie do drzwi " + Time.time);
    }

    void OnTriggerExit2D(Collider2D col) {
        Destroy(marker);
        Debug.Log("odejscie od drzwi " + Time.time);
    }
}
