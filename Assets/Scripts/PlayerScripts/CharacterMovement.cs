using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float _moveSpeed = 10.0f;
    private Rigidbody _rb;
    private Vector3 _moveDir;

    private Animator _anim;

    public bool HasDied = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasDied)
        {
            _moveDir.x = Input.GetAxisRaw("Horizontal");
            _moveDir.z = Input.GetAxisRaw("Vertical");
            _anim.SetFloat("Horizontal", _moveDir.x);
            _anim.SetFloat("Vertical", _moveDir.z);
            _anim.SetFloat("Speed", _moveDir.sqrMagnitude);
        }
        else
        {
            _anim.SetFloat("Speed", 0);
            _anim.SetBool("IsSpotted", true);
            _moveDir = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {   
        _rb.velocity = _moveDir.normalized * _moveSpeed;
        
    }
}
