using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField]
    private int _totalPickups = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_totalPickups == other.GetComponent<PickupPoints>().CurrentPickups)
                print("win");
            else
                print("not enough pickups collected!");
        }
    }
}
