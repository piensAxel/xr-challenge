using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Timer : MonoBehaviour
{
    [SerializeField]
    private float _totalTime;
    [SerializeField]
    private string _endText;
    private float _timeLeft;
    public static Action<bool, string> onTimeOver;
    public static Action<string> updateTime;

    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = _totalTime;
        PickupSystem.onAddTime += AddTime;
    }

    private void OnDestroy()
    {
        PickupSystem.onAddTime -= AddTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(_timeLeft);
        updateTime(string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds));
        if(_timeLeft <= 0.0f)
        {
            onTimeOver(true, _endText);
        }
    }

    private void AddTime(float time)
    {
        _timeLeft += time;
    }


}
