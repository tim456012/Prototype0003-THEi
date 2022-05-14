using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Lift : MonoBehaviour
{
    public TeleportPoint teleportPoint;
    public GameObject door1, door2;
    
    private bool _btn1Pressed, _btn2Pressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (_btn1Pressed && _btn2Pressed)
        {
            if (BaseShake.StartShaking)
                BaseShake.StartShaking = false;
            
            teleportPoint.locked = false;
            Destroy(door1);
            Destroy(door2);
        }
    }

    public void Button1Pressed()
    {
        _btn1Pressed = true;
    }
    
    public void Button2Pressed()
    {
        _btn2Pressed = true;
    }
}
