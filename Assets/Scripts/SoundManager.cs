using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _pickupSound;
    [SerializeField]
    private AudioSource _outOfTimeSound;
    [SerializeField]
    private AudioSource _spottedSound;
    [SerializeField]
    private AudioSource _winSound;

    private void Start()
    {
        Timer.onOutOfTime += PlayOutOfTime;
        DetectionZone.onSpotted += PlaySpotted;
        PickupSystem.onPickupSound += PlayPickup;
        FinishZone.onWin += PlayWin;
    }

    private void OnDestroy()
    {
        Timer.onOutOfTime -= PlayOutOfTime;
        DetectionZone.onSpotted -= PlaySpotted;
        PickupSystem.onPickupSound -= PlayPickup;
        FinishZone.onWin -= PlayWin;
    }

    private void PlayPickup()
    {
        _pickupSound.Play();
    }

    private void PlayOutOfTime()
    {
        _outOfTimeSound.Play();
    }

    private void PlaySpotted()
    {
        _spottedSound.Play();
    }

    private void PlayWin()
    {
        _winSound.Play();
    }
}
