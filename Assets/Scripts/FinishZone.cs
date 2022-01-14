using System;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField]
    private int _totalPickups = 5;

    public static Action<string> onEnterFinish;
    public static Action<bool> onRestart;
    public static Action onExitFinish;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int amount = other.GetComponent<PickupPoints>().CurrentPickups;
            if (_totalPickups == amount)
            {
                print("win");
                if (onEnterFinish != null)
                    onEnterFinish("YOU WON!");
                if (onRestart != null)
                    onRestart(false);
            }
            else
            {
                print("not enough pickups collected!");
                if (onEnterFinish != null)
                    onEnterFinish("YOU MISSED " + (_totalPickups - amount) + " PICKUPS!");

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (onExitFinish != null)
                onExitFinish();
        }
    }
}
