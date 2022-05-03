using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Char_Loading : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public Transform spawnPoint;
    public Transform Parent;
    public Camera cam;
    
    void Awake()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = charPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity,Parent);
        var n_target = clone.transform.Find("CameraPoint").gameObject;
        clone.gameObject.GetComponent<PlayerController_eventsClass>().cm = cam;
        
        cam.gameObject.GetComponent<CameraFollow>().target = n_target;

    }

}
