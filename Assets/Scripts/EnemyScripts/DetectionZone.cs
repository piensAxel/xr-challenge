using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DetectionZone : MonoBehaviour
{
    private Material _zoneMat;
    [SerializeField]
    private ParticleSystem _particle;
    [SerializeField]
    private EnemyMovement _enemyMov;

    public static Action onSpotted;

    private bool _hasDied = false;
    private void Start()
    {
        _zoneMat = GetComponent<Renderer>().material;
        Timer.onOutOfTime += SetHasDied;
    }

    private void OnDestroy()
    {
        Timer.onOutOfTime -= SetHasDied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_hasDied)
        {
            Vector3 direction = other.transform.position - transform.parent.position;
            RaycastHit info;
            if (Physics.Raycast(transform.parent.position, direction, out info))
            {
                if (info.collider.tag == "Player")
                {
                    if (onSpotted != null)
                        onSpotted();

                    other.GetComponent<CharacterMovement>().HasDied = true;
                    _zoneMat.color = Color.red;
                    _particle.Play();
                    _enemyMov.PlayerInSight(other.transform.position);
                    _hasDied = true;
                }
            }
        }
    }

    private void SetHasDied()
    {
        _hasDied = true;
    }
}
