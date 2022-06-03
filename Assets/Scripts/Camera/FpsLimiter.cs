using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
    }
}
