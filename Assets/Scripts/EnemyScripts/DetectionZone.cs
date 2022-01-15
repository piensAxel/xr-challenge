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
        if (other.tag == "Player")
        {
            Vector3 direction = other.transform.position - transform.parent.position;
            RaycastHit info;
            if (Physics.Raycast(transform.parent.position, direction, out info))
            {
                if (info.collider.tag == "Player")
                {
                    other.GetComponent<CharacterMovement>().HasDied = true;
                    _zoneMat.color = Color.red;
                    _particle.Play();
                    _enemyMov.PlayerInSight(other.transform.position);
                    print("death");
                }
            }
        }
    }
}
