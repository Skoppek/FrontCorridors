using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private DimmerControl dimmer;
    GameObject destination;
    float dimTime;

    void Start()
    {
        dimmer = Camera.main.transform.Find("Dimmer").gameObject.GetComponent<DimmerControl>();
    }
    private IEnumerator teleportExecute()
    {
        dimmer.targetAlpha = 1;
        yield return new WaitForSeconds(dimTime);
        transform.position = destination.transform.position;
        yield return new WaitForSeconds(dimTime);
        dimmer.targetAlpha = 0;
    }

    public void teleportToObject(GameObject destination, float dimTime)
    {
        this.destination = destination;
        this.dimTime = dimTime;
        StartCoroutine(teleportExecute());
    }

}
