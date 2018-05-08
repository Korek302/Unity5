using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _player;
    private Vector3 _offset;

	void Start ()
    {
        _offset = transform.position - _player.position;
	}
	
	void Update ()
    {
        transform.position = _player.position + _offset;	
	}
}
