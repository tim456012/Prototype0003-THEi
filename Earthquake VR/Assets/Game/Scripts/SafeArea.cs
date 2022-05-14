using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        BaseShake.StartShaking = true;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLayer");
        }
    }
}
