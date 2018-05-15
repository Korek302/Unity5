using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 4.0f;
    public float minVert = -50.0f;
    public float maxVert = 90.0f;

    private float rotationX = 0;
    private float rotationY = 0;
    private bool acceptInput = true;

    private void Start()
    {
        Messenger.AddListener(GameEvent.FINISH_GAME, OnFinish);
    }

    void Update ()
    {
        if (acceptInput)
        {
            float mY = Input.GetAxis("Mouse Y");
            float mX = Input.GetAxis("Mouse X");

            rotationX -= mY * rotationSpeed;
            rotationY += mX * rotationSpeed;

            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
            transform.parent.GetComponent<Transform>().localEulerAngles = new Vector3(0, rotationY, 0);
        }
    }

    private void OnFinish()
    {
        acceptInput = false;
    }
}
