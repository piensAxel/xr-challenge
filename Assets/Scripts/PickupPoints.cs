using System;
using UnityEngine;
public class PickupPoints : MonoBehaviour
{
    private int _totalScore = 0;

    public static Action<int> onAddScore;

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
            }
        }
    }
}
