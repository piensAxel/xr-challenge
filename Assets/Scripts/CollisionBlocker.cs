using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlocker : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider _playerCollider, _playerBlockerCollider;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(_playerCollider, _playerBlockerCollider, true);
    }
}
