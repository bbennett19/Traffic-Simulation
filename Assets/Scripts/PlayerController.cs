using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float topSpeed;
    public float acceleration;
    public float idleDeceleration;
    public float breakingDeceleration;

    private float currentSpeed = 0.0f;
    private Vector3 speedVector = new Vector3();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = Mathf.Max(0.0f, currentSpeed - breakingDeceleration * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = Mathf.Min(topSpeed, currentSpeed + acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Max(0.0f, currentSpeed - idleDeceleration * Time.deltaTime);
        }
        
	}

    private void FixedUpdate()
    {
        speedVector.z = currentSpeed * Time.fixedDeltaTime;
        this.gameObject.transform.position += speedVector;
    }
}
