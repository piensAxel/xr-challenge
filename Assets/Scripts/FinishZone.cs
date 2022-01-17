using System;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField]
    private string _winText;
    public static Action<string> onEnterFinish;
    public static Action<bool, string> onRestart;
    public static Action onExitFinish;
    public static Action onWin;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int amount = other.GetComponent<PickupSystem>().CurrentPickups;
            int total = other.GetComponent<PickupSystem>().TotalPickups;
            if (total == amount)
            {
                print("win");
                if (onRestart != null)
                    onRestart(false, _winText);
                if (onWin != null)
                    onWin();
            }
            else
            {
                print("not enough pickups collected!");
                if (onEnterFinish != null)
                    onEnterFinish("YOU MISSED " + (total - amount) + " PICKUPS!");

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
