using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_trigger : MonoBehaviour
{
    public GameObject prefab;
    public GameObject destination;
    private GameObject marker;

    public float markerYOffset = 0;
    void OnTriggerEnter2D(Collider2D player) {
        marker = Instantiate<GameObject>(
            prefab,
            transform.position + new Vector3(0, markerYOffset, 0),
            transform.rotation);
            
            StartCoroutine(movePlayer(player));
            
        
        Debug.Log("podejscie do drzwi " + Time.time);
    }

    IEnumerator movePlayer(Collider2D player)
    {
        Camera cm = player.GetComponent<PlayerController_tj>().cm;
        player.GetComponent<PlayerController_tj>().freeze = true;
        cm.gameObject.GetComponentInChildren<DimmerControl>().targetAlpha = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        float temp = cm.GetComponent<CameraFollow>().smoothFactor;
        cm.GetComponent<CameraFollow>().smoothFactor = 100;
        player.transform.position = destination.transform.position;
        yield return new WaitForSecondsRealtime(0.1f);
        cm.GetComponent<CameraFollow>().smoothFactor = temp;
        cm.gameObject.GetComponentInChildren<DimmerControl>().targetAlpha = 0;
        player.GetComponent<PlayerController_tj>().freeze = false;
    }

    void OnTriggerExit2D(Collider2D col) {
        Destroy(marker);
        Debug.Log("odejscie od drzwi " + Time.time);
    }
}
