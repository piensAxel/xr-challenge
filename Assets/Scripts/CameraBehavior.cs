using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private float _screenXBoundary = 0, _screenZBoundary = 0;
    [SerializeField]
    private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > _screenXBoundary)
            transform.position = new Vector3(_screenXBoundary, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(_player.position.x, -_screenXBoundary, _screenXBoundary), transform.position.y, Mathf.Clamp(_player.position.z, -_screenZBoundary, _screenZBoundary));
    }
}
