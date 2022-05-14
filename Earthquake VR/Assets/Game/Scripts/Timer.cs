using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int _timer;
    private bool IsStart = true;
    private IEnumerator _startTimer;
    
    // Start is called before the first frame update
    private void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsStart)
        {
            _startTimer = StartTimer();
            StartCoroutine(_startTimer);
            IsStart = false;
        }

        BaseShake.StartShaking = _timer switch
        {
            5 => true,
            30 => false,
            _ => BaseShake.StartShaking
        };

    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1);
        _timer++;
        IsStart = true;
    }
}
