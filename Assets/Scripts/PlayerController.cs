using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10.0f;
    private Rigidbody _player;
    private int _pickUpCount = 0;

	void Start ()
    {
        _player = this.GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        _player.AddForce(new Vector3(x, 0.0f, z) * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            _pickUpCount++;
        }
    }
}
