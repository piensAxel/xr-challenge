using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private float _screenPosXBoundary = 0, _screenNegXBoundary = 0, _screenPosZBoundary = 0, _screenNegZBoundary = 0;
    [SerializeField]
    private Transform _player;

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(_player.position.x, _screenNegXBoundary, _screenPosXBoundary), transform.position.y, Mathf.Clamp(_player.position.z, _screenNegZBoundary, _screenPosZBoundary));
    }
}
