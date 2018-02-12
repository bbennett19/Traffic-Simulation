using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour {
    private IntersectionPhase[] m_phases;
    private float m_elapsedTime = 0.0f;
    private int m_currentPhase = 0;
    public StoplightController[] lightToPhase_0;
    public StoplightController[] lightToPhase_1;
    public StoplightController[] lightToPhase_2;
    public StoplightController[] lightToPhase_3;
    public float stop_z;
    public float stop_x;
    public PhoneController phoneController;
    // Use this for initialization
    void Start () {
        m_phases = new IntersectionPhase[3];
        m_phases[0] = new IntersectionPhase(10f, 3f, 0, 1, lightToPhase_0);
        m_phases[1] = new IntersectionPhase(10f, 3f, 1, 2, lightToPhase_1);
        m_phases[2] = new IntersectionPhase(10f, 3f, 2, 0, lightToPhase_2);
        m_phases[m_currentPhase].SetPhaseState(PhaseState.ACTIVE);
    }


	// Update is called once per frame
	void Update () {
        m_elapsedTime += Time.deltaTime;

        if(m_phases[m_currentPhase].CurrentState == PhaseState.TRANSITION && m_elapsedTime >= m_phases[m_currentPhase].TransitionTime)
        {
            m_phases[m_currentPhase].SetPhaseState(PhaseState.NOT_ACTIVE);
            m_currentPhase = m_phases[m_currentPhase].NextPhase;
            m_phases[m_currentPhase].SetPhaseState(PhaseState.ACTIVE);
            m_elapsedTime = 0.0f;
        }
        else if(m_phases[m_currentPhase].CurrentState == PhaseState.ACTIVE && m_elapsedTime >= m_phases[m_currentPhase].ActiveTime)
        {
            m_phases[m_currentPhase].SetPhaseState(PhaseState.TRANSITION);
            m_elapsedTime = 0.0f;
        }
		
	}

    internal void CheckCar(CarController c)
    {
        if(c.transform.forward.x > 0f)
        {
            
            float dist = Mathf.Abs(c.transform.position.x - stop_x);
            float stop_dist = (c.GetCurrentSpeed() * c.GetCurrentSpeed()) / (2f * c.deceleration);

            if(stop_dist - dist >= 0.5f)
            {
                //warn biker
                phoneController.Warn();
            }

        }
        else if(c.transform.forward.z > 0f)
        {

            float dist = Mathf.Abs(c.transform.position.x - stop_z);
            float stop_dist = (c.GetCurrentSpeed() * c.GetCurrentSpeed()) / (2f * c.deceleration);

            if (stop_dist - dist >= 0.5f)
            {
                //warn biker
                phoneController.Warn();
            }

        }
    }

    internal IntersectionPhase GetPhase(Vector3 direction)
    {
        return m_phases[2];
    }
}
