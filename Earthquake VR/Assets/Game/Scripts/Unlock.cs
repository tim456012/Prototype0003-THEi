using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Unlock : MonoBehaviour
{
    public TeleportPoint point;
    
    // Update is called once per frame
    private void Update()
    {
        if (Timer.GetTimer() >= 30)
            point.locked = false;
    }
}
