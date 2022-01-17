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
    public static Action onOutOfTime;

    private bool _hasDied = false;
    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = _totalTime;
        PickupSystem.onAddTime += AddTime;
        DetectionZone.onSpotted += SetHasDied;
    }

    private void OnDestroy()
    {
        PickupSystem.onAddTime -= AddTime;
        DetectionZone.onSpotted -= SetHasDied;
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(_timeLeft);
        if (!_hasDied)
        {
            updateTime(string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds));
            if (_timeLeft <= 0.5f)
            {
                onTimeOver(true, _endText);
                onOutOfTime();
                _hasDied = true;
            }
        }
    }

    private void AddTime(float time)
    {
        _timeLeft += time;
    }


    private void SetHasDied()
    {
        _hasDied = true;
    }


}
