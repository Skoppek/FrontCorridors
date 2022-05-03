using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_info_script : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject canvas;
    private GameObject curHealth_index;
    private GameObject curSanity_index;
    void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        curHealth_index = canvas.transform.Find("health").gameObject;
        curSanity_index = canvas.transform.Find("sanity").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth(float newHealth)
    {
        curHealth_index.GetComponent<Text>().text = newHealth.ToString();
    }

    public void UpdateSanity(float newSanity)
    {
        curSanity_index.GetComponent<Text>().text = newSanity.ToString();
    }
}
