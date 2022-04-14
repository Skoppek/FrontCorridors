using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerControl : MonoBehaviour
{
    private SpriteRenderer sr;
    public float changeSpeed;
    public float targetAlpha;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        change();
    }

    void change() 
    {
        float currentAlpha = sr.color.a;
        sr.color = new Color(0, 0, 0, Mathf.Lerp(currentAlpha, targetAlpha, changeSpeed*Time.deltaTime));
    }
}
