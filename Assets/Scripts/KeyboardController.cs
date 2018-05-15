using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public float speed = 15.0f;
    public float gravity = -9.8f;
    private bool acceptInput = true;

    private CharacterController charController;
    
	void Start ()
    {
        charController = this.GetComponent<CharacterController>();
        Messenger.AddListener(GameEvent.FINISH_GAME, OnFinish);
    }
	
	void Update ()
    {
        if (acceptInput)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);

            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;

            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);

            charController.Move(movement);
        }
    }

    private void OnFinish()
    {
        acceptInput = false;
    }
}
