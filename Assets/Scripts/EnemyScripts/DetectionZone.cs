using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private Material _zoneMat;
    [SerializeField]
    private ParticleSystem _particle;
    [SerializeField]
    private EnemyMovement _enemyMov;
    private void Start()
    {
        _zoneMat = GetComponent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CharacterMovement>().HasDied = true;
            _zoneMat.color = Color.red;
            _particle.Play();
            _enemyMov.PlayerInSight(other.transform.position);
            print("death");
        }
    }
}
