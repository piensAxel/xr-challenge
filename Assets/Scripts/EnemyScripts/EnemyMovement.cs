using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //walk back and forwards
    [SerializeField]
    private float _moveSpeed = 10.0f, _rotateSpeed = 5.0f;
    [SerializeField]
    private List<Transform> _movingPoints;
    [SerializeField]
    private Animator _anim;


    private Rigidbody _rb;
    private Vector3 _moveDir, _lookDir;
    private int _currentMovingPoint = 0;
    private bool _isMovingBack = false, _hasCalculatedPoint = false, _isAtPoint = false, _isRotating = true;
    RigidbodyConstraints _originalConstraints;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originalConstraints = _rb.constraints;
        transform.position = _movingPoints[0].position;
        NextMovingPoint();
        _moveDir = _movingPoints[_currentMovingPoint].position - transform.position;
        transform.rotation = Quaternion.LookRotation(_moveDir);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAtPoint)
        {
            if (transform.position.x <= _movingPoints[_currentMovingPoint].position.x + 0.1f &&
                transform.position.x >= _movingPoints[_currentMovingPoint].position.x - 0.1f &&
                transform.position.z <= _movingPoints[_currentMovingPoint].position.z + 0.1f &&
                transform.position.z >= _movingPoints[_currentMovingPoint].position.z - 0.1f)
            {
                _isAtPoint = true;
                _hasCalculatedPoint = false;
                _moveDir = Vector3.zero;
            }
        }
        else
        {
            
            if(!_hasCalculatedPoint)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotationX | ~RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                _hasCalculatedPoint = true;
                _isRotating = true;
                NextMovingPoint();
            }

            if (_isRotating)
            {
                _anim.SetBool("IsIdle", true);
                Rotate();
            }
            else
            {
                _anim.SetBool("IsIdle", false);

                _isAtPoint = false;
                _rb.constraints = _originalConstraints;
                _moveDir = _movingPoints[_currentMovingPoint].position - transform.position;
            }
        }

    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDir.normalized * _moveSpeed;
    }

    private void NextMovingPoint()
    {
        if (_isMovingBack)
        {
            --_currentMovingPoint;
            if (_currentMovingPoint < 0)
            {
                _currentMovingPoint += 2;
                _isMovingBack = false;
            }
        }
        else
        {
            ++_currentMovingPoint;
            if (_currentMovingPoint > _movingPoints.Count-1)
            {
                _currentMovingPoint -= 2;
                _isMovingBack = true;
            }
        }


    }

    private void Rotate()
    {
        _lookDir = _movingPoints[_currentMovingPoint].position - transform.position;
        float dot = Vector3.Dot(transform.forward, _lookDir);
        float mag = transform.forward.magnitude * _lookDir.magnitude;
        float angle = Mathf.Acos(dot / mag) * (180 / Mathf.PI);
        if (angle > 1.0f)
        {
            Vector3 lookat = Vector3.RotateTowards(transform.forward, _lookDir, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(lookat);
        }
        else
        {
            _isRotating = false;
        }
    }
}
