using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isExtend;
    public static bool IsStart = true;
    public static int _timer;
    
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
            10 => true,
            20 => false,
            30 => true,
            50 => false,
            60 => true,
            70 => false,
            _ => BaseShake.StartShaking
        };
        
        Debug.Log(_timer);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1);
        _timer++;
        IsStart = true;
    }

    public static int GetTimer()
    {
        return _timer;
    }
}
