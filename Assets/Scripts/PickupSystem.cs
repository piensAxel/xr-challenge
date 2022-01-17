using System;
using UnityEngine;
public class PickupSystem : MonoBehaviour
{
    //variables that could be added to pickup script (non-editable)
    //in that case each pickup could have a different time that is added
    [SerializeField]
    private float _timeAdded = 15.0f;



    private int _totalScore = 0;
    public int CurrentPickups { get; private set; }
    [SerializeField]
    private int _totalPickups;
    public int TotalPickups => _totalPickups;

    public static Action<int> onAddScore;
    public static Action<float> onAddTime;
    public static Action<int, int> onPickup;
    public static Action onPickupSound;
    private void Start()
    {
        CurrentPickups = 0;
        Invoke("SetPickupsInfo", 0.0001f);
    }

    private void SetPickupsInfo()
    {
        if (onPickup != null)
            onPickup(CurrentPickups, TotalPickups);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            int value =  other.GetComponent<Pickup>().GetPickedUp();
            if (value != -1)
            {
                _totalScore += value;
                ++CurrentPickups;
                if(onAddScore != null)
                    onAddScore(_totalScore);
                if (onAddTime != null)
                    onAddTime(_timeAdded);
                if (onPickup != null)
                    onPickup(CurrentPickups, 5);
                if (onPickupSound != null)
                    onPickupSound();
            }
        }
    }
}
