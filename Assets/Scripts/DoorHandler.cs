using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public GameObject prefab;
    public GameObject destination;
    void OnTriggerEnter2D(Collider2D player) {
        player.GetComponent<PlayerTeleport>().teleportToObject(destination, 0.3f);
        Debug.Log("podejscie do drzwi " + Time.time);
    }

    void OnTriggerExit2D(Collider2D col) {

        Debug.Log("odejscie od drzwi " + Time.time);
    }
}
