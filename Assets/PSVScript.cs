using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSVScript : MonoBehaviour
{
    public Transform Player_m;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
