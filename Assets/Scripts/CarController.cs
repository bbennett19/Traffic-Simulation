using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    private enum CarState {NORMAL, APP_INT, WAIT_INT, FOLLOW};
	public float max_speed;
    public float acceleration;
    public float start_speed = 0f;
    public float deceleration = 3f;
    private float m_currentSpeed = 0f;
    private Vector3 m_speedVector = new Vector3();
    private IntersectionController m_intController = null;
    private CarController m_carController = null;
    private bool m_following = false;
    private bool m_inIntersection = false;
    private bool m_slowingDown = false;
    private IntersectionPhase m_phase = null;
    private void Start()
    {
        m_currentSpeed = start_speed;
    }

    private void Update()
    {
        if (m_following)
        {
            m_currentSpeed = m_carController.GetCurrentSpeed();
        }
        else if (m_inIntersection)
        {            
            if (!m_slowingDown)
            {
                float stop_dist = Mathf.Abs(transform.position.z - m_intController.stop_z);
                float actual_stop_dist = (m_currentSpeed * m_currentSpeed) / (2f * deceleration);
                m_slowingDown = true;
            }
            else
            {
                m_currentSpeed -= deceleration * Time.deltaTime;
                if(m_currentSpeed < 0f)
                {
                    m_currentSpeed = 0f;
                }
            }
            if(m_phase.CurrentState == PhaseState.ACTIVE)
            {
                m_slowingDown = false;
                m_inIntersection = false;
                m_phase = null;
                m_intController = null;
            }
        }
        else
        {
            m_currentSpeed += acceleration * Time.deltaTime;
            if (m_currentSpeed > max_speed)
            {
                m_currentSpeed = max_speed;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate () {
        m_speedVector = transform.forward * m_currentSpeed * Time.deltaTime;
        this.transform.position += m_speedVector;
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("Intersection"))
        {
            m_intController = other.GetComponent<IntersectionController>();
            m_phase = m_intController.GetPhase(transform.forward);
            m_inIntersection = true;

        }
    }

    public float GetCurrentSpeed()
    {
        return m_currentSpeed;
    }
}
