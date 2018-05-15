using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _scale = 0.0f;
    private float _scaleMax = 2.0f;
    private float _scaleMin = 1.0f;

	void Update ()
    {
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
