using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class door_trigger : MonoBehaviour
{
    
    public GameObject prefab;
    public GameObject destination;
    private GameObject marker;
    private EventInputAction eventInputAction;


    private bool active=false;
    public float markerYOffset = 0;
    private Collider2D player_present;
    private void Awake()
    {
        eventInputAction = new EventInputAction();
    }

    private void OnEnable()
    {

        eventInputAction.Player.Use.performed += DoUse;
        eventInputAction.Player.Use.Enable();
        
    }

    private void DoUse(InputAction.CallbackContext obj)
    {
        if (active)
        {
            StartCoroutine(movePlayer(player_present));
        }
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        marker = Instantiate<GameObject>(
            prefab,
            transform.position + new Vector3(0, markerYOffset, 0),
            transform.rotation);
        player_present = player;

        active = true;
        


        Debug.Log("podejscie do drzwi " + Time.time);
    }

    IEnumerator movePlayer(Collider2D player)
    {
        Camera cm = player.GetComponent<PlayerController_eventsClass>().cm;
        player.GetComponent<PlayerController_eventsClass>().freeze = true;
        cm.gameObject.GetComponentInChildren<DimmerControl>().targetAlpha = 1;
        yield return new WaitForSecondsRealtime(0.1f);
        cm.GetComponent<CameraFollow>().smoothFactor = 100;
        player.transform.position = destination.transform.position;
        yield return new WaitForSecondsRealtime(0.1f);
        cm.GetComponent<CameraFollow>().smoothFactor = 3;
        cm.gameObject.GetComponentInChildren<DimmerControl>().targetAlpha = 0;
        player.GetComponent<PlayerController_eventsClass>().freeze = false;
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Destroy(marker);
        Debug.Log("odejscie od drzwi " + Time.time);
        active = false;
    }
}
