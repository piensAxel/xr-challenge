using System;
using UnityEngine;
public class PickupSystem : MonoBehaviour
{
    //variable that could be added to pickup script (non-editable)
    //in that case each pickup could have a different time that is added
    [SerializeField]
    private float _timeAdded = 15.0f;

    private int _totalScore = 0;
    public int CurrentPickups { get; private set; }

    public static Action<int> onAddScore;
    public static Action<float> onAddTime;

    private void Start()
    {
        CurrentPickups = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            int value =  other.GetComponent<Pickup>().GetPickedUp();
            if (value != -1)
            {
                _totalScore += value;
                if(onAddScore != null)
                    onAddScore(_totalScore);
                if (onAddTime != null)
                    onAddTime(_timeAdded);
                ++CurrentPickups;
            }
        }
    }
}
