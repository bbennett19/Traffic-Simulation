using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	public float max_speed;
    public float acceleration;
    private float m_currentSpeed = 0f;
    private Vector3 m_speedVector = new Vector3();

    private void Update()
    {
        m_currentSpeed += acceleration * Time.deltaTime;
        if(m_currentSpeed > max_speed)
        {
            m_currentSpeed = max_speed;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        m_speedVector = transform.forward * m_currentSpeed * Time.deltaTime;
        this.transform.position += m_speedVector;
	}
}
